using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ExpenseDbContext _context;

        public UserRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            // So sánh email không phân biệt hoa thường
            return await _context.Users
                .AnyAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            // So sánh email không phân biệt hoa thường
            return await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower());
        }

        public async Task UpdateUserAsync(User user)
        {
            // Đánh dấu là đã sửa đổi và lưu
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(string userId)
        {
            // Dùng FirstOrDefaultAsync để tìm theo UserId (là string)
            return await _context.Users
                .FirstOrDefaultAsync(u => u.UserId == userId);
        }
    }
}