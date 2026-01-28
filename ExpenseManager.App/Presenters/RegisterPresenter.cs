using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class RegisterPresenter
    {
        private readonly IAuthService _authService;
        private readonly IGoogleAuthService _googleAuthService; 

        public RegisterPresenter(IAuthService authService, IGoogleAuthService googleAuthService)
        {
            _authService = authService;
            _googleAuthService = googleAuthService;
        }

        // Hàm đăng ký bình thường
        public async Task<(bool Success, string? ErrorMessage)> RegisterAsync(string fullName, string email, string password)
        {
            try
            {
                return await _authService.RegisterAsync(fullName, email, password);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        // HÀM ĐĂNG KÝ BẰNG GOOGLE
        public async Task<(bool Success, string? ErrorMessage)> RegisterWithGoogleAsync()
        {
            try
            {
                // Bước 1: Authenticate với Google
                var (success, email, fullName, error) = await _googleAuthService.AuthenticateAsync();

                if (!success)
                {
                    return (false, error ?? "Đăng ký Google thất bại.");
                }

                // Bước 2: Đăng ký hoặc đăng nhập user
                var user = await _authService.LoginWithGoogleAsync(email, fullName);

                if (user != null)
                {
                    //LƯU USER VÀO SESSION
                    CurrentUserSession.SetUser(user);
                    return (true, null);
                }

                return (false, "Không thể tạo tài khoản.");
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
    }
}