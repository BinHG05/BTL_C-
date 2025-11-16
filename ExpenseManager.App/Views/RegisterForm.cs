using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class RegisterForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        public RegisterForm()
        {
            InitializeComponent();

            this.lblError.Text = string.Empty;
            // Set màu mặc định cho cả 3 gạch chân
            pnlFullNameLine.BackColor = blurColor;
            pnlUsernameLine.BackColor = blurColor;
            pnlPasswordLine.BackColor = blurColor;
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel đăng ký
            int panelX = (this.ClientSize.Width - pnlRegisterForm.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlRegisterForm.Height) / 2;
            pnlRegisterForm.Location = new Point(panelX, panelY);

            txtFullName.Focus(); // Focus vào ô Họ và Tên đầu tiên
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // --- Tạm thời ---
            MessageBox.Show("Đăng ký thành công! (Chưa có logic)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        // --- Xử lý Focus gạch chân cho 3 ô ---
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

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Xử lý khi người dùng nhấn "Đăng nhập"

            // 1. Tạo một instance mới của LoginForm
            LoginForm loginForm = new LoginForm();

            // 2. Hiển thị LoginForm
            loginForm.Show();

            // 3. Ẩn (thay vì đóng) Form đăng ký hiện tại
            this.Hide();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }
    }
}