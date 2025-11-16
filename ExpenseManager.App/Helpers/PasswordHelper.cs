using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace ExpenseManager.App.Helpers
{
    public static class PasswordHelper
    {
        // Băm mật khẩu khi đăng ký
        public static string HashPassword(string password)
        {
            // Băm mật khẩu với một "work factor" (độ phức tạp), 12 là đủ mạnh
            return BCrypt.Net.BCrypt.HashPassword(password, 12);
        }

        // Kiểm tra mật khẩu khi đăng nhập
        public static bool VerifyPassword(string enteredPassword, string storedHash)
        {
            try
            {
                // BCrypt sẽ so sánh mật khẩu người dùng nhập với chuỗi hash trong DB
                return BCrypt.Net.BCrypt.Verify(enteredPassword, storedHash);
            }
            catch
            {
                // Lỗi nếu chuỗi hash không hợp lệ
                return false;
            }
        }
    }
}
