using System.Collections.Generic;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Views.Admin.UC
{
    /// <summary>
    /// Interface định nghĩa các phương thức mà View (UC_DashboardAD) phải implement
    /// để giao tiếp với Presenter
    /// </summary>
    public interface IDashboardADView
    {
        /// <summary>
        /// Hiển thị dữ liệu KPI lên các thẻ (Users, Transactions, Tickets)
        /// </summary>
        /// <param name="stats">DTO chứa toàn bộ dữ liệu KPI</param>
        void DisplayKPIStats(KPIStatsDTO stats);

        /// <summary>
        /// Hiển thị dữ liệu biểu đồ tăng trưởng User
        /// </summary>
        /// <param name="data">Danh sách các điểm dữ liệu cho biểu đồ</param>
        void DisplayUserGrowthChart(List<ChartDataPointDTO> data);

        /// <summary>
        /// Hiển thị thông báo lỗi cho người dùng
        /// </summary>
        /// <param name="message">Nội dung thông báo lỗi</param>
        void ShowError(string message);

        /// <summary>
        /// Hiển thị trạng thái đang tải dữ liệu
        /// </summary>
        /// <param name="isLoading">True nếu đang tải, False nếu đã xong</param>
        void ShowLoading(bool isLoading);
    }
}