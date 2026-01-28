using System;
using System.IO;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services.Interfaces;
using BCrypt.Net;

namespace ExpenseManager.App.Services
{
    public class ProfileServices : IProfileServices
    {
        private readonly IProfileRepository _repository;

        public ProfileServices(IProfileRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<User?> GetUserProfileAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
                return null;

            return await _repository.GetUserByIdAsync(userId);
        }

        public async Task<(bool success, string errorMessage)> UpdateGeneralInfoAsync(
            string userId,
            string fullName,
            string? newEmail,
            string? avatarFilePath)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(userId))
                return (false, "User ID không hợp lệ");

            if (string.IsNullOrWhiteSpace(fullName))
                return (false, "Họ tên không được để trống");

            // Kiểm tra email mới nếu có
            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                if (!IsValidEmail(newEmail))
                    return (false, "Email không hợp lệ");

                // Kiểm tra email đã tồn tại chưa
                bool emailExists = await _repository.IsEmailExistsAsync(newEmail, userId);
                if (emailExists)
                    return (false, "Email đã được sử dụng bởi tài khoản khác");
            }

            // Xử lý avatar nếu có
            string? avatarUrl = null;
            if (!string.IsNullOrWhiteSpace(avatarFilePath) && File.Exists(avatarFilePath))
            {
                avatarUrl = await SaveAvatarAsync(avatarFilePath, userId);
                if (avatarUrl == null)
                    return (false, "Không thể lưu ảnh đại diện");
            }

            // Cập nhật vào database
            bool result = await _repository.UpdateGeneralInfoAsync(userId, fullName, newEmail, avatarUrl);

            if (result)
                return (true, string.Empty);
            else
                return (false, "Không thể cập nhật thông tin. Vui lòng thử lại");
        }

        public async Task<(bool success, string errorMessage)> UpdateSecurityInfoAsync(
            string userId,
            string currentPassword,
            string? newEmail,
            string? newPassword)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(userId))
                return (false, "User ID không hợp lệ");

            if (string.IsNullOrWhiteSpace(currentPassword))
                return (false, "Vui lòng nhập mật khẩu hiện tại");

            // Lấy thông tin user để xác thực
            var user = await _repository.GetUserByIdAsync(userId);
            if (user == null)
                return (false, "Không tìm thấy thông tin người dùng");

            // Xác thực mật khẩu hiện tại
            bool isCurrentPasswordValid = BCrypt.Net.BCrypt.Verify(currentPassword, user.PasswordHash);
            if (!isCurrentPasswordValid)
            {
                // Đây là lý do bạn thấy thông báo này
                return (false, "Sai mật khẩu hiện tại");
            }

            // Validate email mới nếu có
            if (!string.IsNullOrWhiteSpace(newEmail))
            {
                if (!IsValidEmail(newEmail))
                    return (false, "Email mới không hợp lệ");

                bool emailExists = await _repository.IsEmailExistsAsync(newEmail, userId);
                if (emailExists)
                    return (false, "Email đã được sử dụng bởi tài khoản khác");
            }

            // Hash password mới nếu có
            string? newPasswordHash = null;
            if (!string.IsNullOrWhiteSpace(newPassword))
            {
                if (newPassword.Length < 6)
                    return (false, "Mật khẩu mới phải có ít nhất 6 ký tự");

                newPasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            }

            // Cập nhật vào database
            bool result = await _repository.UpdateSecurityInfoAsync(userId, newEmail, newPasswordHash);

            if (result)
                return (true, string.Empty);
            else
                return (false, "Không thể cập nhật thông tin bảo mật. Vui lòng thử lại");
        }

        public async Task<(bool success, string errorMessage)> UpdatePersonalInfoAsync(
            string userId,
            string? address,
            string? city,
            DateTime? dateOfBirth,
            string? country)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(userId))
                return (false, "User ID không hợp lệ");

            // Validate ngày sinh nếu có
            if(dateOfBirth.HasValue)
    {
                if (dateOfBirth.Value > DateTime.Now)
                    return (false, "Ngày sinh không hợp lệ: Không thể là ngày trong tương lai"); 

                var age = DateTime.Now.Year - dateOfBirth.Value.Year;
                if (age < 13)
                    return (false, "Bạn phải trên 13 tuổi để sử dụng dịch vụ"); 
            }

            // Cập nhật vào database
            bool result = await _repository.UpdatePersonalInfoAsync(userId, address, city, dateOfBirth, country);

            if (result)
                return (true, string.Empty);
            else
                return (false, "Không thể cập nhật thông tin cá nhân. Vui lòng thử lại");
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        private bool VerifyPassword(string password, string hash)
        {
            string hashedInput = HashPassword(password);
            return hashedInput.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private async Task<string?> SaveAvatarAsync(string sourceFilePath, string userId)
        {
            try
            {
                // Tạo thư mục lưu avatar nếu chưa có
                string avatarFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Uploads", "Avatars");
                if (!Directory.Exists(avatarFolder))
                    Directory.CreateDirectory(avatarFolder);

                // Tạo tên file mới (userId + extension)
                string extension = Path.GetExtension(sourceFilePath);
                string newFileName = $"{userId}_{DateTime.Now:yyyyMMddHHmmss}{extension}";
                string destinationPath = Path.Combine(avatarFolder, newFileName);

                // Copy file
                await Task.Run(() => File.Copy(sourceFilePath, destinationPath, true));

                // Trả về relative path
                return Path.Combine("Uploads", "Avatars", newFileName);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving avatar: {ex.Message}");
                return null;
            }
        }
    }
}