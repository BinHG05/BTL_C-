using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.Sidebar
{
    partial class LayoutUser
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

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            sidebarPanel = new Panel();
            btnSettings = new IconButton();
            btnAnalytics = new IconButton();
            btnGoals = new IconButton();
            btnBudget = new IconButton();
            btnWallet = new IconButton();
            btnDashboard = new IconButton();
            logoPanel = new Panel();
            logoPic = new PictureBox();
            headerPanel = new Panel();
            rightPanel = new Panel();
            btnProfileTop = new IconButton();
            centerPanel = new Panel();
            btnAddTransaction = new IconButton();
            searchBox = new Panel();
            btnSearchInside = new IconButton();
            txtSearch = new TextBox();
            contentPanel = new Panel();
            profileContextMenu = new ContextMenuStrip(components);
            separator1 = new ToolStripSeparator();
            settingsMenuItem = new ToolStripMenuItem();
            logoutMenuItem = new ToolStripMenuItem();
            sidebarPanel.SuspendLayout();
            logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logoPic).BeginInit();
            headerPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            centerPanel.SuspendLayout();
            searchBox.SuspendLayout();
            profileContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.FromArgb(15, 23, 42);
            sidebarPanel.Controls.Add(btnSettings);
            sidebarPanel.Controls.Add(btnAnalytics);
            sidebarPanel.Controls.Add(btnGoals);
            sidebarPanel.Controls.Add(btnBudget);
            sidebarPanel.Controls.Add(btnWallet);
            sidebarPanel.Controls.Add(btnDashboard);
            sidebarPanel.Controls.Add(logoPanel);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Margin = new Padding(3, 4, 3, 4);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(240, 1024);
            sidebarPanel.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 11F);
            btnSettings.ForeColor = Color.FromArgb(226, 232, 240);
            btnSettings.IconChar = IconChar.Cog;
            btnSettings.IconColor = Color.FromArgb(226, 232, 240);
            btnSettings.IconFont = IconFont.Auto;
            btnSettings.IconSize = 24;
            btnSettings.ImageAlign = ContentAlignment.MiddleLeft;
            btnSettings.Location = new Point(0, 944);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Padding = new Padding(20, 0, 0, 0);
            btnSettings.Size = new Size(240, 80);
            btnSettings.TabIndex = 6;
            btnSettings.Tag = "Settings";
            btnSettings.Text = "  Cài đặt";
            btnSettings.TextAlign = ContentAlignment.MiddleLeft;
            btnSettings.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnAnalytics
            // 
            btnAnalytics.BackColor = Color.Transparent;
            btnAnalytics.Dock = DockStyle.Top;
            btnAnalytics.FlatAppearance.BorderSize = 0;
            btnAnalytics.FlatStyle = FlatStyle.Flat;
            btnAnalytics.Font = new Font("Segoe UI", 11F);
            btnAnalytics.ForeColor = Color.FromArgb(226, 232, 240);
            btnAnalytics.IconChar = IconChar.ChartLine;
            btnAnalytics.IconColor = Color.FromArgb(226, 232, 240);
            btnAnalytics.IconFont = IconFont.Auto;
            btnAnalytics.IconSize = 24;
            btnAnalytics.ImageAlign = ContentAlignment.MiddleLeft;
            btnAnalytics.Location = new Point(0, 540);
            btnAnalytics.Margin = new Padding(3, 4, 3, 4);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Padding = new Padding(20, 0, 0, 0);
            btnAnalytics.Size = new Size(240, 65);
            btnAnalytics.TabIndex = 5;
            btnAnalytics.Tag = "Analytics";
            btnAnalytics.Text = "  Phân tích";
            btnAnalytics.TextAlign = ContentAlignment.MiddleLeft;
            btnAnalytics.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAnalytics.UseVisualStyleBackColor = false;
            btnAnalytics.Click += BtnAnalytics_Click;
            // 
            // btnGoals
            // 
            btnGoals.BackColor = Color.Transparent;
            btnGoals.Dock = DockStyle.Top;
            btnGoals.FlatAppearance.BorderSize = 0;
            btnGoals.FlatStyle = FlatStyle.Flat;
            btnGoals.Font = new Font("Segoe UI", 11F);
            btnGoals.ForeColor = Color.FromArgb(226, 232, 240);
            btnGoals.IconChar = IconChar.Bullseye;
            btnGoals.IconColor = Color.FromArgb(226, 232, 240);
            btnGoals.IconFont = IconFont.Auto;
            btnGoals.IconSize = 24;
            btnGoals.ImageAlign = ContentAlignment.MiddleLeft;
            btnGoals.Location = new Point(0, 475);
            btnGoals.Margin = new Padding(3, 4, 3, 4);
            btnGoals.Name = "btnGoals";
            btnGoals.Padding = new Padding(20, 0, 0, 0);
            btnGoals.Size = new Size(240, 65);
            btnGoals.TabIndex = 4;
            btnGoals.Tag = "Goals";
            btnGoals.Text = "  Mục tiêu";
            btnGoals.TextAlign = ContentAlignment.MiddleLeft;
            btnGoals.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnGoals.UseVisualStyleBackColor = false;
            btnGoals.Click += BtnGoals_Click;
            // 
            // btnBudget
            // 
            btnBudget.BackColor = Color.Transparent;
            btnBudget.Dock = DockStyle.Top;
            btnBudget.FlatAppearance.BorderSize = 0;
            btnBudget.FlatStyle = FlatStyle.Flat;
            btnBudget.Font = new Font("Segoe UI", 11F);
            btnBudget.ForeColor = Color.FromArgb(226, 232, 240);
            btnBudget.IconChar = IconChar.Coins;
            btnBudget.IconColor = Color.FromArgb(226, 232, 240);
            btnBudget.IconFont = IconFont.Auto;
            btnBudget.IconSize = 24;
            btnBudget.ImageAlign = ContentAlignment.MiddleLeft;
            btnBudget.Location = new Point(0, 410);
            btnBudget.Margin = new Padding(3, 4, 3, 4);
            btnBudget.Name = "btnBudget";
            btnBudget.Padding = new Padding(20, 0, 0, 0);
            btnBudget.Size = new Size(240, 65);
            btnBudget.TabIndex = 3;
            btnBudget.Tag = "Budget";
            btnBudget.Text = "  Ngân sách";
            btnBudget.TextAlign = ContentAlignment.MiddleLeft;
            btnBudget.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnBudget.UseVisualStyleBackColor = false;
            btnBudget.Click += BtnBudget_Click;
            // 
            // btnWallet
            // 
            btnWallet.BackColor = Color.Transparent;
            btnWallet.Dock = DockStyle.Top;
            btnWallet.FlatAppearance.BorderSize = 0;
            btnWallet.FlatStyle = FlatStyle.Flat;
            btnWallet.Font = new Font("Segoe UI", 11F);
            btnWallet.ForeColor = Color.FromArgb(226, 232, 240);
            btnWallet.IconChar = IconChar.Wallet;
            btnWallet.IconColor = Color.FromArgb(226, 232, 240);
            btnWallet.IconFont = IconFont.Auto;
            btnWallet.IconSize = 24;
            btnWallet.ImageAlign = ContentAlignment.MiddleLeft;
            btnWallet.Location = new Point(0, 345);
            btnWallet.Margin = new Padding(3, 4, 3, 4);
            btnWallet.Name = "btnWallet";
            btnWallet.Padding = new Padding(20, 0, 0, 0);
            btnWallet.Size = new Size(240, 65);
            btnWallet.TabIndex = 2;
            btnWallet.Tag = "Wallet";
            btnWallet.Text = "  Ví của bạn";
            btnWallet.TextAlign = ContentAlignment.MiddleLeft;
            btnWallet.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnWallet.UseVisualStyleBackColor = false;
            btnWallet.Click += BtnWallet_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 11F);
            btnDashboard.ForeColor = Color.FromArgb(226, 232, 240);
            btnDashboard.IconChar = IconChar.House;
            btnDashboard.IconColor = Color.FromArgb(226, 232, 240);
            btnDashboard.IconFont = IconFont.Auto;
            btnDashboard.IconSize = 24;
            btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
            btnDashboard.Location = new Point(0, 280);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(20, 0, 0, 0);
            btnDashboard.Size = new Size(240, 65);
            btnDashboard.TabIndex = 1;
            btnDashboard.Tag = "Dashboard";
            btnDashboard.Text = "  Tổng quan";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnDashboard.UseVisualStyleBackColor = false;
            btnDashboard.Click += BtnDashboard_Click;
            // 
            // logoPanel
            // 
            logoPanel.BackColor = Color.Transparent;
            logoPanel.Controls.Add(logoPic);
            logoPanel.Dock = DockStyle.Top;
            logoPanel.Location = new Point(0, 0);
            logoPanel.Margin = new Padding(3, 4, 3, 4);
            logoPanel.Name = "logoPanel";
            logoPanel.Size = new Size(240, 280);
            logoPanel.TabIndex = 0;
            // 
            // logoPic
            // 
            logoPic.BackColor = Color.Transparent;
            logoPic.Location = new Point(50, 80);
            logoPic.Margin = new Padding(3, 4, 3, 4);
            logoPic.Name = "logoPic";
            logoPic.Size = new Size(140, 120);
            logoPic.SizeMode = PictureBoxSizeMode.Zoom;
            logoPic.TabIndex = 0;
            logoPic.TabStop = false;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.White;
            headerPanel.Controls.Add(rightPanel);
            headerPanel.Controls.Add(centerPanel);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(240, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(34, 20, 34, 20);
            headerPanel.Size = new Size(1387, 93);
            headerPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.White;
            rightPanel.Controls.Add(btnProfileTop);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(1147, 20);
            rightPanel.Margin = new Padding(3, 4, 3, 4);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(0, 13, 23, 13);
            rightPanel.Size = new Size(206, 53);
            rightPanel.TabIndex = 1;
            // 
            // btnProfileTop
            // 
            btnProfileTop.BackColor = Color.FromArgb(59, 130, 246);
            btnProfileTop.Dock = DockStyle.Right;
            btnProfileTop.FlatAppearance.BorderSize = 0;
            btnProfileTop.FlatStyle = FlatStyle.Flat;
            btnProfileTop.ForeColor = Color.White;
            btnProfileTop.IconChar = IconChar.User;
            btnProfileTop.IconColor = Color.White;
            btnProfileTop.IconFont = IconFont.Auto;
            btnProfileTop.IconSize = 20;
            btnProfileTop.Location = new Point(137, 13);
            btnProfileTop.Margin = new Padding(3, 4, 3, 4);
            btnProfileTop.Name = "btnProfileTop";
            btnProfileTop.Size = new Size(46, 27);
            btnProfileTop.TabIndex = 0;
            btnProfileTop.UseVisualStyleBackColor = false;
            btnProfileTop.Click += BtnProfileTop_Click;
            // 
            // centerPanel
            // 
            centerPanel.Controls.Add(btnAddTransaction);
            centerPanel.Controls.Add(searchBox);
            centerPanel.Location = new Point(400, 13);
            centerPanel.Margin = new Padding(3, 4, 3, 4);
            centerPanel.Name = "centerPanel";
            centerPanel.Size = new Size(571, 67);
            centerPanel.TabIndex = 0;
            // 
            // btnAddTransaction
            // 
            btnAddTransaction.BackColor = Color.FromArgb(59, 130, 246);
            btnAddTransaction.FlatAppearance.BorderSize = 0;
            btnAddTransaction.FlatStyle = FlatStyle.Flat;
            btnAddTransaction.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            btnAddTransaction.ForeColor = Color.White;
            btnAddTransaction.IconChar = IconChar.Add;
            btnAddTransaction.IconColor = Color.White;
            btnAddTransaction.IconFont = IconFont.Auto;
            btnAddTransaction.IconSize = 18;
            btnAddTransaction.Location = new Point(354, 7);
            btnAddTransaction.Margin = new Padding(3, 4, 3, 4);
            btnAddTransaction.Name = "btnAddTransaction";
            btnAddTransaction.Size = new Size(194, 53);
            btnAddTransaction.TabIndex = 1;
            btnAddTransaction.Text = "Thêm giao dịch";
            btnAddTransaction.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnAddTransaction.UseVisualStyleBackColor = false;
            // 
            // searchBox
            // 
            searchBox.BackColor = Color.White;
            searchBox.BorderStyle = BorderStyle.FixedSingle;
            searchBox.Controls.Add(btnSearchInside);
            searchBox.Controls.Add(txtSearch);
            searchBox.Location = new Point(0, 7);
            searchBox.Margin = new Padding(3, 4, 3, 4);
            searchBox.Name = "searchBox";
            searchBox.Size = new Size(343, 53);
            searchBox.TabIndex = 0;
            // 
            // btnSearchInside
            // 
            btnSearchInside.BackColor = Color.FromArgb(59, 130, 246);
            btnSearchInside.FlatAppearance.BorderSize = 0;
            btnSearchInside.FlatStyle = FlatStyle.Flat;
            btnSearchInside.IconChar = IconChar.Search;
            btnSearchInside.IconColor = Color.White;
            btnSearchInside.IconFont = IconFont.Auto;
            btnSearchInside.IconSize = 18;
            btnSearchInside.Location = new Point(291, 4);
            btnSearchInside.Margin = new Padding(3, 4, 3, 4);
            btnSearchInside.Name = "btnSearchInside";
            btnSearchInside.Size = new Size(46, 43);
            btnSearchInside.TabIndex = 1;
            btnSearchInside.UseVisualStyleBackColor = false;
            btnSearchInside.Click += btnSearchInside_Click_1;
            // 
            // txtSearch
            // 
            txtSearch.BackColor = Color.White;
            txtSearch.BorderStyle = BorderStyle.None;
            txtSearch.Font = new Font("Segoe UI", 10F);
            txtSearch.ForeColor = Color.Black;
            txtSearch.Location = new Point(17, 15);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Tìm giao dịch... (VD: cafe, ăn sáng)";
            txtSearch.Size = new Size(269, 23);
            txtSearch.TabIndex = 0;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.FromArgb(245, 245, 245);
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(240, 93);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1387, 931);
            contentPanel.TabIndex = 2;
            // 
            // profileContextMenu
            // 
            profileContextMenu.BackColor = Color.White;
            profileContextMenu.ImageScalingSize = new Size(20, 20);
            profileContextMenu.Items.AddRange(new ToolStripItem[] { separator1, settingsMenuItem, logoutMenuItem });
            profileContextMenu.Name = "profileContextMenu";
            profileContextMenu.Size = new Size(192, 94);
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(188, 6);
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Font = new Font("Segoe UI", 10F);
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Padding = new Padding(10, 8, 10, 8);
            settingsMenuItem.Size = new Size(211, 42);
            settingsMenuItem.Text = "⚙️  Cài đặt";
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Font = new Font("Segoe UI", 10F);
            logoutMenuItem.ForeColor = Color.FromArgb(220, 53, 69);
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Padding = new Padding(10, 8, 10, 8);
            logoutMenuItem.Size = new Size(211, 42);
            logoutMenuItem.Text = "🚪  Đăng xuất";
            logoutMenuItem.Click += LogoutMenuItem_Click;
            // 
            // LayoutUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1627, 1024);
            Controls.Add(contentPanel);
            Controls.Add(headerPanel);
            Controls.Add(sidebarPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LayoutUser";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ExpenseManager - User";
            WindowState = FormWindowState.Maximized;
            Load += LayoutAdmin_Load;
            sidebarPanel.ResumeLayout(false);
            logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)logoPic).EndInit();
            headerPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            centerPanel.ResumeLayout(false);
            searchBox.ResumeLayout(false);
            searchBox.PerformLayout();
            profileContextMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Panel CreateProfileInfoPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(230, 70),
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            PictureBox iconBox = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(10, 15),
                BackColor = Color.FromArgb(59, 130, 246),
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, iconBox.Width, iconBox.Height);
            iconBox.Region = new Region(path);

            Label iconLabel = new Label
            {
                Text = "👤",
                Font = new Font("Segoe UI", 16F),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Parent = iconBox
            };

            profileNameLabel = new Label
            {
                Text = "User Name",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(60, 12),
                Size = new Size(160, 20),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            profileEmailLabel = new Label
            {
                Text = "email@example.com",
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.Gray,
                Location = new Point(60, 33),
                Size = new Size(160, 18),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            panel.Controls.Add(iconBox);
            panel.Controls.Add(profileNameLabel);
            panel.Controls.Add(profileEmailLabel);

            return panel;
        }

        #endregion

        private System.Windows.Forms.Panel sidebarPanel;
        private FontAwesome.Sharp.IconButton btnSettings;
        private FontAwesome.Sharp.IconButton btnAnalytics;
        private FontAwesome.Sharp.IconButton btnGoals;
        private FontAwesome.Sharp.IconButton btnBudget;
        private FontAwesome.Sharp.IconButton btnWallet;
        private FontAwesome.Sharp.IconButton btnDashboard;
        private System.Windows.Forms.Panel logoPanel;
        private System.Windows.Forms.PictureBox logoPic;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Panel rightPanel;
        private FontAwesome.Sharp.IconButton btnToggleTheme;
        private FontAwesome.Sharp.IconButton btnNotification;
        private FontAwesome.Sharp.IconButton btnProfileTop;
        private System.Windows.Forms.Panel centerPanel;
        private FontAwesome.Sharp.IconButton btnAddTransaction;
        private System.Windows.Forms.Panel searchBox;
        private FontAwesome.Sharp.IconButton btnSearchInside;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.ContextMenuStrip profileContextMenu;
        private System.Windows.Forms.ToolStripControlHost profileInfoPanel;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private Label profileNameLabel;
        private Label profileEmailLabel;
    }
}