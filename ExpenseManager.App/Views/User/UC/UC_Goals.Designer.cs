namespace ExpenseManager.App.Views.User
{
    partial class UC_Goals
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            this.pnlGoalHeader = new System.Windows.Forms.Panel();
            this.lblGoalTitle = new System.Windows.Forms.Label();
            this.btnNaptien = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.pnlSaved = new System.Windows.Forms.Panel();
            this.pnlPbBackground = new System.Windows.Forms.Panel();
            this.pnlPbValue = new System.Windows.Forms.Panel();
            this.lblSavedTitle = new System.Windows.Forms.Label();
            this.lblSavedAmount = new System.Windows.Forms.Label();
            this.pnlTarget = new System.Windows.Forms.Panel();
            this.lblTargetTitle = new System.Windows.Forms.Label();
            this.lblTargetAmount = new System.Windows.Forms.Label();
            this.pnlAvailable = new System.Windows.Forms.Panel();
            this.flpWalletList = new System.Windows.Forms.FlowLayoutPanel();
            this.lblAvailableTitle = new System.Windows.Forms.Label();
            this.pnlHistory = new System.Windows.Forms.Panel();
            this.lblNoHistory = new System.Windows.Forms.Label();
            this.lblHistoryTitle = new System.Windows.Forms.Label();
            this.dgvHistory = new System.Windows.Forms.DataGridView();
            this.pnlEmptyState = new System.Windows.Forms.Panel();
            this.lblEmptyMessage = new System.Windows.Forms.Label();
            this.pnlHeader.SuspendLayout();
            this.pnlLeftSidebar.SuspendLayout();
            this.pnlGoalHeader.SuspendLayout();
            this.pnlSaved.SuspendLayout();
            this.pnlPbBackground.SuspendLayout();
            this.pnlTarget.SuspendLayout();
            this.pnlAvailable.SuspendLayout();
            this.pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).BeginInit();
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
            this.lblTitle.Size = new System.Drawing.Size(171, 47);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Mục Tiêu";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(35, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(272, 20);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Quản lý các kế hoạch tài chính của bạn";
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftSidebar.Controls.Add(this.flpGoals);
            this.pnlLeftSidebar.Location = new System.Drawing.Point(30, 160);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(350, 700);
            this.pnlLeftSidebar.TabIndex = 1;
            // 
            // flpGoals
            // 
            this.flpGoals.AutoScroll = true;
            this.flpGoals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpGoals.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpGoals.Location = new System.Drawing.Point(0, 0);
            this.flpGoals.Name = "flpGoals";
            this.flpGoals.Padding = new System.Windows.Forms.Padding(0, 0, 0, 20);
            this.flpGoals.Size = new System.Drawing.Size(350, 700);
            this.flpGoals.TabIndex = 3;
            this.flpGoals.WrapContents = false;
            // 
            // pnlGoalHeader
            // 
            this.pnlGoalHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlGoalHeader.BackColor = System.Drawing.Color.White;
            this.pnlGoalHeader.Controls.Add(this.lblGoalTitle);
            this.pnlGoalHeader.Controls.Add(this.btnNaptien);
            this.pnlGoalHeader.Controls.Add(this.btnXoa);
            this.pnlGoalHeader.Location = new System.Drawing.Point(410, 160);
            this.pnlGoalHeader.Name = "pnlGoalHeader";
            this.pnlGoalHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlGoalHeader.Size = new System.Drawing.Size(1160, 80);
            this.pnlGoalHeader.TabIndex = 2;
            // 
            // lblGoalTitle
            // 
            this.lblGoalTitle.AutoSize = true;
            this.lblGoalTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblGoalTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblGoalTitle.Location = new System.Drawing.Point(30, 17);
            this.lblGoalTitle.Name = "lblGoalTitle";
            this.lblGoalTitle.Size = new System.Drawing.Size(260, 37);
            this.lblGoalTitle.TabIndex = 0;
            this.lblGoalTitle.Text = "Chọn một mục tiêu";
            // 
            // btnNaptien
            // 
            this.btnNaptien.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNaptien.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnNaptien.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnNaptien.FlatAppearance.BorderSize = 0;
            this.btnNaptien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNaptien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnNaptien.ForeColor = System.Drawing.Color.White;
            this.btnNaptien.Location = new System.Drawing.Point(920, 18);
            this.btnNaptien.Name = "btnNaptien";
            this.btnNaptien.Size = new System.Drawing.Size(100, 44);
            this.btnNaptien.TabIndex = 1;
            this.btnNaptien.Text = "💰 Nạp";
            this.btnNaptien.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoa.FlatAppearance.BorderSize = 0;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.Location = new System.Drawing.Point(1030, 18);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(100, 44);
            this.btnXoa.TabIndex = 2;
            this.btnXoa.Text = "🗑️ Xóa";
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // pnlSaved
            // 
            this.pnlSaved.BackColor = System.Drawing.Color.White;
            this.pnlSaved.Controls.Add(this.pnlPbBackground);
            this.pnlSaved.Controls.Add(this.lblSavedTitle);
            this.pnlSaved.Controls.Add(this.lblSavedAmount);
            this.pnlSaved.Location = new System.Drawing.Point(410, 260);
            this.pnlSaved.Name = "pnlSaved";
            this.pnlSaved.Padding = new System.Windows.Forms.Padding(30);
            this.pnlSaved.Size = new System.Drawing.Size(570, 170);
            this.pnlSaved.TabIndex = 3;
            // 
            // pnlPbBackground
            // 
            this.pnlPbBackground.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.pnlPbBackground.Controls.Add(this.pnlPbValue);
            this.pnlPbBackground.Location = new System.Drawing.Point(30, 135);
            this.pnlPbBackground.Name = "pnlPbBackground";
            this.pnlPbBackground.Size = new System.Drawing.Size(510, 15);
            this.pnlPbBackground.TabIndex = 2;
            // 
            // pnlPbValue
            // 
            this.pnlPbValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.pnlPbValue.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPbValue.Location = new System.Drawing.Point(0, 0);
            this.pnlPbValue.Name = "pnlPbValue";
            this.pnlPbValue.Size = new System.Drawing.Size(0, 15);
            this.pnlPbValue.TabIndex = 0;
            // 
            // lblSavedTitle
            // 
            this.lblSavedTitle.AutoSize = true;
            this.lblSavedTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSavedTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSavedTitle.Location = new System.Drawing.Point(30, 30);
            this.lblSavedTitle.Name = "lblSavedTitle";
            this.lblSavedTitle.Size = new System.Drawing.Size(91, 20);
            this.lblSavedTitle.TabIndex = 0;
            this.lblSavedTitle.Text = "Đã tiết kiệm";
            // 
            // lblSavedAmount
            // 
            this.lblSavedAmount.AutoSize = true;
            this.lblSavedAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblSavedAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSavedAmount.Location = new System.Drawing.Point(30, 70);
            this.lblSavedAmount.Name = "lblSavedAmount";
            this.lblSavedAmount.Size = new System.Drawing.Size(76, 51);
            this.lblSavedAmount.TabIndex = 1;
            this.lblSavedAmount.Text = "0 đ";
            // 
            // pnlTarget
            // 
            this.pnlTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlTarget.BackColor = System.Drawing.Color.White;
            this.pnlTarget.Controls.Add(this.lblTargetTitle);
            this.pnlTarget.Controls.Add(this.lblTargetAmount);
            this.pnlTarget.Location = new System.Drawing.Point(1000, 260);
            this.pnlTarget.Name = "pnlTarget";
            this.pnlTarget.Padding = new System.Windows.Forms.Padding(30);
            this.pnlTarget.Size = new System.Drawing.Size(570, 170);
            this.pnlTarget.TabIndex = 4;
            // 
            // lblTargetTitle
            // 
            this.lblTargetTitle.AutoSize = true;
            this.lblTargetTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblTargetTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTargetTitle.Location = new System.Drawing.Point(30, 30);
            this.lblTargetTitle.Name = "lblTargetTitle";
            this.lblTargetTitle.Size = new System.Drawing.Size(67, 20);
            this.lblTargetTitle.TabIndex = 0;
            this.lblTargetTitle.Text = "Mục tiêu";
            // 
            // lblTargetAmount
            // 
            this.lblTargetAmount.AutoSize = true;
            this.lblTargetAmount.Font = new System.Drawing.Font("Segoe UI", 28F, System.Drawing.FontStyle.Bold);
            this.lblTargetAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTargetAmount.Location = new System.Drawing.Point(30, 70);
            this.lblTargetAmount.Name = "lblTargetAmount";
            this.lblTargetAmount.Size = new System.Drawing.Size(76, 51);
            this.lblTargetAmount.TabIndex = 1;
            this.lblTargetAmount.Text = "0 đ";
            // 
            // pnlAvailable
            // 
            this.pnlAvailable.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlAvailable.BackColor = System.Drawing.Color.White;
            this.pnlAvailable.Controls.Add(this.flpWalletList);
            this.pnlAvailable.Controls.Add(this.lblAvailableTitle);
            this.pnlAvailable.Location = new System.Drawing.Point(410, 450);
            this.pnlAvailable.Name = "pnlAvailable";
            this.pnlAvailable.Padding = new System.Windows.Forms.Padding(30);
            this.pnlAvailable.Size = new System.Drawing.Size(1160, 330);
            this.pnlAvailable.TabIndex = 5;
            // 
            // flpWalletList
            // 
            this.flpWalletList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpWalletList.AutoScroll = true;
            this.flpWalletList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpWalletList.Location = new System.Drawing.Point(30, 80);
            this.flpWalletList.Name = "flpWalletList";
            this.flpWalletList.Size = new System.Drawing.Size(1100, 220);
            this.flpWalletList.TabIndex = 1;
            this.flpWalletList.WrapContents = false;
            // 
            // lblAvailableTitle
            // 
            this.lblAvailableTitle.AutoSize = true;
            this.lblAvailableTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblAvailableTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblAvailableTitle.Location = new System.Drawing.Point(30, 30);
            this.lblAvailableTitle.Name = "lblAvailableTitle";
            this.lblAvailableTitle.Size = new System.Drawing.Size(258, 30);
            this.lblAvailableTitle.TabIndex = 0;
            this.lblAvailableTitle.Text = "Số dư khả dụng theo Ví";
            // 
            // pnlHistory
            // 
            this.pnlHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHistory.BackColor = System.Drawing.Color.White;
            this.pnlHistory.Controls.Add(this.lblNoHistory);
            this.pnlHistory.Controls.Add(this.lblHistoryTitle);
            this.pnlHistory.Controls.Add(this.dgvHistory);
            this.pnlHistory.Location = new System.Drawing.Point(410, 800);
            this.pnlHistory.Name = "pnlHistory";
            this.pnlHistory.Padding = new System.Windows.Forms.Padding(30);
            this.pnlHistory.Size = new System.Drawing.Size(1160, 750);
            this.pnlHistory.TabIndex = 6;
            // 
            // lblNoHistory
            // 
            this.lblNoHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoHistory.BackColor = System.Drawing.Color.White;
            this.lblNoHistory.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblNoHistory.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNoHistory.Location = new System.Drawing.Point(30, 90);
            this.lblNoHistory.Name = "lblNoHistory";
            this.lblNoHistory.Size = new System.Drawing.Size(1100, 400);
            this.lblNoHistory.TabIndex = 5;
            this.lblNoHistory.Text = "Chưa có giao dịch nào cho mục tiêu này.";
            this.lblNoHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNoHistory.Visible = false;
            // 
            // lblHistoryTitle
            // 
            this.lblHistoryTitle.AutoSize = true;
            this.lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblHistoryTitle.Location = new System.Drawing.Point(30, 30);
            this.lblHistoryTitle.Name = "lblHistoryTitle";
            this.lblHistoryTitle.Size = new System.Drawing.Size(184, 30);
            this.lblHistoryTitle.TabIndex = 0;
            this.lblHistoryTitle.Text = "Lịch sử giao dịch";
            // 
            // dgvHistory
            // 
            this.dgvHistory.AllowUserToAddRows = false;
            this.dgvHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistory.BackgroundColor = System.Drawing.Color.White;
            this.dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvHistory.ColumnHeadersHeight = 45;
            this.dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgvHistory.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvHistory.Location = new System.Drawing.Point(30, 90);
            this.dgvHistory.MultiSelect = false;
            this.dgvHistory.Name = "dgvHistory";
            this.dgvHistory.ReadOnly = true;
            this.dgvHistory.RowHeadersVisible = false;
            this.dgvHistory.RowHeadersWidth = 51;
            this.dgvHistory.RowTemplate.Height = 50;
            this.dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistory.Size = new System.Drawing.Size(1100, 550);
            this.dgvHistory.TabIndex = 1;
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
            this.lblEmptyMessage.Text = "Bạn chưa có mục tiêu nào.\r\nHãy bấm \"Thêm mục tiêu mới\" để tạo mục tiêu đầu tiên!";
            this.lblEmptyMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Goals
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.Controls.Add(this.pnlHistory);
            this.Controls.Add(this.pnlAvailable);
            this.Controls.Add(this.pnlTarget);
            this.Controls.Add(this.pnlSaved);
            this.Controls.Add(this.pnlGoalHeader);
            this.Controls.Add(this.pnlLeftSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Controls.Add(this.pnlEmptyState);
            this.Name = "UC_Goals";
            this.Size = new System.Drawing.Size(1600, 1600);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeftSidebar.ResumeLayout(false);
            this.pnlGoalHeader.ResumeLayout(false);
            this.pnlGoalHeader.PerformLayout();
            this.pnlSaved.ResumeLayout(false);
            this.pnlSaved.PerformLayout();
            this.pnlPbBackground.ResumeLayout(false);
            this.pnlTarget.ResumeLayout(false);
            this.pnlTarget.PerformLayout();
            this.pnlAvailable.ResumeLayout(false);
            this.pnlAvailable.PerformLayout();
            this.pnlHistory.ResumeLayout(false);
            this.pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistory)).EndInit();
            this.pnlEmptyState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpGoals;
        private System.Windows.Forms.Panel pnlGoalHeader;
        private System.Windows.Forms.Label lblGoalTitle;
        private System.Windows.Forms.Button btnNaptien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlSaved;
        private System.Windows.Forms.Label lblSavedTitle;
        private System.Windows.Forms.Label lblSavedAmount;
        // Custom Progress Bar (2 Panels)
        private System.Windows.Forms.Panel pnlPbBackground;
        private System.Windows.Forms.Panel pnlPbValue;

        private System.Windows.Forms.Panel pnlTarget;
        private System.Windows.Forms.Label lblTargetTitle;
        private System.Windows.Forms.Label lblTargetAmount;
        private System.Windows.Forms.Panel pnlAvailable;
        private System.Windows.Forms.Label lblAvailableTitle;
        private System.Windows.Forms.FlowLayoutPanel flpWalletList;
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel pnlEmptyState;
        private System.Windows.Forms.Label lblEmptyMessage;
        private System.Windows.Forms.Label lblNoHistory;
    }
}