using ExpenseManager.App.Presenters;
using Microsoft.Extensions.DependencyInjection; // Thêm
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class RegisterForm : Form
    {
        private Color focusColor = Color.FromArgb(0, 123, 255);
        private Color blurColor = Color.LightGray;

        // 1. Khai báo Presenter
        private readonly RegisterPresenter _presenter;

        // 2. SỬA LẠI CONSTRUCTOR:
        // Xóa hàm public RegisterForm() cũ
        // Constructor này sẽ nhận RegisterPresenter (do Program.cs "tiêm" vào)
        public RegisterForm(RegisterPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter; // Gán Presenter

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

        // 3. SỬA LẠI HÀM REGISTER_CLICK:
        // Hàm này giờ sẽ gọi Presenter
        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string fullName = txtFullName.Text;
            string email = txtUsername.Text; // txtUsername đang được dùng cho Email
            string password = txtPassword.Text;

            lblError.Text = string.Empty;

            if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                ShowErrorMessage("Vui lòng nhập đầy đủ thông tin.");
                return;
            }

            // 4. GỬI DỮ LIỆU CHO PRESENTER
            var (success, errorMessage) = await _presenter.RegisterAsync(fullName, email, password);

            // 5. XỬ LÝ KẾT QUẢ TỪ PRESENTER
            if (success)
            {
                MessageBox.Show("Đăng ký thành công! Vui lòng đăng nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Đăng ký xong thì quay lại Login
                lnkLogin_LinkClicked(sender, null);
            }
            else
            {
                // Hiển thị lỗi (vd: "Email đã tồn tại")
                ShowErrorMessage(errorMessage);
            }
        }

        // --- (Các hàm gạch chân giữ nguyên) ---
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

        // --- (Các hàm xử lý sự kiện khác) ---
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

        // 6. SỬA LẠI HÀM LINK CLICK:
        // Dùng ServiceProvider để lấy LoginForm
        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Lấy Form từ DI (Dependency Injection)
            // KHÔNG DÙNG: new LoginForm();
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