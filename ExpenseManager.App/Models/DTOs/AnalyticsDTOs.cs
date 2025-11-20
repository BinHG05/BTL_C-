using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.DTOs
{
    // --- Cấu trúc chung (Giống ExpenseAnalyticsViewModel.cs) ---
    public class CategoryDto
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public IconDto? Icon { get; set; }
        public ColorDto? Color { get; set; }
    }

    public class IconDto
    {
        public int IconID { get; set; }
        public string IconClass { get; set; } = string.Empty;
    }

    public class ColorDto
    {
        public int ColorID { get; set; }
        public string HexCode { get; set; } = string.Empty;
    }

    // --- DTO cho Lịch sử giao dịch Expense (TransactionDto) ---
    public class TransactionDto
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } = string.Empty;
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public CategoryDto? Category { get; set; }
    }

    // --- DTO cho Lịch sử giao dịch Income (IncomeTransactionDto) ---
    public class IncomeTransactionDto
    {
        public int TransactionID { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        public string Description { get; set; } = string.Empty;
        public CategoryDto? Category { get; set; }
    }

    // --- Item cho Pie Chart Expense (ExpenseBreakdownItem) ---
    public class ExpenseBreakdownItem
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public double Percentage { get; set; }
        public string ColorHex { get; set; } = "#808080";
    }

    // --- Item cho Pie Chart Income (IncomeBreakdownItem) ---
    public class IncomeBreakdownItem
    {
        public string CategoryName { get; set; } = string.Empty;
        public decimal Amount { get; set; }
        public double Percentage { get; set; }
        public string ColorHex { get; set; } = "#4caf50";
    }

    // --- DTO cho thông tin Phân trang (Vì IAnalyticsView không nên xử lý tính toán) ---
    public class PagingInfo
    {
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalRecords { get; set; }
    }
}