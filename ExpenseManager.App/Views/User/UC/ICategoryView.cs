using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;

// Thêm 2 dòng alias này
using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Views.User.UC
{
    public interface ICategoryView
    {
        string UserId { get; }
        int? SelectedCategoryId { get; }
        string CategoryName { get; set; }
        string CategoryType { get; set; }
        int SelectedIconId { get; set; }
        int SelectedColorId { get; set; }

        event EventHandler LoadView;
        event EventHandler CreateCategory;
        event EventHandler UpdateCategory;
        event EventHandler DeleteCategory;
        event EventHandler SelectCategory;

        void DisplayCategories(List<Category> incomeCategories, List<Category> expenseCategories);

        void PopulateDropdowns(List<DbIcon> icons, List<DbColor> colors);

        void LoadCategoryForEdit(Category category);
        void ResetForm();
        void ShowMessage(string message, string title, bool isError = false);
    }
}