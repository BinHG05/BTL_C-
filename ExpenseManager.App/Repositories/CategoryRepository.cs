using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ExpenseDbContext _context;

        public CategoryRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Category>> GetCategoriesByUserIdAsync(string userId)
        {
            return await _context.Categories
                .Include(c => c.Icon) 
                .Include(c => c.Color) 
                .Where(c => c.UserId == userId)
                .OrderBy(c => c.CategoryName)
                .AsNoTracking() 
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(int categoryId)
        {
            return await _context.Categories.FindAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            await _context.Categories.AddAsync(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public void DeleteCategory(Category category)
        {
            _context.Categories.Remove(category);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }

    public class IconRepository : IIconRepository
    {
        private readonly ExpenseDbContext _context;
        public IconRepository(ExpenseDbContext context) { _context = context; }

        public async Task<List<DbIcon>> GetAllIconsAsync()
        {
            return await _context.Icons.AsNoTracking().ToListAsync();
        }
    }

    public class ColorRepository : IColorRepository
    {
        private readonly ExpenseDbContext _context;
        public ColorRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<DbColor>> GetAllColorsAsync()
        {
            return await _context.Colors.AsNoTracking().ToListAsync();
        }
    }
}