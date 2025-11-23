using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_CategoryAD
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
            lblDate = new Label();
            lblWelcome = new Label();
            lblTitle = new Label();
            pnlTabs = new Panel();
            btnIconsTab = new Button();
            btnColorsTab = new Button();
            pnlIconsList = new Panel();
            flpIcons = new FlowLayoutPanel();
            pnlIconsHeader = new Panel();
            lblIconsTitle = new Label();
            lblIconCount = new Label();
            btnAddIcon = new Button();
            pnlColorsList = new Panel();
            flpColors = new FlowLayoutPanel();
            pnlColorsHeader = new Panel();
            lblColorsTitle = new Label();
            lblColorCount = new Label();
            btnAddColor = new Button();
            pnlHeader.SuspendLayout();
            pnlTabs.SuspendLayout();
            pnlIconsList.SuspendLayout();
            pnlIconsHeader.SuspendLayout();
            pnlColorsList.SuspendLayout();
            pnlColorsHeader.SuspendLayout();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(lblDate);
            pnlHeader.Controls.Add(lblWelcome);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Margin = new Padding(3, 4, 3, 4);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(34, 27, 34, 27);
            pnlHeader.Size = new Size(1371, 133);
            pnlHeader.TabIndex = 0;
            // 
            // lblDate
            // 
            lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblDate.Font = new Font("Segoe UI", 9F);
            lblDate.ForeColor = Color.Gray;
            lblDate.Location = new Point(1029, 40);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(309, 27);
            lblDate.TabIndex = 0;
            lblDate.Text = "📅 Thứ Năm, 20 tháng 11, 2025";
            lblDate.TextAlign = ContentAlignment.TopRight;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.Gray;
            lblWelcome.Location = new Point(34, 73);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(309, 23);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Quản lý danh mục, biểu tượng, và màu";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            lblTitle.Location = new Point(34, 27);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(209, 41);
            lblTitle.TabIndex = 2;
            lblTitle.Text = "⚙ Danh mục";
            // 
            // pnlTabs
            // 
            pnlTabs.BackColor = Color.White;
            pnlTabs.Controls.Add(btnIconsTab);
            pnlTabs.Controls.Add(btnColorsTab);
            pnlTabs.Dock = DockStyle.Top;
            pnlTabs.Location = new Point(0, 133);
            pnlTabs.Margin = new Padding(3, 4, 3, 4);
            pnlTabs.Name = "pnlTabs";
            pnlTabs.Padding = new Padding(34, 0, 34, 0);
            pnlTabs.Size = new Size(1371, 67);
            pnlTabs.TabIndex = 1;
            // 
            // btnIconsTab
            // 
            btnIconsTab.BackColor = Color.FromArgb(240, 248, 255);
            btnIconsTab.Cursor = Cursors.Hand;
            btnIconsTab.FlatAppearance.BorderSize = 0;
            btnIconsTab.FlatStyle = FlatStyle.Flat;
            btnIconsTab.Font = new Font("Segoe UI", 10F);
            btnIconsTab.ForeColor = Color.FromArgb(0, 123, 255);
            btnIconsTab.Location = new Point(34, 13);
            btnIconsTab.Margin = new Padding(3, 4, 3, 4);
            btnIconsTab.Name = "btnIconsTab";
            btnIconsTab.Size = new Size(135, 53);
            btnIconsTab.TabIndex = 0;
            btnIconsTab.Text = "🖼 Biểu tượng";
            btnIconsTab.UseVisualStyleBackColor = false;
            // 
            // btnColorsTab
            // 
            btnColorsTab.BackColor = Color.White;
            btnColorsTab.Cursor = Cursors.Hand;
            btnColorsTab.FlatAppearance.BorderSize = 0;
            btnColorsTab.FlatStyle = FlatStyle.Flat;
            btnColorsTab.Font = new Font("Segoe UI", 10F);
            btnColorsTab.ForeColor = Color.FromArgb(100, 100, 100);
            btnColorsTab.Location = new Point(175, 13);
            btnColorsTab.Margin = new Padding(3, 4, 3, 4);
            btnColorsTab.Name = "btnColorsTab";
            btnColorsTab.Size = new Size(99, 53);
            btnColorsTab.TabIndex = 1;
            btnColorsTab.Text = "🎨 Màu";
            btnColorsTab.UseVisualStyleBackColor = false;
            // 
            // pnlIconsList
            // 
            pnlIconsList.BackColor = Color.White;
            pnlIconsList.Controls.Add(flpIcons);
            pnlIconsList.Controls.Add(pnlIconsHeader);
            pnlIconsList.Dock = DockStyle.Fill;
            pnlIconsList.Location = new Point(0, 200);
            pnlIconsList.Margin = new Padding(3, 4, 3, 4);
            pnlIconsList.Name = "pnlIconsList";
            pnlIconsList.Padding = new Padding(34, 40, 34, 40);
            pnlIconsList.Size = new Size(1371, 867);
            pnlIconsList.TabIndex = 0;
            // 
            // flpIcons
            // 
            flpIcons.AutoScroll = true;
            flpIcons.Dock = DockStyle.Fill;
            flpIcons.Location = new Point(34, 93);
            flpIcons.Margin = new Padding(3, 4, 3, 4);
            flpIcons.Name = "flpIcons";
            flpIcons.Padding = new Padding(11, 13, 11, 13);
            flpIcons.Size = new Size(1303, 734);
            flpIcons.TabIndex = 0;
            // 
            // pnlIconsHeader
            // 
            pnlIconsHeader.Controls.Add(lblIconsTitle);
            pnlIconsHeader.Controls.Add(lblIconCount);
            pnlIconsHeader.Dock = DockStyle.Top;
            pnlIconsHeader.Location = new Point(34, 40);
            pnlIconsHeader.Margin = new Padding(3, 4, 3, 4);
            pnlIconsHeader.Name = "pnlIconsHeader";
            pnlIconsHeader.Size = new Size(1303, 53);
            pnlIconsHeader.TabIndex = 1;
            // 
            // lblIconsTitle
            // 
            lblIconsTitle.AutoSize = true;
            lblIconsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblIconsTitle.Location = new Point(0, 7);
            lblIconsTitle.Name = "lblIconsTitle";
            lblIconsTitle.Size = new Size(265, 32);
            lblIconsTitle.TabIndex = 0;
            lblIconsTitle.Text = "Danh sách biểu tượng";
            // 
            // lblIconCount
            // 
            lblIconCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblIconCount.BackColor = Color.FromArgb(0, 123, 255);
            lblIconCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblIconCount.ForeColor = Color.White;
            lblIconCount.Location = new Point(1143, 7);
            lblIconCount.Name = "lblIconCount";
            lblIconCount.Padding = new Padding(14, 8, 14, 8);
            lblIconCount.Size = new Size(145, 40);
            lblIconCount.TabIndex = 1;
            lblIconCount.Text = "30 biểu tượng";
            lblIconCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddIcon
            // 
            btnAddIcon.Location = new Point(0, 0);
            btnAddIcon.Name = "btnAddIcon";
            btnAddIcon.Size = new Size(75, 23);
            btnAddIcon.TabIndex = 0;
            btnAddIcon.Visible = false;
            // 
            // pnlColorsList
            // 
            pnlColorsList.BackColor = Color.White;
            pnlColorsList.Controls.Add(flpColors);
            pnlColorsList.Controls.Add(pnlColorsHeader);
            pnlColorsList.Dock = DockStyle.Fill;
            pnlColorsList.Location = new Point(0, 200);
            pnlColorsList.Margin = new Padding(3, 4, 3, 4);
            pnlColorsList.Name = "pnlColorsList";
            pnlColorsList.Padding = new Padding(34, 40, 34, 40);
            pnlColorsList.Size = new Size(1371, 867);
            pnlColorsList.TabIndex = 1;
            pnlColorsList.Visible = false;
            // 
            // flpColors
            // 
            flpColors.AutoScroll = true;
            flpColors.Dock = DockStyle.Fill;
            flpColors.Location = new Point(34, 93);
            flpColors.Margin = new Padding(3, 4, 3, 4);
            flpColors.Name = "flpColors";
            flpColors.Padding = new Padding(11, 13, 11, 13);
            flpColors.Size = new Size(1303, 734);
            flpColors.TabIndex = 0;
            // 
            // pnlColorsHeader
            // 
            pnlColorsHeader.Controls.Add(lblColorsTitle);
            pnlColorsHeader.Controls.Add(lblColorCount);
            pnlColorsHeader.Dock = DockStyle.Top;
            pnlColorsHeader.Location = new Point(34, 40);
            pnlColorsHeader.Margin = new Padding(3, 4, 3, 4);
            pnlColorsHeader.Name = "pnlColorsHeader";
            pnlColorsHeader.Size = new Size(1303, 53);
            pnlColorsHeader.TabIndex = 1;
            // 
            // lblColorsTitle
            // 
            lblColorsTitle.AutoSize = true;
            lblColorsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblColorsTitle.Location = new Point(0, 7);
            lblColorsTitle.Name = "lblColorsTitle";
            lblColorsTitle.Size = new Size(188, 32);
            lblColorsTitle.TabIndex = 0;
            lblColorsTitle.Text = "Danh sách màu";
            // 
            // lblColorCount
            // 
            lblColorCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblColorCount.BackColor = Color.FromArgb(0, 123, 255);
            lblColorCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblColorCount.ForeColor = Color.White;
            lblColorCount.Location = new Point(1143, 7);
            lblColorCount.Name = "lblColorCount";
            lblColorCount.Padding = new Padding(14, 8, 14, 8);
            lblColorCount.Size = new Size(114, 40);
            lblColorCount.TabIndex = 1;
            lblColorCount.Text = "20 màu";
            lblColorCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddColor
            // 
            btnAddColor.Location = new Point(0, 0);
            btnAddColor.Name = "btnAddColor";
            btnAddColor.Size = new Size(75, 23);
            btnAddColor.TabIndex = 0;
            btnAddColor.Visible = false;
            // 
            // UC_CategoryAD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 245);
            Controls.Add(pnlIconsList);
            Controls.Add(pnlColorsList);
            Controls.Add(pnlTabs);
            Controls.Add(pnlHeader);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_CategoryAD";
            Size = new Size(1371, 1067);
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            pnlTabs.ResumeLayout(false);
            pnlIconsList.ResumeLayout(false);
            pnlIconsHeader.ResumeLayout(false);
            pnlIconsHeader.PerformLayout();
            pnlColorsList.ResumeLayout(false);
            pnlColorsHeader.ResumeLayout(false);
            pnlColorsHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;
        private Label lblWelcome;
        private Label lblDate;
        private Panel pnlTabs;
        private Button btnIconsTab;
        private Button btnColorsTab;
        private Panel pnlIconsList;
        private Panel pnlIconsHeader;
        private Label lblIconsTitle;
        private Label lblIconCount;
        private Button btnAddIcon;
        private FlowLayoutPanel flpIcons;
        private Panel pnlColorsList;
        private Panel pnlColorsHeader;
        private Label lblColorsTitle;
        private Label lblColorCount;
        private Button btnAddColor;
        private FlowLayoutPanel flpColors;
    }
}