using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_TicketAD
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            headerPanel = new Panel();
            lblDate = new Label();
            iconPictureBox1 = new IconPictureBox();
            lblSubtitle = new Label();
            lblTitle = new Label();
            statsPanel = new Panel();
            cardResolved = new Panel();
            lblResolvedCount = new Label();
            lblResolved = new Label();
            iconResolved = new IconPictureBox();
            cardPending = new Panel();
            lblPendingCount = new Label();
            lblPending = new Label();
            iconPending = new IconPictureBox();
            cardOpen = new Panel();
            lblOpenCount = new Label();
            lblOpen = new Label();
            iconOpen = new IconPictureBox();
            cardTotal = new Panel();
            lblTotalCount = new Label();
            lblTotal = new Label();
            iconTotal = new IconPictureBox();
            contentPanel = new Panel();
            dgvTickets = new DataGridView();
            colID = new DataGridViewTextBoxColumn();
            colUser = new DataGridViewTextBoxColumn();
            colEmail = new DataGridViewTextBoxColumn();
            colType = new DataGridViewTextBoxColumn();
            colStatus = new DataGridViewTextBoxColumn();
            colCreated = new DataGridViewTextBoxColumn();
            colNote = new DataGridViewTextBoxColumn();
            colView = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            toolbarPanel = new Panel();
            cboItemsPerPage = new ComboBox();
            lblItemsPerPage = new Label();
            tableHeaderPanel = new Panel();
            iconList = new IconPictureBox();
            lblTableTitle = new Label();
            paginationPanel = new Panel();
            btnNext = new Button();
            lblCurrentPage = new Label();
            btnPrevious = new Button();
            lblPaginationInfo = new Label();
            headerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            statsPanel.SuspendLayout();
            cardResolved.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconResolved).BeginInit();
            cardPending.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPending).BeginInit();
            cardOpen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconOpen).BeginInit();
            cardTotal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconTotal).BeginInit();
            contentPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvTickets).BeginInit();
            toolbarPanel.SuspendLayout();
            tableHeaderPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconList).BeginInit();
            paginationPanel.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(lblDate);
            headerPanel.Controls.Add(iconPictureBox1);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(0, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(34, 33, 34, 20);
            headerPanel.Size = new Size(1371, 133);
            headerPanel.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Font = new Font("Segoe UI", 9.5F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(1086, 40);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(251, 27);
            lblDate.TabIndex = 3;
            lblDate.Text = "📅 Chủ Nhật, 16 tháng 11, 2025";
            lblDate.TextAlign = ContentAlignment.TopRight;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.IconChar = IconChar.LifeRing;
            iconPictureBox1.IconColor = Color.White;
            iconPictureBox1.IconFont = IconFont.Auto;
            iconPictureBox1.IconSize = 41;
            iconPictureBox1.Location = new Point(34, 37);
            iconPictureBox1.Margin = new Padding(3, 4, 3, 4);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(41, 48);
            iconPictureBox1.TabIndex = 2;
            iconPictureBox1.TabStop = false;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(82, 69);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(242, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Manage user support requests";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(75, 29);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(271, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Support Tickets";
            // 
            // statsPanel
            // 
            statsPanel.BackColor = Color.FromArgb(245, 245, 245);
            statsPanel.Controls.Add(cardResolved);
            statsPanel.Controls.Add(cardPending);
            statsPanel.Controls.Add(cardOpen);
            statsPanel.Controls.Add(cardTotal);
            statsPanel.Dock = DockStyle.Top;
            statsPanel.Location = new Point(0, 133);
            statsPanel.Margin = new Padding(3, 4, 3, 4);
            statsPanel.Name = "statsPanel";
            statsPanel.Padding = new Padding(34, 27, 34, 27);
            statsPanel.Size = new Size(1371, 187);
            statsPanel.TabIndex = 1;
            // 
            // cardResolved
            // 
            cardResolved.BackColor = Color.White;
            cardResolved.BorderStyle = BorderStyle.FixedSingle;
            cardResolved.Controls.Add(lblResolvedCount);
            cardResolved.Controls.Add(lblResolved);
            cardResolved.Controls.Add(iconResolved);
            cardResolved.Location = new Point(1063, 27);
            cardResolved.Margin = new Padding(3, 4, 3, 4);
            cardResolved.Name = "cardResolved";
            cardResolved.Size = new Size(274, 133);
            cardResolved.TabIndex = 3;
            // 
            // lblResolvedCount
            // 
            lblResolvedCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblResolvedCount.ForeColor = Color.FromArgb(33, 37, 41);
            lblResolvedCount.Location = new Point(103, 20);
            lblResolvedCount.Name = "lblResolvedCount";
            lblResolvedCount.Size = new Size(154, 53);
            lblResolvedCount.TabIndex = 2;
            lblResolvedCount.Text = "2";
            lblResolvedCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblResolved
            // 
            lblResolved.AutoSize = true;
            lblResolved.Font = new Font("Segoe UI", 10F);
            lblResolved.ForeColor = Color.Gray;
            lblResolved.Location = new Point(103, 80);
            lblResolved.Name = "lblResolved";
            lblResolved.Size = new Size(77, 23);
            lblResolved.TabIndex = 1;
            lblResolved.Text = "Resolved";
            // 
            // iconResolved
            // 
            iconResolved.BackColor = Color.FromArgb(200, 230, 201);
            iconResolved.ForeColor = Color.FromArgb(27, 94, 32);
            iconResolved.IconChar = IconChar.CheckCircle;
            iconResolved.IconColor = Color.FromArgb(27, 94, 32);
            iconResolved.IconFont = IconFont.Auto;
            iconResolved.IconSize = 67;
            iconResolved.Location = new Point(17, 33);
            iconResolved.Margin = new Padding(3, 4, 3, 4);
            iconResolved.Name = "iconResolved";
            iconResolved.Size = new Size(69, 67);
            iconResolved.TabIndex = 0;
            iconResolved.TabStop = false;
            // 
            // cardPending
            // 
            cardPending.BackColor = Color.White;
            cardPending.BorderStyle = BorderStyle.FixedSingle;
            cardPending.Controls.Add(lblPendingCount);
            cardPending.Controls.Add(lblPending);
            cardPending.Controls.Add(iconPending);
            cardPending.Location = new Point(720, 27);
            cardPending.Margin = new Padding(3, 4, 3, 4);
            cardPending.Name = "cardPending";
            cardPending.Size = new Size(274, 133);
            cardPending.TabIndex = 2;
            // 
            // lblPendingCount
            // 
            lblPendingCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblPendingCount.ForeColor = Color.FromArgb(33, 37, 41);
            lblPendingCount.Location = new Point(103, 20);
            lblPendingCount.Name = "lblPendingCount";
            lblPendingCount.Size = new Size(154, 53);
            lblPendingCount.TabIndex = 2;
            lblPendingCount.Text = "1";
            lblPendingCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblPending
            // 
            lblPending.AutoSize = true;
            lblPending.Font = new Font("Segoe UI", 10F);
            lblPending.ForeColor = Color.Gray;
            lblPending.Location = new Point(103, 80);
            lblPending.Name = "lblPending";
            lblPending.Size = new Size(72, 23);
            lblPending.TabIndex = 1;
            lblPending.Text = "Pending";
            // 
            // iconPending
            // 
            iconPending.BackColor = Color.FromArgb(255, 243, 205);
            iconPending.ForeColor = Color.FromArgb(230, 126, 34);
            iconPending.IconChar = IconChar.Hourglass;
            iconPending.IconColor = Color.FromArgb(230, 126, 34);
            iconPending.IconFont = IconFont.Auto;
            iconPending.IconSize = 67;
            iconPending.Location = new Point(17, 33);
            iconPending.Margin = new Padding(3, 4, 3, 4);
            iconPending.Name = "iconPending";
            iconPending.Size = new Size(69, 67);
            iconPending.TabIndex = 0;
            iconPending.TabStop = false;
            // 
            // cardOpen
            // 
            cardOpen.BackColor = Color.White;
            cardOpen.BorderStyle = BorderStyle.FixedSingle;
            cardOpen.Controls.Add(lblOpenCount);
            cardOpen.Controls.Add(lblOpen);
            cardOpen.Controls.Add(iconOpen);
            cardOpen.Location = new Point(377, 27);
            cardOpen.Margin = new Padding(3, 4, 3, 4);
            cardOpen.Name = "cardOpen";
            cardOpen.Size = new Size(274, 133);
            cardOpen.TabIndex = 1;
            // 
            // lblOpenCount
            // 
            lblOpenCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblOpenCount.ForeColor = Color.FromArgb(33, 37, 41);
            lblOpenCount.Location = new Point(103, 20);
            lblOpenCount.Name = "lblOpenCount";
            lblOpenCount.Size = new Size(154, 53);
            lblOpenCount.TabIndex = 2;
            lblOpenCount.Text = "3";
            lblOpenCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblOpen
            // 
            lblOpen.AutoSize = true;
            lblOpen.Font = new Font("Segoe UI", 10F);
            lblOpen.ForeColor = Color.Gray;
            lblOpen.Location = new Point(103, 80);
            lblOpen.Name = "lblOpen";
            lblOpen.Size = new Size(52, 23);
            lblOpen.TabIndex = 1;
            lblOpen.Text = "Open";
            // 
            // iconOpen
            // 
            iconOpen.BackColor = Color.FromArgb(207, 244, 252);
            iconOpen.ForeColor = Color.FromArgb(1, 87, 155);
            iconOpen.IconChar = IconChar.Envelope;
            iconOpen.IconColor = Color.FromArgb(1, 87, 155);
            iconOpen.IconFont = IconFont.Auto;
            iconOpen.IconSize = 67;
            iconOpen.Location = new Point(17, 33);
            iconOpen.Margin = new Padding(3, 4, 3, 4);
            iconOpen.Name = "iconOpen";
            iconOpen.Size = new Size(69, 67);
            iconOpen.TabIndex = 0;
            iconOpen.TabStop = false;
            // 
            // cardTotal
            // 
            cardTotal.BackColor = Color.White;
            cardTotal.BorderStyle = BorderStyle.FixedSingle;
            cardTotal.Controls.Add(lblTotalCount);
            cardTotal.Controls.Add(lblTotal);
            cardTotal.Controls.Add(iconTotal);
            cardTotal.Location = new Point(34, 27);
            cardTotal.Margin = new Padding(3, 4, 3, 4);
            cardTotal.Name = "cardTotal";
            cardTotal.Size = new Size(274, 133);
            cardTotal.TabIndex = 0;
            // 
            // lblTotalCount
            // 
            lblTotalCount.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            lblTotalCount.ForeColor = Color.FromArgb(33, 37, 41);
            lblTotalCount.Location = new Point(103, 20);
            lblTotalCount.Name = "lblTotalCount";
            lblTotalCount.Size = new Size(154, 53);
            lblTotalCount.TabIndex = 2;
            lblTotalCount.Text = "6";
            lblTotalCount.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTotal
            // 
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Segoe UI", 10F);
            lblTotal.ForeColor = Color.Gray;
            lblTotal.Location = new Point(103, 80);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(102, 23);
            lblTotal.TabIndex = 1;
            lblTotal.Text = "Total Tickets";
            // 
            // iconTotal
            // 
            iconTotal.BackColor = Color.FromArgb(224, 224, 224);
            iconTotal.ForeColor = Color.FromArgb(97, 97, 97);
            iconTotal.IconChar = IconChar.Inbox;
            iconTotal.IconColor = Color.FromArgb(97, 97, 97);
            iconTotal.IconFont = IconFont.Auto;
            iconTotal.IconSize = 67;
            iconTotal.Location = new Point(17, 33);
            iconTotal.Margin = new Padding(3, 4, 3, 4);
            iconTotal.Name = "iconTotal";
            iconTotal.Size = new Size(69, 67);
            iconTotal.TabIndex = 0;
            iconTotal.TabStop = false;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Controls.Add(dgvTickets);
            contentPanel.Controls.Add(toolbarPanel);
            contentPanel.Controls.Add(tableHeaderPanel);
            contentPanel.Controls.Add(paginationPanel);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(0, 320);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Padding = new Padding(34, 27, 34, 27);
            contentPanel.Size = new Size(1371, 747);
            contentPanel.TabIndex = 2;
            // 
            // dgvTickets
            // 
            dgvTickets.AllowUserToAddRows = false;
            dgvTickets.AllowUserToDeleteRows = false;
            dgvTickets.AllowUserToResizeRows = false;
            dgvTickets.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvTickets.BackgroundColor = Color.White;
            dgvTickets.BorderStyle = BorderStyle.None;
            dgvTickets.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvTickets.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle1.Padding = new Padding(10, 8, 10, 8);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(248, 249, 250);
            dataGridViewCellStyle1.SelectionForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.True;
            dgvTickets.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            dgvTickets.ColumnHeadersHeight = 45;
            dgvTickets.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgvTickets.Columns.AddRange(new DataGridViewColumn[] { colID, colUser, colEmail, colType, colStatus, colCreated, colNote, colView, colDelete });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.White;
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.Padding = new Padding(10, 5, 10, 5);
            dataGridViewCellStyle2.SelectionBackColor = Color.FromArgb(240, 244, 248);
            dataGridViewCellStyle2.SelectionForeColor = Color.FromArgb(73, 80, 87);
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            dgvTickets.DefaultCellStyle = dataGridViewCellStyle2;
            dgvTickets.Dock = DockStyle.Fill;
            dgvTickets.EnableHeadersVisualStyles = false;
            dgvTickets.GridColor = Color.FromArgb(233, 236, 239);
            dgvTickets.Location = new Point(34, 147);
            dgvTickets.Margin = new Padding(3, 4, 3, 4);
            dgvTickets.MultiSelect = false;
            dgvTickets.Name = "dgvTickets";
            dgvTickets.ReadOnly = true;
            dgvTickets.RowHeadersVisible = false;
            dgvTickets.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Padding = new Padding(0, 5, 0, 5);
            dgvTickets.RowsDefaultCellStyle = dataGridViewCellStyle3;
            dgvTickets.RowTemplate.Height = 50;
            dgvTickets.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvTickets.Size = new Size(1303, 506);
            dgvTickets.TabIndex = 3;
            dgvTickets.CellContentClick += DgvTickets_CellContentClick;
            // 
            // colID
            // 
            colID.FillWeight = 60F;
            colID.HeaderText = "ID";
            colID.MinimumWidth = 6;
            colID.Name = "colID";
            colID.ReadOnly = true;
            // 
            // colUser
            // 
            colUser.FillWeight = 120F;
            colUser.HeaderText = "User";
            colUser.MinimumWidth = 6;
            colUser.Name = "colUser";
            colUser.ReadOnly = true;
            // 
            // colEmail
            // 
            colEmail.FillWeight = 150F;
            colEmail.HeaderText = "Email";
            colEmail.MinimumWidth = 6;
            colEmail.Name = "colEmail";
            colEmail.ReadOnly = true;
            // 
            // colType
            // 
            colType.FillWeight = 90F;
            colType.HeaderText = "Type";
            colType.MinimumWidth = 6;
            colType.Name = "colType";
            colType.ReadOnly = true;
            // 
            // colStatus
            // 
            colStatus.FillWeight = 80F;
            colStatus.HeaderText = "Status";
            colStatus.MinimumWidth = 6;
            colStatus.Name = "colStatus";
            colStatus.ReadOnly = true;
            // 
            // colCreated
            // 
            colCreated.FillWeight = 110F;
            colCreated.HeaderText = "Created";
            colCreated.MinimumWidth = 6;
            colCreated.Name = "colCreated";
            colCreated.ReadOnly = true;
            // 
            // colNote
            // 
            colNote.FillWeight = 80F;
            colNote.HeaderText = "Note";
            colNote.MinimumWidth = 6;
            colNote.Name = "colNote";
            colNote.ReadOnly = true;
            // 
            // colView
            // 
            colView.FillWeight = 70F;
            colView.HeaderText = "";
            colView.MinimumWidth = 6;
            colView.Name = "colView";
            colView.ReadOnly = true;
            colView.Text = "👁 View";
            colView.UseColumnTextForButtonValue = true;
            // 
            // colDelete
            // 
            colDelete.FillWeight = 70F;
            colDelete.HeaderText = "";
            colDelete.MinimumWidth = 6;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "🗑 Delete";
            colDelete.UseColumnTextForButtonValue = true;
            // 
            // toolbarPanel
            // 
            toolbarPanel.BackColor = Color.White;
            toolbarPanel.Controls.Add(cboItemsPerPage);
            toolbarPanel.Controls.Add(lblItemsPerPage);
            toolbarPanel.Dock = DockStyle.Top;
            toolbarPanel.Location = new Point(34, 80);
            toolbarPanel.Margin = new Padding(3, 4, 3, 4);
            toolbarPanel.Name = "toolbarPanel";
            toolbarPanel.Size = new Size(1303, 67);
            toolbarPanel.TabIndex = 2;
            // 
            // cboItemsPerPage
            // 
            cboItemsPerPage.DropDownStyle = ComboBoxStyle.DropDownList;
            cboItemsPerPage.Font = new Font("Segoe UI", 10F);
            cboItemsPerPage.FormattingEnabled = true;
            cboItemsPerPage.Items.AddRange(new object[] { "10", "25", "50", "100" });
            cboItemsPerPage.Location = new Point(91, 15);
            cboItemsPerPage.Margin = new Padding(3, 4, 3, 4);
            cboItemsPerPage.Name = "cboItemsPerPage";
            cboItemsPerPage.Size = new Size(91, 31);
            cboItemsPerPage.TabIndex = 1;
            cboItemsPerPage.SelectedIndexChanged += CboItemsPerPage_SelectedIndexChanged;
            // 
            // lblItemsPerPage
            // 
            lblItemsPerPage.AutoSize = true;
            lblItemsPerPage.Font = new Font("Segoe UI", 10F);
            lblItemsPerPage.Location = new Point(6, 19);
            lblItemsPerPage.Name = "lblItemsPerPage";
            lblItemsPerPage.Size = new Size(70, 23);
            lblItemsPerPage.TabIndex = 0;
            lblItemsPerPage.Text = "Hiển thị";
            // 
            // tableHeaderPanel
            // 
            tableHeaderPanel.BackColor = Color.White;
            tableHeaderPanel.Controls.Add(iconList);
            tableHeaderPanel.Controls.Add(lblTableTitle);
            tableHeaderPanel.Dock = DockStyle.Top;
            tableHeaderPanel.Location = new Point(34, 27);
            tableHeaderPanel.Margin = new Padding(3, 4, 3, 4);
            tableHeaderPanel.Name = "tableHeaderPanel";
            tableHeaderPanel.Size = new Size(1303, 53);
            tableHeaderPanel.TabIndex = 1;
            // 
            // iconList
            // 
            iconList.BackColor = Color.White;
            iconList.ForeColor = Color.FromArgb(33, 37, 41);
            iconList.IconChar = IconChar.ListSquares;
            iconList.IconColor = Color.FromArgb(33, 37, 41);
            iconList.IconFont = IconFont.Auto;
            iconList.IconSize = 25;
            iconList.Location = new Point(6, 12);
            iconList.Margin = new Padding(3, 4, 3, 4);
            iconList.Name = "iconList";
            iconList.Size = new Size(25, 29);
            iconList.TabIndex = 1;
            iconList.TabStop = false;
            // 
            // lblTableTitle
            // 
            lblTableTitle.AutoSize = true;
            lblTableTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTableTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTableTitle.Location = new Point(37, 12);
            lblTableTitle.Name = "lblTableTitle";
            lblTableTitle.Size = new Size(193, 28);
            lblTableTitle.TabIndex = 0;
            lblTableTitle.Text = "All Support Tickets";
            // 
            // paginationPanel
            // 
            paginationPanel.BackColor = Color.White;
            paginationPanel.Controls.Add(btnNext);
            paginationPanel.Controls.Add(lblCurrentPage);
            paginationPanel.Controls.Add(btnPrevious);
            paginationPanel.Controls.Add(lblPaginationInfo);
            paginationPanel.Dock = DockStyle.Bottom;
            paginationPanel.Location = new Point(34, 653);
            paginationPanel.Margin = new Padding(3, 4, 3, 4);
            paginationPanel.Name = "paginationPanel";
            paginationPanel.Size = new Size(1303, 67);
            paginationPanel.TabIndex = 0;
            // 
            // btnNext
            // 
            btnNext.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnNext.BackColor = Color.FromArgb(13, 110, 253);
            btnNext.FlatAppearance.BorderSize = 0;
            btnNext.FlatStyle = FlatStyle.Flat;
            btnNext.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnNext.ForeColor = Color.White;
            btnNext.Location = new Point(1223, 16);
            btnNext.Margin = new Padding(3, 4, 3, 4);
            btnNext.Name = "btnNext";
            btnNext.Size = new Size(80, 40);
            btnNext.TabIndex = 3;
            btnNext.Text = "Sau";
            btnNext.UseVisualStyleBackColor = false;
            btnNext.Click += BtnNext_Click;
            // 
            // lblCurrentPage
            // 
            lblCurrentPage.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblCurrentPage.BackColor = Color.FromArgb(13, 110, 253);
            lblCurrentPage.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblCurrentPage.ForeColor = Color.White;
            lblCurrentPage.Location = new Point(1154, 16);
            lblCurrentPage.Name = "lblCurrentPage";
            lblCurrentPage.Size = new Size(57, 40);
            lblCurrentPage.TabIndex = 2;
            lblCurrentPage.Text = "1";
            lblCurrentPage.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnPrevious
            // 
            btnPrevious.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnPrevious.BackColor = Color.FromArgb(248, 249, 250);
            btnPrevious.FlatAppearance.BorderSize = 0;
            btnPrevious.FlatStyle = FlatStyle.Flat;
            btnPrevious.Font = new Font("Segoe UI", 9F);
            btnPrevious.ForeColor = Color.FromArgb(73, 80, 87);
            btnPrevious.Location = new Point(1063, 16);
            btnPrevious.Margin = new Padding(3, 4, 3, 4);
            btnPrevious.Name = "btnPrevious";
            btnPrevious.Size = new Size(80, 40);
            btnPrevious.TabIndex = 1;
            btnPrevious.Text = "Trước";
            btnPrevious.UseVisualStyleBackColor = false;
            btnPrevious.Click += BtnPrevious_Click;
            // 
            // lblPaginationInfo
            // 
            lblPaginationInfo.AutoSize = true;
            lblPaginationInfo.Font = new Font("Segoe UI", 9.5F);
            lblPaginationInfo.ForeColor = Color.FromArgb(108, 117, 125);
            lblPaginationInfo.Location = new Point(6, 23);
            lblPaginationInfo.Name = "lblPaginationInfo";
            lblPaginationInfo.Size = new Size(279, 21);
            lblPaginationInfo.TabIndex = 0;
            lblPaginationInfo.Text = "Hiển thị 1 đến 6 trong tổng số 6 tickets";
            // 
            // UC_TicketAD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            Controls.Add(contentPanel);
            Controls.Add(statsPanel);
            Controls.Add(headerPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_TicketAD";
            Size = new Size(1371, 1067);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            statsPanel.ResumeLayout(false);
            cardResolved.ResumeLayout(false);
            cardResolved.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconResolved).EndInit();
            cardPending.ResumeLayout(false);
            cardPending.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPending).EndInit();
            cardOpen.ResumeLayout(false);
            cardOpen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconOpen).EndInit();
            cardTotal.ResumeLayout(false);
            cardTotal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconTotal).EndInit();
            contentPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvTickets).EndInit();
            toolbarPanel.ResumeLayout(false);
            toolbarPanel.PerformLayout();
            tableHeaderPanel.ResumeLayout(false);
            tableHeaderPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconList).EndInit();
            paginationPanel.ResumeLayout(false);
            paginationPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Panel statsPanel;
        private System.Windows.Forms.Panel cardTotal;
        private FontAwesome.Sharp.IconPictureBox iconTotal;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblTotalCount;
        private System.Windows.Forms.Panel cardOpen;
        private System.Windows.Forms.Label lblOpenCount;
        private System.Windows.Forms.Label lblOpen;
        private FontAwesome.Sharp.IconPictureBox iconOpen;
        private System.Windows.Forms.Panel cardPending;
        private System.Windows.Forms.Label lblPendingCount;
        private System.Windows.Forms.Label lblPending;
        private FontAwesome.Sharp.IconPictureBox iconPending;
        private System.Windows.Forms.Panel cardResolved;
        private System.Windows.Forms.Label lblResolvedCount;
        private System.Windows.Forms.Label lblResolved;
        private FontAwesome.Sharp.IconPictureBox iconResolved;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Panel paginationPanel;
        private System.Windows.Forms.Label lblPaginationInfo;
        private System.Windows.Forms.Button btnPrevious;
        private System.Windows.Forms.Label lblCurrentPage;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Panel tableHeaderPanel;
        private System.Windows.Forms.Label lblTableTitle;
        private FontAwesome.Sharp.IconPictureBox iconList;
        private System.Windows.Forms.Panel toolbarPanel;
        private System.Windows.Forms.ComboBox cboItemsPerPage;
        private System.Windows.Forms.Label lblItemsPerPage;
        private System.Windows.Forms.DataGridView dgvTickets;
        private System.Windows.Forms.DataGridViewTextBoxColumn colID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn colType;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn colCreated;
        private System.Windows.Forms.DataGridViewTextBoxColumn colNote;
        private System.Windows.Forms.DataGridViewButtonColumn colView;
        private System.Windows.Forms.DataGridViewButtonColumn colDelete;
    }
}