using System;

namespace ExpenseManager.App.Views
{
    // Giao diện này BÂY GIỜ chỉ dành cho Đăng nhập
    public interface ILoginView
    {
        // --- Properties (Chỉ cho Login) ---
        string Email { get; set; }
        string Password { get; set; }
        bool RememberMe { get; set; }

        // --- Events ---
        event EventHandler LoginClicked;        
        event EventHandler CreateAccountClicked;  

        // --- Actions ---
        void ShowError(string message);
        void ShowSuccess(string message);
        void NavigateToMain();

        // Action mới: Yêu cầu View mở Form Đăng ký
        void ShowRegisterForm();
    }
}