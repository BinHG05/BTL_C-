using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class UserRepository : IUserRepository
    {
        // Đây là DbContext của bạn
        private readonly ExpenseDbContext _context;

        // Chúng ta sẽ "inject" DbContext vào đây
        public UserRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // Tìm user đầu tiên có email trùng
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            // Kiểm tra xem có bất kỳ user nào có email này không
            return await _context.Users.AnyAsync(u => u.Email == email);
        }

        public async Task AddUserAsync(User user)
        {
            // Thêm user mới vào
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user)
        {
            // Cập nhật user
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}