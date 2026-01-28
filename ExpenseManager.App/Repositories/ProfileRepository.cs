using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;

namespace ExpenseManager.App.Repositories
{
    /// Repository xử lý truy xuất và cập nhật dữ liệu User trong database
    public class ProfileRepository : IProfileRepository
    {
        private readonly ExpenseDbContext _context;

        public ProfileRepository(ExpenseDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        /// Lấy thông tin User theo UserId
        public async Task<User?> GetUserByIdAsync(string userId)
        {
            try
            {
                return await _context.Users
                    .AsNoTracking()
                    .FirstOrDefaultAsync(u => u.UserId == userId);
            }
            catch (Exception ex)
            {
                // Log exception (nên dùng ILogger trong production)
                Console.WriteLine($"Error in GetUserByIdAsync: {ex.Message}");
                return null;
            }
        }

        /// Cập nhật thông tin chung (FullName, Email, Avatar)
        public async Task<bool> UpdateGeneralInfoAsync(string userId, string fullName, string? email, string? avatarUrl)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                // Cập nhật các trường
                user.FullName = fullName;

                if (!string.IsNullOrWhiteSpace(email))
                    user.Email = email;

                if (!string.IsNullOrWhiteSpace(avatarUrl))
                    user.AvatarUrl = avatarUrl;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateGeneralInfoAsync: {ex.Message}");
                return false;
            }
        }

        /// Cập nhật thông tin bảo mật (Email và Password)
        public async Task<bool> UpdateSecurityInfoAsync(string userId, string? newEmail, string? newPasswordHash)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                // Cập nhật Email nếu có
                if (!string.IsNullOrWhiteSpace(newEmail))
                    user.Email = newEmail;

                // Cập nhật Password nếu có
                if (!string.IsNullOrWhiteSpace(newPasswordHash))
                    user.PasswordHash = newPasswordHash;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdateSecurityInfoAsync: {ex.Message}");
                return false;
            }
        }

        /// Cập nhật thông tin cá nhân (Address, City, DateOfBirth, Country)
        public async Task<bool> UpdatePersonalInfoAsync(string userId, string? address, string? city, DateTime? dateOfBirth, string? country)
        {
            try
            {
                var user = await _context.Users.FindAsync(userId);
                if (user == null)
                    return false;

                // Cập nhật các trường cá nhân
                user.Address = address;
                user.City = city;
                user.DateOfBirth = dateOfBirth;
                user.Country = country;

                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in UpdatePersonalInfoAsync: {ex.Message}");
                return false;
            }
        }

        /// Kiểm tra email có tồn tại trong hệ thống hay không
        public async Task<bool> IsEmailExistsAsync(string email, string excludeUserId)
        {
            try
            {
                return await _context.Users
                    .AnyAsync(u => u.Email == email && u.UserId != excludeUserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in IsEmailExistsAsync: {ex.Message}");
                return false;
            }
        }
    }
}