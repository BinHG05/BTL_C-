namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_Budget
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
            // Khởi tạo các panel chính
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblSubtitle = new System.Windows.Forms.Label();
            this.btnAddNewBudget = new System.Windows.Forms.Button();
            this.pnlLeftSidebar = new System.Windows.Forms.Panel();
            this.flpBudgetList = new System.Windows.Forms.FlowLayoutPanel();

            this.pnlAnUong = new System.Windows.Forms.Panel();
            this.lblAnUongIcon = new System.Windows.Forms.Label();
            this.lblAnUongName = new System.Windows.Forms.Label();
            this.lblAnUongAmount = new System.Windows.Forms.Label();

            this.pnlDoXang = new System.Windows.Forms.Panel();
            this.lblDoXangIcon = new System.Windows.Forms.Label();
            this.lblDoXangName = new System.Windows.Forms.Label();
            this.lblDoXangAmount = new System.Windows.Forms.Label();

            // --- Nút này được GIỮ LẠI trong Sidebar ---
            this.btnAddBudgetSidebar = new System.Windows.Forms.Button();

            // Panel nội dung bên phải
            this.pnlMainContent = new System.Windows.Forms.Panel();
            this.pnlBudgetHeader = new System.Windows.Forms.Panel();
            this.lblBudgetName = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.pnlBudgetOverview = new System.Windows.Forms.Panel();
            this.lblDaChiTitle = new System.Windows.Forms.Label();
            this.lblDaChiAmount = new System.Windows.Forms.Label();
            this.lblNganSachTitle = new System.Windows.Forms.Label();
            this.lblNganSachAmount = new System.Windows.Forms.Label();
            this.pbBudgetProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.lblConLaiTitleOverview = new System.Windows.Forms.Label();
            this.lblConLaiAmountOverview = new System.Windows.Forms.Label();
            this.pnlBudgetStats = new System.Windows.Forms.Panel();
            this.lblNgayBatDauTitle = new System.Windows.Forms.Label();
            this.lblNgayBatDauValue = new System.Windows.Forms.Label();
            this.lblNgayKetThucTitle = new System.Windows.Forms.Label();
            this.lblNgayKetThucValue = new System.Windows.Forms.Label();
            this.lblDaChiStatsTitle = new System.Windows.Forms.Label();
            this.lblDaChiStatsValue = new System.Windows.Forms.Label();
            this.lblConLaiStatsTitle = new System.Windows.Forms.Label();
            this.lblConLaiStatsValue = new System.Windows.Forms.Label();
            this.pnlBudgetChart = new System.Windows.Forms.Panel();
            this.lblChartTitle = new System.Windows.Forms.Label();
            this.dtpChartFrom = new System.Windows.Forms.DateTimePicker();
            this.lblDen = new System.Windows.Forms.Label();
            this.dtpChartTo = new System.Windows.Forms.DateTimePicker();
            this.cmbChartType = new System.Windows.Forms.ComboBox();
            this.pnlChartArea = new System.Windows.Forms.Panel();

            // Tạm dừng layout
            this.pnlHeader.SuspendLayout();
            this.pnlLeftSidebar.SuspendLayout();
            this.flpBudgetList.SuspendLayout();
            this.pnlAnUong.SuspendLayout();
            this.pnlDoXang.SuspendLayout();
            this.pnlMainContent.SuspendLayout();
            this.pnlBudgetHeader.SuspendLayout();
            this.pnlBudgetOverview.SuspendLayout();
            this.pnlBudgetStats.SuspendLayout();
            this.pnlBudgetChart.SuspendLayout();
            this.SuspendLayout();

            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.Transparent;
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Controls.Add(this.lblSubtitle);
            this.pnlHeader.Controls.Add(this.btnAddNewBudget);
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
            this.lblTitle.Size = new System.Drawing.Size(184, 60);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "Budget";
            // 
            // lblSubtitle
            // 
            this.lblSubtitle.AutoSize = true;
            this.lblSubtitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblSubtitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSubtitle.Location = new System.Drawing.Point(35, 90);
            this.lblSubtitle.Name = "lblSubtitle";
            this.lblSubtitle.Size = new System.Drawing.Size(263, 25);
            this.lblSubtitle.TabIndex = 1;
            this.lblSubtitle.Text = "Create and track your budgets";
            // 
            // btnAddNewBudget
            // 
            this.btnAddNewBudget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddNewBudget.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(102)))), ((int)(((byte)(241)))));
            this.btnAddNewBudget.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddNewBudget.FlatAppearance.BorderSize = 0;
            this.btnAddNewBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddNewBudget.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnAddNewBudget.ForeColor = System.Drawing.Color.White;
            this.btnAddNewBudget.Location = new System.Drawing.Point(1353, 45);
            this.btnAddNewBudget.Name = "btnAddNewBudget";
            this.btnAddNewBudget.Size = new System.Drawing.Size(212, 50);
            this.btnAddNewBudget.TabIndex = 2;
            this.btnAddNewBudget.Text = "+ Add new budget";
            this.btnAddNewBudget.UseVisualStyleBackColor = false;
            // 
            // pnlLeftSidebar
            // 
            this.pnlLeftSidebar.BackColor = System.Drawing.Color.Transparent;
            this.pnlLeftSidebar.Controls.Add(this.flpBudgetList);
            this.pnlLeftSidebar.Location = new System.Drawing.Point(30, 160);
            this.pnlLeftSidebar.Name = "pnlLeftSidebar";
            this.pnlLeftSidebar.Size = new System.Drawing.Size(350, 700);
            this.pnlLeftSidebar.TabIndex = 1;
            // 
            // flpBudgetList
            // 
            this.flpBudgetList.AutoScroll = true;
            this.flpBudgetList.Controls.Add(this.pnlAnUong);
            this.flpBudgetList.Controls.Add(this.pnlDoXang);
            this.flpBudgetList.Controls.Add(this.btnAddBudgetSidebar);
            this.flpBudgetList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpBudgetList.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpBudgetList.Location = new System.Drawing.Point(0, 0);
            this.flpBudgetList.Name = "flpBudgetList";
            this.flpBudgetList.Size = new System.Drawing.Size(350, 700);
            this.flpBudgetList.TabIndex = 0;
            this.flpBudgetList.WrapContents = false;
            // 
            // pnlAnUong
            // 
            this.pnlAnUong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(56)))), ((int)(((byte)(202)))));
            this.pnlAnUong.Controls.Add(this.lblAnUongIcon);
            this.pnlAnUong.Controls.Add(this.lblAnUongName);
            this.pnlAnUong.Controls.Add(this.lblAnUongAmount);
            this.pnlAnUong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlAnUong.Location = new System.Drawing.Point(3, 3);
            this.pnlAnUong.Name = "pnlAnUong";
            this.pnlAnUong.Padding = new System.Windows.Forms.Padding(20);
            this.pnlAnUong.Size = new System.Drawing.Size(330, 100);
            this.pnlAnUong.TabIndex = 0;
            // 
            // lblAnUongIcon
            // 
            this.lblAnUongIcon.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblAnUongIcon.ForeColor = System.Drawing.Color.White;
            this.lblAnUongIcon.Location = new System.Drawing.Point(20, 25);
            this.lblAnUongIcon.Name = "lblAnUongIcon";
            this.lblAnUongIcon.Size = new System.Drawing.Size(50, 50);
            this.lblAnUongIcon.TabIndex = 0;
            this.lblAnUongIcon.Text = "🍴";
            // 
            // lblAnUongName
            // 
            this.lblAnUongName.AutoSize = true;
            this.lblAnUongName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblAnUongName.ForeColor = System.Drawing.Color.White;
            this.lblAnUongName.Location = new System.Drawing.Point(80, 25);
            this.lblAnUongName.Name = "lblAnUongName";
            this.lblAnUongName.Size = new System.Drawing.Size(103, 30);
            this.lblAnUongName.TabIndex = 1;
            this.lblAnUongName.Text = "Ăn uống";
            // 
            // lblAnUongAmount
            // 
            this.lblAnUongAmount.AutoSize = true;
            this.lblAnUongAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAnUongAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.lblAnUongAmount.Location = new System.Drawing.Point(80, 55);
            this.lblAnUongAmount.Name = "lblAnUongAmount";
            this.lblAnUongAmount.Size = new System.Drawing.Size(109, 23);
            this.lblAnUongAmount.TabIndex = 2;
            this.lblAnUongAmount.Text = "1,000,000đ";
            // 
            // pnlDoXang
            // 
            this.pnlDoXang.BackColor = System.Drawing.Color.White;
            this.pnlDoXang.Controls.Add(this.lblDoXangIcon);
            this.pnlDoXang.Controls.Add(this.lblDoXangName);
            this.pnlDoXang.Controls.Add(this.lblDoXangAmount);
            this.pnlDoXang.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pnlDoXang.Location = new System.Drawing.Point(3, 109);
            this.pnlDoXang.Name = "pnlDoXang";
            this.pnlDoXang.Padding = new System.Windows.Forms.Padding(20);
            this.pnlDoXang.Size = new System.Drawing.Size(330, 100);
            this.pnlDoXang.TabIndex = 1;
            // 
            // lblDoXangIcon
            // 
            this.lblDoXangIcon.Font = new System.Drawing.Font("Segoe UI", 24F);
            this.lblDoXangIcon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDoXangIcon.Location = new System.Drawing.Point(20, 25);
            this.lblDoXangIcon.Name = "lblDoXangIcon";
            this.lblDoXangIcon.Size = new System.Drawing.Size(50, 50);
            this.lblDoXangIcon.TabIndex = 0;
            this.lblDoXangIcon.Text = "⛽";
            // 
            // lblDoXangName
            // 
            this.lblDoXangName.AutoSize = true;
            this.lblDoXangName.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.lblDoXangName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDoXangName.Location = new System.Drawing.Point(80, 25);
            this.lblDoXangName.Name = "lblDoXangName";
            this.lblDoXangName.Size = new System.Drawing.Size(100, 30);
            this.lblDoXangName.TabIndex = 1;
            this.lblDoXangName.Text = "Đổ xăng";
            // 
            // lblDoXangAmount
            // 
            this.lblDoXangAmount.AutoSize = true;
            this.lblDoXangAmount.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDoXangAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDoXangAmount.Location = new System.Drawing.Point(80, 55);
            this.lblDoXangAmount.Name = "lblDoXangAmount";
            this.lblDoXangAmount.Size = new System.Drawing.Size(89, 23);
            this.lblDoXangAmount.TabIndex = 2;
            this.lblDoXangAmount.Text = "200,000đ";
            // 
            // btnAddBudgetSidebar
            // 
            this.btnAddBudgetSidebar.BackColor = System.Drawing.Color.White;
            this.btnAddBudgetSidebar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAddBudgetSidebar.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.btnAddBudgetSidebar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddBudgetSidebar.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnAddBudgetSidebar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.btnAddBudgetSidebar.Location = new System.Drawing.Point(3, 215);
            this.btnAddBudgetSidebar.Name = "btnAddBudgetSidebar";
            this.btnAddBudgetSidebar.Size = new System.Drawing.Size(330, 55);
            this.btnAddBudgetSidebar.TabIndex = 2;
            this.btnAddBudgetSidebar.Text = "⊕  Add new budget";
            this.btnAddBudgetSidebar.UseVisualStyleBackColor = false;
            // 
            // pnlMainContent
            // 
            this.pnlMainContent.AutoScroll = true;
            this.pnlMainContent.BackColor = System.Drawing.Color.Transparent;
            this.pnlMainContent.Controls.Add(this.pnlBudgetHeader);
            this.pnlMainContent.Controls.Add(this.pnlBudgetOverview);
            this.pnlMainContent.Controls.Add(this.pnlBudgetStats);
            this.pnlMainContent.Controls.Add(this.pnlBudgetChart);
            this.pnlMainContent.Location = new System.Drawing.Point(400, 160);
            this.pnlMainContent.Name = "pnlMainContent";
            this.pnlMainContent.Size = new System.Drawing.Size(1180, 720);
            this.pnlMainContent.TabIndex = 2;
            // 
            // pnlBudgetHeader
            // 
            this.pnlBudgetHeader.BackColor = System.Drawing.Color.White;
            this.pnlBudgetHeader.Controls.Add(this.lblBudgetName);
            this.pnlBudgetHeader.Controls.Add(this.btnEdit);
            this.pnlBudgetHeader.Controls.Add(this.btnDelete);
            this.pnlBudgetHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlBudgetHeader.Name = "pnlBudgetHeader";
            this.pnlBudgetHeader.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.pnlBudgetHeader.Size = new System.Drawing.Size(1140, 80);
            this.pnlBudgetHeader.TabIndex = 3;
            // 
            // lblBudgetName
            // 
            this.lblBudgetName.AutoSize = true;
            this.lblBudgetName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblBudgetName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblBudgetName.Location = new System.Drawing.Point(30, 17);
            this.lblBudgetName.Name = "lblBudgetName";
            this.lblBudgetName.Size = new System.Drawing.Size(161, 46);
            this.lblBudgetName.TabIndex = 0;
            this.lblBudgetName.Text = "Ăn uống";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(59)))), ((int)(((byte)(130)))), ((int)(((byte)(246)))));
            this.btnEdit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(890, 18);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 44);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "✏️ Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(239)))), ((int)(((byte)(68)))), ((int)(((byte)(68)))));
            this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(1000, 18);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 44);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "🗑️ Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            // 
            // pnlBudgetOverview
            // 
            this.pnlBudgetOverview.BackColor = System.Drawing.Color.White;
            this.pnlBudgetOverview.Controls.Add(this.lblDaChiTitle);
            this.pnlBudgetOverview.Controls.Add(this.lblDaChiAmount);
            this.pnlBudgetOverview.Controls.Add(this.lblNganSachTitle);
            this.pnlBudgetOverview.Controls.Add(this.lblNganSachAmount);
            this.pnlBudgetOverview.Controls.Add(this.pbBudgetProgress);
            this.pnlBudgetOverview.Controls.Add(this.lblProgressPercent);
            this.pnlBudgetOverview.Controls.Add(this.lblConLaiTitleOverview);
            this.pnlBudgetOverview.Controls.Add(this.lblConLaiAmountOverview);
            this.pnlBudgetOverview.Location = new System.Drawing.Point(0, 95);
            this.pnlBudgetOverview.Name = "pnlBudgetOverview";
            this.pnlBudgetOverview.Padding = new System.Windows.Forms.Padding(30);
            this.pnlBudgetOverview.Size = new System.Drawing.Size(1140, 140);
            this.pnlBudgetOverview.TabIndex = 4;
            // 
            // lblDaChiTitle
            // 
            this.lblDaChiTitle.AutoSize = true;
            this.lblDaChiTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDaChiTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDaChiTitle.Location = new System.Drawing.Point(30, 30);
            this.lblDaChiTitle.Name = "lblDaChiTitle";
            this.lblDaChiTitle.Size = new System.Drawing.Size(66, 25);
            this.lblDaChiTitle.TabIndex = 0;
            this.lblDaChiTitle.Text = "Đã chi";
            // 
            // lblDaChiAmount
            // 
            this.lblDaChiAmount.AutoSize = true;
            this.lblDaChiAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblDaChiAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDaChiAmount.Location = new System.Drawing.Point(30, 60);
            this.lblDaChiAmount.Name = "lblDaChiAmount";
            this.lblDaChiAmount.Size = new System.Drawing.Size(130, 46);
            this.lblDaChiAmount.TabIndex = 1;
            this.lblDaChiAmount.Text = "25,000đ";
            // 
            // lblNganSachTitle
            // 
            this.lblNganSachTitle.AutoSize = true;
            this.lblNganSachTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNganSachTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNganSachTitle.Location = new System.Drawing.Point(300, 30);
            this.lblNganSachTitle.Name = "lblNganSachTitle";
            this.lblNganSachTitle.Size = new System.Drawing.Size(101, 25);
            this.lblNganSachTitle.TabIndex = 2;
            this.lblNganSachTitle.Text = "Ngân sách";
            // 
            // lblNganSachAmount
            // 
            this.lblNganSachAmount.AutoSize = true;
            this.lblNganSachAmount.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblNganSachAmount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNganSachAmount.Location = new System.Drawing.Point(300, 60);
            this.lblNganSachAmount.Name = "lblNganSachAmount";
            this.lblNganSachAmount.Size = new System.Drawing.Size(188, 46);
            this.lblNganSachAmount.TabIndex = 3;
            this.lblNganSachAmount.Text = "1,000,000đ";
            // 
            // pbBudgetProgress
            // 
            this.pbBudgetProgress.Location = new System.Drawing.Point(600, 60);
            this.pbBudgetProgress.Name = "pbBudgetProgress";
            this.pbBudgetProgress.Size = new System.Drawing.Size(250, 20);
            this.pbBudgetProgress.TabIndex = 4;
            this.pbBudgetProgress.Value = 2;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblProgressPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblProgressPercent.Location = new System.Drawing.Point(600, 85);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(35, 23);
            this.lblProgressPercent.TabIndex = 5;
            this.lblProgressPercent.Text = "2%";
            // 
            // lblConLaiTitleOverview
            // 
            // *** ĐÃ SỬA CĂN LỀ ***
            this.lblConLaiTitleOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConLaiTitleOverview.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblConLaiTitleOverview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblConLaiTitleOverview.Location = new System.Drawing.Point(900, 30);
            this.lblConLaiTitleOverview.Name = "lblConLaiTitleOverview";
            this.lblConLaiTitleOverview.Size = new System.Drawing.Size(200, 25); // Sửa Size
            this.lblConLaiTitleOverview.TabIndex = 6;
            this.lblConLaiTitleOverview.Text = "Còn lại";
            this.lblConLaiTitleOverview.TextAlign = System.Drawing.ContentAlignment.TopRight; // Sửa Align
            // 
            // lblConLaiAmountOverview
            // 
            this.lblConLaiAmountOverview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConLaiAmountOverview.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold);
            this.lblConLaiAmountOverview.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblConLaiAmountOverview.Location = new System.Drawing.Point(900, 60);
            this.lblConLaiAmountOverview.Name = "lblConLaiAmountOverview";
            this.lblConLaiAmountOverview.Size = new System.Drawing.Size(200, 46);
            this.lblConLaiAmountOverview.TabIndex = 7;
            this.lblConLaiAmountOverview.Text = "975,000đ";
            this.lblConLaiAmountOverview.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBudgetStats
            // 
            this.pnlBudgetStats.BackColor = System.Drawing.Color.White;
            this.pnlBudgetStats.Controls.Add(this.lblNgayBatDauTitle);
            this.pnlBudgetStats.Controls.Add(this.lblNgayBatDauValue);
            this.pnlBudgetStats.Controls.Add(this.lblNgayKetThucTitle);
            this.pnlBudgetStats.Controls.Add(this.lblNgayKetThucValue);
            this.pnlBudgetStats.Controls.Add(this.lblDaChiStatsTitle);
            this.pnlBudgetStats.Controls.Add(this.lblDaChiStatsValue);
            this.pnlBudgetStats.Controls.Add(this.lblConLaiStatsTitle);
            this.pnlBudgetStats.Controls.Add(this.lblConLaiStatsValue);
            this.pnlBudgetStats.Location = new System.Drawing.Point(0, 250);
            this.pnlBudgetStats.Name = "pnlBudgetStats";
            this.pnlBudgetStats.Padding = new System.Windows.Forms.Padding(30);
            this.pnlBudgetStats.Size = new System.Drawing.Size(1140, 130);
            this.pnlBudgetStats.TabIndex = 5;
            // 
            // lblNgayBatDauTitle
            // 
            this.lblNgayBatDauTitle.AutoSize = true;
            this.lblNgayBatDauTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNgayBatDauTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgayBatDauTitle.Location = new System.Drawing.Point(30, 30);
            this.lblNgayBatDauTitle.Name = "lblNgayBatDauTitle";
            this.lblNgayBatDauTitle.Size = new System.Drawing.Size(123, 25);
            this.lblNgayBatDauTitle.TabIndex = 0;
            this.lblNgayBatDauTitle.Text = "Ngày bắt đầu";
            // 
            // lblNgayBatDauValue
            // 
            this.lblNgayBatDauValue.AutoSize = true;
            this.lblNgayBatDauValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNgayBatDauValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayBatDauValue.Location = new System.Drawing.Point(30, 60);
            this.lblNgayBatDauValue.Name = "lblNgayBatDauValue";
            this.lblNgayBatDauValue.Size = new System.Drawing.Size(143, 32);
            this.lblNgayBatDauValue.TabIndex = 1;
            this.lblNgayBatDauValue.Text = "11/11/2025";
            // 
            // lblNgayKetThucTitle
            // 
            this.lblNgayKetThucTitle.AutoSize = true;
            this.lblNgayKetThucTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblNgayKetThucTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgayKetThucTitle.Location = new System.Drawing.Point(300, 30);
            this.lblNgayKetThucTitle.Name = "lblNgayKetThucTitle";
            this.lblNgayKetThucTitle.Size = new System.Drawing.Size(127, 25);
            this.lblNgayKetThucTitle.TabIndex = 2;
            this.lblNgayKetThucTitle.Text = "Ngày kết thúc";
            // 
            // lblNgayKetThucValue
            // 
            this.lblNgayKetThucValue.AutoSize = true;
            this.lblNgayKetThucValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblNgayKetThucValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblNgayKetThucValue.Location = new System.Drawing.Point(300, 60);
            this.lblNgayKetThucValue.Name = "lblNgayKetThucValue";
            this.lblNgayKetThucValue.Size = new System.Drawing.Size(143, 32);
            this.lblNgayKetThucValue.TabIndex = 3;
            this.lblNgayKetThucValue.Text = "11/12/2025";
            // 
            // lblDaChiStatsTitle
            // 
            this.lblDaChiStatsTitle.AutoSize = true;
            this.lblDaChiStatsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblDaChiStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblDaChiStatsTitle.Location = new System.Drawing.Point(570, 30);
            this.lblDaChiStatsTitle.Name = "lblDaChiStatsTitle";
            this.lblDaChiStatsTitle.Size = new System.Drawing.Size(66, 25);
            this.lblDaChiStatsTitle.TabIndex = 4;
            this.lblDaChiStatsTitle.Text = "Đã chi";
            // 
            // lblDaChiStatsValue
            // 
            this.lblDaChiStatsValue.AutoSize = true;
            this.lblDaChiStatsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblDaChiStatsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblDaChiStatsValue.Location = new System.Drawing.Point(570, 60);
            this.lblDaChiStatsValue.Name = "lblDaChiStatsValue";
            this.lblDaChiStatsValue.Size = new System.Drawing.Size(107, 32);
            this.lblDaChiStatsValue.TabIndex = 5;
            this.lblDaChiStatsValue.Text = "25,000đ";
            // 
            // lblConLaiStatsTitle
            // 
            // *** ĐÃ SỬA CĂN LỀ ***
            this.lblConLaiStatsTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConLaiStatsTitle.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lblConLaiStatsTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblConLaiStatsTitle.Location = new System.Drawing.Point(840, 30);
            this.lblConLaiStatsTitle.Name = "lblConLaiStatsTitle";
            this.lblConLaiStatsTitle.Size = new System.Drawing.Size(260, 25); // Sửa Size
            this.lblConLaiStatsTitle.TabIndex = 6;
            this.lblConLaiStatsTitle.Text = "Còn lại";
            this.lblConLaiStatsTitle.TextAlign = System.Drawing.ContentAlignment.TopRight; // Sửa Align
            // 
            // lblConLaiStatsValue
            // 
            this.lblConLaiStatsValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblConLaiStatsValue.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblConLaiStatsValue.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblConLaiStatsValue.Location = new System.Drawing.Point(840, 60);
            this.lblConLaiStatsValue.Name = "lblConLaiStatsValue";
            this.lblConLaiStatsValue.Size = new System.Drawing.Size(260, 32);
            this.lblConLaiStatsValue.TabIndex = 7;
            this.lblConLaiStatsValue.Text = "975,000đ";
            this.lblConLaiStatsValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // pnlBudgetChart
            // 
            this.pnlBudgetChart.BackColor = System.Drawing.Color.White;
            this.pnlBudgetChart.Controls.Add(this.lblChartTitle);
            this.pnlBudgetChart.Controls.Add(this.cmbChartType);
            this.pnlBudgetChart.Controls.Add(this.dtpChartFrom);
            this.pnlBudgetChart.Controls.Add(this.lblDen);
            this.pnlBudgetChart.Controls.Add(this.dtpChartTo);
            this.pnlBudgetChart.Controls.Add(this.pnlChartArea);
            this.pnlBudgetChart.Location = new System.Drawing.Point(0, 395);
            this.pnlBudgetChart.Name = "pnlBudgetChart";
            this.pnlBudgetChart.Padding = new System.Windows.Forms.Padding(30);
            this.pnlBudgetChart.Size = new System.Drawing.Size(1140, 300);
            this.pnlBudgetChart.TabIndex = 6;
            // 
            // lblChartTitle
            // 
            this.lblChartTitle.AutoSize = true;
            this.lblChartTitle.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblChartTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblChartTitle.Location = new System.Drawing.Point(30, 30);
            this.lblChartTitle.Name = "lblChartTitle";
            this.lblChartTitle.Size = new System.Drawing.Size(263, 37);
            this.lblChartTitle.TabIndex = 0;
            this.lblChartTitle.Text = "Phân Tích Chi Tiêu";
            // 
            // cmbChartType
            // 
            this.cmbChartType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbChartType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbChartType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbChartType.FormattingEnabled = true;
            this.cmbChartType.Items.AddRange(new object[] {
            "Theo Ngày",
            "Theo Tuần",
            "Theo Tháng"});
            this.cmbChartType.Location = new System.Drawing.Point(620, 35);
            this.cmbChartType.Name = "cmbChartType";
            this.cmbChartType.Size = new System.Drawing.Size(121, 31);
            this.cmbChartType.TabIndex = 1;
            // 
            // dtpChartFrom
            // 
            this.dtpChartFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpChartFrom.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpChartFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChartFrom.Location = new System.Drawing.Point(750, 35);
            this.dtpChartFrom.Name = "dtpChartFrom";
            this.dtpChartFrom.Size = new System.Drawing.Size(130, 30);
            this.dtpChartFrom.TabIndex = 2;
            // 
            // lblDen
            // 
            this.lblDen.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDen.AutoSize = true;
            this.lblDen.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDen.Location = new System.Drawing.Point(890, 38);
            this.lblDen.Name = "lblDen";
            this.lblDen.Size = new System.Drawing.Size(39, 23);
            this.lblDen.TabIndex = 3;
            this.lblDen.Text = "đến";
            // 
            // dtpChartTo
            // 
            this.dtpChartTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpChartTo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.dtpChartTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpChartTo.Location = new System.Drawing.Point(940, 35);
            this.dtpChartTo.Name = "dtpChartTo";
            this.dtpChartTo.Size = new System.Drawing.Size(130, 30);
            this.dtpChartTo.TabIndex = 4;
            // 
            // pnlChartArea
            // 
            this.pnlChartArea.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlChartArea.Location = new System.Drawing.Point(30, 80);
            this.pnlChartArea.Name = "pnlChartArea";
            this.pnlChartArea.Size = new System.Drawing.Size(1080, 190);
            this.pnlChartArea.TabIndex = 5;
            // 
            // UC_Budget
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.Controls.Add(this.pnlMainContent);
            this.Controls.Add(this.pnlLeftSidebar);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_Budget";
            this.Size = new System.Drawing.Size(1600, 900);
            this.Load += new System.EventHandler(this.UC_Budget_Load);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlLeftSidebar.ResumeLayout(false);
            this.flpBudgetList.ResumeLayout(false);
            this.pnlAnUong.ResumeLayout(false);
            this.pnlAnUong.PerformLayout();
            this.pnlDoXang.ResumeLayout(false);
            this.pnlDoXang.PerformLayout();
            this.pnlMainContent.ResumeLayout(false);
            this.pnlBudgetHeader.ResumeLayout(false);
            this.pnlBudgetHeader.PerformLayout();
            this.pnlBudgetOverview.ResumeLayout(false);
            this.pnlBudgetOverview.PerformLayout();
            this.pnlBudgetStats.ResumeLayout(false);
            this.pnlBudgetStats.PerformLayout();
            this.pnlBudgetChart.ResumeLayout(false);
            this.pnlBudgetChart.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Panel chính
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private System.Windows.Forms.Button btnAddNewBudget; // *** GIỮ LẠI NÚT NÀY ***
        private System.Windows.Forms.Panel pnlLeftSidebar;
        private System.Windows.Forms.FlowLayoutPanel flpBudgetList;
        private System.Windows.Forms.Panel pnlMainContent;

        // Mockup Sidebar Items
        private System.Windows.Forms.Panel pnlAnUong;
        private System.Windows.Forms.Label lblAnUongIcon;
        private System.Windows.Forms.Label lblAnUongName;
        private System.Windows.Forms.Label lblAnUongAmount;
        private System.Windows.Forms.Panel pnlDoXang;
        private System.Windows.Forms.Label lblDoXangIcon;
        private System.Windows.Forms.Label lblDoXangName;
        private System.Windows.Forms.Label lblDoXangAmount;
        private System.Windows.Forms.Button btnAddBudgetSidebar; // *** GIỮ LẠI NÚT NÀY ***

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
        private System.Windows.Forms.ProgressBar pbBudgetProgress;
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
    }
}