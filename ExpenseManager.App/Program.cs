using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Windows.Forms;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App
{
    internal static class Program
    {
        // *** ĐÂY LÀ PHIÊN BẢN ĐÚNG ***
        // Khai báo DbContext ở đây để nó "sống" (static)
        public static ExpenseDbContext AppDbContext { get; private set; }

        [STAThread]
        static void Main()
        {
            // Sử dụng hàm Initialize() gốc của bạn
            ApplicationConfiguration.Initialize();

            // 1. Lấy connection string
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'ExpenseDB' trong App.config", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Khởi tạo DbContextOptions
            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // 3. Khởi tạo DbContext TĨNH
            AppDbContext = new ExpenseDbContext(options);

            try
            {
                // 4. Tạo Repository (Sử dụng DbContext tĩnh)
                var userRepository = new UserRepository(AppDbContext);

                // 5. Tạo Service (Tiêm Repository)
                var userService = new UserService(userRepository);

                // 6. Tạo View (LoginForm)
                var loginForm = new LoginForm();

                // 7. Tạo Presenter (Tiêm View và Service)
                var loginPresenter = new LoginPresenter(loginForm, userService);

                // 8. Gán Presenter cho View
                loginForm.SetPresenter(loginPresenter);

                // 9. Chạy LoginForm
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                // 10. Dọn dẹp DbContext khi ứng dụng đóng
                AppDbContext?.Dispose();
            }
        }
    }
}