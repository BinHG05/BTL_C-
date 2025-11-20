using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IAnalyticsRepository
    {
        /// <summary>
        /// Lấy danh sách giao dịch chi tiêu với phân trang
        /// </summary>
        Task<(List<Transaction> Transactions, int TotalCount)> GetExpenseTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize);

        /// <summary>
        /// Lấy danh sách giao dịch thu nhập với phân trang
        /// </summary>
        Task<(List<Transaction> Transactions, int TotalCount)> GetIncomeTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize);

        /// <summary>
        /// Lấy tổng chi tiêu theo danh mục
        /// </summary>
        Task<List<CategorySummary>> GetExpenseSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);

        /// <summary>
        /// Lấy tổng thu nhập theo danh mục
        /// </summary>
        Task<List<CategorySummary>> GetIncomeSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate);
    }

    /// <summary>
    /// DTO cho tổng hợp theo danh mục
    /// </summary>
    public class CategorySummary
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public string ColorHex { get; set; } = string.Empty;
        public decimal TotalAmount { get; set; }
    }
}