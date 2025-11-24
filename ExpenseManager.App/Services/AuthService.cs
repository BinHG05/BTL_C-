using ExpenseManager.App.Helpers;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
  

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<(bool Success, string Message)> SendResetCodeAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null)
            {
                return (false, "Email này chưa được đăng ký trong hệ thống.");
            }

            // 1. Tạo mã xác nhận (6 số ngẫu nhiên)
            string code = new Random().Next(100000, 999999).ToString();

            // 2. Lưu mã và thời gian hết hạn (15 phút) vào DB
            user.PasswordResetToken = code;
            user.PasswordResetTokenExpiry = DateTime.Now.AddMinutes(15);

            // Cập nhật User vào DB
            await _userRepository.UpdateUserAsync(user);

            // 3. Gửi Email
            try
            {
                string subject = "[Expense Manager] Mã xác nhận đặt lại mật khẩu";
                string body = $@"
                    <h3>Xin chào {user.FullName},</h3>
                    <p>Bạn đã yêu cầu đặt lại mật khẩu. Mã xác nhận của bạn là:</p>
                    <h2 style='color: #007bff; letter-spacing: 5px;'>{code}</h2>
                    <p>Mã này có hiệu lực trong <b>15 phút</b>.</p>
                    <p>Nếu bạn không yêu cầu, vui lòng bỏ qua email này.</p>";

                await EmailHelper.SendEmailAsync(email, subject, body);
                return (true, "Mã xác nhận đã được gửi đến email của bạn.");
            }
            catch (Exception ex)
            {
                return (false, "Lỗi gửi email: " + ex.Message);
            }
        }

        public async Task<(bool Success, string Message)> ResetPasswordAsync(string email, string code, string newPassword)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            if (user == null) return (false, "Người dùng không tồn tại.");

            // 1. Kiểm tra Token
            if (user.PasswordResetToken != code)
            {
                return (false, "Mã xác nhận không đúng.");
            }

            // 2. Kiểm tra hạn sử dụng
            if (user.PasswordResetTokenExpiry.HasValue && user.PasswordResetTokenExpiry.Value < DateTime.Now)
            {
                return (false, "Mã xác nhận đã hết hạn. Vui lòng lấy mã mới.");
            }

            // 3. Hash mật khẩu mới và lưu
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);

            // 4. Xóa Token để không dùng lại được nữa
            user.PasswordResetToken = null;
            user.PasswordResetTokenExpiry = null;

            await _userRepository.UpdateUserAsync(user);

            return (true, "Đổi mật khẩu thành công.");
        }
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null || !user.IsActive)
            {
                return null;
            }

            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (isPasswordValid)
            {
                user.LastLogin = DateTime.Now;
                await _userRepository.UpdateUserAsync(user);
                return user;
            }

            return null;
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password)
        {
            if (await _userRepository.EmailExistsAsync(email))
            {
                return (false, "Email này đã được sử dụng.");
            }

            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            var newUser = new User
            {
                UserId = Guid.NewGuid().ToString(),
                Email = email,
                FullName = fullName,
                PasswordHash = hashedPassword,
                Role = "User",
                IsActive = true,
                CreatedAt = DateTime.Now
            };

            await _userRepository.AddUserAsync(newUser);
            return (true, null);
        }

        //  Đăng nhập bằng Google
        public async Task<User> LoginWithGoogleAsync(string email, string fullName)
        {
            // Kiểm tra user đã tồn tại chưa
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user != null)
            {
                // User đã tồn tại -> Đăng nhập
                user.LastLogin = DateTime.Now;
                await _userRepository.UpdateUserAsync(user);
                return user;
            }
            else
            {
                // User chưa tồn tại -> Tự động tạo tài khoản mới
                var newUser = new User
                {
                    UserId = Guid.NewGuid().ToString(),
                    Email = email,
                    FullName = fullName,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(Guid.NewGuid().ToString()), // Password ngẫu nhiên
                    Role = "User",
                    IsActive = true,
                    CreatedAt = DateTime.Now,
                    LastLogin = DateTime.Now
                };

                await _userRepository.AddUserAsync(newUser);
                return newUser;
            }
        }
    }
}