namespace ExpenseManager.App.Views
{
    partial class WalletForm
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblWalletName = new System.Windows.Forms.Label();
            this.txtWalletName = new System.Windows.Forms.TextBox();
            this.lblInitialBalance = new System.Windows.Forms.Label();
            this.txtInitialBalance = new System.Windows.Forms.NumericUpDown();
            this.lblWalletType = new System.Windows.Forms.Label();
            this.cmbWalletType = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(30, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(184, 37);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Thêm Ví Mới";
            // 
            // lblWalletName
            // 
            this.lblWalletName.AutoSize = true;
            this.lblWalletName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWalletName.Location = new System.Drawing.Point(32, 90);
            this.lblWalletName.Name = "lblWalletName";
            this.lblWalletName.Size = new System.Drawing.Size(64, 25);
            this.lblWalletName.TabIndex = 1;
            this.lblWalletName.Text = "Tên ví";
            // 
            // txtWalletName
            // 
            this.txtWalletName.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtWalletName.Location = new System.Drawing.Point(37, 120);
            this.txtWalletName.Name = "txtWalletName";
            this.txtWalletName.Size = new System.Drawing.Size(410, 34);
            this.txtWalletName.TabIndex = 0;
            this.txtWalletName.PlaceholderText = "Ví dụ: Tiền mặt, Vietcombank...";
            // 
            // lblInitialBalance
            // 
            this.lblInitialBalance.AutoSize = true;
            this.lblInitialBalance.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblInitialBalance.Location = new System.Drawing.Point(32, 180);
            this.lblInitialBalance.Name = "lblInitialBalance";
            this.lblInitialBalance.Size = new System.Drawing.Size(139, 25);
            this.lblInitialBalance.TabIndex = 3;
            this.lblInitialBalance.Text = "Số dư ban đầu";
            // 
            // txtInitialBalance
            // 
            this.txtInitialBalance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtInitialBalance.Location = new System.Drawing.Point(37, 210);
            this.txtInitialBalance.Maximum = new decimal(new int[] {
            1000000000,
            0,
            0,
            0});
            this.txtInitialBalance.Name = "txtInitialBalance";
            this.txtInitialBalance.Size = new System.Drawing.Size(410, 34);
            this.txtInitialBalance.TabIndex = 1;
            this.txtInitialBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtInitialBalance.ThousandsSeparator = true;
            // 
            // lblWalletType
            // 
            this.lblWalletType.AutoSize = true;
            this.lblWalletType.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblWalletType.Location = new System.Drawing.Point(32, 270);
            this.lblWalletType.Name = "lblWalletType";
            this.lblWalletType.Size = new System.Drawing.Size(70, 25);
            this.lblWalletType.TabIndex = 5;
            this.lblWalletType.Text = "Loại ví";
            // 
            // cmbWalletType
            // 
            this.cmbWalletType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWalletType.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.cmbWalletType.FormattingEnabled = true;
            this.cmbWalletType.Items.AddRange(new object[] {
            "Tiền mặt (Cash)",
            "Ngân hàng (Bank)",
            "Ví điện tử (E-Wallet)",
            "Thẻ tín dụng (Credit Card)",
            "Khác (Other)"});
            this.cmbWalletType.Location = new System.Drawing.Point(37, 300);
            this.cmbWalletType.Name = "cmbWalletType";
            this.cmbWalletType.Size = new System.Drawing.Size(410, 36);
            this.cmbWalletType.TabIndex = 2;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnCancel.Location = new System.Drawing.Point(217, 370);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 45);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(335, 370);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(112, 45);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Lưu Ví";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // WalletForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(482, 453);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.cmbWalletType);
            this.Controls.Add(this.lblWalletType);
            this.Controls.Add(this.txtInitialBalance);
            this.Controls.Add(this.lblInitialBalance);
            this.Controls.Add(this.txtWalletName);
            this.Controls.Add(this.lblWalletName);
            this.Controls.Add(this.lblTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WalletForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Quản lý Ví";
            ((System.ComponentModel.ISupportInitialize)(this.txtInitialBalance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblWalletName;
        private System.Windows.Forms.TextBox txtWalletName;
        private System.Windows.Forms.Label lblInitialBalance;
        private System.Windows.Forms.NumericUpDown txtInitialBalance;
        private System.Windows.Forms.Label lblWalletType;
        private System.Windows.Forms.ComboBox cmbWalletType;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
    }
}