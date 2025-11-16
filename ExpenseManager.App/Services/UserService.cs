using ExpenseManager.App.Helpers;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public class UserService : IUserService
    {
        // Service này phụ thuộc vào Repository, không phụ thuộc vào DbContext
        private readonly IUserRepository _userRepository;

        // Tiêm IUserRepository qua constructor
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> CheckEmailExistsAsync(string email)
        {
            // Ủy quyền cho repository
            return await _userRepository.CheckEmailExistsAsync(email);
        }

        public async Task<User> LoginAsync(string email, string password)
        {
            // 1. Lấy user từ repository
            var user = await _userRepository.GetUserByEmailAsync(email);

            if (user == null)
            {
                return null; // Không tìm thấy user
            }

            // 2. Kiểm tra mật khẩu (Đây là Business Logic - thuộc về Service)
            // Sử dụng helper đã tạo
            if (!PasswordHelper.VerifyPassword(password, user.PasswordHash))
            {
                return null; // Sai mật khẩu
            }

            // 3. Cập nhật LastLogin và lưu (Business Logic)
            user.LastLogin = DateTime.UtcNow;
            await _userRepository.UpdateUserAsync(user);

            return user; // Đăng nhập thành công
        }

        public async Task<User> RegisterAsync(string fullName, string email, string password)
        {
            // 1. Kiểm tra email (Business Logic)
            if (await CheckEmailExistsAsync(email))
            {
                throw new Exception("Email already exists.");
            }

            // 2. Băm mật khẩu (Business Logic)
            string hashedPassword = PasswordHelper.HashPassword(password);

            // 3. Tạo User mới
            var newUser = new User
            {
                UserId = Guid.NewGuid().ToString(),
                FullName = fullName,
                Email = email,
                PasswordHash = hashedPassword,
                Role = "User", // Gán vai trò mặc định
                IsActive = true,
                CreatedAt = DateTime.UtcNow
                // Các trường khác có thể là nullable hoặc có giá trị mặc định
            };

            // 4. Lưu vào DB thông qua repository
            return await _userRepository.AddUserAsync(newUser);
        }
    }
}