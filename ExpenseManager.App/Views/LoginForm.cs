using ExpenseManager.App.Presenters;
using ExpenseManager.App.Views.Admin.Sidebar;
using System;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    // LoginForm (partial class) triển khai ILoginView MỚI (đã dọn dẹp)
    public partial class LoginForm : Form, ILoginView
    {
        private LoginPresenter _presenter;
        // private bool _isLoginMode = true; // ĐÃ XÓA

        public LoginForm()
        {
            InitializeComponent();
            WireControlEvents();
            // UpdateUiForMode(); // ĐÃ XÓA
        }

        // Phương thức này được gọi từ Program.cs
        public void SetPresenter(LoginPresenter presenter)
        {
            _presenter = presenter;
        }

        // Gắn sự kiện click của Control (Button, Link) vào Event Handlers MỚI
        private void WireControlEvents()
        {
            // Nút chính (Sign In)
            if (btnLogin != null)
            {
                // Gọi OnLoginClicked (tên mới)
                btnLogin.Click += (s, e) => OnLoginClicked();
            }

            // Nút chuyển chế độ (lnkCreateAccount)
            if (lnkCreateAccount != null)
            {
                // Gọi OnCreateAccountClicked (tên mới)
                lnkCreateAccount.LinkClicked += (s, e) => OnCreateAccountClicked(s, e);
            }
        }

        #region ILoginView — Properties & Events (Triển khai Interface MỚI)

        // Events
        public event EventHandler LoginClicked;
        public event EventHandler CreateAccountClicked;

        // Properties (Chỉ còn của Đăng nhập)
        public string Email
        {
            get => txtEmail?.Text ?? string.Empty;
            set { if (txtEmail != null) txtEmail.Text = value; }
        }

        public string Password
        {
            get => txtPassword?.Text ?? string.Empty;
            set { if (txtPassword != null) txtPassword.Text = value; }
        }

        public bool RememberMe
        {
            get => chkRememberMe != null && chkRememberMe.Checked;
            set { if (chkRememberMe != null) chkRememberMe.Checked = value; }
        }

        // --- CÁC THUỘC TÍNH ĐĂNG KÝ ĐÃ BỊ XÓA ---
        // public string FullName { ... }
        // public string ConfirmPassword { ... }
        // public bool AgreeTerms { ... }
        // public bool IsLoginMode => _isLoginMode;

        #endregion

        #region ILoginView — Actions (Triển khai Interface MỚI)

        // Các hàm này được Presenter gọi để điều khiển View

        public void ShowError(string message)
        {
            // Chạy trên UI thread
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(this, message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }

        public void ShowSuccess(string message)
        {
            // Chạy trên UI thread
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(this, message, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        public void NavigateToMain()
        {
            // Chạy trên UI thread
            this.Invoke((MethodInvoker)delegate {
                this.Hide(); // Ẩn form Login

                // *** CHÚ Ý: Đổi tên "MainForm" nếu form layout của bạn tên khác (ví dụ: LayoutAdmin) ***
                var mainForm = new LayoutAdmin();
                mainForm.FormClosed += (s, args) => this.Close(); // Đóng app khi form chính đóng
                mainForm.Show();
            });
        }



        // --- HÀM MỚI (để mở RegisterForm) ---
        public void ShowRegisterForm()
        {
            // Chạy trên UI thread
            this.Invoke((MethodInvoker)delegate {
                // Tạo một instance của RegisterForm (Form Đăng ký chúng ta vừa tạo)
                using (var registerForm = new RegisterForm())
                {
                    // Ẩn Form Login
                    this.Hide();

                    // Hiển thị Form Đăng ký (ShowDialog sẽ khóa Form Login)
                    var result = registerForm.ShowDialog(this);

                    // Sau khi Form Đăng ký đóng:
                    // Nếu người dùng đăng ký thành công (hoặc nhấn 'Sign in' trên form đó)
                    // thì hiển thị lại Form Login
                    if (result == DialogResult.OK || result == DialogResult.Cancel)
                    {
                        this.Show(); // Hiển thị lại Form Login
                    }
                }
            });
        }

        #endregion

        #region Internal UI helpers (Event Handlers MỚI)

        // Khi người dùng click nút Login
        private void OnLoginClicked()
        {
            // Kích hoạt (raise) event, Presenter (file 3/4) sẽ bắt được
            LoginClicked?.Invoke(this, EventArgs.Empty);
        }

        // Khi người dùng click link Chuyển chế độ
        private void OnCreateAccountClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Kích hoạt (raise) event, Presenter (file 3/4) sẽ bắt được
            CreateAccountClicked?.Invoke(this, EventArgs.Empty);
        }

        // --- ĐÃ XÓA ---
        // private void UpdateUiForMode() { ... }

        #endregion
    }
}