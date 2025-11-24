namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Budget
    {
        private System.ComponentModel.IContainer components = null;


        #region Component Designer generated code

        private void InitializeComponent()
        {
            pnlHeader = new System.Windows.Forms.Panel();
            lblTitle = new System.Windows.Forms.Label();
            lblSubtitle = new System.Windows.Forms.Label();
            pnlLeftSidebar = new System.Windows.Forms.Panel();
            flpBudgetList = new System.Windows.Forms.FlowLayoutPanel();
            btnAddBudgetSidebar = new System.Windows.Forms.Button();
            pnlMainContent = new System.Windows.Forms.Panel();
            pnlBudgetHeader = new System.Windows.Forms.Panel();
            lblBudgetName = new System.Windows.Forms.Label();
            btnEdit = new System.Windows.Forms.Button();
            btnDelete = new System.Windows.Forms.Button();
            pnlBudgetOverview = new System.Windows.Forms.Panel();
            pbBudgetProgress = new ExpenseManager.App.CustomControls.CustomProgressBar();
            lblDaChiTitle = new System.Windows.Forms.Label();
            lblDaChiAmount = new System.Windows.Forms.Label();
            lblNganSachTitle = new System.Windows.Forms.Label();
            lblNganSachAmount = new System.Windows.Forms.Label();
            lblProgressPercent = new System.Windows.Forms.Label();
            lblConLaiTitleOverview = new System.Windows.Forms.Label();
            lblConLaiAmountOverview = new System.Windows.Forms.Label();
            pnlBudgetStats = new System.Windows.Forms.Panel();
            lblNgayBatDauTitle = new System.Windows.Forms.Label();
            lblNgayBatDauValue = new System.Windows.Forms.Label();
            lblNgayKetThucTitle = new System.Windows.Forms.Label();
            lblNgayKetThucValue = new System.Windows.Forms.Label();
            lblDaChiStatsTitle = new System.Windows.Forms.Label();
            lblDaChiStatsValue = new System.Windows.Forms.Label();
            lblConLaiStatsTitle = new System.Windows.Forms.Label();
            lblConLaiStatsValue = new System.Windows.Forms.Label();
            pnlBudgetChart = new System.Windows.Forms.Panel();
            lblChartTitle = new System.Windows.Forms.Label();
            cmbChartType = new System.Windows.Forms.ComboBox();
            dtpChartFrom = new System.Windows.Forms.DateTimePicker();
            lblDen = new System.Windows.Forms.Label();
            dtpChartTo = new System.Windows.Forms.DateTimePicker();
            pnlChartArea = new System.Windows.Forms.Panel();
            pnlHeader.SuspendLayout();
            pnlLeftSidebar.SuspendLayout();
            flpBudgetList.SuspendLayout();
            pnlMainContent.SuspendLayout();
            pnlBudgetHeader.SuspendLayout();
            pnlBudgetOverview.SuspendLayout();
            pnlBudgetStats.SuspendLayout();
            pnlBudgetChart.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = System.Drawing.Color.Transparent;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Controls.Add(lblSubtitle);
            pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            pnlHeader.Location = new System.Drawing.Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new System.Windows.Forms.Padding(35, 25, 35, 25);
            pnlHeader.Size = new System.Drawing.Size(1600, 120);
            pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 26F, System.Drawing.FontStyle.Bold);
            lblTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblTitle.Location = new System.Drawing.Point(35, 25);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new System.Drawing.Size(414, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Ngân sách của bạn";
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new System.Drawing.Point(35, 85);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new System.Drawing.Size(305, 25);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Tạo và theo dõi ngân sách của bạn";
            // 
            // pnlLeftSidebar
            // 
            pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            pnlLeftSidebar.Controls.Add(flpBudgetList);
            pnlLeftSidebar.Location = new System.Drawing.Point(30, 140);
            pnlLeftSidebar.Name = "pnlLeftSidebar";
            pnlLeftSidebar.Size = new System.Drawing.Size(350, 720);
            pnlLeftSidebar.TabIndex = 1;
            // 
            // flpBudgetList
            // 
            flpBudgetList.AutoScroll = true;
            flpBudgetList.Controls.Add(btnAddBudgetSidebar);
            flpBudgetList.Dock = System.Windows.Forms.DockStyle.Fill;
            flpBudgetList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            flpBudgetList.Location = new System.Drawing.Point(0, 0);
            flpBudgetList.Name = "flpBudgetList";
            flpBudgetList.Size = new System.Drawing.Size(350, 720);
            flpBudgetList.TabIndex = 0;
            flpBudgetList.WrapContents = false;
            // 
            // btnAddBudgetSidebar
            // 
            btnAddBudgetSidebar.BackColor = System.Drawing.Color.White;
            btnAddBudgetSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            btnAddBudgetSidebar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(226, 232, 240);
            btnAddBudgetSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnAddBudgetSidebar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            btnAddBudgetSidebar.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            btnAddBudgetSidebar.Location = new System.Drawing.Point(3, 3);
            btnAddBudgetSidebar.Name = "btnAddBudgetSidebar";
            btnAddBudgetSidebar.Size = new System.Drawing.Size(330, 55);
            btnAddBudgetSidebar.TabIndex = 2;
            btnAddBudgetSidebar.Text = "⊕  Thêm ngân sách mới";
            btnAddBudgetSidebar.UseVisualStyleBackColor = false;
            // 
            // pnlMainContent
            // 
            pnlMainContent.AutoScroll = true;
            pnlMainContent.BackColor = System.Drawing.Color.Transparent;
            pnlMainContent.Controls.Add(pnlBudgetHeader);
            pnlMainContent.Controls.Add(pnlBudgetOverview);
            pnlMainContent.Controls.Add(pnlBudgetStats);
            pnlMainContent.Controls.Add(pnlBudgetChart);
            pnlMainContent.Location = new System.Drawing.Point(400, 140);
            pnlMainContent.Name = "pnlMainContent";
            pnlMainContent.Size = new System.Drawing.Size(1180, 740);
            pnlMainContent.TabIndex = 2;
            // 
            // pnlBudgetHeader
            // 
            pnlBudgetHeader.BackColor = System.Drawing.Color.White;
            pnlBudgetHeader.Controls.Add(lblBudgetName);
            pnlBudgetHeader.Controls.Add(btnEdit);
            pnlBudgetHeader.Controls.Add(btnDelete);
            pnlBudgetHeader.Location = new System.Drawing.Point(0, 0);
            pnlBudgetHeader.Name = "pnlBudgetHeader";
            pnlBudgetHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            pnlBudgetHeader.Size = new System.Drawing.Size(1140, 80);
            pnlBudgetHeader.TabIndex = 3;
            // 
            // lblBudgetName
            // 
            lblBudgetName.AutoSize = true;
            lblBudgetName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblBudgetName.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblBudgetName.Location = new System.Drawing.Point(30, 17);
            lblBudgetName.Name = "lblBudgetName";
            lblBudgetName.Size = new System.Drawing.Size(271, 46);
            lblBudgetName.TabIndex = 0;
            lblBudgetName.Text = "Chọn ngân sách";
            // 
            // btnEdit
            // 
            btnEdit.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnEdit.BackColor = System.Drawing.Color.FromArgb(59, 130, 246);
            btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            btnEdit.FlatAppearance.BorderSize = 0;
            btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnEdit.ForeColor = System.Drawing.Color.White;
            btnEdit.Location = new System.Drawing.Point(890, 18);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new System.Drawing.Size(100, 44);
            btnEdit.TabIndex = 1;
            btnEdit.Text = "✏️ Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            btnDelete.BackColor = System.Drawing.Color.FromArgb(239, 68, 68);
            btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            btnDelete.ForeColor = System.Drawing.Color.White;
            btnDelete.Location = new System.Drawing.Point(1000, 18);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new System.Drawing.Size(100, 44);
            btnDelete.TabIndex = 2;
            btnDelete.Text = "🗑️ Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            // 
            // pnlBudgetOverview
            // 
            pnlBudgetOverview.BackColor = System.Drawing.Color.White;
            pnlBudgetOverview.Controls.Add(pbBudgetProgress);
            pnlBudgetOverview.Controls.Add(lblDaChiTitle);
            pnlBudgetOverview.Controls.Add(lblDaChiAmount);
            pnlBudgetOverview.Controls.Add(lblNganSachTitle);
            pnlBudgetOverview.Controls.Add(lblNganSachAmount);
            pnlBudgetOverview.Controls.Add(lblProgressPercent);
            pnlBudgetOverview.Controls.Add(lblConLaiTitleOverview);
            pnlBudgetOverview.Controls.Add(lblConLaiAmountOverview);
            pnlBudgetOverview.Location = new System.Drawing.Point(0, 95);
            pnlBudgetOverview.Name = "pnlBudgetOverview";
            pnlBudgetOverview.Padding = new System.Windows.Forms.Padding(30);
            pnlBudgetOverview.Size = new System.Drawing.Size(1140, 140);
            pnlBudgetOverview.TabIndex = 4;
            // 
            // pbBudgetProgress
            // 
            pbBudgetProgress.DangerThreshold = 90;
            pbBudgetProgress.Font = new System.Drawing.Font("Segoe UI", 9F);
            pbBudgetProgress.Location = new System.Drawing.Point(595, 38);
            pbBudgetProgress.Maximum = 100;
            pbBudgetProgress.Minimum = 0;
            pbBudgetProgress.Name = "pbBudgetProgress";
            pbBudgetProgress.Percentage = 0D;
            pbBudgetProgress.ShowText = false;
            pbBudgetProgress.Size = new System.Drawing.Size(283, 33);
            pbBudgetProgress.TabIndex = 0;
            pbBudgetProgress.UseGradient = false;
            pbBudgetProgress.WarningThreshold = 70;
            // 
            // lblDaChiTitle
            // 
            lblDaChiTitle.AutoSize = true;
            lblDaChiTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDaChiTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDaChiTitle.Location = new System.Drawing.Point(30, 30);
            lblDaChiTitle.Name = "lblDaChiTitle";
            lblDaChiTitle.Size = new System.Drawing.Size(65, 25);
            lblDaChiTitle.TabIndex = 0;
            lblDaChiTitle.Text = "Đã chi";
            // 
            // lblDaChiAmount
            // 
            lblDaChiAmount.AutoSize = true;
            lblDaChiAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblDaChiAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDaChiAmount.Location = new System.Drawing.Point(30, 60);
            lblDaChiAmount.Name = "lblDaChiAmount";
            lblDaChiAmount.Size = new System.Drawing.Size(62, 46);
            lblDaChiAmount.TabIndex = 1;
            lblDaChiAmount.Text = "0đ";
            // 
            // lblNganSachTitle
            // 
            lblNganSachTitle.AutoSize = true;
            lblNganSachTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblNganSachTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblNganSachTitle.Location = new System.Drawing.Point(300, 30);
            lblNganSachTitle.Name = "lblNganSachTitle";
            lblNganSachTitle.Size = new System.Drawing.Size(101, 25);
            lblNganSachTitle.TabIndex = 2;
            lblNganSachTitle.Text = "Ngân sách";
            // 
            // lblNganSachAmount
            // 
            lblNganSachAmount.AutoSize = true;
            lblNganSachAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblNganSachAmount.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblNganSachAmount.Location = new System.Drawing.Point(300, 60);
            lblNganSachAmount.Name = "lblNganSachAmount";
            lblNganSachAmount.Size = new System.Drawing.Size(62, 46);
            lblNganSachAmount.TabIndex = 3;
            lblNganSachAmount.Text = "0đ";
            // 
            // lblProgressPercent
            // 
            lblProgressPercent.AutoSize = true;
            lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            lblProgressPercent.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblProgressPercent.Location = new System.Drawing.Point(600, 85);
            lblProgressPercent.Name = "lblProgressPercent";
            lblProgressPercent.Size = new System.Drawing.Size(35, 23);
            lblProgressPercent.TabIndex = 5;
            lblProgressPercent.Text = "0%";
            // 
            // lblConLaiTitleOverview
            // 
            lblConLaiTitleOverview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblConLaiTitleOverview.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblConLaiTitleOverview.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblConLaiTitleOverview.Location = new System.Drawing.Point(900, 30);
            lblConLaiTitleOverview.Name = "lblConLaiTitleOverview";
            lblConLaiTitleOverview.Size = new System.Drawing.Size(200, 25);
            lblConLaiTitleOverview.TabIndex = 6;
            lblConLaiTitleOverview.Text = "Còn lại";
            lblConLaiTitleOverview.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConLaiAmountOverview
            // 
            lblConLaiAmountOverview.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblConLaiAmountOverview.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            lblConLaiAmountOverview.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblConLaiAmountOverview.Location = new System.Drawing.Point(900, 60);
            lblConLaiAmountOverview.Name = "lblConLaiAmountOverview";
            lblConLaiAmountOverview.Size = new System.Drawing.Size(200, 46);
            lblConLaiAmountOverview.TabIndex = 7;
            lblConLaiAmountOverview.Text = "0đ";
            lblConLaiAmountOverview.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBudgetStats
            // 
            pnlBudgetStats.BackColor = System.Drawing.Color.White;
            pnlBudgetStats.Controls.Add(lblNgayBatDauTitle);
            pnlBudgetStats.Controls.Add(lblNgayBatDauValue);
            pnlBudgetStats.Controls.Add(lblNgayKetThucTitle);
            pnlBudgetStats.Controls.Add(lblNgayKetThucValue);
            pnlBudgetStats.Controls.Add(lblDaChiStatsTitle);
            pnlBudgetStats.Controls.Add(lblDaChiStatsValue);
            pnlBudgetStats.Controls.Add(lblConLaiStatsTitle);
            pnlBudgetStats.Controls.Add(lblConLaiStatsValue);
            pnlBudgetStats.Location = new System.Drawing.Point(0, 250);
            pnlBudgetStats.Name = "pnlBudgetStats";
            pnlBudgetStats.Padding = new System.Windows.Forms.Padding(30);
            pnlBudgetStats.Size = new System.Drawing.Size(1140, 130);
            pnlBudgetStats.TabIndex = 5;
            // 
            // lblNgayBatDauTitle
            // 
            lblNgayBatDauTitle.AutoSize = true;
            lblNgayBatDauTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblNgayBatDauTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblNgayBatDauTitle.Location = new System.Drawing.Point(30, 30);
            lblNgayBatDauTitle.Name = "lblNgayBatDauTitle";
            lblNgayBatDauTitle.Size = new System.Drawing.Size(125, 25);
            lblNgayBatDauTitle.TabIndex = 0;
            lblNgayBatDauTitle.Text = "Ngày bắt đầu";
            // 
            // lblNgayBatDauValue
            // 
            lblNgayBatDauValue.AutoSize = true;
            lblNgayBatDauValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblNgayBatDauValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblNgayBatDauValue.Location = new System.Drawing.Point(30, 60);
            lblNgayBatDauValue.Name = "lblNgayBatDauValue";
            lblNgayBatDauValue.Size = new System.Drawing.Size(178, 32);
            lblNgayBatDauValue.TabIndex = 1;
            lblNgayBatDauValue.Text = "MM/DD/YYYY";
            // 
            // lblNgayKetThucTitle
            // 
            lblNgayKetThucTitle.AutoSize = true;
            lblNgayKetThucTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblNgayKetThucTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblNgayKetThucTitle.Location = new System.Drawing.Point(300, 30);
            lblNgayKetThucTitle.Name = "lblNgayKetThucTitle";
            lblNgayKetThucTitle.Size = new System.Drawing.Size(128, 25);
            lblNgayKetThucTitle.TabIndex = 2;
            lblNgayKetThucTitle.Text = "Ngày kết thúc";
            // 
            // lblNgayKetThucValue
            // 
            lblNgayKetThucValue.AutoSize = true;
            lblNgayKetThucValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblNgayKetThucValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblNgayKetThucValue.Location = new System.Drawing.Point(300, 60);
            lblNgayKetThucValue.Name = "lblNgayKetThucValue";
            lblNgayKetThucValue.Size = new System.Drawing.Size(178, 32);
            lblNgayKetThucValue.TabIndex = 3;
            lblNgayKetThucValue.Text = "MM/DD/YYYY";
            // 
            // lblDaChiStatsTitle
            // 
            lblDaChiStatsTitle.AutoSize = true;
            lblDaChiStatsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblDaChiStatsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblDaChiStatsTitle.Location = new System.Drawing.Point(570, 30);
            lblDaChiStatsTitle.Name = "lblDaChiStatsTitle";
            lblDaChiStatsTitle.Size = new System.Drawing.Size(65, 25);
            lblDaChiStatsTitle.TabIndex = 4;
            lblDaChiStatsTitle.Text = "Đã chi";
            // 
            // lblDaChiStatsValue
            // 
            lblDaChiStatsValue.AutoSize = true;
            lblDaChiStatsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblDaChiStatsValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblDaChiStatsValue.Location = new System.Drawing.Point(570, 60);
            lblDaChiStatsValue.Name = "lblDaChiStatsValue";
            lblDaChiStatsValue.Size = new System.Drawing.Size(43, 32);
            lblDaChiStatsValue.TabIndex = 5;
            lblDaChiStatsValue.Text = "0đ";
            // 
            // lblConLaiStatsTitle
            // 
            lblConLaiStatsTitle.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblConLaiStatsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            lblConLaiStatsTitle.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            lblConLaiStatsTitle.Location = new System.Drawing.Point(840, 30);
            lblConLaiStatsTitle.Name = "lblConLaiStatsTitle";
            lblConLaiStatsTitle.Size = new System.Drawing.Size(260, 25);
            lblConLaiStatsTitle.TabIndex = 6;
            lblConLaiStatsTitle.Text = "Còn lại";
            lblConLaiStatsTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblConLaiStatsValue
            // 
            lblConLaiStatsValue.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblConLaiStatsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            lblConLaiStatsValue.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblConLaiStatsValue.Location = new System.Drawing.Point(840, 60);
            lblConLaiStatsValue.Name = "lblConLaiStatsValue";
            lblConLaiStatsValue.Size = new System.Drawing.Size(260, 32);
            lblConLaiStatsValue.TabIndex = 7;
            lblConLaiStatsValue.Text = "0đ";
            lblConLaiStatsValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBudgetChart
            // 
            pnlBudgetChart.BackColor = System.Drawing.Color.White;
            pnlBudgetChart.Controls.Add(lblChartTitle);
            pnlBudgetChart.Controls.Add(cmbChartType);
            pnlBudgetChart.Controls.Add(dtpChartFrom);
            pnlBudgetChart.Controls.Add(lblDen);
            pnlBudgetChart.Controls.Add(dtpChartTo);
            pnlBudgetChart.Controls.Add(pnlChartArea);
            pnlBudgetChart.Location = new System.Drawing.Point(0, 395);
            pnlBudgetChart.Name = "pnlBudgetChart";
            pnlBudgetChart.Padding = new System.Windows.Forms.Padding(30);
            pnlBudgetChart.Size = new System.Drawing.Size(1140, 340);
            pnlBudgetChart.TabIndex = 6;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(30, 41, 59);
            lblChartTitle.Location = new System.Drawing.Point(30, 30);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new System.Drawing.Size(251, 37);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Phân Tích Chi Tiêu";
            // 
            // cmbChartType
            // 
            cmbChartType.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            cmbChartType.Font = new System.Drawing.Font("Segoe UI", 10F);
            cmbChartType.FormattingEnabled = true;
            cmbChartType.Items.AddRange(new object[] { "Theo Ngày", "Theo Tuần", "Theo Tháng" });
            cmbChartType.Location = new System.Drawing.Point(620, 35);
            cmbChartType.Name = "cmbChartType";
            cmbChartType.Size = new System.Drawing.Size(121, 31);
            cmbChartType.TabIndex = 1;
            // 
            // dtpChartFrom
            // 
            dtpChartFrom.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtpChartFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpChartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpChartFrom.Location = new System.Drawing.Point(750, 35);
            dtpChartFrom.Name = "dtpChartFrom";
            dtpChartFrom.Size = new System.Drawing.Size(130, 30);
            dtpChartFrom.TabIndex = 2;
            // 
            // lblDen
            // 
            lblDen.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            lblDen.AutoSize = true;
            lblDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            lblDen.Location = new System.Drawing.Point(890, 38);
            lblDen.Name = "lblDen";
            lblDen.Size = new System.Drawing.Size(39, 23);
            lblDen.TabIndex = 3;
            lblDen.Text = "đến";
            // 
            // dtpChartTo
            // 
            dtpChartTo.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            dtpChartTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            dtpChartTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            dtpChartTo.Location = new System.Drawing.Point(940, 35);
            dtpChartTo.Name = "dtpChartTo";
            dtpChartTo.Size = new System.Drawing.Size(130, 30);
            dtpChartTo.TabIndex = 4;
            // 
            // pnlChartArea
            // 
            pnlChartArea.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            pnlChartArea.Location = new System.Drawing.Point(30, 80);
            pnlChartArea.Name = "pnlChartArea";
            pnlChartArea.Size = new System.Drawing.Size(1080, 230);
            pnlChartArea.TabIndex = 5;
            // 
            // UC_Budget
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = System.Drawing.Color.FromArgb(238, 242, 247);
            Controls.Add(pnlMainContent);
            Controls.Add(pnlLeftSidebar);
            Controls.Add(pnlHeader);
            Name = "UC_Budget";
            Size = new System.Drawing.Size(1600, 900);
            Load += UC_Budget_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlLeftSidebar.ResumeLayout(false);
            flpBudgetList.ResumeLayout(false);
            pnlMainContent.ResumeLayout(false);
            pnlBudgetHeader.ResumeLayout(false);
            pnlBudgetHeader.PerformLayout();
            pnlBudgetOverview.ResumeLayout(false);
            pnlBudgetOverview.PerformLayout();
            pnlBudgetStats.ResumeLayout(false);
            pnlBudgetStats.PerformLayout();
            pnlBudgetChart.ResumeLayout(false);
            pnlBudgetChart.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        // Panel chính
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpBudgetList;
        private System.Windows.Forms.Panel pnlMainContent;
        private System.Windows.Forms.Button btnAddBudgetSidebar;

        // Panel Nội dung
        private System.Windows.Forms.Panel pnlBudgetHeader;
        private System.Windows.Forms.Label lblBudgetName;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;

        private System.Windows.Forms.Panel pnlBudgetOverview;
        private System.Windows.Forms.Label lblDaChiTitle;
        private System.Windows.Forms.Label lblDaChiAmount;
        private System.Windows.Forms.Label lblNganSachTitle;
        private System.Windows.Forms.Label lblNganSachAmount;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label lblConLaiTitleOverview;
        private System.Windows.Forms.Label lblConLaiAmountOverview;

        private System.Windows.Forms.Panel pnlBudgetStats;
        private System.Windows.Forms.Label lblNgayBatDauTitle;
        private System.Windows.Forms.Label lblNgayBatDauValue;
        private System.Windows.Forms.Label lblNgayKetThucTitle;
        private System.Windows.Forms.Label lblNgayKetThucValue;
        private System.Windows.Forms.Label lblDaChiStatsTitle;
        private System.Windows.Forms.Label lblDaChiStatsValue;
        private System.Windows.Forms.Label lblConLaiStatsTitle;
        private System.Windows.Forms.Label lblConLaiStatsValue;

        private System.Windows.Forms.Panel pnlBudgetChart;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.ComboBox cmbChartType;
        private System.Windows.Forms.DateTimePicker dtpChartFrom;
        private System.Windows.Forms.Label lblDen;
        private System.Windows.Forms.DateTimePicker dtpChartTo;
        private System.Windows.Forms.Panel pnlChartArea;
        private CustomControls.CustomProgressBar pbBudgetProgress;
    }
}