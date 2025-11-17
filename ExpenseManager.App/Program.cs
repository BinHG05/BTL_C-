using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Views;
using ExpenseManager.App.Views.Admin.Sidebar; // LayoutUser
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; // Thư viện DI quan trọng
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ExpenseManager.App
{
    internal static class Program
    {
        // 1. Tạo một ServiceProvider toàn cục
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            // Giữ lại hàm Initialize() gốc của bạn
            ApplicationConfiguration.Initialize();

            // Lấy connection string từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'ExpenseDB' trong App.config", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Tạo một bộ sưu tập dịch vụ
            var services = new ServiceCollection();

            // 3. Gọi hàm để đăng ký các dịch vụ
            ConfigureServices(services, connectionString);

            // 4. Xây dựng ServiceProvider
            ServiceProvider = services.BuildServiceProvider();

            // 5. Khởi chạy ứng dụng
            try
            {
                var loginForm = ServiceProvider.GetRequiredService<LoginForm>();
                Application.Run(loginForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}\n{ex.StackTrace}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // 6. Đây là hàm đăng ký DI (Dependency Injection)
        private static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            // 6.1. Đăng ký DbContext
            
            services.AddDbContext<ExpenseDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // 6.2. Đăng ký Repositories
       
            services.AddTransient<IUserRepository, UserRepository>();
         

            // 6.3. Đăng ký Services
           
            services.AddTransient<IAuthService, AuthService>();
 

            // 6.4. Đăng ký Presenters
            
            services.AddTransient<LoginPresenter>();
            services.AddTransient<RegisterPresenter>();
            services.AddTransient<ForgotPasswordPresenter>();
    

            // 6.5. Đăng ký Forms/Views
            // Quan trọng: Đăng ký các Form để chúng có thể nhận Presenter
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<LayoutUser>();
            services.AddTransient<LayoutAdmin>();
            // 6.6. Đăng ký Google Auth Service
            services.AddTransient<IGoogleAuthService, GoogleAuthService>();
       
        }
    }
}