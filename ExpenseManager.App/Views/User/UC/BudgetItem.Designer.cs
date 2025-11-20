namespace ExpenseManager.App.Views.User.UC
{
    partial class BudgetItem
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlDoXang = new System.Windows.Forms.Panel();
            lblDoXangIcon = new System.Windows.Forms.Label();
            lblDoXangName = new System.Windows.Forms.Label();
            lblDoXangAmount = new System.Windows.Forms.Label();
            pnlDoXang.SuspendLayout();
            SuspendLayout();
            // 
            // pnlDoXang
            // 
            pnlDoXang.BackColor = System.Drawing.Color.White;
            pnlDoXang.Controls.Add(lblDoXangIcon);
            pnlDoXang.Controls.Add(lblDoXangName);
            pnlDoXang.Controls.Add(lblDoXangAmount);
            pnlDoXang.Cursor = System.Windows.Forms.Cursors.Hand;
            pnlDoXang.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlDoXang.Location = new System.Drawing.Point(0, 0);
            pnlDoXang.Name = "pnlDoXang";
            pnlDoXang.Padding = new System.Windows.Forms.Padding(20);
            pnlDoXang.Size = new System.Drawing.Size(324, 105);
            pnlDoXang.TabIndex = 2;
            // 
            // lblDoXangIcon
            // 
            lblDoXangIcon.Font = new System.Drawing.Font("Segoe UI", 24F);
            lblDoXangIcon.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDoXangIcon.Location = new System.Drawing.Point(20, 25);
            lblDoXangIcon.Name = "lblDoXangIcon";
            lblDoXangIcon.Size = new System.Drawing.Size(50, 50);
            lblDoXangIcon.TabIndex = 0;
            lblDoXangIcon.Text = "⛽";
            // 
            // lblDoXangName
            // 
            lblDoXangName.AutoSize = true;
            lblDoXangName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblDoXangName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDoXangName.Location = new System.Drawing.Point(100, 45);
            lblDoXangName.Name = "lblDoXangName";
            lblDoXangName.Size = new System.Drawing.Size(150, 30);
            lblDoXangName.TabIndex = 1;
            lblDoXangName.Text = "BudgetName";
            // 
            // lblDoXangAmount
            // 
            lblDoXangAmount.AutoSize = true;
            lblDoXangAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDoXangAmount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDoXangAmount.Location = new System.Drawing.Point(100, 75);
            lblDoXangAmount.Name = "lblDoXangAmount";
            lblDoXangAmount.Size = new System.Drawing.Size(78, 23);
            lblDoXangAmount.TabIndex = 2;
            lblDoXangAmount.Text = "200,000đ";
            // 
            // BudgetItem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(pnlDoXang);
            Name = "BudgetItem";
            Size = new System.Drawing.Size(324, 105);
            pnlDoXang.ResumeLayout(false);
            pnlDoXang.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlDoXang;
        private System.Windows.Forms.Label lblDoXangIcon;
        private System.Windows.Forms.Label lblDoXangName;
        private System.Windows.Forms.Label lblDoXangAmount;
    }
}
