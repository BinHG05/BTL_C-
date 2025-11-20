using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class BudgetCreateUC : UserControl
    {
        private ComboBox cboCategory;
        private TextBox txtAmount;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private CheckBox chkIsRecurring;
        private Button btnSave;
        private Button btnCancel;

        public BudgetCreateDto BudgetData { get; private set; }

        // Sự kiện để thông báo kết quả cho Form cha
        public event EventHandler<BudgetCreateDto> BudgetCreated;
        public event EventHandler CreateCancelled;

        public BudgetCreateUC()
        {
            InitializeComponent();
            SetupControls();
        }

        public BudgetCreateUC(IEnumerable<Category> categories) : this()
        {
            LoadCategories(categories);
        }

        private void SetupControls()
        {
            // Clear các controls do designer tạo
            this.Controls.Clear();
            this.Size = new Size(500, 400);

            // Title
            var lblTitle = new Label
            {
                Text = "Tạo Ngân Sách Mới",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };

            // Category
            var lblCategory = new Label
            {
                Text = "Danh mục:",
                Location = new Point(20, 70),
                AutoSize = true
            };

            cboCategory = new ComboBox
            {
                Location = new Point(20, 95),
                Size = new Size(440, 30),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Amount
            var lblAmount = new Label
            {
                Text = "Số tiền ngân sách:",
                Location = new Point(20, 140),
                AutoSize = true
            };

            txtAmount = new TextBox
            {
                Location = new Point(20, 165),
                Size = new Size(440, 30)
                // Không có PlaceholderText trong WinForms, bạn có thể dùng Tag hoặc TextHint
            };

            // Start Date
            var lblStartDate = new Label
            {
                Text = "Ngày bắt đầu:",
                Location = new Point(20, 210),
                AutoSize = true
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(20, 235),
                Size = new Size(200, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now
            };

            // End Date
            var lblEndDate = new Label
            {
                Text = "Ngày kết thúc:",
                Location = new Point(260, 210),
                AutoSize = true
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(260, 235),
                Size = new Size(200, 30),
                Format = DateTimePickerFormat.Short,
                Value = DateTime.Now.AddMonths(1)
            };

            // Is Recurring
            chkIsRecurring = new CheckBox
            {
                Text = "Ngân sách định kỳ",
                Location = new Point(20, 280),
                AutoSize = true
            };

            // Buttons
            btnSave = new Button
            {
                Text = "Lưu",
                Location = new Point(260, 320),
                Size = new Size(100, 35),
                BackColor = System.Drawing.Color.FromArgb(99, 102, 241),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(370, 320),
                Size = new Size(90, 35),
                FlatStyle = FlatStyle.Flat
            };
            btnCancel.Click += BtnCancel_Click;

            // Add controls
            this.Controls.AddRange(new Control[]
            {
                lblTitle,
                lblCategory, cboCategory,
                lblAmount, txtAmount,
                lblStartDate, dtpStartDate,
                lblEndDate, dtpEndDate,
                chkIsRecurring,
                btnSave, btnCancel
            });
        }

        private void LoadCategories(IEnumerable<Category> categories)
        {
            cboCategory.DisplayMember = "CategoryName";
            cboCategory.ValueMember = "CategoryId";
            cboCategory.DataSource = categories.ToList();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Validation
            if (cboCategory.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn danh mục", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtAmount.Text))
            {
                MessageBox.Show("Vui lòng nhập số tiền", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Số tiền không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtpEndDate.Value <= dtpStartDate.Value)
            {
                MessageBox.Show("Ngày kết thúc phải sau ngày bắt đầu", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create DTO
            BudgetData = new BudgetCreateDto
            {
                CategoryId = (int)cboCategory.SelectedValue,
                BudgetAmount = amount,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                IsRecurring = chkIsRecurring.Checked
            };

            // Gọi sự kiện để thông báo kết quả
            BudgetCreated?.Invoke(this, BudgetData);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CreateCancelled?.Invoke(this, EventArgs.Empty);
        }

    }
}