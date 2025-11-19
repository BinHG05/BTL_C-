using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views;
using ExpenseManager.App.Views.Admin.Sidebar;
using ExpenseManager.App.Views.User.Forms;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Configuration;
using System.Windows.Forms;

namespace ExpenseManager.App
{
    internal static class Program
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'ExpenseDB' trong App.config", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var services = new ServiceCollection();
            ConfigureServices(services, connectionString);
            ServiceProvider = services.BuildServiceProvider();

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

        private static void ConfigureServices(IServiceCollection services, string connectionString)
        {
            // 1. DB Context
            services.AddDbContext<ExpenseDbContext>(options =>
                options.UseSqlServer(connectionString)
            );

            // 2. Repositories (Đăng ký đủ User, Wallet, Category, Icon, Color, Transaction)
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped<IWalletRepository, WalletRepository>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();

            // --- CÁC DÒNG BẠN ĐANG THIẾU ---
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IIconRepository, IconRepository>();
            services.AddScoped<IColorRepository, ColorRepository>();
            // -------------------------------

            // 3. Services (Đăng ký đủ Auth, Wallet, Category, Transaction)
            services.AddTransient<IAuthService, AuthService>();
            services.AddTransient<IGoogleAuthService, GoogleAuthService>();

            // --- CÁC DÒNG BẠN ĐANG THIẾU ---
            services.AddScoped<IWalletService, WalletService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITransactionService, TransactionService>();
            // -------------------------------

            // 4. Presenters
            services.AddTransient<LoginPresenter>();
            services.AddTransient<RegisterPresenter>();
            services.AddTransient<ForgotPasswordPresenter>();

            // 5. Forms
            services.AddTransient<LoginForm>();
            services.AddTransient<RegisterForm>();
            services.AddTransient<ForgotPasswordForm>();
            services.AddTransient<LayoutUser>();
            services.AddTransient<LayoutAdmin>();

            // Form thêm giao dịch
            services.AddTransient<AddTransactionForm>();
        }
    }
}