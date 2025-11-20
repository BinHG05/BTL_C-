using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;

namespace ExpenseManager.App.Views.User
{
    public partial class BudgetCreateDialog : Form
    {
        // Dữ liệu trả về khi người dùng bấm nút Thêm
        public BudgetCreateDto CreatedBudgetDto { get; private set; }

        public BudgetCreateDialog(List<Category> categories)
        {
            InitializeComponent();
            LoadCategoryCombobox(categories);
            SetupEvents();

            // Mặc định chọn 1 tháng
            monthRadioBtn.Checked = true;
            UpdateDateRange();
        }

        private void LoadCategoryCombobox(List<Category> categories)
        {
            comboBox1.DataSource = categories;
            comboBox1.DisplayMember = "CategoryName"; // Hiển thị tên
            comboBox1.ValueMember = "CategoryId";     // Giá trị ID
            comboBox1.SelectedIndex = -1;             // Chưa chọn gì
            comboBox1.Text = "Chọn categories...";
        }

        private void SetupEvents()
        {
            // Nút Thêm
            addBtn.Click += AddBtn_Click;

            // Nút Hủy
            cancelBtn.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            // Sự kiện chọn khoảng thời gian
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
            DateTime start = DateTime.Now.Date; // Bắt đầu từ hôm nay
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
            // 1. Validate
            if (comboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Lưu ý: Designer của bạn dùng textBox1 cho Amount
            if (!decimal.TryParse(textBox1.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (fromDateTimePicker.Value > toDateTimePicker.Value)
            {
                MessageBox.Show("Ngày bắt đầu không được lớn hơn ngày kết thúc!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Tạo DTO
            CreatedBudgetDto = new BudgetCreateDto
            {
                CategoryId = (int)comboBox1.SelectedValue,
                BudgetAmount = amount,
                StartDate = fromDateTimePicker.Value,
                EndDate = toDateTimePicker.Value,
                IsRecurring = isRecurringChckBox.Checked
            };

            // 3. Trả về kết quả
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}