using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    // Interface Category
    public interface ICategoryRepository
    {
        Task<List<Category>> GetCategoriesByUserIdAsync(string userId);
        Task<Category> GetCategoryByIdAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Task SaveChangesAsync();
    }
}