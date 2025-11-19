namespace ExpenseManager.App.Views.User.UC
{
    partial class UC_WalletItem
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

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.lblWalletName = new System.Windows.Forms.Label();
            this.lblWalletAmount = new System.Windows.Forms.Label();
            this.iconPictureBox = new FontAwesome.Sharp.IconPictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // lblWalletName
            // 
            this.lblWalletName.AutoSize = true;
            this.lblWalletName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblWalletName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblWalletName.Location = new System.Drawing.Point(80, 25);
            this.lblWalletName.Name = "lblWalletName";
            this.lblWalletName.Size = new System.Drawing.Size(125, 30);
            this.lblWalletName.TabIndex = 1;
            this.lblWalletName.Text = "Wallet Name";
            this.lblWalletName.Click += new System.EventHandler(this.OnControl_Click);
            // 
            // lblWalletAmount
            // 
            this.lblWalletAmount.AutoSize = true;
            this.lblWalletAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblWalletAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblWalletAmount.Location = new System.Drawing.Point(80, 55);
            this.lblWalletAmount.Name = "lblWalletAmount";
            this.lblWalletAmount.Size = new System.Drawing.Size(92, 23);
            this.lblWalletAmount.TabIndex = 2;
            this.lblWalletAmount.Text = "190,000đ";
            this.lblWalletAmount.Click += new System.EventHandler(this.OnControl_Click);
            // 
            // iconPictureBox
            // 
            this.iconPictureBox.BackColor = System.Drawing.Color.Transparent;
            this.iconPictureBox.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.iconPictureBox.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.iconPictureBox.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.iconPictureBox.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.iconPictureBox.IconSize = 40;
            this.iconPictureBox.Location = new System.Drawing.Point(20, 30);
            this.iconPictureBox.Name = "iconPictureBox";
            this.iconPictureBox.Size = new System.Drawing.Size(40, 40);
            this.iconPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.iconPictureBox.TabIndex = 5;
            this.iconPictureBox.TabStop = false;
            this.iconPictureBox.Click += new System.EventHandler(this.OnControl_Click);
            // 
            // UC_WalletItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.iconPictureBox);
            this.Controls.Add(this.lblWalletAmount);
            this.Controls.Add(this.lblWalletName);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Margin = new System.Windows.Forms.Padding(3, 3, 3, 10);
            this.Name = "UC_WalletItem";
            this.Padding = new System.Windows.Forms.Padding(20);
            this.Size = new System.Drawing.Size(330, 100);
            this.Click += new System.EventHandler(this.OnControl_Click);
            ((System.ComponentModel.ISupportInitialize)(this.iconPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Label lblWalletName;
        private System.Windows.Forms.Label lblWalletAmount;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox;
    }
}