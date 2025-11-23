namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Wallet
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
                _presenter?.Dispose();
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.flpWallets = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAddWallet = new System.Windows.Forms.Button();
            this.pnlBIDVHeader = new System.Windows.Forms.Panel();
            this.lblBIDVTitle = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlTotalBalance = new System.Windows.Forms.Panel();
            this.lblTotalBalanceTitle = new System.Windows.Forms.Label();
            this.lblTotalBalanceAmount = new System.Windows.Forms.Label();
            this.pnlMonthlyExpenses = new System.Windows.Forms.Panel();
            this.lblMonthlyExpensesTitle = new System.Windows.Forms.Label();
            this.lblMonthlyExpensesAmount = new System.Windows.Forms.Label();
            this.pnlCategoryChart = new System.Windows.Forms.Panel();
            this.lblCategoryChartTitle = new System.Windows.Forms.Label();
            this.pnlChartArea = new System.Windows.Forms.Panel();
            this.pieChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.pnlTransactionHistory = new System.Windows.Forms.Panel();
            this.lblNoTransactions = new System.Windows.Forms.Label();
            this.lblPageInfo = new System.Windows.Forms.Label();
            this.btnNextPage = new System.Windows.Forms.Button();
            this.btnPrevPage = new System.Windows.Forms.Button();
            this.lblTransactionTitle = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.pnlEmptyState = new System.Windows.Forms.Panel();
            this.lblEmptyMessage = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeftSidebar.SuspendLayout();
            this.pnlBIDVHeader.SuspendLayout();
            this.pnlTotalBalance.SuspendLayout();
            this.pnlMonthlyExpenses.SuspendLayout();
            this.pnlCategoryChart.SuspendLayout();
            this.pnlChartArea.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).BeginInit();
            this.pnlTransactionHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlEmptyState.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(35, 25, 35, 25);
            this.pnlHeader.Size = new System.Drawing.Size(1600, 140);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTitle.Location = new System.Drawing.Point(35, 25);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(165, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Wallets";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(35, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(336, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Chào mừng bạn đến với Ekash!";
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftSidebar.Controls.Add(this.flpWallets);
            // ❌ ĐÃ XÓA DÒNG btnAddWallet Ở ĐÂY ĐỂ TRÁNH NÓ BỊ DOCK
            this.pnlLeftSidebar.Location = new System.Drawing.Point(30, 160);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(350, 700);
            this.pnlLeftSidebar.TabIndex = 1;
            // 
            // flpWallets
            // 
            this.flpWallets.AutoScroll = true;
            this.flpWallets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpWallets.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWallets.Location = new System.Drawing.Point(0, 0);
            this.flpWallets.Name = "flpWallets";
            this.flpWallets.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.flpWallets.Size = new System.Drawing.Size(350, 700);
            this.flpWallets.TabIndex = 3;
            this.flpWallets.WrapContents = false;
            // 
            // btnAddWallet
            // 
            this.btnAddWallet.BackColor = System.Drawing.Color.White;
            this.btnAddWallet.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddWallet.Dock = System.Windows.Forms.DockStyle.None; // ✅ Đã sửa thành None
            this.btnAddWallet.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnAddWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWallet.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddWallet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAddWallet.Location = new System.Drawing.Point(0, 0);
            this.btnAddWallet.Name = "btnAddWallet";
            this.btnAddWallet.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAddWallet.Size = new System.Drawing.Size(330, 55); // ✅ Chỉnh Width 330 để vừa vặn
            this.btnAddWallet.TabIndex = 2;
            this.btnAddWallet.Text = "⊕  Thêm ví mới";
            this.btnAddWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAddWallet.UseVisualStyleBackColor = false;
            this.btnAddWallet.Margin = new System.Windows.Forms.Padding(0, 10, 0, 0); // ✅ Thêm khoảng cách top
            // 
            // pnlBIDVHeader
            // 
            this.pnlBIDVHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBIDVHeader.BackColor = System.Drawing.Color.White;
            this.pnlBIDVHeader.Controls.Add(this.lblBIDVTitle);
            this.pnlBIDVHeader.Controls.Add(this.btnEdit);
            this.pnlBIDVHeader.Controls.Add(this.btnDelete);
            this.pnlBIDVHeader.Location = new System.Drawing.Point(410, 160);
            this.pnlBIDVHeader.Name = "pnlBIDVHeader";
            this.pnlBIDVHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlBIDVHeader.Size = new System.Drawing.Size(1160, 80);
            this.pnlBIDVHeader.TabIndex = 2;
            // 
            // lblBIDVTitle
            // 
            this.lblBIDVTitle.AutoSize = true;
            this.lblBIDVTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBIDVTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblBIDVTitle.Location = new System.Drawing.Point(30, 17);
            this.lblBIDVTitle.Name = "lblBIDVTitle";
            this.lblBIDVTitle.Size = new System.Drawing.Size(188, 46);
            this.lblBIDVTitle.TabIndex = 0;
            this.lblBIDVTitle.Text = "Chọn một ví";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(920, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 44);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1030, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 44);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // pnlTotalBalance
            // 
            this.pnlTotalBalance.BackColor = System.Drawing.Color.White;
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceTitle);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceAmount);
            this.pnlTotalBalance.Location = new System.Drawing.Point(410, 260);
            this.pnlTotalBalance.Name = "pnlTotalBalance";
            this.pnlTotalBalance.Padding = new System.Windows.Forms.Padding(30);
            this.pnlTotalBalance.Size = new System.Drawing.Size(570, 170);
            this.pnlTotalBalance.TabIndex = 3;
            // 
            // lblTotalBalanceTitle
            // 
            this.lblTotalBalanceTitle.AutoSize = true;
            this.lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTotalBalanceTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            this.lblTotalBalanceTitle.Size = new System.Drawing.Size(123, 25);
            this.lblTotalBalanceTitle.TabIndex = 0;
            this.lblTotalBalanceTitle.Text = "Tổng tiền";
            // 
            // lblTotalBalanceAmount
            // 
            this.lblTotalBalanceAmount.AutoSize = true;
            this.lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTotalBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTotalBalanceAmount.Location = new System.Drawing.Point(30, 70);
            this.lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            this.lblTotalBalanceAmount.Size = new System.Drawing.Size(102, 62);
            this.lblTotalBalanceAmount.TabIndex = 1;
            this.lblTotalBalanceAmount.Text = "0 đ";
            // 
            // pnlMonthlyExpenses
            // 
            this.pnlMonthlyExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMonthlyExpenses.BackColor = System.Drawing.Color.White;
            this.pnlMonthlyExpenses.Controls.Add(this.lblMonthlyExpensesTitle);
            this.pnlMonthlyExpenses.Controls.Add(this.lblMonthlyExpensesAmount);
            this.pnlMonthlyExpenses.Location = new System.Drawing.Point(1000, 260);
            this.pnlMonthlyExpenses.Name = "pnlMonthlyExpenses";
            this.pnlMonthlyExpenses.Padding = new System.Windows.Forms.Padding(30);
            this.pnlMonthlyExpenses.Size = new System.Drawing.Size(570, 170);
            this.pnlMonthlyExpenses.TabIndex = 4;
            // 
            // lblMonthlyExpensesTitle
            // 
            this.lblMonthlyExpensesTitle.AutoSize = true;
            this.lblMonthlyExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblMonthlyExpensesTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblMonthlyExpensesTitle.Location = new System.Drawing.Point(30, 30);
            this.lblMonthlyExpensesTitle.Name = "lblMonthlyExpensesTitle";
            this.lblMonthlyExpensesTitle.Size = new System.Drawing.Size(159, 25);
            this.lblMonthlyExpensesTitle.TabIndex = 0;
            this.lblMonthlyExpensesTitle.Text = "Chi tiêu hàng tháng";
            // 
            // lblMonthlyExpensesAmount
            // 
            this.lblMonthlyExpensesAmount.AutoSize = true;
            this.lblMonthlyExpensesAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblMonthlyExpensesAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMonthlyExpensesAmount.Location = new System.Drawing.Point(30, 70);
            this.lblMonthlyExpensesAmount.Name = "lblMonthlyExpensesAmount";
            this.lblMonthlyExpensesAmount.Size = new System.Drawing.Size(102, 62);
            this.lblMonthlyExpensesAmount.TabIndex = 1;
            this.lblMonthlyExpensesAmount.Text = "0 đ";
            // 
            // pnlCategoryChart
            // 
            this.pnlCategoryChart.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlCategoryChart.BackColor = System.Drawing.Color.White;
            this.pnlCategoryChart.Controls.Add(this.lblCategoryChartTitle);
            this.pnlCategoryChart.Controls.Add(this.pnlChartArea);
            this.pnlCategoryChart.Location = new System.Drawing.Point(410, 450);
            this.pnlCategoryChart.Name = "pnlCategoryChart";
            this.pnlCategoryChart.Padding = new System.Windows.Forms.Padding(30);
            this.pnlCategoryChart.Size = new System.Drawing.Size(1160, 330);
            this.pnlCategoryChart.TabIndex = 5;
            // 
            // lblCategoryChartTitle
            // 
            this.lblCategoryChartTitle.AutoSize = true;
            this.lblCategoryChartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblCategoryChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblCategoryChartTitle.Location = new System.Drawing.Point(30, 30);
            this.lblCategoryChartTitle.Name = "lblCategoryChartTitle";
            this.lblCategoryChartTitle.Size = new System.Drawing.Size(296, 37);
            this.lblCategoryChartTitle.TabIndex = 0;
            this.lblCategoryChartTitle.Text = "Chi Tiêu Theo Danh Mục";
            // 
            // pnlChartArea
            // 
            this.pnlChartArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartArea.BackColor = System.Drawing.Color.White;
            this.pnlChartArea.Controls.Add(this.pieChart);
            this.pnlChartArea.Location = new System.Drawing.Point(30, 80);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(1100, 220);
            this.pnlChartArea.TabIndex = 1;
            // 
            // pieChart
            // 
            chartArea1.Name = "ChartArea1";
            this.pieChart.ChartAreas.Add(chartArea1);
            this.pieChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.pieChart.Legends.Add(legend1);
            this.pieChart.Location = new System.Drawing.Point(0, 0);
            this.pieChart.Name = "pieChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.pieChart.Series.Add(series1);
            this.pieChart.Size = new System.Drawing.Size(1100, 220);
            this.pieChart.TabIndex = 0;
            this.pieChart.Text = "chart1";
            // 
            // pnlTransactionHistory
            // 
            this.pnlTransactionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTransactionHistory.BackColor = System.Drawing.Color.White;
            this.pnlTransactionHistory.Controls.Add(this.lblNoTransactions);
            this.pnlTransactionHistory.Controls.Add(this.lblPageInfo);
            this.pnlTransactionHistory.Controls.Add(this.btnNextPage);
            this.pnlTransactionHistory.Controls.Add(this.btnPrevPage);
            this.pnlTransactionHistory.Controls.Add(this.lblTransactionTitle);
            this.pnlTransactionHistory.Controls.Add(this.dgvTransactions);
            this.pnlTransactionHistory.Location = new System.Drawing.Point(410, 800);
            this.pnlTransactionHistory.Name = "pnlTransactionHistory";
            this.pnlTransactionHistory.Padding = new System.Windows.Forms.Padding(30);
            this.pnlTransactionHistory.Size = new System.Drawing.Size(1160, 750);
            this.pnlTransactionHistory.TabIndex = 6;
            // 
            // lblNoTransactions
            // 
            this.lblNoTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoTransactions.BackColor = System.Drawing.Color.White;
            this.lblNoTransactions.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNoTransactions.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNoTransactions.Location = new System.Drawing.Point(30, 90);
            this.lblNoTransactions.Name = "lblNoTransactions";
            this.lblNoTransactions.Size = new System.Drawing.Size(1100, 400);
            this.lblNoTransactions.TabIndex = 5;
            this.lblNoTransactions.Text = "Chưa có giao dịch nào trong ví này.";
            this.lblNoTransactions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoTransactions.Visible = false;
            // 
            // lblPageInfo
            // 
            this.lblPageInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPageInfo.Location = new System.Drawing.Point(900, 680);
            this.lblPageInfo.Name = "lblPageInfo";
            this.lblPageInfo.Size = new System.Drawing.Size(100, 30);
            this.lblPageInfo.TabIndex = 4;
            this.lblPageInfo.Text = "Page 1 of 1";
            this.lblPageInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNextPage
            // 
            this.btnNextPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNextPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNextPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNextPage.Location = new System.Drawing.Point(1010, 680);
            this.btnNextPage.Name = "btnNextPage";
            this.btnNextPage.Size = new System.Drawing.Size(120, 30);
            this.btnNextPage.TabIndex = 3;
            this.btnNextPage.Text = "Next >";
            this.btnNextPage.UseVisualStyleBackColor = true;
            // 
            // btnPrevPage
            // 
            this.btnPrevPage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrevPage.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPrevPage.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnPrevPage.Location = new System.Drawing.Point(770, 680);
            this.btnPrevPage.Name = "btnPrevPage";
            this.btnPrevPage.Size = new System.Drawing.Size(120, 30);
            this.btnPrevPage.TabIndex = 2;
            this.btnPrevPage.Text = "< Previous";
            this.btnPrevPage.UseVisualStyleBackColor = true;
            // 
            // lblTransactionTitle
            // 
            this.lblTransactionTitle.AutoSize = true;
            this.lblTransactionTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTransactionTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTransactionTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTransactionTitle.Name = "lblTransactionTitle";
            this.lblTransactionTitle.Size = new System.Drawing.Size(238, 37);
            this.lblTransactionTitle.TabIndex = 0;
            this.lblTransactionTitle.Text = "Lịch sử giao dịch";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ColumnHeadersHeight = 45;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvTransactions.Location = new System.Drawing.Point(30, 90);
            this.dgvTransactions.MultiSelect = false;
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowHeadersWidth = 51;
            this.dgvTransactions.RowTemplate.Height = 50;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(1100, 550);
            this.dgvTransactions.TabIndex = 1;
            // 
            // pnlEmptyState
            // 
            this.pnlEmptyState.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlEmptyState.BackColor = System.Drawing.Color.White;
            this.pnlEmptyState.Controls.Add(this.lblEmptyMessage);
            this.pnlEmptyState.Location = new System.Drawing.Point(410, 160);
            this.pnlEmptyState.Name = "pnlEmptyState";
            this.pnlEmptyState.Size = new System.Drawing.Size(1160, 1120);
            this.pnlEmptyState.TabIndex = 7;
            this.pnlEmptyState.Visible = false;
            // 
            // lblEmptyMessage
            // 
            this.lblEmptyMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblEmptyMessage.Font = new System.Drawing.Font("Segoe UI", 14F);
            this.lblEmptyMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblEmptyMessage.Location = new System.Drawing.Point(280, 460);
            this.lblEmptyMessage.Name = "lblEmptyMessage";
            this.lblEmptyMessage.Size = new System.Drawing.Size(600, 80);
            this.lblEmptyMessage.TabIndex = 0;
            this.lblEmptyMessage.Text = "Bạn chưa có ví nào.\r\nHãy bấm \"Thêm ví mới\" để tạo ví đầu tiên!";
            this.lblEmptyMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Wallet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlTransactionHistory);
            this.Controls.Add(this.pnlCategoryChart);
            this.Controls.Add(this.pnlMonthlyExpenses);
            this.Controls.Add(this.pnlTotalBalance);
            this.Controls.Add(this.pnlBIDVHeader);
            this.Controls.Add(this.pnlLeftSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlEmptyState);
            this.Name = "UC_Wallet";
            this.Size = new System.Drawing.Size(1600, 1600);
            this.Load += new System.EventHandler(this.UC_Wallet_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeftSidebar.ResumeLayout(false);
            this.pnlBIDVHeader.ResumeLayout(false);
            this.pnlBIDVHeader.PerformLayout();
            this.pnlTotalBalance.ResumeLayout(false);
            this.pnlTotalBalance.PerformLayout();
            this.pnlMonthlyExpenses.ResumeLayout(false);
            this.pnlMonthlyExpenses.PerformLayout();
            this.pnlCategoryChart.ResumeLayout(false);
            this.pnlCategoryChart.PerformLayout();
            this.pnlChartArea.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pieChart)).EndInit();
            this.pnlTransactionHistory.ResumeLayout(false);
            this.pnlTransactionHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlEmptyState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftSidebar;
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
        private System.Windows.Forms.FlowLayoutPanel flpWallets;
        private System.Windows.Forms.Panel pnlEmptyState;
        private System.Windows.Forms.Label lblEmptyMessage;
        private System.Windows.Forms.DataVisualization.Charting.Chart pieChart;
        private System.Windows.Forms.Label lblPageInfo;
        private System.Windows.Forms.Button btnNextPage;
        private System.Windows.Forms.Button btnPrevPage;
        private System.Windows.Forms.Label lblNoTransactions;
    }
}