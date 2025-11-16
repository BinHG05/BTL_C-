using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IUserRepository
    {
        // Hàm lấy user bằng email (dùng để login)
        Task<User> GetUserByEmailAsync(string email);

        // Hàm kiểm tra email đã tồn tại chưa (dùng để register)
        Task<bool> EmailExistsAsync(string email);

        // Hàm thêm user mới (dùng để register)
        Task AddUserAsync(User user);

        // Hàm cập nhật user (dùng để cập nhật LastLogin)
        Task UpdateUserAsync(User user);
    }
}