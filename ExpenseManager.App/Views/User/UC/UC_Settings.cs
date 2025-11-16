using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Models.EF;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_Settings : UserControl, IProfileView
    {
        private string selectedImagePath = "";
        private ProfilePresenter _presenter;
        private readonly string _currentUserId = "87de8b0d-fb66-445a-a492-79500cd452db";

        public UC_Settings(string userId)
        {
            InitializeComponent();

            // Gán giá trị thực tế sau khi đăng nhập
            //_currentUserId = userId;

            InitializeCustomComponents();
            InitializePresenter();

            // ...
        }

        // ===== IMPLEMENT IProfileView - PROPERTIES =====

        public string UserId => _currentUserId;

        public string FullName
        {
            get => txtFullName.Text;
            set => txtFullName.Text = value;
        }

        public string CurrentEmail => txtCurrentEmail.Text;

        public string AvatarFilePath => selectedImagePath;

        public string NewEmailInput => GetInputValue(txtNewEmail, "Để trống nếu không đổi");

        public string CurrentPasswordInput => txtCurrentPassword.Text;

        public string NewPasswordInput => GetInputValue(txtNewPassword, "Để trống nếu không đổi");

        public string ConfirmNewPasswordInput => GetInputValue(txtConfirmPassword, "Nhập lại mật khẩu mới");

        public string AddressInput => txtAddress.Text;

        public string CityInput => txtCity.Text;

        public DateTime? DateOfBirthInput
        {
            get
            {
                // Kiểm tra nếu giá trị là mặc định hoặc quá khứ xa thì return null
                if (dtpBirthDate.Value.Year < 1900 || dtpBirthDate.Value > DateTime.Now)
                    return null;
                return dtpBirthDate.Value;
            }
        }

        public string CountryInput => cmbCountry.SelectedItem?.ToString() ?? "";

        // ===== EVENTS =====

        public event EventHandler SaveGeneralInfoClicked;
        public event EventHandler SaveSecurityClicked;
        public event EventHandler SavePersonalInfoClicked;

        // ===== CONSTRUCTOR =====

        public UC_Settings()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializePresenter();

            // Handle resize event
            this.Resize += UC_Settings_Resize;
        }

        /// <summary>
        /// Khởi tạo Presenter với Dependency Injection
        /// </summary>
        private void InitializePresenter()
        {
            try
            {
                // TODO: Trong production, nên dùng DI Container
                var dbContext = new ExpenseDbContext(); // Hoặc inject qua constructor
                IProfileRepository repository = new ProfileRepository(dbContext);
                IProfileServices services = new ProfileServices(repository);
                
                _presenter = new ProfilePresenter(this, services);
                
                // Load dữ liệu ban đầu
                _presenter.LoadUserProfileAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===== IMPLEMENT IProfileView - METHODS =====

        public void DisplayUserData(ExpenseManager.App.Models.Entities.User user)
        {
            if (user == null) return;

            // Hiển thị thông tin chung
            txtFullName.Text = user.FullName;
            txtCurrentEmail.Text = user.Email;
            lblProfileName.Text = user.FullName;

            // Hiển thị avatar nếu có
            if (!string.IsNullOrWhiteSpace(user.AvatarUrl) && File.Exists(user.AvatarUrl))
            {
                picProfile.Image = Image.FromFile(user.AvatarUrl);
                lblFileName.Text = Path.GetFileName(user.AvatarUrl);
            }

            // Hiển thị thông tin cá nhân
            txtAddress.Text = user.Address ?? "";
            txtCity.Text = user.City ?? "";
            
            if (user.DateOfBirth.HasValue)
                dtpBirthDate.Value = user.DateOfBirth.Value;

            if (!string.IsNullOrWhiteSpace(user.Country))
            {
                int index = cmbCountry.FindStringExact(user.Country);
                if (index >= 0)
                    cmbCountry.SelectedIndex = index;
            }
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", 
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", 
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===== BUTTON CLICK HANDLERS =====

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            SaveGeneralInfoClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSavePassword_Click(object sender, EventArgs e)
        {
            SaveSecurityClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnSavePersonal_Click(object sender, EventArgs e)
        {
            SavePersonalInfoClicked?.Invoke(this, EventArgs.Empty);
        }

        // ===== PRIVATE HELPER METHODS =====

        /// <summary>
        /// Lấy giá trị input, trả về empty nếu là placeholder
        /// </summary>
        private string GetInputValue(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder || string.IsNullOrWhiteSpace(textBox.Text))
                return "";
            return textBox.Text;
        }

        private void InitializeCustomComponents()
        {
            // Apply rounded corners to textboxes
            ApplyRoundedCorners();

            // Setup password visibility toggle
            SetupPasswordToggle();

            // Setup profile picture
            SetupProfilePicture();

            // Setup placeholder text events
            SetupPlaceholders();
        }

        private void UC_Settings_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int availableWidth = this.Width - 60;
            int panelSpacing = 20;

            headerPanel.Width = availableWidth;
            breadcrumbPanel.Left = availableWidth - breadcrumbPanel.Width;

            tabPanel.Width = availableWidth;

            topPanel.Width = availableWidth;
            int halfWidth = (availableWidth - panelSpacing) / 2;
            profilePanel.Width = halfWidth;
            passwordPanel.Width = halfWidth;
            passwordPanel.Left = halfWidth + panelSpacing;

            txtFullName.Width = profilePanel.Width - 50;
            txtCurrentEmail.Width = profilePanel.Width - 50;

            txtNewEmail.Width = passwordPanel.Width - 50;
            txtCurrentPassword.Width = passwordPanel.Width - 90;
            btnTogglePassword.Left = passwordPanel.Width - 60;
            txtNewPassword.Width = passwordPanel.Width - 50;
            txtConfirmPassword.Width = passwordPanel.Width - 50;

            personalInfoPanel.Width = availableWidth;
            int fieldWidth = (availableWidth - 90) / 2;
            txtAddress.Width = fieldWidth;
            txtCity.Width = fieldWidth;
            txtCity.Left = fieldWidth + 50;
            lblCity.Left = fieldWidth + 50;

            dtpBirthDate.Width = fieldWidth;
            cmbCountry.Width = fieldWidth;
            cmbCountry.Left = fieldWidth + 50;
            lblCountry.Left = fieldWidth + 50;

            ApplyRoundedCorners();
        }

        private void ApplyRoundedCorners()
        {
            ApplyRoundedCorner(txtFullName, 10);
            ApplyRoundedCorner(txtCurrentEmail, 10);
            ApplyRoundedCorner(txtNewEmail, 10);
            ApplyRoundedCorner(txtCurrentPassword, 10);
            ApplyRoundedCorner(txtNewPassword, 10);
            ApplyRoundedCorner(txtConfirmPassword, 10);
            ApplyRoundedCorner(txtAddress, 10);
            ApplyRoundedCorner(txtCity, 10);
            ApplyRoundedCorner(dtpBirthDate, 10);

            ApplyRoundedCorner(btnSaveProfile, 8);
            ApplyRoundedCorner(btnSavePassword, 8);
            ApplyRoundedCorner(btnSavePersonal, 8);
            ApplyRoundedCorner(btnBrowse, 8);
        }

        private void ApplyRoundedCorner(Control control, int radius)
        {
            if (control.Width > 0 && control.Height > 0)
            {
                control.Region = Region.FromHrgn(
                    CreateRoundRectRgn(0, 0, control.Width, control.Height, radius, radius)
                );
            }
        }

        private void SetupPasswordToggle()
        {
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.FlatAppearance.BorderSize = 0;
            btnTogglePassword.BackColor = System.Drawing.Color.White;
            btnTogglePassword.Cursor = Cursors.Hand;
        }

        private void SetupProfilePicture()
        {
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picProfile.Width, picProfile.Height);
            picProfile.Region = new Region(path);
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetupPlaceholders()
        {
            SetupPlaceholder(txtNewEmail, "Để trống nếu không đổi");
            SetupPlaceholder(txtNewPassword, "Để trống nếu không đổi");
            SetupPlaceholder(txtConfirmPassword, "Nhập lại mật khẩu mới");
        }

        private void SetupPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = System.Drawing.Color.Silver;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = System.Drawing.Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = System.Drawing.Color.Silver;
                }
            };
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Profile Picture";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    if (fileInfo.Length > 20 * 1024 * 1024)
                    {
                        MessageBox.Show("File size must be less than 20MB", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedImagePath = ofd.FileName;
                    picProfile.Image = Image.FromFile(ofd.FileName);
                    lblFileName.Text = Path.GetFileName(ofd.FileName);
                }
            }
        }

        private void BtnTogglePassword_Click(object sender, EventArgs e)
        {
            if (txtCurrentPassword.UseSystemPasswordChar)
            {
                txtCurrentPassword.UseSystemPasswordChar = false;
                btnTogglePassword.Text = "🙈";
            }
            else
            {
                txtCurrentPassword.UseSystemPasswordChar = true;
                btnTogglePassword.Text = "👁";
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }
}