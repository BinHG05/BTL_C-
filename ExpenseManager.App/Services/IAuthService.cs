using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IAuthService
    {
        // Hàm Login: Trả về User nếu thành công, null nếu thất bại
        Task<User> LoginAsync(string email, string password);

        // Hàm Register: Trả về (true, null) nếu thành công
        // Trả về (false, "Lỗi...") nếu thất bại
        Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password);
    }
}