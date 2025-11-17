using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Views.User.UC
{
    // DTO (Data Transfer Object) cho biểu đồ
    public class CategoryExpense
    {
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string ColorHex { get; set; }
    }

    public interface IWalletView
    {
        // === Properties ===
        string UserId { get; }
        int? SelectedWalletId { get; set; } // Dùng để Presenter biết đang chọn ví nào
        int CurrentPage { get; set; }

        // === Events ===
        event EventHandler LoadView;
        event EventHandler SelectWallet;    // Khi bấm chọn ví
        event EventHandler AddNewWallet;    // Khi bấm nút "Add new wallet"
        event EventHandler EditWallet;      // Khi bấm nút "Sửa"
        event EventHandler DeleteWallet;    // Khi bấm nút "Xóa"
        event EventHandler NextPage;
        event EventHandler PreviousPage;

        // === Methods ===
        void DisplayWallets(List<Wallet> wallets);
        void DisplayWalletDetails(Wallet wallet, decimal monthlyExpenses);
        void DisplayTransactions(List<Transaction> transactions, int totalRecords, int pageSize);
        void DisplayCategoryChart(List<CategoryExpense> categoryExpenses);
        void ShowEmptyState(bool show); // Hiển thị khi không có ví
        void ShowMessage(string message, string title, bool isError = false);
    }
}