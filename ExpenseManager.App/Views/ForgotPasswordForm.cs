using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class ForgotPasswordForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        public ForgotPasswordForm()
        {
            InitializeComponent();

            this.lblError.Text = string.Empty;
            // Set màu mặc định
            pnlEmailLine.BackColor = blurColor;
            pnlCodeLine.BackColor = blurColor;
            pnlNewPasswordLine.BackColor = blurColor;
            pnlConfirmPasswordLine.BackColor = blurColor;
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel chính
            int panelX = (this.ClientSize.Width - pnlForgotPassword.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlForgotPassword.Height) / 2;
            pnlForgotPassword.Location = new Point(panelX, panelY);

            txtEmail.Focus(); // Focus vào ô Email
        }

        // --- Xử lý sự kiện cho Bước 1 ---
        private void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            if (string.IsNullOrEmpty(txtEmail.Text) || !txtEmail.Text.Contains("@"))
            {
                ShowErrorMessage("Vui lòng nhập một email hợp lệ.");
                return;
            }

            // --- GIẢ LẬP: Gửi mã thành công ---
            // Đổi Tiêu đề
            lblTitle.Text = "ĐẶT LẠI MẬT KHẨU";
            lblTitle.Location = new Point(15, 40); // Căn lại (420 - 390) / 2 = 15
            lblTitle.Size = new System.Drawing.Size(390, 54); // Điều chỉnh kích thước

            // Ẩn/Hiện Panel
            pnlStep1.Visible = false;
            pnlStep2.Visible = true;
            txtCode.Focus();
        }

        // --- Xử lý sự kiện cho Bước 2 ---
        private void btnResetPassword_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtNewPassword.Text) || string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // Kiểm tra mật khẩu khớp
            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowErrorMessage("Mật khẩu mới không khớp. Vui lòng nhập lại.");
                return;
            }

            // --- GIẢ LẬP: Đổi mật khẩu thành công ---
            MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Quay về trang Đăng nhập
            GoBackToLogin();
        }

        // --- Các hàm xử lý sự kiện chung ---
        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoBackToLogin();
        }

        private void GoBackToLogin()
        {
            // Mở lại LoginForm
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide(); // Ẩn form hiện tại
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }

        // --- Xử lý Focus gạch chân ---
        private void txtEmail_Enter(object sender, EventArgs e) { pnlEmailLine.BackColor = focusColor; }
        private void txtEmail_Leave(object sender, EventArgs e) { pnlEmailLine.BackColor = blurColor; }
        private void txtCode_Enter(object sender, EventArgs e) { pnlCodeLine.BackColor = focusColor; }
        private void txtCode_Leave(object sender, EventArgs e) { pnlCodeLine.BackColor = blurColor; }
        private void txtNewPassword_Enter(object sender, EventArgs e) { pnlNewPasswordLine.BackColor = focusColor; }
        private void txtNewPassword_Leave(object sender, EventArgs e) { pnlNewPasswordLine.BackColor = blurColor; }
        private void txtConfirmPassword_Enter(object sender, EventArgs e) { pnlConfirmPasswordLine.BackColor = focusColor; }
        private void txtConfirmPassword_Leave(object sender, EventArgs e) { pnlConfirmPasswordLine.BackColor = blurColor; }

        // --- Xử lý 2 nút ẩn/hiện mật khẩu ---
        private void btnShowHideNewPass_Click(object sender, EventArgs e)
        {
            if (txtNewPassword.PasswordChar == '•')
            {
                txtNewPassword.PasswordChar = '\0';
                btnShowHideNewPass.Text = "🔒";
            }
            else
            {
                txtNewPassword.PasswordChar = '•';
                btnShowHideNewPass.Text = "👁️";
            }
        }

        private void btnShowHideConfirmPass_Click(object sender, EventArgs e)
        {
            if (txtConfirmPassword.PasswordChar == '•')
            {
                txtConfirmPassword.PasswordChar = '\0';
                btnShowHideConfirmPass.Text = "🔒";
            }
            else
            {
                txtConfirmPassword.PasswordChar = '•';
                btnShowHideConfirmPass.Text = "👁️";
            }
        }
    }
}