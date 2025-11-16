namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Wallet
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
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            pnlLeftSidebar = new System.Windows.Forms.Panel();
            pnlMainWallet = new System.Windows.Forms.Panel();
            lblMainWalletIcon = new System.Windows.Forms.Label();
            lblMainWalletName = new System.Windows.Forms.Label();
            lblMainWalletAmount = new System.Windows.Forms.Label();
            pnlCashWallet = new System.Windows.Forms.Panel();
            lblCashIcon = new System.Windows.Forms.Label();
            lblCashName = new System.Windows.Forms.Label();
            lblCashAmount = new System.Windows.Forms.Label();
            btnAddWallet = new System.Windows.Forms.Button();
            pnlBIDVHeader = new System.Windows.Forms.Panel();
            lblBIDVTitle = new System.Windows.Forms.Label();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            pnlTotalBalance = new System.Windows.Forms.Panel();
            lblTotalBalanceTitle = new System.Windows.Forms.Label();
            lblTotalBalanceAmount = new System.Windows.Forms.Label();
            pnlMonthlyExpenses = new System.Windows.Forms.Panel();
            lblMonthlyExpensesTitle = new System.Windows.Forms.Label();
            lblMonthlyExpensesAmount = new System.Windows.Forms.Label();
            pnlCategoryChart = new System.Windows.Forms.Panel();
            lblCategoryChartTitle = new System.Windows.Forms.Label();
            pnlChartArea = new System.Windows.Forms.Panel();
            pnlTransactionHistory = new System.Windows.Forms.Panel();
            lblTransactionTitle = new System.Windows.Forms.Label();
            dgvTransactions = new System.Windows.Forms.DataGridView();
            pnlHeader.SuspendLayout();
            pnlLeftSidebar.SuspendLayout();
            pnlMainWallet.SuspendLayout();
            pnlCashWallet.SuspendLayout();
            pnlBIDVHeader.SuspendLayout();
            pnlTotalBalance.SuspendLayout();
            pnlMonthlyExpenses.SuspendLayout();
            pnlCategoryChart.SuspendLayout();
            pnlTransactionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            // UC_Wallet
            BackColor = System.Drawing.Color.FromArgb(240, 242, 245);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new System.Windows.Forms.Padding(35, 25, 35, 25);
            pnlHeader.Size = new System.Drawing.Size(1600, 140);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTitle.Location = new System.Drawing.Point(35, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(165, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Wallets";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new System.Drawing.Point(35, 90);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(336, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // pnlLeftSidebar
            // 
            pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            pnlLeftSidebar.Controls.Add(pnlMainWallet);
            pnlLeftSidebar.Controls.Add(pnlCashWallet);
            pnlLeftSidebar.Controls.Add(btnAddWallet);
            pnlLeftSidebar.Location = new System.Drawing.Point(30, 160);
            pnlLeftSidebar.Name = "pnlLeftSidebar";
            pnlLeftSidebar.Size = new System.Drawing.Size(350, 700);
            pnlLeftSidebar.TabIndex = 1;
            // 
            // pnlMainWallet
            // 
            pnlMainWallet.BackColor = System.Drawing.Color.FromArgb(67, 56, 202);
            pnlMainWallet.Controls.Add(lblMainWalletIcon);
            pnlMainWallet.Controls.Add(lblMainWalletName);
            pnlMainWallet.Controls.Add(lblMainWalletAmount);
            pnlMainWallet.Location = new System.Drawing.Point(0, 0);
            pnlMainWallet.Name = "pnlMainWallet";
            pnlMainWallet.Padding = new System.Windows.Forms.Padding(25);
            pnlMainWallet.Size = new System.Drawing.Size(330, 190);
            pnlMainWallet.TabIndex = 0;
            // 
            // lblMainWalletIcon
            // 
            lblMainWalletIcon.Font = new System.Drawing.Font("Segoe UI", 28F);
            lblMainWalletIcon.Location = new System.Drawing.Point(25, 25);
            lblMainWalletIcon.Name = "lblMainWalletIcon";
            lblMainWalletIcon.Size = new System.Drawing.Size(60, 60);
            lblMainWalletIcon.TabIndex = 0;
            lblMainWalletIcon.Text = "🏛";
            // 
            // lblMainWalletName
            // 
            lblMainWalletName.AutoSize = true;
            lblMainWalletName.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblMainWalletName.ForeColor = System.Drawing.Color.White;
            lblMainWalletName.Location = new System.Drawing.Point(25, 100);
            lblMainWalletName.Name = "lblMainWalletName";
            lblMainWalletName.Size = new System.Drawing.Size(82, 41);
            lblMainWalletName.TabIndex = 1;
            lblMainWalletName.Text = "BIDV";
            // 
            // lblMainWalletAmount
            // 
            lblMainWalletAmount.AutoSize = true;
            lblMainWalletAmount.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblMainWalletAmount.ForeColor = System.Drawing.Color.White;
            lblMainWalletAmount.Location = new System.Drawing.Point(25, 140);
            lblMainWalletAmount.Name = "lblMainWalletAmount";
            lblMainWalletAmount.Size = new System.Drawing.Size(159, 32);
            lblMainWalletAmount.TabIndex = 2;
            lblMainWalletAmount.Text = "45,104,000đ";
            // 
            // pnlCashWallet
            // 
            pnlCashWallet.BackColor = System.Drawing.Color.White;
            pnlCashWallet.Controls.Add(lblCashIcon);
            pnlCashWallet.Controls.Add(lblCashName);
            pnlCashWallet.Controls.Add(lblCashAmount);
            pnlCashWallet.Location = new System.Drawing.Point(0, 210);
            pnlCashWallet.Name = "pnlCashWallet";
            pnlCashWallet.Padding = new System.Windows.Forms.Padding(20);
            pnlCashWallet.Size = new System.Drawing.Size(330, 100);
            pnlCashWallet.TabIndex = 1;
            // 
            // lblCashIcon
            // 
            lblCashIcon.Font = new System.Drawing.Font("Segoe UI", 24F);
            lblCashIcon.Location = new System.Drawing.Point(20, 25);
            lblCashIcon.Name = "lblCashIcon";
            lblCashIcon.Size = new System.Drawing.Size(50, 50);
            lblCashIcon.TabIndex = 0;
            lblCashIcon.Text = "💵";
            // 
            // lblCashName
            // 
            lblCashName.AutoSize = true;
            lblCashName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            lblCashName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblCashName.Location = new System.Drawing.Point(80, 25);
            lblCashName.Name = "lblCashName";
            lblCashName.Size = new System.Drawing.Size(106, 30);
            lblCashName.TabIndex = 1;
            lblCashName.Text = "Tiền mặt";
            // 
            // lblCashAmount
            // 
            lblCashAmount.AutoSize = true;
            lblCashAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblCashAmount.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblCashAmount.Location = new System.Drawing.Point(80, 55);
            lblCashAmount.Name = "lblCashAmount";
            lblCashAmount.Size = new System.Drawing.Size(92, 23);
            lblCashAmount.TabIndex = 2;
            lblCashAmount.Text = "190,000đ";
            // 
            // btnAddWallet
            // 
            btnAddWallet.BackColor = System.Drawing.Color.White;
            btnAddWallet.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddWallet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnAddWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddWallet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnAddWallet.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnAddWallet.Location = new System.Drawing.Point(0, 330);
            btnAddWallet.Name = "btnAddWallet";
            btnAddWallet.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            btnAddWallet.Size = new System.Drawing.Size(330, 55);
            btnAddWallet.TabIndex = 2;
            btnAddWallet.Text = "⊕  Add new wallet";
            btnAddWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            btnAddWallet.UseVisualStyleBackColor = false;
            // 
            // pnlBIDVHeader
            // 
            pnlBIDVHeader.BackColor = System.Drawing.Color.White;
            pnlBIDVHeader.Controls.Add(lblBIDVTitle);
            pnlBIDVHeader.Controls.Add(btnEdit);
            pnlBIDVHeader.Controls.Add(btnDelete);
            pnlBIDVHeader.Location = new System.Drawing.Point(410, 160);
            pnlBIDVHeader.Name = "pnlBIDVHeader";
            pnlBIDVHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            pnlBIDVHeader.Size = new System.Drawing.Size(1000, 80);
            pnlBIDVHeader.TabIndex = 2;
            // 
            // lblBIDVTitle
            // 
            lblBIDVTitle.AutoSize = true;
            lblBIDVTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblBIDVTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblBIDVTitle.Location = new System.Drawing.Point(30, 20);
            lblBIDVTitle.Name = "lblBIDVTitle";
            lblBIDVTitle.Size = new System.Drawing.Size(92, 46);
            lblBIDVTitle.TabIndex = 0;
            lblBIDVTitle.Text = "BIDV";
            // 
            // btnEdit
            // 
            btnEdit.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(780, 18);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(100, 44);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(890, 18);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(100, 44);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // pnlTotalBalance
            // 
            pnlTotalBalance.BackColor = System.Drawing.Color.White;
            pnlTotalBalance.Controls.Add(lblTotalBalanceTitle);
            pnlTotalBalance.Controls.Add(lblTotalBalanceAmount);
            pnlTotalBalance.Location = new System.Drawing.Point(410, 260);
            pnlTotalBalance.Name = "pnlTotalBalance";
            pnlTotalBalance.Padding = new System.Windows.Forms.Padding(30);
            pnlTotalBalance.Size = new System.Drawing.Size(480, 170);
            pnlTotalBalance.TabIndex = 3;
            // 
            // lblTotalBalanceTitle
            // 
            lblTotalBalanceTitle.AutoSize = true;
            lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblTotalBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTotalBalanceTitle.Location = new System.Drawing.Point(30, 30);
            lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            lblTotalBalanceTitle.Size = new System.Drawing.Size(123, 25);
            lblTotalBalanceTitle.TabIndex = 0;
            lblTotalBalanceTitle.Text = "Total Balance";
            // 
            // lblTotalBalanceAmount
            // 
            lblTotalBalanceAmount.AutoSize = true;
            lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblTotalBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTotalBalanceAmount.Location = new System.Drawing.Point(30, 70);
            lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            lblTotalBalanceAmount.Size = new System.Drawing.Size(299, 62);
            lblTotalBalanceAmount.TabIndex = 1;
            lblTotalBalanceAmount.Text = "45,104,000đ";
            // 
            // pnlMonthlyExpenses
            // 
            pnlMonthlyExpenses.BackColor = System.Drawing.Color.White;
            pnlMonthlyExpenses.Controls.Add(lblMonthlyExpensesTitle);
            pnlMonthlyExpenses.Controls.Add(lblMonthlyExpensesAmount);
            pnlMonthlyExpenses.Location = new System.Drawing.Point(920, 260);
            pnlMonthlyExpenses.Name = "pnlMonthlyExpenses";
            pnlMonthlyExpenses.Padding = new System.Windows.Forms.Padding(30);
            pnlMonthlyExpenses.Size = new System.Drawing.Size(490, 170);
            pnlMonthlyExpenses.TabIndex = 4;
            // 
            // lblMonthlyExpensesTitle
            // 
            lblMonthlyExpensesTitle.AutoSize = true;
            lblMonthlyExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblMonthlyExpensesTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblMonthlyExpensesTitle.Location = new System.Drawing.Point(30, 30);
            lblMonthlyExpensesTitle.Name = "lblMonthlyExpensesTitle";
            lblMonthlyExpensesTitle.Size = new System.Drawing.Size(159, 25);
            lblMonthlyExpensesTitle.TabIndex = 0;
            lblMonthlyExpensesTitle.Text = "Monthly Expenses";
            // 
            // lblMonthlyExpensesAmount
            // 
            lblMonthlyExpensesAmount.AutoSize = true;
            lblMonthlyExpensesAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            lblMonthlyExpensesAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblMonthlyExpensesAmount.Location = new System.Drawing.Point(30, 70);
            lblMonthlyExpensesAmount.Name = "lblMonthlyExpensesAmount";
            lblMonthlyExpensesAmount.Size = new System.Drawing.Size(310, 62);
            lblMonthlyExpensesAmount.TabIndex = 1;
            lblMonthlyExpensesAmount.Text = "36,296,000đ";
            // 
            // pnlCategoryChart
            // 
            pnlCategoryChart.BackColor = System.Drawing.Color.White;
            pnlCategoryChart.Controls.Add(lblCategoryChartTitle);
            pnlCategoryChart.Controls.Add(pnlChartArea);
            pnlCategoryChart.Location = new System.Drawing.Point(410, 450);
            pnlCategoryChart.Name = "pnlCategoryChart";
            pnlCategoryChart.Padding = new System.Windows.Forms.Padding(30);
            pnlCategoryChart.Size = new System.Drawing.Size(1000, 330);
            pnlCategoryChart.TabIndex = 5;
            // 
            // lblCategoryChartTitle
            // 
            lblCategoryChartTitle.AutoSize = true;
            lblCategoryChartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblCategoryChartTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblCategoryChartTitle.Location = new System.Drawing.Point(30, 30);
            lblCategoryChartTitle.Name = "lblCategoryChartTitle";
            lblCategoryChartTitle.Size = new System.Drawing.Size(296, 37);
            lblCategoryChartTitle.TabIndex = 0;
            lblCategoryChartTitle.Text = "Chi Tiêu Theo Danh Mục";
            // 
            // pnlChartArea
            // 
            pnlChartArea.BackColor = System.Drawing.Color.White;
            pnlChartArea.Location = new System.Drawing.Point(30, 80);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Size = new System.Drawing.Size(940, 220);
            pnlChartArea.TabIndex = 1;
            // 
            // pnlTransactionHistory
            // 
            pnlTransactionHistory.BackColor = System.Drawing.Color.White;
            pnlTransactionHistory.Controls.Add(lblTransactionTitle);
            pnlTransactionHistory.Controls.Add(dgvTransactions);
            pnlTransactionHistory.Location = new System.Drawing.Point(410, 800);
            pnlTransactionHistory.Name = "pnlTransactionHistory";
            pnlTransactionHistory.Padding = new System.Windows.Forms.Padding(30);
            pnlTransactionHistory.Size = new System.Drawing.Size(1000, 480);
            pnlTransactionHistory.TabIndex = 6;
            // 
            // lblTransactionTitle
            // 
            lblTransactionTitle.AutoSize = true;
            lblTransactionTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblTransactionTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTransactionTitle.Location = new System.Drawing.Point(30, 30);
            lblTransactionTitle.Name = "lblTransactionTitle";
            lblTransactionTitle.Size = new System.Drawing.Size(238, 37);
            lblTransactionTitle.TabIndex = 0;
            lblTransactionTitle.Text = "Transaction History";
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTransactions.ColumnHeadersHeight = 45;
            dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTransactions.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvTransactions.Location = new System.Drawing.Point(30, 90);
            dgvTransactions.MultiSelect = false;
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dgvTransactions.RowTemplate.Height = 50;
            dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new System.Drawing.Size(940, 360);
            dgvTransactions.TabIndex = 1;
            // 
            // UC_Wallet
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            Controls.Add(pnlTransactionHistory);
            Controls.Add(pnlCategoryChart);
            Controls.Add(pnlMonthlyExpenses);
            Controls.Add(pnlTotalBalance);
            Controls.Add(pnlBIDVHeader);
            Controls.Add(pnlLeftSidebar);
            Controls.Add(pnlHeader);
            Name = "UC_Wallet";
            Size = new System.Drawing.Size(1600, 1400);
            Load += UC_Wallet_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftSidebar.ResumeLayout(false);
            pnlMainWallet.ResumeLayout(false);
            pnlMainWallet.PerformLayout();
            pnlCashWallet.ResumeLayout(false);
            pnlCashWallet.PerformLayout();
            pnlBIDVHeader.ResumeLayout(false);
            pnlBIDVHeader.PerformLayout();
            pnlTotalBalance.ResumeLayout(false);
            pnlTotalBalance.PerformLayout();
            pnlMonthlyExpenses.ResumeLayout(false);
            pnlMonthlyExpenses.PerformLayout();
            pnlCategoryChart.ResumeLayout(false);
            pnlCategoryChart.PerformLayout();
            pnlTransactionHistory.ResumeLayout(false);
            pnlTransactionHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.Panel pnlMainWallet;
        private System.Windows.Forms.Label lblMainWalletIcon;
        private System.Windows.Forms.Label lblMainWalletName;
        private System.Windows.Forms.Label lblMainWalletAmount;
        private System.Windows.Forms.Panel pnlCashWallet;
        private System.Windows.Forms.Label lblCashIcon;
        private System.Windows.Forms.Label lblCashName;
        private System.Windows.Forms.Label lblCashAmount;
        private System.Windows.Forms.Button btnAddWallet;
        private System.Windows.Forms.Panel pnlBIDVHeader;
        private System.Windows.Forms.Label lblBIDVTitle;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Panel pnlTotalBalance;
        private System.Windows.Forms.Label lblTotalBalanceTitle;
        private System.Windows.Forms.Label lblTotalBalanceAmount;
        private System.Windows.Forms.Panel pnlMonthlyExpenses;
        private System.Windows.Forms.Label lblMonthlyExpensesTitle;
        private System.Windows.Forms.Label lblMonthlyExpensesAmount;
        private System.Windows.Forms.Panel pnlCategoryChart;
        private System.Windows.Forms.Label lblCategoryChartTitle;
        private System.Windows.Forms.Panel pnlChartArea;
        private System.Windows.Forms.Panel pnlTransactionHistory;
        private System.Windows.Forms.Label lblTransactionTitle;
        private System.Windows.Forms.DataGridView dgvTransactions;
    }
}