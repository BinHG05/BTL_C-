using System;
using System.Threading.Tasks;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.Admin.UC;

namespace ExpenseManager.App.Presenters
{
    /// <summary>
    /// Presenter kết nối View và Service theo mô hình MVP
    /// Điều phối luồng dữ liệu giữa UI và Business Logic
    /// </summary>
    public class DashboardADPresenter
    {
        private readonly IDashboardADView _view;
        private readonly IDashboardADService _service;

        /// <summary>
        /// Constructor với Dependency Injection
        /// </summary>
        /// <param name="view">Instance của View implement IDashboardADView</param>
        /// <param name="service">Instance của Service implement IDashboardADService</param>
        public DashboardADPresenter(IDashboardADView view, IDashboardADService service)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        /// <summary>
        /// Load và hiển thị tất cả chỉ số KPI
        /// </summary>
        public async Task LoadKPIStatsAsync()
        {
            try
            {
                // Hiển thị loading
                _view.ShowLoading(true);

                // Lấy dữ liệu từ Service
                var stats = await _service.GetKPIStatsAsync();

                // Hiển thị dữ liệu lên View
                _view.DisplayKPIStats(stats);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và thông báo cho View
                _view.ShowError($"Không thể tải dữ liệu KPI: {ex.Message}");
            }
            finally
            {
                // Tắt loading
                _view.ShowLoading(false);
            }
        }

        /// <summary>
        /// Load và hiển thị dữ liệu biểu đồ tăng trưởng User
        /// </summary>
        /// <param name="filterType">Loại filter: "Theo ngày", "Theo tháng", "Theo năm"</param>
        public async Task LoadUserGrowthChartAsync(string filterType)
        {
            try
            {
                // Hiển thị loading
                _view.ShowLoading(true);

                // Validate filterType
                if (string.IsNullOrWhiteSpace(filterType))
                {
                    filterType = "Theo tháng"; // Default
                }

                // Lấy dữ liệu từ Service
                var chartData = await _service.GetUserGrowthDataAsync(filterType);

                // Hiển thị dữ liệu lên View
                _view.DisplayUserGrowthChart(chartData);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi và thông báo cho View
                _view.ShowError($"Không thể tải dữ liệu biểu đồ: {ex.Message}");
            }
            finally
            {
                // Tắt loading
                _view.ShowLoading(false);
            }
        }

        /// <summary>
        /// Load toàn bộ dữ liệu Dashboard (KPI + Chart)
        /// </summary>
        /// <param name="defaultFilterType">Filter mặc định cho biểu đồ</param>
        public async Task LoadDashboardAsync(string defaultFilterType = "Theo tháng")
        {
            // Load KPI Stats
            await LoadKPIStatsAsync();

            // Load User Growth Chart
            await LoadUserGrowthChartAsync(defaultFilterType);
        }
    }
}