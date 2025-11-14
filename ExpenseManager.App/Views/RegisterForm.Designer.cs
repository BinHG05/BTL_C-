using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    partial class RegisterForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblSubtitle;
        private TextBox txtFullName;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtConfirmPassword;
        private CheckBox chkAgree;
        private Button btnSignUp;
        private Label lblOr;
        private PictureBox picGoogle;
        private PictureBox picApple;
        private LinkLabel linkSignIn;
        private Label lblLabelFullName;
        private Label lblLabelEmail;
        private Label lblLabelPassword;
        private Label lblLabelConfirmPassword;


        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblSubtitle = new Label();
            lblLabelFullName = new Label();
            txtFullName = new TextBox();
            lblLabelEmail = new Label();
            txtEmail = new TextBox();
            lblLabelPassword = new Label();
            txtPassword = new TextBox();
            lblLabelConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            chkAgree = new CheckBox();
            btnSignUp = new Button();
            lblOr = new Label();
            picGoogle = new PictureBox();
            picApple = new PictureBox();
            linkSignIn = new LinkLabel();

            ((System.ComponentModel.ISupportInitialize)(picGoogle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(picApple)).BeginInit();
            SuspendLayout();

            // === Form ===
            BackColor = Color.White;
            ClientSize = new Size(500, 750); // Tăng chiều cao
            FormBorderStyle = FormBorderStyle.FixedSingle;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sign Up - FinSet";

            int x = 60;
            int inputWidth = 380;

            // === Title ===
            lblTitle.Text = "Welcome to FinSet!";
            lblTitle.Font = new Font("Segoe UI Semibold", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(x, 50); // Y: 50
            Controls.Add(lblTitle);

            // === Subtitle ===
            lblSubtitle.Text = "Sign up and start managing your finances now";
            lblSubtitle.Font = new Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.AutoSize = true;
            lblSubtitle.Location = new Point(x, 100); // Y: 100
            Controls.Add(lblSubtitle);

            // --- FullName ---
            lblLabelFullName.Text = "Username";
            lblLabelFullName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelFullName.ForeColor = Color.Black;
            lblLabelFullName.AutoSize = true;
            lblLabelFullName.Location = new Point(x, 150); // Y: 150
            Controls.Add(lblLabelFullName);

            txtFullName.PlaceholderText = "Enter your full name";
            txtFullName.Font = new Font("Segoe UI", 11F);
            txtFullName.Location = new Point(x, 180); // Y: 180
            txtFullName.Width = inputWidth;
            txtFullName.Height = 45;
            Controls.Add(txtFullName);

            // --- Email ---
            lblLabelEmail.Text = "Email";
            lblLabelEmail.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelEmail.ForeColor = Color.Black;
            lblLabelEmail.AutoSize = true;
            lblLabelEmail.Location = new Point(x, 240); // Y: 240
            Controls.Add(lblLabelEmail);

            txtEmail.PlaceholderText = "Enter your Email adress";
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.Location = new Point(x, 270); // Y: 270
            txtEmail.Width = inputWidth;
            txtEmail.Height = 45;
            Controls.Add(txtEmail);

            // --- Password ---
            lblLabelPassword.Text = "Create password";
            lblLabelPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelPassword.ForeColor = Color.Black;
            lblLabelPassword.AutoSize = true;
            lblLabelPassword.Location = new Point(x, 330); // Y: 330
            Controls.Add(lblLabelPassword);

            txtPassword.PlaceholderText = "Must be 8 characters";
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.Location = new Point(x, 360); // Y: 360
            txtPassword.Width = inputWidth;
            txtPassword.Height = 45;
            Controls.Add(txtPassword);

            // --- Confirm Password ---
            lblLabelConfirmPassword.Text = "Confirm password";
            lblLabelConfirmPassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelConfirmPassword.ForeColor = Color.Black;
            lblLabelConfirmPassword.AutoSize = true;
            lblLabelConfirmPassword.Location = new Point(x, 420); // Y: 420
            Controls.Add(lblLabelConfirmPassword);

            txtConfirmPassword.PlaceholderText = "Repeat password";
            txtConfirmPassword.Font = new Font("Segoe UI", 11F);
            txtConfirmPassword.UseSystemPasswordChar = true;
            txtConfirmPassword.Location = new Point(x, 450); // Y: 450
            txtConfirmPassword.Width = inputWidth;
            txtConfirmPassword.Height = 45;
            Controls.Add(txtConfirmPassword);

            // === Checkbox ===
            chkAgree.Text = "I agree to the Terms & Privacy";
            chkAgree.Font = new Font("Segoe UI", 10F);
            chkAgree.ForeColor = Color.Gray;
            chkAgree.AutoSize = true;
            chkAgree.Location = new Point(x, 510); // Y: 510
            Controls.Add(chkAgree);

            // === Button ===
            btnSignUp.Text = "Sign Up";
            btnSignUp.BackColor = Color.FromArgb(120, 99, 255);
            btnSignUp.ForeColor = Color.White;
            btnSignUp.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            btnSignUp.FlatStyle = FlatStyle.Flat;
            btnSignUp.FlatAppearance.BorderSize = 0;
            btnSignUp.Location = new Point(x, 555); // Y: 555
            btnSignUp.Width = inputWidth;
            btnSignUp.Height = 50;
            Controls.Add(btnSignUp);

            // === Divider ===
            lblOr.Text = "or continue with";
            lblOr.ForeColor = Color.Gray;
            lblOr.Font = new Font("Segoe UI", 9F);
            lblOr.AutoSize = true;
            lblOr.Location = new Point(200, 625); // Y: 625
            Controls.Add(lblOr);

            // === Google icon ===
            picGoogle.SizeMode = PictureBoxSizeMode.Zoom;
            picGoogle.Size = new Size(40, 40);
            picGoogle.Location = new Point(200, 655); // Y: 655
            picGoogle.Name = "picGoogle";
            picGoogle.TabStop = false;
            picGoogle.Image = Properties.Resources.google;
            picGoogle.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(picGoogle);

            // === Apple icon ===
            picApple.SizeMode = PictureBoxSizeMode.Zoom;
            picApple.Size = new Size(40, 40);
            picApple.Location = new Point(260, 655); // Y: 655
            picApple.Name = "picApple";
            picApple.TabStop = false;
            picApple.Image = Properties.Resources.apple_logo;
            picApple.BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(picApple);

            // === Link sign in ===
            linkSignIn.Text = "Have an account? Sign in";
            linkSignIn.LinkColor = Color.FromArgb(120, 99, 255);
            linkSignIn.Font = new Font("Segoe UI", 10F);
            linkSignIn.AutoSize = true;
            linkSignIn.Location = new Point(160, 715); // Y: 715
            Controls.Add(linkSignIn);

            ((System.ComponentModel.ISupportInitialize)(picGoogle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(picApple)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}