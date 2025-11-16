using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        // Bỏ pnlRight, chỉ giữ pnlLeft (sẽ fill toàn bộ Form)
        private Panel pnlLeft;
        // private Panel pnlRight; // ĐÃ XÓA
        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private Button btnLogin;
        private LinkLabel lnkForgotPassword;
        private CheckBox chkRememberMe;
        // private PictureBox pictureIllustration; // ĐÃ XÓA
        // private Label lblIllustrationTitle; // ĐÃ XÓA
        // private Label lblIllustrationDesc; // ĐÃ XÓA
        private LinkLabel lnkCreateAccount;

        // Thêm Label mô tả
        private Label lblLabelEmail;
        private Label lblLabelPassword;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pnlLeft = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLabelEmail = new Label(); // Khởi tạo
            txtEmail = new TextBox();
            lblLabelPassword = new Label(); // Khởi tạo
            txtPassword = new TextBox();
            chkRememberMe = new CheckBox();
            btnLogin = new Button();
            lnkCreateAccount = new LinkLabel();
            lnkForgotPassword = new LinkLabel();
            // pnlRight = new Panel(); // ĐÃ XÓA
            // ... (Xóa khởi tạo các control của pnlRight) ...

            pnlLeft.SuspendLayout();
            // pnlRight.SuspendLayout(); // ĐÃ XÓA
            // ((System.ComponentModel.ISupportInitialize)pictureIllustration).BeginInit(); // ĐÃ XÓA
            SuspendLayout();

            // --- Cấu hình tổng thể Form ---
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 750); // Kích thước mới
            Controls.Add(pnlLeft); // Chỉ add pnlLeft
            // Controls.Add(pnlRight); // ĐÃ XÓA
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FinSet - Login";

            // --- pnlLeft: (Bây giờ là Form chính) ---
            pnlLeft.BackColor = Color.White;
            pnlLeft.Controls.Add(lblTitle);
            pnlLeft.Controls.Add(lblSubtitle);
            pnlLeft.Controls.Add(lblLabelEmail); // Thêm
            pnlLeft.Controls.Add(txtEmail);
            pnlLeft.Controls.Add(lblLabelPassword); // Thêm
            pnlLeft.Controls.Add(txtPassword);
            pnlLeft.Controls.Add(chkRememberMe);
            pnlLeft.Controls.Add(btnLogin);
            pnlLeft.Controls.Add(lnkCreateAccount);
            pnlLeft.Controls.Add(lnkForgotPassword);
            pnlLeft.Dock = DockStyle.Fill; // Fill toàn bộ Form
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Size = new Size(500, 750); // Kích thước mới

            // Tọa độ X và Chiều rộng chung (Giống RegisterForm)
            int x = 60;
            int inputWidth = 380;

            // --- lblTitle ---
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(126, 58, 242); // Màu tím
            lblTitle.Location = new Point(x, 50); // Y: 50
            lblTitle.Name = "lblTitle";
            lblTitle.Text = "Welcome Back 👋";

            // --- lblSubtitle ---
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(x, 100); // Y: 100
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Text = "Login to continue to FinSet";

            // --- Email ---
            lblLabelEmail.Text = "Email";
            lblLabelEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelEmail.ForeColor = Color.Black;
            lblLabelEmail.AutoSize = true;
            lblLabelEmail.Location = new Point(x, 180); // Y: 180
            pnlLeft.Controls.Add(lblLabelEmail);

            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(x, 210); // Y: 210
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Enter your Email adress";
            txtEmail.Size = new Size(inputWidth, 45);

            // --- Password ---
            lblLabelPassword.Text = "Password";
            lblLabelPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelPassword.ForeColor = Color.Black;
            lblLabelPassword.AutoSize = true;
            lblLabelPassword.Location = new Point(x, 280); // Y: 280
            pnlLeft.Controls.Add(lblLabelPassword);

            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.Location = new Point(x, 310); // Y: 310
            txtPassword.Name = "txtPassword";
            txtPassword.PlaceholderText = "Enter your password";
            txtPassword.Size = new Size(inputWidth, 45);
            txtPassword.UseSystemPasswordChar = true;

            // --- chkRememberMe ---
            chkRememberMe.AutoSize = true;
            chkRememberMe.Font = new Font("Segoe UI", 10F);
            chkRememberMe.ForeColor = Color.Gray;
            chkRememberMe.Location = new Point(x, 370); // Y: 370
            chkRememberMe.Name = "chkRememberMe";
            chkRememberMe.Text = "Remember me";

            // --- lnkForgotPassword ---
            lnkForgotPassword.AutoSize = true;
            lnkForgotPassword.Font = new Font("Segoe UI", 10F);
            lnkForgotPassword.LinkColor = Color.Gray;
            lnkForgotPassword.Location = new Point(x + 230, 370); // Căn phải
            lnkForgotPassword.Name = "lnkForgotPassword";
            lnkForgotPassword.TabStop = true;
            lnkForgotPassword.Text = "Forgot password?";

            // --- btnLogin ---
            btnLogin.BackColor = Color.FromArgb(126, 58, 242);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(x, 430); // Y: 430
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(inputWidth, 50);
            btnLogin.Text = "Sign In";
            btnLogin.UseVisualStyleBackColor = false;


            // --- lnkCreateAccount ---
            lnkCreateAccount.AutoSize = true;
            lnkCreateAccount.Font = new Font("Segoe UI", 10F);
            lnkCreateAccount.LinkColor = Color.FromArgb(126, 58, 242);
            lnkCreateAccount.Location = new Point(140, 500); // Y: 500
            lnkCreateAccount.Name = "lnkCreateAccount";
            lnkCreateAccount.TabStop = true;
            lnkCreateAccount.Text = "Don't have an account? Create one";

            // --- pnlRight (Đã xóa) ---

            pnlLeft.ResumeLayout(false);
            pnlLeft.PerformLayout();
            ResumeLayout(false);
        }
    }
}