using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        // Inject IUserRepository vào
        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            // 1. Lấy user từ Repo
            var user = await _userRepository.GetUserByEmailAsync(email);

            // 2. Kiểm tra user có tồn tại không
            if (user == null || !user.IsActive)
            {
                return null; // Không tìm thấy hoặc tài khoản bị khóa
            }

            // 3. Xác thực mật khẩu
            // Dùng BCrypt để so sánh mật khẩu trần (password) với mật khẩu đã hash (user.PasswordHash)
            bool isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

            if (isPasswordValid)
            {
                // Cập nhật lần đăng nhập cuối
                user.LastLogin = DateTime.Now;
                await _userRepository.UpdateUserAsync(user);

                return user; // Đăng nhập thành công, trả về user
            }

            return null; // Sai mật khẩu
        }

        public async Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password)
        {
            // 1. Kiểm tra Email đã tồn tại chưa
            if (await _userRepository.EmailExistsAsync(email))
            {
                return (false, "Email này đã được sử dụng.");
            }

            // 2. Hash mật khẩu (dùng BCrypt)
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);

            // 3. Tạo User mới (dựa trên Entity User.cs của bạn)
            var newUser = new User
            {
                UserId = Guid.NewGuid().ToString(), // Tạo UserID ngẫu nhiên
                Email = email,
                FullName = fullName,
                PasswordHash = hashedPassword,
                Role = "User", // Mặc định là User
                IsActive = true,
                CreatedAt = DateTime.Now
                // Các trường khác có thể để null
            };

            // 4. Lưu vào CSDL
            await _userRepository.AddUserAsync(newUser);
            return (true, null); // Đăng ký thành công
        }
    }
}