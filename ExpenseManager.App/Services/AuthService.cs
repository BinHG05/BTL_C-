using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using System;
using System.Collections.Generic;
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
        private readonly ICategoryRepository _categoryRepository;

        public AuthService(IUserRepository userRepository, ICategoryRepository categoryRepository)
        {
            _userRepository = userRepository;
            _categoryRepository = categoryRepository; 
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

            // ✅ BƯỚC MỚI: TẠO CÁC DANH MỤC MẶC ĐỊNH
            await CreateDefaultCategoriesAsync(newUser.UserId);

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

                // ✅ BƯỚC MỚI: TẠO CÁC DANH MỤC MẶC ĐỊNH
                await CreateDefaultCategoriesAsync(newUser.UserId);

                return newUser;
            }
        }
        private async Task CreateDefaultCategoriesAsync(string userId)
        {
            var defaultCategories = new List<Category>
            {
                // 3 Chi tiêu (Expense)
                new Category {
                    UserId = userId,
                    CategoryName = "Ăn uống",
                    Type = "Expense",
                    CreatedAt = DateTime.Now,
                    ColorId = 1,
                    IconId = 1 
                },
                new Category {
                    UserId = userId,
                    CategoryName = "Di chuyển",
                    Type = "Expense",
                    CreatedAt = DateTime.Now,
                    ColorId = 2,
                    IconId = 2
                },
                new Category {
                    UserId = userId,
                    CategoryName = "Xăng xe",
                    Type = "Expense",
                    CreatedAt = DateTime.Now,
                    ColorId = 3,
                    IconId = 3 
                },
                
                // 3 Thu nhập (Income)
                new Category {
                    UserId = userId,
                    CategoryName = "Lương",
                    Type = "Income",
                    CreatedAt = DateTime.Now,
                    ColorId = 4, 
                    IconId = 20 
                },
                new Category {
                    UserId = userId,
                    CategoryName = "Kinh doanh",
                    Type = "Income",
                    CreatedAt = DateTime.Now,
                    ColorId = 5, 
                    IconId = 21 
                },
                new Category {
                    UserId = userId,
                    CategoryName = "Đầu tư",
                    Type = "Income",
                    CreatedAt = DateTime.Now,
                    ColorId = 6, 
                    IconId = 22 
                }
            };

            foreach (var category in defaultCategories)
            {
                await _categoryRepository.AddCategoryAsync(category);
            }
        }
    }
}