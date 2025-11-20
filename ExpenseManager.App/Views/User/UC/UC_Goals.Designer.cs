namespace ExpenseManager.App.Views.User
{
    partial class UC_Goals
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            pnlLeftSidebar = new System.Windows.Forms.Panel();
            flpGoals = new System.Windows.Forms.FlowLayoutPanel();
            btnAddGoal = new System.Windows.Forms.Button();
            pnlGoalHeader = new System.Windows.Forms.Panel();
            lblGoalTitle = new System.Windows.Forms.Label();
            btnNaptien = new System.Windows.Forms.Button();
            btnRuttien = new System.Windows.Forms.Button();
            btnXoa = new System.Windows.Forms.Button();
            pnlSaved = new System.Windows.Forms.Panel();
            pbSaved = new System.Windows.Forms.ProgressBar();
            lblSavedTitle = new System.Windows.Forms.Label();
            lblSavedAmount = new System.Windows.Forms.Label();
            pnlTarget = new System.Windows.Forms.Panel();
            lblTargetTitle = new System.Windows.Forms.Label();
            lblTargetAmount = new System.Windows.Forms.Label();
            pnlAvailable = new System.Windows.Forms.Panel();
            flpWalletList = new System.Windows.Forms.FlowLayoutPanel();
            lblAvailableTitle = new System.Windows.Forms.Label();
            pnlHistory = new System.Windows.Forms.Panel();
            lblNoHistory = new System.Windows.Forms.Label();
            lblHistoryTitle = new System.Windows.Forms.Label();
            dgvHistory = new System.Windows.Forms.DataGridView();
            pnlEmptyState = new System.Windows.Forms.Panel();
            lblEmptyMessage = new System.Windows.Forms.Label();
            pnlHeader.SuspendLayout();
            pnlLeftSidebar.SuspendLayout();
            pnlGoalHeader.SuspendLayout();
            pnlSaved.SuspendLayout();
            pnlTarget.SuspendLayout();
            pnlAvailable.SuspendLayout();
            pnlHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).BeginInit();
            pnlEmptyState.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new System.Windows.Forms.Padding(44, 31, 44, 31);
            pnlHeader.Size = new System.Drawing.Size(2000, 175);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTitle.Location = new System.Drawing.Point(44, 31);
            lblTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(254, 70);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Mục Tiêu";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new System.Drawing.Point(44, 112);
            lblSubtitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(384, 30);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Quản lý các kế hoạch tài chính của bạn";
            // 
            // pnlLeftSidebar
            // 
            pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            pnlLeftSidebar.Controls.Add(flpGoals);
            pnlLeftSidebar.Location = new System.Drawing.Point(38, 175);
            pnlLeftSidebar.Margin = new System.Windows.Forms.Padding(4);
            pnlLeftSidebar.Name = "pnlLeftSidebar";
            pnlLeftSidebar.Size = new System.Drawing.Size(447, 813);
            pnlLeftSidebar.TabIndex = 1;
            // 
            // flpGoals
            // 
            flpGoals.AutoScroll = true;
            flpGoals.Dock = System.Windows.Forms.DockStyle.Fill;
            flpGoals.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpGoals.Location = new System.Drawing.Point(0, 0);
            flpGoals.Margin = new System.Windows.Forms.Padding(4);
            flpGoals.Name = "flpGoals";
            flpGoals.Padding = new System.Windows.Forms.Padding(0, 0, 0, 25);
            flpGoals.Size = new System.Drawing.Size(447, 813);
            flpGoals.TabIndex = 3;
            flpGoals.WrapContents = false;
            flpGoals.Paint += flpGoals_Paint;
            // 
            // btnAddGoal
            // 
            btnAddGoal.Location = new System.Drawing.Point(0, 0);
            btnAddGoal.Name = "btnAddGoal";
            btnAddGoal.Size = new System.Drawing.Size(75, 23);
            btnAddGoal.TabIndex = 0;
            // 
            // pnlGoalHeader
            // 
            pnlGoalHeader.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlGoalHeader.BackColor = System.Drawing.Color.White;
            pnlGoalHeader.Controls.Add(lblGoalTitle);
            pnlGoalHeader.Controls.Add(btnNaptien);
            pnlGoalHeader.Controls.Add(btnRuttien);
            pnlGoalHeader.Controls.Add(btnXoa);
            pnlGoalHeader.Location = new System.Drawing.Point(512, 200);
            pnlGoalHeader.Margin = new System.Windows.Forms.Padding(4);
            pnlGoalHeader.Name = "pnlGoalHeader";
            pnlGoalHeader.Padding = new System.Windows.Forms.Padding(38, 25, 38, 25);
            pnlGoalHeader.Size = new System.Drawing.Size(1450, 100);
            pnlGoalHeader.TabIndex = 2;
            // 
            // lblGoalTitle
            // 
            lblGoalTitle.AutoSize = true;
            lblGoalTitle.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblGoalTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblGoalTitle.Location = new System.Drawing.Point(38, 21);
            lblGoalTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblGoalTitle.Name = "lblGoalTitle";
            lblGoalTitle.Size = new System.Drawing.Size(383, 54);
            lblGoalTitle.TabIndex = 0;
            lblGoalTitle.Text = "Chọn một mục tiêu";
            // 
            // btnNaptien
            // 
            btnNaptien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnNaptien.BackColor = System.Drawing.Color.FromArgb(16, 185, 129);
            btnNaptien.Cursor = System.Windows.Forms.Cursors.Hand;
            btnNaptien.FlatAppearance.BorderSize = 0;
            btnNaptien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNaptien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnNaptien.ForeColor = System.Drawing.Color.White;
            btnNaptien.Location = new System.Drawing.Point(875, 22);
            btnNaptien.Margin = new System.Windows.Forms.Padding(4);
            btnNaptien.Name = "btnNaptien";
            btnNaptien.Size = new System.Drawing.Size(125, 55);
            btnNaptien.TabIndex = 1;
            btnNaptien.Text = "💰 Nạp";
            btnNaptien.UseVisualStyleBackColor = false;
            // 
            // btnRuttien
            // 
            btnRuttien.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnRuttien.BackColor = System.Drawing.Color.FromArgb(245, 158, 11);
            btnRuttien.Cursor = System.Windows.Forms.Cursors.Hand;
            btnRuttien.FlatAppearance.BorderSize = 0;
            btnRuttien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnRuttien.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnRuttien.ForeColor = System.Drawing.Color.White;
            btnRuttien.Location = new System.Drawing.Point(1012, 22);
            btnRuttien.Margin = new System.Windows.Forms.Padding(4);
            btnRuttien.Name = "btnRuttien";
            btnRuttien.Size = new System.Drawing.Size(125, 55);
            btnRuttien.TabIndex = 3;
            btnRuttien.Text = "💸 Rút";
            btnRuttien.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnXoa.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            btnXoa.FlatAppearance.BorderSize = 0;
            btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnXoa.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnXoa.ForeColor = System.Drawing.Color.White;
            btnXoa.Location = new System.Drawing.Point(1288, 22);
            btnXoa.Margin = new System.Windows.Forms.Padding(4);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new System.Drawing.Size(125, 55);
            btnXoa.TabIndex = 2;
            btnXoa.Text = "🗑️ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // pnlSaved
            // 
            pnlSaved.BackColor = System.Drawing.Color.White;
            pnlSaved.Controls.Add(pbSaved);
            pnlSaved.Controls.Add(lblSavedTitle);
            pnlSaved.Controls.Add(lblSavedAmount);
            pnlSaved.Location = new System.Drawing.Point(512, 325);
            pnlSaved.Margin = new System.Windows.Forms.Padding(4);
            pnlSaved.Name = "pnlSaved";
            pnlSaved.Padding = new System.Windows.Forms.Padding(38);
            pnlSaved.Size = new System.Drawing.Size(712, 212);
            pnlSaved.TabIndex = 3;
            // 
            // pbSaved
            // 
            pbSaved.Location = new System.Drawing.Point(38, 150);
            pbSaved.Margin = new System.Windows.Forms.Padding(4);
            pbSaved.Name = "pbSaved";
            pbSaved.Size = new System.Drawing.Size(638, 19);
            pbSaved.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            pbSaved.TabIndex = 2;
            // 
            // lblSavedTitle
            // 
            lblSavedTitle.AutoSize = true;
            lblSavedTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSavedTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSavedTitle.Location = new System.Drawing.Point(38, 25);
            lblSavedTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSavedTitle.Name = "lblSavedTitle";
            lblSavedTitle.Size = new System.Drawing.Size(129, 30);
            lblSavedTitle.TabIndex = 0;
            lblSavedTitle.Text = "Đã tiết kiệm";
            // 
            // lblSavedAmount
            // 
            lblSavedAmount.AutoSize = true;
            lblSavedAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblSavedAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblSavedAmount.Location = new System.Drawing.Point(31, 62);
            lblSavedAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblSavedAmount.Name = "lblSavedAmount";
            lblSavedAmount.Size = new System.Drawing.Size(99, 65);
            lblSavedAmount.TabIndex = 1;
            lblSavedAmount.Text = "0 đ";
            // 
            // pnlTarget
            // 
            pnlTarget.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlTarget.BackColor = System.Drawing.Color.White;
            pnlTarget.Controls.Add(lblTargetTitle);
            pnlTarget.Controls.Add(lblTargetAmount);
            pnlTarget.Location = new System.Drawing.Point(1250, 325);
            pnlTarget.Margin = new System.Windows.Forms.Padding(4);
            pnlTarget.Name = "pnlTarget";
            pnlTarget.Padding = new System.Windows.Forms.Padding(38);
            pnlTarget.Size = new System.Drawing.Size(712, 212);
            pnlTarget.TabIndex = 4;
            pnlTarget.Paint += pnlTarget_Paint;
            // 
            // lblTargetTitle
            // 
            lblTargetTitle.AutoSize = true;
            lblTargetTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblTargetTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblTargetTitle.Location = new System.Drawing.Point(38, 25);
            lblTargetTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTargetTitle.Name = "lblTargetTitle";
            lblTargetTitle.Size = new System.Drawing.Size(97, 30);
            lblTargetTitle.TabIndex = 0;
            lblTargetTitle.Text = "Mục tiêu";
            // 
            // lblTargetAmount
            // 
            lblTargetAmount.AutoSize = true;
            lblTargetAmount.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            lblTargetAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTargetAmount.Location = new System.Drawing.Point(31, 62);
            lblTargetAmount.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblTargetAmount.Name = "lblTargetAmount";
            lblTargetAmount.Size = new System.Drawing.Size(99, 65);
            lblTargetAmount.TabIndex = 1;
            lblTargetAmount.Text = "0 đ";
            // 
            // pnlAvailable
            // 
            pnlAvailable.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlAvailable.BackColor = System.Drawing.Color.White;
            pnlAvailable.Controls.Add(flpWalletList);
            pnlAvailable.Controls.Add(lblAvailableTitle);
            pnlAvailable.Location = new System.Drawing.Point(512, 562);
            pnlAvailable.Margin = new System.Windows.Forms.Padding(4);
            pnlAvailable.Name = "pnlAvailable";
            pnlAvailable.Size = new System.Drawing.Size(1451, 426);
            pnlAvailable.TabIndex = 5;
            // 
            // flpWalletList
            // 
            flpWalletList.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            flpWalletList.AutoScroll = true;
            flpWalletList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpWalletList.Location = new System.Drawing.Point(31, 75);
            flpWalletList.Margin = new System.Windows.Forms.Padding(4);
            flpWalletList.Name = "flpWalletList";
            flpWalletList.Size = new System.Drawing.Size(1382, 326);
            flpWalletList.TabIndex = 1;
            flpWalletList.WrapContents = false;
            // 
            // lblAvailableTitle
            // 
            lblAvailableTitle.AutoSize = true;
            lblAvailableTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblAvailableTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblAvailableTitle.Location = new System.Drawing.Point(38, 25);
            lblAvailableTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblAvailableTitle.Name = "lblAvailableTitle";
            lblAvailableTitle.Size = new System.Drawing.Size(329, 38);
            lblAvailableTitle.TabIndex = 0;
            lblAvailableTitle.Text = "Số dư khả dụng theo Ví";
            // 
            // pnlHistory
            // 
            pnlHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlHistory.BackColor = System.Drawing.Color.White;
            pnlHistory.Controls.Add(lblNoHistory);
            pnlHistory.Controls.Add(lblHistoryTitle);
            pnlHistory.Controls.Add(dgvHistory);
            pnlHistory.Location = new System.Drawing.Point(512, 1018);
            pnlHistory.Margin = new System.Windows.Forms.Padding(4);
            pnlHistory.Name = "pnlHistory";
            pnlHistory.Padding = new System.Windows.Forms.Padding(38);
            pnlHistory.Size = new System.Drawing.Size(1450, 532);
            pnlHistory.TabIndex = 6;
            // 
            // lblNoHistory
            // 
            lblNoHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lblNoHistory.BackColor = System.Drawing.Color.White;
            lblNoHistory.Font = new System.Drawing.Font("Segoe UI", 12F);
            lblNoHistory.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblNoHistory.Location = new System.Drawing.Point(42, 70);
            lblNoHistory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblNoHistory.Name = "lblNoHistory";
            lblNoHistory.Size = new System.Drawing.Size(1375, 482);
            lblNoHistory.TabIndex = 5;
            lblNoHistory.Text = "Chưa có giao dịch nào cho mục tiêu này.";
            lblNoHistory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblNoHistory.Visible = false;
            // 
            // lblHistoryTitle
            // 
            lblHistoryTitle.AutoSize = true;
            lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblHistoryTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblHistoryTitle.Location = new System.Drawing.Point(38, 25);
            lblHistoryTitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblHistoryTitle.Name = "lblHistoryTitle";
            lblHistoryTitle.Size = new System.Drawing.Size(236, 38);
            lblHistoryTitle.TabIndex = 0;
            lblHistoryTitle.Text = "Lịch sử giao dịch";
            // 
            // dgvHistory
            // 
            dgvHistory.AllowUserToAddRows = false;
            dgvHistory.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            dgvHistory.BackgroundColor = System.Drawing.Color.White;
            dgvHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dgvHistory.ColumnHeadersHeight = 45;
            dgvHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvHistory.GridColor = System.Drawing.Color.FromArgb(226, 232, 240);
            dgvHistory.Location = new System.Drawing.Point(30, 70);
            dgvHistory.Margin = new System.Windows.Forms.Padding(4);
            dgvHistory.MultiSelect = false;
            dgvHistory.Name = "dgvHistory";
            dgvHistory.ReadOnly = true;
            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowHeadersWidth = 51;
            dgvHistory.RowTemplate.Height = 50;
            dgvHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            dgvHistory.Size = new System.Drawing.Size(1050, 582);
            dgvHistory.TabIndex = 1;
            // 
            // pnlEmptyState
            // 
            pnlEmptyState.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlEmptyState.BackColor = System.Drawing.Color.White;
            pnlEmptyState.Controls.Add(lblEmptyMessage);
            pnlEmptyState.Location = new System.Drawing.Point(512, 200);
            pnlEmptyState.Margin = new System.Windows.Forms.Padding(4);
            pnlEmptyState.Name = "pnlEmptyState";
            pnlEmptyState.Size = new System.Drawing.Size(1450, 1400);
            pnlEmptyState.TabIndex = 7;
            pnlEmptyState.Visible = false;
            pnlEmptyState.Paint += pnlEmptyState_Paint;
            // 
            // lblEmptyMessage
            // 
            lblEmptyMessage.Anchor = System.Windows.Forms.AnchorStyles.None;
            lblEmptyMessage.Font = new System.Drawing.Font("Segoe UI", 14F);
            lblEmptyMessage.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblEmptyMessage.Location = new System.Drawing.Point(350, 575);
            lblEmptyMessage.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblEmptyMessage.Name = "lblEmptyMessage";
            lblEmptyMessage.Size = new System.Drawing.Size(750, 100);
            lblEmptyMessage.TabIndex = 0;
            lblEmptyMessage.Text = "Bạn chưa có mục tiêu nào.\r\nHãy bấm \"Thêm mục tiêu\" để tạo mục tiêu đầu tiên!";
            lblEmptyMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UC_Goals
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(248, 250, 252);
            Controls.Add(pnlHistory);
            Controls.Add(pnlAvailable);
            Controls.Add(pnlTarget);
            Controls.Add(pnlSaved);
            Controls.Add(pnlGoalHeader);
            Controls.Add(pnlLeftSidebar);
            Controls.Add(pnlHeader);
            Controls.Add(pnlEmptyState);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "UC_Goals";
            Size = new System.Drawing.Size(2000, 2000);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftSidebar.ResumeLayout(false);
            pnlGoalHeader.ResumeLayout(false);
            pnlGoalHeader.PerformLayout();
            pnlSaved.ResumeLayout(false);
            pnlSaved.PerformLayout();
            pnlTarget.ResumeLayout(false);
            pnlTarget.PerformLayout();
            pnlAvailable.ResumeLayout(false);
            pnlAvailable.PerformLayout();
            pnlHistory.ResumeLayout(false);
            pnlHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvHistory).EndInit();
            pnlEmptyState.ResumeLayout(false);
            ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpGoals;
        private System.Windows.Forms.Button btnAddGoal;
        private System.Windows.Forms.Panel pnlGoalHeader;
        private System.Windows.Forms.Label lblGoalTitle;
        private System.Windows.Forms.Button btnNaptien;
        private System.Windows.Forms.Button btnRuttien;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Panel pnlSaved;
        private System.Windows.Forms.Label lblSavedTitle;
        private System.Windows.Forms.Label lblSavedAmount;
        private System.Windows.Forms.ProgressBar pbSaved; // Progress bar Đã tiết kiệm
        private System.Windows.Forms.Panel pnlTarget;
        private System.Windows.Forms.Label lblTargetTitle;
        private System.Windows.Forms.Label lblTargetAmount;
        private System.Windows.Forms.Panel pnlAvailable;
        private System.Windows.Forms.Label lblAvailableTitle;
        private System.Windows.Forms.FlowLayoutPanel flpWalletList; // List chứa các ví động
        private System.Windows.Forms.Panel pnlHistory;
        private System.Windows.Forms.Label lblHistoryTitle;
        private System.Windows.Forms.DataGridView dgvHistory;
        private System.Windows.Forms.Panel pnlEmptyState;
        private System.Windows.Forms.Label lblEmptyMessage;
        private System.Windows.Forms.Label lblNoHistory;
    }
}