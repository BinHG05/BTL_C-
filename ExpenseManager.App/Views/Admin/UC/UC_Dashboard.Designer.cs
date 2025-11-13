using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Dashboard
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
            pnlHeader = new Panel();
            lblWelcome = new Label();
            lblSubtitle = new Label();
            pnlStatCards = new FlowLayoutPanel();
            pnlTotalBalance = new Panel();
            lblTotalBalanceTitle = new Label();
            lblTotalBalanceAmount = new Label();
            lblTotalBalanceChange = new Label();
            pnlPeriodChange = new Panel();
            lblPeriodChangeTitle = new Label();
            lblPeriodChangeAmount = new Label();
            lblPeriodChangePercent = new Label();
            pnlPeriodExpenses = new Panel();
            lblPeriodExpensesTitle = new Label();
            lblPeriodExpensesAmount = new Label();
            lblPeriodExpensesPercent = new Label();
            pnlPeriodIncome = new Panel();
            lblPeriodIncomeTitle = new Label();
            lblPeriodIncomeAmount = new Label();
            lblPeriodIncomePercent = new Label();
            pnlMainContent = new TableLayoutPanel();
            pnlBalanceTrends = new Panel();
            lblBalanceTrendsTitle = new Label();
            lblBalanceTrendsAmount = new Label();
            lblBalanceTrendsChange = new Label();
            pnlBalanceChart = new Panel();
            pnlExpensesBreakdown = new Panel();
            lblExpensesTitle = new Label();
            pnlExpensesList = new Panel();
            pnlHeader.SuspendLayout();
            pnlStatCards.SuspendLayout();
            pnlTotalBalance.SuspendLayout();
            pnlPeriodChange.SuspendLayout();
            pnlPeriodExpenses.SuspendLayout();
            pnlPeriodIncome.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlBalanceTrends.SuspendLayout();
            pnlExpensesBreakdown.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(30, 25, 30, 15);
            pnlHeader.Size = new System.Drawing.Size(1400, 100);
            pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            lblWelcome.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblWelcome.Location = new System.Drawing.Point(30, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(178, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Dashboard";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblSubtitle.Location = new System.Drawing.Point(30, 66);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(291, 19);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // pnlStatCards
            // 
            pnlStatCards.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            pnlStatCards.Controls.Add(pnlTotalBalance);
            pnlStatCards.Controls.Add(pnlPeriodChange);
            pnlStatCards.Controls.Add(pnlPeriodExpenses);
            pnlStatCards.Controls.Add(pnlPeriodIncome);
            pnlStatCards.Dock = DockStyle.Top;
            pnlStatCards.Location = new System.Drawing.Point(0, 100);
            pnlStatCards.Name = "pnlStatCards";
            pnlStatCards.Padding = new Padding(20, 10, 20, 20);
            pnlStatCards.Size = new System.Drawing.Size(1400, 180);
            pnlStatCards.TabIndex = 1;
            // 
            // pnlTotalBalance
            // 
            pnlTotalBalance.BackColor = System.Drawing.Color.White;
            pnlTotalBalance.Controls.Add(lblTotalBalanceTitle);
            pnlTotalBalance.Controls.Add(lblTotalBalanceAmount);
            pnlTotalBalance.Controls.Add(lblTotalBalanceChange);
            pnlTotalBalance.Location = new System.Drawing.Point(30, 20);
            pnlTotalBalance.Margin = new Padding(10);
            pnlTotalBalance.Name = "pnlTotalBalance";
            pnlTotalBalance.Padding = new Padding(20);
            pnlTotalBalance.Size = new System.Drawing.Size(310, 135);
            pnlTotalBalance.TabIndex = 0;
            // 
            // lblTotalBalanceTitle
            // 
            lblTotalBalanceTitle.AutoSize = true;
            lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTotalBalanceTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblTotalBalanceTitle.Location = new System.Drawing.Point(20, 20);
            lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            lblTotalBalanceTitle.Size = new System.Drawing.Size(91, 19);
            lblTotalBalanceTitle.TabIndex = 0;
            lblTotalBalanceTitle.Text = "Total Balance";
            // 
            // lblTotalBalanceAmount
            // 
            lblTotalBalanceAmount.AutoSize = true;
            lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTotalBalanceAmount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblTotalBalanceAmount.Location = new System.Drawing.Point(15, 50);
            lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            lblTotalBalanceAmount.Size = new System.Drawing.Size(200, 45);
            lblTotalBalanceAmount.TabIndex = 1;
            lblTotalBalanceAmount.Text = "$ 432568";
            // 
            // lblTotalBalanceChange
            // 
            lblTotalBalanceChange.AutoSize = true;
            lblTotalBalanceChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalBalanceChange.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblTotalBalanceChange.Location = new System.Drawing.Point(20, 105);
            lblTotalBalanceChange.Name = "lblTotalBalanceChange";
            lblTotalBalanceChange.Size = new System.Drawing.Size(180, 15);
            lblTotalBalanceChange.TabIndex = 2;
            lblTotalBalanceChange.Text = "↗ 2.47% Last month $24,478";
            // 
            // pnlPeriodChange
            // 
            pnlPeriodChange.BackColor = System.Drawing.Color.White;
            pnlPeriodChange.Controls.Add(lblPeriodChangeTitle);
            pnlPeriodChange.Controls.Add(lblPeriodChangeAmount);
            pnlPeriodChange.Controls.Add(lblPeriodChangePercent);
            pnlPeriodChange.Location = new System.Drawing.Point(360, 20);
            pnlPeriodChange.Margin = new Padding(10);
            pnlPeriodChange.Name = "pnlPeriodChange";
            pnlPeriodChange.Padding = new Padding(20);
            pnlPeriodChange.Size = new System.Drawing.Size(310, 135);
            pnlPeriodChange.TabIndex = 1;
            // 
            // lblPeriodChangeTitle
            // 
            lblPeriodChangeTitle.AutoSize = true;
            lblPeriodChangeTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPeriodChangeTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblPeriodChangeTitle.Location = new System.Drawing.Point(20, 20);
            lblPeriodChangeTitle.Name = "lblPeriodChangeTitle";
            lblPeriodChangeTitle.Size = new System.Drawing.Size(136, 19);
            lblPeriodChangeTitle.TabIndex = 0;
            lblPeriodChangeTitle.Text = "Total Period Change";
            // 
            // lblPeriodChangeAmount
            // 
            lblPeriodChangeAmount.AutoSize = true;
            lblPeriodChangeAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblPeriodChangeAmount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblPeriodChangeAmount.Location = new System.Drawing.Point(15, 50);
            lblPeriodChangeAmount.Name = "lblPeriodChangeAmount";
            lblPeriodChangeAmount.Size = new System.Drawing.Size(200, 45);
            lblPeriodChangeAmount.TabIndex = 1;
            lblPeriodChangeAmount.Text = "$ 245860";
            // 
            // lblPeriodChangePercent
            // 
            lblPeriodChangePercent.AutoSize = true;
            lblPeriodChangePercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPeriodChangePercent.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblPeriodChangePercent.Location = new System.Drawing.Point(20, 105);
            lblPeriodChangePercent.Name = "lblPeriodChangePercent";
            lblPeriodChangePercent.Size = new System.Drawing.Size(180, 15);
            lblPeriodChangePercent.TabIndex = 2;
            lblPeriodChangePercent.Text = "↗ 2.47% Last month $24,478";
            // 
            // pnlPeriodExpenses
            // 
            pnlPeriodExpenses.BackColor = System.Drawing.Color.White;
            pnlPeriodExpenses.Controls.Add(lblPeriodExpensesTitle);
            pnlPeriodExpenses.Controls.Add(lblPeriodExpensesAmount);
            pnlPeriodExpenses.Controls.Add(lblPeriodExpensesPercent);
            pnlPeriodExpenses.Location = new System.Drawing.Point(690, 20);
            pnlPeriodExpenses.Margin = new Padding(10);
            pnlPeriodExpenses.Name = "pnlPeriodExpenses";
            pnlPeriodExpenses.Padding = new Padding(20);
            pnlPeriodExpenses.Size = new System.Drawing.Size(310, 135);
            pnlPeriodExpenses.TabIndex = 2;
            // 
            // lblPeriodExpensesTitle
            // 
            lblPeriodExpensesTitle.AutoSize = true;
            lblPeriodExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPeriodExpensesTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblPeriodExpensesTitle.Location = new System.Drawing.Point(20, 20);
            lblPeriodExpensesTitle.Name = "lblPeriodExpensesTitle";
            lblPeriodExpensesTitle.Size = new System.Drawing.Size(146, 19);
            lblPeriodExpensesTitle.TabIndex = 0;
            lblPeriodExpensesTitle.Text = "Total Period Expenses";
            // 
            // lblPeriodExpensesAmount
            // 
            lblPeriodExpensesAmount.AutoSize = true;
            lblPeriodExpensesAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblPeriodExpensesAmount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblPeriodExpensesAmount.Location = new System.Drawing.Point(15, 50);
            lblPeriodExpensesAmount.Name = "lblPeriodExpensesAmount";
            lblPeriodExpensesAmount.Size = new System.Drawing.Size(155, 45);
            lblPeriodExpensesAmount.TabIndex = 1;
            lblPeriodExpensesAmount.Text = "$ 25.35";
            // 
            // lblPeriodExpensesPercent
            // 
            lblPeriodExpensesPercent.AutoSize = true;
            lblPeriodExpensesPercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPeriodExpensesPercent.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            lblPeriodExpensesPercent.Location = new System.Drawing.Point(20, 105);
            lblPeriodExpensesPercent.Name = "lblPeriodExpensesPercent";
            lblPeriodExpensesPercent.Size = new System.Drawing.Size(180, 15);
            lblPeriodExpensesPercent.TabIndex = 2;
            lblPeriodExpensesPercent.Text = "↘ 2.47% Last month $24,478";
            // 
            // pnlPeriodIncome
            // 
            pnlPeriodIncome.BackColor = System.Drawing.Color.White;
            pnlPeriodIncome.Controls.Add(lblPeriodIncomeTitle);
            pnlPeriodIncome.Controls.Add(lblPeriodIncomeAmount);
            pnlPeriodIncome.Controls.Add(lblPeriodIncomePercent);
            pnlPeriodIncome.Location = new System.Drawing.Point(1020, 20);
            pnlPeriodIncome.Margin = new Padding(10);
            pnlPeriodIncome.Name = "pnlPeriodIncome";
            pnlPeriodIncome.Padding = new Padding(20);
            pnlPeriodIncome.Size = new System.Drawing.Size(310, 135);
            pnlPeriodIncome.TabIndex = 3;
            // 
            // lblPeriodIncomeTitle
            // 
            lblPeriodIncomeTitle.AutoSize = true;
            lblPeriodIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblPeriodIncomeTitle.ForeColor = System.Drawing.Color.FromArgb(107, 114, 128);
            lblPeriodIncomeTitle.Location = new System.Drawing.Point(20, 20);
            lblPeriodIncomeTitle.Name = "lblPeriodIncomeTitle";
            lblPeriodIncomeTitle.Size = new System.Drawing.Size(137, 19);
            lblPeriodIncomeTitle.TabIndex = 0;
            lblPeriodIncomeTitle.Text = "Total Period Income";
            // 
            // lblPeriodIncomeAmount
            // 
            lblPeriodIncomeAmount.AutoSize = true;
            lblPeriodIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblPeriodIncomeAmount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblPeriodIncomeAmount.Location = new System.Drawing.Point(15, 50);
            lblPeriodIncomeAmount.Name = "lblPeriodIncomeAmount";
            lblPeriodIncomeAmount.Size = new System.Drawing.Size(155, 45);
            lblPeriodIncomeAmount.TabIndex = 1;
            lblPeriodIncomeAmount.Text = "$ 22.56";
            // 
            // lblPeriodIncomePercent
            // 
            lblPeriodIncomePercent.AutoSize = true;
            lblPeriodIncomePercent.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblPeriodIncomePercent.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblPeriodIncomePercent.Location = new System.Drawing.Point(20, 105);
            lblPeriodIncomePercent.Name = "lblPeriodIncomePercent";
            lblPeriodIncomePercent.Size = new System.Drawing.Size(180, 15);
            lblPeriodIncomePercent.TabIndex = 2;
            lblPeriodIncomePercent.Text = "↗ 2.47% Last month $24,478";
            // 
            // pnlMainContent
            // 
            pnlMainContent.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            pnlMainContent.ColumnCount = 2;
            pnlMainContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            pnlMainContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            pnlMainContent.Controls.Add(pnlBalanceTrends, 0, 0);
            pnlMainContent.Controls.Add(pnlExpensesBreakdown, 1, 0);
            pnlMainContent.Dock = DockStyle.Fill;
            pnlMainContent.Location = new System.Drawing.Point(0, 280);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Padding = new Padding(20);
            pnlMainContent.RowCount = 1;
            pnlMainContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            pnlMainContent.Size = new System.Drawing.Size(1400, 520);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlBalanceTrends
            // 
            pnlBalanceTrends.BackColor = System.Drawing.Color.White;
            pnlBalanceTrends.Controls.Add(lblBalanceTrendsTitle);
            pnlBalanceTrends.Controls.Add(lblBalanceTrendsAmount);
            pnlBalanceTrends.Controls.Add(lblBalanceTrendsChange);
            pnlBalanceTrends.Controls.Add(pnlBalanceChart);
            pnlBalanceTrends.Dock = DockStyle.Fill;
            pnlBalanceTrends.Location = new System.Drawing.Point(30, 30);
            pnlBalanceTrends.Margin = new Padding(10);
            pnlBalanceTrends.Name = "pnlBalanceTrends";
            pnlBalanceTrends.Padding = new Padding(25);
            pnlBalanceTrends.Size = new System.Drawing.Size(804, 460);
            pnlBalanceTrends.TabIndex = 0;
            // 
            // lblBalanceTrendsTitle
            // 
            lblBalanceTrendsTitle.AutoSize = true;
            lblBalanceTrendsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblBalanceTrendsTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblBalanceTrendsTitle.Location = new System.Drawing.Point(25, 25);
            lblBalanceTrendsTitle.Name = "lblBalanceTrendsTitle";
            lblBalanceTrendsTitle.Size = new System.Drawing.Size(151, 25);
            lblBalanceTrendsTitle.TabIndex = 0;
            lblBalanceTrendsTitle.Text = "Balance Trends";
            // 
            // lblBalanceTrendsAmount
            // 
            lblBalanceTrendsAmount.AutoSize = true;
            lblBalanceTrendsAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblBalanceTrendsAmount.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblBalanceTrendsAmount.Location = new System.Drawing.Point(25, 65);
            lblBalanceTrendsAmount.Name = "lblBalanceTrendsAmount";
            lblBalanceTrendsAmount.Size = new System.Drawing.Size(181, 37);
            lblBalanceTrendsAmount.TabIndex = 1;
            lblBalanceTrendsAmount.Text = "$221,478";
            // 
            // lblBalanceTrendsChange
            // 
            lblBalanceTrendsChange.AutoSize = true;
            lblBalanceTrendsChange.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblBalanceTrendsChange.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblBalanceTrendsChange.Location = new System.Drawing.Point(700, 30);
            lblBalanceTrendsChange.Name = "lblBalanceTrendsChange";
            lblBalanceTrendsChange.Size = new System.Drawing.Size(79, 19);
            lblBalanceTrendsChange.TabIndex = 2;
            lblBalanceTrendsChange.Text = "↗ 12.25%";
            lblBalanceTrendsChange.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBalanceChart
            // 
            pnlBalanceChart.BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            pnlBalanceChart.Location = new System.Drawing.Point(25, 120);
            pnlBalanceChart.Name = "pnlBalanceChart";
            pnlBalanceChart.Size = new System.Drawing.Size(754, 315);
            pnlBalanceChart.TabIndex = 3;
            // 
            // pnlExpensesBreakdown
            // 
            pnlExpensesBreakdown.BackColor = System.Drawing.Color.White;
            pnlExpensesBreakdown.Controls.Add(lblExpensesTitle);
            pnlExpensesBreakdown.Controls.Add(pnlExpensesList);
            pnlExpensesBreakdown.Dock = DockStyle.Fill;
            pnlExpensesBreakdown.Location = new System.Drawing.Point(854, 30);
            pnlExpensesBreakdown.Margin = new Padding(10);
            pnlExpensesBreakdown.Name = "pnlExpensesBreakdown";
            pnlExpensesBreakdown.Padding = new Padding(25);
            pnlExpensesBreakdown.Size = new System.Drawing.Size(516, 460);
            pnlExpensesBreakdown.TabIndex = 1;
            // 
            // lblExpensesTitle
            // 
            lblExpensesTitle.AutoSize = true;
            lblExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblExpensesTitle.ForeColor = System.Drawing.Color.FromArgb(31, 41, 55);
            lblExpensesTitle.Location = new System.Drawing.Point(25, 25);
            lblExpensesTitle.Name = "lblExpensesTitle";
            lblExpensesTitle.Size = new System.Drawing.Size(269, 25);
            lblExpensesTitle.TabIndex = 0;
            lblExpensesTitle.Text = "Monthly Expenses Breakdown";
            // 
            // pnlExpensesList
            // 
            pnlExpensesList.AutoScroll = true;
            pnlExpensesList.Location = new System.Drawing.Point(25, 70);
            pnlExpensesList.Name = "pnlExpensesList";
            pnlExpensesList.Size = new System.Drawing.Size(466, 365);
            pnlExpensesList.TabIndex = 1;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(249, 250, 251);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlStatCards);
            Controls.Add(pnlHeader);
            Name = "UC_Dashboard";
            Size = new System.Drawing.Size(1400, 800);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlStatCards.ResumeLayout(false);
            pnlTotalBalance.ResumeLayout(false);
            pnlTotalBalance.PerformLayout();
            pnlPeriodChange.ResumeLayout(false);
            pnlPeriodChange.PerformLayout();
            pnlPeriodExpenses.ResumeLayout(false);
            pnlPeriodExpenses.PerformLayout();
            pnlPeriodIncome.ResumeLayout(false);
            pnlPeriodIncome.PerformLayout();
            pnlMainContent.ResumeLayout(false);
            pnlBalanceTrends.ResumeLayout(false);
            pnlBalanceTrends.PerformLayout();
            pnlExpensesBreakdown.ResumeLayout(false);
            pnlExpensesBreakdown.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblWelcome;
        private Label lblSubtitle;
        private FlowLayoutPanel pnlStatCards;
        private Panel pnlTotalBalance;
        private Label lblTotalBalanceTitle;
        private Label lblTotalBalanceAmount;
        private Label lblTotalBalanceChange;
        private Panel pnlPeriodChange;
        private Label lblPeriodChangeTitle;
        private Label lblPeriodChangeAmount;
        private Label lblPeriodChangePercent;
        private Panel pnlPeriodExpenses;
        private Label lblPeriodExpensesTitle;
        private Label lblPeriodExpensesAmount;
        private Label lblPeriodExpensesPercent;
        private Panel pnlPeriodIncome;
        private Label lblPeriodIncomeTitle;
        private Label lblPeriodIncomeAmount;
        private Label lblPeriodIncomePercent;
        private TableLayoutPanel pnlMainContent;
        private Panel pnlBalanceTrends;
        private Label lblBalanceTrendsTitle;
        private Label lblBalanceTrendsAmount;
        private Label lblBalanceTrendsChange;
        private Panel pnlBalanceChart;
        private Panel pnlExpensesBreakdown;
        private Label lblExpensesTitle;
        private Panel pnlExpensesList;
    }
}