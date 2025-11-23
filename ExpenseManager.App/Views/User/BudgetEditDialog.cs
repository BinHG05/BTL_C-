using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services; // Chứa DTO

using Color = System.Drawing.Color;

namespace ExpenseManager.App.Views.User
{
    public partial class BudgetEditDialog : Form
    {
        private List<Category> _availableCategories;
        private int _selectedCategoryId = -1;
        private FlowLayoutPanel _categoryPanel;
        private BudgetDetailDto _currentBudget;

        // Property trả về kết quả update
        public BudgetUpdateDto UpdatedBudgetDto { get; private set; }

        // Constructor nhận thêm tham số budget hiện tại
        public BudgetEditDialog(BudgetDetailDto currentBudget, List<Category> allCategories)
        {
            InitializeComponent();
            _currentBudget = currentBudget;

            // Danh sách category hiển thị bao gồm:
            // 1. Category hiện tại của budget này (để hiện lên mà chọn)
            // 2. Các category chưa có budget (để có thể đổi sang)
            _availableCategories = allCategories ?? new List<Category>();

            // Ẩn combobox cũ
            if (categoryComboBox != null) categoryComboBox.Visible = false;

            // Setup Giao diện & Dữ liệu
            SetupCategoryGrid();
            LoadCurrentData();
            SetupEvents();
        }

        private void LoadCurrentData()
        {
            if (_currentBudget == null) return;

            // 1. Load số tiền
            monetTxtBox.Text = ((int)_currentBudget.BudgetAmount).ToString();

            // 2. Load ngày tháng
            fromDateTimePicker.Value = _currentBudget.StartDate;
            toDateTimePicker.Value = _currentBudget.EndDate;

            // 3. Load Recurring
            isRecurringChckBox.Checked = _currentBudget.IsRecurring;

            // 4. Chọn Category hiện tại trên lưới
            _selectedCategoryId = _currentBudget.CategoryId;
            RefreshGridSelection();
        }

        private void SetupCategoryGrid()
        {
            _categoryPanel = new FlowLayoutPanel
            {
                Location = new Point(60, 130), // Căn chỉnh theo thiết kế form edit
                Size = new Size(415, 120),     // Nhỏ hơn chút cho vừa form
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(0, 5, 0, 0),
                BorderStyle = BorderStyle.FixedSingle
            };

            if (_availableCategories.Count == 0)
            {
                Label lblEmpty = new Label { Text = "Không có danh mục khả dụng", AutoSize = true };
                _categoryPanel.Controls.Add(lblEmpty);
            }
            else
            {
                foreach (var cat in _availableCategories)
                {
                    _categoryPanel.Controls.Add(CreateCategoryCard(cat));
                }
            }

            this.Controls.Add(_categoryPanel);
            _categoryPanel.BringToFront();
        }

        private Panel CreateCategoryCard(Category category)
        {
            Panel pnlCard = new Panel
            {
                Size = new Size(90, 90), // Nhỏ hơn form create chút
                Margin = new Padding(0, 0, 10, 10),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = category.CategoryId
            };

            // Lấy màu
            Color displayColor = Color.Black;
            if (category.Color != null && !string.IsNullOrEmpty(category.Color.HexCode))
            {
                try { displayColor = ColorTranslator.FromHtml(category.Color.HexCode); } catch { }
            }

            // Vẽ viền
            pnlCard.Paint += (s, e) =>
            {
                Color borderColor = (_selectedCategoryId == category.CategoryId)
                                    ? Color.FromArgb(59, 130, 246)
                                    : Color.FromArgb(226, 232, 240);
                int penWidth = (_selectedCategoryId == category.CategoryId) ? 2 : 1;
                ControlPaint.DrawBorder(e.Graphics, pnlCard.ClientRectangle, borderColor, penWidth, ButtonBorderStyle.Solid, borderColor, penWidth, ButtonBorderStyle.Solid, borderColor, penWidth, ButtonBorderStyle.Solid, borderColor, penWidth, ButtonBorderStyle.Solid);
            };

            // Icon
            Label lblIcon = new Label
            {
                Text = GetEmojiFromIconData(category),
                Font = new Font("Segoe UI", 22),
                ForeColor = displayColor,
                AutoSize = false,
                Size = new Size(90, 45),
                TextAlign = ContentAlignment.BottomCenter,
                Location = new Point(0, 5),
                BackColor = Color.Transparent
            };

            // Tên
            Label lblName = new Label
            {
                Text = category.CategoryName,
                Font = new Font("Segoe UI", 8, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                AutoSize = false,
                Size = new Size(90, 35),
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(0, 50),
                BackColor = Color.Transparent
            };

            pnlCard.Controls.Add(lblIcon);
            pnlCard.Controls.Add(lblName);

            EventHandler selectAction = (s, e) =>
            {
                _selectedCategoryId = category.CategoryId;
                RefreshGridSelection();
            };
            pnlCard.Click += selectAction;
            lblIcon.Click += selectAction;
            lblName.Click += selectAction;

            return pnlCard;
        }

        private void RefreshGridSelection()
        {
            foreach (Control c in _categoryPanel.Controls) c.Invalidate();
        }

        private string GetEmojiFromIconData(Category cat)
        {
            string iconClass = (cat.Icon?.IconClass ?? "").ToLower();
            string name = (cat.CategoryName ?? "").ToLower();

            if (iconClass.Contains("paw") || iconClass.Contains("dog")) return "🐾";
            if (iconClass.Contains("coffee") || iconClass.Contains("mug")) return "☕";
            if (iconClass.Contains("shirt") || iconClass.Contains("tshirt")) return "👕";
            if (iconClass.Contains("shield") || iconClass.Contains("lock")) return "🛡️";
            if (iconClass.Contains("ticket") || iconClass.Contains("receipt")) return "🎟️";
            if (iconClass.Contains("money") || iconClass.Contains("dollar")) return "💵";
            if (iconClass.Contains("cart") || iconClass.Contains("shop")) return "🛒";
            if (iconClass.Contains("car") || iconClass.Contains("gas")) return "⛽";
            if (iconClass.Contains("home") || iconClass.Contains("house")) return "🏠";
            if (iconClass.Contains("utensils") || iconClass.Contains("burger") || iconClass.Contains("food")) return "🍔";
            if (iconClass.Contains("plane")) return "✈️";
            if (iconClass.Contains("game")) return "🎮";
            if (iconClass.Contains("gift")) return "🎁";
            if (iconClass.Contains("book")) return "📚";

            if (name.Contains("cà phê")) return "☕";
            if (name.Contains("quần áo")) return "👕";
            if (name.Contains("bảo hiểm")) return "🛡️";
            if (name.Contains("trúng số")) return "🎟️";
            if (name.Contains("lương")) return "💵";
            if (name.Contains("ăn")) return "🍔";
            if (name.Contains("xăng")) return "⛽";

            return "💰";
        }

        private void SetupEvents()
        {
            addBtn.Click += SaveBtn_Click; // Đổi tên hành động là Save
            cancelBtn.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            weekRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            monthRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            tMonthRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            YearRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
        }

        private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                DateTime start = fromDateTimePicker.Value.Date;
                // Nếu muốn logic thông minh: giữ nguyên ngày bắt đầu, chỉ đổi ngày kết thúc
                DateTime end = start;
                if (weekRadioBtn.Checked) end = start.AddDays(7);
                else if (monthRadioBtn.Checked) end = start.AddMonths(1);
                else if (tMonthRadioBtn.Checked) end = start.AddMonths(3);
                else if (YearRadioBtn.Checked) end = start.AddYears(1);
                toDateTimePicker.Value = end;
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId <= 0) { MessageBox.Show("Vui lòng chọn danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(monetTxtBox.Text.Trim(), out decimal amount) || amount <= 0) { MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (fromDateTimePicker.Value.Date >= toDateTimePicker.Value.Date) { MessageBox.Show("Ngày không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            UpdatedBudgetDto = new BudgetUpdateDto
            {
                CategoryId = _selectedCategoryId,
                BudgetAmount = amount,
                StartDate = fromDateTimePicker.Value.Date,
                EndDate = toDateTimePicker.Value.Date,
                IsRecurring = isRecurringChckBox.Checked
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}