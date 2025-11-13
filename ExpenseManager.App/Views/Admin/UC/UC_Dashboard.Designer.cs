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
            btnManageWidgets = new Button();
            btnAddWidget = new Button();
            btnThisMonth = new Button();
            pnlTotalBalance = new Panel();
            lblTotalBalanceTitle = new Label();
            lblTotalBalanceAmount = new Label();
            lblTotalBalanceChange = new Label();
            pnlIncome = new Panel();
            lblIncomeTitle = new Label();
            lblIncomeAmount = new Label();
            lblIncomeChange = new Label();
            pnlExpense = new Panel();
            lblExpenseTitle = new Label();
            lblExpenseAmount = new Label();
            lblExpenseChange = new Label();
            pnlTotalSavings = new Panel();
            lblTotalSavingsTitle = new Label();
            lblTotalSavingsAmount = new Label();
            lblTotalSavingsChange = new Label();
            pnlMoneyFlow = new Panel();
            lblMoneyFlowTitle = new Label();
            pnlMoneyFlowChart = new Panel();
            pnlBudget = new Panel();
            lblBudgetTitle = new Label();
            pnlBudgetChart = new Panel();
            pnlTransactions = new Panel();
            lblTransactionsTitle = new Label();
            dgvTransactions = new DataGridView();
            pnlSavingGoals = new Panel();
            lblSavingGoalsTitle = new Label();
            pnlGoalsList = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            flbStaus = new FlowLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlTotalBalance.SuspendLayout();
            pnlIncome.SuspendLayout();
            pnlExpense.SuspendLayout();
            pnlTotalSavings.SuspendLayout();
            pnlMoneyFlow.SuspendLayout();
            pnlBudget.SuspendLayout();
            pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            pnlSavingGoals.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            flbStaus.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(btnManageWidgets);
            pnlHeader.Controls.Add(btnAddWidget);
            pnlHeader.Controls.Add(btnThisMonth);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(34, 26, 34, 26);
            pnlHeader.Size = new System.Drawing.Size(1246, 154);
            pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblWelcome.Location = new System.Drawing.Point(34, 26);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new System.Drawing.Size(476, 54);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Welcome back, Adaline!";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            lblSubtitle.Location = new System.Drawing.Point(38, 86);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(372, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "It is the best time to manage your finances.";
            // 
            // btnManageWidgets
            // 
            btnManageWidgets.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnManageWidgets.BackColor = System.Drawing.Color.White;
            btnManageWidgets.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btnManageWidgets.FlatStyle = FlatStyle.Flat;
            btnManageWidgets.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnManageWidgets.Location = new System.Drawing.Point(768, 57);
            btnManageWidgets.Margin = new Padding(3, 4, 3, 4);
            btnManageWidgets.Name = "btnManageWidgets";
            btnManageWidgets.Size = new System.Drawing.Size(171, 54);
            btnManageWidgets.TabIndex = 2;
            btnManageWidgets.Text = "⊞ Manage widgets";
            btnManageWidgets.UseVisualStyleBackColor = false;
            // 
            // btnAddWidget
            // 
            btnAddWidget.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnAddWidget.BackColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnAddWidget.FlatAppearance.BorderSize = 0;
            btnAddWidget.FlatStyle = FlatStyle.Flat;
            btnAddWidget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAddWidget.ForeColor = System.Drawing.Color.White;
            btnAddWidget.Location = new System.Drawing.Point(1016, 57);
            btnAddWidget.Margin = new Padding(3, 4, 3, 4);
            btnAddWidget.Name = "btnAddWidget";
            btnAddWidget.Size = new System.Drawing.Size(171, 54);
            btnAddWidget.TabIndex = 3;
            btnAddWidget.Text = "+ Add new widget";
            btnAddWidget.UseVisualStyleBackColor = false;
            // 
            // btnThisMonth
            // 
            btnThisMonth.BackColor = System.Drawing.Color.White;
            btnThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btnThisMonth.FlatStyle = FlatStyle.Flat;
            btnThisMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnThisMonth.Location = new System.Drawing.Point(518, 57);
            btnThisMonth.Margin = new Padding(3, 4, 3, 4);
            btnThisMonth.Name = "btnThisMonth";
            btnThisMonth.Size = new System.Drawing.Size(137, 54);
            btnThisMonth.TabIndex = 4;
            btnThisMonth.Text = "📅 This month";
            btnThisMonth.UseVisualStyleBackColor = false;
            // 
            // pnlTotalBalance
            // 
            pnlTotalBalance.BackColor = System.Drawing.Color.White;
            pnlTotalBalance.Controls.Add(lblTotalBalanceTitle);
            pnlTotalBalance.Controls.Add(lblTotalBalanceAmount);
            pnlTotalBalance.Controls.Add(lblTotalBalanceChange);
            pnlTotalBalance.Location = new System.Drawing.Point(35, 204);
            pnlTotalBalance.Margin = new Padding(3, 4, 3, 4);
            pnlTotalBalance.Name = "pnlTotalBalance";
            pnlTotalBalance.Padding = new Padding(23, 26, 23, 26);
            pnlTotalBalance.Size = new System.Drawing.Size(309, 160);
            pnlTotalBalance.TabIndex = 0;
            // 
            // lblTotalBalanceTitle
            // 
            lblTotalBalanceTitle.AutoSize = true;
            lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblTotalBalanceTitle.ForeColor = System.Drawing.Color.Gray;
            lblTotalBalanceTitle.Location = new System.Drawing.Point(23, 20);
            lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            lblTotalBalanceTitle.Size = new System.Drawing.Size(123, 25);
            lblTotalBalanceTitle.TabIndex = 0;
            lblTotalBalanceTitle.Text = "Total balance";
            // 
            // lblTotalBalanceAmount
            // 
            lblTotalBalanceAmount.AutoSize = true;
            lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTotalBalanceAmount.Location = new System.Drawing.Point(19, 60);
            lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            lblTotalBalanceAmount.Size = new System.Drawing.Size(198, 46);
            lblTotalBalanceAmount.TabIndex = 1;
            lblTotalBalanceAmount.Text = "$15,700.00";
            // 
            // lblTotalBalanceChange
            // 
            lblTotalBalanceChange.AutoSize = true;
            lblTotalBalanceChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalBalanceChange.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblTotalBalanceChange.Location = new System.Drawing.Point(23, 116);
            lblTotalBalanceChange.Name = "lblTotalBalanceChange";
            lblTotalBalanceChange.Size = new System.Drawing.Size(154, 20);
            lblTotalBalanceChange.TabIndex = 2;
            lblTotalBalanceChange.Text = "↑ 12.1%  vs last month";
            // 
            // pnlIncome
            // 
            pnlIncome.BackColor = System.Drawing.Color.White;
            pnlIncome.Controls.Add(lblIncomeTitle);
            pnlIncome.Controls.Add(lblIncomeAmount);
            pnlIncome.Controls.Add(lblIncomeChange);
            pnlIncome.Location = new System.Drawing.Point(691, 36);
            pnlIncome.Margin = new Padding(3, 4, 16, 4);
            pnlIncome.Name = "pnlIncome";
            pnlIncome.Padding = new Padding(23, 26, 23, 26);
            pnlIncome.Size = new System.Drawing.Size(309, 160);
            pnlIncome.TabIndex = 1;
            // 
            // lblIncomeTitle
            // 
            lblIncomeTitle.AutoSize = true;
            lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblIncomeTitle.ForeColor = System.Drawing.Color.Gray;
            lblIncomeTitle.Location = new System.Drawing.Point(23, 20);
            lblIncomeTitle.Name = "lblIncomeTitle";
            lblIncomeTitle.Size = new System.Drawing.Size(74, 25);
            lblIncomeTitle.TabIndex = 0;
            lblIncomeTitle.Text = "Income";
            // 
            // lblIncomeAmount
            // 
            lblIncomeAmount.AutoSize = true;
            lblIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblIncomeAmount.Location = new System.Drawing.Point(19, 60);
            lblIncomeAmount.Name = "lblIncomeAmount";
            lblIncomeAmount.Size = new System.Drawing.Size(178, 46);
            lblIncomeAmount.TabIndex = 1;
            lblIncomeAmount.Text = "$8,500.00";
            // 
            // lblIncomeChange
            // 
            lblIncomeChange.AutoSize = true;
            lblIncomeChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblIncomeChange.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblIncomeChange.Location = new System.Drawing.Point(23, 116);
            lblIncomeChange.Name = "lblIncomeChange";
            lblIncomeChange.Size = new System.Drawing.Size(146, 20);
            lblIncomeChange.TabIndex = 2;
            lblIncomeChange.Text = "↑ 6.3%  vs last month";
            // 
            // pnlExpense
            // 
            pnlExpense.BackColor = System.Drawing.Color.White;
            pnlExpense.Controls.Add(lblExpenseTitle);
            pnlExpense.Controls.Add(lblExpenseAmount);
            pnlExpense.Controls.Add(lblExpenseChange);
            pnlExpense.Location = new System.Drawing.Point(363, 36);
            pnlExpense.Margin = new Padding(3, 4, 16, 4);
            pnlExpense.Name = "pnlExpense";
            pnlExpense.Padding = new Padding(23, 26, 23, 26);
            pnlExpense.Size = new System.Drawing.Size(309, 160);
            pnlExpense.TabIndex = 2;
            // 
            // lblExpenseTitle
            // 
            lblExpenseTitle.AutoSize = true;
            lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblExpenseTitle.ForeColor = System.Drawing.Color.Gray;
            lblExpenseTitle.Location = new System.Drawing.Point(23, 20);
            lblExpenseTitle.Name = "lblExpenseTitle";
            lblExpenseTitle.Size = new System.Drawing.Size(81, 25);
            lblExpenseTitle.TabIndex = 0;
            lblExpenseTitle.Text = "Expense";
            // 
            // lblExpenseAmount
            // 
            lblExpenseAmount.AutoSize = true;
            lblExpenseAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblExpenseAmount.Location = new System.Drawing.Point(19, 60);
            lblExpenseAmount.Name = "lblExpenseAmount";
            lblExpenseAmount.Size = new System.Drawing.Size(178, 46);
            lblExpenseAmount.TabIndex = 1;
            lblExpenseAmount.Text = "$6,222.00";
            // 
            // lblExpenseChange
            // 
            lblExpenseChange.AutoSize = true;
            lblExpenseChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblExpenseChange.ForeColor = System.Drawing.Color.FromArgb(239, 68, 68);
            lblExpenseChange.Location = new System.Drawing.Point(23, 116);
            lblExpenseChange.Name = "lblExpenseChange";
            lblExpenseChange.Size = new System.Drawing.Size(146, 20);
            lblExpenseChange.TabIndex = 2;
            lblExpenseChange.Text = "↑ 2.4%  vs last month";
            // 
            // pnlTotalSavings
            // 
            pnlTotalSavings.BackColor = System.Drawing.Color.White;
            pnlTotalSavings.Controls.Add(lblTotalSavingsTitle);
            pnlTotalSavings.Controls.Add(lblTotalSavingsAmount);
            pnlTotalSavings.Controls.Add(lblTotalSavingsChange);
            pnlTotalSavings.Location = new System.Drawing.Point(35, 36);
            pnlTotalSavings.Margin = new Padding(3, 4, 16, 4);
            pnlTotalSavings.Name = "pnlTotalSavings";
            pnlTotalSavings.Padding = new Padding(23, 26, 23, 26);
            pnlTotalSavings.Size = new System.Drawing.Size(309, 160);
            pnlTotalSavings.TabIndex = 3;
            // 
            // lblTotalSavingsTitle
            // 
            lblTotalSavingsTitle.AutoSize = true;
            lblTotalSavingsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblTotalSavingsTitle.ForeColor = System.Drawing.Color.Gray;
            lblTotalSavingsTitle.Location = new System.Drawing.Point(23, 20);
            lblTotalSavingsTitle.Name = "lblTotalSavingsTitle";
            lblTotalSavingsTitle.Size = new System.Drawing.Size(119, 25);
            lblTotalSavingsTitle.TabIndex = 0;
            lblTotalSavingsTitle.Text = "Total savings";
            // 
            // lblTotalSavingsAmount
            // 
            lblTotalSavingsAmount.AutoSize = true;
            lblTotalSavingsAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblTotalSavingsAmount.Location = new System.Drawing.Point(19, 60);
            lblTotalSavingsAmount.Name = "lblTotalSavingsAmount";
            lblTotalSavingsAmount.Size = new System.Drawing.Size(198, 46);
            lblTotalSavingsAmount.TabIndex = 1;
            lblTotalSavingsAmount.Text = "$32,913.00";
            // 
            // lblTotalSavingsChange
            // 
            lblTotalSavingsChange.AutoSize = true;
            lblTotalSavingsChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblTotalSavingsChange.ForeColor = System.Drawing.Color.FromArgb(34, 197, 94);
            lblTotalSavingsChange.Location = new System.Drawing.Point(23, 116);
            lblTotalSavingsChange.Name = "lblTotalSavingsChange";
            lblTotalSavingsChange.Size = new System.Drawing.Size(154, 20);
            lblTotalSavingsChange.TabIndex = 2;
            lblTotalSavingsChange.Text = "↑ 12.1%  vs last month";
            // 
            // pnlMoneyFlow
            // 
            pnlMoneyFlow.BackColor = System.Drawing.Color.White;
            pnlMoneyFlow.Controls.Add(lblMoneyFlowTitle);
            pnlMoneyFlow.Controls.Add(pnlMoneyFlowChart);
            pnlMoneyFlow.Dock = DockStyle.Fill;
            pnlMoneyFlow.Location = new System.Drawing.Point(64, 64);
            pnlMoneyFlow.Margin = new Padding(24, 24, 24, 24);
            pnlMoneyFlow.Name = "pnlMoneyFlow";
            pnlMoneyFlow.Padding = new Padding(23, 26, 23, 26);
            pnlMoneyFlow.Size = new System.Drawing.Size(538, 376);
            pnlMoneyFlow.TabIndex = 2;
            // 
            // lblMoneyFlowTitle
            // 
            lblMoneyFlowTitle.AutoSize = true;
            lblMoneyFlowTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblMoneyFlowTitle.Location = new System.Drawing.Point(23, 26);
            lblMoneyFlowTitle.Name = "lblMoneyFlowTitle";
            lblMoneyFlowTitle.Size = new System.Drawing.Size(150, 32);
            lblMoneyFlowTitle.TabIndex = 0;
            lblMoneyFlowTitle.Text = "Money flow";
            // 
            // pnlMoneyFlowChart
            // 
            pnlMoneyFlowChart.Location = new System.Drawing.Point(23, 80);
            pnlMoneyFlowChart.Margin = new Padding(8, 8, 8, 8);
            pnlMoneyFlowChart.Name = "pnlMoneyFlowChart";
            pnlMoneyFlowChart.Size = new System.Drawing.Size(530, 266);
            pnlMoneyFlowChart.TabIndex = 1;
            // 
            // pnlBudget
            // 
            pnlBudget.BackColor = System.Drawing.Color.White;
            pnlBudget.Controls.Add(lblBudgetTitle);
            pnlBudget.Controls.Add(pnlBudgetChart);
            pnlBudget.Dock = DockStyle.Fill;
            pnlBudget.Location = new System.Drawing.Point(650, 64);
            pnlBudget.Margin = new Padding(24, 24, 24, 24);
            pnlBudget.Name = "pnlBudget";
            pnlBudget.Padding = new Padding(23, 26, 23, 26);
            pnlBudget.Size = new System.Drawing.Size(532, 376);
            pnlBudget.TabIndex = 3;
            pnlBudget.Paint += pnlBudget_Paint;
            // 
            // lblBudgetTitle
            // 
            lblBudgetTitle.AutoSize = true;
            lblBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblBudgetTitle.Location = new System.Drawing.Point(23, 26);
            lblBudgetTitle.Name = "lblBudgetTitle";
            lblBudgetTitle.Size = new System.Drawing.Size(96, 32);
            lblBudgetTitle.TabIndex = 0;
            lblBudgetTitle.Text = "Budget";
            // 
            // pnlBudgetChart
            // 
            pnlBudgetChart.Location = new System.Drawing.Point(23, 80);
            pnlBudgetChart.Margin = new Padding(3, 4, 3, 4);
            pnlBudgetChart.Name = "pnlBudgetChart";
            pnlBudgetChart.Size = new System.Drawing.Size(526, 266);
            pnlBudgetChart.TabIndex = 1;
            // 
            // pnlTransactions
            // 
            pnlTransactions.BackColor = System.Drawing.Color.White;
            pnlTransactions.Controls.Add(lblTransactionsTitle);
            pnlTransactions.Controls.Add(dgvTransactions);
            pnlTransactions.Dock = DockStyle.Fill;
            pnlTransactions.Location = new System.Drawing.Point(64, 488);
            pnlTransactions.Margin = new Padding(24, 24, 24, 24);
            pnlTransactions.Name = "pnlTransactions";
            pnlTransactions.Padding = new Padding(23, 26, 23, 26);
            pnlTransactions.Size = new System.Drawing.Size(538, 377);
            pnlTransactions.TabIndex = 4;
            // 
            // lblTransactionsTitle
            // 
            lblTransactionsTitle.AutoSize = true;
            lblTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTransactionsTitle.Location = new System.Drawing.Point(23, 26);
            lblTransactionsTitle.Name = "lblTransactionsTitle";
            lblTransactionsTitle.Size = new System.Drawing.Size(238, 32);
            lblTransactionsTitle.TabIndex = 0;
            lblTransactionsTitle.Text = "Recent transactions";
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            dgvTransactions.BorderStyle = BorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new System.Drawing.Point(23, 80);
            dgvTransactions.Margin = new Padding(3, 4, 3, 4);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 62;
            dgvTransactions.Size = new System.Drawing.Size(530, 262);
            dgvTransactions.TabIndex = 1;
            // 
            // pnlSavingGoals
            // 
            pnlSavingGoals.BackColor = System.Drawing.Color.White;
            pnlSavingGoals.Controls.Add(lblSavingGoalsTitle);
            pnlSavingGoals.Controls.Add(pnlGoalsList);
            pnlSavingGoals.Dock = DockStyle.Fill;
            pnlSavingGoals.Location = new System.Drawing.Point(650, 488);
            pnlSavingGoals.Margin = new Padding(24, 24, 24, 24);
            pnlSavingGoals.Name = "pnlSavingGoals";
            pnlSavingGoals.Padding = new Padding(23, 26, 23, 26);
            pnlSavingGoals.Size = new System.Drawing.Size(532, 377);
            pnlSavingGoals.TabIndex = 5;
            // 
            // lblSavingGoalsTitle
            // 
            lblSavingGoalsTitle.AutoSize = true;
            lblSavingGoalsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblSavingGoalsTitle.Location = new System.Drawing.Point(23, 26);
            lblSavingGoalsTitle.Name = "lblSavingGoalsTitle";
            lblSavingGoalsTitle.Size = new System.Drawing.Size(158, 32);
            lblSavingGoalsTitle.TabIndex = 0;
            lblSavingGoalsTitle.Text = "Saving goals";
            // 
            // pnlGoalsList
            // 
            pnlGoalsList.AutoScroll = true;
            pnlGoalsList.Location = new System.Drawing.Point(23, 80);
            pnlGoalsList.Margin = new Padding(3, 4, 3, 4);
            pnlGoalsList.Name = "pnlGoalsList";
            pnlGoalsList.Size = new System.Drawing.Size(526, 279);
            pnlGoalsList.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50.30979F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 49.6902122F));
            tableLayoutPanel1.Controls.Add(pnlTransactions, 0, 1);
            tableLayoutPanel1.Controls.Add(pnlBudget, 1, 0);
            tableLayoutPanel1.Controls.Add(pnlMoneyFlow, 0, 0);
            tableLayoutPanel1.Controls.Add(pnlSavingGoals, 1, 1);
            tableLayoutPanel1.Dock = DockStyle.Bottom;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 376);
            tableLayoutPanel1.Margin = new Padding(2, 2, 2, 2);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.Padding = new Padding(40, 40, 40, 40);
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 16F));
            tableLayoutPanel1.Size = new System.Drawing.Size(1246, 929);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // flbStaus
            // 
            flbStaus.Controls.Add(pnlTotalSavings);
            flbStaus.Controls.Add(pnlExpense);
            flbStaus.Controls.Add(pnlIncome);
            flbStaus.Controls.Add(pnlTotalBalance);
            flbStaus.Dock = DockStyle.Top;
            flbStaus.Location = new System.Drawing.Point(0, 154);
            flbStaus.Margin = new Padding(16, 16, 16, 16);
            flbStaus.Name = "flbStaus";
            flbStaus.Padding = new Padding(32, 32, 32, 32);
            flbStaus.Size = new System.Drawing.Size(1246, 222);
            flbStaus.TabIndex = 2;
            // 
            // UC_Dashboard
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(243, 240, 253);
            Controls.Add(flbStaus);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_Dashboard";
            Size = new System.Drawing.Size(1246, 1266);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTotalBalance.ResumeLayout(false);
            pnlTotalBalance.PerformLayout();
            pnlIncome.ResumeLayout(false);
            pnlIncome.PerformLayout();
            pnlExpense.ResumeLayout(false);
            pnlExpense.PerformLayout();
            pnlTotalSavings.ResumeLayout(false);
            pnlTotalSavings.PerformLayout();
            pnlMoneyFlow.ResumeLayout(false);
            pnlMoneyFlow.PerformLayout();
            pnlBudget.ResumeLayout(false);
            pnlBudget.PerformLayout();
            pnlTransactions.ResumeLayout(false);
            pnlTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            pnlSavingGoals.ResumeLayout(false);
            pnlSavingGoals.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            flbStaus.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnManageWidgets;
        private System.Windows.Forms.Button btnAddWidget;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Panel pnlTotalBalance;
        private System.Windows.Forms.Label lblTotalBalanceTitle;
        private System.Windows.Forms.Label lblTotalBalanceAmount;
        private System.Windows.Forms.Label lblTotalBalanceChange;
        private System.Windows.Forms.Panel pnlIncome;
        private System.Windows.Forms.Label lblIncomeTitle;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.Label lblIncomeChange;
        private System.Windows.Forms.Panel pnlExpense;
        private System.Windows.Forms.Label lblExpenseTitle;
        private System.Windows.Forms.Label lblExpenseAmount;
        private System.Windows.Forms.Label lblExpenseChange;
        private System.Windows.Forms.Panel pnlTotalSavings;
        private System.Windows.Forms.Label lblTotalSavingsTitle;
        private System.Windows.Forms.Label lblTotalSavingsAmount;
        private System.Windows.Forms.Label lblTotalSavingsChange;
        private System.Windows.Forms.Panel pnlMoneyFlow;
        private System.Windows.Forms.Label lblMoneyFlowTitle;
        private System.Windows.Forms.Panel pnlMoneyFlowChart;
        private System.Windows.Forms.Panel pnlBudget;
        private System.Windows.Forms.Label lblBudgetTitle;
        private System.Windows.Forms.Panel pnlBudgetChart;
        private System.Windows.Forms.Panel pnlTransactions;
        private System.Windows.Forms.Label lblTransactionsTitle;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.Panel pnlSavingGoals;
        private System.Windows.Forms.Label lblSavingGoalsTitle;
        private System.Windows.Forms.Panel pnlGoalsList;
        private TableLayoutPanel tableLayoutPanel1;
        private FlowLayoutPanel flbStaus;
    }
}
