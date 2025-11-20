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
            this.pnlHeader = new Panel();
            this.lblWelcome = new Label();
            this.lblDate = new Label();
            this.lblTitle = new Label();
            this.pnlTabs = new Panel();
            this.btnIconsTab = new Button();
            this.btnColorsTab = new Button();
            this.pnlIconsList = new Panel();
            this.pnlIconsHeader = new Panel();
            this.lblIconsTitle = new Label();
            this.lblIconCount = new Label();
            this.btnAddIcon = new Button();
            this.flpIcons = new FlowLayoutPanel();
            this.pnlColorsList = new Panel();
            this.pnlColorsHeader = new Panel();
            this.lblColorsTitle = new Label();
            this.lblColorCount = new Label();
            this.btnAddColor = new Button();
            this.flpColors = new FlowLayoutPanel();
            this.pnlHeader.SuspendLayout();
            this.pnlTabs.SuspendLayout();
            this.pnlIconsList.SuspendLayout();
            this.pnlIconsHeader.SuspendLayout();
            this.pnlColorsList.SuspendLayout();
            this.pnlColorsHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = Color.White;
            this.pnlHeader.Controls.Add(this.lblDate);
            this.pnlHeader.Controls.Add(this.lblWelcome);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = DockStyle.Top;
            this.pnlHeader.Location = new Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Padding = new Padding(30, 20, 30, 20);
            this.pnlHeader.Size = new Size(1200, 100);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(33, 37, 41);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new Size(180, 32);
            this.lblTitle.Text = "⚙ Category";
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Font = new Font("Segoe UI", 10F);
            this.lblWelcome.ForeColor = Color.Gray;
            this.lblWelcome.Location = new Point(30, 55);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new Size(200, 19);
            this.lblWelcome.Text = "Manage  categories, icons, and colors.";
            // 
            // lblDate
            // 
            this.lblDate.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblDate.Font = new Font("Segoe UI", 9F);
            this.lblDate.ForeColor = Color.Gray;
            this.lblDate.Location = new Point(900, 30);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new Size(270, 20);
            this.lblDate.Text = "📅 Thứ Năm, 20 tháng 11, 2025";
            this.lblDate.TextAlign = ContentAlignment.TopRight;
            // 
            // pnlTabs
            // 
            this.pnlTabs.BackColor = Color.White;
            this.pnlTabs.Controls.Add(this.btnIconsTab);
            this.pnlTabs.Controls.Add(this.btnColorsTab);
            this.pnlTabs.Dock = DockStyle.Top;
            this.pnlTabs.Location = new Point(0, 100);
            this.pnlTabs.Name = "pnlTabs";
            this.pnlTabs.Padding = new Padding(30, 0, 30, 0);
            this.pnlTabs.Size = new Size(1200, 50);
            this.pnlTabs.TabIndex = 1;
            // 
            // btnIconsTab
            // 
            this.btnIconsTab.FlatStyle = FlatStyle.Flat;
            this.btnIconsTab.FlatAppearance.BorderSize = 0;
            this.btnIconsTab.Font = new Font("Segoe UI", 10F);
            this.btnIconsTab.Location = new Point(30, 10);
            this.btnIconsTab.Name = "btnIconsTab";
            this.btnIconsTab.Size = new Size(100, 40);
            this.btnIconsTab.Text = "🖼 Icons";
            this.btnIconsTab.BackColor = Color.FromArgb(240, 248, 255);
            this.btnIconsTab.ForeColor = Color.FromArgb(0, 123, 255);
            this.btnIconsTab.Cursor = Cursors.Hand;
            // 
            // btnColorsTab
            // 
            this.btnColorsTab.FlatStyle = FlatStyle.Flat;
            this.btnColorsTab.FlatAppearance.BorderSize = 0;
            this.btnColorsTab.Font = new Font("Segoe UI", 10F);
            this.btnColorsTab.Location = new Point(140, 10);
            this.btnColorsTab.Name = "btnColorsTab";
            this.btnColorsTab.Size = new Size(100, 40);
            this.btnColorsTab.Text = "🎨 Colors";
            this.btnColorsTab.BackColor = Color.White;
            this.btnColorsTab.ForeColor = Color.FromArgb(100, 100, 100);
            this.btnColorsTab.Cursor = Cursors.Hand;
            // 
            // pnlIconsList
            // 
            this.pnlIconsList.BackColor = Color.White;
            this.pnlIconsList.Controls.Add(this.flpIcons);
            this.pnlIconsList.Controls.Add(this.pnlIconsHeader);
            this.pnlIconsList.Dock = DockStyle.Fill;
            this.pnlIconsList.Location = new Point(0, 150);
            this.pnlIconsList.Name = "pnlIconsList";
            this.pnlIconsList.Padding = new Padding(30);
            this.pnlIconsList.Size = new Size(1200, 650);
            // 
            // pnlIconsHeader
            // 
            this.pnlIconsHeader.Controls.Add(this.lblIconsTitle);
            this.pnlIconsHeader.Controls.Add(this.lblIconCount);
            this.pnlIconsHeader.Dock = DockStyle.Top;
            this.pnlIconsHeader.Location = new Point(30, 30);
            this.pnlIconsHeader.Name = "pnlIconsHeader";
            this.pnlIconsHeader.Size = new Size(1140, 40);
            // 
            // lblIconsTitle
            // 
            this.lblIconsTitle.AutoSize = true;
            this.lblIconsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblIconsTitle.Location = new Point(0, 5);
            this.lblIconsTitle.Name = "lblIconsTitle";
            this.lblIconsTitle.Size = new Size(150, 25);
            this.lblIconsTitle.Text = "Danh sách Icons";
            // 
            // lblIconCount
            // 
            this.lblIconCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblIconCount.BackColor = Color.FromArgb(0, 123, 255);
            this.lblIconCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblIconCount.ForeColor = Color.White;
            this.lblIconCount.Location = new Point(1000, 5);
            this.lblIconCount.Name = "lblIconCount";
            this.lblIconCount.Padding = new Padding(12, 6, 12, 6);
            this.lblIconCount.Size = new Size(100, 30);
            this.lblIconCount.Text = "30 icons";
            this.lblIconCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddIcon
            // 
            this.btnAddIcon.Visible = false;
            // 
            // flpIcons
            // 
            this.flpIcons.AutoScroll = true;
            this.flpIcons.Dock = DockStyle.Fill;
            this.flpIcons.Location = new Point(30, 70);
            this.flpIcons.Name = "flpIcons";
            this.flpIcons.Size = new Size(1140, 550);
            this.flpIcons.Padding = new Padding(10);
            // 
            // pnlColorsList
            // 
            this.pnlColorsList.BackColor = Color.White;
            this.pnlColorsList.Controls.Add(this.flpColors);
            this.pnlColorsList.Controls.Add(this.pnlColorsHeader);
            this.pnlColorsList.Dock = DockStyle.Fill;
            this.pnlColorsList.Location = new Point(0, 150);
            this.pnlColorsList.Name = "pnlColorsList";
            this.pnlColorsList.Padding = new Padding(30);
            this.pnlColorsList.Size = new Size(1200, 650);
            this.pnlColorsList.Visible = false;
            // 
            // pnlColorsHeader
            // 
            this.pnlColorsHeader.Controls.Add(this.lblColorsTitle);
            this.pnlColorsHeader.Controls.Add(this.lblColorCount);
            this.pnlColorsHeader.Dock = DockStyle.Top;
            this.pnlColorsHeader.Location = new Point(30, 30);
            this.pnlColorsHeader.Name = "pnlColorsHeader";
            this.pnlColorsHeader.Size = new Size(1140, 40);
            // 
            // lblColorsTitle
            // 
            this.lblColorsTitle.AutoSize = true;
            this.lblColorsTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            this.lblColorsTitle.Location = new Point(0, 5);
            this.lblColorsTitle.Name = "lblColorsTitle";
            this.lblColorsTitle.Size = new Size(150, 25);
            this.lblColorsTitle.Text = "Danh sách Colors";
            // 
            // lblColorCount
            // 
            this.lblColorCount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            this.lblColorCount.BackColor = Color.FromArgb(0, 123, 255);
            this.lblColorCount.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            this.lblColorCount.ForeColor = Color.White;
            this.lblColorCount.Location = new Point(1000, 5);
            this.lblColorCount.Name = "lblColorCount";
            this.lblColorCount.Padding = new Padding(12, 6, 12, 6);
            this.lblColorCount.Size = new Size(100, 30);
            this.lblColorCount.Text = "20 colors";
            this.lblColorCount.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnAddColor
            // 
            this.btnAddColor.Visible = false;
            // 
            // flpColors
            // 
            this.flpColors.AutoScroll = true;
            this.flpColors.Dock = DockStyle.Fill;
            this.flpColors.Location = new Point(30, 70);
            this.flpColors.Name = "flpColors";
            this.flpColors.Size = new Size(1140, 550);
            this.flpColors.Padding = new Padding(10);
            // 
            // UC_CategoryAD
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = Color.FromArgb(245, 245, 245);
            this.Controls.Add(this.pnlIconsList);
            this.Controls.Add(this.pnlColorsList);
            this.Controls.Add(this.pnlTabs);
            this.Controls.Add(this.pnlHeader);
            this.Name = "UC_CategoryAD";
            this.Size = new Size(1200, 800);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlTabs.ResumeLayout(false);
            this.pnlIconsList.ResumeLayout(false);
            this.pnlIconsHeader.ResumeLayout(false);
            this.pnlIconsHeader.PerformLayout();
            this.pnlColorsList.ResumeLayout(false);
            this.pnlColorsHeader.ResumeLayout(false);
            this.pnlColorsHeader.PerformLayout();
            this.ResumeLayout(false);
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