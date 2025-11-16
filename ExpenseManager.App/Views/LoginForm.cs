using ExpenseManager.App.Presenters;
using ExpenseManager.App.Views.Admin.Sidebar;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class LoginForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        private readonly LoginPresenter _presenter;

        public LoginForm(LoginPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;

            this.lblError.Text = string.Empty;
            pnlUsernameLine.BackColor = blurColor;
            pnlPasswordLine.BackColor = blurColor;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            int panelX = (this.ClientSize.Width - pnlLoginForm.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlLoginForm.Height) / 2;
            pnlLoginForm.Location = new Point(panelX, panelY);
            txtUsername.Focus();
        }

        // *** SỬA LẠI HÀM NÀY ***
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ Email và Mật khẩu.");
                return;
            }

            // Gọi Presenter và nhận về cả Success và User
            var (loginSuccess, user) = await _presenter.LoginAsync(email, password);

            if (loginSuccess && user != null)
            {
                // *** PHÂN QUYỀN DỰA TRÊN ROLE ***
                if (user.Role == "Admin")
                {
                    // Hiển thị thông báo tạm thời cho Admin
                    MessageBox.Show(
                        "Chào mừng Admin!\n\nGiao diện quản trị đang được phát triển.",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );

                    // Tạm thời không chuyển form, giữ nguyên màn hình login
                    // Hoặc bạn có thể tạo một AdminPlaceholderForm đơn giản

                    // Option 1: Không làm gì, giữ ở màn hình login
                    // (Bỏ comment dòng dưới nếu muốn đăng xuất ngay)
                    // CurrentUserSession.ClearUser();

                    // Option 2: Mở form placeholder cho Admin
                    // var adminForm = Program.ServiceProvider.GetRequiredService<AdminPlaceholderForm>();
                    // adminForm.Show();
                    // this.Hide();
                }
                else if (user.Role == "User")
                {
                    // Chuyển đến giao diện User bình thường
                    var layoutUser = Program.ServiceProvider.GetRequiredService<LayoutUser>();
                    layoutUser.Show();
                    this.Hide();
                }
                else
                {
                    // Role không hợp lệ
                    ShowErrorMessage("Tài khoản không có quyền truy cập hợp lệ.");
                }
            }
            else
            {
                ShowErrorMessage("Email hoặc mật khẩu không đúng.");
            }
        }

        // --- Các hàm khác giữ nguyên ---
        private void txtUsername_Enter(object sender, EventArgs e)
        {
            pnlUsernameLine.BackColor = focusColor;
        }

        private void txtUsername_Leave(object sender, EventArgs e)
        {
            pnlUsernameLine.BackColor = blurColor;
        }

        private void txtPassword_Enter(object sender, EventArgs e)
        {
            pnlPasswordLine.BackColor = focusColor;
        }

        private void txtPassword_Leave(object sender, EventArgs e)
        {
            pnlPasswordLine.BackColor = blurColor;
        }

        private void btnShowHidePassword_Click(object sender, EventArgs e)
        {
            if (txtPassword.PasswordChar == '•')
            {
                txtPassword.PasswordChar = '\0';
                btnShowHidePassword.Text = "🔒";
            }
            else
            {
                txtPassword.PasswordChar = '•';
                btnShowHidePassword.Text = "👁️";
            }
        }

        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var forgotForm = Program.ServiceProvider.GetRequiredService<ForgotPasswordForm>();
            forgotForm.Show();
            this.Hide();
        }

        private void btnGoogleLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Đăng nhập bằng Google đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var registerForm = Program.ServiceProvider.GetRequiredService<RegisterForm>();
            registerForm.Show();
            this.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }
    }
}