using ExpenseManager.App.Models.Entities;
using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Views.User.UC
{
    public class CategoryExpense
    {
        public string CategoryName { get; set; }
        public decimal Amount { get; set; }
        public string ColorHex { get; set; }
    }

    public interface IWalletView
    {
        string UserId { get; }
        int? SelectedWalletId { get; set; } 
        int CurrentPage { get; set; }

        event EventHandler LoadView;
        event EventHandler SelectWallet;    
        event EventHandler AddNewWallet;   
        event EventHandler EditWallet;      
        event EventHandler DeleteWallet;    
        event EventHandler NextPage;
        event EventHandler PreviousPage;

        void DisplayWallets(List<Wallet> wallets);
        void DisplayWalletDetails(Wallet wallet, decimal monthlyExpenses);
        void DisplayTransactions(List<Transaction> transactions, int totalRecords, int pageSize);
        void DisplayCategoryChart(List<CategoryExpense> categoryExpenses);
        void ShowEmptyState(bool show); 
        void ShowMessage(string message, string title, bool isError = false);
    }
}