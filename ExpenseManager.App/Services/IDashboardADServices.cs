using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Services
{
  
    public interface IDashboardADService
    {
       
        Task<KPIStatsDTO> GetKPIStatsAsync();

      
        /// <param name="filterType">
        Task<List<ChartDataPointDTO>> GetUserGrowthDataAsync(string filterType);
    }
}