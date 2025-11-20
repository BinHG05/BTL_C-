using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Repositories;
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
            Debug.WriteLine($"[BudgetService] GetUserBudgetSummariesAsync: Bắt đầu lấy danh sách ngân sách cho UserId: {userId}");

            var budgets = await _budgetRepo.GetByUserAsync(userId);

            Debug.WriteLine($"[BudgetService] GetUserBudgetSummariesAsync: Số lượng ngân sách từ DB: {budgets?.Count()}");

            if (budgets == null || !budgets.Any())
            {
                Debug.WriteLine("[BudgetService] GetUserBudgetSummariesAsync: Không có ngân sách nào được tìm thấy.");
                return new List<BudgetSummaryDto>();
            }

            var summaries = new List<BudgetSummaryDto>();

            foreach (var budget in budgets)
            {
                Debug.WriteLine($"[BudgetService] GetUserBudgetSummariesAsync: Xử lý ngân sách ID: {budget.BudgetId}, CategoryId: {budget.CategoryId}");

                var spent = await CalculateSpentAmountAsync(budget, userId);

                Debug.WriteLine($"[BudgetService] GetUserBudgetSummariesAsync: SpentAmount cho ngân sách {budget.BudgetId}: {spent}");

                summaries.Add(new BudgetSummaryDto
                {
                    BudgetId = budget.BudgetId,
                    CategoryName = budget.Category?.CategoryName ?? "Unknown Category",
                    IconId = budget.Category?.IconId ?? 0,
                    ColorId = budget.Category?.ColorId ?? 0,
                    BudgetAmount = budget.BudgetAmount,
                    SpentAmount = spent,
                    PercentageUsed = budget.BudgetAmount > 0
                        ? Math.Round((spent / budget.BudgetAmount) * 100, 1)
                        : 0
                });
            }

            Debug.WriteLine($"[BudgetService] GetUserBudgetSummariesAsync: Tổng số DTO được tạo: {summaries.Count}");

            return summaries.OrderBy(b => b.CategoryName);
        }

        public async Task<BudgetDetailDto> GetBudgetDetailAsync(int budgetId, string userId)
        {
            Debug.WriteLine($"[BudgetService] GetBudgetDetailAsync: Bắt đầu lấy chi tiết ngân sách ID: {budgetId}, UserId: {userId}");

            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
            {
                Debug.WriteLine("[BudgetService] GetBudgetDetailAsync: Không tìm thấy ngân sách hoặc không thuộc về người dùng.");
                return null;
            }

            var spent = await CalculateSpentAmountAsync(budget, userId);
            var remainingAmount = budget.BudgetAmount - spent;
            var daysRemaining = (budget.EndDate.Date - DateTime.Now.Date).Days;

            Debug.WriteLine($"[BudgetService] GetBudgetDetailAsync: SpentAmount: {spent}, Remaining: {remainingAmount}");

            var recentTransactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            Debug.WriteLine($"[BudgetService] GetBudgetDetailAsync: Số giao dịch gần đây: {recentTransactions.Count()}");

            return new BudgetDetailDto
            {
                BudgetId = budget.BudgetId,
                CategoryName = budget.Category.CategoryName,
                IconId = budget.Category.IconId,
                ColorId = budget.Category.ColorId,
                BudgetAmount = budget.BudgetAmount,
                SpentAmount = spent,
                RemainingAmount = remainingAmount,
                PercentageUsed = budget.BudgetAmount > 0
                    ? Math.Round((spent / budget.BudgetAmount) * 100, 1)
                    : 0,
                StartDate = budget.StartDate,
                EndDate = budget.EndDate,
                DaysRemaining = daysRemaining > 0 ? daysRemaining : 0,
                IsOverBudget = spent > budget.BudgetAmount,
                IsRecurring = budget.IsRecurring,
                RecentTransactions = recentTransactions
                    .OrderByDescending(t => t.TransactionDate)
                    .Take(10)
                    .Select(t => new TransactionItemDto
                    {
                        TransactionId = t.TransactionId,
                        Description = t.Description,
                        Amount = t.Amount,
                        TransactionDate = t.TransactionDate,
                        WalletId = t.WalletId
                    }).ToList()
            };
        }

        public async Task<IEnumerable<ExpenseBreakdownDto>> GetExpenseBreakdownAsync(int budgetId, string userId)
        {
            Debug.WriteLine($"[BudgetService] GetExpenseBreakdownAsync: Bắt đầu lấy phân tích chi tiêu cho ngân sách ID: {budgetId}, UserId: {userId}");

            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
            {
                Debug.WriteLine("[BudgetService] GetExpenseBreakdownAsync: Không tìm thấy ngân sách hoặc không thuộc về người dùng.");
                return new List<ExpenseBreakdownDto>();
            }

            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            Debug.WriteLine($"[BudgetService] GetExpenseBreakdownAsync: Số giao dịch trong khoảng thời gian: {transactions.Count()}");

            var breakdown = transactions
                .Where(t => t.Type == "Expense")
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new ExpenseBreakdownDto
                {
                    Date = g.Key,
                    TotalAmount = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                })
                .OrderBy(e => e.Date)
                .ToList();

            Debug.WriteLine($"[BudgetService] GetExpenseBreakdownAsync: Số điểm phân tích: {breakdown.Count}");

            return breakdown;
        }

        public async Task<Budget> CreateBudgetAsync(BudgetCreateDto dto, string userId)
        {
            Debug.WriteLine($"[BudgetService] CreateBudgetAsync: Bắt đầu tạo ngân sách cho UserId: {userId}, CategoryId: {dto.CategoryId}");

            var existingBudgets = await _budgetRepo.GetByUserAsync(userId);
            var hasOverlap = existingBudgets.Any(b =>
                b.CategoryId == dto.CategoryId &&
                b.StartDate <= dto.EndDate &&
                b.EndDate >= dto.StartDate);

            if (hasOverlap)
            {
                Debug.WriteLine("[BudgetService] CreateBudgetAsync: Đã tồn tại ngân sách trùng thời gian.");
                throw new InvalidOperationException("Đã có ngân sách cho danh mục này trong khoảng thời gian được chọn.");
            }

            var budget = new Budget
            {
                UserId = userId,
                CategoryId = dto.CategoryId,
                BudgetAmount = dto.BudgetAmount,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                IsRecurring = dto.IsRecurring,
                CreatedAt = DateTime.Now
            };

            var created = await _budgetRepo.AddAsync(budget);
            Debug.WriteLine($"[BudgetService] CreateBudgetAsync: Ngân sách ID {created.BudgetId} đã được tạo.");

            return created;
        }

        public async Task<bool> UpdateBudgetAsync(int budgetId, BudgetUpdateDto dto, string userId)
        {
            Debug.WriteLine($"[BudgetService] UpdateBudgetAsync: Bắt đầu cập nhật ngân sách ID: {budgetId}, UserId: {userId}");

            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
            {
                Debug.WriteLine("[BudgetService] UpdateBudgetAsync: Không tìm thấy ngân sách hoặc không thuộc về người dùng.");
                return false;
            }

            budget.CategoryId = dto.CategoryId;
            budget.BudgetAmount = dto.BudgetAmount;
            budget.StartDate = dto.StartDate;
            budget.EndDate = dto.EndDate;
            budget.IsRecurring = dto.IsRecurring;

            var updated = await _budgetRepo.UpdateAsync(budget);
            Debug.WriteLine($"[BudgetService] UpdateBudgetAsync: Kết quả cập nhật: {updated}");

            return updated;
        }

        public async Task<bool> DeleteBudgetAsync(int budgetId, string userId)
        {
            Debug.WriteLine($"[BudgetService] DeleteBudgetAsync: Bắt đầu xóa ngân sách ID: {budgetId}, UserId: {userId}");

            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
            {
                Debug.WriteLine("[BudgetService] DeleteBudgetAsync: Không tìm thấy ngân sách hoặc không thuộc về người dùng.");
                return false;
            }

            var deleted = await _budgetRepo.DeleteAsync(budgetId);
            Debug.WriteLine($"[BudgetService] DeleteBudgetAsync: Kết quả xóa: {deleted}");

            return deleted;
        }

        private async Task<decimal> CalculateSpentAmountAsync(Budget budget, string userId)
        {
            Debug.WriteLine($"[BudgetService] CalculateSpentAmountAsync: Tính toán chi tiêu cho ngân sách ID: {budget.BudgetId}");

            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            var totalSpent = transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);

            Debug.WriteLine($"[BudgetService] CalculateSpentAmountAsync: Tổng chi tiêu: {totalSpent}");

            return totalSpent;
        }
    }

    // ==================== DTOs ====================

    public class BudgetSummaryDto
    {
        public int BudgetId { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int IconId { get; set; }
        public int ColorId { get; set; }
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
        public string FormattedRemaining => $"{RemainingAmount:N0}đ";
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