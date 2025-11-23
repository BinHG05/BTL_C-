using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Models.DTOs;

using Color = System.Drawing.Color;
using ExpenseManager.App.Services;

namespace ExpenseManager.App.Views.User
{
    public partial class BudgetCreateDialog : Form
    {
        private List<Category> _availableCategories;
        private int _selectedCategoryId = -1;
        private FlowLayoutPanel _categoryPanel;

        public BudgetCreateDto CreatedBudgetDto { get; private set; }

        public BudgetCreateDialog(List<Category> categories)
        {
            InitializeComponent();
            _availableCategories = categories ?? new List<Category>();

            if (comboBox1 != null) comboBox1.Visible = false;

            SetupCategoryGrid();
            SetupEvents();

            monthRadioBtn.Checked = true;
            UpdateDateRange();
        }

        private void SetupCategoryGrid()
        {
            _categoryPanel = new FlowLayoutPanel
            {
                Location = new Point(42, 130),
                Size = new Size(600, 190),
                AutoScroll = true,
                BackColor = Color.White,
                Padding = new Padding(0, 5, 0, 0)
            };

            if (_availableCategories.Count == 0)
            {
                Label lblEmpty = new Label
                {
                    Text = "Không có danh mục chi tiêu nào khả dụng.",
                    Font = new Font("Segoe UI", 10, FontStyle.Italic),
                    ForeColor = Color.Gray,
                    AutoSize = true,
                    Location = new Point(10, 10)
                };
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
                Size = new Size(100, 100),
                Margin = new Padding(0, 0, 15, 15),
                BackColor = Color.White,
                Cursor = Cursors.Hand,
                Tag = category.CategoryId
            };

            Color displayColor = Color.Black;
            if (category.Color != null && !string.IsNullOrEmpty(category.Color.HexCode))
            {
                try { displayColor = ColorTranslator.FromHtml(category.Color.HexCode); } catch { }
            }

            pnlCard.Paint += (s, e) =>
            {
                Color borderColor = (_selectedCategoryId == category.CategoryId)
                                    ? Color.FromArgb(59, 130, 246)
                                    : Color.FromArgb(226, 232, 240);
                int penWidth = (_selectedCategoryId == category.CategoryId) ? 2 : 1;

                ControlPaint.DrawBorder(e.Graphics, pnlCard.ClientRectangle,
                    borderColor, penWidth, ButtonBorderStyle.Solid,
                    borderColor, penWidth, ButtonBorderStyle.Solid,
                    borderColor, penWidth, ButtonBorderStyle.Solid,
                    borderColor, penWidth, ButtonBorderStyle.Solid);
            };

            Label lblIcon = new Label
            {
                Text = GetEmojiFromIconData(category),
                Font = new Font("Segoe UI", 28),
                ForeColor = displayColor,
                AutoSize = false,
                Size = new Size(100, 55),
                TextAlign = ContentAlignment.BottomCenter,
                Location = new Point(0, 0),
                BackColor = Color.Transparent
            };

            Label lblName = new Label
            {
                Text = category.CategoryName,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                ForeColor = Color.FromArgb(64, 64, 64),
                AutoSize = false,
                Size = new Size(100, 40),
                TextAlign = ContentAlignment.TopCenter,
                Location = new Point(0, 60),
                BackColor = Color.Transparent
            };

            pnlCard.Controls.Add(lblIcon);
            pnlCard.Controls.Add(lblName);

            EventHandler selectAction = (s, e) =>
            {
                _selectedCategoryId = category.CategoryId;
                foreach (Control c in _categoryPanel.Controls) c.Invalidate();
            };
            pnlCard.Click += selectAction;
            lblIcon.Click += selectAction;
            lblName.Click += selectAction;

            return pnlCard;
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
            addBtn.Click += AddBtn_Click;
            cancelBtn.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };
            weekRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            monthRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            tMonthRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
            YearRadioBtn.CheckedChanged += RadioBtn_CheckedChanged;
        }

        private void RadioBtn_CheckedChanged(object sender, EventArgs e) { if (((RadioButton)sender).Checked) UpdateDateRange(); }

        private void UpdateDateRange()
        {
            DateTime start = DateTime.Now.Date;
            DateTime end = start;
            if (weekRadioBtn.Checked) end = start.AddDays(7);
            else if (monthRadioBtn.Checked) end = start.AddMonths(1);
            else if (tMonthRadioBtn.Checked) end = start.AddMonths(3);
            else if (YearRadioBtn.Checked) end = start.AddYears(1);
            fromDateTimePicker.Value = start;
            toDateTimePicker.Value = end;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            if (_selectedCategoryId <= 0) { MessageBox.Show("Vui lòng chọn danh mục!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (!decimal.TryParse(textBox1.Text.Trim(), out decimal amount) || amount <= 0) { MessageBox.Show("Số tiền không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }
            if (fromDateTimePicker.Value.Date >= toDateTimePicker.Value.Date) { MessageBox.Show("Ngày không hợp lệ!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning); return; }

            CreatedBudgetDto = new BudgetCreateDto
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