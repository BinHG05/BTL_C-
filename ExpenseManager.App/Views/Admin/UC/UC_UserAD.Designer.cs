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
            mainPanel = new Panel();
            dgvUsers = new DataGridView();
            paginationPanel = new Panel();
            lblPaginationInfo = new Label();
            lblShowingInfo = new Label();
            kpiPanel = new Panel();
            cardAdmins = new Panel();
            lblAdminsValue = new Label();
            lblAdminsLabel = new Label();
            iconAdmins = new Panel();
            cardBlocked = new Panel();
            lblBlockedValue = new Label();
            lblBlockedLabel = new Label();
            iconBlocked = new Panel();
            cardActive = new Panel();
            lblActiveValue = new Label();
            lblActiveLabel = new Label();
            iconActive = new Panel();
            cardTotal = new Panel();
            lblTotalValue = new Label();
            lblTotalLabel = new Label();
            iconTotal = new Panel();
            searchPanel = new Panel();
            btnRefresh = new IconButton();
            btnSearch = new IconButton();
            cmbStatus = new ComboBox();
            cmbRole = new ComboBox();
            txtSearch = new TextBox();
            headerPanel = new Panel();
            lblDateTime = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            loadingPanel = new Panel();
            lblLoading = new Label();
            mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvUsers).BeginInit();
            paginationPanel.SuspendLayout();
            kpiPanel.SuspendLayout();
            cardAdmins.SuspendLayout();
            cardBlocked.SuspendLayout();
            cardActive.SuspendLayout();
            cardTotal.SuspendLayout();
            searchPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            loadingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(248, 249, 250);
            mainPanel.Controls.Add(dgvUsers);
            mainPanel.Controls.Add(paginationPanel);
            mainPanel.Controls.Add(kpiPanel);
            mainPanel.Controls.Add(searchPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Controls.Add(loadingPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(40, 30, 40, 30);
            mainPanel.Size = new Size(1400, 900);
            mainPanel.TabIndex = 0;
            // 
            // dgvUsers
            // 
            dgvUsers.AllowUserToAddRows = false;
            dgvUsers.AllowUserToDeleteRows = false;
            dgvUsers.AllowUserToResizeRows = false;
            dgvUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvUsers.BackgroundColor = Color.White;
            dgvUsers.BorderStyle = BorderStyle.None;
            dgvUsers.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUsers.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUsers.ColumnHeadersHeight = 50;
            dgvUsers.Dock = DockStyle.Fill;
            dgvUsers.EnableHeadersVisualStyles = false;
            dgvUsers.GridColor = Color.FromArgb(240, 240, 240);
            dgvUsers.Location = new Point(40, 390);
            dgvUsers.MultiSelect = false;
            dgvUsers.Name = "dgvUsers";
            dgvUsers.ReadOnly = true;
            dgvUsers.RowHeadersVisible = false;
            dgvUsers.RowHeadersWidth = 51;
            dgvUsers.RowTemplate.Height = 70;
            dgvUsers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvUsers.Size = new Size(1320, 420);
            dgvUsers.TabIndex = 5;
            // 
            // paginationPanel
            // 
            paginationPanel.BackColor = Color.White;
            paginationPanel.Controls.Add(lblPaginationInfo);
            paginationPanel.Controls.Add(lblShowingInfo);
            paginationPanel.Dock = DockStyle.Bottom;
            paginationPanel.Location = new Point(40, 810);
            paginationPanel.Name = "paginationPanel";
            paginationPanel.Padding = new Padding(20);
            paginationPanel.Size = new Size(1320, 60);
            paginationPanel.TabIndex = 4;
            // 
            // lblPaginationInfo
            // 
            lblPaginationInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblPaginationInfo.AutoSize = true;
            lblPaginationInfo.Cursor = Cursors.Hand;
            lblPaginationInfo.Font = new Font("Segoe UI", 10F);
            lblPaginationInfo.ForeColor = Color.FromArgb(100, 100, 100);
            lblPaginationInfo.Location = new Point(1180, 20);
            lblPaginationInfo.Name = "lblPaginationInfo";
            lblPaginationInfo.Size = new Size(113, 23);
            lblPaginationInfo.TabIndex = 1;
            lblPaginationInfo.Text = "Trang 1 của 1";
            lblPaginationInfo.Click += LblPaginationInfo_Click;
            // 
            // lblShowingInfo
            // 
            lblShowingInfo.AutoSize = true;
            lblShowingInfo.Font = new Font("Segoe UI", 10F);
            lblShowingInfo.ForeColor = Color.FromArgb(100, 100, 100);
            lblShowingInfo.Location = new Point(23, 20);
            lblShowingInfo.Name = "lblShowingInfo";
            lblShowingInfo.Size = new Size(293, 23);
            lblShowingInfo.TabIndex = 0;
            lblShowingInfo.Text = "Hiển thị từ 1 đến 6 của 6 người dùng";
            // 
            // kpiPanel
            // 
            kpiPanel.BackColor = Color.Transparent;
            kpiPanel.Controls.Add(cardAdmins);
            kpiPanel.Controls.Add(cardBlocked);
            kpiPanel.Controls.Add(cardActive);
            kpiPanel.Controls.Add(cardTotal);
            kpiPanel.Dock = DockStyle.Top;
            kpiPanel.Location = new Point(40, 200);
            kpiPanel.Name = "kpiPanel";
            kpiPanel.Padding = new Padding(0, 15, 0, 15);
            kpiPanel.Size = new Size(1320, 190);
            kpiPanel.TabIndex = 3;
            // 
            // cardAdmins
            // 
            cardAdmins.BackColor = Color.White;
            cardAdmins.Controls.Add(lblAdminsValue);
            cardAdmins.Controls.Add(lblAdminsLabel);
            cardAdmins.Controls.Add(iconAdmins);
            cardAdmins.Location = new Point(990, 15);
            cardAdmins.Name = "cardAdmins";
            cardAdmins.Padding = new Padding(25);
            cardAdmins.Size = new Size(315, 150);
            cardAdmins.TabIndex = 3;
            // 
            // lblAdminsValue
            // 
            lblAdminsValue.AutoSize = true;
            lblAdminsValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblAdminsValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblAdminsValue.Location = new Point(120, 40);
            lblAdminsValue.Name = "lblAdminsValue";
            lblAdminsValue.Size = new Size(61, 72);
            lblAdminsValue.TabIndex = 2;
            lblAdminsValue.Text = "2";
            // 
            // lblAdminsLabel
            // 
            lblAdminsLabel.AutoSize = true;
            lblAdminsLabel.Font = new Font("Segoe UI", 11F);
            lblAdminsLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblAdminsLabel.Location = new Point(28, 95);
            lblAdminsLabel.Name = "lblAdminsLabel";
            lblAdminsLabel.Size = new Size(144, 25);
            lblAdminsLabel.TabIndex = 1;
            lblAdminsLabel.Text = "Số quản trị viên";
            // 
            // iconAdmins
            // 
            iconAdmins.BackColor = Color.FromArgb(52, 152, 219);
            iconAdmins.Location = new Point(28, 35);
            iconAdmins.Name = "iconAdmins";
            iconAdmins.Size = new Size(60, 60);
            iconAdmins.TabIndex = 0;
            // 
            // cardBlocked
            // 
            cardBlocked.BackColor = Color.White;
            cardBlocked.Controls.Add(lblBlockedValue);
            cardBlocked.Controls.Add(lblBlockedLabel);
            cardBlocked.Controls.Add(iconBlocked);
            cardBlocked.Location = new Point(660, 15);
            cardBlocked.Name = "cardBlocked";
            cardBlocked.Padding = new Padding(25);
            cardBlocked.Size = new Size(315, 150);
            cardBlocked.TabIndex = 2;
            // 
            // lblBlockedValue
            // 
            lblBlockedValue.AutoSize = true;
            lblBlockedValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblBlockedValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblBlockedValue.Location = new Point(120, 40);
            lblBlockedValue.Name = "lblBlockedValue";
            lblBlockedValue.Size = new Size(61, 72);
            lblBlockedValue.TabIndex = 2;
            lblBlockedValue.Text = "0";
            // 
            // lblBlockedLabel
            // 
            lblBlockedLabel.AutoSize = true;
            lblBlockedLabel.Font = new Font("Segoe UI", 11F);
            lblBlockedLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblBlockedLabel.Location = new Point(28, 95);
            lblBlockedLabel.Name = "lblBlockedLabel";
            lblBlockedLabel.Size = new Size(203, 25);
            lblBlockedLabel.TabIndex = 1;
            lblBlockedLabel.Text = "Số người dùng bị chặn";
            // 
            // iconBlocked
            // 
            iconBlocked.BackColor = Color.FromArgb(231, 76, 60);
            iconBlocked.Location = new Point(28, 35);
            iconBlocked.Name = "iconBlocked";
            iconBlocked.Size = new Size(60, 60);
            iconBlocked.TabIndex = 0;
            // 
            // cardActive
            // 
            cardActive.BackColor = Color.White;
            cardActive.Controls.Add(lblActiveValue);
            cardActive.Controls.Add(lblActiveLabel);
            cardActive.Controls.Add(iconActive);
            cardActive.Location = new Point(330, 15);
            cardActive.Name = "cardActive";
            cardActive.Padding = new Padding(25);
            cardActive.Size = new Size(315, 150);
            cardActive.TabIndex = 1;
            // 
            // lblActiveValue
            // 
            lblActiveValue.AutoSize = true;
            lblActiveValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblActiveValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblActiveValue.Location = new Point(120, 40);
            lblActiveValue.Name = "lblActiveValue";
            lblActiveValue.Size = new Size(61, 72);
            lblActiveValue.TabIndex = 2;
            lblActiveValue.Text = "6";
            // 
            // lblActiveLabel
            // 
            lblActiveLabel.AutoSize = true;
            lblActiveLabel.Font = new Font("Segoe UI", 11F);
            lblActiveLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblActiveLabel.Location = new Point(28, 95);
            lblActiveLabel.Name = "lblActiveLabel";
            lblActiveLabel.Size = new Size(228, 25);
            lblActiveLabel.TabIndex = 1;
            lblActiveLabel.Text = "Số người dùng hoạt động";
            // 
            // iconActive
            // 
            iconActive.BackColor = Color.FromArgb(46, 204, 113);
            iconActive.Location = new Point(28, 35);
            iconActive.Name = "iconActive";
            iconActive.Size = new Size(60, 60);
            iconActive.TabIndex = 0;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.White;
            cardTotal.Controls.Add(lblTotalValue);
            cardTotal.Controls.Add(lblTotalLabel);
            cardTotal.Controls.Add(iconTotal);
            cardTotal.Location = new Point(0, 15);
            cardTotal.Name = "cardTotal";
            cardTotal.Padding = new Padding(25);
            cardTotal.Size = new Size(315, 150);
            cardTotal.TabIndex = 0;
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 32F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblTotalValue.Location = new Point(120, 40);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(61, 72);
            lblTotalValue.TabIndex = 2;
            lblTotalValue.Text = "6";
            // 
            // lblTotalLabel
            // 
            lblTotalLabel.AutoSize = true;
            lblTotalLabel.Font = new Font("Segoe UI", 11F);
            lblTotalLabel.ForeColor = Color.FromArgb(127, 140, 141);
            lblTotalLabel.Location = new Point(28, 95);
            lblTotalLabel.Name = "lblTotalLabel";
            lblTotalLabel.Size = new Size(158, 25);
            lblTotalLabel.TabIndex = 1;
            lblTotalLabel.Text = "Tổng người dùng";
            // 
            // iconTotal
            // 
            iconTotal.BackColor = Color.FromArgb(155, 89, 182);
            iconTotal.Location = new Point(28, 35);
            iconTotal.Name = "iconTotal";
            iconTotal.Size = new Size(60, 60);
            iconTotal.TabIndex = 0;
            // 
            // searchPanel
            // 
            searchPanel.BackColor = Color.White;
            searchPanel.Controls.Add(btnRefresh);
            searchPanel.Controls.Add(btnSearch);
            searchPanel.Controls.Add(cmbStatus);
            searchPanel.Controls.Add(cmbRole);
            searchPanel.Controls.Add(txtSearch);
            searchPanel.Dock = DockStyle.Top;
            searchPanel.Location = new Point(40, 110);
            searchPanel.Name = "searchPanel";
            searchPanel.Padding = new Padding(25, 20, 25, 20);
            searchPanel.Size = new Size(1320, 90);
            searchPanel.TabIndex = 2;
            // 
            // btnRefresh
            // 
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(149, 165, 166);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.IconChar = IconChar.Refresh;
            btnRefresh.IconColor = Color.White;
            btnRefresh.IconFont = IconFont.Auto;
            btnRefresh.IconSize = 24;
            btnRefresh.Location = new Point(1240, 26);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(50, 40);
            btnRefresh.TabIndex = 4;
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += BtnRefresh_Click;
            // 
            // btnSearch
            // 
            btnSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnSearch.BackColor = Color.FromArgb(52, 152, 219);
            btnSearch.Cursor = Cursors.Hand;
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.FlatStyle = FlatStyle.Flat;
            btnSearch.IconChar = IconChar.Search;
            btnSearch.IconColor = Color.White;
            btnSearch.IconFont = IconFont.Auto;
            btnSearch.IconSize = 24;
            btnSearch.Location = new Point(1175, 26);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(50, 40);
            btnSearch.TabIndex = 3;
            btnSearch.UseVisualStyleBackColor = false;
            btnSearch.Click += BtnSearch_Click;
            // 
            // cmbStatus
            // 
            cmbStatus.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus.Font = new Font("Segoe UI", 11F);
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Tất cả trạng thái", "Hoạt động", "Bị chặn" });
            cmbStatus.Location = new Point(960, 28);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(190, 33);
            cmbStatus.TabIndex = 2;
            cmbStatus.SelectedIndexChanged += CmbStatus_SelectedIndexChanged;
            // 
            // cmbRole
            // 
            cmbRole.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbRole.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRole.Font = new Font("Segoe UI", 11F);
            cmbRole.FormattingEnabled = true;
            cmbRole.Items.AddRange(new object[] { "Tất cả vai trò", "Người dùng", "Quản trị viên" }); 
            cmbRole.Location = new Point(750, 28);
            cmbRole.Name = "cmbRole";
            cmbRole.Size = new Size(190, 33);
            cmbRole.TabIndex = 1;
            cmbRole.SelectedIndexChanged += CmbRole_SelectedIndexChanged;
            // 
            // txtSearch
            // 
            txtSearch.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            txtSearch.Font = new Font("Segoe UI", 12F);
            txtSearch.Location = new Point(28, 26);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm kiếm người dùng...";
            txtSearch.Size = new Size(700, 34);
            txtSearch.TabIndex = 0;
            txtSearch.KeyPress += TxtSearch_KeyPress;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Transparent;
            headerPanel.Controls.Add(lblDateTime);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(40, 30);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1320, 80);
            headerPanel.TabIndex = 1;
            // 
            // lblDateTime
            // 
            lblDateTime.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDateTime.Font = new Font("Segoe UI", 9F);
            lblDateTime.ForeColor = Color.Gray;
            lblDateTime.Location = new Point(1000, 15);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(300, 23);
            lblDateTime.TabIndex = 2;
            lblDateTime.Text = "📅 ...";
            lblDateTime.TextAlign = ContentAlignment.TopRight;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(127, 140, 141);
            lblSubtitle.Location = new Point(5, 50);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(366, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý tất cả người dùng và tài khoản của họ";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(44, 62, 80);
            lblTitle.Location = new Point(0, 5);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(341, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Quản lý người dùng";
            // 
            // loadingPanel
            // 
            loadingPanel.BackColor = Color.FromArgb(250, 250, 250);
            loadingPanel.Controls.Add(lblLoading);
            loadingPanel.Dock = DockStyle.Fill;
            loadingPanel.Location = new Point(40, 30);
            loadingPanel.Name = "loadingPanel";
            loadingPanel.Size = new Size(1320, 840);
            loadingPanel.TabIndex = 6;
            loadingPanel.Visible = false;
            // 
            // lblLoading
            // 
            lblLoading.Dock = DockStyle.Fill;
            lblLoading.Font = new Font("Segoe UI", 16F);
            lblLoading.ForeColor = Color.FromArgb(52, 152, 219);
            lblLoading.Location = new Point(0, 0);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(1320, 840);
            lblLoading.TabIndex = 0;
            lblLoading.Text = "⏳ Đang tải dữ liệu...";
            lblLoading.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // UC_UserAD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Name = "UC_UserAD";
            Size = new Size(1400, 900);
            mainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvUsers).EndInit();
            paginationPanel.ResumeLayout(false);
            paginationPanel.PerformLayout();
            kpiPanel.ResumeLayout(false);
            cardAdmins.ResumeLayout(false);
            cardAdmins.PerformLayout();
            cardBlocked.ResumeLayout(false);
            cardBlocked.PerformLayout();
            cardActive.ResumeLayout(false);
            cardActive.PerformLayout();
            cardTotal.ResumeLayout(false);
            cardTotal.PerformLayout();
            searchPanel.ResumeLayout(false);
            searchPanel.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            loadingPanel.ResumeLayout(false);
            ResumeLayout(false);

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