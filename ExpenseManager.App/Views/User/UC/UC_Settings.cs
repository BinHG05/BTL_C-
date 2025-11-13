using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_Settings : UserControl
    {
        private string selectedImagePath = "";

        public UC_Settings()
        {
            InitializeComponent();
            InitializeCustomComponents();

            // Handle resize event
            this.Resize += UC_Settings_Resize;
        }

        private void InitializeCustomComponents()
        {
            // Apply rounded corners to textboxes
            ApplyRoundedCorners();

            // Setup password visibility toggle
            SetupPasswordToggle();

            // Setup profile picture
            SetupProfilePicture();

            // Load default data
            LoadDefaultData();

            // Setup placeholder text events
            SetupPlaceholders();
        }

        private void UC_Settings_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int availableWidth = this.Width - 60; // 30px padding on each side
            int panelSpacing = 20;

            // Adjust header panel
            headerPanel.Width = availableWidth;
            breadcrumbPanel.Left = availableWidth - breadcrumbPanel.Width;

            // Adjust tab panel
            tabPanel.Width = availableWidth;

            // Adjust top panel (Profile + Password)
            topPanel.Width = availableWidth;
            int halfWidth = (availableWidth - panelSpacing) / 2;

            profilePanel.Width = halfWidth;
            passwordPanel.Width = halfWidth;
            passwordPanel.Left = halfWidth + panelSpacing;

            // Adjust controls inside profilePanel
            txtFullName.Width = profilePanel.Width - 50;
            txtCurrentEmail.Width = profilePanel.Width - 50;

            // Adjust controls inside passwordPanel
            txtNewEmail.Width = passwordPanel.Width - 50;
            txtCurrentPassword.Width = passwordPanel.Width - 90;
            btnTogglePassword.Left = passwordPanel.Width - 60;
            txtNewPassword.Width = passwordPanel.Width - 50;
            txtConfirmPassword.Width = passwordPanel.Width - 50;

            // Adjust personal info panel
            personalInfoPanel.Width = availableWidth;
            int fieldWidth = (availableWidth - 90) / 2; // 30px padding + 30px spacing

            txtAddress.Width = fieldWidth;
            txtCity.Width = fieldWidth;
            txtCity.Left = fieldWidth + 50;
            lblCity.Left = fieldWidth + 50;

            dtpBirthDate.Width = fieldWidth;
            cmbCountry.Width = fieldWidth;
            cmbCountry.Left = fieldWidth + 50;
            lblCountry.Left = fieldWidth + 50;

            // Re-apply rounded corners after resize
            ApplyRoundedCorners();
        }

        private void ApplyRoundedCorners()
        {
            // Round all textboxes
            ApplyRoundedCorner(txtFullName, 10);
            ApplyRoundedCorner(txtCurrentEmail, 10);
            ApplyRoundedCorner(txtNewEmail, 10);
            ApplyRoundedCorner(txtCurrentPassword, 10);
            ApplyRoundedCorner(txtNewPassword, 10);
            ApplyRoundedCorner(txtConfirmPassword, 10);
            ApplyRoundedCorner(txtAddress, 10);
            ApplyRoundedCorner(txtCity, 10);
            ApplyRoundedCorner(dtpBirthDate, 10);

            // Round buttons
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
            btnTogglePassword.BackColor = Color.White;
            btnTogglePassword.Cursor = Cursors.Hand;
        }

        private void SetupProfilePicture()
        {
            // Make profile picture circular
            GraphicsPath path = new GraphicsPath();
            path.AddEllipse(0, 0, picProfile.Width, picProfile.Height);
            picProfile.Region = new Region(path);

            // Set default avatar
            picProfile.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void SetupPlaceholders()
        {
            // New Email placeholder
            SetupPlaceholder(txtNewEmail, "Để trống nếu không đổi");

            // New Password placeholder
            SetupPlaceholder(txtNewPassword, "Để trống nếu không đổi");

            // Confirm Password placeholder
            SetupPlaceholder(txtConfirmPassword, "Nhập lại mật khẩu mới");
        }

        private void SetupPlaceholder(TextBox textBox, string placeholderText)
        {
            textBox.Text = placeholderText;
            textBox.ForeColor = Color.Silver;

            textBox.GotFocus += (s, e) =>
            {
                if (textBox.Text == placeholderText)
                {
                    textBox.Text = "";
                    textBox.ForeColor = Color.Black;
                }
            };

            textBox.LostFocus += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(textBox.Text))
                {
                    textBox.Text = placeholderText;
                    textBox.ForeColor = Color.Silver;
                }
            };
        }

        private void LoadDefaultData()
        {
            // Load current user data (replace with actual data from your system)
            txtFullName.Text = "Âu Dương Tải";
            txtCurrentEmail.Text = "auduongtai27@gmail.com";
            txtAddress.Text = "";
            txtCity.Text = "";
            dtpBirthDate.Text = "";
            cmbCountry.SelectedIndex = 0;
        }

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Profile Picture";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    // Check file size (20MB limit)
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

        private void BtnSaveProfile_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Please enter your full name", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Save profile logic here
            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnSavePassword_Click(object sender, EventArgs e)
        {
            string newEmail = txtNewEmail.Text == "Để trống nếu không đổi" ? "" : txtNewEmail.Text;
            string newPass = txtNewPassword.Text == "Để trống nếu không đổi" ? "" : txtNewPassword.Text;
            string confirmPass = txtConfirmPassword.Text == "Nhập lại mật khẩu mới" ? "" : txtConfirmPassword.Text;

            // Validate password fields
            if (string.IsNullOrWhiteSpace(txtCurrentPassword.Text))
            {
                MessageBox.Show("Please enter current password", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!string.IsNullOrEmpty(newPass) && newPass != confirmPass)
            {
                MessageBox.Show("New passwords do not match", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Update password logic here
            MessageBox.Show("Password updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear password fields
            txtCurrentPassword.Clear();
            txtNewPassword.Text = "Để trống nếu không đổi";
            txtNewPassword.ForeColor = Color.Silver;
            txtConfirmPassword.Text = "Nhập lại mật khẩu mới";
            txtConfirmPassword.ForeColor = Color.Silver;
        }

        private void BtnSavePersonal_Click(object sender, EventArgs e)
        {
            // Save personal information logic here
            MessageBox.Show("Personal information updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }
}