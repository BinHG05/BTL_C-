using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Views.User.UC
{
    public interface IAddTransactionView
    {
        // Properties lấy dữ liệu từ Form
        string UserId { get; } 
        string TransactionType { get; set; }
        decimal Amount { get; set; }
        int? SelectedCategoryId { get; set; } 
        int? SelectedWalletId { get; set; }
        DateTime TransactionDate { get; set; }
        string Description { get; set; }

        void LoadCategories(IEnumerable<Category> categories);
        void LoadWallets(IEnumerable<Wallet> wallets);
        void ResetForm();

        // Events
        event EventHandler LoadView;
        event EventHandler SaveTransaction;
        event EventHandler TypeChanged; 

        // Thông báo
        void ShowMessage(string message, string title, bool isError = false);
        void CloseForm();
    }
}