using ExpenseManager.App.Services;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class ForgotPasswordPresenter
    {
        private readonly IAuthService _authService;

        public ForgotPasswordPresenter(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<(bool Success, string Message)> RequestResetCode(string email)
        {
            return await _authService.SendResetCodeAsync(email);
        }

        public async Task<(bool Success, string Message)> SubmitNewPassword(string email, string code, string newPass)
        {
            return await _authService.ResetPasswordAsync(email, code, newPass);
        }
    }
}