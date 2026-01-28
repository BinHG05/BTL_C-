using System;
using System.Threading.Tasks;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.Admin.UC;

namespace ExpenseManager.App.Presenters
{
   
    public class DashboardADPresenter
    {
        private readonly IDashboardADView _view;
        private readonly IDashboardADService _service;

        public DashboardADPresenter(IDashboardADView view, IDashboardADService service)
        {
            _view = view ?? throw new ArgumentNullException(nameof(view));
            _service = service ?? throw new ArgumentNullException(nameof(service));
        }

        public async Task LoadKPIStatsAsync()
        {
            try
            {
                _view.ShowLoading(true);

                var stats = await _service.GetKPIStatsAsync();

                _view.DisplayKPIStats(stats);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Không thể tải dữ liệu KPI: {ex.Message}");
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }
        public async Task LoadUserGrowthChartAsync(string filterType)
        {
            try
            {
                _view.ShowLoading(true);

                if (string.IsNullOrWhiteSpace(filterType))
                {
                    filterType = "Theo tháng"; 
                }

                var chartData = await _service.GetUserGrowthDataAsync(filterType);

                _view.DisplayUserGrowthChart(chartData);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Không thể tải dữ liệu biểu đồ: {ex.Message}");
            }
            finally
            {
                _view.ShowLoading(false);
            }
        }

        public async Task LoadDashboardAsync(string defaultFilterType = "Theo tháng")
        {
            await LoadKPIStatsAsync();

            await LoadUserGrowthChartAsync(defaultFilterType);
        }
    }
}