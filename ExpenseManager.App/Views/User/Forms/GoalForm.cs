using ExpenseManager.App.Presenters;
using System;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    public partial class GoalForm : Form
    {
        private readonly GoalsPresenter _presenter;
        private readonly string _userId;
        private readonly int? _goalId;

        public GoalForm(GoalsPresenter presenter, string userId, int? goalId = null)
        {
            InitializeComponent();
            _presenter = presenter;
            _userId = userId;
            _goalId = goalId;

            SetupForm();
        }

        private void SetupForm()
        {
            // Cấu hình DateTimePicker
            dtpDeadline.Format = DateTimePickerFormat.Custom;
            dtpDeadline.CustomFormat = "dd/MM/yyyy";

            // Mặc định deadline là 1 tháng sau
            dtpDeadline.Value = DateTime.Today.AddMonths(1);

            if (_goalId.HasValue)
            {
                this.Text = "Sửa Mục Tiêu";
                btnSave.Text = "Cập Nhật";
                // TODO: Gọi hàm load dữ liệu cũ nếu cần thiết
                // LoadGoalData(_goalId.Value); 
            }
            else
            {
                this.Text = "Thêm Mục Tiêu Mới";
                btnSave.Text = "Tạo Mới";
            }
        }

        private async void BtnSave_Click(object sender, EventArgs e)
        {
            // 1. Validate Tên
            if (string.IsNullOrWhiteSpace(txtGoalName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên mục tiêu", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtGoalName.Focus();
                return;
            }

            // 2. Validate Số Tiền
            if (!decimal.TryParse(txtTargetAmount.Text, out decimal targetAmount) || targetAmount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền mục tiêu hợp lệ (lớn hơn 0)", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTargetAmount.Focus();
                return;
            }

            try
            {
                btnSave.Enabled = false;
                btnSave.Text = "Đang xử lý...";

                // Lấy giá trị ngày hoàn thành (chỉ lấy phần ngày, bỏ giờ phút giây)
                DateTime? completionDate = dtpDeadline.Value.Date;

                if (_goalId.HasValue)
                {
                    // GỌI HÀM UPDATE (truyền completionDate thay vì walletId)
                    await _presenter.UpdateGoalAsync(
                        _goalId.Value,
                        txtGoalName.Text.Trim(),
                        targetAmount,
                        completionDate,
                        "Active"
                    );
                }
                else
                {
                    // GỌI HÀM CREATE (truyền completionDate thay vì walletId)
                    await _presenter.CreateGoalAsync(
                        txtGoalName.Text.Trim(),
                        targetAmount,
                        completionDate
                    );
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSave.Enabled = true;
                btnSave.Text = _goalId.HasValue ? "Cập Nhật" : "Tạo Mới";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}