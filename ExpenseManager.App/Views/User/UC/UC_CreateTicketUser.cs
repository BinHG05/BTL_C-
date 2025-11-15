using System;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_CreateTicketUser : UserControl
    {
        // Event để thông báo cho Form/UC cha khi cần quay lại
        public event EventHandler BackToTicketListRequested;

        public UC_CreateTicketUser()
        {
            InitializeComponent();
            InitializeComboBox();
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

        private void BtnCreate_Click(object sender, EventArgs e)
        {
            // Validate input
            if (cmbType.SelectedIndex == 0)
            {
                MessageBox.Show("Vui lòng chọn loại ticket!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSubject.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Vui lòng nhập mô tả!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ở đây bạn có thể thêm logic lưu ticket vào database
            MessageBox.Show("Ticket đã được tạo thành công!", "Thành công",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Quay lại danh sách ticket
            BackToTicketListRequested?.Invoke(this, EventArgs.Empty);
        }
        private void LoadContent(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            // Quay lại danh sách ticket
            LoadContent(new UC_TicketUser());
        }
    }
}