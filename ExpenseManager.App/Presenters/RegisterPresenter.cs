using ExpenseManager.App.Services;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class RegisterPresenter
    {
        private readonly IAuthService _authService;
        // private readonly IRegisterView _view; // (Nếu bạn dùng interface cho View)

        // Constructor nhận IAuthService (do Program.cs "tiêm" vào)
        public RegisterPresenter(IAuthService authService /*, IRegisterView view */)
        {
            _authService = authService;
            // _view = view;
        }

        // Hàm xử lý logic đăng ký
        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password)
        {
            try
            {
                // Gọi thẳng đến Service
                return await _authService.RegisterAsync(fullName, email, password);
            }
            catch (Exception ex)
            {
                // Bắt các lỗi CSDL hoặc lỗi hệ thống khác
                return (false, ex.Message);
            }
        }
    }
}