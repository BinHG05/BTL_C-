using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.ViewModels
{
    /// <summary>
    /// Model chứa toàn bộ dữ liệu thống kê cho Dashboard
    /// </summary>
    public class DashboardStats
    {
        /// <summary>
        /// Tổng số dư của tất cả các ví
        /// </summary>
        public decimal TotalBalance { get; set; }

        /// <summary>
        /// Tổng thu nhập trong tháng hiện tại
        /// </summary>
        public decimal MonthlyIncome { get; set; }

        /// <summary>
        /// Tổng chi tiêu trong tháng hiện tại
        /// </summary>
        public decimal MonthlyExpense { get; set; }

        /// <summary>
        /// Thông tin ngân sách đang hoạt động
        /// </summary>
        public BudgetInfo CurrentBudget { get; set; }

        /// <summary>
        /// Thông tin so sánh với tháng trước
        /// </summary>
        public ComparisonStats Comparison { get; set; }

        /// <summary>
        /// Dữ liệu biểu đồ Balance Trends (theo tuần)
        /// </summary>
        public List<BalanceTrendPoint> BalanceTrends { get; set; }

        /// <summary>
        /// Dữ liệu phân tích chi tiêu theo danh mục
        /// </summary>
        public List<ExpenseCategoryBreakdown> ExpenseBreakdown { get; set; }
    }

    /// <summary>
    /// Thông tin về ngân sách
    /// </summary>
    public class BudgetInfo
    {
        public string BudgetName { get; set; }
        public decimal BudgetAmount { get; set; }
        public decimal SpentAmount { get; set; }
        public decimal RemainingAmount { get; set; }
        public double UsagePercent { get; set; }
    }

    /// <summary>
    /// Thông tin so sánh với tháng trước
    /// </summary>
    public class ComparisonStats
    {
        /// <summary>
        /// Có phải là tháng đầu tiên không (chưa có dữ liệu tháng trước)
        /// </summary>
        public bool IsFirstMonth { get; set; }

        // So sánh số dư
        public decimal BalanceChangePercent { get; set; }
        public decimal BalanceChangeAmount { get; set; }

        // So sánh thu nhập
        public decimal IncomeChangePercent { get; set; }
        public decimal IncomeChangeAmount { get; set; }

        // So sánh chi tiêu
        public decimal ExpenseChangePercent { get; set; }
        public decimal ExpenseChangeAmount { get; set; }
    }

    /// <summary>
    /// Điểm dữ liệu cho biểu đồ Balance Trends
    /// </summary>
    public class BalanceTrendPoint
    {
        public DateTime Date { get; set; }
        public decimal NetAmount { get; set; } // Thu - Chi
        public string Label { get; set; } // "Tuần 1", "Tuần 2"...
    }

    /// <summary>
    /// Phân tích chi tiêu theo danh mục
    /// </summary>
    public class ExpenseCategoryBreakdown
    {
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public double Percentage { get; set; }
        public string ColorHex { get; set; }
    }
}