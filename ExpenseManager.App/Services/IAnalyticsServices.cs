using ExpenseManager.App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IAnalyticsService
    {
        /// <summary>
        /// Lấy dữ liệu phân tích chi tiêu
        /// </summary>
        /// <param name="userId">ID người dùng</param>
        /// <param name="walletId">ID ví (null = tất cả ví)</param>
        /// <param name="month">Tháng theo định dạng "yyyy-MM"</param>
        /// <param name="page">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi mỗi trang</param>
        /// <returns>Tuple chứa Breakdown, History, Total, Paging</returns>
        Task<(
            List<ExpenseBreakdownItem> Breakdown,
            List<TransactionDto> History,
            decimal Total,
            PagingInfo Paging)> GetExpenseAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7);

        /// <summary>
        /// Lấy dữ liệu phân tích thu nhập
        /// </summary>
        /// <param name="userId">ID người dùng</param>
        /// <param name="walletId">ID ví (null = tất cả ví)</param>
        /// <param name="month">Tháng theo định dạng "yyyy-MM"</param>
        /// <param name="page">Trang hiện tại</param>
        /// <param name="pageSize">Số bản ghi mỗi trang</param>
        /// <returns>Tuple chứa Breakdown, History, Total, Paging</returns>
        Task<(
            List<IncomeBreakdownItem> Breakdown,
            List<IncomeTransactionDto> History,
            decimal Total,
            PagingInfo Paging)> GetIncomeAnalyticsAsync(
            string userId,
            int? walletId,
            string? month,
            int page = 1,
            int pageSize = 7);
    }
}