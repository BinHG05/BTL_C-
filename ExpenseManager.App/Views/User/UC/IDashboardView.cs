using ExpenseManager.App.Models.ViewModels;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface IDashboardView
    {
        void ShowLoading();
        void HideLoading();
        void DisplayDashboardStats(DashboardStats stats);
        void DisplayError(string message);
        string GetCurrentUserId();
    }
}