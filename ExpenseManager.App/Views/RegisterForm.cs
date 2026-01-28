using ExpenseManager.App.Presenters;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.Admin.Sidebar;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class RegisterForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        private readonly RegisterPresenter _presenter;

        public RegisterForm(RegisterPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;

            this.lblError.Text = string.Empty;
            pnlFullNameLine.BackColor = blurColor;
            pnlUsernameLine.BackColor = blurColor;
            pnlPasswordLine.BackColor = blurColor;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            int panelX = (this.ClientSize.Width - pnlRegisterForm.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlRegisterForm.Height) / 2;
            pnlRegisterForm.Location = new Point(panelX, panelY);
            txtFullName.Focus();
        }

        // Đăng ký bình thường
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtUsername.Text;
            string password = txtPassword.Text;

            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // 1. Kiểm tra định dạng email
            if (!IsValidEmail(email))
            {
                ShowErrorMessage("Email không đúng định dạng.");
                return;
            }

            // 2. Kiểm tra độ dài mật khẩu (ít nhất 6 ký tự)
            if (password.Length < 6)
            {
                ShowErrorMessage("Mật khẩu phải có ít nhất 6 ký tự.");
                return;
            }

            var (success, errorMessage) = await _presenter.RegisterAsync(fullName, email, password);

            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lnkLogin_LinkClicked(sender, null);
            }
            else
            {
                ShowErrorMessage(errorMessage);
            }
        }

        // THÊM - Phương thức kiểm tra định dạng email
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        // Đăng ký bằng Google
        private async void btnGoogleRegister_Click(object sender, EventArgs e)
        {
            bool shouldNavigate = false; // Flag để check có chuyển trang không

            try
            {
                btnGoogleRegister.Enabled = false;
                lblError.Text = string.Empty;

                // Gọi Presenter
                var (success, errorMessage) = await _presenter.RegisterWithGoogleAsync();

                if (success)
                {
                    // Đăng ký thành công -> Vào luôn giao diện
                    var user = CurrentUserSession.CurrentUser;

                    if (user != null)
                    {
                        shouldNavigate = true; // Đánh dấu sẽ chuyển trang

                        if (user.Role == "Admin")
                        {
                            var layoutAdmin = Program.ServiceProvider.GetRequiredService<LayoutAdmin>();
                            layoutAdmin.Show();
                            this.Hide();
                        }
                        else if (user.Role == "User")
                        {
                            var layoutUser = Program.ServiceProvider.GetRequiredService<LayoutUser>();
                            layoutUser.Show();
                            this.Hide();
                        }
                    }
                    else
                    {
                        ShowErrorMessage("Không thể lấy thông tin tài khoản.");
                    }
                }
                else
                {
                    // Thất bại (bao gồm cả khi user hủy)
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        ShowErrorMessage(errorMessage);
                    }
                    else
                    {
                        ShowErrorMessage("Đăng ký Google thất bại.");
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage($"Lỗi: {ex.Message}");
            }
            finally
            {
                // QUAN TRỌNG: CHỈ ENABLE LẠI NẾU KHÔNG CHUYỂN TRANG
                if (!shouldNavigate)
                {
                    btnGoogleRegister.Enabled = true;
                }
            }
        }

        private void txtFullName_Enter(object sender, EventArgs e)
        {
            pnlFullNameLine.BackColor = focusColor;
        }

        private void txtFullName_Leave(object sender, EventArgs e)
        {
            pnlFullNameLine.BackColor = blurColor;
        }

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

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }
    }
}