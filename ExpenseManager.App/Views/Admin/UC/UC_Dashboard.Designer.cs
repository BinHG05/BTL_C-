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
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblWelcome = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnManageWidgets = new System.Windows.Forms.Button();
            this.btnAddWidget = new System.Windows.Forms.Button();
            this.btnThisMonth = new System.Windows.Forms.Button();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.pnlTotalBalance = new System.Windows.Forms.Panel();
            this.lblTotalBalanceTitle = new System.Windows.Forms.Label();
            this.lblTotalBalanceAmount = new System.Windows.Forms.Label();
            this.lblTotalBalanceChange = new System.Windows.Forms.Label();
            this.pnlIncome = new System.Windows.Forms.Panel();
            this.lblIncomeTitle = new System.Windows.Forms.Label();
            this.lblIncomeAmount = new System.Windows.Forms.Label();
            this.lblIncomeChange = new System.Windows.Forms.Label();
            this.pnlExpense = new System.Windows.Forms.Panel();
            this.lblExpenseTitle = new System.Windows.Forms.Label();
            this.lblExpenseAmount = new System.Windows.Forms.Label();
            this.lblExpenseChange = new System.Windows.Forms.Label();
            this.pnlTotalSavings = new System.Windows.Forms.Panel();
            this.lblTotalSavingsTitle = new System.Windows.Forms.Label();
            this.lblTotalSavingsAmount = new System.Windows.Forms.Label();
            this.lblTotalSavingsChange = new System.Windows.Forms.Label();
            this.pnlMoneyFlow = new System.Windows.Forms.Panel();
            this.lblMoneyFlowTitle = new System.Windows.Forms.Label();
            this.pnlMoneyFlowChart = new System.Windows.Forms.Panel();
            this.pnlBudget = new System.Windows.Forms.Panel();
            this.lblBudgetTitle = new System.Windows.Forms.Label();
            this.pnlBudgetChart = new System.Windows.Forms.Panel();
            this.pnlTransactions = new System.Windows.Forms.Panel();
            this.lblTransactionsTitle = new System.Windows.Forms.Label();
            this.dgvTransactions = new System.Windows.Forms.DataGridView();
            this.pnlSavingGoals = new System.Windows.Forms.Panel();
            this.lblSavingGoalsTitle = new System.Windows.Forms.Label();
            this.pnlGoalsList = new System.Windows.Forms.Panel();
            this.pnlHeader.SuspendLayout();
            this.pnlStats.SuspendLayout();
            this.pnlTotalBalance.SuspendLayout();
            this.pnlIncome.SuspendLayout();
            this.pnlExpense.SuspendLayout();
            this.pnlTotalSavings.SuspendLayout();
            this.pnlMoneyFlow.SuspendLayout();
            this.pnlBudget.SuspendLayout();
            this.pnlTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).BeginInit();
            this.pnlSavingGoals.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.btnManageWidgets);
            this.pnlHeader.Controls.Add(this.btnAddWidget);
            this.pnlHeader.Controls.Add(this.btnThisMonth);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new System.Drawing.Size(1200, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.lblWelcome.Location = new System.Drawing.Point(30, 20);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(350, 45);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Welcome back, Adaline!";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            this.lblSubtitle.Location = new System.Drawing.Point(33, 65);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(280, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "It is the best time to manage your finances.";
            // 
            // btnManageWidgets
            // 
            this.btnManageWidgets.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnManageWidgets.BackColor = System.Drawing.Color.White;
            this.btnManageWidgets.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnManageWidgets.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnManageWidgets.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnManageWidgets.Location = new System.Drawing.Point(886, 35);
            this.btnManageWidgets.Name = "btnManageWidgets";
            this.btnManageWidgets.Size = new System.Drawing.Size(150, 40);
            this.btnManageWidgets.TabIndex = 2;
            this.btnManageWidgets.Text = "⊞ Manage widgets";
            this.btnManageWidgets.UseVisualStyleBackColor = false;
            // 
            // btnAddWidget
            // 
            this.btnAddWidget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddWidget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(124)))), ((int)(((byte)(108)))), ((int)(((byte)(254)))));
            this.btnAddWidget.FlatAppearance.BorderSize = 0;
            this.btnAddWidget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddWidget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddWidget.ForeColor = System.Drawing.Color.White;
            this.btnAddWidget.Location = new System.Drawing.Point(1042, 35);
            this.btnAddWidget.Name = "btnAddWidget";
            this.btnAddWidget.Size = new System.Drawing.Size(150, 40);
            this.btnAddWidget.TabIndex = 3;
            this.btnAddWidget.Text = "+ Add new widget";
            this.btnAddWidget.UseVisualStyleBackColor = false;
            // 
            // btnThisMonth
            // 
            this.btnThisMonth.BackColor = System.Drawing.Color.White;
            this.btnThisMonth.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            this.btnThisMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThisMonth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnThisMonth.Location = new System.Drawing.Point(420, 35);
            this.btnThisMonth.Name = "btnThisMonth";
            this.btnThisMonth.Size = new System.Drawing.Size(120, 40);
            this.btnThisMonth.TabIndex = 4;
            this.btnThisMonth.Text = "📅 This month";
            this.btnThisMonth.UseVisualStyleBackColor = false;
            // 
            // pnlStats
            // 
            this.pnlStats.Controls.Add(this.pnlTotalBalance);
            this.pnlStats.Controls.Add(this.pnlIncome);
            this.pnlStats.Controls.Add(this.pnlExpense);
            this.pnlStats.Controls.Add(this.pnlTotalSavings);
            this.pnlStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlStats.Location = new System.Drawing.Point(0, 100);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlStats.Size = new System.Drawing.Size(1200, 160);
            this.pnlStats.TabIndex = 1;
            // 
            // pnlTotalBalance
            // 
            this.pnlTotalBalance.BackColor = System.Drawing.Color.White;
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceTitle);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceAmount);
            this.pnlTotalBalance.Controls.Add(this.lblTotalBalanceChange);
            this.pnlTotalBalance.Location = new System.Drawing.Point(30, 20);
            this.pnlTotalBalance.Name = "pnlTotalBalance";
            this.pnlTotalBalance.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTotalBalance.Size = new System.Drawing.Size(270, 120);
            this.pnlTotalBalance.TabIndex = 0;
            // 
            // lblTotalBalanceTitle
            // 
            this.lblTotalBalanceTitle.AutoSize = true;
            this.lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalBalanceTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalBalanceTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            this.lblTotalBalanceTitle.Size = new System.Drawing.Size(100, 20);
            this.lblTotalBalanceTitle.TabIndex = 0;
            this.lblTotalBalanceTitle.Text = "Total balance";
            // 
            // lblTotalBalanceAmount
            // 
            this.lblTotalBalanceAmount.AutoSize = true;
            this.lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalBalanceAmount.Location = new System.Drawing.Point(17, 45);
            this.lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            this.lblTotalBalanceAmount.Size = new System.Drawing.Size(155, 37);
            this.lblTotalBalanceAmount.TabIndex = 1;
            this.lblTotalBalanceAmount.Text = "$15,700.00";
            // 
            // lblTotalBalanceChange
            // 
            this.lblTotalBalanceChange.AutoSize = true;
            this.lblTotalBalanceChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalBalanceChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalBalanceChange.Location = new System.Drawing.Point(20, 87);
            this.lblTotalBalanceChange.Name = "lblTotalBalanceChange";
            this.lblTotalBalanceChange.Size = new System.Drawing.Size(110, 15);
            this.lblTotalBalanceChange.TabIndex = 2;
            this.lblTotalBalanceChange.Text = "↑ 12.1%  vs last month";
            // 
            // pnlIncome
            // 
            this.pnlIncome.BackColor = System.Drawing.Color.White;
            this.pnlIncome.Controls.Add(this.lblIncomeTitle);
            this.pnlIncome.Controls.Add(this.lblIncomeAmount);
            this.pnlIncome.Controls.Add(this.lblIncomeChange);
            this.pnlIncome.Location = new System.Drawing.Point(310, 20);
            this.pnlIncome.Name = "pnlIncome";
            this.pnlIncome.Padding = new System.Windows.Forms.Padding(20);
            this.pnlIncome.Size = new System.Drawing.Size(270, 120);
            this.pnlIncome.TabIndex = 1;
            // 
            // lblIncomeTitle
            // 
            this.lblIncomeTitle.AutoSize = true;
            this.lblIncomeTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblIncomeTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblIncomeTitle.Location = new System.Drawing.Point(20, 15);
            this.lblIncomeTitle.Name = "lblIncomeTitle";
            this.lblIncomeTitle.Size = new System.Drawing.Size(60, 20);
            this.lblIncomeTitle.TabIndex = 0;
            this.lblIncomeTitle.Text = "Income";
            // 
            // lblIncomeAmount
            // 
            this.lblIncomeAmount.AutoSize = true;
            this.lblIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblIncomeAmount.Location = new System.Drawing.Point(17, 45);
            this.lblIncomeAmount.Name = "lblIncomeAmount";
            this.lblIncomeAmount.Size = new System.Drawing.Size(140, 37);
            this.lblIncomeAmount.TabIndex = 1;
            this.lblIncomeAmount.Text = "$8,500.00";
            // 
            // lblIncomeChange
            // 
            this.lblIncomeChange.AutoSize = true;
            this.lblIncomeChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIncomeChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblIncomeChange.Location = new System.Drawing.Point(20, 87);
            this.lblIncomeChange.Name = "lblIncomeChange";
            this.lblIncomeChange.Size = new System.Drawing.Size(103, 15);
            this.lblIncomeChange.TabIndex = 2;
            this.lblIncomeChange.Text = "↑ 6.3%  vs last month";
            // 
            // pnlExpense
            // 
            this.pnlExpense.BackColor = System.Drawing.Color.White;
            this.pnlExpense.Controls.Add(this.lblExpenseTitle);
            this.pnlExpense.Controls.Add(this.lblExpenseAmount);
            this.pnlExpense.Controls.Add(this.lblExpenseChange);
            this.pnlExpense.Location = new System.Drawing.Point(590, 20);
            this.pnlExpense.Name = "pnlExpense";
            this.pnlExpense.Padding = new System.Windows.Forms.Padding(20);
            this.pnlExpense.Size = new System.Drawing.Size(270, 120);
            this.pnlExpense.TabIndex = 2;
            // 
            // lblExpenseTitle
            // 
            this.lblExpenseTitle.AutoSize = true;
            this.lblExpenseTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblExpenseTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblExpenseTitle.Location = new System.Drawing.Point(20, 15);
            this.lblExpenseTitle.Name = "lblExpenseTitle";
            this.lblExpenseTitle.Size = new System.Drawing.Size(63, 20);
            this.lblExpenseTitle.TabIndex = 0;
            this.lblExpenseTitle.Text = "Expense";
            // 
            // lblExpenseAmount
            // 
            this.lblExpenseAmount.AutoSize = true;
            this.lblExpenseAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblExpenseAmount.Location = new System.Drawing.Point(17, 45);
            this.lblExpenseAmount.Name = "lblExpenseAmount";
            this.lblExpenseAmount.Size = new System.Drawing.Size(140, 37);
            this.lblExpenseAmount.TabIndex = 1;
            this.lblExpenseAmount.Text = "$6,222.00";
            // 
            // lblExpenseChange
            // 
            this.lblExpenseChange.AutoSize = true;
            this.lblExpenseChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblExpenseChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.lblExpenseChange.Location = new System.Drawing.Point(20, 87);
            this.lblExpenseChange.Name = "lblExpenseChange";
            this.lblExpenseChange.Size = new System.Drawing.Size(103, 15);
            this.lblExpenseChange.TabIndex = 2;
            this.lblExpenseChange.Text = "↑ 2.4%  vs last month";
            // 
            // pnlTotalSavings
            // 
            this.pnlTotalSavings.BackColor = System.Drawing.Color.White;
            this.pnlTotalSavings.Controls.Add(this.lblTotalSavingsTitle);
            this.pnlTotalSavings.Controls.Add(this.lblTotalSavingsAmount);
            this.pnlTotalSavings.Controls.Add(this.lblTotalSavingsChange);
            this.pnlTotalSavings.Location = new System.Drawing.Point(870, 20);
            this.pnlTotalSavings.Name = "pnlTotalSavings";
            this.pnlTotalSavings.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTotalSavings.Size = new System.Drawing.Size(270, 120);
            this.pnlTotalSavings.TabIndex = 3;
            // 
            // lblTotalSavingsTitle
            // 
            this.lblTotalSavingsTitle.AutoSize = true;
            this.lblTotalSavingsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalSavingsTitle.ForeColor = System.Drawing.Color.Gray;
            this.lblTotalSavingsTitle.Location = new System.Drawing.Point(20, 15);
            this.lblTotalSavingsTitle.Name = "lblTotalSavingsTitle";
            this.lblTotalSavingsTitle.Size = new System.Drawing.Size(98, 20);
            this.lblTotalSavingsTitle.TabIndex = 0;
            this.lblTotalSavingsTitle.Text = "Total savings";
            // 
            // lblTotalSavingsAmount
            // 
            this.lblTotalSavingsAmount.AutoSize = true;
            this.lblTotalSavingsAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTotalSavingsAmount.Location = new System.Drawing.Point(17, 45);
            this.lblTotalSavingsAmount.Name = "lblTotalSavingsAmount";
            this.lblTotalSavingsAmount.Size = new System.Drawing.Size(155, 37);
            this.lblTotalSavingsAmount.TabIndex = 1;
            this.lblTotalSavingsAmount.Text = "$32,913.00";
            // 
            // lblTotalSavingsChange
            // 
            this.lblTotalSavingsChange.AutoSize = true;
            this.lblTotalSavingsChange.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTotalSavingsChange.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(197)))), ((int)(((byte)(94)))));
            this.lblTotalSavingsChange.Location = new System.Drawing.Point(20, 87);
            this.lblTotalSavingsChange.Name = "lblTotalSavingsChange";
            this.lblTotalSavingsChange.Size = new System.Drawing.Size(110, 15);
            this.lblTotalSavingsChange.TabIndex = 2;
            this.lblTotalSavingsChange.Text = "↑ 12.1%  vs last month";
            // 
            // pnlMoneyFlow
            // 
            this.pnlMoneyFlow.BackColor = System.Drawing.Color.White;
            this.pnlMoneyFlow.Controls.Add(this.lblMoneyFlowTitle);
            this.pnlMoneyFlow.Controls.Add(this.pnlMoneyFlowChart);
            this.pnlMoneyFlow.Location = new System.Drawing.Point(30, 280);
            this.pnlMoneyFlow.Name = "pnlMoneyFlow";
            this.pnlMoneyFlow.Padding = new System.Windows.Forms.Padding(20);
            this.pnlMoneyFlow.Size = new System.Drawing.Size(580, 300);
            this.pnlMoneyFlow.TabIndex = 2;
            // 
            // lblMoneyFlowTitle
            // 
            this.lblMoneyFlowTitle.AutoSize = true;
            this.lblMoneyFlowTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblMoneyFlowTitle.Location = new System.Drawing.Point(20, 20);
            this.lblMoneyFlowTitle.Name = "lblMoneyFlowTitle";
            this.lblMoneyFlowTitle.Size = new System.Drawing.Size(113, 25);
            this.lblMoneyFlowTitle.TabIndex = 0;
            this.lblMoneyFlowTitle.Text = "Money flow";
            // 
            // pnlMoneyFlowChart
            // 
            this.pnlMoneyFlowChart.Location = new System.Drawing.Point(20, 60);
            this.pnlMoneyFlowChart.Name = "pnlMoneyFlowChart";
            this.pnlMoneyFlowChart.Size = new System.Drawing.Size(540, 220);
            this.pnlMoneyFlowChart.TabIndex = 1;
            // 
            // pnlBudget
            // 
            this.pnlBudget.BackColor = System.Drawing.Color.White;
            this.pnlBudget.Controls.Add(this.lblBudgetTitle);
            this.pnlBudget.Controls.Add(this.pnlBudgetChart);
            this.pnlBudget.Location = new System.Drawing.Point(630, 280);
            this.pnlBudget.Name = "pnlBudget";
            this.pnlBudget.Padding = new System.Windows.Forms.Padding(20);
            this.pnlBudget.Size = new System.Drawing.Size(510, 300);
            this.pnlBudget.TabIndex = 3;
            // 
            // lblBudgetTitle
            // 
            this.lblBudgetTitle.AutoSize = true;
            this.lblBudgetTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblBudgetTitle.Location = new System.Drawing.Point(20, 20);
            this.lblBudgetTitle.Name = "lblBudgetTitle";
            this.lblBudgetTitle.Size = new System.Drawing.Size(75, 25);
            this.lblBudgetTitle.TabIndex = 0;
            this.lblBudgetTitle.Text = "Budget";
            // 
            // pnlBudgetChart
            // 
            this.pnlBudgetChart.Location = new System.Drawing.Point(20, 60);
            this.pnlBudgetChart.Name = "pnlBudgetChart";
            this.pnlBudgetChart.Size = new System.Drawing.Size(470, 220);
            this.pnlBudgetChart.TabIndex = 1;
            // 
            // pnlTransactions
            // 
            this.pnlTransactions.BackColor = System.Drawing.Color.White;
            this.pnlTransactions.Controls.Add(this.lblTransactionsTitle);
            this.pnlTransactions.Controls.Add(this.dgvTransactions);
            this.pnlTransactions.Location = new System.Drawing.Point(30, 600);
            this.pnlTransactions.Name = "pnlTransactions";
            this.pnlTransactions.Padding = new System.Windows.Forms.Padding(20);
            this.pnlTransactions.Size = new System.Drawing.Size(580, 300);
            this.pnlTransactions.TabIndex = 4;
            // 
            // lblTransactionsTitle
            // 
            this.lblTransactionsTitle.AutoSize = true;
            this.lblTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTransactionsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblTransactionsTitle.Name = "lblTransactionsTitle";
            this.lblTransactionsTitle.Size = new System.Drawing.Size(180, 25);
            this.lblTransactionsTitle.TabIndex = 0;
            this.lblTransactionsTitle.Text = "Recent transactions";
            // 
            // dgvTransactions
            // 
            this.dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTransactions.Location = new System.Drawing.Point(20, 60);
            this.dgvTransactions.Name = "dgvTransactions";
            this.dgvTransactions.Size = new System.Drawing.Size(540, 220);
            this.dgvTransactions.TabIndex = 1;
            // 
            // pnlSavingGoals
            // 
            this.pnlSavingGoals.BackColor = System.Drawing.Color.White;
            this.pnlSavingGoals.Controls.Add(this.lblSavingGoalsTitle);
            this.pnlSavingGoals.Controls.Add(this.pnlGoalsList);
            this.pnlSavingGoals.Location = new System.Drawing.Point(630, 600);
            this.pnlSavingGoals.Name = "pnlSavingGoals";
            this.pnlSavingGoals.Padding = new System.Windows.Forms.Padding(20);
            this.pnlSavingGoals.Size = new System.Drawing.Size(510, 300);
            this.pnlSavingGoals.TabIndex = 5;
            // 
            // lblSavingGoalsTitle
            // 
            this.lblSavingGoalsTitle.AutoSize = true;
            this.lblSavingGoalsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblSavingGoalsTitle.Location = new System.Drawing.Point(20, 20);
            this.lblSavingGoalsTitle.Name = "lblSavingGoalsTitle";
            this.lblSavingGoalsTitle.Size = new System.Drawing.Size(121, 25);
            this.lblSavingGoalsTitle.TabIndex = 0;
            this.lblSavingGoalsTitle.Text = "Saving goals";
            // 
            // pnlGoalsList
            // 
            this.pnlGoalsList.AutoScroll = true;
            this.pnlGoalsList.Location = new System.Drawing.Point(20, 60);
            this.pnlGoalsList.Name = "pnlGoalsList";
            this.pnlGoalsList.Size = new System.Drawing.Size(470, 220);
            this.pnlGoalsList.TabIndex = 1;
            // 
            // UC_Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(240)))), ((int)(((byte)(253)))));
            this.Controls.Add(this.pnlSavingGoals);
            this.Controls.Add(this.pnlTransactions);
            this.Controls.Add(this.pnlBudget);
            this.Controls.Add(this.pnlMoneyFlow);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Dashboard";
            this.Size = new System.Drawing.Size(1200, 950);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlTotalBalance.ResumeLayout(false);
            this.pnlTotalBalance.PerformLayout();
            this.pnlIncome.ResumeLayout(false);
            this.pnlIncome.PerformLayout();
            this.pnlExpense.ResumeLayout(false);
            this.pnlExpense.PerformLayout();
            this.pnlTotalSavings.ResumeLayout(false);
            this.pnlTotalSavings.PerformLayout();
            this.pnlMoneyFlow.ResumeLayout(false);
            this.pnlMoneyFlow.PerformLayout();
            this.pnlBudget.ResumeLayout(false);
            this.pnlBudget.PerformLayout();
            this.pnlTransactions.ResumeLayout(false);
            this.pnlTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransactions)).EndInit();
            this.pnlSavingGoals.ResumeLayout(false);
            this.pnlSavingGoals.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnManageWidgets;
        private System.Windows.Forms.Button btnAddWidget;
        private System.Windows.Forms.Button btnThisMonth;
        private System.Windows.Forms.Panel pnlStats;
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
    }
}
