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
        private readonly IGoogleAuthService _googleAuthService; 

       
        public LoginPresenter(IAuthService authService, IGoogleAuthService googleAuthService)
        {
            _authService = authService;
            _googleAuthService = googleAuthService;
        }

        public async Task<(bool Success, User User)> LoginAsync(string email, string password)
        {
            try
            {
                var user = await _authService.LoginAsync(email, password);

                if (user != null)
                {
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
                return (false, null);
            }
        }

     
        public async Task<(bool Success, User User, string Error)> LoginWithGoogleAsync()
        {
            try
            {
                // Gọi Google Auth
                var (success, email, fullName, error) = await _googleAuthService.AuthenticateAsync();

                if (!success)
                {
                    return (false, null, error ?? "Đăng nhập Google thất bại.");
                }

                // Đăng nhập hoặc tạo user mới
                var user = await _authService.LoginWithGoogleAsync(email, fullName);

                if (user != null)
                {
                    CurrentUserSession.SetUser(user);
                    return (true, user, null);
                }
                else
                {
                    return (false, null, "Không thể tạo tài khoản.");
                }
            }
            catch (Exception ex)
            {
                return (false, null, ex.Message);
            }
        }
    }
}