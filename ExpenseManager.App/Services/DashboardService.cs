using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    public interface IDashboardService
    {
        Task<DashboardStats> GetDashboardStatsAsync(string userId);
    }

    public class DashboardService : IDashboardService
    {
        private readonly IDashboardRepository _repository;

        public DashboardService(IDashboardRepository repository)
        {
            _repository = repository;
        }

        public async Task<DashboardStats> GetDashboardStatsAsync(string userId)
        {
            var now = DateTime.Now;
            var currentMonth = now.Month;
            var currentYear = now.Year;

            var lastMonth = currentMonth == 1 ? 12 : currentMonth - 1;
            var lastMonthYear = currentMonth == 1 ? currentYear - 1 : currentYear;

            var totalBalance = await _repository.GetTotalBalanceAsync(userId);
            var monthlyIncome = await _repository.GetMonthlyIncomeAsync(userId, currentMonth, currentYear);
            var monthlyExpense = await _repository.GetMonthlyExpenseAsync(userId, currentMonth, currentYear);

            var activeBudget = await _repository.GetActiveBudgetAsync(userId, currentMonth, currentYear);
            var budgetInfo = await CalculateBudgetInfo(userId, activeBudget);

            var comparison = await CalculateComparison(userId, currentMonth, currentYear, lastMonth, lastMonthYear, monthlyIncome, monthlyExpense);

            // LOGIC MỚI: Lấy dữ liệu 7 ngày gần nhất
            var trends = await CalculateBalanceTrendsAsync(userId);

            var breakdown = await CalculateExpenseBreakdown(userId, currentMonth, currentYear);

            return new DashboardStats
            {
                TotalBalance = totalBalance,
                MonthlyIncome = monthlyIncome,
                MonthlyExpense = monthlyExpense,
                CurrentBudget = budgetInfo,
                Comparison = comparison,
                BalanceTrends = trends,
                ExpenseBreakdown = breakdown
            };
        }

        // --- LOGIC 7 NGÀY GẦN NHẤT ---
        private async Task<List<BalanceTrendPoint>> CalculateBalanceTrendsAsync(string userId)
        {
            var endDate = DateTime.Now.Date;
            var startDate = endDate.AddDays(-6); // Lấy 7 ngày (tính cả hôm nay)

            // Lấy giao dịch trong khoảng này
            var transactions = await _repository.GetTransactionsByDateRangeAsync(userId, startDate, endDate.AddDays(1).AddSeconds(-1));

            var result = new List<BalanceTrendPoint>();

            // Lặp từng ngày để đảm bảo ngày nào cũng có điểm vẽ (dù là 0đ)
            for (var date = startDate; date <= endDate; date = date.AddDays(1))
            {
                var dailyTxs = transactions.Where(t => t.TransactionDate.Date == date).ToList();
                var income = dailyTxs.Where(t => t.Type == "Income").Sum(t => t.Amount);
                var expense = dailyTxs.Where(t => t.Type == "Expense").Sum(t => t.Amount);

                result.Add(new BalanceTrendPoint
                {
                    Date = date,
                    NetAmount = income - expense,
                    Label = date.ToString("dd/MM") // VD: 23/11
                });
            }
            return result;
        }

        private async Task<BudgetInfo> CalculateBudgetInfo(string userId, ExpenseManager.App.Models.Entities.Budget budget)
        {
            if (budget == null) return null;
            var transactions = await _repository.GetTransactionsByDateRangeAsync(userId, budget.StartDate, budget.EndDate);
            var spent = transactions.Where(t => t.CategoryId == budget.CategoryId && t.Type == "Expense").Sum(t => t.Amount);
            var percent = budget.BudgetAmount > 0 ? (double)(spent / budget.BudgetAmount * 100) : 0;

            return new BudgetInfo
            {
                BudgetName = budget.Category?.CategoryName ?? "Ngân sách",
                BudgetAmount = budget.BudgetAmount,
                SpentAmount = spent,
                RemainingAmount = budget.BudgetAmount - spent,
                UsagePercent = Math.Round(percent, 1)
            };
        }

        private async Task<ComparisonStats> CalculateComparison(string userId, int curM, int curY, int lastM, int lastY, decimal curInc, decimal curExp)
        {
            var lastInc = await _repository.GetMonthlyIncomeAsync(userId, lastM, lastY);
            var lastExp = await _repository.GetMonthlyExpenseAsync(userId, lastM, lastY);

            if (lastInc == 0 && lastExp == 0) return new ComparisonStats { IsFirstMonth = true };

            return new ComparisonStats
            {
                IsFirstMonth = false,
                IncomeChangePercent = lastInc != 0 ? Math.Round((curInc - lastInc) / lastInc * 100, 1) : 100,
                ExpenseChangePercent = lastExp != 0 ? Math.Round((curExp - lastExp) / lastExp * 100, 1) : 100,
                BalanceChangePercent = (lastInc - lastExp) != 0
                    ? Math.Round(((curInc - curExp) - (lastInc - lastExp)) / Math.Abs(lastInc - lastExp) * 100, 1)
                    : 0
            };
        }

        private async Task<List<ExpenseCategoryBreakdown>> CalculateExpenseBreakdown(string userId, int month, int year)
        {
            var txs = await _repository.GetMonthlyTransactionsAsync(userId, month, year);
            var expenses = txs.Where(t => t.Type == "Expense").ToList();
            var total = expenses.Sum(t => t.Amount);

            if (total == 0) return new List<ExpenseCategoryBreakdown>();

            return expenses.GroupBy(t => new { t.Category.CategoryName, Hex = t.Category.Color?.HexCode ?? "#9CA3AF" })
                           .Select(g => new ExpenseCategoryBreakdown
                           {
                               CategoryName = g.Key.CategoryName,
                               Amount = g.Sum(t => t.Amount),
                               Percentage = Math.Round((double)(g.Sum(t => t.Amount) / total * 100), 1),
                               ColorHex = g.Key.Hex
                           }).OrderByDescending(x => x.Amount).ToList();
        }
    }
}