using ExpenseManager.App.Views.Admin.Sidebar;
using System;
using System.Windows.Forms;

namespace ExpenseManager.App
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            //Application.Run(new Layout());
            Application.Run(new LayoutAdmin());

        }
    }
}
