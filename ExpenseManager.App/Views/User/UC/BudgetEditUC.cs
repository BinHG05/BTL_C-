using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class BudgetEditUC : UserControl
    {
        private ComboBox cboCategory;
        private TextBox txtAmount;
        private DateTimePicker dtpStartDate;
        private DateTimePicker dtpEndDate;
        private CheckBox chkIsRecurring;
        private Button btnSave;
        private Button btnCancel;

        public BudgetUpdateDto BudgetData { get; private set; }

        // Sự kiện để thông báo kết quả cho Form cha
        public event EventHandler<BudgetUpdateDto> BudgetUpdated;
        public event EventHandler EditCancelled;

        public BudgetEditUC()
        {
            InitializeComponent();
            SetupControls();
        }

        public BudgetEditUC(IEnumerable<Category> categories, BudgetDetailDto currentBudget) : this()
        {
            LoadCategories(categories);
            LoadCurrentData(currentBudget);
        }

        private void SetupControls()
        {
            // Clear các controls do designer tạo
            this.Controls.Clear();
            this.Size = new Size(500, 400);

            // Title
            var lblTitle = new Label
            {
                Text = "Chỉnh Sửa Ngân Sách",
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
                Format = DateTimePickerFormat.Short
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
                Format = DateTimePickerFormat.Short
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
                Text = "Cập nhật",
                Location = new Point(250, 320),
                Size = new Size(110, 35),
                BackColor = System.Drawing.Color.FromArgb(59, 130, 246),
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

        private void LoadCurrentData(BudgetDetailDto currentBudget)
        {
            // Set selected category by name
            for (int i = 0; i < cboCategory.Items.Count; i++)
            {
                var category = (Category)cboCategory.Items[i];
                if (category.CategoryName == currentBudget.CategoryName)
                {
                    cboCategory.SelectedIndex = i;
                    break;
                }
            }

            txtAmount.Text = currentBudget.BudgetAmount.ToString();
            dtpStartDate.Value = currentBudget.StartDate;
            dtpEndDate.Value = currentBudget.EndDate;
            chkIsRecurring.Checked = currentBudget.IsRecurring;
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
            BudgetData = new BudgetUpdateDto
            {
                CategoryId = (int)cboCategory.SelectedValue,
                BudgetAmount = amount,
                StartDate = dtpStartDate.Value,
                EndDate = dtpEndDate.Value,
                IsRecurring = chkIsRecurring.Checked
            };

            // Gọi sự kiện để thông báo kết quả
            BudgetUpdated?.Invoke(this, BudgetData);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            EditCancelled?.Invoke(this, EventArgs.Empty);
        }

        // Override Dispose để dọn dẹp tài nguyên

    }
}