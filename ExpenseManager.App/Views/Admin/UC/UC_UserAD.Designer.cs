using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_UserAD
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
            this.mainPanel = new System.Windows.Forms.Panel();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.paginationPanel = new System.Windows.Forms.Panel();
            this.lblPaginationInfo = new System.Windows.Forms.Label();
            this.lblShowingInfo = new System.Windows.Forms.Label();
            this.kpiPanel = new System.Windows.Forms.Panel();
            this.cardAdmins = new System.Windows.Forms.Panel();
            this.lblAdminsValue = new System.Windows.Forms.Label();
            this.lblAdminsLabel = new System.Windows.Forms.Label();
            this.iconAdmins = new System.Windows.Forms.Panel();
            this.cardBlocked = new System.Windows.Forms.Panel();
            this.lblBlockedValue = new System.Windows.Forms.Label();
            this.lblBlockedLabel = new System.Windows.Forms.Label();
            this.iconBlocked = new System.Windows.Forms.Panel();
            this.cardActive = new System.Windows.Forms.Panel();
            this.lblActiveValue = new System.Windows.Forms.Label();
            this.lblActiveLabel = new System.Windows.Forms.Label();
            this.iconActive = new System.Windows.Forms.Panel();
            this.cardTotal = new System.Windows.Forms.Panel();
            this.lblTotalValue = new System.Windows.Forms.Label();
            this.lblTotalLabel = new System.Windows.Forms.Label();
            this.iconTotal = new System.Windows.Forms.Panel();
            this.searchPanel = new System.Windows.Forms.Panel();
            this.btnRefresh = new FontAwesome.Sharp.IconButton();
            this.btnSearch = new FontAwesome.Sharp.IconButton();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.lblDateTime = new System.Windows.Forms.Label(); // <--- 1. Khởi tạo Label ngày
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.lblLoading = new System.Windows.Forms.Label();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            this.paginationPanel.SuspendLayout();
            this.kpiPanel.SuspendLayout();
            this.cardAdmins.SuspendLayout();
            this.cardBlocked.SuspendLayout();
            this.cardActive.SuspendLayout();
            this.cardTotal.SuspendLayout();
            this.searchPanel.SuspendLayout();
            this.headerPanel.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainPanel
            // 
            this.mainPanel.AutoScroll = true;
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(249)))), ((int)(((byte)(250)))));
            this.mainPanel.Controls.Add(this.dgvUsers);
            this.mainPanel.Controls.Add(this.paginationPanel);
            this.mainPanel.Controls.Add(this.kpiPanel);
            this.mainPanel.Controls.Add(this.searchPanel);
            this.mainPanel.Controls.Add(this.headerPanel);
            this.mainPanel.Controls.Add(this.loadingPanel);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(40, 30, 40, 30);
            this.mainPanel.Size = new System.Drawing.Size(1400, 900);
            this.mainPanel.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.AllowUserToAddRows = false;
            this.dgvUsers.AllowUserToDeleteRows = false;
            this.dgvUsers.AllowUserToResizeRows = false;
            this.dgvUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvUsers.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvUsers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgvUsers.ColumnHeadersHeight = 50;
            this.dgvUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUsers.EnableHeadersVisualStyles = false;
            this.dgvUsers.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.dgvUsers.Location = new System.Drawing.Point(40, 390);
            this.dgvUsers.MultiSelect = false;
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.ReadOnly = true;
            this.dgvUsers.RowHeadersVisible = false;
            this.dgvUsers.RowHeadersWidth = 51;
            this.dgvUsers.RowTemplate.Height = 70;
            this.dgvUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUsers.Size = new System.Drawing.Size(1320, 420);
            this.dgvUsers.TabIndex = 5;
            // 
            // paginationPanel
            // 
            this.paginationPanel.BackColor = System.Drawing.Color.White;
            this.paginationPanel.Controls.Add(this.lblPaginationInfo);
            this.paginationPanel.Controls.Add(this.lblShowingInfo);
            this.paginationPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.paginationPanel.Location = new System.Drawing.Point(40, 810);
            this.paginationPanel.Name = "paginationPanel";
            this.paginationPanel.Padding = new System.Windows.Forms.Padding(20);
            this.paginationPanel.Size = new System.Drawing.Size(1320, 60);
            this.paginationPanel.TabIndex = 4;
            // 
            // lblPaginationInfo
            // 
            this.lblPaginationInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblPaginationInfo.AutoSize = true;
            this.lblPaginationInfo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblPaginationInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPaginationInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblPaginationInfo.Location = new System.Drawing.Point(1180, 20);
            this.lblPaginationInfo.Name = "lblPaginationInfo";
            this.lblPaginationInfo.Size = new System.Drawing.Size(94, 23);
            this.lblPaginationInfo.TabIndex = 1;
            this.lblPaginationInfo.Text = "Page 1 of 1";
            this.lblPaginationInfo.Click += new System.EventHandler(this.LblPaginationInfo_Click);
            // 
            // lblShowingInfo
            // 
            this.lblShowingInfo.AutoSize = true;
            this.lblShowingInfo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblShowingInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.lblShowingInfo.Location = new System.Drawing.Point(23, 20);
            this.lblShowingInfo.Name = "lblShowingInfo";
            this.lblShowingInfo.Size = new System.Drawing.Size(177, 23);
            this.lblShowingInfo.TabIndex = 0;
            this.lblShowingInfo.Text = "Showing 1 to 6 of 6 users";
            // 
            // kpiPanel
            // 
            this.kpiPanel.BackColor = System.Drawing.Color.Transparent;
            this.kpiPanel.Controls.Add(this.cardAdmins);
            this.kpiPanel.Controls.Add(this.cardBlocked);
            this.kpiPanel.Controls.Add(this.cardActive);
            this.kpiPanel.Controls.Add(this.cardTotal);
            this.kpiPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.kpiPanel.Location = new System.Drawing.Point(40, 200);
            this.kpiPanel.Name = "kpiPanel";
            this.kpiPanel.Padding = new System.Windows.Forms.Padding(0, 15, 0, 15);
            this.kpiPanel.Size = new System.Drawing.Size(1320, 190);
            this.kpiPanel.TabIndex = 3;
            // 
            // cardAdmins
            // 
            this.cardAdmins.BackColor = System.Drawing.Color.White;
            this.cardAdmins.Controls.Add(this.lblAdminsValue);
            this.cardAdmins.Controls.Add(this.lblAdminsLabel);
            this.cardAdmins.Controls.Add(this.iconAdmins);
            this.cardAdmins.Location = new System.Drawing.Point(990, 15);
            this.cardAdmins.Name = "cardAdmins";
            this.cardAdmins.Padding = new System.Windows.Forms.Padding(25);
            this.cardAdmins.Size = new System.Drawing.Size(315, 150);
            this.cardAdmins.TabIndex = 3;
            // 
            // lblAdminsValue
            // 
            this.lblAdminsValue.AutoSize = true;
            this.lblAdminsValue.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblAdminsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblAdminsValue.Location = new System.Drawing.Point(120, 40);
            this.lblAdminsValue.Name = "lblAdminsValue";
            this.lblAdminsValue.Size = new System.Drawing.Size(59, 72);
            this.lblAdminsValue.TabIndex = 2;
            this.lblAdminsValue.Text = "2";
            // 
            // lblAdminsLabel
            // 
            this.lblAdminsLabel.AutoSize = true;
            this.lblAdminsLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblAdminsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblAdminsLabel.Location = new System.Drawing.Point(28, 95);
            this.lblAdminsLabel.Name = "lblAdminsLabel";
            this.lblAdminsLabel.Size = new System.Drawing.Size(139, 25);
            this.lblAdminsLabel.TabIndex = 1;
            this.lblAdminsLabel.Text = "Administrators";
            // 
            // iconAdmins
            // 
            this.iconAdmins.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.iconAdmins.Location = new System.Drawing.Point(28, 35);
            this.iconAdmins.Name = "iconAdmins";
            this.iconAdmins.Size = new System.Drawing.Size(60, 60);
            this.iconAdmins.TabIndex = 0;
            // 
            // cardBlocked
            // 
            this.cardBlocked.BackColor = System.Drawing.Color.White;
            this.cardBlocked.Controls.Add(this.lblBlockedValue);
            this.cardBlocked.Controls.Add(this.lblBlockedLabel);
            this.cardBlocked.Controls.Add(this.iconBlocked);
            this.cardBlocked.Location = new System.Drawing.Point(660, 15);
            this.cardBlocked.Name = "cardBlocked";
            this.cardBlocked.Padding = new System.Windows.Forms.Padding(25);
            this.cardBlocked.Size = new System.Drawing.Size(315, 150);
            this.cardBlocked.TabIndex = 2;
            // 
            // lblBlockedValue
            // 
            this.lblBlockedValue.AutoSize = true;
            this.lblBlockedValue.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblBlockedValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblBlockedValue.Location = new System.Drawing.Point(120, 40);
            this.lblBlockedValue.Name = "lblBlockedValue";
            this.lblBlockedValue.Size = new System.Drawing.Size(59, 72);
            this.lblBlockedValue.TabIndex = 2;
            this.lblBlockedValue.Text = "0";
            // 
            // lblBlockedLabel
            // 
            this.lblBlockedLabel.AutoSize = true;
            this.lblBlockedLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblBlockedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblBlockedLabel.Location = new System.Drawing.Point(28, 95);
            this.lblBlockedLabel.Name = "lblBlockedLabel";
            this.lblBlockedLabel.Size = new System.Drawing.Size(127, 25);
            this.lblBlockedLabel.TabIndex = 1;
            this.lblBlockedLabel.Text = "Blocked Users";
            // 
            // iconBlocked
            // 
            this.iconBlocked.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(231)))), ((int)(((byte)(76)))), ((int)(((byte)(60)))));
            this.iconBlocked.Location = new System.Drawing.Point(28, 35);
            this.iconBlocked.Name = "iconBlocked";
            this.iconBlocked.Size = new System.Drawing.Size(60, 60);
            this.iconBlocked.TabIndex = 0;
            // 
            // cardActive
            // 
            this.cardActive.BackColor = System.Drawing.Color.White;
            this.cardActive.Controls.Add(this.lblActiveValue);
            this.cardActive.Controls.Add(this.lblActiveLabel);
            this.cardActive.Controls.Add(this.iconActive);
            this.cardActive.Location = new System.Drawing.Point(330, 15);
            this.cardActive.Name = "cardActive";
            this.cardActive.Padding = new System.Windows.Forms.Padding(25);
            this.cardActive.Size = new System.Drawing.Size(315, 150);
            this.cardActive.TabIndex = 1;
            // 
            // lblActiveValue
            // 
            this.lblActiveValue.AutoSize = true;
            this.lblActiveValue.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblActiveValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblActiveValue.Location = new System.Drawing.Point(120, 40);
            this.lblActiveValue.Name = "lblActiveValue";
            this.lblActiveValue.Size = new System.Drawing.Size(59, 72);
            this.lblActiveValue.TabIndex = 2;
            this.lblActiveValue.Text = "6";
            // 
            // lblActiveLabel
            // 
            this.lblActiveLabel.AutoSize = true;
            this.lblActiveLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblActiveLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblActiveLabel.Location = new System.Drawing.Point(28, 95);
            this.lblActiveLabel.Name = "lblActiveLabel";
            this.lblActiveLabel.Size = new System.Drawing.Size(110, 25);
            this.lblActiveLabel.TabIndex = 1;
            this.lblActiveLabel.Text = "Active Users";
            // 
            // iconActive
            // 
            this.iconActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(204)))), ((int)(((byte)(113)))));
            this.iconActive.Location = new System.Drawing.Point(28, 35);
            this.iconActive.Name = "iconActive";
            this.iconActive.Size = new System.Drawing.Size(60, 60);
            this.iconActive.TabIndex = 0;
            // 
            // cardTotal
            // 
            this.cardTotal.BackColor = System.Drawing.Color.White;
            this.cardTotal.Controls.Add(this.lblTotalValue);
            this.cardTotal.Controls.Add(this.lblTotalLabel);
            this.cardTotal.Controls.Add(this.iconTotal);
            this.cardTotal.Location = new System.Drawing.Point(0, 15);
            this.cardTotal.Name = "cardTotal";
            this.cardTotal.Padding = new System.Windows.Forms.Padding(25);
            this.cardTotal.Size = new System.Drawing.Size(315, 150);
            this.cardTotal.TabIndex = 0;
            // 
            // lblTotalValue
            // 
            this.lblTotalValue.AutoSize = true;
            this.lblTotalValue.Font = new System.Drawing.Font("Segoe UI", 32F, System.Drawing.FontStyle.Bold);
            this.lblTotalValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(73)))), ((int)(((byte)(94)))));
            this.lblTotalValue.Location = new System.Drawing.Point(120, 40);
            this.lblTotalValue.Name = "lblTotalValue";
            this.lblTotalValue.Size = new System.Drawing.Size(59, 72);
            this.lblTotalValue.TabIndex = 2;
            this.lblTotalValue.Text = "6";
            // 
            // lblTotalLabel
            // 
            this.lblTotalLabel.AutoSize = true;
            this.lblTotalLabel.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTotalLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblTotalLabel.Location = new System.Drawing.Point(28, 95);
            this.lblTotalLabel.Name = "lblTotalLabel";
            this.lblTotalLabel.Size = new System.Drawing.Size(100, 25);
            this.lblTotalLabel.TabIndex = 1;
            this.lblTotalLabel.Text = "Total Users";
            // 
            // iconTotal
            // 
            this.iconTotal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(89)))), ((int)(((byte)(182)))));
            this.iconTotal.Location = new System.Drawing.Point(28, 35);
            this.iconTotal.Name = "iconTotal";
            this.iconTotal.Size = new System.Drawing.Size(60, 60);
            this.iconTotal.TabIndex = 0;
            // 
            // searchPanel
            // 
            this.searchPanel.BackColor = System.Drawing.Color.White;
            this.searchPanel.Controls.Add(this.btnRefresh);
            this.searchPanel.Controls.Add(this.btnSearch);
            this.searchPanel.Controls.Add(this.cmbStatus);
            this.searchPanel.Controls.Add(this.cmbRole);
            this.searchPanel.Controls.Add(this.txtSearch);
            this.searchPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.searchPanel.Location = new System.Drawing.Point(40, 110);
            this.searchPanel.Name = "searchPanel";
            this.searchPanel.Padding = new System.Windows.Forms.Padding(25, 20, 25, 20);
            this.searchPanel.Size = new System.Drawing.Size(1320, 90);
            this.searchPanel.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(149)))), ((int)(((byte)(165)))), ((int)(((byte)(166)))));
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.btnRefresh.IconColor = System.Drawing.Color.White;
            this.btnRefresh.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnRefresh.IconSize = 24;
            this.btnRefresh.Location = new System.Drawing.Point(1240, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(50, 40);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearch.IconColor = System.Drawing.Color.White;
            this.btnSearch.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearch.IconSize = 24;
            this.btnSearch.Location = new System.Drawing.Point(1175, 26);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(50, 40);
            this.btnSearch.TabIndex = 3;
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // cmbStatus
            // 
            this.cmbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbStatus.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbStatus.FormattingEnabled = true;
            this.cmbStatus.Items.AddRange(new object[] {
            "All Status",
            "Active",
            "Blocked"});
            this.cmbStatus.Location = new System.Drawing.Point(960, 28);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(190, 33);
            this.cmbStatus.TabIndex = 2;
            this.cmbStatus.SelectedIndexChanged += new System.EventHandler(this.CmbStatus_SelectedIndexChanged);
            // 
            // cmbRole
            // 
            this.cmbRole.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "All Roles",
            "User",
            "Admin"});
            this.cmbRole.Location = new System.Drawing.Point(750, 28);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(190, 33);
            this.cmbRole.TabIndex = 1;
            this.cmbRole.SelectedIndexChanged += new System.EventHandler(this.CmbRole_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.txtSearch.Location = new System.Drawing.Point(28, 26);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search users...";
            this.txtSearch.Size = new System.Drawing.Size(700, 34);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtSearch_KeyPress);
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.Transparent;
            this.headerPanel.Controls.Add(this.lblDateTime); // <--- 2. Thêm vào panel
            this.headerPanel.Controls.Add(this.lblSubtitle);
            this.headerPanel.Controls.Add(this.lblTitle);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(40, 30);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(1320, 80);
            this.headerPanel.TabIndex = 1;
            // 
            // lblDateTime
            // 
            this.lblDateTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDateTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDateTime.ForeColor = System.Drawing.Color.Gray;
            this.lblDateTime.Location = new System.Drawing.Point(1000, 15); // Vị trí góc phải
            this.lblDateTime.Name = "lblDateTime";
            this.lblDateTime.Size = new System.Drawing.Size(300, 23);
            this.lblDateTime.TabIndex = 2;
            this.lblDateTime.Text = "📅 ...";
            this.lblDateTime.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(127)))), ((int)(((byte)(140)))), ((int)(((byte)(141)))));
            this.lblSubtitle.Location = new System.Drawing.Point(5, 50);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(336, 23);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Manage all system users and their accounts";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.lblTitle.Location = new System.Drawing.Point(0, 5);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(301, 46);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "User Management";
            // 
            // loadingPanel
            // 
            this.loadingPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(250)))));
            this.loadingPanel.Controls.Add(this.lblLoading);
            this.loadingPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loadingPanel.Location = new System.Drawing.Point(40, 30);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(1320, 840);
            this.loadingPanel.TabIndex = 6;
            this.loadingPanel.Visible = false;
            // 
            // lblLoading
            // 
            this.lblLoading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLoading.Font = new System.Drawing.Font("Segoe UI", 16F);
            this.lblLoading.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(152)))), ((int)(((byte)(219)))));
            this.lblLoading.Location = new System.Drawing.Point(0, 0);
            this.lblLoading.Name = "lblLoading";
            this.lblLoading.Size = new System.Drawing.Size(1320, 840);
            this.lblLoading.TabIndex = 0;
            this.lblLoading.Text = "⏳ Loading data...";
            this.lblLoading.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_UserAD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.mainPanel);
            this.Name = "UC_UserAD";
            this.Size = new System.Drawing.Size(1400, 900);
            this.mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            this.paginationPanel.ResumeLayout(false);
            this.paginationPanel.PerformLayout();
            this.kpiPanel.ResumeLayout(false);
            this.cardAdmins.ResumeLayout(false);
            this.cardAdmins.PerformLayout();
            this.cardBlocked.ResumeLayout(false);
            this.cardBlocked.PerformLayout();
            this.cardActive.ResumeLayout(false);
            this.cardActive.PerformLayout();
            this.cardTotal.ResumeLayout(false);
            this.cardTotal.PerformLayout();
            this.searchPanel.ResumeLayout(false);
            this.searchPanel.PerformLayout();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.loadingPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Label lblDateTime; // <--- 3. Khai báo biến
        private System.Windows.Forms.Panel searchPanel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.ComboBox cmbStatus;
        private FontAwesome.Sharp.IconButton btnSearch;
        private FontAwesome.Sharp.IconButton btnRefresh;
        private System.Windows.Forms.Panel kpiPanel;
        private System.Windows.Forms.Panel cardTotal;
        private System.Windows.Forms.Panel iconTotal;
        private System.Windows.Forms.Label lblTotalLabel;
        private System.Windows.Forms.Label lblTotalValue;
        private System.Windows.Forms.Panel cardActive;
        private System.Windows.Forms.Label lblActiveValue;
        private System.Windows.Forms.Label lblActiveLabel;
        private System.Windows.Forms.Panel iconActive;
        private System.Windows.Forms.Panel cardBlocked;
        private System.Windows.Forms.Label lblBlockedValue;
        private System.Windows.Forms.Label lblBlockedLabel;
        private System.Windows.Forms.Panel iconBlocked;
        private System.Windows.Forms.Panel cardAdmins;
        private System.Windows.Forms.Label lblAdminsValue;
        private System.Windows.Forms.Label lblAdminsLabel;
        private System.Windows.Forms.Panel iconAdmins;
        private System.Windows.Forms.Panel paginationPanel;
        private System.Windows.Forms.Label lblShowingInfo;
        private System.Windows.Forms.Label lblPaginationInfo;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Panel loadingPanel;
        private System.Windows.Forms.Label lblLoading;
    }
}