using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IUserRepository
    {
        // Lấy user bằng email (không phân biệt hoa thường)
        Task<User> GetUserByEmailAsync(string email);

        // Kiểm tra email tồn tại
        Task<bool> CheckEmailExistsAsync(string email);

        // Thêm user mới
        Task<User> AddUserAsync(User user);

        // Cập nhật user (ví dụ: cập nhật LastLogin)
        Task UpdateUserAsync(User user);

        // Lấy user bằng ID (Bổ sung theo gợi ý của bạn)
        Task<User> GetUserByIdAsync(string userId);
    }
}