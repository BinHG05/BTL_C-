using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
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
            _availableCategories = categories;

            // Ẩn comboBox1 cũ, tạo panel mới để hiển thị categories dạng grid
            comboBox1.Visible = false;
            CreateCategoryGridPanel();

            SetupEvents();

            // Mặc định chọn 1 tháng
            monthRadioBtn.Checked = true;
            UpdateDateRange();
        }

        private void CreateCategoryGridPanel()
        {
            // Tạo FlowLayoutPanel để hiển thị categories dạng grid
            _categoryPanel = new FlowLayoutPanel
            {
                Location = new Point(42, 160),
                Size = new Size(520, 150),
                AutoScroll = true,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = System.Drawing.Color.White
            };

            // Thêm các category vào panel
            foreach (var category in _availableCategories)
            {
                var categoryCard = CreateCategoryCard(category);
                _categoryPanel.Controls.Add(categoryCard);
            }

            this.Controls.Add(_categoryPanel);
        }

        private Panel CreateCategoryCard(Category category)
        {
            var panel = new Panel
            {
                Size = new Size(100, 100),
                BorderStyle = BorderStyle.FixedSingle,
                Cursor = Cursors.Hand,
                BackColor = System.Drawing.Color.White,
                Margin = new Padding(5),
                Tag = category.CategoryId
            };

            // Icon/Emoji
            var lblIcon = new Label
            {
                Text = GetCategoryIcon(category.IconId),
                Font = new Font("Segoe UI", 24),
                Location = new Point(30, 15),
                AutoSize = true
            };

            // Tên category
            var lblName = new Label
            {
                Text = category.CategoryName,
                Font = new Font("Segoe UI", 9),
                Location = new Point(5, 70),
                Size = new Size(90, 25),
                TextAlign = ContentAlignment.MiddleCenter
            };

            panel.Controls.Add(lblIcon);
            panel.Controls.Add(lblName);

            // Sự kiện click
            EventHandler clickHandler = (s, e) => SelectCategory(panel, category.CategoryId);
            panel.Click += clickHandler;
            lblIcon.Click += clickHandler;
            lblName.Click += clickHandler;

            return panel;
        }

        private void SelectCategory(Panel selectedPanel, int categoryId)
        {
            // Bỏ chọn tất cả các panel khác
            foreach (Control ctrl in _categoryPanel.Controls)
            {
                if (ctrl is Panel p)
                {
                    p.BackColor = System.Drawing.Color.White;
                    p.BorderStyle = BorderStyle.FixedSingle;
                }
            }

            // Highlight panel được chọn
            selectedPanel.BackColor = System.Drawing.Color.LightGreen;
            selectedPanel.BorderStyle = BorderStyle.Fixed3D;
            _selectedCategoryId = categoryId;
        }

        private string GetCategoryIcon(int iconId)
        {
            // Map IconId sang emoji (bạn có thể lấy từ database)
            var iconMap = new Dictionary<int, string>
            {
                { 1, "👕" }, // Mua sắm
                { 2, "⛽" }, // Đổ xăng
                { 3, "🍴" }, // Ăn uống
                { 4, "🍽️" }, // Ăn sáng
                { 5, "☕" }, // Cà phê
                { 6, "📈" }, // Đầu tư
                { 7, "🏠" }, // Nhà cửa
                { 8, "🎮" }, // Giải trí
            };

            return iconMap.ContainsKey(iconId) ? iconMap[iconId] : "💰";
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

        private void RadioBtn_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                UpdateDateRange();
            }
        }

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
            // Validate category
            if (_selectedCategoryId <= 0)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate amount
            if (!decimal.TryParse(textBox1.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate date range
            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Tạo DTO
            CreatedBudgetDto = new BudgetCreateDto
            {
                CategoryId = _selectedCategoryId,
                BudgetAmount = amount,
                StartDate = fromDateTimePicker.Value,
                EndDate = toDateTimePicker.Value,
                IsRecurring = isRecurringChckBox.Checked
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}