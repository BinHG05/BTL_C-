using ExpenseManager.App.Models.Entities;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    /// Interface cho Profile Repository - định nghĩa các phương thức truy xuất dữ liệu User
    public interface IProfileRepository
    {
        /// Lấy thông tin User theo UserId
        Task<User?> GetUserByIdAsync(string userId);

        /// Cập nhật thông tin chung (FullName, Email, Avatar)
        Task<bool> UpdateGeneralInfoAsync(string userId, string fullName, string? email, string? avatarUrl);

        /// Cập nhật thông tin bảo mật (Email và Password)
        Task<bool> UpdateSecurityInfoAsync(string userId, string? newEmail, string? newPasswordHash);

        /// Cập nhật thông tin cá nhân (Address, City, DateOfBirth, Country)
        Task<bool> UpdatePersonalInfoAsync(string userId, string? address, string? city, DateTime? dateOfBirth, string? country);

        /// Kiểm tra email có tồn tại trong hệ thống hay không (dùng cho validation)
        Task<bool> IsEmailExistsAsync(string email, string excludeUserId);
    }
}