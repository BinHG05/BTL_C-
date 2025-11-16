using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Windows.Forms;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Views;
using ExpenseManager.App.Views.Admin.Sidebar;


// Thêm using cho LayoutAdmin (nếu cần)
// using ExpenseManager.App.Views.Admin; 

namespace ExpenseManager.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            // *** SỬA LỖI LAYOUT Ở ĐÂY ***
            // Sử dụng hàm Initialize() gốc của bạn
            ApplicationConfiguration.Initialize();
            // Application.EnableVisualStyles(); // (Không dùng)
            // Application.SetCompatibleTextRenderingDefault(false); // (Không dùng)


            // 1. Lấy connection string từ App.config (Theo code của bạn)
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'ExpenseDB' trong App.config", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // 2. Khởi tạo DbContextOptions (Theo code của bạn)
            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // 3. Quản lý vòng đời DbContext và khởi chạy MVP
            // 'using' đảm bảo DbContext được giải phóng khi app đóng
            using (var dbContext = new ExpenseDbContext(options))
            {
                try
                {




                    Application.Run(new LayoutUser());

                }
                catch (Exception ex)
                {
                    // Bắt lỗi nếu không kết nối được CSDL khi khởi động
                    MessageBox.Show($"Lỗi khởi động ứng dụng: {ex.Message}", "Lỗi nghiêm trọng", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}