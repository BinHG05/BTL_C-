using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public interface IUserService
    {
        // Hàm đăng nhập, trả về User nếu thành công, null nếu thất bại
        Task<User> LoginAsync(string email, string password);

        // Hàm đăng ký, trả về User mới nếu thành công
        Task<User> RegisterAsync(string fullName, string email, string password);

        // Hàm kiểm tra email tồn tại
        Task<bool> CheckEmailExistsAsync(string email);
    }
}