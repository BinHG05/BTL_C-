using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using System.Diagnostics;

namespace ExpenseManager.App.Services
{
    public class BudgetService : IBudgetService
    {
        private readonly IBudgetRepository _budgetRepo;
        private readonly ITransactionRepository _transactionRepo;

        public BudgetService(IBudgetRepository budgetRepo, ITransactionRepository transactionRepo)
        {
            _budgetRepo = budgetRepo;
            _transactionRepo = transactionRepo;
        }

        public async Task<IEnumerable<BudgetSummaryDto>> GetUserBudgetSummariesAsync(string userId)
        {
            var budgets = await _budgetRepo.GetByUserAsync(userId);

            if (budgets == null || !budgets.Any()) return new List<BudgetSummaryDto>();

            var summaries = new List<BudgetSummaryDto>();

            foreach (var budget in budgets)
            {
                var spent = await CalculateSpentAmountAsync(budget, userId);

                summaries.Add(new BudgetSummaryDto
                {
                    BudgetId = budget.BudgetId,
                    CategoryId = budget.CategoryId,
                    CategoryName = budget.Category?.CategoryName ?? "Unknown",
                    IconId = budget.Category?.IconId ?? 0,
                    IconClass = budget.Category?.Icon?.IconClass,
                    HexCode = budget.Category?.Color?.HexCode,
                    ColorId = budget.Category?.ColorId ?? 0,
                    BudgetAmount = budget.BudgetAmount,
                    SpentAmount = spent,
                    PercentageUsed = budget.BudgetAmount > 0
                        ? Math.Round((spent / budget.BudgetAmount) * 100, 1)
                        : 0
                });
            }

            return summaries.OrderByDescending(b => b.BudgetId);
        }

        public async Task<BudgetDetailDto> GetBudgetDetailAsync(int budgetId, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);
            if (budget == null || budget.UserId != userId) return null;

            var spent = await CalculateSpentAmountAsync(budget, userId);
            var remainingAmount = budget.BudgetAmount - spent;
            var daysRemaining = (budget.EndDate.Date - DateTime.Now.Date).Days;

            var recentTransactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            return new BudgetDetailDto
            {
                BudgetId = budget.BudgetId,
                CategoryId = budget.CategoryId,
                CategoryName = budget.Category.CategoryName,
                IconId = budget.Category.IconId,
                ColorId = budget.Category.ColorId,
                BudgetAmount = budget.BudgetAmount,
                SpentAmount = spent,
                RemainingAmount = remainingAmount, // Vẫn giữ số âm để tính toán logic
                PercentageUsed = budget.BudgetAmount > 0 ? Math.Round((spent / budget.BudgetAmount) * 100, 1) : 0,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                DaysRemaining = daysRemaining > 0 ? daysRemaining : 0,
                IsOverBudget = spent > budget.BudgetAmount,
                IsRecurring = budget.IsRecurring,
                RecentTransactions = recentTransactions.OrderByDescending(t => t.TransactionDate).Take(10)
                    .Select(t => new TransactionItemDto { TransactionId = t.TransactionId, Description = t.Description, Amount = t.Amount, TransactionDate = t.TransactionDate, WalletId = t.WalletId }).ToList()
            };
        }

        public async Task<IEnumerable<ExpenseBreakdownDto>> GetExpenseBreakdownAsync(
            int budgetId, string userId, DateTime? startDate = null, DateTime? endDate = null, string grouping = "Day")
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);
            if (budget == null || budget.UserId != userId)
                return new List<ExpenseBreakdownDto>();

            // ✅ Nếu không truyền date range, dùng range của budget
            var effectiveStartDate = startDate ?? budget.StartDate;
            var effectiveEndDate = endDate ?? budget.EndDate;

            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, effectiveStartDate, effectiveEndDate);

            var query = transactions.Where(t => t.Type == "Expense");

            IEnumerable<ExpenseBreakdownDto> result;

            switch (grouping?.ToLower())
            {
                case "week":
                    result = query
                        .GroupBy(t => {
                            // Nhóm theo đầu tuần (Chủ Nhật)
                            return t.TransactionDate.Date.AddDays(-(int)t.TransactionDate.DayOfWeek);
                        })
                        .Select(g => new ExpenseBreakdownDto
                        {
                            Date = g.Key,
                            TotalAmount = g.Sum(t => t.Amount),
                            TransactionCount = g.Count()
                        });
                    break;

                case "month":
                    result = query
                        .GroupBy(t => new DateTime(t.TransactionDate.Year, t.TransactionDate.Month, 1))
                        .Select(g => new ExpenseBreakdownDto
                        {
                            Date = g.Key,
                            TotalAmount = g.Sum(t => t.Amount),
                            TransactionCount = g.Count()
                        });
                    break;

                default: // Day
                    result = query
                        .GroupBy(t => t.TransactionDate.Date)
                        .Select(g => new ExpenseBreakdownDto
                        {
                            Date = g.Key,
                            TotalAmount = g.Sum(t => t.Amount),
                            TransactionCount = g.Count()
                        });
                    break;
            }

            return result.OrderBy(e => e.Date).ToList();
        }

        public async Task<Budget> CreateBudgetAsync(BudgetCreateDto dto, string userId)
        {
            var existingBudgets = await _budgetRepo.GetByUserAsync(userId);
            if (existingBudgets.Any(b => b.CategoryId == dto.CategoryId)) throw new InvalidOperationException("Danh mục này đã có ngân sách!");

            var budget = new Budget { UserId = userId, CategoryId = dto.CategoryId, BudgetAmount = dto.BudgetAmount, StartDate = dto.StartDate, EndDate = dto.EndDate, IsRecurring = dto.IsRecurring, CreatedAt = DateTime.Now };
            return await _budgetRepo.AddAsync(budget);
        }

        public async Task<bool> UpdateBudgetAsync(int budgetId, BudgetUpdateDto dto, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);
            if (budget == null || budget.UserId != userId) return false;

            budget.CategoryId = dto.CategoryId;
            budget.BudgetAmount = dto.BudgetAmount;
            budget.StartDate = dto.StartDate;
            budget.EndDate = dto.EndDate;
            budget.IsRecurring = dto.IsRecurring;

            return await _budgetRepo.UpdateAsync(budget);
        }

        public async Task<bool> DeleteBudgetAsync(int budgetId, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);
            if (budget == null || budget.UserId != userId) return false;
            return await _budgetRepo.DeleteAsync(budgetId);
        }

        private async Task<decimal> CalculateSpentAmountAsync(Budget budget, string userId)
        {
            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(userId, budget.CategoryId, budget.StartDate, budget.EndDate);
            return transactions.Where(t => t.Type == "Expense").Sum(t => t.Amount);
        }
    }

    public class BudgetSummaryDto
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IconId { get; set; }
        public int ColorId { get; set; }
        public string IconClass { get; set; }
        public string HexCode { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal PercentageUsed { get; set; }
        public string FormattedBudget => $"{BudgetAmount:N0}đ";
        public string FormattedSpent => $"{SpentAmount:N0}đ";
    }

    public class BudgetDetailDto
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IconId { get; set; }
        public int ColorId { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public decimal PercentageUsed { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int DaysRemaining { get; set; }
        public bool IsOverBudget { get; set; }
        public bool IsRecurring { get; set; }
        public List<TransactionItemDto> RecentTransactions { get; set; }

        public string FormattedBudget => $"{BudgetAmount:N0}đ";
        public string FormattedSpent => $"{SpentAmount:N0}đ";

        // --- SỬA ĐOẠN NÀY: Nếu âm thì hiển thị là 0đ ---
        public string FormattedRemaining => $"{(RemainingAmount < 0 ? 0 : RemainingAmount):N0}đ";
        // ------------------------------------------------

        public string FormattedStartDate => StartDate.ToString("dd/MM/yyyy");
        public string FormattedEndDate => EndDate.ToString("dd/MM/yyyy");
    }

    public class TransactionItemDto
    {
        public int TransactionId { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public int WalletId { get; set; }
        public string FormattedAmount => $"{Amount:N0}đ";
        public string FormattedDate => TransactionDate.ToString("dd/MM/yyyy HH:mm");
    }

    public class ExpenseBreakdownDto
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int TransactionCount { get; set; }
        public string FormattedDate => Date.ToString("dd/MM/yyyy");
        public string FormattedAmount => $"{TotalAmount:N0}đ";
    }

    public class BudgetCreateDto
    {
        public int CategoryId { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
    }

    public class BudgetUpdateDto
    {
        public int CategoryId { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
    }
}