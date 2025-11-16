namespace ExpenseManager.App.Views
{
    partial class LoginForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.pnlLoginForm = new System.Windows.Forms.Panel();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.btnGoogleLogin = new System.Windows.Forms.Button();
            this.lnkForgotPassword = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlPasswordContainer = new System.Windows.Forms.Panel();
            this.btnShowHidePassword = new System.Windows.Forms.Button();
            this.pnlUsernameLine = new System.Windows.Forms.Panel();
            this.pnlPasswordLine = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();

            this.pnlLoginForm.SuspendLayout();
            this.pnlPasswordContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlLoginForm
            // 
            this.pnlLoginForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlLoginForm.Controls.Add(this.lblTitle);
            this.pnlLoginForm.Controls.Add(this.lnkRegister);
            this.pnlLoginForm.Controls.Add(this.btnGoogleLogin);
            this.pnlLoginForm.Controls.Add(this.lnkForgotPassword);
            this.pnlLoginForm.Controls.Add(this.lblError);
            this.pnlLoginForm.Controls.Add(this.btnLogin);
            this.pnlLoginForm.Controls.Add(this.lblPassword);
            this.pnlLoginForm.Controls.Add(this.txtUsername);
            this.pnlLoginForm.Controls.Add(this.lblUsername);
            this.pnlLoginForm.Controls.Add(this.pnlPasswordContainer);
            this.pnlLoginForm.Controls.Add(this.pnlUsernameLine);
            this.pnlLoginForm.Controls.Add(this.pnlPasswordLine);
            this.pnlLoginForm.Location = new System.Drawing.Point(340, 40);
            // *** SỬA LỖI KHOẢNG CÁCH: Thu nhỏ chiều cao Panel ***
            this.pnlLoginForm.Name = "pnlLoginForm";
            this.pnlLoginForm.Size = new System.Drawing.Size(420, 560); // Giảm chiều cao từ 600 -> 560
            this.pnlLoginForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(86, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(248, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG NHẬP";
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(60, 130);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(141, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(60, 160);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 27);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // pnlUsernameLine
            // 
            this.pnlUsernameLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlUsernameLine.Location = new System.Drawing.Point(60, 187);
            this.pnlUsernameLine.Name = "pnlUsernameLine";
            this.pnlUsernameLine.Size = new System.Drawing.Size(300, 2);
            this.pnlUsernameLine.TabIndex = 12;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.BackColor = System.Drawing.Color.Transparent;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPassword.Location = new System.Drawing.Point(60, 210);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(95, 25);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Mật Khẩu";
            // 
            // pnlPasswordContainer
            // 
            this.pnlPasswordContainer.BackColor = System.Drawing.Color.White;
            this.pnlPasswordContainer.Controls.Add(this.btnShowHidePassword);
            this.pnlPasswordContainer.Controls.Add(this.txtPassword);
            this.pnlPasswordContainer.Location = new System.Drawing.Point(60, 240);
            this.pnlPasswordContainer.Name = "pnlPasswordContainer";
            this.pnlPasswordContainer.Size = new System.Drawing.Size(300, 34);
            this.pnlPasswordContainer.TabIndex = 4;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.Location = new System.Drawing.Point(3, 3);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '•';
            this.txtPassword.Size = new System.Drawing.Size(255, 27);
            this.txtPassword.TabIndex = 0;
            this.txtPassword.Enter += new System.EventHandler(this.txtPassword_Enter);
            this.txtPassword.Leave += new System.EventHandler(this.txtPassword_Leave);
            // 
            // btnShowHidePassword
            // 
            this.btnShowHidePassword.BackColor = System.Drawing.Color.White;
            this.btnShowHidePassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHidePassword.FlatAppearance.BorderSize = 0;
            this.btnShowHidePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHidePassword.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowHidePassword.ForeColor = System.Drawing.Color.Gray;
            this.btnShowHidePassword.Image = null;
            this.btnShowHidePassword.Text = "👁️";
            this.btnShowHidePassword.Location = new System.Drawing.Point(260, 2);
            this.btnShowHidePassword.Name = "btnShowHidePassword";
            this.btnShowHidePassword.Size = new System.Drawing.Size(35, 30);
            this.btnShowHidePassword.TabIndex = 1;
            this.btnShowHidePassword.UseVisualStyleBackColor = false;
            this.btnShowHidePassword.Click += new System.EventHandler(this.btnShowHidePassword_Click);
            // 
            // pnlPasswordLine
            // 
            this.pnlPasswordLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlPasswordLine.Location = new System.Drawing.Point(60, 274);
            this.pnlPasswordLine.Name = "pnlPasswordLine";
            this.pnlPasswordLine.Size = new System.Drawing.Size(300, 2);
            this.pnlPasswordLine.TabIndex = 13;
            // 
            // lnkForgotPassword
            // 
            this.lnkForgotPassword.AutoSize = true;
            this.lnkForgotPassword.BackColor = System.Drawing.Color.Transparent;
            this.lnkForgotPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkForgotPassword.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkForgotPassword.Location = new System.Drawing.Point(250, 280);
            this.lnkForgotPassword.Name = "lnkForgotPassword";
            this.lnkForgotPassword.Size = new System.Drawing.Size(110, 20);
            this.lnkForgotPassword.TabIndex = 6;
            this.lnkForgotPassword.TabStop = true;
            this.lnkForgotPassword.Text = "Quên mật khẩu?";
            this.lnkForgotPassword.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkForgotPassword_LinkClicked);
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            // *** SỬA LỖI KHOẢNG CÁCH: Dời lên ***
            this.lblError.Location = new System.Drawing.Point(60, 315); // Dời Y từ 330 -> 315
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(300, 20);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "";
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            // *** SỬA LỖI KHOẢNG CÁCH: Dời lên ***
            this.btnLogin.Location = new System.Drawing.Point(60, 350); // Dời Y từ 370 -> 350
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(300, 50);
            this.btnLogin.TabIndex = 8;
            this.btnLogin.Text = "Đăng Nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // btnGoogleLogin
            // 
            this.btnGoogleLogin.BackColor = System.Drawing.Color.White;
            this.btnGoogleLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoogleLogin.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGoogleLogin.FlatAppearance.BorderSize = 1;
            this.btnGoogleLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoogleLogin.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnGoogleLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoogleLogin.Image = null;
            this.btnGoogleLogin.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // *** SỬA LỖI KHOẢNG CÁCH: Dời lên ***
            this.btnGoogleLogin.Location = new System.Drawing.Point(60, 415); // Dời Y từ 440 -> 415
            this.btnGoogleLogin.Name = "btnGoogleLogin";
            this.btnGoogleLogin.Padding = new System.Windows.Forms.Padding(0);
            this.btnGoogleLogin.Size = new System.Drawing.Size(300, 50);
            this.btnGoogleLogin.TabIndex = 9;
            this.btnGoogleLogin.Text = "Đăng nhập bằng Google";
            this.btnGoogleLogin.UseVisualStyleBackColor = false;
            this.btnGoogleLogin.Click += new System.EventHandler(this.btnGoogleLogin_Click);
            // 
            // lnkRegister
            // 
            this.lnkRegister.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lnkRegister.BackColor = System.Drawing.Color.Transparent;
            this.lnkRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkRegister.LinkArea = new System.Windows.Forms.LinkArea(23, 7);
            this.lnkRegister.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkRegister.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            // *** SỬA LỖI KHOẢNG CÁCH: Dời lên ***
            this.lnkRegister.Location = new System.Drawing.Point(60, 485); // Dời Y từ 520 -> 485
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(300, 20);
            this.lnkRegister.TabIndex = 11;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "Bạn chưa có tài khoản? Đăng ký";
            this.lnkRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkRegister.UseCompatibleTextRendering = true;
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlLoginForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Manager - Đăng Nhập";
            this.BackgroundImage = ExpenseManager.App.Properties.Resources.bglogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.Resize += new System.EventHandler(this.LoginForm_Load);
            this.pnlLoginForm.ResumeLayout(false);
            this.pnlLoginForm.PerformLayout();
            this.pnlPasswordContainer.ResumeLayout(false);
            this.pnlPasswordContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        // Khai báo các Controls (biến)
        private System.Windows.Forms.Panel pnlLoginForm;
        private System.Windows.Forms.Panel pnlPasswordContainer;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button btnGoogleLogin;
        private System.Windows.Forms.Button btnShowHidePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.LinkLabel lnkForgotPassword;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.Panel pnlUsernameLine;
        private System.Windows.Forms.Panel pnlPasswordLine;

        #endregion
    }
}