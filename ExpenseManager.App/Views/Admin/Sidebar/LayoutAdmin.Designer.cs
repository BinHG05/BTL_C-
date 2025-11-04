using System.Drawing;
using System.IO;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.Sidebar
{
    partial class LayoutAdmin
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
            this.sidebarPanel = new System.Windows.Forms.Panel();
            this.btnSettings = new FontAwesome.Sharp.IconButton();
            this.btnAnalytics = new FontAwesome.Sharp.IconButton();
            this.btnGoals = new FontAwesome.Sharp.IconButton();
            this.btnBudget = new FontAwesome.Sharp.IconButton();
            this.btnWallet = new FontAwesome.Sharp.IconButton();
            this.btnDashboard = new FontAwesome.Sharp.IconButton();
            this.logoPanel = new System.Windows.Forms.Panel();
            this.logoPic = new System.Windows.Forms.PictureBox();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.btnToggleTheme = new FontAwesome.Sharp.IconButton();
            this.btnProfileTop = new FontAwesome.Sharp.IconButton();
            this.centerPanel = new System.Windows.Forms.Panel();
            this.btnAddTransaction = new FontAwesome.Sharp.IconButton();
            this.searchBox = new System.Windows.Forms.Panel();
            this.btnSearchInside = new FontAwesome.Sharp.IconButton();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.sidebarPanel.SuspendLayout();
            this.logoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.centerPanel.SuspendLayout();
            this.searchBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // sidebarPanel
            // 
            this.sidebarPanel.BackColor = System.Drawing.Color.White;
            this.sidebarPanel.Controls.Add(this.btnSettings);
            this.sidebarPanel.Controls.Add(this.btnAnalytics);
            this.sidebarPanel.Controls.Add(this.btnGoals);
            this.sidebarPanel.Controls.Add(this.btnBudget);
            this.sidebarPanel.Controls.Add(this.btnWallet);
            this.sidebarPanel.Controls.Add(this.btnDashboard);
            this.sidebarPanel.Controls.Add(this.logoPanel);
            this.sidebarPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPanel.Location = new System.Drawing.Point(0, 0);
            this.sidebarPanel.Name = "sidebarPanel";
            this.sidebarPanel.Size = new System.Drawing.Size(250, 768);
            this.sidebarPanel.TabIndex = 0;
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.White;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnSettings.FlatAppearance.BorderSize = 0;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnSettings.ForeColor = System.Drawing.Color.Black;
            this.btnSettings.IconChar = FontAwesome.Sharp.IconChar.Gear;
            this.btnSettings.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnSettings.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSettings.IconSize = 28;
            this.btnSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.Location = new System.Drawing.Point(0, 680);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnSettings.Size = new System.Drawing.Size(250, 120);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Tag = "Settings";
            this.btnSettings.Text = "Settings";
            this.btnSettings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnSettings.UseVisualStyleBackColor = false;
            this.btnSettings.Click += new System.EventHandler(this.BtnSettings_Click);
            // 
            // btnAnalytics
            // 
            this.btnAnalytics.BackColor = System.Drawing.Color.White;
            this.btnAnalytics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnAnalytics.FlatAppearance.BorderSize = 0;
            this.btnAnalytics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnalytics.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAnalytics.ForeColor = System.Drawing.Color.Black;
            this.btnAnalytics.IconChar = FontAwesome.Sharp.IconChar.ChartLine;
            this.btnAnalytics.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnAnalytics.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAnalytics.IconSize = 28;
            this.btnAnalytics.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalytics.Location = new System.Drawing.Point(0, 560);
            this.btnAnalytics.Name = "btnAnalytics";
            this.btnAnalytics.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnAnalytics.Size = new System.Drawing.Size(250, 120);
            this.btnAnalytics.TabIndex = 5;
            this.btnAnalytics.Tag = "Analytics";
            this.btnAnalytics.Text = "Analytics";
            this.btnAnalytics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAnalytics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAnalytics.UseVisualStyleBackColor = false;
            this.btnAnalytics.Click += new System.EventHandler(this.BtnAnalytics_Click);
            // 
            // btnGoals
            // 
            this.btnGoals.BackColor = System.Drawing.Color.White;
            this.btnGoals.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnGoals.FlatAppearance.BorderSize = 0;
            this.btnGoals.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGoals.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGoals.ForeColor = System.Drawing.Color.Black;
            this.btnGoals.IconChar = FontAwesome.Sharp.IconChar.Bullseye;
            this.btnGoals.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnGoals.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnGoals.IconSize = 28;
            this.btnGoals.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoals.Location = new System.Drawing.Point(0, 440);
            this.btnGoals.Name = "btnGoals";
            this.btnGoals.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnGoals.Size = new System.Drawing.Size(250, 120);
            this.btnGoals.TabIndex = 4;
            this.btnGoals.Tag = "Goals";
            this.btnGoals.Text = "Goals";
            this.btnGoals.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnGoals.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnGoals.UseVisualStyleBackColor = false;
            this.btnGoals.Click += new System.EventHandler(this.BtnGoals_Click);
            // 
            // btnBudget
            // 
            this.btnBudget.BackColor = System.Drawing.Color.White;
            this.btnBudget.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnBudget.FlatAppearance.BorderSize = 0;
            this.btnBudget.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBudget.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnBudget.ForeColor = System.Drawing.Color.Black;
            this.btnBudget.IconChar = FontAwesome.Sharp.IconChar.Coins;
            this.btnBudget.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnBudget.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnBudget.IconSize = 28;
            this.btnBudget.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBudget.Location = new System.Drawing.Point(0, 320);
            this.btnBudget.Name = "btnBudget";
            this.btnBudget.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnBudget.Size = new System.Drawing.Size(250, 120);
            this.btnBudget.TabIndex = 3;
            this.btnBudget.Tag = "Budget";
            this.btnBudget.Text = "Budget";
            this.btnBudget.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBudget.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBudget.UseVisualStyleBackColor = false;
            this.btnBudget.Click += new System.EventHandler(this.BtnBudget_Click);
            // 
            // btnWallet
            // 
            this.btnWallet.BackColor = System.Drawing.Color.White;
            this.btnWallet.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnWallet.FlatAppearance.BorderSize = 0;
            this.btnWallet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWallet.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnWallet.ForeColor = System.Drawing.Color.Black;
            this.btnWallet.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            this.btnWallet.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnWallet.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnWallet.IconSize = 28;
            this.btnWallet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWallet.Location = new System.Drawing.Point(0, 200);
            this.btnWallet.Name = "btnWallet";
            this.btnWallet.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnWallet.Size = new System.Drawing.Size(250, 120);
            this.btnWallet.TabIndex = 2;
            this.btnWallet.Tag = "Wallet";
            this.btnWallet.Text = "Wallet";
            this.btnWallet.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnWallet.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnWallet.UseVisualStyleBackColor = false;
            this.btnWallet.Click += new System.EventHandler(this.BtnWallet_Click);
            // 
            // btnDashboard
            // 
            this.btnDashboard.BackColor = System.Drawing.Color.White;
            this.btnDashboard.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnDashboard.FlatAppearance.BorderSize = 0;
            this.btnDashboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDashboard.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnDashboard.ForeColor = System.Drawing.Color.Black;
            this.btnDashboard.IconChar = FontAwesome.Sharp.IconChar.ChartPie;
            this.btnDashboard.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnDashboard.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnDashboard.IconSize = 28;
            this.btnDashboard.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.Location = new System.Drawing.Point(0, 80);
            this.btnDashboard.Name = "btnDashboard";
            this.btnDashboard.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.btnDashboard.Size = new System.Drawing.Size(250, 120);
            this.btnDashboard.TabIndex = 1;
            this.btnDashboard.Tag = "Dashboard";
            this.btnDashboard.Text = "Dashboard";
            this.btnDashboard.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnDashboard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnDashboard.UseVisualStyleBackColor = false;
            this.btnDashboard.Click += new System.EventHandler(this.BtnDashboard_Click);
            // 
            // logoPanel
            // 
            this.logoPanel.BackColor = System.Drawing.Color.White;
            this.logoPanel.Controls.Add(this.logoPic);
            this.logoPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.logoPanel.Location = new System.Drawing.Point(0, 0);
            this.logoPanel.Name = "logoPanel";
            this.logoPanel.Size = new System.Drawing.Size(250, 80);
            this.logoPanel.TabIndex = 0;
            // 
            // logoPic
            // 
            this.logoPic.BackColor = System.Drawing.Color.Transparent;
            this.logoPic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoPic.Location = new System.Drawing.Point(0, 0);
            this.logoPic.Name = "logoPic";
            this.logoPic.Size = new System.Drawing.Size(250, 80);
            this.logoPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPic.TabIndex = 0;
            this.logoPic.TabStop = false;
            // 
            // headerPanel
            // 
            this.headerPanel.BackColor = System.Drawing.Color.White;
            this.headerPanel.Controls.Add(this.rightPanel);
            this.headerPanel.Controls.Add(this.centerPanel);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(250, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(30, 20, 30, 20);
            this.headerPanel.Size = new System.Drawing.Size(1174, 80);
            this.headerPanel.TabIndex = 1;
            // 
            // rightPanel
            // 
            this.rightPanel.BackColor = System.Drawing.Color.White;
            this.rightPanel.Controls.Add(this.btnToggleTheme);
            this.rightPanel.Controls.Add(this.btnProfileTop);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.rightPanel.Location = new System.Drawing.Point(1014, 20);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Padding = new System.Windows.Forms.Padding(0, 10, 20, 10);
            this.rightPanel.Size = new System.Drawing.Size(130, 40);
            this.rightPanel.TabIndex = 1;
            // 
            // btnToggleTheme
            // 
            this.btnToggleTheme.BackColor = System.Drawing.Color.Transparent;
            this.btnToggleTheme.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnToggleTheme.FlatAppearance.BorderSize = 0;
            this.btnToggleTheme.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleTheme.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnToggleTheme.IconChar = FontAwesome.Sharp.IconChar.Moon;
            this.btnToggleTheme.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnToggleTheme.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnToggleTheme.IconSize = 26;
            this.btnToggleTheme.Location = new System.Drawing.Point(20, 10);
            this.btnToggleTheme.Name = "btnToggleTheme";
            this.btnToggleTheme.Size = new System.Drawing.Size(45, 20);
            this.btnToggleTheme.TabIndex = 1;
            this.btnToggleTheme.UseVisualStyleBackColor = false;
            // 
            // btnProfileTop
            // 
            this.btnProfileTop.BackColor = System.Drawing.Color.Transparent;
            this.btnProfileTop.Dock = System.Windows.Forms.DockStyle.Right;
            this.btnProfileTop.FlatAppearance.BorderSize = 0;
            this.btnProfileTop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProfileTop.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnProfileTop.IconChar = FontAwesome.Sharp.IconChar.UserCircle;
            this.btnProfileTop.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnProfileTop.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnProfileTop.IconSize = 26;
            this.btnProfileTop.Location = new System.Drawing.Point(65, 10);
            this.btnProfileTop.Name = "btnProfileTop";
            this.btnProfileTop.Size = new System.Drawing.Size(45, 20);
            this.btnProfileTop.TabIndex = 0;
            this.btnProfileTop.UseVisualStyleBackColor = false;
            // 
            // centerPanel
            // 
            this.centerPanel.Controls.Add(this.btnAddTransaction);
            this.centerPanel.Controls.Add(this.searchBox);
            this.centerPanel.Location = new System.Drawing.Point(350, 15);
            this.centerPanel.Name = "centerPanel";
            this.centerPanel.Size = new System.Drawing.Size(500, 50);
            this.centerPanel.TabIndex = 0;
            // 
            // btnAddTransaction
            // 
            this.btnAddTransaction.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnAddTransaction.FlatAppearance.BorderSize = 0;
            this.btnAddTransaction.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTransaction.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnAddTransaction.ForeColor = System.Drawing.Color.White;
            this.btnAddTransaction.IconChar = FontAwesome.Sharp.IconChar.Plus;
            this.btnAddTransaction.IconColor = System.Drawing.Color.White;
            this.btnAddTransaction.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnAddTransaction.IconSize = 18;
            this.btnAddTransaction.Location = new System.Drawing.Point(300, 5);
            this.btnAddTransaction.Name = "btnAddTransaction";
            this.btnAddTransaction.Size = new System.Drawing.Size(180, 40);
            this.btnAddTransaction.TabIndex = 1;
            this.btnAddTransaction.Text = "Add Transaction";
            this.btnAddTransaction.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAddTransaction.UseVisualStyleBackColor = false;
            // 
            // searchBox
            // 
            this.searchBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.searchBox.Controls.Add(this.btnSearchInside);
            this.searchBox.Controls.Add(this.txtSearch);
            this.searchBox.Location = new System.Drawing.Point(0, 5);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(280, 40);
            this.searchBox.TabIndex = 0;
            // 
            // btnSearchInside
            // 
            this.btnSearchInside.BackColor = System.Drawing.Color.Transparent;
            this.btnSearchInside.FlatAppearance.BorderSize = 0;
            this.btnSearchInside.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchInside.IconChar = FontAwesome.Sharp.IconChar.MagnifyingGlass;
            this.btnSearchInside.IconColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(44)))), ((int)(((byte)(216)))));
            this.btnSearchInside.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.btnSearchInside.IconSize = 18;
            this.btnSearchInside.Location = new System.Drawing.Point(245, 5);
            this.btnSearchInside.Name = "btnSearchInside";
            this.btnSearchInside.Size = new System.Drawing.Size(30, 30);
            this.btnSearchInside.TabIndex = 1;
            this.btnSearchInside.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.txtSearch.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSearch.ForeColor = System.Drawing.Color.Black;
            this.txtSearch.Location = new System.Drawing.Point(10, 10);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.PlaceholderText = "Search...";
            this.txtSearch.Size = new System.Drawing.Size(225, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(250, 80);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1174, 688);
            this.contentPanel.TabIndex = 2;
            // 
            // LayoutAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1424, 768);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.headerPanel);
            this.Controls.Add(this.sidebarPanel);
            this.Name = "LayoutAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ExpenseManager - Admin";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.LayoutAdmin_Load);
            this.sidebarPanel.ResumeLayout(false);
            this.logoPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoPic)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.centerPanel.ResumeLayout(false);
            this.searchBox.ResumeLayout(false);
            this.searchBox.PerformLayout();
            this.ResumeLayout(false);
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
        private FontAwesome.Sharp.IconButton btnProfileTop;
        private System.Windows.Forms.Panel centerPanel;
        private FontAwesome.Sharp.IconButton btnAddTransaction;
        private System.Windows.Forms.Panel searchBox;
        private FontAwesome.Sharp.IconButton btnSearchInside;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Panel contentPanel;
    }
}
