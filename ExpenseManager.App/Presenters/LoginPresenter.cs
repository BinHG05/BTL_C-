using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class LoginPresenter
    {
        private readonly IAuthService _authService;

        public LoginPresenter(IAuthService authService)
        {
            _authService = authService;
        }

        // Sửa lại để trả về cả User (để lấy Role)
        public async Task<(bool Success, User User)> LoginAsync(string email, string password)
        {
            try
            {
                // Gọi Service
                var user = await _authService.LoginAsync(email, password);

                if (user != null)
                {
                    // Lưu vào Session
                    CurrentUserSession.SetUser(user);
                    return (true, user);
                }
                else
                {
                    return (false, null);
                }
            }
            catch (Exception ex)
            {
                // Log lỗi nếu cần
                return (false, null);
            }
        }
    }
}