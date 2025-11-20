using System;
using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Forms
{
    public partial class AddIconForm : Form
    {
        public string IconName { get; private set; }
        public string IconClass { get; private set; }

        public AddIconForm()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIconName.Text))
            {
                MessageBox.Show("Vui lòng nhập tên icon!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIconName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtIconClass.Text))
            {
                MessageBox.Show("Vui lòng nhập FontAwesome class!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIconClass.Focus();
                return;
            }

            IconName = txtIconName.Text.Trim();
            IconClass = txtIconClass.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }
    }
}