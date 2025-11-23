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

            // 1. Dữ liệu cơ bản
            var totalBalance = await _repository.GetTotalBalanceAsync(userId);
            var monthlyIncome = await _repository.GetMonthlyIncomeAsync(userId, currentMonth, currentYear);
            var monthlyExpense = await _repository.GetMonthlyExpenseAsync(userId, currentMonth, currentYear);

            var firstBudget = await _repository.GetFirstActiveBudgetAsync(userId);
            var budgetInfo = await CalculateBudgetInfo(userId, firstBudget);
            var comparison = await CalculateComparison(userId, currentMonth, currentYear, lastMonth, lastMonthYear, monthlyIncome, monthlyExpense);
            var trends = await CalculateBalanceTrends(userId);
            var breakdown = await CalculateExpenseBreakdown(userId, currentMonth, currentYear);

            // 2. Dữ liệu mở rộng (Grid 2x2)

            // A. Ngân sách
            var activeBudgets = await _repository.GetActiveBudgetsAsync(userId);
            var budgetDtos = new List<BudgetDto>();
            foreach (var b in activeBudgets)
            {
                var txs = await _repository.GetTransactionsByDateRangeAsync(userId, b.StartDate, b.EndDate);
                var spent = txs.Where(t => t.CategoryId == b.CategoryId && t.Type == "Expense").Sum(t => t.Amount);
                budgetDtos.Add(new BudgetDto
                {
                    Name = b.Category.CategoryName,
                    CategoryIcon = b.Category.Icon?.IconClass ?? "QuestionCircle",
                    Limit = b.BudgetAmount,
                    Spent = spent,
                    Percent = b.BudgetAmount > 0 ? Math.Round((double)(spent / b.BudgetAmount * 100), 1) : 0,
                    ColorHex = b.Category.Color?.HexCode ?? "#6366F1"
                });
            }

            // B. Giao dịch gần đây (QUAN TRỌNG: LẤY ICON CLASS)
            var recentTxs = await _repository.GetRecentTransactionsAsync(userId, 5);
            var recentDtos = recentTxs.Select(t => new RecentTransactionDto
            {
                CategoryName = t.Category.CategoryName,
                // Lấy IconClass (vd: "fa-solid fa-mug-hot") thay vì IconName
                CategoryIcon = t.Category.Icon?.IconClass ?? "fa-circle-question",
                ColorHex = t.Category.Color?.HexCode ?? "#9CA3AF",
                Date = t.TransactionDate,
                Note = t.Description,
                Amount = t.Amount,
                Type = t.Type
            }).ToList();

            // C. Biểu đồ cột
            var sevenDaysAgo = DateTime.Now.Date.AddDays(-6);
            var weekTxs = await _repository.GetTransactionsByDateRangeAsync(userId, sevenDaysAgo, DateTime.Now.Date.AddDays(1));
            var dailyAnalysis = new List<DailyAnalysisDto>();
            for (var date = sevenDaysAgo; date <= DateTime.Now.Date; date = date.AddDays(1))
            {
                var dayTxs = weekTxs.Where(t => t.TransactionDate.Date == date).ToList();
                dailyAnalysis.Add(new DailyAnalysisDto
                {
                    Date = date,
                    Label = date.ToString("dd/MM"),
                    Income = dayTxs.Where(t => t.Type == "Income").Sum(t => t.Amount),
                    Expense = dayTxs.Where(t => t.Type == "Expense").Sum(t => t.Amount)
                });
            }

            // D. Mục tiêu
            // D. Mục Tiêu Tiết Kiệm
            var goals = await _repository.GetGoalsAsync(userId);
            var goalDtos = goals.Select(g => new GoalDto
            {
                Name = g.GoalName,
                Saved = g.CurrentAmount,
                Target = g.TargetAmount,

            
                Percent = g.TargetAmount > 0
         ? Math.Round((double)g.CurrentAmount / (double)g.TargetAmount * 100, 2)
         : 0
            }).ToList();

            return new DashboardStats
            {
                TotalBalance = totalBalance,
                MonthlyIncome = monthlyIncome,
                MonthlyExpense = monthlyExpense,
                CurrentBudget = budgetInfo,
                Comparison = comparison,
                BalanceTrends = trends,
                ExpenseBreakdown = breakdown,
                Budgets = budgetDtos,
                RecentTransactions = recentDtos,
                DailyAnalysis = dailyAnalysis,
                Goals = goalDtos
            };
        }

        // --- Helper Methods ---
        private async Task<BudgetInfo> CalculateBudgetInfo(string userId, ExpenseManager.App.Models.Entities.Budget budget)
        {
            if (budget == null) return null;
            var transactions = await _repository.GetTransactionsByDateRangeAsync(userId, budget.StartDate, budget.EndDate);
            var spent = transactions.Where(t => t.CategoryId == budget.CategoryId && t.Type == "Expense").Sum(t => t.Amount);
            var percent = budget.BudgetAmount > 0 ? (double)(spent / budget.BudgetAmount * 100) : 0;
            return new BudgetInfo { BudgetName = budget.Category?.CategoryName ?? "Ngân sách", BudgetAmount = budget.BudgetAmount, SpentAmount = spent, RemainingAmount = budget.BudgetAmount - spent, UsagePercent = Math.Round(percent, 1) };
        }

        private async Task<ComparisonStats> CalculateComparison(string userId, int curM, int curY, int lastM, int lastY, decimal curInc, decimal curExp)
        {
            var lastInc = await _repository.GetMonthlyIncomeAsync(userId, lastM, lastY);
            var lastExp = await _repository.GetMonthlyExpenseAsync(userId, lastM, lastY);
            if (lastInc == 0 && lastExp == 0) return new ComparisonStats { IsFirstMonth = true };
            return new ComparisonStats { IsFirstMonth = false, IncomeChangePercent = lastInc != 0 ? Math.Round((curInc - lastInc) / lastInc * 100, 1) : 100, ExpenseChangePercent = lastExp != 0 ? Math.Round((curExp - lastExp) / lastExp * 100, 1) : 100, BalanceChangePercent = (lastInc - lastExp) != 0 ? Math.Round(((curInc - curExp) - (lastInc - lastExp)) / Math.Abs(lastInc - lastExp) * 100, 1) : 0 };
        }

        private async Task<List<BalanceTrendPoint>> CalculateBalanceTrends(string userId)
        {
            var end = DateTime.Now.Date;
            var start = end.AddDays(-6);
            var txs = await _repository.GetTransactionsByDateRangeAsync(userId, start, end.AddDays(1));
            var result = new List<BalanceTrendPoint>();
            for (var d = start; d <= end; d = d.AddDays(1))
            {
                var dayTxs = txs.Where(t => t.TransactionDate.Date == d).ToList();
                result.Add(new BalanceTrendPoint { Date = d, Label = d.ToString("dd/MM"), NetAmount = dayTxs.Where(t => t.Type == "Income").Sum(t => t.Amount) - dayTxs.Where(t => t.Type == "Expense").Sum(t => t.Amount) });
            }
            return result;
        }

        private async Task<List<ExpenseCategoryBreakdown>> CalculateExpenseBreakdown(string userId, int month, int year)
        {
            var txs = await _repository.GetMonthlyTransactionsAsync(userId, month, year);
            var expenses = txs.Where(t => t.Type == "Expense").ToList();
            var total = expenses.Sum(t => t.Amount);
            if (total == 0) return new List<ExpenseCategoryBreakdown>();
            return expenses.GroupBy(t => new { t.Category.CategoryName, Hex = t.Category.Color?.HexCode ?? "#9CA3AF" })
                           .Select(g => new ExpenseCategoryBreakdown { CategoryName = g.Key.CategoryName, Amount = g.Sum(t => t.Amount), Percentage = Math.Round((double)(g.Sum(t => t.Amount) / total * 100), 1), ColorHex = g.Key.Hex }).OrderByDescending(x => x.Amount).ToList();
        }
    }
}