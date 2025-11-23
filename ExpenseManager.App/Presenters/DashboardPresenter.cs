using System;
using System.Threading.Tasks;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Services;

namespace ExpenseManager.App.Presenters
{
    /// <summary>
    /// Interface định nghĩa các phương thức mà View phải implement
    /// </summary>
    public interface IDashboardView
    {
        /// <summary>
        /// Hiển thị trạng thái loading
        /// </summary>
        void ShowLoading();

        /// <summary>
        /// Ẩn trạng thái loading
        /// </summary>
        void HideLoading();

        /// <summary>
        /// Hiển thị dữ liệu dashboard
        /// </summary>
        void DisplayDashboardStats(DashboardStats stats);

        /// <summary>
        /// Hiển thị thông báo lỗi
        /// </summary>
        void DisplayError(string message);

        /// <summary>
        /// Lấy ID của user hiện tại
        /// </summary>
        string GetCurrentUserId();
    }

    /// <summary>
    /// Presenter làm cầu nối giữa View và Service
    /// Xử lý logic điều khiển flow của ứng dụng
    /// </summary>
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly IDashboardService _service;

        public DashboardPresenter(IDashboardView view, IDashboardService service)
        {
            _view = view;
            _service = service;
        }

        /// <summary>
        /// Load dữ liệu dashboard
        /// </summary>
        public async Task LoadDashboardDataAsync()
        {
            try
            {
                // Hiển thị loading
                _view.ShowLoading();

                // Lấy user ID
                var userId = _view.GetCurrentUserId();

                if (string.IsNullOrEmpty(userId))
                {
                    _view.DisplayError("Không tìm thấy thông tin người dùng. Vui lòng đăng nhập lại.");
                    return;
                }

                // Gọi service để lấy dữ liệu
                var stats = await _service.GetDashboardStatsAsync(userId);

                // Hiển thị dữ liệu lên view
                _view.DisplayDashboardStats(stats);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                _view.DisplayError($"Lỗi khi tải dữ liệu Dashboard: {ex.Message}");
            }
            finally
            {
                // Luôn ẩn loading khi xong
                _view.HideLoading();
            }
        }

        /// <summary>
        /// Refresh lại dashboard
        /// </summary>
        public async Task RefreshDashboardAsync()
        {
            await LoadDashboardDataAsync();
        }
    }
}