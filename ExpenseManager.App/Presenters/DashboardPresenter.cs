using System;
using System.Threading.Tasks;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.Admin.UC;

namespace ExpenseManager.App.Presenters
{
    public class DashboardPresenter
    {
        private readonly IDashboardView _view;
        private readonly IDashboardService _service;

        public DashboardPresenter(IDashboardView view, IDashboardService service)
        {
            _view = view;
            _service = service;
        }

        public async Task LoadDashboardDataAsync()
        {
            try
            {
                var userId = _view.GetCurrentUserId();
                if (string.IsNullOrEmpty(userId)) return;

                _view.ShowLoading();
                var stats = await _service.GetDashboardStatsAsync(userId);
                _view.DisplayDashboardStats(stats);
            }
            catch (Exception ex)
            {
                _view.DisplayError("Lỗi tải Dashboard: " + ex.Message);
            }
            finally
            {
                _view.HideLoading();
            }
        }
    }
}