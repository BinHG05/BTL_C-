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
            cmbType.Items.Add("-- Choose Type --");
            cmbType.Items.Add("General");
            cmbType.Items.Add("Bug Report");
            cmbType.Items.Add("Feature Request");
            cmbType.Items.Add("Others");
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