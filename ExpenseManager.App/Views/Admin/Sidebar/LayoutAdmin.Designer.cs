    using System.Drawing;
    using System.Windows.Forms;
    using FontAwesome.Sharp;

    namespace ExpenseManager.App.Views.Admin.Sidebar
    {
        partial class LayoutAdmin
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

            #region Windows Form Designer generated code

            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                components = new System.ComponentModel.Container();
                sidebarPanel = new Panel();
                profilePanel = new Panel();
                lblAdminRole = new Label();
                lblAdminName = new Label();
                btnProfileAvatar = new IconButton();
                btnLogout = new IconButton();
                btnSupport = new IconButton();
                btnCategory = new IconButton();
                btnUsers = new IconButton();
                btnDashboard = new IconButton();
                logoPanel = new Panel();
                lblTitle = new Label();
                contentPanel = new Panel();
                profileMenu = new ContextMenuStrip(components);
                logoutMenuItem = new ToolStripMenuItem();
                sidebarPanel.SuspendLayout();
                profilePanel.SuspendLayout();
                logoPanel.SuspendLayout();
                profileMenu.SuspendLayout();
                SuspendLayout();
                // 
                // sidebarPanel
                // 
                sidebarPanel.BackColor = Color.FromArgb(1, 31, 65);
                sidebarPanel.Controls.Add(profilePanel);
                sidebarPanel.Controls.Add(btnLogout);
                sidebarPanel.Controls.Add(btnSupport);
                sidebarPanel.Controls.Add(btnCategory);
                sidebarPanel.Controls.Add(btnUsers);
                sidebarPanel.Controls.Add(btnDashboard);
                sidebarPanel.Controls.Add(logoPanel);
                sidebarPanel.Dock = DockStyle.Left;
                sidebarPanel.Location = new Point(0, 0);
                sidebarPanel.Margin = new Padding(3, 4, 3, 4);
                sidebarPanel.Name = "sidebarPanel";
                sidebarPanel.Size = new Size(297, 1024);
                sidebarPanel.TabIndex = 0;
                // 
                // profilePanel
                // 
                profilePanel.BackColor = Color.FromArgb(0, 21, 45);
                profilePanel.Controls.Add(lblAdminRole);
                profilePanel.Controls.Add(lblAdminName);
                profilePanel.Controls.Add(btnProfileAvatar);
                profilePanel.Cursor = Cursors.Hand;
                profilePanel.Dock = DockStyle.Bottom;
                profilePanel.Location = new Point(0, 831);
                profilePanel.Margin = new Padding(3, 4, 3, 4);
                profilePanel.Name = "profilePanel";
                profilePanel.Padding = new Padding(17, 16, 17, 16);
                profilePanel.Size = new Size(297, 120);
                profilePanel.TabIndex = 5;
                // 
                // lblAdminRole
                // 
                lblAdminRole.AutoSize = true;
                lblAdminRole.Font = new Font("Segoe UI", 8.5F);
                lblAdminRole.ForeColor = Color.FromArgb(180, 190, 200);
                lblAdminRole.Location = new Point(86, 60);
                lblAdminRole.Name = "lblAdminRole";
                lblAdminRole.Size = new Size(104, 20);
                lblAdminRole.TabIndex = 2;
                lblAdminRole.Text = "System Admin";
                // 
                // lblAdminName
                // 
                lblAdminName.AutoSize = true;
                lblAdminName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                lblAdminName.ForeColor = Color.White;
                lblAdminName.Location = new Point(86, 29);
                lblAdminName.Name = "lblAdminName";
                lblAdminName.Size = new Size(175, 25);
                lblAdminName.TabIndex = 1;
                lblAdminName.Text = "Âu Dương Tấn AD";
                // 
                // btnProfileAvatar
                // 
                btnProfileAvatar.BackColor = Color.FromArgb(52, 152, 219);
                btnProfileAvatar.FlatAppearance.BorderSize = 0;
                btnProfileAvatar.FlatStyle = FlatStyle.Flat;
                btnProfileAvatar.IconChar = IconChar.UserTie;
                btnProfileAvatar.IconColor = Color.White;
                btnProfileAvatar.IconFont = IconFont.Auto;
                btnProfileAvatar.IconSize = 32;
                btnProfileAvatar.Location = new Point(17, 27);
                btnProfileAvatar.Margin = new Padding(3, 4, 3, 4);
                btnProfileAvatar.Name = "btnProfileAvatar";
                btnProfileAvatar.Size = new Size(57, 67);
                btnProfileAvatar.TabIndex = 0;
                btnProfileAvatar.UseVisualStyleBackColor = false;
                btnProfileAvatar.Click += BtnProfileAvatar_Click;
                // 
                // btnLogout
                // 
                btnLogout.BackColor = Color.FromArgb(220, 53, 69);
                btnLogout.Dock = DockStyle.Bottom;
                btnLogout.FlatAppearance.BorderSize = 0;
                btnLogout.FlatStyle = FlatStyle.Flat;
                btnLogout.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
                btnLogout.ForeColor = Color.White;
                btnLogout.IconChar = IconChar.SignOutAlt;
                btnLogout.IconColor = Color.White;
                btnLogout.IconFont = IconFont.Auto;
                btnLogout.IconSize = 28;
                btnLogout.ImageAlign = ContentAlignment.MiddleLeft;
                btnLogout.Location = new Point(0, 951);
                btnLogout.Margin = new Padding(3, 4, 3, 4);
                btnLogout.Name = "btnLogout";
                btnLogout.Padding = new Padding(17, 0, 23, 0);
                btnLogout.Size = new Size(297, 73);
                btnLogout.TabIndex = 6;
                btnLogout.Text = "Đăng xuất";
                btnLogout.TextAlign = ContentAlignment.MiddleLeft;
                btnLogout.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnLogout.UseVisualStyleBackColor = false;
                btnLogout.Click += BtnLogout_Click;
                btnLogout.MouseEnter += BtnLogout_MouseEnter;
                btnLogout.MouseLeave += BtnLogout_MouseLeave;
                // 
                // btnSupport
                // 
                btnSupport.BackColor = Color.Transparent;
                btnSupport.Dock = DockStyle.Top;
                btnSupport.FlatAppearance.BorderSize = 0;
                btnSupport.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
                btnSupport.FlatStyle = FlatStyle.Flat;
                btnSupport.Font = new Font("Segoe UI", 11F);
                btnSupport.ForeColor = Color.White;
                btnSupport.IconChar = IconChar.Ticket;
                btnSupport.IconColor = Color.White;
                btnSupport.IconFont = IconFont.Auto;
                btnSupport.IconSize = 32;
                btnSupport.ImageAlign = ContentAlignment.MiddleLeft;
                btnSupport.Location = new Point(0, 373);
                btnSupport.Margin = new Padding(3, 4, 3, 4);
                btnSupport.Name = "btnSupport";
                btnSupport.Padding = new Padding(11, 0, 23, 0);
                btnSupport.Size = new Size(297, 80);
                btnSupport.TabIndex = 4;
                btnSupport.Text = "Support/Ticket";
                btnSupport.TextAlign = ContentAlignment.MiddleLeft;
                btnSupport.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnSupport.UseVisualStyleBackColor = false;
                btnSupport.Click += BtnSupport_Click;
                // 
                // btnCategory
                // 
                btnCategory.BackColor = Color.Transparent;
                btnCategory.Dock = DockStyle.Top;
                btnCategory.FlatAppearance.BorderSize = 0;
                btnCategory.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
                btnCategory.FlatStyle = FlatStyle.Flat;
                btnCategory.Font = new Font("Segoe UI", 11F);
                btnCategory.ForeColor = Color.White;
                btnCategory.IconChar = IconChar.Tag;
                btnCategory.IconColor = Color.White;
                btnCategory.IconFont = IconFont.Auto;
                btnCategory.IconSize = 32;
                btnCategory.ImageAlign = ContentAlignment.MiddleLeft;
                btnCategory.Location = new Point(0, 293);
                btnCategory.Margin = new Padding(3, 4, 3, 4);
                btnCategory.Name = "btnCategory";
                btnCategory.Padding = new Padding(11, 0, 23, 0);
                btnCategory.Size = new Size(297, 80);
                btnCategory.TabIndex = 3;
                btnCategory.Text = "Category";
                btnCategory.TextAlign = ContentAlignment.MiddleLeft;
                btnCategory.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnCategory.UseVisualStyleBackColor = false;
                btnCategory.Click += BtnCategory_Click;
                // 
                // btnUsers
                // 
                btnUsers.BackColor = Color.Transparent;
                btnUsers.Dock = DockStyle.Top;
                btnUsers.FlatAppearance.BorderSize = 0;
                btnUsers.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
                btnUsers.FlatStyle = FlatStyle.Flat;
                btnUsers.Font = new Font("Segoe UI", 11F);
                btnUsers.ForeColor = Color.White;
                btnUsers.IconChar = IconChar.Users;
                btnUsers.IconColor = Color.White;
                btnUsers.IconFont = IconFont.Auto;
                btnUsers.IconSize = 32;
                btnUsers.ImageAlign = ContentAlignment.MiddleLeft;
                btnUsers.Location = new Point(0, 213);
                btnUsers.Margin = new Padding(3, 4, 3, 4);
                btnUsers.Name = "btnUsers";
                btnUsers.Padding = new Padding(11, 0, 23, 0);
                btnUsers.Size = new Size(297, 80);
                btnUsers.TabIndex = 2;
                btnUsers.Text = "Users";
                btnUsers.TextAlign = ContentAlignment.MiddleLeft;
                btnUsers.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnUsers.UseVisualStyleBackColor = false;
                btnUsers.Click += BtnUsers_Click;
                // 
                // btnDashboard
                // 
                btnDashboard.BackColor = Color.Transparent;
                btnDashboard.Dock = DockStyle.Top;
                btnDashboard.FlatAppearance.BorderSize = 0;
                btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(41, 128, 185);
                btnDashboard.FlatStyle = FlatStyle.Flat;
                btnDashboard.Font = new Font("Segoe UI", 11F);
                btnDashboard.ForeColor = Color.White;
                btnDashboard.IconChar = IconChar.PieChart;
                btnDashboard.IconColor = Color.White;
                btnDashboard.IconFont = IconFont.Auto;
                btnDashboard.IconSize = 32;
                btnDashboard.ImageAlign = ContentAlignment.MiddleLeft;
                btnDashboard.Location = new Point(0, 133);
                btnDashboard.Margin = new Padding(3, 4, 3, 4);
                btnDashboard.Name = "btnDashboard";
                btnDashboard.Padding = new Padding(11, 0, 23, 0);
                btnDashboard.Size = new Size(297, 80);
                btnDashboard.TabIndex = 1;
                btnDashboard.Text = "Dashboard";
                btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
                btnDashboard.TextImageRelation = TextImageRelation.ImageBeforeText;
                btnDashboard.UseVisualStyleBackColor = false;
                btnDashboard.Click += BtnDashboard_Click;
                // 
                // logoPanel
                // 
                logoPanel.BackColor = Color.Transparent;
                logoPanel.Controls.Add(lblTitle);
                logoPanel.Dock = DockStyle.Top;
                logoPanel.Location = new Point(0, 0);
                logoPanel.Margin = new Padding(3, 4, 3, 4);
                logoPanel.Name = "logoPanel";
                logoPanel.Padding = new Padding(23, 40, 23, 13);
                logoPanel.Size = new Size(297, 133);
                logoPanel.TabIndex = 0;
                // 
                // lblTitle
                // 
                lblTitle.Dock = DockStyle.Fill;
                lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                lblTitle.ForeColor = Color.White;
                lblTitle.Location = new Point(23, 40);
                lblTitle.Name = "lblTitle";
                lblTitle.Size = new Size(251, 80);
                lblTitle.TabIndex = 0;
                lblTitle.Text = "EXPENSE\r\nMANAGER";
                lblTitle.TextAlign = ContentAlignment.MiddleCenter;
                // 
                // contentPanel
                // 
                contentPanel.BackColor = Color.FromArgb(245, 245, 245);
                contentPanel.Dock = DockStyle.Fill;
                contentPanel.Location = new Point(297, 0);
                contentPanel.Margin = new Padding(3, 4, 3, 4);
                contentPanel.Name = "contentPanel";
                contentPanel.Size = new Size(1330, 1024);
                contentPanel.TabIndex = 1;
                // 
                // profileMenu
                // 
                profileMenu.ImageScalingSize = new Size(20, 20);
                profileMenu.Items.AddRange(new ToolStripItem[] { logoutMenuItem });
                profileMenu.Name = "profileMenu";
                profileMenu.Size = new Size(147, 28);
                // 
                // logoutMenuItem
                // 
                logoutMenuItem.Name = "logoutMenuItem";
                logoutMenuItem.Size = new Size(146, 24);
                logoutMenuItem.Text = "Đăng xuất";
                logoutMenuItem.Click += LogoutMenuItem_Click;
                // 
                // LayoutAdmin
                // 
                AutoScaleDimensions = new SizeF(8F, 20F);
                AutoScaleMode = AutoScaleMode.Font;
                ClientSize = new Size(1627, 1024);
                Controls.Add(contentPanel);
                Controls.Add(sidebarPanel);
                Margin = new Padding(3, 4, 3, 4);
                Name = "LayoutAdmin";
                StartPosition = FormStartPosition.CenterScreen;
                Text = "EXPENSE MANAGER - Admin";
                WindowState = FormWindowState.Maximized;
                Load += LayoutAdmin_Load;
                sidebarPanel.ResumeLayout(false);
                profilePanel.ResumeLayout(false);
                profilePanel.PerformLayout();
                logoPanel.ResumeLayout(false);
                profileMenu.ResumeLayout(false);
                ResumeLayout(false);
            }

            #endregion

            private System.Windows.Forms.Panel sidebarPanel;
            private System.Windows.Forms.Panel logoPanel;
            private System.Windows.Forms.Label lblTitle;
            private FontAwesome.Sharp.IconButton btnDashboard;
            private FontAwesome.Sharp.IconButton btnUsers;
            private FontAwesome.Sharp.IconButton btnCategory;
            private FontAwesome.Sharp.IconButton btnSupport;
            private System.Windows.Forms.Panel profilePanel;
            private FontAwesome.Sharp.IconButton btnProfileAvatar;
            private System.Windows.Forms.Label lblAdminName;
            private System.Windows.Forms.Label lblAdminRole;
            private FontAwesome.Sharp.IconButton btnLogout;
            private System.Windows.Forms.Panel contentPanel;
            private System.Windows.Forms.ContextMenuStrip profileMenu;
            private System.Windows.Forms.ToolStripMenuItem logoutMenuItem;
        }
    }