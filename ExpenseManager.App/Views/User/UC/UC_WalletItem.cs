using ExpenseManager.App.Models.Entities;
using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

// ===== THÊM ALIAS NÀY =====
using DbColor = ExpenseManager.App.Models.Entities.Color;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_WalletItem : UserControl
    {
        private Wallet _wallet;
        public int WalletId => _wallet.WalletId;
        public Wallet Wallet => _wallet;

        public UC_WalletItem(Wallet wallet)
        {
            InitializeComponent();
            _wallet = wallet;
            lblWalletName.Text = wallet.WalletName;
            lblWalletAmount.Text = wallet.Balance.ToString("N0") + "đ";

            try
            {
                IconChar icon = ConvertIconClassToIconChar(wallet.Icon);
                iconPictureBox.IconChar = icon;
            }
            catch (Exception)
            {
                iconPictureBox.IconChar = IconChar.QuestionCircle;
            }
        }

        public void SetSelected(bool isSelected)
        {
            if (isSelected)
            {
                this.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
                lblWalletName.ForeColor = System.Drawing.Color.White;
                lblWalletAmount.ForeColor = System.Drawing.Color.White;
                iconPictureBox.IconColor = System.Drawing.Color.White;
            }
            else
            {
                this.BackColor = System.Drawing.Color.White;
                lblWalletName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
                lblWalletAmount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
                iconPictureBox.IconColor = System.Drawing.Color.FromArgb(30, 41, 59);
            }
        }

        // ===== SỬA LỖI STACKOVERFLOW =====
        private void OnControl_Click(object sender, EventArgs e)
        {
            // Chỉ raise event nếu sender là control con (Label, Icon)
            // Nếu sender là chính UserControl (this), nó đã tự raise event rồi
            // không cần gọi lại base.OnClick() nữa để tránh vòng lặp.
            if (sender != this)
            {
                base.OnClick(e);
            }
        }
        // ===== KẾT THÚC SỬA =====

        private IconChar ConvertIconClassToIconChar(string iconClass)
        {
            if (string.IsNullOrWhiteSpace(iconClass))
                return IconChar.CircleQuestion;

            string name = iconClass.Split(' ').Last();
            name = name.Replace("fa-", "");

            string[] parts = name.Split('-');
            StringBuilder pascalCaseName = new StringBuilder();
            foreach (string part in parts)
            {
                pascalCaseName.Append(char.ToUpper(part[0]) + part.Substring(1));
            }

            if (Enum.TryParse<IconChar>(pascalCaseName.ToString(), true, out IconChar result))
            {
                return result;
            }

            return IconChar.CircleQuestion;
        }
    }
}