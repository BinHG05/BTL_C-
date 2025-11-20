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
            btnToggleTheme = new IconButton();
            btnNotification = new IconButton();
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
            sidebarPanel.BackColor = Color.FromArgb(31, 31, 224);
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
            sidebarPanel.Size = new Size(91, 1024);
            sidebarPanel.TabIndex = 0;
            // 
            // btnSettings
            // 
            btnSettings.BackColor = Color.Transparent;
            btnSettings.Dock = DockStyle.Bottom;
            btnSettings.FlatAppearance.BorderSize = 0;
            btnSettings.FlatStyle = FlatStyle.Flat;
            btnSettings.Font = new Font("Segoe UI", 10F);
            btnSettings.ForeColor = Color.White;
            btnSettings.IconChar = IconChar.Cog;
            btnSettings.IconColor = Color.White;
            btnSettings.IconFont = IconFont.Auto;
            btnSettings.IconSize = 32;
            btnSettings.Location = new Point(0, 931);
            btnSettings.Margin = new Padding(3, 4, 3, 4);
            btnSettings.Name = "btnSettings";
            btnSettings.Size = new Size(91, 93);
            btnSettings.TabIndex = 6;
            btnSettings.Tag = "Settings";
            btnSettings.UseVisualStyleBackColor = false;
            btnSettings.Click += BtnSettings_Click;
            // 
            // btnAnalytics
            // 
            btnAnalytics.BackColor = Color.Transparent;
            btnAnalytics.Dock = DockStyle.Top;
            btnAnalytics.FlatAppearance.BorderSize = 0;
            btnAnalytics.FlatStyle = FlatStyle.Flat;
            btnAnalytics.Font = new Font("Segoe UI", 10F);
            btnAnalytics.ForeColor = Color.White;
            btnAnalytics.IconChar = IconChar.ChartLine;
            btnAnalytics.IconColor = Color.White;
            btnAnalytics.IconFont = IconFont.Auto;
            btnAnalytics.IconSize = 32;
            btnAnalytics.Location = new Point(0, 585);
            btnAnalytics.Margin = new Padding(3, 4, 3, 4);
            btnAnalytics.Name = "btnAnalytics";
            btnAnalytics.Size = new Size(91, 93);
            btnAnalytics.TabIndex = 5;
            btnAnalytics.Tag = "Analytics";
            btnAnalytics.UseVisualStyleBackColor = false;
            btnAnalytics.Click += BtnAnalytics_Click;
            // 
            // btnGoals
            // 
            btnGoals.BackColor = Color.Transparent;
            btnGoals.Dock = DockStyle.Top;
            btnGoals.FlatAppearance.BorderSize = 0;
            btnGoals.FlatStyle = FlatStyle.Flat;
            btnGoals.Font = new Font("Segoe UI", 10F);
            btnGoals.ForeColor = Color.White;
            btnGoals.IconChar = IconChar.Bullseye;
            btnGoals.IconColor = Color.White;
            btnGoals.IconFont = IconFont.Auto;
            btnGoals.IconSize = 32;
            btnGoals.Location = new Point(0, 492);
            btnGoals.Margin = new Padding(3, 4, 3, 4);
            btnGoals.Name = "btnGoals";
            btnGoals.Size = new Size(91, 93);
            btnGoals.TabIndex = 4;
            btnGoals.Tag = "Goals";
            btnGoals.UseVisualStyleBackColor = false;
            btnGoals.Click += BtnGoals_Click;
            // 
            // btnBudget
            // 
            btnBudget.BackColor = Color.Transparent;
            btnBudget.Dock = DockStyle.Top;
            btnBudget.FlatAppearance.BorderSize = 0;
            btnBudget.FlatStyle = FlatStyle.Flat;
            btnBudget.Font = new Font("Segoe UI", 10F);
            btnBudget.ForeColor = Color.White;
            btnBudget.IconChar = IconChar.Coins;
            btnBudget.IconColor = Color.White;
            btnBudget.IconFont = IconFont.Auto;
            btnBudget.IconSize = 32;
            btnBudget.Location = new Point(0, 399);
            btnBudget.Margin = new Padding(3, 4, 3, 4);
            btnBudget.Name = "btnBudget";
            btnBudget.Size = new Size(91, 93);
            btnBudget.TabIndex = 3;
            btnBudget.Tag = "Budget";
            btnBudget.UseVisualStyleBackColor = false;
            btnBudget.Click += BtnBudget_Click;
            // 
            // btnWallet
            // 
            btnWallet.BackColor = Color.Transparent;
            btnWallet.Dock = DockStyle.Top;
            btnWallet.FlatAppearance.BorderSize = 0;
            btnWallet.FlatStyle = FlatStyle.Flat;
            btnWallet.Font = new Font("Segoe UI", 10F);
            btnWallet.ForeColor = Color.White;
            btnWallet.IconChar = IconChar.CreditCard;
            btnWallet.IconColor = Color.White;
            btnWallet.IconFont = IconFont.Auto;
            btnWallet.IconSize = 32;
            btnWallet.Location = new Point(0, 306);
            btnWallet.Margin = new Padding(3, 4, 3, 4);
            btnWallet.Name = "btnWallet";
            btnWallet.Size = new Size(91, 93);
            btnWallet.TabIndex = 2;
            btnWallet.Tag = "Wallet";
            btnWallet.UseVisualStyleBackColor = false;
            btnWallet.Click += BtnWallet_Click;
            // 
            // btnDashboard
            // 
            btnDashboard.BackColor = Color.Transparent;
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.White;
            btnDashboard.IconChar = IconChar.PieChart;
            btnDashboard.IconColor = Color.White;
            btnDashboard.IconFont = IconFont.Auto;
            btnDashboard.IconSize = 32;
            btnDashboard.Location = new Point(0, 213);
            btnDashboard.Margin = new Padding(3, 4, 3, 4);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Size = new Size(91, 93);
            btnDashboard.TabIndex = 1;
            btnDashboard.Tag = "Dashboard";
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
            logoPanel.Size = new Size(91, 213);
            logoPanel.TabIndex = 0;
            // 
            // logoPic
            // 
            logoPic.BackColor = Color.Transparent;
            logoPic.Location = new Point(11, 67);
            logoPic.Margin = new Padding(3, 4, 3, 4);
            logoPic.Name = "logoPic";
            logoPic.Size = new Size(69, 80);
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
            headerPanel.Location = new Point(91, 0);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Padding = new Padding(34, 20, 34, 20);
            headerPanel.Size = new Size(1536, 93);
            headerPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            rightPanel.BackColor = Color.White;
            rightPanel.Controls.Add(btnToggleTheme);
            rightPanel.Controls.Add(btnNotification);
            rightPanel.Controls.Add(btnProfileTop);
            rightPanel.Dock = DockStyle.Right;
            rightPanel.Location = new Point(1296, 20);
            rightPanel.Margin = new Padding(3, 4, 3, 4);
            rightPanel.Name = "rightPanel";
            rightPanel.Padding = new Padding(0, 13, 23, 13);
            rightPanel.Size = new Size(206, 53);
            rightPanel.TabIndex = 1;
            // 
            // btnToggleTheme
            // 
            btnToggleTheme.BackColor = Color.Transparent;
            btnToggleTheme.Dock = DockStyle.Right;
            btnToggleTheme.FlatAppearance.BorderSize = 0;
            btnToggleTheme.FlatStyle = FlatStyle.Flat;
            btnToggleTheme.ForeColor = Color.Black;
            btnToggleTheme.IconChar = IconChar.Sun;
            btnToggleTheme.IconColor = Color.Black;
            btnToggleTheme.IconFont = IconFont.Auto;
            btnToggleTheme.IconSize = 22;
            btnToggleTheme.Location = new Point(45, 13);
            btnToggleTheme.Margin = new Padding(3, 4, 3, 4);
            btnToggleTheme.Name = "btnToggleTheme";
            btnToggleTheme.Size = new Size(46, 27);
            btnToggleTheme.TabIndex = 2;
            btnToggleTheme.UseVisualStyleBackColor = false;
            // 
            // btnNotification
            // 
            btnNotification.BackColor = Color.Transparent;
            btnNotification.Dock = DockStyle.Right;
            btnNotification.FlatAppearance.BorderSize = 0;
            btnNotification.FlatStyle = FlatStyle.Flat;
            btnNotification.ForeColor = Color.Black;
            btnNotification.IconChar = IconChar.Bell;
            btnNotification.IconColor = Color.Black;
            btnNotification.IconFont = IconFont.Auto;
            btnNotification.IconSize = 22;
            btnNotification.Location = new Point(91, 13);
            btnNotification.Margin = new Padding(3, 4, 3, 4);
            btnNotification.Name = "btnNotification";
            btnNotification.Size = new Size(46, 27);
            btnNotification.TabIndex = 1;
            btnNotification.UseVisualStyleBackColor = false;
            // 
            // btnProfileTop
            // 
            btnProfileTop.BackColor = Color.FromArgb(31, 31, 224);
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
            btnAddTransaction.BackColor = Color.FromArgb(101, 109, 255);
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
            btnSearchInside.BackColor = Color.FromArgb(31, 31, 224);
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
            contentPanel.Location = new Point(91, 93);
            contentPanel.Margin = new Padding(3, 4, 3, 4);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1536, 931);
            contentPanel.TabIndex = 2;
            // 
            // profileContextMenu
            // 
            profileContextMenu.BackColor = Color.White;
            profileContextMenu.ImageScalingSize = new Size(20, 20);
            profileContextMenu.Items.AddRange(new ToolStripItem[] { separator1, settingsMenuItem, logoutMenuItem });
            profileContextMenu.Name = "profileContextMenu";
            profileContextMenu.Size = new Size(174, 94);
            // 
            // separator1
            // 
            separator1.Name = "separator1";
            separator1.Size = new Size(170, 6);
            // 
            // settingsMenuItem
            // 
            settingsMenuItem.Font = new Font("Segoe UI", 10F);
            settingsMenuItem.Name = "settingsMenuItem";
            settingsMenuItem.Padding = new Padding(10, 8, 10, 8);
            settingsMenuItem.Size = new Size(193, 42);
            settingsMenuItem.Text = "⚙️  Settings";
            //settingsMenuItem.Click += SettingsMenuItem_Click;
            // 
            // logoutMenuItem
            // 
            logoutMenuItem.Font = new Font("Segoe UI", 10F);
            logoutMenuItem.ForeColor = Color.FromArgb(220, 53, 69);
            logoutMenuItem.Name = "logoutMenuItem";
            logoutMenuItem.Padding = new Padding(10, 8, 10, 8);
            logoutMenuItem.Size = new Size(193, 42);
            logoutMenuItem.Text = "🚪  Logout";
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

        // ✅ THÊM METHOD TẠO PROFILE INFO PANEL
        private Panel CreateProfileInfoPanel()
        {
            Panel panel = new Panel
            {
                Size = new Size(230, 70),
                BackColor = Color.White,
                Padding = new Padding(15, 10, 15, 10)
            };

            // Icon
            PictureBox iconBox = new PictureBox
            {
                Size = new Size(40, 40),
                Location = new Point(10, 15),
                BackColor = Color.FromArgb(31, 31, 224),
                SizeMode = PictureBoxSizeMode.CenterImage
            };

            // Make icon circular
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, iconBox.Width, iconBox.Height);
            iconBox.Region = new Region(path);

            // Icon user (dùng emoji hoặc text)
            Label iconLabel = new Label
            {
                Text = "👤",
                Font = new Font("Segoe UI", 16F),
                Size = new Size(40, 40),
                TextAlign = ContentAlignment.MiddleCenter,
                BackColor = Color.Transparent,
                Parent = iconBox
            };

            // Name label
            profileNameLabel = new Label
            {
                Text = "User Name",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Location = new Point(60, 12),
                Size = new Size(160, 20),
                AutoSize = false,
                BackColor = Color.Transparent
            };

            // Email label
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

        // ✅ THÊM CÁC BIẾN MỚI
        private System.Windows.Forms.ContextMenuStrip profileContextMenu;
        private System.Windows.Forms.ToolStripControlHost profileInfoPanel;
        private System.Windows.Forms.ToolStripSeparator separator1;
        private System.Windows.Forms.ToolStripMenuItem settingsMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        private Label profileNameLabel;
        private Label profileEmailLabel;
    }
}