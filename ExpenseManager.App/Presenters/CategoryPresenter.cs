using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User.UC; // Đảm bảo bạn đã using ICategoryView
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore; // <<< THÊM DÒNG NÀY

namespace ExpenseManager.App.Presenters
{
    public class CategoryPresenter : IDisposable
    {
        private readonly ICategoryView _view;
        private readonly ICategoryService _service;

        public CategoryPresenter(ICategoryView view, ICategoryService service)
        {
            _view = view;
            _service = service;

            // Đăng ký các sự kiện từ View
            _view.LoadView += OnLoadView;
            _view.CreateCategory += OnCreateCategory;
            _view.UpdateCategory += OnUpdateCategory;
            _view.DeleteCategory += OnDeleteCategory;
            _view.SelectCategory += OnSelectCategory;
        }

        private async void OnLoadView(object sender, EventArgs e)
        {
            try
            {
                await LoadAllCategories();
                await LoadDropdowns();
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải dữ liệu: {ex.Message}", "Lỗi", true);
            }
        }

        private async Task LoadAllCategories()
        {
            var categories = await _service.GetCategoriesByUserIdAsync(_view.UserId);
            var incomeCategories = categories.Where(c => c.Type == "Income").ToList();
            var expenseCategories = categories.Where(c => c.Type == "Expense").ToList();
            _view.DisplayCategories(incomeCategories, expenseCategories);
        }

        private async Task LoadDropdowns()
        {
            var icons = await _service.GetAllIconsAsync();
            var colors = await _service.GetAllColorsAsync();
            _view.PopulateDropdowns(icons, colors);
        }

        private async void OnCreateCategory(object sender, EventArgs e)
        {
            try
            {
                var category = new Category
                {
                    UserId = _view.UserId,
                    CategoryName = _view.CategoryName,
                    Type = _view.CategoryType,
                    IconId = _view.SelectedIconId,
                    ColorId = _view.SelectedColorId
                };
                await _service.CreateCategoryAsync(category);
                _view.ShowMessage("Tạo danh mục thành công!", "Thành công");
                _view.ResetForm();
                await LoadAllCategories(); // Tải lại danh sách
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi tạo mới", true);
            }
        }

        private async void OnUpdateCategory(object sender, EventArgs e)
        {
            if (_view.SelectedCategoryId == null) return;

            try
            {
                var category = new Category
                {
                    CategoryId = _view.SelectedCategoryId.Value,
                    CategoryName = _view.CategoryName,
                    Type = _view.CategoryType,
                    IconId = _view.SelectedIconId,
                    ColorId = _view.SelectedColorId
                };
                await _service.UpdateCategoryAsync(category);
                _view.ShowMessage("Cập nhật thành công!", "Thành công");
                _view.ResetForm();
                await LoadAllCategories(); // Tải lại danh sách
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi cập nhật", true);
            }
        }

        private async void OnSelectCategory(object sender, EventArgs e)
        {
            if (_view.SelectedCategoryId == null) return;

            var categories = await _service.GetCategoriesByUserIdAsync(_view.UserId);
            var categoryToEdit = categories.FirstOrDefault(c => c.CategoryId == _view.SelectedCategoryId.Value);

            if (categoryToEdit != null)
            {
                _view.LoadCategoryForEdit(categoryToEdit);
            }
        }

        // ===== BẮT ĐẦU SỬA LỖI XÓA =====
        private async void OnDeleteCategory(object sender, EventArgs e)
        {
            if (_view.SelectedCategoryId == null) return;
            try
            {
                await _service.DeleteCategoryAsync(_view.SelectedCategoryId.Value);
                _view.ShowMessage("Xóa thành công!", "Thành công");
                _view.ResetForm();
                await LoadAllCategories(); // Tải lại danh sách
            }
            catch (DbUpdateException dbEx) // Bắt lỗi cụ thể của EF
            {
                string errorMessage = dbEx.InnerException?.Message ?? dbEx.Message;

                // Kiểm tra xem có phải lỗi Khóa Ngoại (Foreign Key) không
                if (errorMessage.Contains("FOREIGN KEY constraint") || errorMessage.Contains("REFERENCE constraint"))
                {
                    errorMessage = "Không thể xóa danh mục này vì nó đang được sử dụng bởi một Giao dịch (Transaction) hoặc Ngân sách (Budget) đã có.";
                }
                else
                {
                    errorMessage = "Lỗi database: " + errorMessage;
                }

                _view.ShowMessage(errorMessage, "Lỗi xóa", true);
            }
            catch (Exception ex) // Bắt các lỗi chung khác
            {
                _view.ShowMessage($"Lỗi: {ex.Message}", "Lỗi xóa", true);
            }
        }
        // ===== KẾT THÚC SỬA LỖI XÓA =====

        public void Dispose()
        {
            // Hủy đăng ký sự kiện
            _view.LoadView -= OnLoadView;
            _view.CreateCategory -= OnCreateCategory;
            _view.UpdateCategory -= OnUpdateCategory;
            _view.DeleteCategory -= OnDeleteCategory;
            _view.SelectCategory -= OnSelectCategory;
        }
    }
}