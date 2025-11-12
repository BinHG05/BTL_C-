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
            btnAddNewAccount = new System.Windows.Forms.Button();
            pnlTotalBalance = new System.Windows.Forms.Panel();
            lblTotalBalanceTitle = new System.Windows.Forms.Label();
            lblTotalBalanceAmount = new System.Windows.Forms.Label();
            lblCapitalInfo = new System.Windows.Forms.Label();
            cmbAllAccounts = new System.Windows.Forms.ComboBox();
            btnTransfer = new System.Windows.Forms.Button();
            btnRequest = new System.Windows.Forms.Button();
            btnMore = new System.Windows.Forms.Button();
            pnlAccounts = new System.Windows.Forms.Panel();
            lblYourAccounts = new System.Windows.Forms.Label();
            lblAccountsCount = new System.Windows.Forms.Label();
            pnlAccountCards = new System.Windows.Forms.FlowLayoutPanel();
            pnlCard1 = new System.Windows.Forms.Panel();
            lblCard1Number = new System.Windows.Forms.Label();
            lblCard1Name = new System.Windows.Forms.Label();
            lblCard1Balance = new System.Windows.Forms.Label();
            picCard1Logo = new System.Windows.Forms.PictureBox();
            pnlCard2 = new System.Windows.Forms.Panel();
            lblCard2Number = new System.Windows.Forms.Label();
            lblCard2Expiry = new System.Windows.Forms.Label();
            lblCard2Balance = new System.Windows.Forms.Label();
            picCard2Logo = new System.Windows.Forms.PictureBox();
            pnlCard3 = new System.Windows.Forms.Panel();
            lblCard3Email = new System.Windows.Forms.Label();
            lblCard3Balance = new System.Windows.Forms.Label();
            picCard3Logo = new System.Windows.Forms.PictureBox();
            btnDetails = new System.Windows.Forms.Button();
            cmbMonth = new System.Windows.Forms.ComboBox();
            pnlTransactionsChart = new System.Windows.Forms.Panel();
            lblTransactionsTitle = new System.Windows.Forms.Label();
            pnlChart = new System.Windows.Forms.Panel();
            btnSeeAll = new System.Windows.Forms.Button();
            pnlStatistics = new System.Windows.Forms.Panel();
            lblStatisticsTitle = new System.Windows.Forms.Label();
            cmbStatMonth = new System.Windows.Forms.ComboBox();
            pnlDonutChart = new System.Windows.Forms.Panel();
            lblTotalIncome = new System.Windows.Forms.Label();
            lblIncomeAmount = new System.Windows.Forms.Label();
            pnlRecentTransactions = new System.Windows.Forms.Panel();
            lblRecentTitle = new System.Windows.Forms.Label();
            dgvTransactions = new System.Windows.Forms.DataGridView();
            tlpMain = new System.Windows.Forms.TableLayoutPanel();
            tlpTop = new System.Windows.Forms.TableLayoutPanel();
            pnlHeader.SuspendLayout();
            pnlTotalBalance.SuspendLayout();
            pnlAccounts.SuspendLayout();
            pnlAccountCards.SuspendLayout();
            pnlCard1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCard1Logo).BeginInit();
            pnlCard2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCard2Logo).BeginInit();
            pnlCard3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picCard3Logo).BeginInit();
            pnlTransactionsChart.SuspendLayout();
            pnlStatistics.SuspendLayout();
            pnlRecentTransactions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).BeginInit();
            tlpMain.SuspendLayout();
            tlpTop.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.White;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Controls.Add(btnAddNewAccount);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new System.Windows.Forms.Padding(43, 33, 43, 33);
            pnlHeader.Size = new System.Drawing.Size(1662, 167);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTitle.Location = new System.Drawing.Point(43, 33);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(173, 65);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Wallet";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.Gray;
            lblSubtitle.Location = new System.Drawing.Point(47, 108);
            lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(393, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Overview of your balance and accounts";
            // 
            // btnAddNewAccount
            // 
            btnAddNewAccount.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnAddNewAccount.BackColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnAddNewAccount.FlatAppearance.BorderSize = 0;
            btnAddNewAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddNewAccount.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnAddNewAccount.ForeColor = System.Drawing.Color.White;
            btnAddNewAccount.Location = new System.Drawing.Point(1394, 58);
            btnAddNewAccount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnAddNewAccount.Name = "btnAddNewAccount";
            btnAddNewAccount.Size = new System.Drawing.Size(257, 67);
            btnAddNewAccount.TabIndex = 2;
            btnAddNewAccount.Text = "+ Add new account";
            btnAddNewAccount.UseVisualStyleBackColor = false;
            // 
            // pnlTotalBalance
            // 
            pnlTotalBalance.BackColor = System.Drawing.Color.White;
            pnlTotalBalance.Controls.Add(lblTotalBalanceTitle);
            pnlTotalBalance.Controls.Add(lblTotalBalanceAmount);
            pnlTotalBalance.Controls.Add(lblCapitalInfo);
            pnlTotalBalance.Controls.Add(cmbAllAccounts);
            pnlTotalBalance.Controls.Add(btnTransfer);
            pnlTotalBalance.Controls.Add(btnRequest);
            pnlTotalBalance.Controls.Add(btnMore);
            pnlTotalBalance.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTotalBalance.Location = new System.Drawing.Point(50, 50);
            pnlTotalBalance.Margin = new System.Windows.Forms.Padding(20);
            pnlTotalBalance.Name = "pnlTotalBalance";
            pnlTotalBalance.Padding = new System.Windows.Forms.Padding(36, 42, 36, 42);
            pnlTotalBalance.Size = new System.Drawing.Size(600, 370);
            pnlTotalBalance.TabIndex = 1;
            // 
            // lblTotalBalanceTitle
            // 
            lblTotalBalanceTitle.AutoSize = true;
            lblTotalBalanceTitle.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblTotalBalanceTitle.ForeColor = System.Drawing.Color.Gray;
            lblTotalBalanceTitle.Location = new System.Drawing.Point(36, 42);
            lblTotalBalanceTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalBalanceTitle.Name = "lblTotalBalanceTitle";
            lblTotalBalanceTitle.Size = new System.Drawing.Size(154, 32);
            lblTotalBalanceTitle.TabIndex = 0;
            lblTotalBalanceTitle.Text = "Total balance";
            // 
            // lblTotalBalanceAmount
            // 
            lblTotalBalanceAmount.AutoSize = true;
            lblTotalBalanceAmount.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            lblTotalBalanceAmount.Location = new System.Drawing.Point(26, 83);
            lblTotalBalanceAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalBalanceAmount.Name = "lblTotalBalanceAmount";
            lblTotalBalanceAmount.Size = new System.Drawing.Size(276, 86);
            lblTotalBalanceAmount.TabIndex = 1;
            lblTotalBalanceAmount.Text = "$15,700";
            // 
            // lblCapitalInfo
            // 
            lblCapitalInfo.AutoSize = true;
            lblCapitalInfo.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCapitalInfo.ForeColor = System.Drawing.Color.Gray;
            lblCapitalInfo.Location = new System.Drawing.Point(36, 192);
            lblCapitalInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCapitalInfo.Name = "lblCapitalInfo";
            lblCapitalInfo.Size = new System.Drawing.Size(273, 25);
            lblCapitalInfo.TabIndex = 2;
            lblCapitalInfo.Text = "Your capital consists of 3 sources";
            // 
            // cmbAllAccounts
            // 
            cmbAllAccounts.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbAllAccounts.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbAllAccounts.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbAllAccounts.FormattingEnabled = true;
            cmbAllAccounts.Items.AddRange(new object[] { "All accounts", "Bank accounts", "Credit cards", "Digital wallets" });
            cmbAllAccounts.Location = new System.Drawing.Point(385, 50);
            cmbAllAccounts.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbAllAccounts.Name = "cmbAllAccounts";
            cmbAllAccounts.Size = new System.Drawing.Size(170, 33);
            cmbAllAccounts.TabIndex = 3;
            cmbAllAccounts.Text = "All accounts";
            // 
            // btnTransfer
            // 
            btnTransfer.BackColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnTransfer.FlatAppearance.BorderSize = 0;
            btnTransfer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnTransfer.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnTransfer.ForeColor = System.Drawing.Color.White;
            btnTransfer.Location = new System.Drawing.Point(36, 258);
            btnTransfer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnTransfer.Name = "btnTransfer";
            btnTransfer.Size = new System.Drawing.Size(171, 67);
            btnTransfer.TabIndex = 4;
            btnTransfer.Text = "💳 Transfer";
            btnTransfer.UseVisualStyleBackColor = false;
            // 
            // btnRequest
            // 
            btnRequest.BackColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnRequest.FlatAppearance.BorderSize = 0;
            btnRequest.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRequest.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            btnRequest.ForeColor = System.Drawing.Color.White;
            btnRequest.Location = new System.Drawing.Point(221, 258);
            btnRequest.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnRequest.Name = "btnRequest";
            btnRequest.Size = new System.Drawing.Size(171, 67);
            btnRequest.TabIndex = 5;
            btnRequest.Text = "💳 Request";
            btnRequest.UseVisualStyleBackColor = false;
            // 
            // btnMore
            // 
            btnMore.BackColor = System.Drawing.Color.White;
            btnMore.FlatAppearance.BorderColor = System.Drawing.Color.LightGray;
            btnMore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnMore.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnMore.Location = new System.Drawing.Point(407, 258);
            btnMore.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnMore.Name = "btnMore";
            btnMore.Size = new System.Drawing.Size(71, 67);
            btnMore.TabIndex = 6;
            btnMore.Text = "⋯";
            btnMore.UseVisualStyleBackColor = false;
            // 
            // pnlAccounts
            // 
            pnlAccounts.BackColor = System.Drawing.Color.Transparent;
            pnlAccounts.Controls.Add(lblYourAccounts);
            pnlAccounts.Controls.Add(lblAccountsCount);
            pnlAccounts.Controls.Add(pnlAccountCards);
            pnlAccounts.Controls.Add(btnDetails);
            pnlAccounts.Controls.Add(cmbMonth);
            pnlAccounts.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlAccounts.Location = new System.Drawing.Point(690, 50);
            pnlAccounts.Margin = new System.Windows.Forms.Padding(20);
            pnlAccounts.Name = "pnlAccounts";
            pnlAccounts.Size = new System.Drawing.Size(922, 370);
            pnlAccounts.TabIndex = 2;
            pnlAccounts.Paint += pnlAccounts_Paint;
            // 
            // lblYourAccounts
            // 
            lblYourAccounts.AutoSize = true;
            lblYourAccounts.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblYourAccounts.Location = new System.Drawing.Point(14, 17);
            lblYourAccounts.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblYourAccounts.Name = "lblYourAccounts";
            lblYourAccounts.Size = new System.Drawing.Size(199, 38);
            lblYourAccounts.TabIndex = 0;
            lblYourAccounts.Text = "Your accounts";
            // 
            // lblAccountsCount
            // 
            lblAccountsCount.AutoSize = true;
            lblAccountsCount.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblAccountsCount.ForeColor = System.Drawing.Color.Gray;
            lblAccountsCount.Location = new System.Drawing.Point(14, 67);
            lblAccountsCount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAccountsCount.Name = "lblAccountsCount";
            lblAccountsCount.Size = new System.Drawing.Size(75, 28);
            lblAccountsCount.TabIndex = 1;
            lblAccountsCount.Text = "3 items";
            // 
            // pnlAccountCards
            // 
            pnlAccountCards.AutoScroll = true;
            pnlAccountCards.Controls.Add(pnlCard1);
            pnlAccountCards.Controls.Add(pnlCard2);
            pnlAccountCards.Controls.Add(pnlCard3);
            pnlAccountCards.Location = new System.Drawing.Point(14, 117);
            pnlAccountCards.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlAccountCards.Name = "pnlAccountCards";
            pnlAccountCards.Size = new System.Drawing.Size(810, 233);
            pnlAccountCards.TabIndex = 2;
            // 
            // pnlCard1
            // 
            pnlCard1.BackColor = System.Drawing.Color.FromArgb(167, 139, 250);
            pnlCard1.Controls.Add(lblCard1Number);
            pnlCard1.Controls.Add(lblCard1Name);
            pnlCard1.Controls.Add(lblCard1Balance);
            pnlCard1.Controls.Add(picCard1Logo);
            pnlCard1.Location = new System.Drawing.Point(4, 5);
            pnlCard1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlCard1.Name = "pnlCard1";
            pnlCard1.Size = new System.Drawing.Size(257, 217);
            pnlCard1.TabIndex = 0;
            // 
            // lblCard1Number
            // 
            lblCard1Number.AutoSize = true;
            lblCard1Number.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCard1Number.ForeColor = System.Drawing.Color.White;
            lblCard1Number.Location = new System.Drawing.Point(21, 83);
            lblCard1Number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard1Number.Name = "lblCard1Number";
            lblCard1Number.Size = new System.Drawing.Size(163, 25);
            lblCard1Number.TabIndex = 0;
            lblCard1Number.Text = "**** **** **** 2154";
            // 
            // lblCard1Name
            // 
            lblCard1Name.AutoSize = true;
            lblCard1Name.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCard1Name.ForeColor = System.Drawing.Color.White;
            lblCard1Name.Location = new System.Drawing.Point(21, 125);
            lblCard1Name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard1Name.Name = "lblCard1Name";
            lblCard1Name.Size = new System.Drawing.Size(52, 21);
            lblCard1Name.TabIndex = 1;
            lblCard1Name.Text = "12/26";
            // 
            // lblCard1Balance
            // 
            lblCard1Balance.AutoSize = true;
            lblCard1Balance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblCard1Balance.ForeColor = System.Drawing.Color.White;
            lblCard1Balance.Location = new System.Drawing.Point(17, 25);
            lblCard1Balance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard1Balance.Name = "lblCard1Balance";
            lblCard1Balance.Size = new System.Drawing.Size(145, 38);
            lblCard1Balance.TabIndex = 2;
            lblCard1Balance.Text = "$8,000.00";
            // 
            // picCard1Logo
            // 
            picCard1Logo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            picCard1Logo.Location = new System.Drawing.Point(186, 158);
            picCard1Logo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            picCard1Logo.Name = "picCard1Logo";
            picCard1Logo.Size = new System.Drawing.Size(57, 42);
            picCard1Logo.TabIndex = 3;
            picCard1Logo.TabStop = false;
            // 
            // pnlCard2
            // 
            pnlCard2.BackColor = System.Drawing.Color.FromArgb(165, 180, 252);
            pnlCard2.Controls.Add(lblCard2Number);
            pnlCard2.Controls.Add(lblCard2Expiry);
            pnlCard2.Controls.Add(lblCard2Balance);
            pnlCard2.Controls.Add(picCard2Logo);
            pnlCard2.Location = new System.Drawing.Point(269, 5);
            pnlCard2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlCard2.Name = "pnlCard2";
            pnlCard2.Size = new System.Drawing.Size(257, 217);
            pnlCard2.TabIndex = 1;
            // 
            // lblCard2Number
            // 
            lblCard2Number.AutoSize = true;
            lblCard2Number.Font = new System.Drawing.Font("Segoe UI", 9F);
            lblCard2Number.ForeColor = System.Drawing.Color.White;
            lblCard2Number.Location = new System.Drawing.Point(21, 83);
            lblCard2Number.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard2Number.Name = "lblCard2Number";
            lblCard2Number.Size = new System.Drawing.Size(163, 25);
            lblCard2Number.TabIndex = 0;
            lblCard2Number.Text = "**** **** **** 3254";
            // 
            // lblCard2Expiry
            // 
            lblCard2Expiry.AutoSize = true;
            lblCard2Expiry.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCard2Expiry.ForeColor = System.Drawing.Color.White;
            lblCard2Expiry.Location = new System.Drawing.Point(21, 125);
            lblCard2Expiry.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard2Expiry.Name = "lblCard2Expiry";
            lblCard2Expiry.Size = new System.Drawing.Size(52, 21);
            lblCard2Expiry.TabIndex = 1;
            lblCard2Expiry.Text = "06/29";
            // 
            // lblCard2Balance
            // 
            lblCard2Balance.AutoSize = true;
            lblCard2Balance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblCard2Balance.ForeColor = System.Drawing.Color.White;
            lblCard2Balance.Location = new System.Drawing.Point(17, 25);
            lblCard2Balance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard2Balance.Name = "lblCard2Balance";
            lblCard2Balance.Size = new System.Drawing.Size(145, 38);
            lblCard2Balance.TabIndex = 2;
            lblCard2Balance.Text = "$4,500.00";
            // 
            // picCard2Logo
            // 
            picCard2Logo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            picCard2Logo.Location = new System.Drawing.Point(186, 158);
            picCard2Logo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            picCard2Logo.Name = "picCard2Logo";
            picCard2Logo.Size = new System.Drawing.Size(57, 42);
            picCard2Logo.TabIndex = 3;
            picCard2Logo.TabStop = false;
            // 
            // pnlCard3
            // 
            pnlCard3.BackColor = System.Drawing.Color.FromArgb(100, 149, 237);
            pnlCard3.Controls.Add(lblCard3Email);
            pnlCard3.Controls.Add(lblCard3Balance);
            pnlCard3.Controls.Add(picCard3Logo);
            pnlCard3.Location = new System.Drawing.Point(534, 5);
            pnlCard3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlCard3.Name = "pnlCard3";
            pnlCard3.Size = new System.Drawing.Size(257, 217);
            pnlCard3.TabIndex = 2;
            // 
            // lblCard3Email
            // 
            lblCard3Email.AutoSize = true;
            lblCard3Email.Font = new System.Drawing.Font("Segoe UI", 8F);
            lblCard3Email.ForeColor = System.Drawing.Color.White;
            lblCard3Email.Location = new System.Drawing.Point(21, 83);
            lblCard3Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard3Email.Name = "lblCard3Email";
            lblCard3Email.Size = new System.Drawing.Size(143, 21);
            lblCard3Email.TabIndex = 0;
            lblCard3Email.Text = "***j***@gmail.com";
            // 
            // lblCard3Balance
            // 
            lblCard3Balance.AutoSize = true;
            lblCard3Balance.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblCard3Balance.ForeColor = System.Drawing.Color.White;
            lblCard3Balance.Location = new System.Drawing.Point(17, 25);
            lblCard3Balance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblCard3Balance.Name = "lblCard3Balance";
            lblCard3Balance.Size = new System.Drawing.Size(145, 38);
            lblCard3Balance.TabIndex = 1;
            lblCard3Balance.Text = "$3,200.00";
            // 
            // picCard3Logo
            // 
            picCard3Logo.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
            picCard3Logo.Location = new System.Drawing.Point(186, 158);
            picCard3Logo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            picCard3Logo.Name = "picCard3Logo";
            picCard3Logo.Size = new System.Drawing.Size(57, 42);
            picCard3Logo.TabIndex = 2;
            picCard3Logo.TabStop = false;
            // 
            // btnDetails
            // 
            btnDetails.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDetails.BackColor = System.Drawing.Color.Transparent;
            btnDetails.FlatAppearance.BorderSize = 0;
            btnDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDetails.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnDetails.ForeColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnDetails.Location = new System.Drawing.Point(737, 17);
            btnDetails.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnDetails.Name = "btnDetails";
            btnDetails.Size = new System.Drawing.Size(114, 50);
            btnDetails.TabIndex = 3;
            btnDetails.Text = "Details ›";
            btnDetails.UseVisualStyleBackColor = false;
            // 
            // cmbMonth
            // 
            cmbMonth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbMonth.FormattingEnabled = true;
            cmbMonth.Items.AddRange(new object[] { "Jun 2024", "May 2024", "Apr 2024" });
            cmbMonth.Location = new System.Drawing.Point(622, 20);
            cmbMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbMonth.Name = "cmbMonth";
            cmbMonth.Size = new System.Drawing.Size(113, 33);
            cmbMonth.TabIndex = 4;
            cmbMonth.Text = "Jun 2024";
            // 
            // pnlTransactionsChart
            // 
            pnlTransactionsChart.BackColor = System.Drawing.Color.White;
            pnlTransactionsChart.Controls.Add(lblTransactionsTitle);
            pnlTransactionsChart.Controls.Add(pnlChart);
            pnlTransactionsChart.Controls.Add(btnSeeAll);
            pnlTransactionsChart.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlTransactionsChart.Location = new System.Drawing.Point(70, 70);
            pnlTransactionsChart.Margin = new System.Windows.Forms.Padding(20);
            pnlTransactionsChart.Name = "pnlTransactionsChart";
            pnlTransactionsChart.Padding = new System.Windows.Forms.Padding(36, 42, 36, 42);
            pnlTransactionsChart.Size = new System.Drawing.Size(897, 464);
            pnlTransactionsChart.TabIndex = 3;
            // 
            // lblTransactionsTitle
            // 
            lblTransactionsTitle.AutoSize = true;
            lblTransactionsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblTransactionsTitle.Location = new System.Drawing.Point(36, 42);
            lblTransactionsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTransactionsTitle.Name = "lblTransactionsTitle";
            lblTransactionsTitle.Size = new System.Drawing.Size(306, 38);
            lblTransactionsTitle.TabIndex = 0;
            lblTransactionsTitle.Text = "Transactions overview";
            // 
            // pnlChart
            // 
            pnlChart.Location = new System.Drawing.Point(36, 117);
            pnlChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlChart.Name = "pnlChart";
            pnlChart.Size = new System.Drawing.Size(840, 308);
            pnlChart.TabIndex = 1;
            // 
            // btnSeeAll
            // 
            btnSeeAll.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnSeeAll.BackColor = System.Drawing.Color.Transparent;
            btnSeeAll.FlatAppearance.BorderSize = 0;
            btnSeeAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSeeAll.Font = new System.Drawing.Font("Segoe UI", 9F);
            btnSeeAll.ForeColor = System.Drawing.Color.FromArgb(124, 108, 254);
            btnSeeAll.Location = new System.Drawing.Point(747, 42);
            btnSeeAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            btnSeeAll.Name = "btnSeeAll";
            btnSeeAll.Size = new System.Drawing.Size(114, 50);
            btnSeeAll.TabIndex = 2;
            btnSeeAll.Text = "See all ›";
            btnSeeAll.UseVisualStyleBackColor = false;
            // 
            // pnlStatistics
            // 
            pnlStatistics.BackColor = System.Drawing.Color.White;
            pnlStatistics.Controls.Add(lblStatisticsTitle);
            pnlStatistics.Controls.Add(cmbStatMonth);
            pnlStatistics.Controls.Add(pnlDonutChart);
            pnlStatistics.Controls.Add(lblTotalIncome);
            pnlStatistics.Controls.Add(lblIncomeAmount);
            pnlStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlStatistics.Location = new System.Drawing.Point(1007, 70);
            pnlStatistics.Margin = new System.Windows.Forms.Padding(20);
            pnlStatistics.Name = "pnlStatistics";
            pnlStatistics.Padding = new System.Windows.Forms.Padding(36, 42, 36, 42);
            pnlStatistics.Size = new System.Drawing.Size(585, 464);
            pnlStatistics.TabIndex = 4;
            // 
            // lblStatisticsTitle
            // 
            lblStatisticsTitle.AutoSize = true;
            lblStatisticsTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblStatisticsTitle.Location = new System.Drawing.Point(36, 42);
            lblStatisticsTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblStatisticsTitle.Name = "lblStatisticsTitle";
            lblStatisticsTitle.Size = new System.Drawing.Size(133, 38);
            lblStatisticsTitle.TabIndex = 0;
            lblStatisticsTitle.Text = "Statistics";
            // 
            // cmbStatMonth
            // 
            cmbStatMonth.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbStatMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            cmbStatMonth.Font = new System.Drawing.Font("Segoe UI", 9F);
            cmbStatMonth.FormattingEnabled = true;
            cmbStatMonth.Items.AddRange(new object[] { "Jun 2024", "May 2024", "Apr 2024" });
            cmbStatMonth.Location = new System.Drawing.Point(421, 47);
            cmbStatMonth.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            cmbStatMonth.Name = "cmbStatMonth";
            cmbStatMonth.Size = new System.Drawing.Size(127, 33);
            cmbStatMonth.TabIndex = 1;
            cmbStatMonth.Text = "Jun 2024";
            // 
            // pnlDonutChart
            // 
            pnlDonutChart.Location = new System.Drawing.Point(100, 117);
            pnlDonutChart.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            pnlDonutChart.Name = "pnlDonutChart";
            pnlDonutChart.Size = new System.Drawing.Size(343, 233);
            pnlDonutChart.TabIndex = 2;
            // 
            // lblTotalIncome
            // 
            lblTotalIncome.AutoSize = true;
            lblTotalIncome.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblTotalIncome.ForeColor = System.Drawing.Color.Gray;
            lblTotalIncome.Location = new System.Drawing.Point(186, 367);
            lblTotalIncome.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTotalIncome.Name = "lblTotalIncome";
            lblTotalIncome.Size = new System.Drawing.Size(123, 28);
            lblTotalIncome.TabIndex = 3;
            lblTotalIncome.Text = "Total income";
            // 
            // lblIncomeAmount
            // 
            lblIncomeAmount.AutoSize = true;
            lblIncomeAmount.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold);
            lblIncomeAmount.Location = new System.Drawing.Point(157, 400);
            lblIncomeAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblIncomeAmount.Name = "lblIncomeAmount";
            lblIncomeAmount.Size = new System.Drawing.Size(187, 48);
            lblIncomeAmount.TabIndex = 4;
            lblIncomeAmount.Text = "$8,500.00";
            // 
            // pnlRecentTransactions
            // 
            pnlRecentTransactions.BackColor = System.Drawing.Color.White;
            tlpMain.SetColumnSpan(pnlRecentTransactions, 2);
            pnlRecentTransactions.Controls.Add(lblRecentTitle);
            pnlRecentTransactions.Controls.Add(dgvTransactions);
            pnlRecentTransactions.Dock = System.Windows.Forms.DockStyle.Fill;
            pnlRecentTransactions.Location = new System.Drawing.Point(70, 574);
            pnlRecentTransactions.Margin = new System.Windows.Forms.Padding(20);
            pnlRecentTransactions.Name = "pnlRecentTransactions";
            pnlRecentTransactions.Padding = new System.Windows.Forms.Padding(36, 42, 36, 42);
            pnlRecentTransactions.Size = new System.Drawing.Size(1522, 465);
            pnlRecentTransactions.TabIndex = 5;
            // 
            // lblRecentTitle
            // 
            lblRecentTitle.AutoSize = true;
            lblRecentTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblRecentTitle.Location = new System.Drawing.Point(36, 42);
            lblRecentTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblRecentTitle.Name = "lblRecentTitle";
            lblRecentTitle.Size = new System.Drawing.Size(272, 38);
            lblRecentTitle.TabIndex = 0;
            lblRecentTitle.Text = "Recent transactions";
            // 
            // dgvTransactions
            // 
            dgvTransactions.BackgroundColor = System.Drawing.Color.White;
            dgvTransactions.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvTransactions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTransactions.Location = new System.Drawing.Point(36, 108);
            dgvTransactions.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            dgvTransactions.Name = "dgvTransactions";
            dgvTransactions.RowHeadersWidth = 62;
            dgvTransactions.Size = new System.Drawing.Size(1557, 267);
            dgvTransactions.TabIndex = 1;
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tlpMain.Controls.Add(pnlRecentTransactions, 0, 1);
            tlpMain.Controls.Add(pnlStatistics, 1, 0);
            tlpMain.Controls.Add(pnlTransactionsChart, 0, 0);
            tlpMain.Dock = System.Windows.Forms.DockStyle.Bottom;
            tlpMain.Location = new System.Drawing.Point(0, 637);
            tlpMain.Name = "tlpMain";
            tlpMain.Padding = new System.Windows.Forms.Padding(50);
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tlpMain.Size = new System.Drawing.Size(1662, 1109);
            tlpMain.TabIndex = 6;
            tlpMain.Paint += tlpMain_Paint;
            // 
            // tlpTop
            // 
            tlpTop.ColumnCount = 2;
            tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            tlpTop.Controls.Add(pnlAccounts, 1, 0);
            tlpTop.Controls.Add(pnlTotalBalance, 0, 0);
            tlpTop.Dock = System.Windows.Forms.DockStyle.Top;
            tlpTop.Location = new System.Drawing.Point(0, 167);
            tlpTop.Name = "tlpTop";
            tlpTop.Padding = new System.Windows.Forms.Padding(30);
            tlpTop.RowCount = 1;
            tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            tlpTop.Size = new System.Drawing.Size(1662, 470);
            tlpTop.TabIndex = 7;
            // 
            // UC_Wallet
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(243, 240, 253);
            Controls.Add(tlpTop);
            Controls.Add(tlpMain);
            Controls.Add(pnlHeader);
            Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            Name = "UC_Wallet";
            Size = new System.Drawing.Size(1662, 1583);
            Load += UC_Wallet_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTotalBalance.ResumeLayout(false);
            pnlTotalBalance.PerformLayout();
            pnlAccounts.ResumeLayout(false);
            pnlAccounts.PerformLayout();
            pnlAccountCards.ResumeLayout(false);
            pnlCard1.ResumeLayout(false);
            pnlCard1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCard1Logo).EndInit();
            pnlCard2.ResumeLayout(false);
            pnlCard2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCard2Logo).EndInit();
            pnlCard3.ResumeLayout(false);
            pnlCard3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picCard3Logo).EndInit();
            pnlTransactionsChart.ResumeLayout(false);
            pnlTransactionsChart.PerformLayout();
            pnlStatistics.ResumeLayout(false);
            pnlStatistics.PerformLayout();
            pnlRecentTransactions.ResumeLayout(false);
            pnlRecentTransactions.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTransactions).EndInit();
            tlpMain.ResumeLayout(false);
            tlpTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnAddNewAccount;
        private System.Windows.Forms.Panel pnlTotalBalance;
        private System.Windows.Forms.Label lblTotalBalanceTitle;
        private System.Windows.Forms.Label lblTotalBalanceAmount;
        private System.Windows.Forms.Label lblCapitalInfo;
        private System.Windows.Forms.ComboBox cmbAllAccounts;
        private System.Windows.Forms.Button btnTransfer;
        private System.Windows.Forms.Button btnRequest;
        private System.Windows.Forms.Button btnMore;
        private System.Windows.Forms.Panel pnlAccounts;
        private System.Windows.Forms.Label lblYourAccounts;
        private System.Windows.Forms.Label lblAccountsCount;
        private System.Windows.Forms.FlowLayoutPanel pnlAccountCards;
        private System.Windows.Forms.Panel pnlCard1;
        private System.Windows.Forms.Label lblCard1Number;
        private System.Windows.Forms.Label lblCard1Name;
        private System.Windows.Forms.Label lblCard1Balance;
        private System.Windows.Forms.PictureBox picCard1Logo;
        private System.Windows.Forms.Panel pnlCard2;
        private System.Windows.Forms.Label lblCard2Number;
        private System.Windows.Forms.Label lblCard2Expiry;
        private System.Windows.Forms.Label lblCard2Balance;
        private System.Windows.Forms.PictureBox picCard2Logo;
        private System.Windows.Forms.Panel pnlCard3;
        private System.Windows.Forms.Label lblCard3Email;
        private System.Windows.Forms.Label lblCard3Balance;
        private System.Windows.Forms.PictureBox picCard3Logo;
        private System.Windows.Forms.Button btnDetails;
        private System.Windows.Forms.ComboBox cmbMonth;
        private System.Windows.Forms.Panel pnlTransactionsChart;
        private System.Windows.Forms.Label lblTransactionsTitle;
        private System.Windows.Forms.Panel pnlChart;
        private System.Windows.Forms.Button btnSeeAll;
        private System.Windows.Forms.Panel pnlStatistics;
        private System.Windows.Forms.Label lblStatisticsTitle;
        private System.Windows.Forms.ComboBox cmbStatMonth;
        private System.Windows.Forms.Panel pnlDonutChart;
        private System.Windows.Forms.Label lblTotalIncome;
        private System.Windows.Forms.Label lblIncomeAmount;
        private System.Windows.Forms.Panel pnlRecentTransactions;
        private System.Windows.Forms.Label lblRecentTitle;
        private System.Windows.Forms.DataGridView dgvTransactions;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
    }
}
