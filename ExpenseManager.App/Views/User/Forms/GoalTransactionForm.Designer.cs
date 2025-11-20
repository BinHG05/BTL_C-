namespace ExpenseManager.App.Views.Admin.Forms
{
    partial class GoalTransactionForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            panelDivider = new System.Windows.Forms.Panel();
            lblWallet = new System.Windows.Forms.Label();
            cboWallet = new System.Windows.Forms.ComboBox();
            lblWalletHint = new System.Windows.Forms.Label();
            lblAmount = new System.Windows.Forms.Label();
            txtAmount = new System.Windows.Forms.TextBox();
            lblAmountHint = new System.Windows.Forms.Label();
            lblNote = new System.Windows.Forms.Label();
            txtNote = new System.Windows.Forms.TextBox();
            btnSubmit = new System.Windows.Forms.Button();
            btnCancel = new System.Windows.Forms.Button();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            panelHeader.Location = new System.Drawing.Point(0, 0);
            panelHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new System.Drawing.Size(600, 75);
            panelHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTitle.Location = new System.Drawing.Point(25, 22);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(308, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "💰 Nạp tiền vào mục tiêu";
            // 
            // panelDivider
            // 
            panelDivider.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            panelDivider.Dock = System.Windows.Forms.DockStyle.Top;
            panelDivider.Location = new System.Drawing.Point(0, 75);
            panelDivider.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            panelDivider.Name = "panelDivider";
            panelDivider.Size = new System.Drawing.Size(600, 1);
            panelDivider.TabIndex = 1;
            // 
            // lblWallet
            // 
            lblWallet.AutoSize = true;
            lblWallet.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblWallet.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblWallet.Location = new System.Drawing.Point(31, 100);
            lblWallet.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWallet.Name = "lblWallet";
            lblWallet.Size = new System.Drawing.Size(117, 28);
            lblWallet.TabIndex = 2;
            lblWallet.Text = "💳 Chọn ví";
            // 
            // cboWallet
            // 
            cboWallet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cboWallet.Font = new System.Drawing.Font("Segoe UI", 10F);
            cboWallet.FormattingEnabled = true;
            cboWallet.Location = new System.Drawing.Point(31, 135);
            cboWallet.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            cboWallet.Name = "cboWallet";
            cboWallet.Size = new System.Drawing.Size(536, 36);
            cboWallet.TabIndex = 3;
            //cboWallet.SelectedIndexChanged += CboWallet_SelectedIndexChanged;
            // 
            // lblWalletHint
            // 
            lblWalletHint.AutoSize = true;
            lblWalletHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblWalletHint.ForeColor = System.Drawing.Color.Gray;
            lblWalletHint.Location = new System.Drawing.Point(31, 181);
            lblWalletHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblWalletHint.Name = "lblWalletHint";
            lblWalletHint.Size = new System.Drawing.Size(299, 25);
            lblWalletHint.TabIndex = 4;
            lblWalletHint.Text = "Chọn ví để chuyển tiền vào mục tiêu";
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblAmount.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblAmount.Location = new System.Drawing.Point(31, 231);
            lblAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new System.Drawing.Size(217, 28);
            lblAmount.TabIndex = 5;
            lblAmount.Text = "💵 Số tiền nạp (VNĐ)";
            // 
            // txtAmount
            // 
            txtAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtAmount.Location = new System.Drawing.Point(31, 266);
            txtAmount.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtAmount.Name = "txtAmount";
            txtAmount.PlaceholderText = "Nhập số tiền...";
            txtAmount.Size = new System.Drawing.Size(536, 34);
            txtAmount.TabIndex = 6;
            txtAmount.KeyPress += TxtAmount_KeyPress;
            // 
            // lblAmountHint
            // 
            lblAmountHint.AutoSize = true;
            lblAmountHint.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblAmountHint.ForeColor = System.Drawing.Color.Gray;
            lblAmountHint.Location = new System.Drawing.Point(31, 312);
            lblAmountHint.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAmountHint.Name = "lblAmountHint";
            lblAmountHint.Size = new System.Drawing.Size(235, 25);
            lblAmountHint.TabIndex = 7;
            lblAmountHint.Text = "Nhập số tiền bạn muốn nạp";
            // 
            // lblNote
            // 
            lblNote.AutoSize = true;
            lblNote.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblNote.ForeColor = System.Drawing.Color.FromArgb(71, 85, 105);
            lblNote.Location = new System.Drawing.Point(31, 362);
            lblNote.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNote.Name = "lblNote";
            lblNote.Size = new System.Drawing.Size(224, 28);
            lblNote.TabIndex = 8;
            lblNote.Text = "📝 Ghi chú (Tùy chọn)";
            // 
            // txtNote
            // 
            txtNote.Font = new System.Drawing.Font("Segoe UI", 10F);
            txtNote.Location = new System.Drawing.Point(31, 398);
            txtNote.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            txtNote.MaxLength = 500;
            txtNote.Multiline = true;
            txtNote.Name = "txtNote";
            txtNote.PlaceholderText = "Ví dụ: Tiết kiệm tháng 1, Thưởng cuối năm...";
            txtNote.Size = new System.Drawing.Size(536, 86);
            txtNote.TabIndex = 9;
            // 
            // btnSubmit
            // 
            btnSubmit.BackColor = System.Drawing.Color.FromArgb(13, 110, 253);
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSubmit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnSubmit.ForeColor = System.Drawing.Color.White;
            btnSubmit.Location = new System.Drawing.Point(325, 512);
            btnSubmit.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new System.Drawing.Size(244, 56);
            btnSubmit.TabIndex = 10;
            btnSubmit.Text = "✔ Xác nhận nạp tiền";
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += BtnSubmit_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = System.Drawing.Color.FromArgb(108, 117, 125);
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnCancel.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnCancel.ForeColor = System.Drawing.Color.White;
            btnCancel.Location = new System.Drawing.Point(200, 512);
            btnCancel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new System.Drawing.Size(112, 56);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Hủy";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += BtnCancel_Click;
            // 
            // GoalTransactionForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(600, 600);
            Controls.Add(btnCancel);
            Controls.Add(btnSubmit);
            Controls.Add(txtNote);
            Controls.Add(lblNote);
            Controls.Add(lblAmountHint);
            Controls.Add(txtAmount);
            Controls.Add(lblAmount);
            //Controls.Add(lblWalletBalance);
            Controls.Add(lblWalletHint);
            Controls.Add(cboWallet);
            Controls.Add(lblWallet);
            Controls.Add(panelDivider);
            Controls.Add(panelHeader);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "GoalTransactionForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "Nạp Tiền Vào Mục Tiêu";
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Panel panelHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Panel panelDivider;
        private System.Windows.Forms.Label lblWallet;
        private System.Windows.Forms.ComboBox cboWallet;
        private System.Windows.Forms.Label lblWalletHint;
        //private System.Windows.Forms.Label lblWalletBalance;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblAmountHint;
        private System.Windows.Forms.Label lblNote;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Button btnCancel;
    }
}