using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Services
{
    /// <summary>
    /// Interface định nghĩa các phương thức nghiệp vụ cho Dashboard
    /// Chứa logic tính toán và xử lý dữ liệu
    /// </summary>
    public interface IDashboardADService
    {
        /// <summary>
        /// Lấy tất cả chỉ số KPI (Users, Transactions, Tickets)
        /// Bao gồm cả tính toán Growth Rate
        /// </summary>
        Task<KPIStatsDTO> GetKPIStatsAsync();

        /// <summary>
        /// Lấy dữ liệu biểu đồ tăng trưởng User theo loại filter
        /// </summary>
        /// <param name="filterType">Loại filter: "Theo ngày", "Theo tháng", "Theo năm"</param>
        Task<List<ChartDataPointDTO>> GetUserGrowthDataAsync(string filterType);
    }
}