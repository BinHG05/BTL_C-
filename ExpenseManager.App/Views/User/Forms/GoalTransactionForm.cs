using ExpenseManager.App.Models.DTOs; 
using ExpenseManager.App.Presenters;
using System;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    public partial class GoalTransactionForm : Form
    {
        private readonly GoalsPresenter _presenter;
        private readonly string _userId;
        private readonly int _goalId; // ID của mục tiêu đang được nạp tiền

        public GoalTransactionForm(GoalsPresenter presenter, string userId, int goalId)
        {
            InitializeComponent();
            _presenter = presenter;
            _userId = userId;
            _goalId = goalId;

            this.Text = "Nạp Tiền Vào Mục Tiêu";
            btnSubmit.Text = "Xác nhận nạp tiền";

            LoadWalletsAsync();
        }

        private async void LoadWalletsAsync()
        {
            try
            {
                // 1. Lấy dữ liệu từ Presenter (List<GoalWalletBalanceDTO>)
                var wallets = await _presenter.GetAvailableWalletsAsync();
                var walletList = wallets.ToList();

                if (walletList.Count > 0)
                {
                    // 2. TẠO LIST HIỂN THỊ (Anonymous Object)
                    // Kết hợp Tên và Số tiền thành 1 chuỗi
                    var displayList = walletList.Select(w => new
                    {
                        w.WalletId,
                        w.Balance,
                        // Format chuỗi hiển thị tại đây
                        DisplayInfo = $"{w.WalletName} - {w.Balance:N0} VNĐ"
                    }).ToList();

                    // 3. Gán vào ComboBox
                    cboWallet.DataSource = displayList;
                    cboWallet.DisplayMember = "DisplayInfo"; // Hiển thị cột DisplayInfo
                    cboWallet.ValueMember = "WalletId";      // Giá trị ngầm là WalletId

                    // Chọn mặc định cái đầu tiên
                    cboWallet.SelectedIndex = 0;

                    btnSubmit.Enabled = true;
                }
                else
                {
                    // Xử lý khi không có ví
                    cboWallet.DataSource = null;
                    cboWallet.Items.Add("Chưa có ví nào");
                    cboWallet.SelectedIndex = 0;
                    btnSubmit.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
        }

        //private void CboWallet_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    // Kiểm tra null và kiểu dữ liệu
        //    if (cboWallet.SelectedItem != null && cboWallet.DataSource != null)
        //    {
        //        // Vì dùng Anonymous Object ở trên, nên ở đây dùng 'dynamic' để lấy dữ liệu
        //        dynamic selectedItem = cboWallet.SelectedItem;

        //        // Kiểm tra xem object có thuộc tính Balance không (tránh lỗi khi list rỗng/string)
        //        try
        //        {
        //            decimal balance = selectedItem.Balance;


        //            if (balance <= 0)
        //            {
        //                lblWalletBalance.ForeColor = System.Drawing.Color.Red;
        //                // lblWalletHint.Text = "Ví này hết tiền"; 
        //            }
        //            else
        //            {
        //                lblWalletBalance.ForeColor = System.Drawing.Color.Green;
        //                // lblWalletHint.Text = "Có thể nạp";
        //            }
        //        }
        //        catch
        //        {
        //            // Bỏ qua nếu lỗi ép kiểu (trường hợp item là string thông báo)
        //        }
        //    }
        //}

        private void TxtAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Chỉ cho phép nhập số và phím điều khiển (như Backspace)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private async void BtnSubmit_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra chọn ví
            if (cboWallet.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn ví nguồn", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cboWallet.Focus();
                return;
            }

            // 2. Kiểm tra số tiền nhập vào
            if (!decimal.TryParse(txtAmount.Text, out decimal amount) || amount <= 0)
            {
                MessageBox.Show("Vui lòng nhập số tiền hợp lệ (lớn hơn 0)", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtAmount.Focus();
                return;
            }

            // 3. Kiểm tra số dư ví
            dynamic selectedWallet = cboWallet.SelectedItem;
            decimal walletBalance = selectedWallet.Balance;

            if (amount > walletBalance)
            {
                MessageBox.Show($"Số dư ví không đủ để thực hiện giao dịch!\nSố dư hiện tại: {walletBalance:N0} ₫",
                    "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                btnSubmit.Enabled = false;
                btnSubmit.Text = "Đang xử lý...";

                var walletId = (int)cboWallet.SelectedValue;

                // GỌI HÀM DEPOSIT (Truyền GoalId vào đầu tiên)
                await _presenter.DepositToGoalAsync(_goalId, walletId, amount, txtNote.Text?.Trim());

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi giao dịch: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnSubmit.Enabled = true;
                btnSubmit.Text = "Xác nhận nạp tiền";
            }
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}