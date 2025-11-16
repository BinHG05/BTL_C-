using System.Drawing;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.Forms
{
    partial class AddDepositForm
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblTitle;
        private Label lblGoalName;
        private Label lblGoalProgress;
        private Label lblLabelAmount;
        private NumericUpDown numAmount;
        private Button btnSave;
        private Button btnCancel;

        // --- CONTROL MỚI (ĐỂ SỬA LỖI CSDL) ---
        private Label lblLabelWallet;
        private ComboBox cmbWallets; // Hộp chọn Ví

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            lblTitle = new Label();
            lblGoalName = new Label();
            lblGoalProgress = new Label();
            lblLabelAmount = new Label();
            numAmount = new NumericUpDown();
            btnSave = new Button();
            btnCancel = new Button();

            // --- KHỞI TẠO CONTROL MỚI ---
            lblLabelWallet = new Label();
            cmbWallets = new ComboBox();

            ((System.ComponentModel.ISupportInitialize)(numAmount)).BeginInit();
            SuspendLayout();

            // === Form ===
            BackColor = Color.White;
            ClientSize = new Size(500, 480); // Tăng chiều cao 1 chút (trước là 420)
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "Nạp tiền cho Mục tiêu";

            int x = 40;
            int inputWidth = 420;

            // === Title ===
            lblTitle.Text = "Nạp tiền cho Mục tiêu";
            lblTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.AutoSize = true;
            lblTitle.Location = new Point(x, 30); // Y: 30
            Controls.Add(lblTitle);

            // --- Goal Name (Tên mục tiêu) ---
            lblGoalName.Text = "(Đang tải tên mục tiêu...)";
            lblGoalName.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            lblGoalName.ForeColor = Color.FromArgb(126, 58, 242); // Màu tím
            lblGoalName.AutoSize = true;
            lblGoalName.Location = new Point(x, 90); // Y: 90
            Controls.Add(lblGoalName);

            // --- Goal Progress (Tiến độ) ---
            lblGoalProgress.Text = "Hiện tại: 0 ₫ / 0 ₫";
            lblGoalProgress.Font = new Font("Segoe UI", 10F);
            lblGoalProgress.ForeColor = Color.Gray;
            lblGoalProgress.AutoSize = true;
            lblGoalProgress.Location = new Point(x, 125); // Y: 125
            Controls.Add(lblGoalProgress);

            // --- Amount to Deposit (Số tiền nạp) ---
            lblLabelAmount.Text = "Số tiền Nạp (VND)";
            lblLabelAmount.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelAmount.ForeColor = Color.Black;
            lblLabelAmount.AutoSize = true;
            lblLabelAmount.Location = new Point(x, 180); // Y: 180
            Controls.Add(lblLabelAmount);

            numAmount.Font = new Font("Segoe UI", 11F);
            numAmount.Location = new Point(x, 210); // Y: 210
            numAmount.Width = inputWidth;
            numAmount.Height = 45;
            numAmount.DecimalPlaces = 0;
            numAmount.Maximum = new decimal(new int[] { 2000000000, 0, 0, 0 });
            numAmount.ThousandsSeparator = true;
            Controls.Add(numAmount);

            // --- *** CONTROL MỚI: CHỌN VÍ *** ---
            lblLabelWallet.Text = "Nạp tiền từ Ví";
            lblLabelWallet.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            lblLabelWallet.ForeColor = Color.Black;
            lblLabelWallet.AutoSize = true;
            lblLabelWallet.Location = new Point(x, 275); // Y: 275
            Controls.Add(lblLabelWallet);

            cmbWallets.Font = new Font("Segoe UI", 11F);
            cmbWallets.Location = new Point(x, 305); // Y: 305
            cmbWallets.Width = inputWidth;
            cmbWallets.Height = 45;
            cmbWallets.DropDownStyle = ComboBoxStyle.DropDownList; // Bắt buộc chọn
            cmbWallets.FormattingEnabled = true;
            Controls.Add(cmbWallets);


            // === Button Cancel ===
            btnCancel.Text = "Hủy";
            btnCancel.BackColor = Color.WhiteSmoke;
            btnCancel.ForeColor = Color.Black;
            btnCancel.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.FlatAppearance.BorderSize = 1;
            btnCancel.FlatAppearance.BorderColor = Color.LightGray;
            btnCancel.Location = new Point(200, 380); // Y: 380
            btnCancel.Size = new Size(120, 45);
            Controls.Add(btnCancel);

            // === Button Save ===
            btnSave.Text = "Nạp tiền";
            btnSave.BackColor = Color.FromArgb(120, 99, 255);
            btnSave.ForeColor = Color.White;
            btnSave.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Location = new Point(330, 380); // Y: 380
            btnSave.Size = new Size(130, 45);
            Controls.Add(btnSave);

            ((System.ComponentModel.ISupportInitialize)(numAmount)).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}