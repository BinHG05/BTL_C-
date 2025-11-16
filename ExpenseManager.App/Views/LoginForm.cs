using System;
using System.Drawing;
using System.Windows.Forms;
// using ExpenseManager.App.Presenters; 

namespace ExpenseManager.App.Views
{
    public partial class LoginForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        public LoginForm()
        {
            InitializeComponent();
            this.lblError.Text = string.Empty;
            pnlUsernameLine.BackColor = blurColor;
            pnlPasswordLine.BackColor = blurColor;
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel login chính
            int panelX = (this.ClientSize.Width - pnlLoginForm.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlLoginForm.Height) / 2;
            pnlLoginForm.Location = new Point(panelX, panelY);

            txtUsername.Focus();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ Tên đăng nhập và Mật khẩu.");
                return;
            }

            if (username == "admin" && password == "123456")
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowErrorMessage("Tên đăng nhập hoặc mật khẩu không đúng.");
            }
        }

        // --- Xử lý Focus gạch chân ---
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

        // --- Các hàm xử lý sự kiện khác ---
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

        // *** ĐÃ SỬA LỖI CÚ PHÁP TẠI ĐÂY ***
        private void lnkForgotPassword_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Mở Form Quên Mật Khẩu
            ForgotPasswordForm forgotForm = new ForgotPasswordForm();
            forgotForm.Show();
            this.Hide(); // Ẩn Form đăng nhập
        }

        private void btnGoogleLogin_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Chức năng Đăng nhập bằng Google đang được phát triển!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // *** ĐÃ SỬA LỖI CÚ PHÁP TẠI ĐÂY ***
        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Xử lý khi người dùng nhấn "Đăng ký"

            // 1. Tạo một instance mới của RegisterForm
            RegisterForm registerForm = new RegisterForm();

            // 2. Hiển thị RegisterForm
            registerForm.Show();

            // 3. Ẩn (thay vì đóng) Form đăng nhập hiện tại
            this.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }
    }
}