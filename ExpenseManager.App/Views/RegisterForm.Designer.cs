namespace ExpenseManager.App.Views
{
    partial class RegisterForm
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
            this.pnlRegisterForm = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.lblError = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnGoogleRegister = new System.Windows.Forms.Button(); // ✅ THÊM

            // Thêm controls cho Full Name
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.pnlFullNameLine = new System.Windows.Forms.Panel();

            this.lblPassword = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlPasswordContainer = new System.Windows.Forms.Panel();
            this.btnShowHidePassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.pnlUsernameLine = new System.Windows.Forms.Panel();
            this.pnlPasswordLine = new System.Windows.Forms.Panel();

            this.pnlRegisterForm.SuspendLayout();
            this.pnlPasswordContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlRegisterForm
            // 
            this.pnlRegisterForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlRegisterForm.Controls.Add(this.lblTitle);
            this.pnlRegisterForm.Controls.Add(this.lnkLogin);
            this.pnlRegisterForm.Controls.Add(this.lblError);
            this.pnlRegisterForm.Controls.Add(this.btnRegister);
            this.pnlRegisterForm.Controls.Add(this.btnGoogleRegister); // ✅ THÊM

            // Thêm controls Full Name vào Panel
            this.pnlRegisterForm.Controls.Add(this.lblFullName);
            this.pnlRegisterForm.Controls.Add(this.txtFullName);
            this.pnlRegisterForm.Controls.Add(this.pnlFullNameLine);

            this.pnlRegisterForm.Controls.Add(this.lblPassword);
            this.pnlRegisterForm.Controls.Add(this.txtUsername);
            this.pnlRegisterForm.Controls.Add(this.lblUsername);
            this.pnlRegisterForm.Controls.Add(this.pnlPasswordContainer);
            this.pnlRegisterForm.Controls.Add(this.pnlUsernameLine);
            this.pnlRegisterForm.Controls.Add(this.pnlPasswordLine);
            this.pnlRegisterForm.Location = new System.Drawing.Point(340, 40);
            this.pnlRegisterForm.Name = "pnlRegisterForm";
            this.pnlRegisterForm.Size = new System.Drawing.Size(420, 600); // ✅ TĂNG CHIỀU CAO TỪ 560 -> 600
            this.pnlRegisterForm.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(105, 40);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(210, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "ĐĂNG KÝ";
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            // 
            // lblFullName
            // 
            this.lblFullName.AutoSize = true;
            this.lblFullName.BackColor = System.Drawing.Color.Transparent;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblFullName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblFullName.Location = new System.Drawing.Point(60, 110);
            this.lblFullName.Name = "lblFullName";
            this.lblFullName.Size = new System.Drawing.Size(98, 25);
            this.lblFullName.TabIndex = 14;
            this.lblFullName.Text = "Họ và Tên";
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFullName.Location = new System.Drawing.Point(60, 140);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.Size = new System.Drawing.Size(300, 27);
            this.txtFullName.TabIndex = 1;
            this.txtFullName.Enter += new System.EventHandler(this.txtFullName_Enter);
            this.txtFullName.Leave += new System.EventHandler(this.txtFullName_Leave);
            // 
            // pnlFullNameLine
            // 
            this.pnlFullNameLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlFullNameLine.Location = new System.Drawing.Point(60, 167);
            this.pnlFullNameLine.Name = "pnlFullNameLine";
            this.pnlFullNameLine.Size = new System.Drawing.Size(300, 2);
            this.pnlFullNameLine.TabIndex = 15;
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.BackColor = System.Drawing.Color.Transparent;
            this.lblUsername.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblUsername.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsername.Location = new System.Drawing.Point(60, 190);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(141, 25);
            this.lblUsername.TabIndex = 1;
            this.lblUsername.Text = "Email";
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.Location = new System.Drawing.Point(60, 220);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(300, 27);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.Enter += new System.EventHandler(this.txtUsername_Enter);
            this.txtUsername.Leave += new System.EventHandler(this.txtUsername_Leave);
            // 
            // pnlUsernameLine
            // 
            this.pnlUsernameLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlUsernameLine.Location = new System.Drawing.Point(60, 247);
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
            this.lblPassword.Location = new System.Drawing.Point(60, 270);
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
            this.pnlPasswordContainer.Location = new System.Drawing.Point(60, 300);
            this.pnlPasswordContainer.Name = "pnlPasswordContainer";
            this.pnlPasswordContainer.Size = new System.Drawing.Size(300, 34);
            this.pnlPasswordContainer.TabIndex = 3;
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
            this.pnlPasswordLine.Location = new System.Drawing.Point(60, 334);
            this.pnlPasswordLine.Name = "pnlPasswordLine";
            this.pnlPasswordLine.Size = new System.Drawing.Size(300, 2);
            this.pnlPasswordLine.TabIndex = 13;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(60, 350);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(300, 20);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(60, 385);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(300, 50);
            this.btnRegister.TabIndex = 4;
            this.btnRegister.Text = "Đăng Ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnGoogleRegister ✅ THÊM BUTTON GOOGLE
            // 
            this.btnGoogleRegister.BackColor = System.Drawing.Color.White;
            this.btnGoogleRegister.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGoogleRegister.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnGoogleRegister.FlatAppearance.BorderSize = 1;
            this.btnGoogleRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoogleRegister.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGoogleRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.btnGoogleRegister.Location = new System.Drawing.Point(60, 450);
            this.btnGoogleRegister.Name = "btnGoogleRegister";
            this.btnGoogleRegister.Size = new System.Drawing.Size(300, 45);
            this.btnGoogleRegister.TabIndex = 5;
            this.btnGoogleRegister.Text = "🔵 Đăng ký bằng Google";
            this.btnGoogleRegister.UseVisualStyleBackColor = false;
            this.btnGoogleRegister.Click += new System.EventHandler(this.btnGoogleRegister_Click);
            // 
            // lnkLogin
            // 
            this.lnkLogin.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lnkLogin.BackColor = System.Drawing.Color.Transparent;
            this.lnkLogin.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkLogin.LinkArea = new System.Windows.Forms.LinkArea(21, 9);
            this.lnkLogin.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lnkLogin.Location = new System.Drawing.Point(60, 515); // ✅ DỜI XUỐNG TỪ 470 -> 515
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(300, 20);
            this.lnkLogin.TabIndex = 6;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Bạn đã có tài khoản? Đăng nhập";
            this.lnkLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLogin.UseCompatibleTextRendering = true;
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlRegisterForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RegisterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Manager - Đăng Ký";
            this.BackgroundImage = ExpenseManager.App.Properties.Resources.bglogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.Resize += new System.EventHandler(this.RegisterForm_Load);
            this.pnlRegisterForm.ResumeLayout(false);
            this.pnlRegisterForm.PerformLayout();
            this.pnlPasswordContainer.ResumeLayout(false);
            this.pnlPasswordContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        // Khai báo các Controls (biến)
        private System.Windows.Forms.Panel pnlRegisterForm;
        private System.Windows.Forms.Panel pnlPasswordContainer;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnGoogleRegister; // ✅ THÊM
        private System.Windows.Forms.Button btnShowHidePassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Panel pnlUsernameLine;
        private System.Windows.Forms.Panel pnlPasswordLine;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Panel pnlFullNameLine;
    }
}