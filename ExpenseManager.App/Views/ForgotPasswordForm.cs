using ExpenseManager.App.Presenters;
using Microsoft.Extensions.DependencyInjection; 
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class ForgotPasswordForm : Form
    {
        private readonly ForgotPasswordPresenter _presenter;

        // Màu sắc UI
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        // Constructor nhận Presenter từ Dependency Injection
        public ForgotPasswordForm(ForgotPasswordPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;

            // Setup UI mặc định
            this.lblError.Text = string.Empty;
            pnlEmailLine.BackColor = blurColor;
            pnlCodeLine.BackColor = blurColor;
            pnlNewPasswordLine.BackColor = blurColor;
            pnlConfirmPasswordLine.BackColor = blurColor;
        }

        private void ForgotPasswordForm_Load(object sender, EventArgs e)
        {
            // Căn giữa panel
            int panelX = (this.ClientSize.Width - pnlForgotPassword.Width) / 2;
            int panelY = (this.ClientSize.Height - pnlForgotPassword.Height) / 2;
            pnlForgotPassword.Location = new Point(panelX, panelY);

            txtEmail.Focus();
        }

        private async void btnSubmitEmail_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;
            string email = txtEmail.Text.Trim();

            if (string.IsNullOrEmpty(email) || !email.Contains("@"))
            {
                ShowErrorMessage("Vui lòng nhập email hợp lệ.");
                return;
            }

            // UI: Loading
            btnSubmitEmail.Enabled = false;
            btnSubmitEmail.Text = "Đang gửi mã...";

            // GỌI PRESENTER
            var result = await _presenter.RequestResetCode(email);

            // UI: Reset button
            btnSubmitEmail.Enabled = true;
            btnSubmitEmail.Text = "Gửi mã";

            if (result.Success)
            {
                // Chuyển sang giao diện nhập mã 
                lblTitle.Text = "ĐẶT LẠI MẬT KHẨU";
                pnlStep1.Visible = false;
                pnlStep2.Visible = true;
                txtCode.Focus();
                MessageBox.Show(result.Message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                ShowErrorMessage(result.Message);
            }
        }

        private async void btnResetPassword_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(txtCode.Text) || string.IsNullOrEmpty(txtNewPassword.Text))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            if (txtNewPassword.Text != txtConfirmPassword.Text)
            {
                ShowErrorMessage("Mật khẩu xác nhận không khớp.");
                return;
            }

            btnResetPassword.Enabled = false;
            btnResetPassword.Text = "Đang xử lý...";

            // GỌI PRESENTER
            var result = await _presenter.SubmitNewPassword(txtEmail.Text.Trim(), txtCode.Text.Trim(), txtNewPassword.Text);

            btnResetPassword.Enabled = true;
            btnResetPassword.Text = "Xác nhận";

            if (result.Success)
            {
                MessageBox.Show("Đổi mật khẩu thành công! Vui lòng đăng nhập lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GoBackToLogin();
            }
            else
            {
                ShowErrorMessage(result.Message);
            }
        }

        private void GoBackToLogin()
        {
            var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
            loginForm.Show();
            this.Hide();
        }

        private void lnkBackToLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            GoBackToLogin();
        }

        public void ShowErrorMessage(string message)
        {
            lblError.Text = message;
        }

        private void txtEmail_Enter(object sender, EventArgs e) { pnlEmailLine.BackColor = focusColor; }
        private void txtEmail_Leave(object sender, EventArgs e) { pnlEmailLine.BackColor = blurColor; }
        private void txtCode_Enter(object sender, EventArgs e) { pnlCodeLine.BackColor = focusColor; }
        private void txtCode_Leave(object sender, EventArgs e) { pnlCodeLine.BackColor = blurColor; }
        private void txtNewPassword_Enter(object sender, EventArgs e) { pnlNewPasswordLine.BackColor = focusColor; }
        private void txtNewPassword_Leave(object sender, EventArgs e) { pnlNewPasswordLine.BackColor = blurColor; }
        private void txtConfirmPassword_Enter(object sender, EventArgs e) { pnlConfirmPasswordLine.BackColor = focusColor; }
        private void txtConfirmPassword_Leave(object sender, EventArgs e) { pnlConfirmPasswordLine.BackColor = blurColor; }

        private void btnShowHideNewPass_Click(object sender, EventArgs e)
        {
            txtNewPassword.PasswordChar = txtNewPassword.PasswordChar == '•' ? '\0' : '•';
            btnShowHideNewPass.Text = txtNewPassword.PasswordChar == '•' ? "👁️" : "🔒";
        }

        private void btnShowHideConfirmPass_Click(object sender, EventArgs e)
        {
            txtConfirmPassword.PasswordChar = txtConfirmPassword.PasswordChar == '•' ? '\0' : '•';
            btnShowHideConfirmPass.Text = txtConfirmPassword.PasswordChar == '•' ? "👁️" : "🔒";
        }
    }
}