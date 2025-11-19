using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Views.Admin.UC;
using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Sidebar
{
    public partial class LayoutAdmin : Form
    {
        private IconButton currentButton;
        private Color sidebarColor = Color.FromArgb(1, 31, 65);
        private Color activeColor = Color.FromArgb(41, 128, 185);
        private Color defaultBg = Color.Transparent;
        private Color logoutDefaultColor = Color.FromArgb(220, 53, 69);
        private Color logoutHoverColor = Color.FromArgb(200, 35, 51);

        // KHAI BÁO KIỂU CỤ THỂ ExpenseDbContext
        private readonly ExpenseDbContext _dbContext = new ExpenseDbContext();

        public LayoutAdmin()
        {
            InitializeComponent();
            LoadContent(new UC_DashboardAD());
            ActivateButton(btnDashboard);
        }

        private void ActivateButton(IconButton selectedButton)
        {
            if (selectedButton == currentButton)
                return;

            // Reset previous button
            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = Color.White;
                currentButton.IconColor = Color.White;
            }

            // Set current button
            currentButton = selectedButton;

            // Highlight selected button
            selectedButton.BackColor = activeColor;
            selectedButton.ForeColor = Color.White;
            selectedButton.IconColor = Color.White;
        }

        // Button Click Events
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadContent(new UC_DashboardAD());
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(btnUsers);
            LoadContent(new UC_UserAD());
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCategory);
            // TODO: Load Category content
            MessageBox.Show("Category management coming soon!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSupport_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSupport);
            LoadContent(new UC_TicketAD());
        }

        private void BtnProfileAvatar_Click(object sender, EventArgs e)
        {
            profileMenu.Show(Cursor.Position);
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // TODO: Navigate to login form
            }
        }

        private void BtnLogout_MouseEnter(object sender, EventArgs e)
        {
            btnLogout.BackColor = logoutHoverColor;
        }

        private void BtnLogout_MouseLeave(object sender, EventArgs e)
        {
            btnLogout.BackColor = logoutDefaultColor;
        }

        private void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            BtnLogout_Click(sender, e);
        }

        private void LayoutAdmin_Load(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
        }

        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);

            try
            {
                // Initialize presenters based on UserControl type
                if (uc is UC_DashboardAD dashboardUc)
                {
                    // Truyền ExpenseDbContext
                    dashboardUc.InitializePresenter(_dbContext);
                }
                else if (uc is UC_UserAD userUc)
                {
                    // ĐÃ SỬA LỖI CS1503: Truyền ExpenseDbContext
                    userUc.InitializePresenter(_dbContext);
                }
                else if (uc is UC_TicketAD ticketUc)
                {
                    // ticketUc.InitializePresenter(_dbContext);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi tạo: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }
    }
}