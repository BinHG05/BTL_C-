using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Configuration; // Cần để lấy Connection String
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class RegisterForm : Form
    {
        // Form này sẽ tự quản lý logic của nó (cho đơn giản)
        // nhưng vẫn TÁI SỬ DỤNG UserService và UserRepository

        public RegisterForm()
        {
            InitializeComponent();

            // Gắn sự kiện click (Cách làm này an toàn hơn là gán trong Designer)
            btnSignUp.Click += btnSignUp_Click;
            linkSignIn.LinkClicked += linkSignIn_LinkClicked;
        }

        // Xử lý sự kiện khi nhấn nút "Sign Up"
        private async void btnSignUp_Click(object sender, EventArgs e)
        {
            // 1. Validation (Kiểm tra)
            if (string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmPassword.Text))
            {
                MessageBox.Show("Please fill out all required fields.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Passwords do not match.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!chkAgree.Checked)
            {
                MessageBox.Show("You must agree to the Terms & Privacy to continue.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // --- 2. Xử lý Đăng ký (Tái sử dụng logic MVP) ---

            // Tạo một DbContext stack tạm thời (vì form này là độc lập)
            string connectionString = ConfigurationManager.ConnectionStrings["ExpenseDB"]?.ConnectionString;
            if (string.IsNullOrEmpty(connectionString))
            {
                MessageBox.Show("Connection string 'ExpenseDB' not found.", "Error");
                return;
            }

            var options = new DbContextOptionsBuilder<ExpenseDbContext>()
                .UseSqlServer(connectionString)
                .Options;

            using (var dbContext = new ExpenseDbContext(options))
            {
                // Khởi tạo Service và Repository (giống hệt Program.cs)
                var userRepository = new UserRepository(dbContext);
                var userService = new UserService(userRepository);

                try
                {
                    // Vẫn vô hiệu hóa nút để tránh click đúp
                    btnSignUp.Enabled = false;
                    btnSignUp.Text = "Creating...";

                    // 3. Gọi Service (Tái sử dụng File 6/9)
                    var newUser = await userService.RegisterAsync(
                        txtFullName.Text,
                        txtEmail.Text,
                        txtPassword.Text
                    );

                    // 4. Thành công
                    MessageBox.Show("Account created successfully! Please log in.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    this.DialogResult = DialogResult.OK; // Báo hiệu thành công
                    this.Close(); // Đóng form Đăng ký
                }
                catch (Exception ex)
                {
                    // 5. Bắt lỗi (ví dụ: "Email already exists." từ Service)
                    MessageBox.Show(ex.Message, "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    // Mở lại nút
                    btnSignUp.Enabled = true;
                    btnSignUp.Text = "Sign Up";
                }
            }
        }

        // Xử lý khi nhấn link "Have an account? Sign in"
        private void linkSignIn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close(); // Chỉ cần đóng form này lại, form Login đang chờ ở dưới
        }
    }
}