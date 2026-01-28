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
            var context = new ExpenseDbContext(); 
            var repository = new TicketUserRepository(context);
            var service = new TicketUserServices(repository);
            _presenter = new CreateTicketPresenter(this, service);
        }

        private void InitializeComboBox()
        {
            cmbType.Items.Clear();

            cmbType.Items.Add("-- Chọn Loại --");

            cmbType.Items.Add("Chung");
            cmbType.Items.Add("Báo lỗi");
            cmbType.Items.Add("Yêu cầu tính năng");

            cmbType.Items.Add("Tài khoản & Đăng nhập");
            cmbType.Items.Add("Lỗi Giao dịch");
            cmbType.Items.Add("Ngân sách & Mục tiêu");
            cmbType.Items.Add("Dữ liệu & Sao lưu");
            cmbType.Items.Add("Thanh toán & Gói dịch vụ");
            cmbType.Items.Add("Vấn đề Rút tiền");
            cmbType.Items.Add("Vấn đề Thu nhập");

            cmbType.Items.Add("Khác");

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
                btnCreate.Text = "Đang tạo...";
            }
            else
            {
                Cursor = Cursors.Default;
                btnCreate.Text = "Tạo";
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