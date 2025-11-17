using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    //public interface IAuthService
    //{
    //    Task<User> LoginAsync(string email, string password);
    //    Task<(bool Success, string ErrorMessage)> RegisterAsync(string fullName, string email, string password);
    //    Task<User> LoginWithGoogleAsync(string email, string fullName); // ✅ THÊM
    //}

    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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

        // ✅ THÊM METHOD MỚI: Đăng nhập bằng Google
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