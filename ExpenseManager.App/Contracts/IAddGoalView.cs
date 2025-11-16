using System;

namespace ExpenseManager.App.Contracts
{
    // Cập nhật Interface cho pop-up AddGoalForm
    public interface IAddGoalView
    {
        // === Properties (Get/Set) (Đã có) ===
        string GoalName { get; set; }
        decimal TargetAmount { get; set; }
        DateTime CompletionDate { get; set; }
        int? GoalIdToEdit { get; }


        // === Events (Báo cho Presenter) ===

        event EventHandler SaveClicked; // (Đã có)
        event EventHandler LoadView; // (Đã có)

        // *** EVENT MỚI (Cho chức năng Xóa) ***
        event EventHandler DeleteClicked;


        // === Actions (Presenter ra lệnh) ===

        void ShowError(string message); // (Đã có)
        void CloseDialog(bool success); // (Đã có)
        void SetEditMode(string goalName); // (Đã có)

        // *** ACTION MỚI (Cho chức năng Xóa) ***
        // Presenter ra lệnh cho View: "Hãy hiển thị nút Xóa"
        void ShowDeleteButton();

        // *** ACTION MỚI (Cho chức năng Xóa) ***
        // Presenter hỏi View: "Hãy hiển thị hộp thoại Yes/No và cho tôi biết kết quả"
        bool ConfirmDelete(string goalName);
    }
}