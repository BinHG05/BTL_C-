using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IAuthService
    {
        Task<User> LoginAsync(string email, string password);
        Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password);
        Task<User> LoginWithGoogleAsync(string email, string fullName);
        Task<(bool Success, string Message)> SendResetCodeAsync(string email);
        Task<(bool Success, string Message)> ResetPasswordAsync(string email, string code, string newPassword);
    }

}