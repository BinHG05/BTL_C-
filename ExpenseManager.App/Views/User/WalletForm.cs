using ExpenseManager.App.Models.Entities;
using System;
using System.Windows.Forms;

namespace ExpenseManager.App.Views
{
    public partial class WalletForm : Form
    {
        // Public properties để Presenter lấy dữ liệu
        public string WalletName => txtWalletName.Text;
        public decimal InitialBalance => txtInitialBalance.Value;

        // Lấy giá trị "thô" (Bank, Cash...)
        public string WalletType
        {
            get
            {
                if (cmbWalletType.SelectedItem == null)
                    return "Other";

                string selected = cmbWalletType.SelectedItem.ToString();
                if (selected.Contains("Bank")) return "Bank";
                if (selected.Contains("Cash")) return "Cash";
                if (selected.Contains("E-Wallet")) return "E-Wallet";
                if (selected.Contains("Credit Card")) return "Credit Card";
                return "Other";
            }
        }

        public WalletForm()
        {
            InitializeComponent();
            cmbWalletType.SelectedIndex = 0; // Chọn "Tiền mặt" làm mặc định
        }

        // Constructor dùng cho "Sửa Ví"
        public WalletForm(Wallet walletToEdit)
        {
            InitializeComponent();

            lblTitle.Text = "Sửa Ví";
            btnSave.Text = "Lưu";

            txtWalletName.Text = walletToEdit.WalletName;

            // Không cho sửa số dư ban đầu và loại ví khi đã tạo
            txtInitialBalance.Value = walletToEdit.InitialBalance;
            txtInitialBalance.Enabled = false; // Khóa không cho sửa

            // Tìm và chọn đúng loại ví
            string type = walletToEdit.WalletType;
            if (type == "Bank") cmbWalletType.SelectedIndex = 1;
            else if (type == "E-Wallet") cmbWalletType.SelectedIndex = 2;
            else if (type == "Credit Card") cmbWalletType.SelectedIndex = 3;
            else if (type == "Other") cmbWalletType.SelectedIndex = 4;
            else cmbWalletType.SelectedIndex = 0; // Cash

            cmbWalletType.Enabled = false; // Khóa không cho sửa
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtWalletName.Text))
            {
                MessageBox.Show("Tên ví không được để trống.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}