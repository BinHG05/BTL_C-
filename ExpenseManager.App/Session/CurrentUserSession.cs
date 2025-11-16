using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Session
{
    // Lớp static này sẽ giữ thông tin User sau khi đăng nhập thành công
    public static class CurrentUserSession
    {
        public static User CurrentUser { get; private set; }

        public static void SetUser(User user)
        {
            CurrentUser = user;
        }

        public static void ClearUser()
        {
            CurrentUser = null;
        }
    }
}