using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Services.Admin;
using ExpenseManager.App.Views.Admin.UC;
using System;

namespace ExpenseManager.App.Presenters.Admin
{
    public class CategoryAdminPresenter
    {
        private readonly ICategoryAdminView _view;
        private readonly CategoryAdminService _service;

        public CategoryAdminPresenter(ICategoryAdminView view, ExpenseDbContext dbContext)
        {
            _view = view;
            _service = new CategoryAdminService(dbContext);
        }

        public void LoadIcons()
        {
            try
            {
                var icons = _service.GetAllIcons();
                _view.DisplayIcons(icons);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi tải danh sách icons: {ex.Message}");
            }
        }

        public void LoadColors()
        {
            try
            {
                var colors = _service.GetAllColors();
                _view.DisplayColors(colors);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi tải danh sách colors: {ex.Message}");
            }
        }

        public void AddIcon(IconDTO dto)
        {
            try
            {
                _service.AddIcon(dto);
                _view.ShowSuccess("Thêm icon thành công!");
                LoadIcons();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi thêm icon: {ex.Message}");
            }
        }

        public void AddColor(ColorDTO dto)
        {
            try
            {
                _service.AddColor(dto);
                _view.ShowSuccess("Thêm màu thành công!");
                LoadColors();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi thêm màu: {ex.Message}");
            }
        }

        public void DeleteIcon(int iconId)
        {
            try
            {
                _service.DeleteIcon(iconId);
                _view.ShowSuccess("Xóa icon thành công!");
                LoadIcons();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi xóa icon: {ex.Message}");
            }
        }

        public void DeleteColor(int colorId)
        {
            try
            {
                _service.DeleteColor(colorId);
                _view.ShowSuccess("Xóa màu thành công!");
                LoadColors();
            }
            catch (Exception ex)
            {
                _view.ShowError($"Lỗi xóa màu: {ex.Message}");
            }
        }
    }
}