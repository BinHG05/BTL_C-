using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using System;
using System.Diagnostics;
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
                Debug.WriteLine("========================================");
                Debug.WriteLine("[LoginPresenter] LoginWithGoogleAsync START");

                // Gọi Google Auth
                var (success, email, fullName, error) = await _googleAuthService.AuthenticateAsync();

                Debug.WriteLine($"[LoginPresenter] Google Auth: Success={success}, Email={email}");

                if (!success)
                {
                    Debug.WriteLine($"[LoginPresenter] Google Auth FAILED: {error}");
                    return (false, null, error ?? "Đăng nhập Google thất bại.");
                }

                // Đăng nhập hoặc tạo user mới
                Debug.WriteLine("[LoginPresenter] Calling LoginWithGoogleAsync on AuthService...");
                var user = await _authService.LoginWithGoogleAsync(email, fullName);

                Debug.WriteLine($"[LoginPresenter] AuthService returned User: {user?.UserId ?? "NULL"}");

                if (user != null)
                {
                    Debug.WriteLine($"[LoginPresenter] Setting Session for User: {user.UserId}");
                    CurrentUserSession.SetUser(user);

                    // ✅ Verify ngay sau khi set
                    if (CurrentUserSession.CurrentUser == null)
                    {
                        Debug.WriteLine("[LoginPresenter] ❌ ERROR: Session is NULL after SetUser!");
                        return (false, null, "Không thể lưu phiên đăng nhập");
                    }

                    Debug.WriteLine($"[LoginPresenter] ✅ Session SET SUCCESS: {CurrentUserSession.CurrentUser.UserId}");
                    Debug.WriteLine("========================================");
                    return (true, user, null);
                }
                else
                {
                    Debug.WriteLine("[LoginPresenter] ❌ ERROR: User is NULL from AuthService");
                    Debug.WriteLine("========================================");
                    return (false, null, "Không thể tạo tài khoản.");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[LoginPresenter] EXCEPTION: {ex.Message}");
                Debug.WriteLine($"[LoginPresenter] Stack Trace: {ex.StackTrace}");
                Debug.WriteLine("========================================");
                return (false, null, ex.Message);
            }
        }
    }
}