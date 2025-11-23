using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Dashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.pnlHeader = new Panel();
            this.lblWelcome = new Label();
            this.lblSubtitle = new Label();
            this.pnlStatCards = new FlowLayoutPanel();
            this.pnlTotalBalance = new Panel();
            this.lblTotalBalanceTitle = new Label();
            this.lblTotalBalanceAmount = new Label();
            this.lblTotalBalanceChange = new Label();
            this.pnlPeriodChange = new Panel();
            this.lblPeriodChangeTitle = new Label();
            this.lblPeriodChangeAmount = new Label();
            this.lblPeriodChangePercent = new Label();
            this.pnlPeriodExpenses = new Panel();
            this.lblPeriodExpensesTitle = new Label();
            this.lblPeriodExpensesAmount = new Label();
            this.lblPeriodExpensesPercent = new Label();
            this.pnlPeriodIncome = new Panel();
            this.lblPeriodIncomeTitle = new Label();
            this.lblPeriodIncomeAmount = new Label();
            this.lblPeriodIncomePercent = new Label();
            this.pnlMainContent = new TableLayoutPanel();
            this.pnlBalanceTrends = new Panel();
            this.lblBalanceTrendsTitle = new Label();
            this.lblBalanceTrendsAmount = new Label();
            this.lblBalanceTrendsChange = new Label();
            this.pnlBalanceChart = new Panel();
            this.pnlExpensesBreakdown = new Panel();
            this.lblExpensesTitle = new Label();
            this.pnlExpensesList = new Panel();

            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Padding = new Padding(30, 25, 30, 15);
            this.pnlHeader.Size = new System.Drawing.Size(1400, 100);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblSubtitle);

            // 
            // lblWelcome (TIÊU ĐỀ LỚN)
            // 
            this.lblWelcome.Text = "Tổng quan"; // Đã Việt hóa
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 25);
            this.lblWelcome.AutoSize = true;

            // 
            // lblSubtitle (LỜI CHÀO)
            // 
            this.lblSubtitle.Text = "Chào mừng bạn đến với Ekash"; // Đã Việt hóa
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(30, 66);
            this.lblSubtitle.AutoSize = true;

            // 
            // pnlStatCards (CONTAINER 4 Ô)
            // 
            this.pnlStatCards.Dock = DockStyle.Top;
            this.pnlStatCards.Size = new System.Drawing.Size(1400, 180);
            this.pnlStatCards.Padding = new Padding(20, 10, 20, 20);
            this.pnlStatCards.Controls.Add(this.pnlTotalBalance);
            this.pnlStatCards.Controls.Add(this.pnlPeriodIncome);  // Đảo thứ tự cho đúng logic bạn muốn
            this.pnlStatCards.Controls.Add(this.pnlPeriodExpenses);
            this.pnlStatCards.Controls.Add(this.pnlPeriodChange);  // Ô này giờ là Ngân sách

            // 
            // Ô 1: TỔNG SỐ DƯ (pnlTotalBalance)
            // 
            this.pnlTotalBalance.BackColor = System.Drawing.Color.White;
            this.pnlTotalBalance.Size = new System.Drawing.Size(310, 135);
            this.pnlTotalBalance.Margin = new Padding(10);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceTitle);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceAmount);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceChange);

            this.lblTotalBalanceTitle.Text = "Tổng Số Dư"; // Đã Việt hóa
            this.lblTotalBalanceTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTotalBalanceTitle.AutoSize = true;
            this.lblTotalBalanceTitle.ForeColor = System.Drawing.Color.Gray;

            this.lblTotalBalanceAmount.Text = "0đ";
            this.lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalBalanceAmount.Location = new System.Drawing.Point(15, 50);
            this.lblTotalBalanceAmount.AutoSize = true;

            this.lblTotalBalanceChange.Text = "---";
            this.lblTotalBalanceChange.Location = new System.Drawing.Point(20, 105);
            this.lblTotalBalanceChange.AutoSize = true;

            // 
            // Ô 2: THU NHẬP (pnlPeriodIncome)
            // 
            this.pnlPeriodIncome.BackColor = System.Drawing.Color.White;
            this.pnlPeriodIncome.Size = new System.Drawing.Size(310, 135);
            this.pnlPeriodIncome.Margin = new Padding(10);
            this.pnlPeriodIncome.Controls.Add(this.lblPeriodIncomeTitle);
            this.pnlPeriodIncome.Controls.Add(this.lblPeriodIncomeAmount);
            this.pnlPeriodIncome.Controls.Add(this.lblPeriodIncomePercent);

            this.lblPeriodIncomeTitle.Text = "Thu Nhập (Tháng Này)"; // Đã Việt hóa
            this.lblPeriodIncomeTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPeriodIncomeTitle.AutoSize = true;
            this.lblPeriodIncomeTitle.ForeColor = System.Drawing.Color.Gray;

            this.lblPeriodIncomeAmount.Text = "0đ";
            this.lblPeriodIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPeriodIncomeAmount.Location = new System.Drawing.Point(15, 50);
            this.lblPeriodIncomeAmount.AutoSize = true;
            this.lblPeriodIncomeAmount.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94); // Xanh lá

            this.lblPeriodIncomePercent.Text = "Chào mừng bạn!";
            this.lblPeriodIncomePercent.Location = new System.Drawing.Point(20, 105);
            this.lblPeriodIncomePercent.AutoSize = true;

            // 
            // Ô 3: CHI TIÊU (pnlPeriodExpenses)
            // 
            this.pnlPeriodExpenses.BackColor = System.Drawing.Color.White;
            this.pnlPeriodExpenses.Size = new System.Drawing.Size(310, 135);
            this.pnlPeriodExpenses.Margin = new Padding(10);
            this.pnlPeriodExpenses.Controls.Add(this.lblPeriodExpensesTitle);
            this.pnlPeriodExpenses.Controls.Add(this.lblPeriodExpensesAmount);
            this.pnlPeriodExpenses.Controls.Add(this.lblPeriodExpensesPercent);

            this.lblPeriodExpensesTitle.Text = "Chi Tiêu (Tháng Này)"; // Đã Việt hóa
            this.lblPeriodExpensesTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPeriodExpensesTitle.AutoSize = true;
            this.lblPeriodExpensesTitle.ForeColor = System.Drawing.Color.Gray;

            this.lblPeriodExpensesAmount.Text = "0đ";
            this.lblPeriodExpensesAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblPeriodExpensesAmount.Location = new System.Drawing.Point(15, 50);
            this.lblPeriodExpensesAmount.AutoSize = true;
            this.lblPeriodExpensesAmount.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68); // Đỏ

            this.lblPeriodExpensesPercent.Text = "Chào mừng bạn!";
            this.lblPeriodExpensesPercent.Location = new System.Drawing.Point(20, 105);
            this.lblPeriodExpensesPercent.AutoSize = true;

            // 
            // Ô 4: NGÂN SÁCH (pnlPeriodChange - Tái sử dụng panel cũ)
            // 
            this.pnlPeriodChange.BackColor = System.Drawing.Color.White;
            this.pnlPeriodChange.Size = new System.Drawing.Size(310, 135);
            this.pnlPeriodChange.Margin = new Padding(10);
            this.pnlPeriodChange.Controls.Add(this.lblPeriodChangeTitle);
            this.pnlPeriodChange.Controls.Add(this.lblPeriodChangeAmount);
            this.pnlPeriodChange.Controls.Add(this.lblPeriodChangePercent);

            this.lblPeriodChangeTitle.Text = "Ngân Sách"; // Đã Việt hóa
            this.lblPeriodChangeTitle.Location = new System.Drawing.Point(20, 20);
            this.lblPeriodChangeTitle.AutoSize = true;
            this.lblPeriodChangeTitle.ForeColor = System.Drawing.Color.Gray;

            this.lblPeriodChangeAmount.Text = "0đ / 0đ";
            this.lblPeriodChangeAmount.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblPeriodChangeAmount.Location = new System.Drawing.Point(15, 50);
            this.lblPeriodChangeAmount.AutoSize = true;

            this.lblPeriodChangePercent.Text = "Đã dùng 0%";
            this.lblPeriodChangePercent.Location = new System.Drawing.Point(20, 105);
            this.lblPeriodChangePercent.AutoSize = true;

            // 
            // pnlMainContent (BIỂU ĐỒ & DANH SÁCH)
            // 
            this.pnlMainContent.Dock = DockStyle.Fill;
            this.pnlMainContent.ColumnCount = 2;
            this.pnlMainContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            this.pnlMainContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            this.pnlMainContent.Controls.Add(this.pnlBalanceTrends, 0, 0);
            this.pnlMainContent.Controls.Add(this.pnlExpensesBreakdown, 1, 0);

            // 
            // pnlBalanceTrends
            // 
            this.pnlBalanceTrends.BackColor = System.Drawing.Color.White;
            this.pnlBalanceTrends.Dock = DockStyle.Fill;
            this.pnlBalanceTrends.Margin = new Padding(30, 10, 10, 30);
            this.pnlBalanceTrends.Controls.Add(this.lblBalanceTrendsTitle);
            this.pnlBalanceTrends.Controls.Add(this.lblBalanceTrendsAmount);
            this.pnlBalanceTrends.Controls.Add(this.lblBalanceTrendsChange);
            this.pnlBalanceTrends.Controls.Add(this.pnlBalanceChart);

            this.lblBalanceTrendsTitle.Text = "Chênh Lệch Thu - Chi"; // Đã Việt hóa
            this.lblBalanceTrendsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTrendsTitle.Location = new System.Drawing.Point(25, 25);
            this.lblBalanceTrendsTitle.AutoSize = true;

            this.lblBalanceTrendsAmount.Text = "0đ";
            this.lblBalanceTrendsAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            this.lblBalanceTrendsAmount.Location = new System.Drawing.Point(25, 60);
            this.lblBalanceTrendsAmount.AutoSize = true;

            this.pnlBalanceChart.Location = new System.Drawing.Point(25, 110);
            this.pnlBalanceChart.Size = new System.Drawing.Size(700, 300);
            this.pnlBalanceChart.BackColor = System.Drawing.Color.White;

            // 
            // pnlExpensesBreakdown
            // 
            this.pnlExpensesBreakdown.BackColor = System.Drawing.Color.White;
            this.pnlExpensesBreakdown.Dock = DockStyle.Fill;
            this.pnlExpensesBreakdown.Margin = new Padding(10, 10, 30, 30);
            this.pnlExpensesBreakdown.Controls.Add(this.lblExpensesTitle);
            this.pnlExpensesBreakdown.Controls.Add(this.pnlExpensesList);

            this.lblExpensesTitle.Text = "Chi Tiêu Tháng Này"; // Đã Việt hóa
            this.lblExpensesTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblExpensesTitle.Location = new System.Drawing.Point(25, 25);
            this.lblExpensesTitle.AutoSize = true;

            this.pnlExpensesList.Location = new System.Drawing.Point(25, 70);
            this.pnlExpensesList.Size = new System.Drawing.Size(460, 350);
            this.pnlExpensesList.AutoScroll = true;

            // 
            // UC_Dashboard
            // 
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlStatCards);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1400, 800);

            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStatCards.ResumeLayout(false);
            this.pnlTotalBalance.ResumeLayout(false);
            this.pnlTotalBalance.PerformLayout();
            this.pnlPeriodIncome.ResumeLayout(false);
            this.pnlPeriodIncome.PerformLayout();
            this.pnlPeriodExpenses.ResumeLayout(false);
            this.pnlPeriodExpenses.PerformLayout();
            this.pnlPeriodChange.ResumeLayout(false);
            this.pnlPeriodChange.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlBalanceTrends.ResumeLayout(false);
            this.pnlBalanceTrends.PerformLayout();
            this.pnlExpensesBreakdown.ResumeLayout(false);
            this.pnlExpensesBreakdown.PerformLayout();
            this.ResumeLayout(false);
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