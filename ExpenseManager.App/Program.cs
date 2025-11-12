using ExpenseManager.App.Views.Admin.Sidebar;
using ExpenseManager.App.Models.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            // Lấy connection string từ App.config
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;

            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Không tìm thấy connection string 'ExpenseDB' trong App.config", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Khởi tạo DbContextOptions
            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            // Chạy form chính của bạn
            Application.Run(new LayoutAdmin());
        }
    }
}
