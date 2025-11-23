using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    /// <summary>
    /// Interface cho Dashboard Service
    /// </summary>
    public interface IDashboardService
    {
        Task<DashboardStats> GetDashboardStatsAsync(string userId);
    }

    /// <summary>
    /// Service xử lý business logic cho Dashboard
    /// </summary>
    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lấy toàn bộ dữ liệu thống kê cho Dashboard
        /// </summary>
        public async Task<DashboardStats> GetDashboardStatsAsync(string userId)
        {
            var now = DateTime.Now;
            var currentMonth = now.Month;
            var currentYear = now.Year;

            // Tháng trước
            var lastMonth = currentMonth == 1 ? 12 : currentMonth - 1;
            var lastMonthYear = currentMonth == 1 ? currentYear - 1 : currentYear;

            // 1. Lấy tổng số dư tất cả ví
            var totalBalance = await _repository.GetTotalBalanceAsync(userId);

            // 2. Lấy thu nhập tháng này
            var monthlyIncome = await _repository.GetMonthlyIncomeAsync(userId, currentMonth, currentYear);

            // 3. Lấy chi tiêu tháng này
            var monthlyExpense = await _repository.GetMonthlyExpenseAsync(userId, currentMonth, currentYear);

            // 4. Lấy budget đang hoạt động
            var currentBudget = await GetCurrentBudgetInfoAsync(userId);

            // 5. Tính toán so sánh với tháng trước
            var comparison = await CalculateComparisonAsync(userId, currentMonth, currentYear,
                lastMonth, lastMonthYear, totalBalance, monthlyIncome, monthlyExpense);

            // 6. Lấy dữ liệu biểu đồ Balance Trends (theo tuần trong tháng)
            var balanceTrends = await CalculateBalanceTrendsAsync(userId, currentMonth, currentYear);

            // 7. Lấy phân tích chi tiêu theo danh mục
            var expenseBreakdown = await CalculateExpenseBreakdownAsync(userId, currentMonth, currentYear);

            return new DashboardStats
            {
                TotalBalance = totalBalance,
                MonthlyIncome = monthlyIncome,
                MonthlyExpense = monthlyExpense,
                CurrentBudget = currentBudget,
                Comparison = comparison,
                BalanceTrends = balanceTrends,
                ExpenseBreakdown = expenseBreakdown
            };
        }

        /// <summary>
        /// Lấy thông tin budget hiện tại
        /// </summary>
        private async Task<BudgetInfo> GetCurrentBudgetInfoAsync(string userId)
        {
            var budget = await _repository.GetFirstActiveBudgetAsync(userId);

            if (budget == null)
            {
                return new BudgetInfo
                {
                    BudgetName = "Chưa có ngân sách",
                    BudgetAmount = 0,
                    SpentAmount = 0,
                    RemainingAmount = 0,
                    UsagePercent = 0
                };
            }

            // Tính tổng chi tiêu cho category này trong khoảng thời gian budget
            var spent = await _repository.GetTransactionsByDateRangeAsync(userId,
                budget.StartDate, budget.EndDate);

            var spentAmount = spent
                .Where(t => t.CategoryId == budget.CategoryId && t.Type == "Expense")
                .Sum(t => t.Amount);

            var remaining = budget.BudgetAmount - spentAmount;
            var usagePercent = budget.BudgetAmount > 0
                ? (double)(spentAmount / budget.BudgetAmount * 100)
                : 0;

            return new BudgetInfo
            {
                BudgetName = budget.Category?.CategoryName ?? "Ngân sách",
                BudgetAmount = budget.BudgetAmount,
                SpentAmount = spentAmount,
                RemainingAmount = remaining,
                UsagePercent = Math.Round(usagePercent, 2)
            };
        }

        /// <summary>
        /// Tính toán số liệu so sánh với tháng trước
        /// </summary>
        private async Task<ComparisonStats> CalculateComparisonAsync(string userId,
            int currentMonth, int currentYear, int lastMonth, int lastMonthYear,
            decimal currentBalance, decimal currentIncome, decimal currentExpense)
        {
            // Kiểm tra xem có phải tháng đầu tiên không (không có dữ liệu tháng trước)
            var lastMonthIncome = await _repository.GetMonthlyIncomeAsync(userId, lastMonth, lastMonthYear);
            var lastMonthExpense = await _repository.GetMonthlyExpenseAsync(userId, lastMonth, lastMonthYear);

            var isFirstMonth = lastMonthIncome == 0 && lastMonthExpense == 0;

            if (isFirstMonth)
            {
                return new ComparisonStats
                {
                    IsFirstMonth = true,
                    BalanceChangePercent = 0,
                    BalanceChangeAmount = 0,
                    IncomeChangePercent = 0,
                    IncomeChangeAmount = 0,
                    ExpenseChangePercent = 0,
                    ExpenseChangeAmount = 0
                };
            }

            // Tính % thay đổi
            var lastMonthBalance = currentBalance - (currentIncome - currentExpense) + (lastMonthIncome - lastMonthExpense);

            var balanceChange = currentBalance - lastMonthBalance;
            var balanceChangePercent = lastMonthBalance != 0
                ? (balanceChange / lastMonthBalance * 100)
                : 0;

            var incomeChange = currentIncome - lastMonthIncome;
            var incomeChangePercent = lastMonthIncome != 0
                ? (incomeChange / lastMonthIncome * 100)
                : 0;

            var expenseChange = currentExpense - lastMonthExpense;
            var expenseChangePercent = lastMonthExpense != 0
                ? (expenseChange / lastMonthExpense * 100)
                : 0;

            return new ComparisonStats
            {
                IsFirstMonth = false,
                BalanceChangePercent = Math.Round(balanceChangePercent, 2),
                BalanceChangeAmount = balanceChange,
                IncomeChangePercent = Math.Round(incomeChangePercent, 2),
                IncomeChangeAmount = incomeChange,
                ExpenseChangePercent = Math.Round(expenseChangePercent, 2),
                ExpenseChangeAmount = expenseChange
            };
        }

        /// <summary>
        /// Tính toán dữ liệu cho biểu đồ Balance Trends theo tuần
        /// </summary>
        private async Task<List<BalanceTrendPoint>> CalculateBalanceTrendsAsync(string userId,
            int month, int year)
        {
            var transactions = await _repository.GetMonthlyTransactionsAsync(userId, month, year);

            if (!transactions.Any())
            {
                return new List<BalanceTrendPoint>();
            }

            // Nhóm giao dịch theo tuần
            var weeklyData = transactions
                .GroupBy(t => GetWeekOfMonth(t.TransactionDate))
                .Select(g => new BalanceTrendPoint
                {
                    Date = g.First().TransactionDate,
                    NetAmount = g.Where(t => t.Type == "Income").Sum(t => t.Amount) -
                               g.Where(t => t.Type == "Expense").Sum(t => t.Amount),
                    Label = $"Tuần {g.Key}"
                })
                .OrderBy(p => p.Date)
                .ToList();

            return weeklyData;
        }

        /// <summary>
        /// Tính toán phân tích chi tiêu theo danh mục
        /// </summary>
        private async Task<List<ExpenseCategoryBreakdown>> CalculateExpenseBreakdownAsync(
            string userId, int month, int year)
        {
            var transactions = await _repository.GetMonthlyTransactionsAsync(userId, month, year);
            var expenses = transactions.Where(t => t.Type == "Expense").ToList();

            if (!expenses.Any())
            {
                return new List<ExpenseCategoryBreakdown>();
            }

            var totalExpense = expenses.Sum(t => t.Amount);

            var breakdown = expenses
                .GroupBy(t => new
                {
                    t.Category.CategoryName,
                    ColorHex = t.Category.Color?.HexCode ?? "#6366F1"  // Sửa ColorHex thành HexCode
                })
                .Select(g => new ExpenseCategoryBreakdown
                {
                    CategoryName = g.Key.CategoryName,
                    Amount = g.Sum(t => t.Amount),
                    Percentage = totalExpense > 0
                        ? Math.Round((double)(g.Sum(t => t.Amount) / totalExpense * 100), 2)
                        : 0,
                    ColorHex = g.Key.ColorHex
                })
                .OrderByDescending(c => c.Amount)
                .ToList();

            return breakdown;
        }

        /// <summary>
        /// Tính tuần thứ mấy trong tháng
        /// </summary>
        private int GetWeekOfMonth(DateTime date)
        {
            var firstDayOfMonth = new DateTime(date.Year, date.Month, 1);
            var dayOfMonth = date.Day;
            var firstWeekday = (int)firstDayOfMonth.DayOfWeek;

            return (dayOfMonth + firstWeekday - 1) / 7 + 1;
        }
    }
}