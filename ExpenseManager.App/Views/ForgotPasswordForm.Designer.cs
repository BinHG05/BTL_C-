namespace ExpenseManager.App.Views
{
    partial class ForgotPasswordForm
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
            this.pnlForgotPassword = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblError = new System.Windows.Forms.Label();

            // Panel cho Bước 1: Nhập Email
            this.pnlStep1 = new System.Windows.Forms.Panel();
            this.lblEmailPrompt = new System.Windows.Forms.Label();
            this.btnSubmitEmail = new System.Windows.Forms.Button();
            this.lnkBackToLogin1 = new System.Windows.Forms.LinkLabel();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.pnlEmailLine = new System.Windows.Forms.Panel();

            // Panel cho Bước 2: Nhập Code, Mật khẩu mới
            this.pnlStep2 = new System.Windows.Forms.Panel();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.pnlCodeLine = new System.Windows.Forms.Panel();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.pnlNewPasswordContainer = new System.Windows.Forms.Panel();
            this.btnShowHideNewPass = new System.Windows.Forms.Button();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.pnlNewPasswordLine = new System.Windows.Forms.Panel();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.pnlConfirmPasswordContainer = new System.Windows.Forms.Panel();
            this.btnShowHideConfirmPass = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.pnlConfirmPasswordLine = new System.Windows.Forms.Panel();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.lnkBackToLogin2 = new System.Windows.Forms.LinkLabel();

            this.pnlForgotPassword.SuspendLayout();
            this.pnlStep1.SuspendLayout();
            this.pnlStep2.SuspendLayout();
            this.pnlNewPasswordContainer.SuspendLayout();
            this.pnlConfirmPasswordContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlForgotPassword
            // 
            this.pnlForgotPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.pnlForgotPassword.Controls.Add(this.lblTitle);
            this.pnlForgotPassword.Controls.Add(this.lblError);
            this.pnlForgotPassword.Controls.Add(this.pnlStep1); // Chứa Bước 1
            this.pnlForgotPassword.Controls.Add(this.pnlStep2); // Chứa Bước 2 (ẩn)
            this.pnlForgotPassword.Location = new System.Drawing.Point(340, 40);
            this.pnlForgotPassword.Name = "pnlForgotPassword";
            this.pnlForgotPassword.Size = new System.Drawing.Size(420, 560);
            this.pnlForgotPassword.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lblTitle.Location = new System.Drawing.Point(45, 40); // (420 - 330) / 2 = 45
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(330, 54);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "QUÊN MẬT KHẨU";
            this.lblTitle.BackColor = System.Drawing.Color.Transparent;
            // 
            // lblError
            // 
            this.lblError.BackColor = System.Drawing.Color.Transparent;
            this.lblError.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(60, 490); // Để dưới cùng
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(300, 20);
            this.lblError.TabIndex = 7;
            this.lblError.Text = "";
            this.lblError.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlStep1
            // 
            this.pnlStep1.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep1.Controls.Add(this.lblEmailPrompt);
            this.pnlStep1.Controls.Add(this.btnSubmitEmail);
            this.pnlStep1.Controls.Add(this.lnkBackToLogin1);
            this.pnlStep1.Controls.Add(this.lblEmail);
            this.pnlStep1.Controls.Add(this.txtEmail);
            this.pnlStep1.Controls.Add(this.pnlEmailLine);
            this.pnlStep1.Location = new System.Drawing.Point(0, 110); // Nằm dưới tiêu đề
            this.pnlStep1.Name = "pnlStep1";
            this.pnlStep1.Size = new System.Drawing.Size(420, 360);
            this.pnlStep1.TabIndex = 10;
            // 
            // lblEmailPrompt
            // 
            this.lblEmailPrompt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEmailPrompt.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmailPrompt.Location = new System.Drawing.Point(60, 20);
            this.lblEmailPrompt.Name = "lblEmailPrompt";
            this.lblEmailPrompt.Size = new System.Drawing.Size(300, 25);
            this.lblEmailPrompt.TabIndex = 15;
            this.lblEmailPrompt.Text = "Nhập email của bạn để lấy mã";
            this.lblEmailPrompt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblEmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblEmail.Location = new System.Drawing.Point(60, 70);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(57, 25);
            this.lblEmail.TabIndex = 1;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtEmail.Location = new System.Drawing.Point(60, 100);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(300, 27);
            this.txtEmail.TabIndex = 2;
            this.txtEmail.Enter += new System.EventHandler(this.txtEmail_Enter);
            this.txtEmail.Leave += new System.EventHandler(this.txtEmail_Leave);
            // 
            // pnlEmailLine
            // 
            this.pnlEmailLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlEmailLine.Location = new System.Drawing.Point(60, 127);
            this.pnlEmailLine.Name = "pnlEmailLine";
            this.pnlEmailLine.Size = new System.Drawing.Size(300, 2);
            this.pnlEmailLine.TabIndex = 12;
            // 
            // btnSubmitEmail
            // 
            this.btnSubmitEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnSubmitEmail.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSubmitEmail.FlatAppearance.BorderSize = 0;
            this.btnSubmitEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitEmail.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnSubmitEmail.ForeColor = System.Drawing.Color.White;
            this.btnSubmitEmail.Location = new System.Drawing.Point(60, 160);
            this.btnSubmitEmail.Name = "btnSubmitEmail";
            this.btnSubmitEmail.Size = new System.Drawing.Size(300, 50);
            this.btnSubmitEmail.TabIndex = 8;
            this.btnSubmitEmail.Text = "Gửi mã";
            this.btnSubmitEmail.UseVisualStyleBackColor = false;
            this.btnSubmitEmail.Click += new System.EventHandler(this.btnSubmitEmail_Click);
            // 
            // lnkBackToLogin1
            // 
            this.lnkBackToLogin1.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lnkBackToLogin1.BackColor = System.Drawing.Color.Transparent;
            this.lnkBackToLogin1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBackToLogin1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkBackToLogin1.LinkArea = new System.Windows.Forms.LinkArea(0, 18);
            this.lnkBackToLogin1.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBackToLogin1.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lnkBackToLogin1.Location = new System.Drawing.Point(60, 240);
            this.lnkBackToLogin1.Name = "lnkBackToLogin1";
            this.lnkBackToLogin1.Size = new System.Drawing.Size(300, 20);
            this.lnkBackToLogin1.TabIndex = 11;
            this.lnkBackToLogin1.TabStop = true;
            this.lnkBackToLogin1.Text = "Quay lại Đăng nhập";
            this.lnkBackToLogin1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkBackToLogin1.UseCompatibleTextRendering = true;
            this.lnkBackToLogin1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBackToLogin_LinkClicked);
            // 
            // pnlStep2
            // 
            this.pnlStep2.BackColor = System.Drawing.Color.Transparent;
            this.pnlStep2.Controls.Add(this.lblCode);
            this.pnlStep2.Controls.Add(this.txtCode);
            this.pnlStep2.Controls.Add(this.pnlCodeLine);
            this.pnlStep2.Controls.Add(this.lblNewPassword);
            this.pnlStep2.Controls.Add(this.pnlNewPasswordContainer);
            this.pnlStep2.Controls.Add(this.pnlNewPasswordLine);
            this.pnlStep2.Controls.Add(this.lblConfirmPassword);
            this.pnlStep2.Controls.Add(this.pnlConfirmPasswordContainer);
            this.pnlStep2.Controls.Add(this.pnlConfirmPasswordLine);
            this.pnlStep2.Controls.Add(this.btnResetPassword);
            this.pnlStep2.Controls.Add(this.lnkBackToLogin2);
            this.pnlStep2.Location = new System.Drawing.Point(0, 110);
            this.pnlStep2.Name = "pnlStep2";
            this.pnlStep2.Size = new System.Drawing.Size(420, 360);
            this.pnlStep2.TabIndex = 11;
            this.pnlStep2.Visible = false; // Ẩn Bước 2 ban đầu
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblCode.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblCode.Location = new System.Drawing.Point(60, 20);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(119, 25);
            this.lblCode.TabIndex = 16;
            this.lblCode.Text = "Mã xác nhận";
            // 
            // txtCode
            // 
            this.txtCode.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCode.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCode.Location = new System.Drawing.Point(60, 50);
            this.txtCode.Name = "txtCode";
            this.txtCode.Size = new System.Drawing.Size(300, 27);
            this.txtCode.TabIndex = 17;
            this.txtCode.Enter += new System.EventHandler(this.txtCode_Enter);
            this.txtCode.Leave += new System.EventHandler(this.txtCode_Leave);
            // 
            // pnlCodeLine
            // 
            this.pnlCodeLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlCodeLine.Location = new System.Drawing.Point(60, 77);
            this.pnlCodeLine.Name = "pnlCodeLine";
            this.pnlCodeLine.Size = new System.Drawing.Size(300, 2);
            this.pnlCodeLine.TabIndex = 18;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblNewPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNewPassword.Location = new System.Drawing.Point(60, 100);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(129, 25);
            this.lblNewPassword.TabIndex = 19;
            this.lblNewPassword.Text = "Mật khẩu mới";
            // 
            // pnlNewPasswordContainer
            // 
            this.pnlNewPasswordContainer.BackColor = System.Drawing.Color.White;
            this.pnlNewPasswordContainer.Controls.Add(this.btnShowHideNewPass);
            this.pnlNewPasswordContainer.Controls.Add(this.txtNewPassword);
            this.pnlNewPasswordContainer.Location = new System.Drawing.Point(60, 130);
            this.pnlNewPasswordContainer.Name = "pnlNewPasswordContainer";
            this.pnlNewPasswordContainer.Size = new System.Drawing.Size(300, 34);
            this.pnlNewPasswordContainer.TabIndex = 20;
            // 
            // btnShowHideNewPass
            // 
            this.btnShowHideNewPass.BackColor = System.Drawing.Color.White;
            this.btnShowHideNewPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHideNewPass.FlatAppearance.BorderSize = 0;
            this.btnShowHideNewPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideNewPass.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowHideNewPass.ForeColor = System.Drawing.Color.Gray;
            this.btnShowHideNewPass.Image = null;
            this.btnShowHideNewPass.Text = "👁️";
            this.btnShowHideNewPass.Location = new System.Drawing.Point(260, 2);
            this.btnShowHideNewPass.Name = "btnShowHideNewPass";
            this.btnShowHideNewPass.Size = new System.Drawing.Size(35, 30);
            this.btnShowHideNewPass.TabIndex = 1;
            this.btnShowHideNewPass.UseVisualStyleBackColor = false;
            this.btnShowHideNewPass.Click += new System.EventHandler(this.btnShowHideNewPass_Click);
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNewPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNewPassword.Location = new System.Drawing.Point(3, 3);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.PasswordChar = '•';
            this.txtNewPassword.Size = new System.Drawing.Size(255, 27);
            this.txtNewPassword.TabIndex = 0;
            this.txtNewPassword.Enter += new System.EventHandler(this.txtNewPassword_Enter);
            this.txtNewPassword.Leave += new System.EventHandler(this.txtNewPassword_Leave);
            // 
            // pnlNewPasswordLine
            // 
            this.pnlNewPasswordLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlNewPasswordLine.Location = new System.Drawing.Point(60, 164);
            this.pnlNewPasswordLine.Name = "pnlNewPasswordLine";
            this.pnlNewPasswordLine.Size = new System.Drawing.Size(300, 2);
            this.pnlNewPasswordLine.TabIndex = 21;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblConfirmPassword.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblConfirmPassword.Location = new System.Drawing.Point(60, 185);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(171, 25);
            this.lblConfirmPassword.TabIndex = 22;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // pnlConfirmPasswordContainer
            // 
            this.pnlConfirmPasswordContainer.BackColor = System.Drawing.Color.White;
            this.pnlConfirmPasswordContainer.Controls.Add(this.btnShowHideConfirmPass);
            this.pnlConfirmPasswordContainer.Controls.Add(this.txtConfirmPassword);
            this.pnlConfirmPasswordContainer.Location = new System.Drawing.Point(60, 215);
            this.pnlConfirmPasswordContainer.Name = "pnlConfirmPasswordContainer";
            this.pnlConfirmPasswordContainer.Size = new System.Drawing.Size(300, 34);
            this.pnlConfirmPasswordContainer.TabIndex = 23;
            // 
            // btnShowHideConfirmPass
            // 
            this.btnShowHideConfirmPass.BackColor = System.Drawing.Color.White;
            this.btnShowHideConfirmPass.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnShowHideConfirmPass.FlatAppearance.BorderSize = 0;
            this.btnShowHideConfirmPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowHideConfirmPass.Font = new System.Drawing.Font("Segoe UI Symbol", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnShowHideConfirmPass.ForeColor = System.Drawing.Color.Gray;
            this.btnShowHideConfirmPass.Image = null;
            this.btnShowHideConfirmPass.Text = "👁️";
            this.btnShowHideConfirmPass.Location = new System.Drawing.Point(260, 2);
            this.btnShowHideConfirmPass.Name = "btnShowHideConfirmPass";
            this.btnShowHideConfirmPass.Size = new System.Drawing.Size(35, 30);
            this.btnShowHideConfirmPass.TabIndex = 1;
            this.btnShowHideConfirmPass.UseVisualStyleBackColor = false;
            this.btnShowHideConfirmPass.Click += new System.EventHandler(this.btnShowHideConfirmPass_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConfirmPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtConfirmPassword.Location = new System.Drawing.Point(3, 3);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.PasswordChar = '•';
            this.txtConfirmPassword.Size = new System.Drawing.Size(255, 27);
            this.txtConfirmPassword.TabIndex = 0;
            this.txtConfirmPassword.Enter += new System.EventHandler(this.txtConfirmPassword_Enter);
            this.txtConfirmPassword.Leave += new System.EventHandler(this.txtConfirmPassword_Leave);
            // 
            // pnlConfirmPasswordLine
            // 
            this.pnlConfirmPasswordLine.BackColor = System.Drawing.Color.LightGray;
            this.pnlConfirmPasswordLine.Location = new System.Drawing.Point(60, 249);
            this.pnlConfirmPasswordLine.Name = "pnlConfirmPasswordLine";
            this.pnlConfirmPasswordLine.Size = new System.Drawing.Size(300, 2);
            this.pnlConfirmPasswordLine.TabIndex = 24;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnResetPassword.FlatAppearance.BorderSize = 0;
            this.btnResetPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnResetPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnResetPassword.ForeColor = System.Drawing.Color.White;
            this.btnResetPassword.Location = new System.Drawing.Point(60, 275);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(300, 50);
            this.btnResetPassword.TabIndex = 25;
            this.btnResetPassword.Text = "Xác nhận";
            this.btnResetPassword.UseVisualStyleBackColor = false;
            this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
            // 
            // lnkBackToLogin2
            // 
            this.lnkBackToLogin2.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(100)))), ((int)(((byte)(200)))));
            this.lnkBackToLogin2.BackColor = System.Drawing.Color.Transparent;
            this.lnkBackToLogin2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lnkBackToLogin2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkBackToLogin2.LinkArea = new System.Windows.Forms.LinkArea(0, 18);
            this.lnkBackToLogin2.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.lnkBackToLogin2.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.lnkBackToLogin2.Location = new System.Drawing.Point(60, 335);
            this.lnkBackToLogin2.Name = "lnkBackToLogin2";
            this.lnkBackToLogin2.Size = new System.Drawing.Size(300, 20);
            this.lnkBackToLogin2.TabIndex = 26;
            this.lnkBackToLogin2.TabStop = true;
            this.lnkBackToLogin2.Text = "Quay lại Đăng nhập";
            this.lnkBackToLogin2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkBackToLogin2.UseCompatibleTextRendering = true;
            this.lnkBackToLogin2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkBackToLogin_LinkClicked);
            // 
            // ForgotPasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 680);
            this.Controls.Add(this.pnlForgotPassword);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ForgotPasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Expense Manager - Quên Mật Khẩu";
            this.BackgroundImage = ExpenseManager.App.Properties.Resources.bglogin;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Load += new System.EventHandler(this.ForgotPasswordForm_Load);
            this.Resize += new System.EventHandler(this.ForgotPasswordForm_Load);
            this.pnlForgotPassword.ResumeLayout(false);
            this.pnlForgotPassword.PerformLayout();
            this.pnlStep1.ResumeLayout(false);
            this.pnlStep1.PerformLayout();
            this.pnlStep2.ResumeLayout(false);
            this.pnlStep2.PerformLayout();
            this.pnlNewPasswordContainer.ResumeLayout(false);
            this.pnlNewPasswordContainer.PerformLayout();
            this.pnlConfirmPasswordContainer.ResumeLayout(false);
            this.pnlConfirmPasswordContainer.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel pnlForgotPassword;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblError;

        // Step 1
        private System.Windows.Forms.Panel pnlStep1;
        private System.Windows.Forms.Label lblEmailPrompt;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Panel pnlEmailLine;
        private System.Windows.Forms.Button btnSubmitEmail;
        private System.Windows.Forms.LinkLabel lnkBackToLogin1;

        // Step 2
        private System.Windows.Forms.Panel pnlStep2;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Panel pnlCodeLine;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.Panel pnlNewPasswordContainer;
        private System.Windows.Forms.Button btnShowHideNewPass;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Panel pnlNewPasswordLine;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.Panel pnlConfirmPasswordContainer;
        private System.Windows.Forms.Button btnShowHideConfirmPass;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Panel pnlConfirmPasswordLine;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.LinkLabel lnkBackToLogin2;
    }
}