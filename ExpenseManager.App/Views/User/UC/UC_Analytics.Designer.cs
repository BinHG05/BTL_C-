namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Analytics
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            lblHome = new System.Windows.Forms.Label();
            lblSeparator = new System.Windows.Forms.Label();
            lblPageName = new System.Windows.Forms.Label();
            pnlFilterWrapper = new System.Windows.Forms.Panel();
            pnlTabsAndFilters = new System.Windows.Forms.Panel();
            btnExpenses = new System.Windows.Forms.Button();
            btnIncome = new System.Windows.Forms.Button();
            lblChonVi = new System.Windows.Forms.Label();
            cmbWallets = new System.Windows.Forms.ComboBox();
            lblThang = new System.Windows.Forms.Label();
            dtpMonth = new System.Windows.Forms.DateTimePicker();
            btnLoc = new System.Windows.Forms.Button();
            btnReset = new System.Windows.Forms.Button();
            tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            pnlChart = new System.Windows.Forms.Panel();
            lblExpensesBreakdown = new System.Windows.Forms.Label();
            pnlDonutChart = new System.Windows.Forms.Panel();
            flpLegend = new System.Windows.Forms.FlowLayoutPanel();
            pnlHistory = new System.Windows.Forms.Panel();
            lblTransactionHistory = new System.Windows.Forms.Label();
            lblTotalExpenses = new System.Windows.Forms.Label();
            dgvTransactions = new System.Windows.Forms.DataGridView();
            pnlTrendWrapper = new System.Windows.Forms.Panel();
            pnlTrend = new System.Windows.Forms.Panel();
            lblTrendTitle = new System.Windows.Forms.Label();
            pnlLineChart = new System.Windows.Forms.Panel();
            pnlHeader.SuspendLayout();
            pnlFilterWrapper.SuspendLayout();
            pnlTabsAndFilters.SuspendLayout();
            tlpMainContent.SuspendLayout();
            pnlChart.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            pnlTrendWrapper.SuspendLayout();
            pnlTrend.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(lblHome);
            pnlHeader.Controls.Add(lblSeparator);
            pnlHeader.Controls.Add(lblPageName);
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
            lblTitle.Size = new System.Drawing.Size(218, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Phân tích";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new System.Drawing.Point(35, 90);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(417, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Chào mừng đến với Ekash Finance Management";
            // 
            // lblHome
            // 
            lblHome.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblHome.AutoSize = true;
            lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            lblHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblHome.ForeColor = System.Drawing.Color.FromArgb(99, 102, 241);
            lblHome.Location = new System.Drawing.Point(1390, 60);
            lblHome.Name = "lblHome";
            lblHome.Size = new System.Drawing.Size(58, 23);
            lblHome.TabIndex = 2;
            lblHome.Text = "Trang chủ";
            // 
            // lblSeparator
            // 
            lblSeparator.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblSeparator.AutoSize = true;
            lblSeparator.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSeparator.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSeparator.Location = new System.Drawing.Point(1450, 60);
            lblSeparator.Name = "lblSeparator";
            lblSeparator.Size = new System.Drawing.Size(22, 23);
            lblSeparator.TabIndex = 3;
            lblSeparator.Text = ">";
            // 
            // lblPageName
            // 
            lblPageName.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblPageName.AutoSize = true;
            lblPageName.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPageName.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblPageName.Location = new System.Drawing.Point(1470, 60);
            lblPageName.Name = "lblPageName";
            lblPageName.Size = new System.Drawing.Size(72, 23);
            lblPageName.TabIndex = 4;
            lblPageName.Text = "Phân tích";
            // 
            // pnlFilterWrapper
            // 
            pnlFilterWrapper.BackColor = System.Drawing.Color.Transparent;
            pnlFilterWrapper.Controls.Add(pnlTabsAndFilters);
            pnlFilterWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            pnlFilterWrapper.Location = new System.Drawing.Point(0, 140);
            pnlFilterWrapper.Name = "pnlFilterWrapper";
            pnlFilterWrapper.Padding = new System.Windows.Forms.Padding(35, 0, 35, 20);
            pnlFilterWrapper.Size = new System.Drawing.Size(1600, 140);
            pnlFilterWrapper.TabIndex = 1;
            // 
            // pnlTabsAndFilters
            // 
            pnlTabsAndFilters.BackColor = System.Drawing.Color.White;
            pnlTabsAndFilters.Controls.Add(btnExpenses);
            pnlTabsAndFilters.Controls.Add(btnIncome);
            pnlTabsAndFilters.Controls.Add(lblChonVi);
            pnlTabsAndFilters.Controls.Add(cmbWallets);
            pnlTabsAndFilters.Controls.Add(lblThang);
            pnlTabsAndFilters.Controls.Add(dtpMonth);
            pnlTabsAndFilters.Controls.Add(btnLoc);
            pnlTabsAndFilters.Controls.Add(btnReset);
            pnlTabsAndFilters.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTabsAndFilters.Location = new System.Drawing.Point(35, 0);
            pnlTabsAndFilters.Name = "pnlTabsAndFilters";
            pnlTabsAndFilters.Size = new System.Drawing.Size(1530, 120);
            pnlTabsAndFilters.TabIndex = 0;
            // 
            // btnExpenses
            // 
            btnExpenses.Cursor = System.Windows.Forms.Cursors.Hand;
            btnExpenses.FlatAppearance.BorderSize = 0;
            btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnExpenses.ForeColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnExpenses.Location = new System.Drawing.Point(40, 10);
            btnExpenses.Name = "btnExpenses";
            btnExpenses.Size = new System.Drawing.Size(120, 40);
            btnExpenses.TabIndex = 0;
            btnExpenses.Text = "Chi tiêu";
            btnExpenses.UseVisualStyleBackColor = true;
            // 
            // btnIncome
            // 
            btnIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            btnIncome.FlatAppearance.BorderSize = 0;
            btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnIncome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            btnIncome.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            btnIncome.Location = new System.Drawing.Point(170, 10);
            btnIncome.Name = "btnIncome";
            btnIncome.Size = new System.Drawing.Size(120, 40);
            btnIncome.TabIndex = 1;
            btnIncome.Text = "Thu nhập";
            btnIncome.UseVisualStyleBackColor = true;
            // 
            // lblChonVi
            // 
            lblChonVi.AutoSize = true;
            lblChonVi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblChonVi.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblChonVi.Location = new System.Drawing.Point(40, 70);
            lblChonVi.Name = "lblChonVi";
            lblChonVi.Size = new System.Drawing.Size(70, 23);
            lblChonVi.TabIndex = 2;
            lblChonVi.Text = "Chọn ví";
            // 
            // cmbWallets
            // 
            cmbWallets.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbWallets.FormattingEnabled = true;
            cmbWallets.Items.AddRange(new object[] { "Tất cả ví" });
            cmbWallets.Location = new System.Drawing.Point(120, 67);
            cmbWallets.Name = "cmbWallets";
            cmbWallets.Size = new System.Drawing.Size(200, 31);
            cmbWallets.TabIndex = 3;
            cmbWallets.Text = "Tất cả ví";
            // 
            // lblThang
            // 
            lblThang.AutoSize = true;
            lblThang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblThang.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblThang.Location = new System.Drawing.Point(340, 70);
            lblThang.Name = "lblThang";
            lblThang.Size = new System.Drawing.Size(60, 23);
            lblThang.TabIndex = 4;
            lblThang.Text = "Tháng";
            // 
            // dtpMonth
            // 
            dtpMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpMonth.Location = new System.Drawing.Point(410, 67);
            dtpMonth.Name = "dtpMonth";
            dtpMonth.Size = new System.Drawing.Size(200, 30);
            dtpMonth.TabIndex = 5;
            // 
            // btnLoc
            // 
            btnLoc.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            btnLoc.FlatAppearance.BorderSize = 0;
            btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnLoc.ForeColor = System.Drawing.Color.White;
            btnLoc.Location = new System.Drawing.Point(630, 65);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new System.Drawing.Size(100, 35);
            btnLoc.TabIndex = 6;
            btnLoc.Text = "Lọc";
            btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            btnReset.BackColor = System.Drawing.Color.White;
            btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            btnReset.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnReset.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnReset.Location = new System.Drawing.Point(740, 65);
            btnReset.Name = "btnReset";
            btnReset.Size = new System.Drawing.Size(100, 35);
            btnReset.TabIndex = 7;
            btnReset.Text = "Tái lập";
            btnReset.UseVisualStyleBackColor = false;
            // 
            // tlpMainContent
            // 
            tlpMainContent.ColumnCount = 2;
            tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tlpMainContent.Controls.Add(pnlChart, 0, 0);
            tlpMainContent.Controls.Add(pnlHistory, 1, 0);
            tlpMainContent.Dock = System.Windows.Forms.DockStyle.Top;
            tlpMainContent.Location = new System.Drawing.Point(0, 280);
            tlpMainContent.Name = "tlpMainContent";
            tlpMainContent.Padding = new System.Windows.Forms.Padding(30, 0, 30, 20);
            tlpMainContent.RowCount = 1;
            tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpMainContent.Size = new System.Drawing.Size(1600, 620);
            tlpMainContent.TabIndex = 2;
            // 
            // pnlChart
            // 
            pnlChart.BackColor = System.Drawing.Color.White;
            pnlChart.Controls.Add(lblExpensesBreakdown);
            pnlChart.Controls.Add(pnlDonutChart);
            pnlChart.Controls.Add(flpLegend);
            pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlChart.Location = new System.Drawing.Point(33, 3);
            pnlChart.Name = "pnlChart";
            pnlChart.Padding = new System.Windows.Forms.Padding(20);
            pnlChart.Size = new System.Drawing.Size(610, 594);
            pnlChart.TabIndex = 0;
            // 
            // lblExpensesBreakdown
            // 
            lblExpensesBreakdown.AutoSize = true;
            lblExpensesBreakdown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblExpensesBreakdown.Location = new System.Drawing.Point(25, 20);
            lblExpensesBreakdown.Name = "lblExpensesBreakdown";
            lblExpensesBreakdown.Size = new System.Drawing.Size(211, 32);
            lblExpensesBreakdown.TabIndex = 0;
            lblExpensesBreakdown.Text = "Phân tích chi tiêu";
            // 
            // pnlDonutChart
            // 
            pnlDonutChart.Location = new System.Drawing.Point(100, 70);
            pnlDonutChart.Name = "pnlDonutChart";
            pnlDonutChart.Size = new System.Drawing.Size(410, 300);
            pnlDonutChart.TabIndex = 1;
            // 
            // flpLegend
            // 
            flpLegend.AutoScroll = true;
            flpLegend.Location = new System.Drawing.Point(30, 380);
            flpLegend.Name = "flpLegend";
            flpLegend.Size = new System.Drawing.Size(550, 190);
            flpLegend.TabIndex = 2;
            // 
            // pnlHistory
            // 
            pnlHistory.BackColor = System.Drawing.Color.White;
            pnlHistory.Controls.Add(lblTransactionHistory);
            pnlHistory.Controls.Add(lblTotalExpenses);
            pnlHistory.Controls.Add(dgvTransactions);
            pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlHistory.Location = new System.Drawing.Point(649, 3);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.Padding = new System.Windows.Forms.Padding(20);
            pnlHistory.Size = new System.Drawing.Size(918, 594);
            pnlHistory.TabIndex = 1;
            // 
            // lblTransactionHistory
            // 
            lblTransactionHistory.AutoSize = true;
            lblTransactionHistory.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTransactionHistory.Location = new System.Drawing.Point(25, 20);
            lblTransactionHistory.Name = "lblTransactionHistory";
            lblTransactionHistory.Size = new System.Drawing.Size(205, 32);
            lblTransactionHistory.TabIndex = 0;
            lblTransactionHistory.Text = "Lịch sử giao dịch";
            // 
            // lblTotalExpenses
            // 
            lblTotalExpenses.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblTotalExpenses.BackColor = System.Drawing.Color.FromArgb(254, 226, 226);
            lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblTotalExpenses.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            lblTotalExpenses.Location = new System.Drawing.Point(695, 18);
            lblTotalExpenses.Name = "lblTotalExpenses";
            lblTotalExpenses.Padding = new System.Windows.Forms.Padding(10);
            lblTotalExpenses.Size = new System.Drawing.Size(200, 40);
            lblTotalExpenses.TabIndex = 1;
            lblTotalExpenses.Text = "Tổng: 39,326,000đ";
            lblTotalExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvTransactions
            // 
            dgvTransactions.AllowUserToAddRows = false;
            dgvTransactions.AllowUserToDeleteRows = false;
            dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvTransactions.ColumnHeadersHeight = 40;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            dgvTransactions.DefaultCellStyle = dataGridViewCellStyle5;
            dgvTransactions.EnableHeadersVisualStyles = false;
            dgvTransactions.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvTransactions.Location = new System.Drawing.Point(25, 80);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.ReadOnly = true;
            dgvTransactions.RowHeadersVisible = false;
            dgvTransactions.RowHeadersWidth = 51;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            dgvTransactions.RowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvTransactions.RowTemplate.Height = 40;
            dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvTransactions.Size = new System.Drawing.Size(870, 490);
            dgvTransactions.TabIndex = 2;
            // 
            // pnlTrendWrapper
            // 
            pnlTrendWrapper.BackColor = System.Drawing.Color.Transparent;
            pnlTrendWrapper.Controls.Add(pnlTrend);
            pnlTrendWrapper.Dock = System.Windows.Forms.DockStyle.Top;
            pnlTrendWrapper.Location = new System.Drawing.Point(0, 900);
            pnlTrendWrapper.Name = "pnlTrendWrapper";
            pnlTrendWrapper.Padding = new System.Windows.Forms.Padding(35, 0, 35, 20);
            pnlTrendWrapper.Size = new System.Drawing.Size(1600, 420);
            pnlTrendWrapper.TabIndex = 3;
            // 
            // pnlTrend
            // 
            pnlTrend.BackColor = System.Drawing.Color.White;
            pnlTrend.Controls.Add(lblTrendTitle);
            pnlTrend.Controls.Add(pnlLineChart);
            pnlTrend.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTrend.Location = new System.Drawing.Point(35, 0);
            pnlTrend.Name = "pnlTrend";
            pnlTrend.Padding = new System.Windows.Forms.Padding(20);
            pnlTrend.Size = new System.Drawing.Size(1530, 400);
            pnlTrend.TabIndex = 0;
            // 
            // lblTrendTitle
            // 
            lblTrendTitle.AutoSize = true;
            lblTrendTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTrendTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTrendTitle.Location = new System.Drawing.Point(25, 20);
            lblTrendTitle.Name = "lblTrendTitle";
            lblTrendTitle.Size = new System.Drawing.Size(222, 32);
            lblTrendTitle.TabIndex = 0;
            lblTrendTitle.Text = "Xu hướng chi tiêu";
            // 
            // pnlLineChart
            // 
            pnlLineChart.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlLineChart.Location = new System.Drawing.Point(25, 70);
            pnlLineChart.Name = "pnlLineChart";
            pnlLineChart.Size = new System.Drawing.Size(1480, 310);
            pnlLineChart.TabIndex = 1;
            // 
            // UC_Analytics
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            Controls.Add(pnlTrendWrapper);
            Controls.Add(tlpMainContent);
            Controls.Add(pnlFilterWrapper);
            Controls.Add(pnlHeader);
            Name = "UC_Analytics";
            Size = new System.Drawing.Size(1600, 1400);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlFilterWrapper.ResumeLayout(false);
            pnlTabsAndFilters.ResumeLayout(false);
            pnlTabsAndFilters.PerformLayout();
            tlpMainContent.ResumeLayout(false);
            pnlChart.ResumeLayout(false);
            pnlChart.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            pnlTrendWrapper.ResumeLayout(false);
            pnlTrend.ResumeLayout(false);
            pnlTrend.PerformLayout();
            ResumeLayout(false);

        }

        #endregion

        // Khai báo controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label lblPageName;

        // Thêm pnlFilterWrapper
        private System.Windows.Forms.Panel pnlFilterWrapper;
        private System.Windows.Forms.Panel pnlTabsAndFilters;

        private System.Windows.Forms.Button btnExpenses;
        private System.Windows.Forms.Button btnIncome;
        private System.Windows.Forms.Label lblChonVi;
        private System.Windows.Forms.ComboBox cmbWallets;
        private System.Windows.Forms.Label lblThang;
        private System.Windows.Forms.DateTimePicker dtpMonth;
        private System.Windows.Forms.Button btnLoc;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.TableLayoutPanel tlpMainContent;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Label lblExpensesBreakdown;
        private System.Windows.Forms.Panel pnlDonutChart;
        private System.Windows.Forms.FlowLayoutPanel flpLegend;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblTransactionHistory;
        private System.Windows.Forms.Label lblTotalExpenses;
        private System.Windows.Forms.DataGridView dgvTransactions;

        // Trend Chart Controls
        private System.Windows.Forms.Panel pnlTrendWrapper;
        private System.Windows.Forms.Panel pnlTrend;
        private System.Windows.Forms.Label lblTrendTitle;
        private System.Windows.Forms.Panel pnlLineChart;
    }
}