using System.Windows.Forms;
using System.Drawing;

namespace ExpenseManager.App.Views.User.UC
{
    partial class UC_Settings
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                _presenter?.Dispose();
                _categoryPresenter?.Dispose(); // Thêm
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            mainPanel = new Panel();
            personalInfoPanel = new Panel();
            lblPersonalInfo = new Label();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblCity = new Label();
            txtCity = new TextBox();
            lblBirthDate = new Label();
            dtpBirthDate = new DateTimePicker();
            lblCountry = new Label();
            cmbCountry = new ComboBox();
            btnSavePersonal = new Button();
            topPanel = new Panel();
            profilePanel = new Panel();
            lblUserProfile = new Label();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblCurrentEmail = new Label();
            txtCurrentEmail = new TextBox();
            picProfile = new PictureBox();
            lblProfileName = new Label();
            lblMaxFileSize = new Label();
            btnBrowse = new Button();
            btnSaveProfile = new Button();
            passwordPanel = new Panel();
            lblUserProfilePass = new Label();
            lblNewEmail = new Label();
            txtNewEmail = new TextBox();
            lblCurrentPassword = new Label();
            txtCurrentPassword = new TextBox();
            btnTogglePassword = new Button();
            lblNewPassword = new Label();
            txtNewPassword = new TextBox();
            lblConfirmPassword = new Label();
            txtConfirmPassword = new TextBox();
            btnSavePassword = new Button();
            headerPanel = new Panel();
            lblTitle = new Label();
            lblSubtitle = new Label();
            breadcrumbPanel = new Panel();
            lblSettings = new Label();
            lblArrow = new Label();
            lblProfile = new Label();
            tabPanel = new Panel();
            lblTabProfile = new Label();
            lblTabCategories = new Label();
            lblTabSupport = new Label();
            categoriesPanel = new Panel();
            pnlCategoryLists = new Panel();
            flpExpenseCategories = new FlowLayoutPanel();
            lblExpenseCategories = new Label();
            flpIncomeCategories = new FlowLayoutPanel();
            lblIncomeCategories = new Label();
            createCategoryPanel = new Panel();
            lblCreateCategoryTitle = new Label();
            lblCategoryName = new Label();
            txtCategoryName = new TextBox();
            lblCategoryType = new Label();
            cmbCategoryType = new ComboBox();
            lblCategoryIcon = new Label();
            cmbIcon = new ComboBox();
            lblCategoryColor = new Label();
            cmbColor = new ComboBox();
            flpColorPicker = new FlowLayoutPanel();
            btnSaveCategory = new Button();
            mainPanel.SuspendLayout();
            personalInfoPanel.SuspendLayout();
            topPanel.SuspendLayout();
            profilePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).BeginInit();
            passwordPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            breadcrumbPanel.SuspendLayout();
            tabPanel.SuspendLayout();
            categoriesPanel.SuspendLayout();
            pnlCategoryLists.SuspendLayout();
            createCategoryPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(245, 247, 250);
            mainPanel.Controls.Add(personalInfoPanel);
            mainPanel.Controls.Add(topPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(tabPanel);
            mainPanel.Controls.Add(categoriesPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(30, 20, 30, 20);
            mainPanel.Size = new Size(1463, 1154);
            mainPanel.TabIndex = 0;
            // 
            // personalInfoPanel
            // 
            personalInfoPanel.BackColor = Color.White;
            personalInfoPanel.Controls.Add(lblPersonalInfo);
            personalInfoPanel.Controls.Add(lblAddress);
            personalInfoPanel.Controls.Add(txtAddress);
            personalInfoPanel.Controls.Add(lblCity);
            personalInfoPanel.Controls.Add(txtCity);
            personalInfoPanel.Controls.Add(lblBirthDate);
            personalInfoPanel.Controls.Add(dtpBirthDate);
            personalInfoPanel.Controls.Add(lblCountry);
            personalInfoPanel.Controls.Add(cmbCountry);
            personalInfoPanel.Controls.Add(btnSavePersonal);
            personalInfoPanel.Location = new Point(40, 790);
            personalInfoPanel.Margin = new Padding(4, 5, 4, 5);
            personalInfoPanel.Name = "personalInfoPanel";
            personalInfoPanel.Size = new Size(1387, 389);
            personalInfoPanel.TabIndex = 3;
            // 
            // lblPersonalInfo
            // 
            lblPersonalInfo.AutoSize = true;
            lblPersonalInfo.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblPersonalInfo.ForeColor = Color.FromArgb(51, 51, 51);
            lblPersonalInfo.Location = new Point(40, 38);
            lblPersonalInfo.Margin = new Padding(4, 0, 4, 0);
            lblPersonalInfo.Name = "lblPersonalInfo";
            lblPersonalInfo.Size = new Size(242, 32);
            lblPersonalInfo.TabIndex = 0;
            lblPersonalInfo.Text = "Personal Information";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Segoe UI", 10F);
            lblAddress.ForeColor = Color.FromArgb(102, 102, 102);
            lblAddress.Location = new Point(40, 108);
            lblAddress.Margin = new Padding(4, 0, 4, 0);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(70, 23);
            lblAddress.TabIndex = 1;
            lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            txtAddress.BorderStyle = BorderStyle.FixedSingle;
            txtAddress.Font = new Font("Segoe UI", 10F);
            txtAddress.Location = new Point(40, 146);
            txtAddress.Margin = new Padding(4, 5, 4, 5);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(599, 30);
            txtAddress.TabIndex = 2;
            // 
            // lblCity
            // 
            lblCity.AutoSize = true;
            lblCity.Font = new Font("Segoe UI", 10F);
            lblCity.ForeColor = Color.FromArgb(102, 102, 102);
            lblCity.Location = new Point(707, 108);
            lblCity.Margin = new Padding(4, 0, 4, 0);
            lblCity.Name = "lblCity";
            lblCity.Size = new Size(39, 23);
            lblCity.TabIndex = 3;
            lblCity.Text = "City";
            // 
            // txtCity
            // 
            txtCity.BorderStyle = BorderStyle.FixedSingle;
            txtCity.Font = new Font("Segoe UI", 10F);
            txtCity.Location = new Point(707, 146);
            txtCity.Margin = new Padding(4, 5, 4, 5);
            txtCity.Name = "txtCity";
            txtCity.Size = new Size(599, 30);
            txtCity.TabIndex = 4;
            // 
            // lblBirthDate
            // 
            lblBirthDate.AutoSize = true;
            lblBirthDate.Font = new Font("Segoe UI", 10F);
            lblBirthDate.ForeColor = Color.FromArgb(102, 102, 102);
            lblBirthDate.Location = new Point(40, 215);
            lblBirthDate.Margin = new Padding(4, 0, 4, 0);
            lblBirthDate.Name = "lblBirthDate";
            lblBirthDate.Size = new Size(105, 23);
            lblBirthDate.TabIndex = 5;
            lblBirthDate.Text = "Birth of date";
            // 
            // dtpBirthDate
            // 
            dtpBirthDate.CustomFormat = "dd/MM/yyyy";
            dtpBirthDate.Font = new Font("Segoe UI", 10F);
            dtpBirthDate.Format = DateTimePickerFormat.Custom;
            dtpBirthDate.Location = new Point(40, 254);
            dtpBirthDate.Margin = new Padding(4, 5, 4, 5);
            dtpBirthDate.Name = "dtpBirthDate";
            dtpBirthDate.Size = new Size(599, 30);
            dtpBirthDate.TabIndex = 6;
            // 
            // lblCountry
            // 
            lblCountry.AutoSize = true;
            lblCountry.Font = new Font("Segoe UI", 10F);
            lblCountry.ForeColor = Color.FromArgb(102, 102, 102);
            lblCountry.Location = new Point(707, 215);
            lblCountry.Margin = new Padding(4, 0, 4, 0);
            lblCountry.Name = "lblCountry";
            lblCountry.Size = new Size(71, 23);
            lblCountry.TabIndex = 7;
            lblCountry.Text = "Country";
            // 
            // cmbCountry
            // 
            cmbCountry.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCountry.Font = new Font("Segoe UI", 10F);
            cmbCountry.FormattingEnabled = true;
            cmbCountry.Items.AddRange(new object[] { "Afghanistan", "Albania", "Algeria", "Andorra", "Angola", "Antigua and Barbuda", "Argentina", "Armenia", "Australia", "Austria", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Belgium", "Belize", "Benin", "Bhutan", "Bolivia", "Bosnia and Herzegovina", "Botswana", "Brazil", "Brunei", "Bulgaria", "Burkina Faso", "Burundi", "Cabo Verde", "Cambodia", "Cameroon", "Canada", "Central African Republic", "Chad", "Chile", "China", "Colombia", "Comoros", "Congo (Congo-Brazzaville)", "Costa Rica", "Côte d'Ivoire", "Croatia", "Cuba", "Cyprus", "Czechia (Czech Republic)", "Democratic Republic of the Congo", "Denmark", "Djibouti", "Dominica", "Dominican Republic", "Ecuador", "Egypt", "El Salvador", "Equatorial Guinea", "Eritrea", "Estonia", "Eswatini (fmr. \"Swaziland\")", "Ethiopia", "Fiji", "Finland", "France", "Gabon", "Gambia", "Georgia", "Germany", "Ghana", "Greece", "Grenada", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Holy See", "Honduras", "Hungary", "Iceland", "India", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Jamaica", "Japan", "Jordan", "Kazakhstan", "Kenya", "Kiribati", "Kuwait", "Kyrgyzstan", "Laos", "Latvia", "Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Madagascar", "Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Mauritania", "Mauritius", "Mexico", "Micronesia", "Moldova", "Monaco", "Mongolia", "Montenegro", "Morocco", "Mozambique", "Myanmar (formerly Burma)", "Namibia", "Nauru", "Nepal", "Netherlands", "New Zealand", "Nicaragua", "Niger", "Nigeria", "North Korea", "North Macedonia", "Norway", "Oman", "Pakistan", "Palau", "Palestine State", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland", "Portugal", "Qatar", "Romania", "Russia", "Rwanda", "Saint Kitts and Nevis", "Saint Lucia", "Saint Vincent and the Grenadines", "Samoa", "San Marino", "Sao Tome and Principe", "Saudi Arabia", "Senegal", "Serbia", "Seychelles", "Sierra Leone", "Singapore", "Slovakia", "Slovenia", "Solomon Islands", "Somalia", "South Africa", "South Korea", "South Sudan", "Spain", "Sri Lanka", "Sudan", "Suriname", "Sweden", "Switzerland", "Syria", "Tajikistan", "Tanzania", "Thailand", "Timor-Leste", "Togo", "Tonga", "Trinidad and Tobago", "Tunisia", "Turkey", "Turkmenistan", "Tuvalu", "Uganda", "Ukraine", "United Arab Emirates", "United Kingdom", "United States of America", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam", "Yemen", "Zambia", "Zimbabwe" });
            cmbCountry.Location = new Point(707, 254);
            cmbCountry.Margin = new Padding(4, 5, 4, 5);
            cmbCountry.MaxDropDownItems = 15;
            cmbCountry.Name = "cmbCountry";
            cmbCountry.Size = new Size(599, 31);
            cmbCountry.TabIndex = 8;
            // 
            // btnSavePersonal
            // 
            btnSavePersonal.BackColor = Color.FromArgb(0, 112, 243);
            btnSavePersonal.Cursor = Cursors.Hand;
            btnSavePersonal.FlatAppearance.BorderSize = 0;
            btnSavePersonal.FlatStyle = FlatStyle.Flat;
            btnSavePersonal.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSavePersonal.ForeColor = Color.White;
            btnSavePersonal.Location = new Point(40, 338);
            btnSavePersonal.Margin = new Padding(4, 5, 4, 5);
            btnSavePersonal.Name = "btnSavePersonal";
            btnSavePersonal.Size = new Size(133, 58);
            btnSavePersonal.TabIndex = 9;
            btnSavePersonal.Text = "Save";
            btnSavePersonal.UseVisualStyleBackColor = false;
            btnSavePersonal.Click += BtnSavePersonal_Click;
            // 
            // topPanel
            // 
            topPanel.Controls.Add(profilePanel);
            topPanel.Controls.Add(passwordPanel);
            topPanel.Location = new Point(40, 215);
            topPanel.Margin = new Padding(4, 5, 4, 5);
            topPanel.Name = "topPanel";
            topPanel.Size = new Size(1387, 544);
            topPanel.TabIndex = 2;
            // 
            // profilePanel
            // 
            profilePanel.BackColor = Color.White;
            profilePanel.Controls.Add(lblUserProfile);
            profilePanel.Controls.Add(lblFullName);
            profilePanel.Controls.Add(txtFullName);
            profilePanel.Controls.Add(lblCurrentEmail);
            profilePanel.Controls.Add(txtCurrentEmail);
            profilePanel.Controls.Add(picProfile);
            profilePanel.Controls.Add(lblProfileName);
            profilePanel.Controls.Add(lblMaxFileSize);
            profilePanel.Controls.Add(btnBrowse);
            profilePanel.Controls.Add(btnSaveProfile);
            profilePanel.Location = new Point(0, 0);
            profilePanel.Margin = new Padding(4, 5, 4, 5);
            profilePanel.Name = "profilePanel";
            profilePanel.Size = new Size(673, 544);
            profilePanel.TabIndex = 0;
            // 
            // lblUserProfile
            // 
            lblUserProfile.AutoSize = true;
            lblUserProfile.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblUserProfile.ForeColor = Color.FromArgb(51, 51, 51);
            lblUserProfile.Location = new Point(33, 31);
            lblUserProfile.Margin = new Padding(4, 0, 4, 0);
            lblUserProfile.Name = "lblUserProfile";
            lblUserProfile.Size = new Size(140, 32);
            lblUserProfile.TabIndex = 0;
            lblUserProfile.Text = "User Profile";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Font = new Font("Segoe UI", 10F);
            lblFullName.ForeColor = Color.FromArgb(102, 102, 102);
            lblFullName.Location = new Point(33, 92);
            lblFullName.Margin = new Padding(4, 0, 4, 0);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(87, 23);
            lblFullName.TabIndex = 1;
            lblFullName.Text = "Full Name";
            // 
            // txtFullName
            // 
            txtFullName.BorderStyle = BorderStyle.FixedSingle;
            txtFullName.Font = new Font("Segoe UI", 10F);
            txtFullName.Location = new Point(33, 131);
            txtFullName.Margin = new Padding(4, 5, 4, 5);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(606, 30);
            txtFullName.TabIndex = 2;
            // 
            // lblCurrentEmail
            // 
            lblCurrentEmail.AutoSize = true;
            lblCurrentEmail.Font = new Font("Segoe UI", 10F);
            lblCurrentEmail.ForeColor = Color.FromArgb(102, 102, 102);
            lblCurrentEmail.Location = new Point(33, 192);
            lblCurrentEmail.Margin = new Padding(4, 0, 4, 0);
            lblCurrentEmail.Name = "lblCurrentEmail";
            lblCurrentEmail.Size = new Size(114, 23);
            lblCurrentEmail.TabIndex = 3;
            lblCurrentEmail.Text = "Current Email";
            // 
            // txtCurrentEmail
            // 
            txtCurrentEmail.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentEmail.Font = new Font("Segoe UI", 10F);
            txtCurrentEmail.Location = new Point(33, 231);
            txtCurrentEmail.Margin = new Padding(4, 5, 4, 5);
            txtCurrentEmail.Name = "txtCurrentEmail";
            txtCurrentEmail.ReadOnly = true;
            txtCurrentEmail.Size = new Size(606, 30);
            txtCurrentEmail.TabIndex = 4;
            // 
            // picProfile
            // 
            picProfile.BackColor = Color.FromArgb(79, 195, 247);
            picProfile.Location = new Point(33, 292);
            picProfile.Margin = new Padding(4, 5, 4, 5);
            picProfile.Name = "picProfile";
            picProfile.Size = new Size(67, 77);
            picProfile.TabIndex = 5;
            picProfile.TabStop = false;
            // 
            // lblProfileName
            // 
            lblProfileName.AutoSize = true;
            lblProfileName.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblProfileName.Location = new Point(113, 300);
            lblProfileName.Margin = new Padding(4, 0, 4, 0);
            lblProfileName.Name = "lblProfileName";
            lblProfileName.Size = new Size(116, 23);
            lblProfileName.TabIndex = 6;
            lblProfileName.Text = "Âu Dương Tải";
            // 
            // lblMaxFileSize
            // 
            lblMaxFileSize.AutoSize = true;
            lblMaxFileSize.Font = new Font("Segoe UI", 9F);
            lblMaxFileSize.ForeColor = Color.Gray;
            lblMaxFileSize.Location = new Point(113, 331);
            lblMaxFileSize.Margin = new Padding(4, 0, 4, 0);
            lblMaxFileSize.Name = "lblMaxFileSize";
            lblMaxFileSize.Size = new Size(147, 20);
            lblMaxFileSize.TabIndex = 7;
            lblMaxFileSize.Text = "Max file size is 20mb";
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.WhiteSmoke;
            btnBrowse.Cursor = Cursors.Hand;
            btnBrowse.FlatAppearance.BorderColor = Color.FromArgb(200, 200, 200);
            btnBrowse.FlatStyle = FlatStyle.Flat;
            btnBrowse.Font = new Font("Segoe UI", 9F);
            btnBrowse.ForeColor = Color.CornflowerBlue;
            btnBrowse.Location = new Point(484, 312);
            btnBrowse.Margin = new Padding(4, 5, 4, 5);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(107, 49);
            btnBrowse.TabIndex = 9;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // btnSaveProfile
            // 
            btnSaveProfile.BackColor = Color.FromArgb(0, 112, 243);
            btnSaveProfile.Cursor = Cursors.Hand;
            btnSaveProfile.FlatAppearance.BorderSize = 0;
            btnSaveProfile.FlatStyle = FlatStyle.Flat;
            btnSaveProfile.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSaveProfile.ForeColor = Color.White;
            btnSaveProfile.Location = new Point(33, 415);
            btnSaveProfile.Margin = new Padding(4, 5, 4, 5);
            btnSaveProfile.Name = "btnSaveProfile";
            btnSaveProfile.Size = new Size(133, 58);
            btnSaveProfile.TabIndex = 10;
            btnSaveProfile.Text = "Save";
            btnSaveProfile.UseVisualStyleBackColor = false;
            btnSaveProfile.Click += BtnSaveProfile_Click;
            // 
            // passwordPanel
            // 
            passwordPanel.BackColor = Color.White;
            passwordPanel.Controls.Add(lblUserProfilePass);
            passwordPanel.Controls.Add(lblNewEmail);
            passwordPanel.Controls.Add(txtNewEmail);
            passwordPanel.Controls.Add(lblCurrentPassword);
            passwordPanel.Controls.Add(txtCurrentPassword);
            passwordPanel.Controls.Add(btnTogglePassword);
            passwordPanel.Controls.Add(lblNewPassword);
            passwordPanel.Controls.Add(txtNewPassword);
            passwordPanel.Controls.Add(lblConfirmPassword);
            passwordPanel.Controls.Add(txtConfirmPassword);
            passwordPanel.Controls.Add(btnSavePassword);
            passwordPanel.Location = new Point(713, 0);
            passwordPanel.Margin = new Padding(4, 5, 4, 5);
            passwordPanel.Name = "passwordPanel";
            passwordPanel.Size = new Size(673, 544);
            passwordPanel.TabIndex = 1;
            // 
            // lblUserProfilePass
            // 
            lblUserProfilePass.AutoSize = true;
            lblUserProfilePass.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblUserProfilePass.ForeColor = Color.FromArgb(51, 51, 51);
            lblUserProfilePass.Location = new Point(33, 31);
            lblUserProfilePass.Margin = new Padding(4, 0, 4, 0);
            lblUserProfilePass.Name = "lblUserProfilePass";
            lblUserProfilePass.Size = new Size(140, 32);
            lblUserProfilePass.TabIndex = 0;
            lblUserProfilePass.Text = "User Profile";
            // 
            // lblNewEmail
            // 
            lblNewEmail.AutoSize = true;
            lblNewEmail.Font = new Font("Segoe UI", 10F);
            lblNewEmail.ForeColor = Color.FromArgb(102, 102, 102);
            lblNewEmail.Location = new Point(33, 92);
            lblNewEmail.Margin = new Padding(4, 0, 4, 0);
            lblNewEmail.Name = "lblNewEmail";
            lblNewEmail.Size = new Size(90, 23);
            lblNewEmail.TabIndex = 1;
            lblNewEmail.Text = "New Email";
            // 
            // txtNewEmail
            // 
            txtNewEmail.BorderStyle = BorderStyle.FixedSingle;
            txtNewEmail.Font = new Font("Segoe UI", 10F);
            txtNewEmail.ForeColor = Color.Silver;
            txtNewEmail.Location = new Point(33, 131);
            txtNewEmail.Margin = new Padding(4, 5, 4, 5);
            txtNewEmail.Name = "txtNewEmail";
            txtNewEmail.Size = new Size(606, 30);
            txtNewEmail.TabIndex = 2;
            txtNewEmail.Text = "Để trống nếu không đổi";
            // 
            // lblCurrentPassword
            // 
            lblCurrentPassword.AutoSize = true;
            lblCurrentPassword.Font = new Font("Segoe UI", 10F);
            lblCurrentPassword.ForeColor = Color.FromArgb(102, 102, 102);
            lblCurrentPassword.Location = new Point(33, 192);
            lblCurrentPassword.Margin = new Padding(4, 0, 4, 0);
            lblCurrentPassword.Name = "lblCurrentPassword";
            lblCurrentPassword.Size = new Size(226, 23);
            lblCurrentPassword.TabIndex = 3;
            lblCurrentPassword.Text = "Current Password (Required)";
            // 
            // txtCurrentPassword
            // 
            txtCurrentPassword.BorderStyle = BorderStyle.FixedSingle;
            txtCurrentPassword.Font = new Font("Segoe UI", 10F);
            txtCurrentPassword.Location = new Point(33, 231);
            txtCurrentPassword.Margin = new Padding(4, 5, 4, 5);
            txtCurrentPassword.Name = "txtCurrentPassword";
            txtCurrentPassword.Size = new Size(560, 30);
            txtCurrentPassword.TabIndex = 4;
            txtCurrentPassword.UseSystemPasswordChar = true;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Location = new Point(600, 226);
            btnTogglePassword.Margin = new Padding(4, 5, 4, 5);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(47, 38);
            btnTogglePassword.TabIndex = 5;
            btnTogglePassword.Text = "👁";
            btnTogglePassword.UseVisualStyleBackColor = true;
            btnTogglePassword.Click += BtnTogglePassword_Click;
            // 
            // lblNewPassword
            // 
            lblNewPassword.AutoSize = true;
            lblNewPassword.Font = new Font("Segoe UI", 10F);
            lblNewPassword.ForeColor = Color.FromArgb(102, 102, 102);
            lblNewPassword.Location = new Point(33, 292);
            lblNewPassword.Margin = new Padding(4, 0, 4, 0);
            lblNewPassword.Name = "lblNewPassword";
            lblNewPassword.Size = new Size(119, 23);
            lblNewPassword.TabIndex = 6;
            lblNewPassword.Text = "New Password";
            // 
            // txtNewPassword
            // 
            txtNewPassword.BorderStyle = BorderStyle.FixedSingle;
            txtNewPassword.Font = new Font("Segoe UI", 10F);
            txtNewPassword.ForeColor = Color.Silver;
            txtNewPassword.Location = new Point(33, 331);
            txtNewPassword.Margin = new Padding(4, 5, 4, 5);
            txtNewPassword.Name = "txtNewPassword";
            txtNewPassword.Size = new Size(606, 30);
            txtNewPassword.TabIndex = 7;
            txtNewPassword.Text = "Để trống nếu không đổi";
            txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            lblConfirmPassword.AutoSize = true;
            lblConfirmPassword.Font = new Font("Segoe UI", 10F);
            lblConfirmPassword.ForeColor = Color.FromArgb(102, 102, 102);
            lblConfirmPassword.Location = new Point(33, 392);
            lblConfirmPassword.Margin = new Padding(4, 0, 4, 0);
            lblConfirmPassword.Name = "lblConfirmPassword";
            lblConfirmPassword.Size = new Size(185, 23);
            lblConfirmPassword.TabIndex = 8;
            lblConfirmPassword.Text = "Confirm New Password";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            txtConfirmPassword.Font = new Font("Segoe UI", 10F);
            txtConfirmPassword.ForeColor = Color.Silver;
            txtConfirmPassword.Location = new Point(33, 431);
            txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Size = new Size(606, 30);
            txtConfirmPassword.TabIndex = 9;
            txtConfirmPassword.Text = "Nhập lại mật khẩu mới";
            txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // btnSavePassword
            // 
            btnSavePassword.BackColor = Color.FromArgb(0, 112, 243);
            btnSavePassword.Cursor = Cursors.Hand;
            btnSavePassword.FlatAppearance.BorderSize = 0;
            btnSavePassword.FlatStyle = FlatStyle.Flat;
            btnSavePassword.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSavePassword.ForeColor = Color.White;
            btnSavePassword.Location = new Point(33, 492);
            btnSavePassword.Margin = new Padding(4, 5, 4, 5);
            btnSavePassword.Name = "btnSavePassword";
            btnSavePassword.Size = new Size(133, 58);
            btnSavePassword.TabIndex = 10;
            btnSavePassword.Text = "Save";
            btnSavePassword.UseVisualStyleBackColor = false;
            btnSavePassword.Click += BtnSavePassword_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(245, 247, 250);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(breadcrumbPanel);
            headerPanel.Location = new Point(40, 31);
            headerPanel.Margin = new Padding(4, 5, 4, 5);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1387, 92);
            headerPanel.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(51, 51, 51);
            lblTitle.Location = new Point(0, 0);
            lblTitle.Margin = new Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(176, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Profile";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(0, 54);
            lblSubtitle.Margin = new Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(298, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // breadcrumbPanel
            // 
            breadcrumbPanel.Controls.Add(lblSettings);
            breadcrumbPanel.Controls.Add(lblArrow);
            breadcrumbPanel.Controls.Add(lblProfile);
            breadcrumbPanel.Location = new Point(1133, 12);
            breadcrumbPanel.Margin = new Padding(4, 5, 4, 5);
            breadcrumbPanel.Name = "breadcrumbPanel";
            breadcrumbPanel.Size = new Size(253, 38);
            breadcrumbPanel.TabIndex = 2;
            // 
            // lblSettings
            // 
            lblSettings.AutoSize = true;
            lblSettings.Cursor = Cursors.Hand;
            lblSettings.Font = new Font("Segoe UI", 10F);
            lblSettings.ForeColor = Color.Gray;
            lblSettings.Location = new Point(0, 5);
            lblSettings.Margin = new Padding(4, 0, 4, 0);
            lblSettings.Name = "lblSettings";
            lblSettings.Size = new Size(71, 23);
            lblSettings.TabIndex = 0;
            lblSettings.Text = "Settings";
            // 
            // lblArrow
            // 
            lblArrow.AutoSize = true;
            lblArrow.Font = new Font("Segoe UI", 10F);
            lblArrow.ForeColor = Color.Gray;
            lblArrow.Location = new Point(87, 5);
            lblArrow.Margin = new Padding(4, 0, 4, 0);
            lblArrow.Name = "lblArrow";
            lblArrow.Size = new Size(22, 23);
            lblArrow.TabIndex = 1;
            lblArrow.Text = ">";
            // 
            // lblProfile
            // 
            lblProfile.AutoSize = true;
            lblProfile.Font = new Font("Segoe UI", 10F);
            lblProfile.ForeColor = Color.FromArgb(0, 112, 243);
            lblProfile.Location = new Point(120, 5);
            lblProfile.Margin = new Padding(4, 0, 4, 0);
            lblProfile.Name = "lblProfile";
            lblProfile.Size = new Size(58, 23);
            lblProfile.TabIndex = 2;
            lblProfile.Text = "Profile";
            // 
            // tabPanel
            // 
            tabPanel.BackColor = Color.White;
            tabPanel.Controls.Add(lblTabProfile);
            tabPanel.Controls.Add(lblTabCategories);
            tabPanel.Controls.Add(lblTabSupport);
            tabPanel.Location = new Point(40, 138);
            tabPanel.Margin = new Padding(4, 5, 4, 5);
            tabPanel.Name = "tabPanel";
            tabPanel.Size = new Size(1387, 62);
            tabPanel.TabIndex = 1;
            // 
            // lblTabProfile
            // 
            lblTabProfile.AutoSize = true;
            lblTabProfile.Cursor = Cursors.Hand;
            lblTabProfile.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            lblTabProfile.ForeColor = Color.FromArgb(0, 112, 243);
            lblTabProfile.Location = new Point(27, 15);
            lblTabProfile.Margin = new Padding(4, 0, 4, 0);
            lblTabProfile.Name = "lblTabProfile";
            lblTabProfile.Size = new Size(68, 25);
            lblTabProfile.TabIndex = 0;
            lblTabProfile.Text = "Profile";
            lblTabProfile.Click += lblTabProfile_Click;
            // 
            // lblTabCategories
            // 
            lblTabCategories.AutoSize = true;
            lblTabCategories.Cursor = Cursors.Hand;
            lblTabCategories.Font = new Font("Segoe UI", 11F);
            lblTabCategories.ForeColor = Color.Gray;
            lblTabCategories.Location = new Point(160, 15);
            lblTabCategories.Margin = new Padding(4, 0, 4, 0);
            lblTabCategories.Name = "lblTabCategories";
            lblTabCategories.Size = new Size(102, 25);
            lblTabCategories.TabIndex = 1;
            lblTabCategories.Text = "Categories";
            lblTabCategories.Click += lblTabCategories_Click;
            // 
            // lblTabSupport
            // 
            lblTabSupport.AutoSize = true;
            lblTabSupport.Cursor = Cursors.Hand;
            lblTabSupport.Font = new Font("Segoe UI", 11F);
            lblTabSupport.ForeColor = Color.Gray;
            lblTabSupport.Location = new Point(333, 15);
            lblTabSupport.Margin = new Padding(4, 0, 4, 0);
            lblTabSupport.Name = "lblTabSupport";
            lblTabSupport.Size = new Size(79, 25);
            lblTabSupport.TabIndex = 2;
            lblTabSupport.Text = "Support";
            lblTabSupport.Click += lblTabSupport_Click;
            // 
            // categoriesPanel
            // 
            categoriesPanel.Controls.Add(pnlCategoryLists);
            categoriesPanel.Controls.Add(createCategoryPanel);
            categoriesPanel.Location = new Point(40, 215);
            categoriesPanel.Name = "categoriesPanel";
            categoriesPanel.Size = new Size(1387, 800);
            categoriesPanel.TabIndex = 4;
            categoriesPanel.Visible = false;
            // 
            // pnlCategoryLists
            // 
            pnlCategoryLists.BackColor = Color.FromArgb(245, 247, 250);
            pnlCategoryLists.Controls.Add(flpExpenseCategories);
            pnlCategoryLists.Controls.Add(lblExpenseCategories);
            pnlCategoryLists.Controls.Add(flpIncomeCategories);
            pnlCategoryLists.Controls.Add(lblIncomeCategories);
            pnlCategoryLists.Location = new Point(470, 0);
            pnlCategoryLists.Name = "pnlCategoryLists";
            pnlCategoryLists.Padding = new Padding(20);
            pnlCategoryLists.Size = new Size(917, 780);
            pnlCategoryLists.TabIndex = 1;
            // 
            // flpExpenseCategories
            // 
            flpExpenseCategories.AutoSize = true;
            flpExpenseCategories.BackColor = Color.White;
            flpExpenseCategories.FlowDirection = FlowDirection.TopDown;
            flpExpenseCategories.Location = new Point(20, 240);
            flpExpenseCategories.MinimumSize = new Size(870, 50);
            flpExpenseCategories.Name = "flpExpenseCategories";
            flpExpenseCategories.Size = new Size(870, 50);
            flpExpenseCategories.TabIndex = 3;
            // 
            // lblExpenseCategories
            // 
            lblExpenseCategories.AutoSize = true;
            lblExpenseCategories.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblExpenseCategories.Location = new Point(20, 200);
            lblExpenseCategories.Name = "lblExpenseCategories";
            lblExpenseCategories.Size = new Size(225, 32);
            lblExpenseCategories.TabIndex = 2;
            lblExpenseCategories.Text = "Expense Categories";
            // 
            // flpIncomeCategories
            // 
            flpIncomeCategories.AutoSize = true;
            flpIncomeCategories.BackColor = Color.White;
            flpIncomeCategories.FlowDirection = FlowDirection.TopDown;
            flpIncomeCategories.Location = new Point(20, 60);
            flpIncomeCategories.MinimumSize = new Size(870, 50);
            flpIncomeCategories.Name = "flpIncomeCategories";
            flpIncomeCategories.Size = new Size(870, 50);
            flpIncomeCategories.TabIndex = 1;
            // 
            // lblIncomeCategories
            // 
            lblIncomeCategories.AutoSize = true;
            lblIncomeCategories.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblIncomeCategories.Location = new Point(20, 20);
            lblIncomeCategories.Name = "lblIncomeCategories";
            lblIncomeCategories.Size = new Size(217, 32);
            lblIncomeCategories.TabIndex = 0;
            lblIncomeCategories.Text = "Income Categories";
            // 
            // createCategoryPanel
            // 
            createCategoryPanel.BackColor = Color.White;
            createCategoryPanel.Controls.Add(lblCreateCategoryTitle);
            createCategoryPanel.Controls.Add(lblCategoryName);
            createCategoryPanel.Controls.Add(txtCategoryName);
            createCategoryPanel.Controls.Add(lblCategoryType);
            createCategoryPanel.Controls.Add(cmbCategoryType);
            createCategoryPanel.Controls.Add(lblCategoryIcon);
            createCategoryPanel.Controls.Add(cmbIcon);
            createCategoryPanel.Controls.Add(lblCategoryColor);
            createCategoryPanel.Controls.Add(cmbColor);
            createCategoryPanel.Controls.Add(flpColorPicker);
            createCategoryPanel.Controls.Add(btnSaveCategory);
            createCategoryPanel.Location = new Point(0, 0);
            createCategoryPanel.Name = "createCategoryPanel";
            createCategoryPanel.Padding = new Padding(20);
            createCategoryPanel.Size = new Size(450, 780);
            createCategoryPanel.TabIndex = 0;
            // 
            // lblCreateCategoryTitle
            // 
            lblCreateCategoryTitle.AutoSize = true;
            lblCreateCategoryTitle.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold);
            lblCreateCategoryTitle.Location = new Point(20, 20);
            lblCreateCategoryTitle.Name = "lblCreateCategoryTitle";
            lblCreateCategoryTitle.Size = new Size(261, 32);
            lblCreateCategoryTitle.TabIndex = 0;
            lblCreateCategoryTitle.Text = "Create a new category";
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Font = new Font("Segoe UI", 10F);
            lblCategoryName.Location = new Point(20, 80);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(56, 23);
            lblCategoryName.TabIndex = 1;
            lblCategoryName.Text = "Name";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Font = new Font("Segoe UI", 10F);
            txtCategoryName.Location = new Point(24, 106);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(400, 30);
            txtCategoryName.TabIndex = 2;
            // 
            // lblCategoryType
            // 
            lblCategoryType.AutoSize = true;
            lblCategoryType.Font = new Font("Segoe UI", 10F);
            lblCategoryType.Location = new Point(20, 150);
            lblCategoryType.Name = "lblCategoryType";
            lblCategoryType.Size = new Size(45, 23);
            lblCategoryType.TabIndex = 3;
            lblCategoryType.Text = "Type";
            // 
            // cmbCategoryType
            // 
            cmbCategoryType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategoryType.Font = new Font("Segoe UI", 10F);
            cmbCategoryType.FormattingEnabled = true;
            cmbCategoryType.Items.AddRange(new object[] { "Expense", "Income" });
            cmbCategoryType.Location = new Point(24, 176);
            cmbCategoryType.Name = "cmbCategoryType";
            cmbCategoryType.Size = new Size(400, 31);
            cmbCategoryType.TabIndex = 4;
            // 
            // lblCategoryIcon
            // 
            lblCategoryIcon.AutoSize = true;
            lblCategoryIcon.Font = new Font("Segoe UI", 10F);
            lblCategoryIcon.Location = new Point(20, 220);
            lblCategoryIcon.Name = "lblCategoryIcon";
            lblCategoryIcon.Size = new Size(43, 23);
            lblCategoryIcon.TabIndex = 5;
            lblCategoryIcon.Text = "Icon";
            // 
            // cmbIcon
            // 
            cmbIcon.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbIcon.Font = new Font("Segoe UI", 10F);
            cmbIcon.FormattingEnabled = true;
            cmbIcon.Location = new Point(24, 246);
            cmbIcon.Name = "cmbIcon";
            cmbIcon.Size = new Size(400, 31);
            cmbIcon.TabIndex = 6;
            // 
            // lblCategoryColor
            // 
            lblCategoryColor.AutoSize = true;
            lblCategoryColor.Font = new Font("Segoe UI", 10F);
            lblCategoryColor.Location = new Point(20, 290);
            lblCategoryColor.Name = "lblCategoryColor";
            lblCategoryColor.Size = new Size(51, 23);
            lblCategoryColor.TabIndex = 7;
            lblCategoryColor.Text = "Color";
            // 
            // cmbColor
            // 
            cmbColor.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbColor.Font = new Font("Segoe UI", 10F);
            cmbColor.FormattingEnabled = true;
            cmbColor.Location = new Point(24, 316);
            cmbColor.Name = "cmbColor";
            cmbColor.Size = new Size(400, 31);
            cmbColor.TabIndex = 8;
            // 
            // flpColorPicker
            // 
            flpColorPicker.Location = new Point(24, 360);
            flpColorPicker.Name = "flpColorPicker";
            flpColorPicker.Size = new Size(400, 200);
            flpColorPicker.TabIndex = 9;
            // 
            // btnSaveCategory
            // 
            btnSaveCategory.BackColor = Color.FromArgb(28, 176, 80);
            btnSaveCategory.FlatAppearance.BorderSize = 0;
            btnSaveCategory.FlatStyle = FlatStyle.Flat;
            btnSaveCategory.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSaveCategory.ForeColor = Color.White;
            btnSaveCategory.Location = new Point(24, 580);
            btnSaveCategory.Name = "btnSaveCategory";
            btnSaveCategory.Size = new Size(400, 45);
            btnSaveCategory.TabIndex = 10;
            btnSaveCategory.Text = "Create new category";
            btnSaveCategory.UseVisualStyleBackColor = false;
            // 
            // UC_Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(4, 5, 4, 5);
            Name = "UC_Settings";
            Size = new Size(1463, 1154);
            mainPanel.ResumeLayout(false);
            personalInfoPanel.ResumeLayout(false);
            personalInfoPanel.PerformLayout();
            topPanel.ResumeLayout(false);
            profilePanel.ResumeLayout(false);
            profilePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picProfile).EndInit();
            passwordPanel.ResumeLayout(false);
            passwordPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            breadcrumbPanel.ResumeLayout(false);
            breadcrumbPanel.PerformLayout();
            tabPanel.ResumeLayout(false);
            tabPanel.PerformLayout();
            categoriesPanel.ResumeLayout(false);
            pnlCategoryLists.ResumeLayout(false);
            pnlCategoryLists.PerformLayout();
            createCategoryPanel.ResumeLayout(false);
            createCategoryPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel breadcrumbPanel;
        private System.Windows.Forms.Label lblSettings;
        private System.Windows.Forms.Label lblArrow;
        private System.Windows.Forms.Label lblProfile;
        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Label lblTabProfile;
        private System.Windows.Forms.Label lblTabCategories;
        private System.Windows.Forms.Label lblTabSupport;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.Panel profilePanel;
        private System.Windows.Forms.Label lblUserProfile;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblCurrentEmail;
        private System.Windows.Forms.TextBox txtCurrentEmail;
        private System.Windows.Forms.PictureBox picProfile;
        private System.Windows.Forms.Label lblProfileName;
        private System.Windows.Forms.Label lblMaxFileSize;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.Panel passwordPanel;
        private System.Windows.Forms.Label lblUserProfilePass;
        private System.Windows.Forms.Label lblNewEmail;
        private System.Windows.Forms.TextBox txtNewEmail;
        private System.Windows.Forms.Label lblCurrentPassword;
        private System.Windows.Forms.TextBox txtCurrentPassword;
        private System.Windows.Forms.Button btnTogglePassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Button btnSavePassword;
        private System.Windows.Forms.Panel personalInfoPanel;
        private System.Windows.Forms.Label lblPersonalInfo;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.Label lblCity;
        private System.Windows.Forms.TextBox txtCity;
        private System.Windows.Forms.Label lblBirthDate;
        private System.Windows.Forms.DateTimePicker dtpBirthDate;
        private System.Windows.Forms.Label lblCountry;
        private System.Windows.Forms.ComboBox cmbCountry;
        private System.Windows.Forms.Button btnSavePersonal;

        // CÁC BIẾN MỚI CHO TAB CATEGORIES
        private System.Windows.Forms.Panel categoriesPanel;
        private System.Windows.Forms.Panel createCategoryPanel;
        private System.Windows.Forms.Panel pnlCategoryLists;
        private System.Windows.Forms.Label lblCreateCategoryTitle;
        private System.Windows.Forms.Label lblCategoryName;
        private System.Windows.Forms.TextBox txtCategoryName;
        private System.Windows.Forms.Label lblCategoryType;
        private System.Windows.Forms.ComboBox cmbCategoryType;
        private System.Windows.Forms.Label lblCategoryIcon;
        private System.Windows.Forms.ComboBox cmbIcon;
        private System.Windows.Forms.Label lblCategoryColor;
        private System.Windows.Forms.ComboBox cmbColor;
        private System.Windows.Forms.FlowLayoutPanel flpColorPicker;
        private System.Windows.Forms.Button btnSaveCategory;
        private System.Windows.Forms.Label lblIncomeCategories;
        private System.Windows.Forms.FlowLayoutPanel flpIncomeCategories;
        private System.Windows.Forms.Label lblExpenseCategories;
        private System.Windows.Forms.FlowLayoutPanel flpExpenseCategories;
    }
}