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
                // Lấy LoginForm từ DI container (thay vì new LayoutUser())
                // Điều này đảm bảo LoginForm sẽ nhận được Presenter của nó
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
            // Nó sẽ tự động quản lý vòng đời của DbContext
            services.AddDbContext<ExpenseDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // 6.2. Đăng ký Repositories
            // Khi ai đó "hỏi" IUserRepository, DI sẽ "tiêm" vào một UserRepository
            services.AddTransient<IUserRepository, UserRepository>();
            // ... (Thêm các Repositories khác của bạn ở đây)
            // services.AddTransient<IWalletRepository, WalletRepository>();
            // services.AddTransient<ITransactionRepository, TransactionRepository>();

            // 6.3. Đăng ký Services
            // Khi ai đó "hỏi" IAuthService, DI sẽ "tiêm" vào một AuthService
            services.AddTransient<IAuthService, AuthService>();
            // ... (Thêm các Services khác của bạn ở đây)
            // services.AddTransient<IWalletService, WalletService>();

            // 6.4. Đăng ký Presenters
            // (Đăng ký thẳng class, không cần interface nếu bạn không dùng)
            services.AddTransient<LoginPresenter>();
            services.AddTransient<RegisterPresenter>();
            services.AddTransient<ForgotPasswordPresenter>();
            // ... (Thêm các Presenters khác của bạn ở đây)
            // services.AddTransient<WalletPresenter>();

            // 6.5. Đăng ký Forms/Views
            // Quan trọng: Đăng ký các Form để chúng có thể nhận Presenter
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<LayoutUser>();
            // ... (Thêm các Form/UC khác của bạn ở đây)
            // services.AddTransient<UC_Wallet>();
        }
    }
}