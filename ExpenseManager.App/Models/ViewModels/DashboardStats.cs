using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.ViewModels
{
    public class DashboardStats
    {
        public decimal TotalBalance { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MonthlyExpense { get; set; }

        // Ngân sách
        public BudgetInfo CurrentBudget { get; set; }

        // So sánh
        public ComparisonStats Comparison { get; set; }

        // Biểu đồ & Danh sách
        public List<BalanceTrendPoint> BalanceTrends { get; set; }
        public List<ExpenseCategoryBreakdown> ExpenseBreakdown { get; set; }
    }

    public class BudgetInfo
    {
        public string BudgetName { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public double UsagePercent { get; set; }
    }

    public class ComparisonStats
    {
        public bool IsFirstMonth { get; set; }
        public decimal BalanceChangePercent { get; set; }
        public decimal IncomeChangePercent { get; set; }
        public decimal ExpenseChangePercent { get; set; }
    }

    public class BalanceTrendPoint
    {
        public DateTime Date { get; set; }
        public decimal NetAmount { get; set; }
        public string Label { get; set; }
    }

    public class ExpenseCategoryBreakdown
    {
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public double Percentage { get; set; }
        public string ColorHex { get; set; }
    }
}