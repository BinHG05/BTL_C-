using ExpenseManager.App.Models.DTOs;
using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Views.User.UC
{
    public interface IAnalyticsView
    {
        string UserId { get; }
        int? SelectedWalletId { get; }
        string SelectedMonth { get; set; }
        string ActiveTab { get; set; }

        // Expense Data
        void DisplayExpenseBreakdown(List<ExpenseBreakdownItem> breakdown);
        void DisplayExpenseHistory(List<TransactionDto> history);
        void DisplayTotalExpense(decimal total);
        void DisplayExpenseTrend(List<TrendDataPoint> trendData);

        // Income Data
        void DisplayIncomeBreakdown(List<IncomeBreakdownItem> breakdown);
        void DisplayIncomeHistory(List<IncomeTransactionDto> history);
        void DisplayTotalIncome(decimal total);
        void DisplayIncomeTrend(List<TrendDataPoint> trendData);

        // Paging và Trạng thái
        void DisplayPagingInfo(PagingInfo info);
        void ShowLoading(bool isVisible);
        void ShowError(string message);

        // Wallet List Control
        void SetWalletList(List<WalletDto> wallets);

        // Events (Presenter đăng ký)
        event EventHandler LoadWalletList;
        event EventHandler ApplyFilter;
        event EventHandler ResetFilter;
        event EventHandler<int> PageChanged;
    }
}