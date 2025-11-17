using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

// Thêm alias
using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesByUserIdAsync(string userId);

        Task<List<DbIcon>> GetAllIconsAsync();
        Task<List<DbColor>> GetAllColorsAsync();

        Task CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category category);
        Task DeleteCategoryAsync(int categoryId);
    }
}