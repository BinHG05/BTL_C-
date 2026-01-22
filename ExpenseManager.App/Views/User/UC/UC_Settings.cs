using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.Admin.UC;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExpenseManager.App.Session;
using System.Collections.Generic;
using System.Linq;

// Alias cho các entity trùng tên
using DbColor = ExpenseManager.App.Models.Entities.Color;
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_Settings : UserControl, IProfileView, ICategoryView
    {
        private string selectedImagePath = "";
        private ProfilePresenter _presenter;
        private CategoryPresenter _categoryPresenter;
        private int? _selectedCategoryId = null;

        public UC_Settings(string userId)
        {
            InitializeComponent();
            SetupUI(); // Gom code setup giao diện vào hàm chung
            InitializeCustomComponents();
            InitializePresenter();
        }

        public UC_Settings()
        {
            InitializeComponent();
            SetupUI(); // Gom code setup giao diện vào hàm chung
            InitializeCustomComponents();
            InitializePresenter();
            this.Resize += UC_Settings_Resize;
        }

        // Hàm setup chung cho cả 2 constructor
        private void SetupUI()
        {
            this.BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            mainPanel.BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            breadcrumbPanel.Visible = false;

            // --- CẤU HÌNH SCROLLBAR ---
            pnlCategoryLists.AutoScroll = true;
            pnlCategoryLists.HorizontalScroll.Visible = false; // Ẩn scroll ngang nếu không cần
            // ---------------------------
        }

        // =========================================================
        // ===== IMPLEMENT IProfileView - PROPERTIES =====
        // =========================================================

        public string UserId => CurrentUserSession.CurrentUser?.UserId;

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
                //if (dtpBirthDate.Value.Year < 1900 || dtpBirthDate.Value > DateTime.Now)
                //    return null;
                return dtpBirthDate.Value;
            }
        }

        public string CountryInput => cmbCountry.SelectedItem?.ToString() ?? "";

        // ======================================================
        // ===== IMPLEMENT IProfileView - EVENTS =====
        // ======================================================

        public event EventHandler SaveGeneralInfoClicked;
        public event EventHandler SaveSecurityClicked;
        public event EventHandler SavePersonalInfoClicked;


        // ============================================================
        // ===== IMPLEMENT ICategoryView - PROPERTIES =====
        // ============================================================

        public int? SelectedCategoryId => _selectedCategoryId;

        public string CategoryName
        {
            get => txtCategoryName.Text;
            set => txtCategoryName.Text = value;
        }
        public string CategoryType
        {
            get
            {
                string selectedText = cmbCategoryType.SelectedItem.ToString();
                if (selectedText == "Chi tiêu") return "Expense";
                if (selectedText == "Thu nhập") return "Income";
                return selectedText;
            }
            set
            {
                if (value == "Expense") cmbCategoryType.SelectedItem = "Chi tiêu";
                else if (value == "Income") cmbCategoryType.SelectedItem = "Thu nhập";
                else cmbCategoryType.SelectedItem = value;
            }
        }
        public int SelectedIconId
        {
            get => (int)cmbIcon.SelectedValue;
            set => cmbIcon.SelectedValue = value;
        }
        public int SelectedColorId
        {
            get => (int)cmbColor.SelectedValue;
            set => cmbColor.SelectedValue = value;
        }

        // =========================================================
        // ===== IMPLEMENT ICategoryView - EVENTS =====
        // =========================================================

        public event EventHandler LoadView;
        public event EventHandler CreateCategory;
        public event EventHandler UpdateCategory;
        public event EventHandler DeleteCategory;
        public event EventHandler SelectCategory;


        // ==========================================================
        // ===== PRESENTER =====
        // ==========================================================

        private void InitializePresenter()
        {
            try
            {
                var dbContext = new ExpenseDbContext();

                IProfileRepository profileRepository = new ProfileRepository(dbContext);
                IProfileServices profileServices = new ProfileServices(profileRepository);
                _presenter = new ProfilePresenter(this, profileServices);

                _ = _presenter.LoadUserProfileAsync();

                ICategoryRepository categoryRepository = new CategoryRepository(dbContext);
                IIconRepository iconRepository = new IconRepository(dbContext);
                IColorRepository colorRepository = new ColorRepository(dbContext);
                ICategoryService categoryService = new CategoryService(categoryRepository, iconRepository, colorRepository);
                _categoryPresenter = new CategoryPresenter(this, categoryService);

                this.btnSaveCategory.Click += BtnSaveCategory_Click;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ====================================================================
        // ===== IMPLEMENT METHODS =====
        // ====================================================================

        public void DisplayUserData(ExpenseManager.App.Models.Entities.User user)
        {
            if (user == null) return;

            txtFullName.Text = user.FullName;
            txtCurrentEmail.Text = user.Email;
            lblProfileName.Text = user.FullName;
            txtAddress.Text = user.Address;
            txtCity.Text = user.City;

            if (user.DateOfBirth.HasValue)
            {
                if (user.DateOfBirth.Value >= dtpBirthDate.MinDate &&
                    user.DateOfBirth.Value <= dtpBirthDate.MaxDate)
                {
                    dtpBirthDate.Value = user.DateOfBirth.Value;
                }
            }

            if (!string.IsNullOrEmpty(user.Country))
            {
                int index = cmbCountry.FindStringExact(user.Country);
                if (index != -1) cmbCountry.SelectedIndex = index;
            }
            else
            {
                cmbCountry.SelectedIndex = -1;
            }
            try
            {
                if (!string.IsNullOrWhiteSpace(user.AvatarUrl) && File.Exists(user.AvatarUrl))
                {
                    picProfile.Image = System.Drawing.Image.FromFile(user.AvatarUrl);
                }
                else
                {
                    string defaultAvatarPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "image", "AvatarDefault.jpg");
                    if (File.Exists(defaultAvatarPath))
                        picProfile.Image = System.Drawing.Image.FromFile(defaultAvatarPath);
                    else
                        picProfile.Image = null;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi tải ảnh: {ex.Message}");
                picProfile.Image = null;
            }
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // ===== HÀM QUAN TRỌNG ĐỂ SỬA LỖI HIỂN THỊ CATEGORY =====
        public void DisplayCategories(List<Category> incomeCategories, List<Category> expenseCategories)
        {
            // 1. Tạm dừng layout
            pnlCategoryLists.SuspendLayout();
            flpIncomeCategories.SuspendLayout();
            flpExpenseCategories.SuspendLayout();

            // 2. Xóa dữ liệu cũ
            flpIncomeCategories.Controls.Clear();
            flpExpenseCategories.Controls.Clear();

            // 3. Tính toán chiều rộng
            // Trừ hao 25px để chừa chỗ cho Scrollbar dọc, tránh bị che nút
            int scrollbarPadding = 25;
            int panelWidth = pnlCategoryLists.ClientSize.Width - scrollbarPadding;
            if (panelWidth < 0) panelWidth = pnlCategoryLists.ClientSize.Width;

            // Set width và AutoSize cho các panel chứa danh sách
            flpIncomeCategories.Width = panelWidth;
            flpIncomeCategories.AutoSize = true;
            flpIncomeCategories.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            flpExpenseCategories.Width = panelWidth;
            flpExpenseCategories.AutoSize = true;
            flpExpenseCategories.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // 4. Thêm danh sách Thu nhập (Income)
            foreach (var category in incomeCategories)
            {
                var item = new UC_CategoryItem(category);
                item.Width = panelWidth;
                item.EditClicked += OnCategoryItem_EditClicked;
                item.DeleteClicked += OnCategoryItem_DeleteClicked;
                flpIncomeCategories.Controls.Add(item);
            }

            // 5. Cập nhật layout của Income ngay lập tức để lấy chiều cao thực tế
            flpIncomeCategories.ResumeLayout(false);
            flpIncomeCategories.PerformLayout();

            // 6. Tính toán vị trí mới cho phần Chi tiêu (Expense) để không bị đè
            // Vị trí Y mới = Đáy của danh sách Thu nhập + khoảng cách (30px)
            int gap = 30;
            int newY = flpIncomeCategories.Bottom + gap;

            lblExpenseCategories.Location = new Point(lblExpenseCategories.Location.X, newY);

            // Danh sách chi tiêu nằm ngay dưới label chi tiêu
            flpExpenseCategories.Location = new Point(flpExpenseCategories.Location.X, lblExpenseCategories.Bottom + 10);

            // 7. Thêm danh sách Chi tiêu (Expense)
            foreach (var category in expenseCategories)
            {
                var item = new UC_CategoryItem(category);
                item.Width = panelWidth;
                item.EditClicked += OnCategoryItem_EditClicked;
                item.DeleteClicked += OnCategoryItem_DeleteClicked;
                flpExpenseCategories.Controls.Add(item);
            }

            // 8. Tiếp tục layout
            flpExpenseCategories.ResumeLayout(false);
            flpExpenseCategories.PerformLayout();
            pnlCategoryLists.ResumeLayout(true);
        }

        public void PopulateDropdowns(List<DbIcon> icons, List<DbColor> colors)
        {
            cmbIcon.DataSource = icons;
            cmbIcon.DisplayMember = "IconName";
            cmbIcon.ValueMember = "IconId";

            cmbColor.DataSource = colors;
            cmbColor.DisplayMember = "ColorName";
            cmbColor.ValueMember = "ColorId";

            flpColorPicker.Controls.Clear();
            foreach (var color in colors)
            {
                Panel colorPanel = new Panel
                {
                    Width = 30,
                    Height = 30,
                    Margin = new Padding(5),
                    BackColor = System.Drawing.ColorTranslator.FromHtml(color.HexCode),
                    Cursor = Cursors.Hand,
                    Tag = color.ColorId
                };
                colorPanel.Click += (s, e) =>
                {
                    cmbColor.SelectedValue = (int)((Panel)s).Tag;
                };
                flpColorPicker.Controls.Add(colorPanel);
            }
        }

        public void LoadCategoryForEdit(Category category)
        {
            _selectedCategoryId = category.CategoryId;
            txtCategoryName.Text = category.CategoryName;
            cmbCategoryType.SelectedItem = category.Type;
            cmbIcon.SelectedValue = category.IconId;
            cmbColor.SelectedValue = category.ColorId;

            btnSaveCategory.Text = "Lưu thay đổi";
            btnSaveCategory.BackColor = System.Drawing.Color.FromArgb(0, 112, 243);
            lblCreateCategoryTitle.Text = "Chỉnh sửa danh mục";
        }

        public void ResetForm()
        {
            _selectedCategoryId = null;
            txtCategoryName.Text = "";
            cmbCategoryType.SelectedIndex = 0;
            if (cmbIcon.Items.Count > 0) cmbIcon.SelectedIndex = 0;
            if (cmbColor.Items.Count > 0) cmbColor.SelectedIndex = 0;

            btnSaveCategory.Text = "Tạo danh mục mới";
            btnSaveCategory.BackColor = System.Drawing.Color.FromArgb(28, 176, 80);
            lblCreateCategoryTitle.Text = "Tạo danh mục mới";
        }

        public void ShowMessage(string message, string title, bool isError = false)
        {
            MessageBox.Show(message, title,
                MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Warning : MessageBoxIcon.Information);
        }

        // ========================================================
        // ===== EVENT HANDLERS =====
        // ========================================================

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

        private void BtnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
                ofd.Title = "Select Profile Picture";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    FileInfo fileInfo = new FileInfo(ofd.FileName);
                    if (fileInfo.Length > 20 * 1024 * 1024) // 20MB
                    {
                        MessageBox.Show("File size must be less than 20MB", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    selectedImagePath = ofd.FileName;
                    picProfile.Image = System.Drawing.Image.FromFile(ofd.FileName);
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

        // Handlers cho Chuyển Tab
        private void lblTabProfile_Click(object sender, EventArgs e) => SwitchTab(Tab.Profile);

        private void lblTabCategories_Click(object sender, EventArgs e)
        {
            SwitchTab(Tab.Categories);
            LoadView?.Invoke(this, EventArgs.Empty);
        }

        private void lblTabSupport_Click(object sender, EventArgs e)
        {
            SwitchTab(Tab.Support);
            LoadContent(new UC_TicketUser());
        }

        private enum Tab { Profile, Categories, Support }
        private void SwitchTab(Tab tab)
        {
            topPanel.Visible = false;
            personalInfoPanel.Visible = false;
            categoriesPanel.Visible = false;

            lblTabProfile.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTabProfile.ForeColor = System.Drawing.Color.Gray;
            lblTabCategories.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTabCategories.ForeColor = System.Drawing.Color.Gray;
            lblTabSupport.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblTabSupport.ForeColor = System.Drawing.Color.Gray;

            if (tab == Tab.Profile)
            {
                topPanel.Visible = true;
                personalInfoPanel.Visible = true;
                lblTabProfile.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
                lblTabProfile.ForeColor = System.Drawing.Color.FromArgb(0, 112, 243);
            }
            else if (tab == Tab.Categories)
            {
                categoriesPanel.Visible = true;
                lblTabCategories.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
                lblTabCategories.ForeColor = System.Drawing.Color.FromArgb(0, 112, 243);
                ResetForm();
                AdjustLayout();
            }
            else if (tab == Tab.Support)
            {
                lblTabSupport.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
                lblTabSupport.ForeColor = System.Drawing.Color.FromArgb(0, 112, 243);
            }
        }

        private void BtnSaveCategory_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId == null) CreateCategory?.Invoke(this, EventArgs.Empty);
            else UpdateCategory?.Invoke(this, EventArgs.Empty);
        }

        private void OnCategoryItem_EditClicked(object sender, EventArgs e)
        {
            var item = (UC_CategoryItem)sender;
            _selectedCategoryId = item.CategoryId;
            SelectCategory?.Invoke(this, EventArgs.Empty);
        }

        private void OnCategoryItem_DeleteClicked(object sender, EventArgs e)
        {
            var item = (UC_CategoryItem)sender;
            var confirmResult = MessageBox.Show($"Bạn có chắc muốn xóa danh mục '{item.GetCategory().CategoryName}' không?",
                                             "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                _selectedCategoryId = item.CategoryId;
                DeleteCategory?.Invoke(this, EventArgs.Empty);
            }
        }

        // ========================================================
        // ===== HELPER METHODS =====
        // ========================================================

        private string GetInputValue(TextBox textBox, string placeholderText)
        {
            if (textBox.Text == placeholderText || string.IsNullOrWhiteSpace(textBox.Text))
                return "";
            return textBox.Text;
        }

        private void InitializeCustomComponents()
        {
            ApplyRoundedCorners();
            SetupPasswordToggle();
            SetupProfilePicture();
            SetupPlaceholders();
            SwitchTab(Tab.Profile);
        }

        private void UC_Settings_Resize(object sender, EventArgs e)
        {
            AdjustLayout();
        }

        private void AdjustLayout()
        {
            int availableWidth = this.Width - (this.mainPanel.Padding.Horizontal);
            int mainPanelPadding = this.mainPanel.Padding.Left;
            int panelSpacing = 20;

            // HEADER & TAB
            headerPanel.Width = availableWidth - mainPanelPadding * 2;
            tabPanel.Width = availableWidth - mainPanelPadding * 2;
            headerPanel.Left = mainPanelPadding;
            tabPanel.Left = mainPanelPadding;
            breadcrumbPanel.Left = headerPanel.Width - breadcrumbPanel.Width;

            // PROFILE & PASSWORD
            topPanel.Width = availableWidth - mainPanelPadding * 2;
            topPanel.Left = mainPanelPadding;
            topPanel.Height = 565;

            int halfWidth = (topPanel.Width - panelSpacing) / 2;
            profilePanel.Width = halfWidth;
            profilePanel.Height = 565;
            passwordPanel.Width = halfWidth;
            passwordPanel.Height = 565;
            passwordPanel.Left = halfWidth + panelSpacing;

            // Căn chỉnh Profile
            int profileContentWidth = profilePanel.Width - 60;
            txtFullName.Left = 33; txtFullName.Width = profileContentWidth;
            txtCurrentEmail.Left = 33; txtCurrentEmail.Width = profileContentWidth;

            // Căn chỉnh Password
            int passwordContentWidth = passwordPanel.Width - 60;
            txtNewEmail.Left = 33; txtNewEmail.Width = passwordContentWidth;
            txtNewPassword.Left = 33; txtNewPassword.Width = passwordContentWidth;
            txtConfirmPassword.Left = 33; txtConfirmPassword.Width = passwordContentWidth;
            txtCurrentPassword.Left = 33; txtCurrentPassword.Width = passwordContentWidth - btnTogglePassword.Width - 5;
            btnTogglePassword.Left = txtCurrentPassword.Left + txtCurrentPassword.Width - 170;
            btnTogglePassword.Top = txtCurrentPassword.Top;

            // PERSONAL INFO
            personalInfoPanel.Width = availableWidth - mainPanelPadding * 2;
            personalInfoPanel.Left = mainPanelPadding;
            personalInfoPanel.Height = 389;

            int personalContentWidth = personalInfoPanel.Width - 80;
            int fieldWidth = (personalContentWidth - panelSpacing) / 2;
            txtAddress.Left = 40; txtAddress.Width = fieldWidth;
            dtpBirthDate.Left = 40; dtpBirthDate.Width = fieldWidth;
            int rightColumnLeft = 40 + fieldWidth + panelSpacing;
            lblCity.Left = rightColumnLeft; txtCity.Left = rightColumnLeft; txtCity.Width = fieldWidth;
            lblCountry.Left = rightColumnLeft; cmbCountry.Left = rightColumnLeft; cmbCountry.Width = 604;

            // CATEGORIES PANEL - CẬP NHẬT CHO SCROLLBAR
            if (categoriesPanel.Visible)
            {
                categoriesPanel.Width = availableWidth - mainPanelPadding * 2;
                categoriesPanel.Left = mainPanelPadding;

                createCategoryPanel.Height = categoriesPanel.Height;
                pnlCategoryLists.Height = categoriesPanel.Height;

                pnlCategoryLists.Width = categoriesPanel.Width - createCategoryPanel.Width - panelSpacing;
                pnlCategoryLists.Left = createCategoryPanel.Width + panelSpacing;

                // Căn chỉnh createCategoryPanel
                int categoryContentWidth = createCategoryPanel.Width - 48;
                txtCategoryName.Width = categoryContentWidth;
                cmbCategoryType.Width = categoryContentWidth;
                cmbIcon.Width = categoryContentWidth;
                cmbColor.Width = categoryContentWidth;

                // --- CẬP NHẬT LẠI CHIỀU RỘNG LIST KHI RESIZE ---
                // Trừ hao scrollbar 25px
                int scrollbarPadding = 25;
                int listWidth = pnlCategoryLists.ClientSize.Width - scrollbarPadding;

                if (listWidth > 0)
                {
                    flpIncomeCategories.Width = listWidth;
                    flpExpenseCategories.Width = listWidth;

                    foreach (Control item in flpIncomeCategories.Controls) item.Width = listWidth;
                    foreach (Control item in flpExpenseCategories.Controls) item.Width = listWidth;
                }
            }
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
            ApplyRoundedCorner(txtCategoryName, 10);
            ApplyRoundedCorner(btnSaveCategory, 8);

            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.FlatAppearance.BorderSize = 1;
            btnTogglePassword.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            ApplyRoundedCorner(btnTogglePassword, 8);
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
            picProfile.Size = new Size(60, 60);
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

        private void LoadContent(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }
}