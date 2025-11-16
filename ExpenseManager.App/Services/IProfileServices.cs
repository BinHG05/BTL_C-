using System;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services.Interfaces
{
    /// <summary>
    /// Interface cho Profile Services - định nghĩa các nghiệp vụ xử lý profile
    /// </summary>
    public interface IProfileServices
    {
        /// <summary>
        /// Lấy thông tin User theo UserId
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <returns>Đối tượng User hoặc null nếu không tìm thấy</returns>
        Task<User?> GetUserProfileAsync(string userId);

        /// <summary>
        /// Cập nhật thông tin chung (FullName, Email, Avatar)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="fullName">Tên đầy đủ mới</param>
        /// <param name="newEmail">Email mới (có thể null)</param>
        /// <param name="avatarFilePath">Đường dẫn file avatar (có thể null)</param>
        /// <returns>Tuple (success, errorMessage)</returns>
        Task<(bool success, string errorMessage)> UpdateGeneralInfoAsync(
            string userId,
            string fullName,
            string? newEmail,
            string? avatarFilePath);

        /// <summary>
        /// Cập nhật thông tin bảo mật (Password và Email)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="currentPassword">Mật khẩu hiện tại</param>
        /// <param name="newEmail">Email mới (có thể null)</param>
        /// <param name="newPassword">Mật khẩu mới (có thể null)</param>
        /// <returns>Tuple (success, errorMessage)</returns>
        Task<(bool success, string errorMessage)> UpdateSecurityInfoAsync(
            string userId,
            string currentPassword,
            string? newEmail,
            string? newPassword);

        /// <summary>
        /// Cập nhật thông tin cá nhân (Address, City, DateOfBirth, Country)
        /// </summary>
        /// <param name="userId">ID của người dùng</param>
        /// <param name="address">Địa chỉ mới</param>
        /// <param name="city">Thành phố mới</param>
        /// <param name="dateOfBirth">Ngày sinh mới</param>
        /// <param name="country">Quốc gia mới</param>
        /// <returns>Tuple (success, errorMessage)</returns>
        Task<(bool success, string errorMessage)> UpdatePersonalInfoAsync(
            string userId,
            string? address,
            string? city,
            DateTime? dateOfBirth,
            string? country);
    }
}