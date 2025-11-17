using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;

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
        private Color hoverColor = Color.FromArgb(20, 60, 100);

        public LayoutAdmin()
        {
            InitializeComponent();
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

            // Highlight selected button with active color
            selectedButton.BackColor = activeColor;
            selectedButton.ForeColor = Color.White;
            selectedButton.IconColor = Color.White;
        }

        // Button Click Events
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            // TODO: Load Dashboard content here
        }

        private void BtnUsers_Click(object sender, EventArgs e)
        {
            ActivateButton(btnUsers);
            // TODO: Load Users content here
        }

        private void BtnCategory_Click(object sender, EventArgs e)
        {
            ActivateButton(btnCategory);
            // TODO: Load Category content here
        }

        private void BtnSupport_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSupport);
            // TODO: Load Support/Ticket content here
            LoadContent(new UC.UC_TicketAD());
        }

        private void ProfilePanel_Click(object sender, EventArgs e)
        {
            // Show context menu at cursor position
            profileMenu.Show(Cursor.Position);
        }

        private void BtnProfileAvatar_Click(object sender, EventArgs e)
        {
            // Show context menu at cursor position
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
                // TODO: Add logout logic here
                // For example: Navigate to Login form
                // this.Hide();
                // LoginForm loginForm = new LoginForm();
                // loginForm.ShowDialog();
                // this.Close();

                MessageBox.Show("Đăng xuất thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            // Activate Dashboard by default
            ActivateButton(btnDashboard);
        }
        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
        }
    }
}