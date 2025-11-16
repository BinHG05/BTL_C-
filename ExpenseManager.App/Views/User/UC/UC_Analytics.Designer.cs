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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblHome = new System.Windows.Forms.Label();
            this.lblSeparator = new System.Windows.Forms.Label();
            this.lblPageName = new System.Windows.Forms.Label();
            this.pnlTabsAndFilters = new System.Windows.Forms.Panel();
            this.btnExpenses = new System.Windows.Forms.Button();
            this.btnIncome = new System.Windows.Forms.Button();
            this.lblChonVi = new System.Windows.Forms.Label();
            this.cmbWallets = new System.Windows.Forms.ComboBox();
            this.lblThang = new System.Windows.Forms.Label();
            this.dtpMonth = new System.Windows.Forms.DateTimePicker();
            this.btnLoc = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.tlpMainContent = new System.Windows.Forms.TableLayoutPanel();
            this.pnlChart = new System.Windows.Forms.Panel();
            this.lblExpensesBreakdown = new System.Windows.Forms.Label();
            this.pnlDonutChart = new System.Windows.Forms.Panel();
            this.flpLegend = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblTransactionHistory = new System.Windows.Forms.Label();
            this.lblTotalExpenses = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.pnlHeader.SuspendLayout();
            this.pnlTabsAndFilters.SuspendLayout();
            this.tlpMainContent.SuspendLayout();
            this.pnlChart.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            // *** ĐÃ SỬA MÀU NỀN ***
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent; // Đổi từ White sang Transparent
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.lblHome);
            this.pnlHeader.Controls.Add(this.lblSeparator);
            this.pnlHeader.Controls.Add(this.lblPageName);
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
            this.lblTitle.Size = new System.Drawing.Size(208, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Analytics";
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
            this.lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // lblHome
            // 
            this.lblHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHome.AutoSize = true;
            this.lblHome.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblHome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.lblHome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblHome.Location = new System.Drawing.Point(1390, 60);
            this.lblHome.Name = "lblHome";
            this.lblHome.Size = new System.Drawing.Size(60, 23);
            this.lblHome.TabIndex = 2;
            this.lblHome.Text = "Home";
            // 
            // lblSeparator
            // 
            this.lblSeparator.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSeparator.AutoSize = true;
            this.lblSeparator.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSeparator.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSeparator.Location = new System.Drawing.Point(1450, 60);
            this.lblSeparator.Name = "lblSeparator";
            this.lblSeparator.Size = new System.Drawing.Size(17, 23);
            this.lblSeparator.TabIndex = 3;
            this.lblSeparator.Text = ">";
            // 
            // lblPageName
            // 
            this.lblPageName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPageName.AutoSize = true;
            this.lblPageName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPageName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblPageName.Location = new System.Drawing.Point(1470, 60);
            this.lblPageName.Name = "lblPageName";
            this.lblPageName.Size = new System.Drawing.Size(71, 23);
            this.lblPageName.TabIndex = 4;
            this.lblPageName.Text = "Expense";
            // 
            // pnlTabsAndFilters
            // 
            this.pnlTabsAndFilters.BackColor = System.Drawing.Color.White;
            this.pnlTabsAndFilters.Controls.Add(this.btnExpenses);
            this.pnlTabsAndFilters.Controls.Add(this.btnIncome);
            this.pnlTabsAndFilters.Controls.Add(this.lblChonVi);
            this.pnlTabsAndFilters.Controls.Add(this.cmbWallets);
            this.pnlTabsAndFilters.Controls.Add(this.lblThang);
            this.pnlTabsAndFilters.Controls.Add(this.dtpMonth);
            this.pnlTabsAndFilters.Controls.Add(this.btnLoc);
            this.pnlTabsAndFilters.Controls.Add(this.btnReset);
            this.pnlTabsAndFilters.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTabsAndFilters.Location = new System.Drawing.Point(0, 140);
            this.pnlTabsAndFilters.Name = "pnlTabsAndFilters";
            this.pnlTabsAndFilters.Size = new System.Drawing.Size(1600, 120);
            this.pnlTabsAndFilters.TabIndex = 1;
            // 
            // btnExpenses
            // 
            this.btnExpenses.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExpenses.FlatAppearance.BorderSize = 0;
            this.btnExpenses.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExpenses.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExpenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnExpenses.Location = new System.Drawing.Point(40, 10);
            this.btnExpenses.Name = "btnExpenses";
            this.btnExpenses.Size = new System.Drawing.Size(120, 40);
            this.btnExpenses.TabIndex = 0;
            this.btnExpenses.Text = "Expenses";
            this.btnExpenses.UseVisualStyleBackColor = true;
            // 
            // btnIncome
            // 
            this.btnIncome.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnIncome.FlatAppearance.BorderSize = 0;
            this.btnIncome.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIncome.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnIncome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.btnIncome.Location = new System.Drawing.Point(170, 10);
            this.btnIncome.Name = "btnIncome";
            this.btnIncome.Size = new System.Drawing.Size(120, 40);
            this.btnIncome.TabIndex = 1;
            this.btnIncome.Text = "Income";
            this.btnIncome.UseVisualStyleBackColor = true;
            // 
            // lblChonVi
            // 
            this.lblChonVi.AutoSize = true;
            this.lblChonVi.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblChonVi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChonVi.Location = new System.Drawing.Point(40, 70);
            this.lblChonVi.Name = "lblChonVi";
            this.lblChonVi.Size = new System.Drawing.Size(73, 23);
            this.lblChonVi.TabIndex = 2;
            this.lblChonVi.Text = "Chọn ví";
            // 
            // cmbWallets
            // 
            this.cmbWallets.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbWallets.FormattingEnabled = true;
            this.cmbWallets.Items.AddRange(new object[] { "Tất cả ví" });
            this.cmbWallets.Location = new System.Drawing.Point(120, 67);
            this.cmbWallets.Name = "cmbWallets";
            this.cmbWallets.Size = new System.Drawing.Size(200, 31);
            this.cmbWallets.TabIndex = 3;
            this.cmbWallets.Text = "Tất cả ví";
            // 
            // lblThang
            // 
            this.lblThang.AutoSize = true;
            this.lblThang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblThang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblThang.Location = new System.Drawing.Point(340, 70);
            this.lblThang.Name = "lblThang";
            this.lblThang.Size = new System.Drawing.Size(60, 23);
            this.lblThang.TabIndex = 4;
            this.lblThang.Text = "Tháng";
            // 
            // dtpMonth
            // 
            this.dtpMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpMonth.Location = new System.Drawing.Point(410, 67);
            this.dtpMonth.Name = "dtpMonth";
            this.dtpMonth.Size = new System.Drawing.Size(200, 30);
            this.dtpMonth.TabIndex = 5;
            // 
            // btnLoc
            // 
            this.btnLoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnLoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLoc.FlatAppearance.BorderSize = 0;
            this.btnLoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLoc.ForeColor = System.Drawing.Color.White;
            this.btnLoc.Location = new System.Drawing.Point(630, 65);
            this.btnLoc.Name = "btnLoc";
            this.btnLoc.Size = new System.Drawing.Size(100, 35);
            this.btnLoc.TabIndex = 6;
            this.btnLoc.Text = "Lọc";
            this.btnLoc.UseVisualStyleBackColor = false;
            // 
            // btnReset
            // 
            this.btnReset.BackColor = System.Drawing.Color.White;
            this.btnReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnReset.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReset.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnReset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnReset.Location = new System.Drawing.Point(740, 65);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(100, 35);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = false;
            // 
            // tlpMainContent
            // 
            this.tlpMainContent.ColumnCount = 2;
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tlpMainContent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tlpMainContent.Controls.Add(this.pnlChart, 0, 0);
            this.tlpMainContent.Controls.Add(this.pnlHistory, 1, 0);
            this.tlpMainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMainContent.Location = new System.Drawing.Point(0, 260);
            this.tlpMainContent.Name = "tlpMainContent";
            this.tlpMainContent.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.tlpMainContent.RowCount = 1;
            this.tlpMainContent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMainContent.Size = new System.Drawing.Size(1600, 640);
            this.tlpMainContent.TabIndex = 2;
            // 
            // pnlChart
            // 
            this.pnlChart.BackColor = System.Drawing.Color.White;
            this.pnlChart.Controls.Add(this.lblExpensesBreakdown);
            this.pnlChart.Controls.Add(this.pnlDonutChart);
            this.pnlChart.Controls.Add(this.flpLegend);
            this.pnlChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlChart.Location = new System.Drawing.Point(33, 23);
            this.pnlChart.Name = "pnlChart";
            this.pnlChart.Padding = new System.Windows.Forms.Padding(20);
            this.pnlChart.Size = new System.Drawing.Size(610, 594);
            this.pnlChart.TabIndex = 0;
            // 
            // lblExpensesBreakdown
            // 
            this.lblExpensesBreakdown.AutoSize = true;
            this.lblExpensesBreakdown.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblExpensesBreakdown.Location = new System.Drawing.Point(25, 20);
            this.lblExpensesBreakdown.Name = "lblExpensesBreakdown";
            this.lblExpensesBreakdown.Size = new System.Drawing.Size(243, 32);
            this.lblExpensesBreakdown.TabIndex = 0;
            this.lblExpensesBreakdown.Text = "Expenses Breakdown";
            // 
            // pnlDonutChart
            // 
            this.pnlDonutChart.Location = new System.Drawing.Point(100, 70);
            this.pnlDonutChart.Name = "pnlDonutChart";
            this.pnlDonutChart.Size = new System.Drawing.Size(410, 300);
            this.pnlDonutChart.TabIndex = 1;
            // 
            // flpLegend
            // 
            this.flpLegend.AutoScroll = true;
            this.flpLegend.Location = new System.Drawing.Point(30, 380);
            this.flpLegend.Name = "flpLegend";
            this.flpLegend.Size = new System.Drawing.Size(550, 190);
            this.flpLegend.TabIndex = 2;
            // 
            // pnlHistory
            // 
            this.pnlHistory.BackColor = System.Drawing.Color.White;
            this.pnlHistory.Controls.Add(this.lblTransactionHistory);
            this.pnlHistory.Controls.Add(this.lblTotalExpenses);
            this.pnlHistory.Controls.Add(this.dgvTransactions);
            this.pnlHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHistory.Location = new System.Drawing.Point(649, 23);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Padding = new System.Windows.Forms.Padding(20);
            this.pnlHistory.Size = new System.Drawing.Size(918, 594);
            this.pnlHistory.TabIndex = 1;
            // 
            // lblTransactionHistory
            // 
            this.lblTransactionHistory.AutoSize = true;
            this.lblTransactionHistory.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTransactionHistory.Location = new System.Drawing.Point(25, 20);
            this.lblTransactionHistory.Name = "lblTransactionHistory";
            this.lblTransactionHistory.Size = new System.Drawing.Size(232, 32);
            this.lblTransactionHistory.TabIndex = 0;
            this.lblTransactionHistory.Text = "Transaction History";
            // 
            // lblTotalExpenses
            // 
            this.lblTotalExpenses.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalExpenses.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(254)))), ((int)(((byte)(226)))), ((int)(((byte)(226)))));
            this.lblTotalExpenses.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotalExpenses.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblTotalExpenses.Location = new System.Drawing.Point(698, 20);
            this.lblTotalExpenses.Name = "lblTotalExpenses";
            this.lblTotalExpenses.Padding = new System.Windows.Forms.Padding(10);
            this.lblTotalExpenses.Size = new System.Drawing.Size(200, 40);
            this.lblTotalExpenses.TabIndex = 1;
            this.lblTotalExpenses.Text = "Tổng: 39,326,000đ";
            this.lblTotalExpenses.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.AllowUserToAddRows = false;
            this.dgvTransactions.AllowUserToDeleteRows = false;
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvTransactions.ColumnHeadersHeight = 40;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTransactions.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTransactions.EnableHeadersVisualStyles = false;
            this.dgvTransactions.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvTransactions.Location = new System.Drawing.Point(25, 80);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.ReadOnly = true;
            this.dgvTransactions.RowHeadersVisible = false;
            this.dgvTransactions.RowHeadersWidth = 51;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTransactions.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvTransactions.RowTemplate.Height = 40;
            this.dgvTransactions.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTransactions.Size = new System.Drawing.Size(870, 490);
            this.dgvTransactions.TabIndex = 2;
            // 
            // UC_Analytics
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.tlpMainContent);
            this.Controls.Add(this.pnlTabsAndFilters);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Analytics";
            this.Size = new System.Drawing.Size(1600, 900);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTabsAndFilters.ResumeLayout(false);
            this.pnlTabsAndFilters.PerformLayout();
            this.tlpMainContent.ResumeLayout(false);
            this.pnlChart.ResumeLayout(false);
            this.pnlChart.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        // Khai báo controls
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblHome;
        private System.Windows.Forms.Label lblSeparator;
        private System.Windows.Forms.Label lblPageName;
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
    }
}