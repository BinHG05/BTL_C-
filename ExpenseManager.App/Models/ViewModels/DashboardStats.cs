using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.ViewModels
{
    public class DashboardStats
    {
        // 1. Các chỉ số chính (4 ô trên cùng)
        public decimal TotalBalance { get; set; }
        public decimal MonthlyIncome { get; set; }
        public decimal MonthlyExpense { get; set; }
        public BudgetInfo CurrentBudget { get; set; }
        public ComparisonStats Comparison { get; set; }

        // 2. Dữ liệu cho các biểu đồ bên dưới
        public List<BalanceTrendPoint> BalanceTrends { get; set; } // Biểu đồ đường
        public List<ExpenseCategoryBreakdown> ExpenseBreakdown { get; set; } // List danh mục

        // 3. DỮ LIỆU MỚI CHO GRID 2x2
        public List<BudgetDto> Budgets { get; set; }
        public List<DailyAnalysisDto> DailyAnalysis { get; set; }
        public List<RecentTransactionDto> RecentTransactions { get; set; }
        public List<GoalDto> Goals { get; set; }
    }

    // --- CÁC CLASS CON (DTO) ---

    public class BudgetDto
    {
        public string Name { get; set; }
        public string CategoryIcon { get; set; }
        public decimal Spent { get; set; }
        public decimal Limit { get; set; }
        public double Percent { get; set; }
        public string ColorHex { get; set; }
    }

    public class DailyAnalysisDto
    {
        public DateTime Date { get; set; }
        public string Label { get; set; } // VD: 22/11
        public decimal Income { get; set; }
        public decimal Expense { get; set; }
    }

    public class RecentTransactionDto
    {
        public string CategoryName { get; set; }
        public string CategoryIcon { get; set; }
        public string ColorHex { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "Income" hoặc "Expense"
    }

    public class GoalDto
    {
        public string Name { get; set; }
        public decimal Saved { get; set; }
        public decimal Target { get; set; }
        public double Percent { get; set; }
    }

    // --- CÁC CLASS CŨ (GIỮ NGUYÊN ĐỂ KHÔNG LỖI) ---
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