using ExpenseManager.App.Models.Entities;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    /// <summary>
    /// Interface cho Profile Repository - định nghĩa các phương thức truy xuất dữ liệu User
    /// </summary>
    public interface IProfileRepository
    {
        /// <summary>
        /// Lấy thông tin User theo UserId
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <returns>Đối tượng User hoặc null nếu không tìm thấy</returns>
        Task<User?> GetUserByIdAsync(string userId);

        /// <summary>
        /// Cập nhật thông tin chung (FullName, Email, Avatar)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="fullName">Tên đầy đủ mới</param>
        /// <param name="email">Email mới (có thể null nếu không đổi)</param>
        /// <param name="avatarUrl">URL avatar mới (có thể null nếu không đổi)</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        Task<bool> UpdateGeneralInfoAsync(string userId, string fullName, string? email, string? avatarUrl);

        /// <summary>
        /// Cập nhật thông tin bảo mật (Email và Password)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="newEmail">Email mới (có thể null nếu không đổi)</param>
        /// <param name="newPasswordHash">Hash của mật khẩu mới (có thể null nếu không đổi)</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        Task<bool> UpdateSecurityInfoAsync(string userId, string? newEmail, string? newPasswordHash);

        /// <summary>
        /// Cập nhật thông tin cá nhân (Address, City, DateOfBirth, Country)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="address">Địa chỉ mới</param>
        /// <param name="city">Thành phố mới</param>
        /// <param name="dateOfBirth">Ngày sinh mới</param>
        /// <param name="country">Quốc gia mới</param>
        /// <returns>True nếu cập nhật thành công, False nếu thất bại</returns>
        Task<bool> UpdatePersonalInfoAsync(string userId, string? address, string? city, DateTime? dateOfBirth, string? country);

        /// <summary>
        /// Kiểm tra email có tồn tại trong hệ thống hay không (dùng cho validation)
        /// </summary>
        /// <param name="email">Email cần kiểm tra</param>
        /// <param name="excludeUserId">UserId cần loại trừ (user hiện tại)</param>
        /// <returns>True nếu email đã tồn tại, False nếu chưa</returns>
        Task<bool> IsEmailExistsAsync(string email, string excludeUserId);
    }
}