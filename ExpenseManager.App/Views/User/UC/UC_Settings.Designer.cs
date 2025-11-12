using System.Windows.Forms;
using System.Drawing;

namespace ExpenseManager.App.Views.User.UC
{
    partial class UC_Settings : UserControl
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

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSubtitle = new Label();
            tabMain = new TabControl();
            tabProfile = new TabPage();
            panelUserProfileLeft = new Panel();
            textBox1 = new TextBox();
            lblUserProfileLeft = new Label();
            lblFullNameLeft = new Label();
            txtFullNameLeft = new TextBox();
            picAvatar = new PictureBox();
            btnBrowse = new Button();
            lblMaxFile = new Label();
            btnSaveLeft = new Button();
            panelUserProfileRight = new Panel();
            lblUserProfileRight = new Label();
            lblNewEmail = new Label();
            txtNewEmail = new TextBox();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            btnSaveRight = new Button();
            panelPersonalInfo = new Panel();
            lblPersonalInfo = new Label();
            lblFullNamePersonal = new Label();
            txtFullNamePersonal = new TextBox();
            lblEmailPersonal = new Label();
            txtEmailPersonal = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblCity = new Label();
            txtCity = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblCountry = new Label();
            cboCountry = new ComboBox();
            btnSavePersonal = new Button();
            tabCategories = new TabPage();
            tabSupport = new TabPage();
            tabMain.SuspendLayout();
            tabProfile.SuspendLayout();
            panelUserProfileLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).BeginInit();
            panelUserProfileRight.SuspendLayout();
            panelPersonalInfo.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.Location = new Point(20, 11);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(235, 53);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Profile";
            // 
            // lblSubtitle
            // 
            lblSubtitle.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(20, 59);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(331, 31);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // tabMain
            // 
            tabMain.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabMain.Controls.Add(tabProfile);
            tabMain.Controls.Add(tabCategories);
            tabMain.Controls.Add(tabSupport);
            tabMain.Font = new Font("Segoe UI", 10F);
            tabMain.Location = new Point(20, 116);
            tabMain.Name = "tabMain";
            tabMain.SelectedIndex = 0;
            tabMain.Size = new Size(1311, 639);
            tabMain.TabIndex = 2;
            // 
            // tabProfile
            // 
            tabProfile.BackColor = Color.FromArgb(249, 250, 251);
            tabProfile.Controls.Add(panelUserProfileLeft);
            tabProfile.Controls.Add(panelUserProfileRight);
            tabProfile.Controls.Add(panelPersonalInfo);
            tabProfile.Location = new Point(4, 32);
            tabProfile.Name = "tabProfile";
            tabProfile.Size = new Size(1303, 603); // Tăng chiều cao để chứa panel con
            tabProfile.TabIndex = 0;
            tabProfile.Text = "Profile";
            // 
            // panelUserProfileLeft
            // 
            panelUserProfileLeft.Anchor = AnchorStyles.Top | AnchorStyles.Left; // CHỈ Neo Left/Top
            panelUserProfileLeft.BackColor = Color.White;
            panelUserProfileLeft.BorderStyle = BorderStyle.FixedSingle;
            panelUserProfileLeft.Controls.Add(textBox1);
            panelUserProfileLeft.Controls.Add(lblUserProfileLeft);
            panelUserProfileLeft.Controls.Add(lblFullNameLeft);
            panelUserProfileLeft.Controls.Add(txtFullNameLeft);
            panelUserProfileLeft.Controls.Add(picAvatar);
            panelUserProfileLeft.Controls.Add(btnBrowse);
            panelUserProfileLeft.Controls.Add(lblMaxFile);
            panelUserProfileLeft.Controls.Add(btnSaveLeft);
            panelUserProfileLeft.Location = new Point(20, 20);
            panelUserProfileLeft.Name = "panelUserProfileLeft";
            panelUserProfileLeft.Size = new Size(621, 250); // Chiều rộng 621
            panelUserProfileLeft.TabIndex = 0;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(428, 145);
            textBox1.Name = "textBox1";
            textBox1.ReadOnly = true;
            textBox1.Size = new Size(173, 30); // Giảm size
            textBox1.TabIndex = 7;
            // 
            // lblUserProfileLeft
            // 
            lblUserProfileLeft.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserProfileLeft.Location = new Point(10, 10);
            lblUserProfileLeft.Name = "lblUserProfileLeft";
            lblUserProfileLeft.Size = new Size(200, 37);
            lblUserProfileLeft.TabIndex = 0;
            lblUserProfileLeft.Text = "User Profile";
            // 
            // lblFullNameLeft
            // 
            lblFullNameLeft.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblFullNameLeft.Location = new Point(30, 70);
            lblFullNameLeft.Name = "lblFullNameLeft";
            lblFullNameLeft.Size = new Size(180, 34);
            lblFullNameLeft.TabIndex = 1;
            lblFullNameLeft.Text = "Full Name";
            // 
            // txtFullNameLeft
            // 
            txtFullNameLeft.Location = new Point(30, 123);
            txtFullNameLeft.Name = "txtFullNameLeft";
            txtFullNameLeft.Size = new Size(296, 30);
            txtFullNameLeft.TabIndex = 2;
            // 
            // picAvatar
            // 
            picAvatar.BorderStyle = BorderStyle.FixedSingle;
            picAvatar.Location = new Point(470, 10); // Điều chỉnh X
            picAvatar.Name = "picAvatar";
            picAvatar.Size = new Size(131, 129);
            picAvatar.SizeMode = PictureBoxSizeMode.Zoom;
            picAvatar.TabIndex = 3;
            picAvatar.TabStop = false;
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(486, 182);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(110, 30);
            btnBrowse.TabIndex = 4;
            btnBrowse.Text = "Browse";
            // 
            // lblMaxFile
            // 
            lblMaxFile.Font = new Font("Segoe UI", 8F);
            lblMaxFile.ForeColor = Color.Gray;
            lblMaxFile.Location = new Point(470, 215); // Điều chỉnh X
            lblMaxFile.Name = "lblMaxFile";
            lblMaxFile.Size = new Size(145, 23);
            lblMaxFile.TabIndex = 5;
            lblMaxFile.Text = "Max file size is 20mb";
            lblMaxFile.TextAlign = ContentAlignment.TopCenter;
            // 
            // btnSaveLeft
            // 
            btnSaveLeft.BackColor = Color.RoyalBlue;
            btnSaveLeft.FlatStyle = FlatStyle.Flat;
            btnSaveLeft.ForeColor = Color.White;
            btnSaveLeft.Location = new Point(30, 183);
            btnSaveLeft.Name = "btnSaveLeft";
            btnSaveLeft.Size = new Size(86, 47);
            btnSaveLeft.TabIndex = 6;
            btnSaveLeft.Text = "Save";
            btnSaveLeft.UseVisualStyleBackColor = false;
            // 
            // panelUserProfileRight
            // 
            panelUserProfileRight.Anchor = AnchorStyles.Top | AnchorStyles.Right; // CHỈ Neo Top/Right
            panelUserProfileRight.BackColor = Color.White;
            panelUserProfileRight.BorderStyle = BorderStyle.FixedSingle;
            panelUserProfileRight.Controls.Add(lblUserProfileRight);
            panelUserProfileRight.Controls.Add(lblNewEmail);
            panelUserProfileRight.Controls.Add(txtNewEmail);
            panelUserProfileRight.Controls.Add(lblNewPassword);
            panelUserProfileRight.Controls.Add(txtNewPassword);
            panelUserProfileRight.Controls.Add(btnSaveRight);
            panelUserProfileRight.Location = new Point(662, 20); // Vị trí X mới
            panelUserProfileRight.Name = "panelUserProfileRight";
            panelUserProfileRight.Size = new Size(621, 250); // Chiều rộng 621
            panelUserProfileRight.TabIndex = 1;
            // 
            // lblUserProfileRight
            // 
            lblUserProfileRight.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblUserProfileRight.Location = new Point(10, 10);
            lblUserProfileRight.Name = "lblUserProfileRight";
            lblUserProfileRight.Size = new Size(261, 37);
            lblUserProfileRight.TabIndex = 0;
            lblUserProfileRight.Text = "User Profile";
            // 
            // lblNewEmail
            // 
            lblNewEmail.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewEmail.Location = new Point(21, 70);
            lblNewEmail.Name = "lblNewEmail";
            lblNewEmail.Size = new Size(270, 34); // Width 270
            lblNewEmail.TabIndex = 1;
            lblNewEmail.Text = "New Email";
            // 
            // txtNewEmail
            // 
            txtNewEmail.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Neo Left
            txtNewEmail.Location = new Point(21, 124);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(270, 30); // Width 270
            txtNewEmail.TabIndex = 2;
            // 
            // lblNewPassword
            // 
            lblNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            lblNewPassword.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNewPassword.Location = new Point(330, 70); // Vị trí X 330
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(270, 34); // Width 270
            lblNewPassword.TabIndex = 3;
            lblNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            txtNewPassword.Location = new Point(330, 123); // Vị trí X 330
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.PasswordChar = '*';
            txtNewPassword.Size = new Size(270, 30); // Width 270
            txtNewPassword.TabIndex = 4;
            // 
            // btnSaveRight
            // 
            btnSaveRight.BackColor = Color.RoyalBlue;
            btnSaveRight.FlatStyle = FlatStyle.Flat;
            btnSaveRight.ForeColor = Color.White;
            btnSaveRight.Location = new Point(21, 183);
            btnSaveRight.Name = "btnSaveRight";
            btnSaveRight.Size = new Size(86, 47);
            btnSaveRight.TabIndex = 5;
            btnSaveRight.Text = "Save";
            btnSaveRight.UseVisualStyleBackColor = false;
            // 
            // panelPersonalInfo
            // 
            panelPersonalInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right; // Neo 4 góc
            panelPersonalInfo.BackColor = Color.White;
            panelPersonalInfo.BorderStyle = BorderStyle.FixedSingle;
            panelPersonalInfo.Controls.Add(lblPersonalInfo);
            panelPersonalInfo.Controls.Add(lblFullNamePersonal);
            panelPersonalInfo.Controls.Add(txtFullNamePersonal);
            panelPersonalInfo.Controls.Add(lblEmailPersonal);
            panelPersonalInfo.Controls.Add(txtEmailPersonal);
            panelPersonalInfo.Controls.Add(lblAddress);
            panelPersonalInfo.Controls.Add(txtAddress);
            panelPersonalInfo.Controls.Add(lblCity);
            panelPersonalInfo.Controls.Add(txtCity);
            panelPersonalInfo.Controls.Add(lblBirthDate);
            panelPersonalInfo.Controls.Add(dtpBirthDate);
            panelPersonalInfo.Controls.Add(lblCountry);
            panelPersonalInfo.Controls.Add(cboCountry);
            panelPersonalInfo.Controls.Add(btnSavePersonal);
            panelPersonalInfo.Location = new Point(20, 302); // Tăng Y (khoảng cách 32px)
            panelPersonalInfo.Name = "panelPersonalInfo";
            panelPersonalInfo.Size = new Size(1263, 340); // Tăng chiều cao
            panelPersonalInfo.TabIndex = 2;
            // 
            // lblPersonalInfo
            // 
            lblPersonalInfo.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblPersonalInfo.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPersonalInfo.Location = new Point(0, 17);
            lblPersonalInfo.Name = "lblPersonalInfo";
            lblPersonalInfo.Size = new Size(1263, 47);
            lblPersonalInfo.TabIndex = 0;
            lblPersonalInfo.Text = "Personal Information";
            lblPersonalInfo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblFullNamePersonal
            // 
            lblFullNamePersonal.Font = new Font("Segoe UI", 13.8F);
            lblFullNamePersonal.Location = new Point(37, 106); // Y = 106 (tăng 20px)
            lblFullNamePersonal.Name = "lblFullNamePersonal";
            lblFullNamePersonal.Size = new Size(150, 34);
            lblFullNamePersonal.TabIndex = 1;
            lblFullNamePersonal.Text = "Full Name";
            // 
            // txtFullNamePersonal
            // 
            txtFullNamePersonal.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Neo Left
            txtFullNamePersonal.Location = new Point(197, 113); // Y = 113
            txtFullNamePersonal.Name = "txtFullNamePersonal";
            txtFullNamePersonal.Size = new Size(420, 30); // Width 420
            txtFullNamePersonal.TabIndex = 2;
            // 
            // lblEmailPersonal
            // 
            lblEmailPersonal.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            lblEmailPersonal.Font = new Font("Segoe UI", 13.8F);
            lblEmailPersonal.Location = new Point(700, 106); // Y = 106, X = 700
            lblEmailPersonal.Name = "lblEmailPersonal";
            lblEmailPersonal.Size = new Size(100, 34);
            lblEmailPersonal.TabIndex = 3;
            lblEmailPersonal.Text = "Email";
            // 
            // txtEmailPersonal
            // 
            txtEmailPersonal.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            txtEmailPersonal.Location = new Point(810, 113); // Y = 113, X = 810
            txtEmailPersonal.Name = "txtEmailPersonal";
            txtEmailPersonal.Size = new Size(420, 30); // Width 420
            txtEmailPersonal.TabIndex = 4;
            // 
            // lblAddress
            // 
            lblAddress.Font = new Font("Segoe UI", 13.8F);
            lblAddress.Location = new Point(37, 176); // Y = 176 (tăng 20px)
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(150, 34);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Left; // Neo Left
            txtAddress.Location = new Point(197, 183); // Y = 183
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(420, 30); // Width 420
            txtAddress.TabIndex = 6;
            // 
            // lblCity
            // 
            lblCity.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            lblCity.Font = new Font("Segoe UI", 13.8F);
            lblCity.Location = new Point(700, 176); // Y = 176, X = 700
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(100, 34);
            lblCity.TabIndex = 7;
            lblCity.Text = "City";
            // 
            // txtCity
            // 
            txtCity.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            txtCity.Location = new Point(810, 183); // Y = 183, X = 810
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(420, 30); // Width 420
            txtCity.TabIndex = 8;
            // 
            // lblBirthDate
            // 
            lblBirthDate.Font = new Font("Segoe UI", 13.8F);
            lblBirthDate.Location = new Point(37, 247); // Y = 247 (tăng 20px)
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(150, 34);
            lblBirthDate.TabIndex = 9;
            lblBirthDate.Text = "Birth of date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.Location = new Point(197, 247); // Y = 247
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(420, 30); // Width 420
            dtpBirthDate.TabIndex = 10;
            // 
            // lblCountry
            // 
            lblCountry.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            lblCountry.Font = new Font("Segoe UI", 13.8F);
            lblCountry.Location = new Point(700, 247); // Y = 247, X = 700
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(100, 34);
            lblCountry.TabIndex = 11;
            lblCountry.Text = "Country";
            // 
            // cboCountry
            // 
            cboCountry.Anchor = AnchorStyles.Top | AnchorStyles.Right; // Neo Right
            cboCountry.Location = new Point(810, 246); // Y = 246, X = 810
            cboCountry.Name = "cboCountry";
            cboCountry.Size = new Size(420, 31); // Width 420
            cboCountry.TabIndex = 12;
            // 
            // btnSavePersonal
            // 
            btnSavePersonal.Anchor = AnchorStyles.Bottom; // CHỈ Neo Bottom
            btnSavePersonal.BackColor = Color.RoyalBlue;
            btnSavePersonal.FlatStyle = FlatStyle.Flat;
            btnSavePersonal.ForeColor = Color.White;
            btnSavePersonal.Location = new Point(588, 290); // Vị trí X = 588 (Căn giữa), Y = 290
            btnSavePersonal.Name = "btnSavePersonal";
            btnSavePersonal.Size = new Size(86, 47);
            btnSavePersonal.TabIndex = 13;
            btnSavePersonal.Text = "Save";
            btnSavePersonal.UseVisualStyleBackColor = false;
            // 
            // tabCategories
            // 
            tabCategories.Location = new Point(4, 32);
            tabCategories.Name = "tabCategories";
            tabCategories.Size = new Size(1303, 567);
            tabCategories.TabIndex = 1;
            tabCategories.Text = "Categories";
            // 
            // tabSupport
            // 
            tabSupport.Location = new Point(4, 32);
            tabSupport.Name = "tabSupport";
            tabSupport.Size = new Size(1303, 567);
            tabSupport.TabIndex = 2;
            tabSupport.Text = "Support";
            // 
            // UC_Settings
            // 
            AutoScaleDimensions = new SizeF(9F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(249, 250, 251);
            Controls.Add(lblTitle);
            Controls.Add(lblSubtitle);
            Controls.Add(tabMain);
            Font = new Font("Segoe UI", 10F);
            Name = "UC_Settings";
            Size = new Size(1361, 785);
            tabMain.ResumeLayout(false);
            tabProfile.ResumeLayout(false);
            panelUserProfileLeft.ResumeLayout(false);
            panelUserProfileLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picAvatar).EndInit();
            panelUserProfileRight.ResumeLayout(false);
            panelUserProfileRight.PerformLayout();
            panelPersonalInfo.ResumeLayout(false);
            panelPersonalInfo.PerformLayout();
            ResumeLayout(false);
        }

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabCategories;
        private System.Windows.Forms.TabPage tabSupport;

        private System.Windows.Forms.Panel panelUserProfileLeft;
        private System.Windows.Forms.Panel panelUserProfileRight;
        private System.Windows.Forms.Panel panelPersonalInfo;

        private System.Windows.Forms.Label lblUserProfileLeft;
        private System.Windows.Forms.Label lblFullNameLeft;
        private System.Windows.Forms.TextBox txtFullNameLeft;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Label lblMaxFile;
        private System.Windows.Forms.Button btnSaveLeft;

        private System.Windows.Forms.Label lblUserProfileRight;
        private System.Windows.Forms.Label lblNewEmail;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Button btnSaveRight;

        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.TextBox txtFullNamePersonal;
        private System.Windows.Forms.TextBox txtEmailPersonal;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.ComboBox cboCountry;
        private System.Windows.Forms.Button btnSavePersonal;

        private System.Windows.Forms.Label lblFullNamePersonal;
        private System.Windows.Forms.Label lblEmailPersonal;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.Label lblCountry;
        private TextBox textBox1;
    }
}

