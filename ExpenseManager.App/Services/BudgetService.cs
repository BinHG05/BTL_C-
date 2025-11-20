using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Repositories;

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

        // Lấy danh sách budget summary cho sidebar (hiển thị list bên trái)
        public async Task<IEnumerable<BudgetSummaryDto>> GetUserBudgetSummariesAsync(string userId)
        {
            var budgets = await _budgetRepo.GetByUserAsync(userId);
            var summaries = new List<BudgetSummaryDto>();

            foreach (var budget in budgets)
            {
                var spent = await CalculateSpentAmountAsync(budget, userId);

                summaries.Add(new BudgetSummaryDto
                {
                    BudgetId = budget.BudgetId,
                    CategoryName = budget.Category.CategoryName,
                    IconId = budget.Category.IconId,
                    ColorId = budget.Category.ColorId,
                    BudgetAmount = budget.BudgetAmount,
                    SpentAmount = spent,
                    PercentageUsed = budget.BudgetAmount > 0
                        ? Math.Round((spent / budget.BudgetAmount) * 100, 1)
                        : 0
                });
            }

            return summaries.OrderBy(b => b.CategoryName);
        }

        // Lấy chi tiết budget khi click vào (hiển thị bên phải)
        public async Task<BudgetDetailDto> GetBudgetDetailAsync(int budgetId, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
                return null;

            var spent = await CalculateSpentAmountAsync(budget, userId);
            var remainingAmount = budget.BudgetAmount - spent;
            var daysRemaining = (budget.EndDate.Date - DateTime.Now.Date).Days;

            // Lấy giao dịch gần đây trong kỳ ngân sách
            var recentTransactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

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

        // Lấy phân tích chi tiêu theo ngày/tuần (cho phần "Phân Tích Chi Tiêu")
        public async Task<IEnumerable<ExpenseBreakdownDto>> GetExpenseBreakdownAsync(int budgetId, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
                return new List<ExpenseBreakdownDto>();

            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            // Nhóm theo ngày
            var breakdown = transactions
                .Where(t => t.Type == "Expense") // Chỉ lấy chi tiêu
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new ExpenseBreakdownDto
                {
                    Date = g.Key,
                    TotalAmount = g.Sum(t => t.Amount),
                    TransactionCount = g.Count()
                })
                .OrderBy(e => e.Date)
                .ToList();

            return breakdown;
        }

        // Tạo budget mới
        public async Task<Budget> CreateBudgetAsync(BudgetCreateDto dto, string userId)
        {
            // Kiểm tra xem đã có budget cho category này trong khoảng thời gian chưa
            var existingBudgets = await _budgetRepo.GetByUserAsync(userId);
            var hasOverlap = existingBudgets.Any(b =>
                b.CategoryId == dto.CategoryId &&
                b.StartDate <= dto.EndDate &&
                b.EndDate >= dto.StartDate);

            if (hasOverlap)
                throw new InvalidOperationException("Đã có ngân sách cho danh mục này trong khoảng thời gian được chọn.");

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

            return await _budgetRepo.AddAsync(budget);
        }

        // Cập nhật budget
        public async Task<bool> UpdateBudgetAsync(int budgetId, BudgetUpdateDto dto, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
                return false;

            budget.CategoryId = dto.CategoryId;
            budget.BudgetAmount = dto.BudgetAmount;
            budget.StartDate = dto.StartDate;
            budget.EndDate = dto.EndDate;
            budget.IsRecurring = dto.IsRecurring;

            return await _budgetRepo.UpdateAsync(budget);
        }

        // Xóa budget
        public async Task<bool> DeleteBudgetAsync(int budgetId, string userId)
        {
            var budget = await _budgetRepo.GetByIdAsync(budgetId);

            if (budget == null || budget.UserId != userId)
                return false;

            return await _budgetRepo.DeleteAsync(budgetId);
        }

        // Private helper: Tính tổng đã chi trong khoảng thời gian của budget
        private async Task<decimal> CalculateSpentAmountAsync(Budget budget, string userId)
        {
            var transactions = await _transactionRepo.GetByCategoryAndDateRangeAsync(
                userId, budget.CategoryId, budget.StartDate, budget.EndDate);

            // Chỉ tính các giao dịch chi tiêu (Type = "Expense")
            return transactions
                .Where(t => t.Type == "Expense")
                .Sum(t => t.Amount);
        }
    }

    // ==================== DTOs ====================

    // Cho sidebar list bên trái
    public class BudgetSummaryDto
    {
        public int BudgetId { get; set; }
        public string CategoryName { get; set; }
        public int IconId { get; set; }
        public int ColorId { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal PercentageUsed { get; set; }

        // Helper properties
        public string FormattedBudget => $"{BudgetAmount:N0}đ";
        public string FormattedSpent => $"{SpentAmount:N0}đ";
    }

    // Cho detail panel bên phải
    public class BudgetDetailDto
    {
        public int BudgetId { get; set; }
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

        // Helper properties
        public string FormattedBudget => $"{BudgetAmount:N0}đ";
        public string FormattedSpent => $"{SpentAmount:N0}đ";
        public string FormattedRemaining => $"{RemainingAmount:N0}đ";
        public string FormattedStartDate => StartDate.ToString("dd/MM/yyyy");
        public string FormattedEndDate => EndDate.ToString("dd/MM/yyyy");
    }

    // Cho danh sách giao dịch
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

    // Cho phân tích chi tiêu theo ngày
    public class ExpenseBreakdownDto
    {
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int TransactionCount { get; set; }

        public string FormattedDate => Date.ToString("dd/MM/yyyy");
        public string FormattedAmount => $"{TotalAmount:N0}đ";
    }

    // Cho tạo mới budget
    public class BudgetCreateDto
    {
        public int CategoryId { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
    }

    // Cho cập nhật budget
    public class BudgetUpdateDto
    {
        public int CategoryId { get; set; }
        public decimal BudgetAmount { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsRecurring { get; set; }
    }
}