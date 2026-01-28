using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Enums;

namespace ExpenseManager.App.Repositories
{
    /// Interface định nghĩa các phương thức truy vấn dữ liệu thô cho Dashboard
    /// Tách biệt hoàn toàn khỏi logic tính toán nghiệp vụ
    public interface IDashboardADRepository
    {
        /// Đếm tổng số users trong hệ thống
        Task<int> CountUsersAsync();

        /// Đếm số users được tạo trong một tháng cụ thể
        Task<int> CountUsersCreatedInMonthAsync(DateTime monthStart);

        /// Lấy số lượng users được tạo trong khoảng thời gian, nhóm theo kiểu tổng hợp
        Task<Dictionary<string, int>> GetUsersCountByDateRangeAsync(
            DateTime startDate, 
            DateTime endDate, 
            AggregationType type);

        /// Đếm tổng số transactions trong hệ thống
        Task<int> CountTransactionsAsync();

        /// Đếm số transactions được tạo trong một tháng cụ thể
        Task<int> CountTransactionsCreatedInMonthAsync(DateTime monthStart);

        /// Đếm tổng số tickets trong hệ thống
        Task<int> CountTotalTicketsAsync();

        /// Đếm số tickets đang ở trạng thái Pending
        Task<int> CountPendingTicketsAsync();
        Task<int> CountOpenTicketsAsync();
        Task<int> CountResolvedTicketsAsync();
    }
}