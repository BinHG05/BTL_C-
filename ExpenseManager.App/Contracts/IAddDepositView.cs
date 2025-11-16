using ExpenseManager.App.Models.Entities; // Cần cho Wallet
using System;
using System.Collections.Generic; // Cần cho List

// (Namespace của bạn)
namespace ExpenseManager.App.Contracts
{
    // Cập nhật Interface cho pop-up AddDepositForm
    public interface IAddDepositView
    {
        // === Properties: Lấy dữ liệu từ Form (View -> Presenter) ===

        decimal Amount { get; }
        int GoalId { get; } // ID của Goal (cha) đang được nạp

        // *** THUỘC TÍNH MỚI (Sửa lỗi CSDL) ***
        int SelectedWalletId { get; } // ID của Ví (Wallet) mà người dùng chọn


        // === Events: Báo cho Presenter (View -> Presenter) ===

        event EventHandler SaveDepositClicked;
        event EventHandler LoadView; // Để tải tên Goal VÀ danh sách Ví


        // === Actions: Presenter ra lệnh cho View (Presenter -> View) ===

        void ShowError(string message);
        void CloseDialog(bool success);

        // Ra lệnh cho View hiển thị tên của Goal
        void SetGoalDetails(string goalName, decimal currentAmount, decimal targetAmount);

        // *** ACTION MỚI (Sửa lỗi CSDL) ***
        // Ra lệnh cho View điền (populate) danh sách Ví vào ComboBox
        void SetWallets(List<Wallet> wallets);
    }
}