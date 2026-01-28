using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Session; 
using ExpenseManager.App.Views.Admin.UC;
using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection; 
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

        private readonly ExpenseDbContext _dbContext = new ExpenseDbContext();

        public LayoutAdmin()
        {
            InitializeComponent();

            LoadContent(new UC_DashboardAD());
            ActivateButton(btnDashboard);
            DisplayNameAdmin();


            if (CurrentUserSession.CurrentUser != null)
            {
                lblAdminName.Text = CurrentUserSession.CurrentUser.FullName;
             
            }
        
        }
        private void DisplayNameAdmin()
        {
            string userName = "Admin";

            var currentUser = CurrentUserSession.CurrentUser;

            if (currentUser != null)
            {
                if (!string.IsNullOrEmpty(currentUser.FullName))
                {
                    userName = currentUser.FullName;
                }
                else if (!string.IsNullOrEmpty(currentUser.FullName))
                {
                    userName = currentUser.FullName;
                }
            }

            lblAdminName.Text = $"Welcome back, {userName} !";
        }
        private void ActivateButton(IconButton selectedButton)
        {
            if (selectedButton == currentButton)
                return;

            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = Color.White;
                currentButton.IconColor = Color.White;
            }

            currentButton = selectedButton;

            selectedButton.BackColor = activeColor;
            selectedButton.ForeColor = Color.White;
            selectedButton.IconColor = Color.White;
        }

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
            LoadContent(new UC_CategoryAD());
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
                CurrentUserSession.ClearUser();

                var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();

                this.Close();
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
        }

        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);

            try
            {
                if (uc is UC_DashboardAD dashboardUc)
                {
                    dashboardUc.InitializePresenter(_dbContext);
                }
                else if (uc is UC_UserAD userUc)
                {
                    userUc.InitializePresenter(_dbContext);
                }
                else if (uc is UC_CategoryAD categoryUc)
                {
                    categoryUc.InitializePresenter(_dbContext);
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