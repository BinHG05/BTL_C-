using ExpenseManager.App.Models.Entities;
using System.Diagnostics;

namespace ExpenseManager.App.Session
{
    public static class CurrentUserSession
    {
        private static User _currentUser;

        public static User CurrentUser
        {
            get
            {
                var caller = new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod()?.Name ?? "Unknown";
                Debug.WriteLine($"[Session] GET CurrentUser from {caller}: {_currentUser?.UserId ?? "NULL"}");
                return _currentUser;
            }
            private set
            {
                var caller = new System.Diagnostics.StackTrace().GetFrame(1)?.GetMethod()?.Name ?? "Unknown";
                Debug.WriteLine($"[Session] SET CurrentUser from {caller}: OLD={_currentUser?.UserId ?? "NULL"}, NEW={value?.UserId ?? "NULL"}");
                _currentUser = value;
            }
        }

        public static void SetUser(User user)
        {
            Debug.WriteLine("========================================");
            Debug.WriteLine($"[Session] SetUser CALLED");
            Debug.WriteLine($"[Session] Input User: {user?.UserId ?? "NULL"}");
            Debug.WriteLine($"[Session] Input Email: {user?.Email ?? "NULL"}");
            Debug.WriteLine($"[Session] Input FullName: {user?.FullName ?? "NULL"}");
            Debug.WriteLine($"[Session] Stack Trace: {new System.Diagnostics.StackTrace()}");

            CurrentUser = user;

            Debug.WriteLine($"[Session] After SET - CurrentUser: {CurrentUser?.UserId ?? "NULL"}");

            if (CurrentUser == null)
            {
                Debug.WriteLine("[Session] WARNING: CurrentUser is STILL NULL after SetUser!");
            }
            else
            {
                Debug.WriteLine($"[Session] SUCCESS: CurrentUser = {CurrentUser.UserId}");
            }
            Debug.WriteLine("========================================");
        }

        public static void ClearUser()
        {
            Debug.WriteLine($"[Session] CLEAR User - Was: {_currentUser?.UserId ?? "NULL"}");
            Debug.WriteLine($"[Session] Stack Trace: {new System.Diagnostics.StackTrace()}");
            CurrentUser = null;
        }
    }
}