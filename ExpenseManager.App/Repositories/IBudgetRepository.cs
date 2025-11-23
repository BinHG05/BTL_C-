using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;



public interface IBudgetRepository
{
    Task<IEnumerable<Budget>> GetAllAsync();
    Task<Budget?> GetByIdAsync(int id);
    Task<IEnumerable<Budget>> GetByUserAsync(string userId);
    Task<Budget> AddAsync(Budget model);
    Task<bool> UpdateAsync(Budget model);
    Task<bool> DeleteAsync(int id);
}