using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User.UC;
using FontAwesome.Sharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// ✅ FIX LỖI QUAN TRỌNG: Định danh rõ Color dùng cho giao diện
using Color = System.Drawing.Color;

namespace ExpenseManager.App.Views.User.Forms
{
    public partial class AddTransactionForm : Form, IAddTransactionView
    {
        private AddTransactionPresenter _presenter;

        // --- 1. IMPLEMENT INTERFACE EVENTS ---
        public event EventHandler LoadView;
        public event EventHandler SaveTransaction;
        public event EventHandler TypeChanged;

        // --- 2. IMPLEMENT INTERFACE PROPERTIES ---
        public string UserId => CurrentUserSession.CurrentUser?.UserId;

        private string _transactionType = "Expense";
        public string TransactionType
        {
            get => _transactionType;
            set => _transactionType = value;
        }

        public decimal Amount
        {
            get => decimal.TryParse(txtAmount.Text, out decimal result) ? result : 0;
            set => txtAmount.Text = value.ToString("N0"); // Format số có dấu phẩy
        }

        public int? SelectedCategoryId { get; set; } = null;

        public int? SelectedWalletId
        {
            get => cmbWallet.SelectedValue as int?;
            set => cmbWallet.SelectedValue = value;
        }

        public DateTime TransactionDate
        {
            get => dtpTransaction.Value;
            set => dtpTransaction.Value = value;
        }

        public string Description
        {
            get => txtDescription.Text;
            set => txtDescription.Text = value;
        }

        // --- 3. CONSTRUCTOR & INIT ---
        public AddTransactionForm(
            ITransactionService transactionService,
            ICategoryService categoryService,
            IWalletService walletService)
        {
            InitializeComponent();

            // Khởi tạo Presenter
            _presenter = new AddTransactionPresenter(this, transactionService, categoryService, walletService);

            // Setup UI
            ApplyRoundedCorners();
            dtpTransaction.Value = DateTime.Now;

            // Đăng ký sự kiện UI
            txtAmount.KeyPress += TxtAmount_KeyPress;
            btnSubmit.Click += (s, e) => SaveTransaction?.Invoke(this, EventArgs.Empty);

            // Gọi LoadView khi form hiển thị
            this.Load += (s, e) => LoadView?.Invoke(this, EventArgs.Empty);
        }

        // --- 4. UI METHODS (INTERFACE IMPLEMENTATION) ---

        public void LoadWallets(IEnumerable<Wallet> wallets)


        {
            cmbWallet.DataSource = wallets.ToList();
            cmbWallet.DisplayMember = "WalletName";
            cmbWallet.ValueMember = "WalletId";
            cmbWallet.SelectedIndex = -1; // Mặc định chưa chọn ví nào
        }

        // 1. Hàm phụ trợ: Xử lý chuỗi "fa-solid fa-mug-hot" thành IconChar.MugHot
        private IconChar ParseIcon(string iconClass)
        {
            if (string.IsNullOrWhiteSpace(iconClass)) return IconChar.QuestionCircle;

            try
            {
                // Lấy phần tên chính: "fa-solid fa-mug-hot" -> lấy "fa-mug-hot"
                var parts = iconClass.Split(' ');
                var iconName = parts.Length > 0 ? parts[parts.Length - 1] : iconClass;

                // Bỏ tiền tố "fa-": "fa-mug-hot" -> "mug-hot"
                if (iconName.StartsWith("fa-"))
                    iconName = iconName.Substring(3);

                // Chuyển kebab-case sang PascalCase: "mug-hot" -> "MugHot"
                var words = iconName.Split('-');
                for (int i = 0; i < words.Length; i++)
                {
                    if (words[i].Length > 0)
                        words[i] = char.ToUpper(words[i][0]) + words[i].Substring(1);
                }
                var enumString = string.Join("", words);

                // Ép kiểu sang Enum của thư viện
                if (Enum.TryParse(enumString, true, out IconChar result))
                {
                    return result;
                }
            }
            catch { }

            return IconChar.QuestionCircle; // Trả về dấu ? nếu lỗi
        }

        // 2. Hàm LoadCategories đã sửa
        public void LoadCategories(IEnumerable<Category> categories)
        {
            categoryFlowPanel.Controls.Clear();
            SelectedCategoryId = null;

            foreach (var category in categories)
            {
                // Tạo Button
                Button btn = new Button
                {
                    Size = new Size(100, 100),
                    BackColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    Cursor = Cursors.Hand,
                    Tag = category.CategoryId,
                    Margin = new Padding(10)
                };
                btn.FlatAppearance.BorderColor = Color.LightGray;
                btn.FlatAppearance.BorderSize = 1;

                // Màu sắc
                Color categoryColor = Color.Gray;
                try
                {
                    if (!string.IsNullOrEmpty(category.Color?.HexCode))
                    {
                        categoryColor = ColorTranslator.FromHtml(category.Color.HexCode);
                    }
                }
                catch { }

                // IconPictureBox
                var iconPic = new IconPictureBox
                {
                    BackColor = Color.Transparent,
                    ForeColor = categoryColor,
                    IconColor = categoryColor,
                    IconSize = 32,
                    Size = new Size(100, 40),
                    Location = new Point(0, 15),
                    SizeMode = PictureBoxSizeMode.CenterImage,
                    Cursor = Cursors.Hand
                };

                // --- SỬA LỖI Ở ĐÂY: Dùng IconClass thay vì IconName ---
                if (category.Icon != null)
                {
                    // Gọi hàm ParseIcon ta vừa viết ở trên với cột IconClass
                    iconPic.IconChar = ParseIcon(category.Icon.IconClass);
                }
                else
                {
                    iconPic.IconChar = IconChar.QuestionCircle;
                }
                // -----------------------------------------------------

                // Label tên
                Label lblName = new Label
                {
                    Text = category.CategoryName,
                    Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                    ForeColor = Color.FromArgb(64, 64, 64),
                    TextAlign = ContentAlignment.TopCenter,
                    Dock = DockStyle.Bottom,
                    Height = 35,
                    BackColor = Color.Transparent,
                    Cursor = Cursors.Hand
                };

                // Sự kiện Click
                EventHandler selectAction = (s, e) =>
                {
                    SelectedCategoryId = (int)btn.Tag;
                    HighlightCategory(btn);
                };

                btn.Click += selectAction;
                iconPic.Click += selectAction;
                lblName.Click += selectAction;

                btn.Controls.Add(iconPic);
                btn.Controls.Add(lblName);

                RoundButton(btn, 15);
                categoryFlowPanel.Controls.Add(btn);
            }
        }

        private void HighlightCategory(Button selectedBtn)
        {
            // Reset màu tất cả các nút
            foreach (Control ctrl in categoryFlowPanel.Controls)
            {
                if (ctrl is Button btn)
                {
                    btn.BackColor = Color.White;
                    btn.FlatAppearance.BorderColor = Color.LightGray;
                }
            }
            // Tô màu nút được chọn
            selectedBtn.BackColor = Color.FromArgb(235, 235, 255);
            selectedBtn.FlatAppearance.BorderColor = Color.FromArgb(101, 109, 255);
        }

        public void ResetForm()
        {
            txtAmount.Text = "0";
            txtDescription.Text = "";
            dtpTransaction.Value = DateTime.Now;
            cmbWallet.SelectedIndex = -1;
            SelectedCategoryId = null;
            LoadCategories(new List<Category>()); // Clear category selection visual
        }

        public void ShowMessage(string message, string title, bool isError = false)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK,
                isError ? MessageBoxIcon.Error : MessageBoxIcon.Information);
        }

        public void CloseForm()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        // --- 5. UI EVENT HANDLERS ---

        private void BtnExpense_Click(object sender, EventArgs e)
        {
            TransactionType = "Expense";
            UpdateTabUI();
            TypeChanged?.Invoke(this, EventArgs.Empty); // Báo cho Presenter load lại category
        }

        private void BtnIncome_Click(object sender, EventArgs e)
        {
            TransactionType = "Income";
            UpdateTabUI();
            TypeChanged?.Invoke(this, EventArgs.Empty); // Báo cho Presenter load lại category
        }

        private void UpdateTabUI()
        {
            if (TransactionType == "Expense")
            {
                // Tab Chi tiêu active
                btnExpense.BackColor = Color.FromArgb(101, 109, 255);
                btnExpense.ForeColor = Color.White;

                btnIncome.BackColor = Color.White;
                btnIncome.ForeColor = Color.Gray;
            }
            else
            {
                // Tab Thu nhập active
                btnIncome.BackColor = Color.FromArgb(101, 109, 255);
                btnIncome.ForeColor = Color.White;

                btnExpense.BackColor = Color.White;
                btnExpense.ForeColor = Color.Gray;
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho nhập số và phím điều khiển (backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        // --- 6. STYLING HELPERS (BO TRÒN GÓC) ---

        private void ApplyRoundedCorners()
        {
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, this.Width, this.Height, 20, 20));
            RoundButton(btnExpense, 10);
            RoundButton(btnIncome, 10);
            RoundButton(btnSubmit, 10);
            RoundPanel(amountPanel, 10);
        }

        private void RoundButton(Button btn, int radius)
        {
            btn.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btn.Width, btn.Height, radius, radius));
        }

        private void RoundPanel(Panel panel, int radius)
        {
            panel.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, panel.Width, panel.Height, radius, radius));
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }
}