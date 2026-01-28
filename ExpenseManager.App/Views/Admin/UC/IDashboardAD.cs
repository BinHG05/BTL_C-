using System.Collections.Generic;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface IDashboardADView
    {
        void DisplayKPIStats(KPIStatsDTO stats);

        void DisplayUserGrowthChart(List<ChartDataPointDTO> data);

        void ShowError(string message);

        void ShowLoading(bool isLoading);
    }
}