using ExpenseManager.App.Session;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_CreateTicketUser : UserControl, ICreateTicketView
    {
        private CreateTicketPresenter _presenter;

        // ICreateTicketView implementation
        public string UserId => CurrentUserSession.CurrentUser?.UserId;
        public string Description => txtDescription.Text;
        public string QuestionType => cmbType.SelectedItem?.ToString() ?? "";
        public int SelectedQuestionTypeIndex => cmbType.SelectedIndex;

        public event EventHandler SubmitTicketClicked;
        public event EventHandler CancelClicked;

        public UC_CreateTicketUser()
        {
            InitializeComponent();
            InitializeComboBox();
            InitializePresenter();
        }

        private void InitializePresenter()
        {
            // Initialize dependencies
            var context = new ExpenseDbContext(); // Or inject via constructor
            var repository = new TicketUserRepository(context);
            var service = new TicketUserServices(repository);
            _presenter = new CreateTicketPresenter(this, service);
        }

        private void InitializeComboBox()
        {
            cmbType.Items.Clear();

            // Mục mặc định (placeholder)
            cmbType.Items.Add("-- Choose Type --");

            // Các mục chung
            cmbType.Items.Add("General"); // Mục chung
            cmbType.Items.Add("Bug Report"); // Báo lỗi
            cmbType.Items.Add("Feature Request"); // Yêu cầu tính năng mới

            // Các mục cụ thể cho ứng dụng Expense Manager
            cmbType.Items.Add("Account & Login"); // Vấn đề tài khoản & đăng nhập
            cmbType.Items.Add("Transaction Issue"); // Lỗi liên quan đến giao dịch
            cmbType.Items.Add("Budget & Goals"); // Vấn đề về ngân sách/mục tiêu
            cmbType.Items.Add("Data & Backup"); // Vấn đề về dữ liệu & sao lưu
            cmbType.Items.Add("Payment & Subscription"); // Vấn đề thanh toán & gói dịch vụ
            cmbType.Items.Add("Withdrawals"); // Vấn đề rút tiền
            cmbType.Items.Add("Earning"); // Hỏi đáp về ghi nhận thu nhập

            // Mục cuối cùng
            cmbType.Items.Add("Others"); // Khác

            // Đặt mục "-- Choose Type --" làm mục được chọn mặc định
            cmbType.SelectedIndex = 0;
        }

        public void ShowSuccess(string message)
        {
            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public void SetLoading(bool isLoading)
        {
            btnCreate.Enabled = !isLoading;
            btnCancel.Enabled = !isLoading;
            txtDescription.Enabled = !isLoading;
            cmbType.Enabled = !isLoading;

            if (isLoading)
            {
                Cursor = Cursors.WaitCursor;
                btnCreate.Text = "Creating...";
            }
            else
            {
                Cursor = Cursors.Default;
                btnCreate.Text = "Create";
            }
        }

        public void NavigateBackToList()
        {
            LoadContent(new UC_TicketUser());
        }

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            SubmitTicketClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            CancelClicked?.Invoke(this, EventArgs.Empty);
        }

        private void LoadContent(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }
    }
}