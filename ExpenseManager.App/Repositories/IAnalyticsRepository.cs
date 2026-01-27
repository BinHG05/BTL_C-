using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IAnalyticsRepository
    {
        /// Lấy danh sách giao dịch chi tiêu với phân trang
        Task<(List<Transaction> Transactions, int TotalCount)> GetExpenseTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize);

        /// Lấy danh sách giao dịch thu nhập với phân trang
        Task<(List<Transaction> Transactions, int TotalCount)> GetIncomeTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize);

        /// Lấy tổng chi tiêu theo danh mục
        Task<List<CategorySummary>> GetExpenseSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);

        /// Lấy tổng thu nhập theo danh mục
        Task<List<CategorySummary>> GetIncomeSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);

        /// Lấy tổng chi tiêu theo ngày (cho biểu đồ xu hướng)
        Task<List<DailySummary>> GetExpenseDailySummaryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);
        /// Lấy tổng thu nhập theo ngày (cho biểu đồ xu hướng)
        Task<List<DailySummary>> GetIncomeDailySummaryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);
    }
    /// DTO cho tổng hợp theo danh mục
    public class CategorySummary
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ColorHex { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }

    /// DTO cho tổng hợp theo ngày
    public class DailySummary
    {
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
    }
}