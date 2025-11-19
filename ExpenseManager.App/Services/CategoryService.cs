using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// Thêm 2 dòng alias này
using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IIconRepository _iconRepository;
        private readonly IColorRepository _colorRepository;

        public CategoryService(ICategoryRepository categoryRepository, IIconRepository iconRepository, IColorRepository colorRepository)
        {
            _categoryRepository = categoryRepository;
            _iconRepository = iconRepository;
            _colorRepository = colorRepository;
        }

        public Task<List<Category>> GetCategoriesByUserIdAsync(string userId)
        {
            return _categoryRepository.GetCategoriesByUserIdAsync(userId);
        }

        // Sửa dùng alias DbIcon
        public Task<List<DbIcon>> GetAllIconsAsync()
        {
            return _iconRepository.GetAllIconsAsync();
        }

        // Sửa dùng alias DbColor
        public Task<List<DbColor>> GetAllColorsAsync()
        {
            return _colorRepository.GetAllColorsAsync();
        }

        public async Task CreateCategoryAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new ArgumentException("Category name cannot be empty.");

            category.CreatedAt = DateTime.Now;
            await _categoryRepository.AddCategoryAsync(category);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.CategoryName))
                throw new ArgumentException("Category name cannot be empty.");

            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(category.CategoryId);
            if (existingCategory == null)
                throw new ArgumentException("Category not found.");

            // Cập nhật các trường
            existingCategory.CategoryName = category.CategoryName;
            existingCategory.Type = category.Type;
            existingCategory.IconId = category.IconId;
            existingCategory.ColorId = category.ColorId;

            _categoryRepository.UpdateCategory(existingCategory);
            await _categoryRepository.SaveChangesAsync();
        }

        public async Task DeleteCategoryAsync(int categoryId)
        {
            var existingCategory = await _categoryRepository.GetCategoryByIdAsync(categoryId);
            if (existingCategory == null)
                throw new ArgumentException("Category not found.");

            // (Kiểm tra logic, ví dụ: không cho xóa nếu có transaction)
            // if (existingCategory.Transactions.Any())
            //    throw new InvalidOperationException("Cannot delete category with existing transactions.");

            _categoryRepository.DeleteCategory(existingCategory);
            await _categoryRepository.SaveChangesAsync();
        }
    }
}