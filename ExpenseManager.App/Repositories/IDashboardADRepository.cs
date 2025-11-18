using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Enums;

namespace ExpenseManager.App.Repositories
{
    /// <summary>
    /// Interface định nghĩa các phương thức truy vấn dữ liệu thô cho Dashboard
    /// Tách biệt hoàn toàn khỏi logic tính toán nghiệp vụ
    /// </summary>
    public interface IDashboardADRepository
    {
        // ===== USER QUERIES =====
        
        /// <summary>
        /// Đếm tổng số users trong hệ thống
        /// </summary>
        Task<int> CountUsersAsync();

        /// <summary>
        /// Đếm số users được tạo trong một tháng cụ thể
        /// </summary>
        /// <param name="monthStart">Ngày đầu tiên của tháng cần đếm</param>
        Task<int> CountUsersCreatedInMonthAsync(DateTime monthStart);

        /// <summary>
        /// Lấy số lượng users được tạo trong khoảng thời gian, nhóm theo kiểu tổng hợp
        /// </summary>
        /// <param name="startDate">Ngày bắt đầu</param>
        /// <param name="endDate">Ngày kết thúc</param>
        /// <param name="type">Kiểu tổng hợp (Daily/Monthly/Yearly)</param>
        /// <returns>Dictionary với key là nhãn thời gian và value là số lượng</returns>
        Task<Dictionary<string, int>> GetUsersCountByDateRangeAsync(
            DateTime startDate, 
            DateTime endDate, 
            AggregationType type);

        // ===== TRANSACTION QUERIES =====
        
        /// <summary>
        /// Đếm tổng số transactions trong hệ thống
        /// </summary>
        Task<int> CountTransactionsAsync();

        /// <summary>
        /// Đếm số transactions được tạo trong một tháng cụ thể
        /// </summary>
        /// <param name="monthStart">Ngày đầu tiên của tháng cần đếm</param>
        Task<int> CountTransactionsCreatedInMonthAsync(DateTime monthStart);

        // ===== TICKET QUERIES =====
        
        /// <summary>
        /// Đếm tổng số tickets trong hệ thống
        /// </summary>
        Task<int> CountTotalTicketsAsync();

        /// <summary>
        /// Đếm số tickets đang ở trạng thái Pending
        /// </summary>
        Task<int> CountPendingTicketsAsync();
        Task<int> CountOpenTicketsAsync();
        Task<int> CountResolvedTicketsAsync();
    }
}