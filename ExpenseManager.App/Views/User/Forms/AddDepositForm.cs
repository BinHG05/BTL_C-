using ExpenseManager.App.Contracts;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.Forms
{
    public partial class AddDepositForm : Form, IAddDepositView
    {
        private readonly AddDepositPresenter _presenter;
        private readonly int _goalId; // ID của Goal (cha)
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN"); // Tiền tệ VND

        // Constructor MỚI: Bắt buộc phải có GoalId
        public AddDepositForm(int goalId)
        {
            InitializeComponent();
            _goalId = goalId; // Lưu ID lại

            // --- Khởi tạo MVP ---
            if (!this.DesignMode)
            {
                // 1. Lấy DbContext
                var dbContext = Program.AppDbContext;

                // 2. Khởi tạo các lớp Repository
                var goalRepo = new GoalRepository(dbContext);
                var walletRepo = new WalletRepository(dbContext); // (Repo 2/10)
                var depositRepo = new GoalDepositRepository(dbContext); // (Repo 4/10)

                // 3. Khởi tạo các lớp Service
                var goalService = new GoalService(goalRepo);
                var walletService = new WalletService(walletRepo); // (Service 4/10)
                var depositService = new GoalDepositService(goalRepo, depositRepo); // (Service 6/10)

                // 4. Tạo Presenter (File 8/10)
                _presenter = new AddDepositPresenter(this, goalService, walletService, depositService);
            }

            // --- Gắn sự kiện (Wire Events) ---
            this.Load += AddDepositForm_Load;
            btnSave.Click += (s, e) => SaveDepositClicked?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => CloseDialog(false);
        }

        // Khi Form được tải -> Báo cho Presenter
        private void AddDepositForm_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                LoadView?.Invoke(this, EventArgs.Empty);
            }
        }

        // --- Triển khai Interface IAddDepositView (File 7/10) ---

        // Properties (Lấy dữ liệu từ Giao diện)
        public decimal Amount => numAmount.Value;
        public int GoalId => _goalId; // Trả về ID đã lưu

        // *** THUỘC TÍNH MỚI (Sửa lỗi CSDL) ***
        public int SelectedWalletId
        {
            get
            {
                // Lấy ID của Ví (Wallet) mà người dùng đã chọn
                if (cmbWallets.SelectedValue != null)
                {
                    try
                    {
                        return (int)cmbWallets.SelectedValue;
                    }
                    catch
                    {
                        return 0;
                    }
                }
                return 0; // Trả về 0 (hoặc -1) nếu chưa chọn
            }
        }

        // Events (Báo cho Presenter)
        public event EventHandler SaveDepositClicked;
        public event EventHandler LoadView; 

        // Actions (Presenter ra lệnh)
        public void ShowError(string message)
        {
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(this, message, "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }

        public void CloseDialog(bool success)
        {
            this.Invoke((MethodInvoker)delegate {
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            });
        }

        // (Action này được gọi bởi Presenter (File 8/10) khi Load)
        public void SetGoalDetails(string goalName, decimal currentAmount, decimal targetAmount)
        {
            this.Invoke((MethodInvoker)delegate {
                lblGoalName.Text = goalName;
                // Cập nhật tiền tệ (C0 = không có số lẻ)
                lblGoalProgress.Text = $"Hiện tại: {currentAmount.ToString("C0", _culture)} / {targetAmount.ToString("C0", _culture)}";
            });
        }

        // *** HÀM ĐÃ SỬA LỖI (File 10/10) ***
        // (Được gọi bởi Presenter (File 8/10) khi Load)
        public void SetWallets(List<Wallet> wallets)
        {
            this.Invoke((MethodInvoker)delegate {
                cmbWallets.DataSource = wallets;

                // *** SỬA LỖI: DÙNG "WalletName" (hoặc tên cột đúng của bạn) ***
                // cmbWallets.DisplayMember = "Name"; // (SAI)
                cmbWallets.DisplayMember = "WalletName"; // (ĐÚNG - Giả sử tên cột là WalletName)

                cmbWallets.ValueMember = "WalletId";

                if (wallets.Count > 0)
                {
                    cmbWallets.SelectedIndex = 0;
                }
            });
        }
    }
}
