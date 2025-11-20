using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManager.App.Presenters; 
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.User.UC;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Budget : UserControl
    {
        public UC_Budget()
        {
            InitializeComponent();
        }

        private void UC_Budget_Load(object sender, EventArgs e)
        {
            // Căn chỉnh lại nội dung bên phải (giống như UC_Wallet)
            // Lấy khoảng trống bên trái (30) + độ rộng sidebar (350) + khoảng đệm (30)
            int leftOffset = pnlLeftSidebar.Left + pnlLeftSidebar.Width + 30;

            // Lấy độ rộng của toàn bộ User Control
            int totalWidth = this.Width;

            // Tính độ rộng còn lại cho pnlMainContent
            int mainContentWidth = totalWidth - leftOffset - pnlLeftSidebar.Left; // 1600 - 410 - 30 = 1160

            // Cập nhật vị trí và kích thước
            pnlMainContent.Location = new Point(leftOffset, pnlLeftSidebar.Top);
            pnlMainContent.Size = new Size(mainContentWidth, this.Height - pnlHeader.Height - 60); // 60 là padding dưới

            // Căn chỉnh lại kích thước của các panel con bên trong pnlMainContent
            pnlBudgetHeader.Width = mainContentWidth - 40; // Trừ padding
            pnlBudgetOverview.Width = mainContentWidth - 40;
            pnlBudgetStats.Width = mainContentWidth - 40;
            pnlBudgetChart.Width = mainContentWidth - 40;

            // Thiết lập giá trị mặc định cho ComboBox và DateTimePicker
            cmbChartType.SelectedIndex = 0;
            dtpChartFrom.Value = new DateTime(2025, 11, 10);
            dtpChartTo.Value = new DateTime(2025, 12, 10);
        }
    }
}