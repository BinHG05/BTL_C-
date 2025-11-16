using ExpenseManager.App.Services;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class ForgotPasswordPresenter
    {
        // Tạm thời Presenter này chưa cần logic phức tạp,
        // vì logic đang được xử lý trực tiếp bên trong ForgotPasswordForm.cs
        // Tuy nhiên, chúng ta vẫn cần file này để Program.cs có thể inject.

        public ForgotPasswordPresenter()
        {
            // Khi bạn phát triển logic BE cho "Quên mật khẩu",
            // bạn sẽ inject IAuthService vào đây.
        }

        // Ví dụ (cho tương lai):
        // public async Task<bool> SendResetCodeAsync(string email)
        // {
        //     // return await _authService.SendResetCodeAsync(email);
        // }
    }
}