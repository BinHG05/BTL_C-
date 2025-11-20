using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services
{
    public interface IBudgetService
    {
        Task<IEnumerable<BudgetSummaryDto>> GetUserBudgetSummariesAsync(string userId);
        Task<BudgetDetailDto> GetBudgetDetailAsync(int budgetId, string userId);
        Task<Budget> CreateBudgetAsync(BudgetCreateDto dto, string userId);
        Task<bool> UpdateBudgetAsync(int budgetId, BudgetUpdateDto dto, string userId);
        Task<bool> DeleteBudgetAsync(int budgetId, string userId);
        Task<IEnumerable<ExpenseBreakdownDto>> GetExpenseBreakdownAsync(int budgetId, string userId);
    }
}
