using System;
using System.Collections.Generic;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.User.UC
{
    public interface ISearchView
    {
        string Keyword { get; set; }
        string SelectedType { get; set; }
        int? SelectedCategoryId { get; set; }
        DateTime FromDate { get; set; }
        DateTime ToDate { get; set; }

        string ResultCount { get; set; }
        List<Transaction> Transactions { get; set; }

        void ShowMessage(string message, string title, bool isError = false);
        void LoadCategories(List<Category> categories);
        void InitializeFilters();
        void ResetFiltersUI(); 
    }
}