using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.UC
{
    partial class UC_TicketUser
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
            mainPanel = new Panel();
            ticketListPanel = new FlowLayoutPanel();
            tabPanel = new Panel();
            btnSupport = new Button();
            btnCreateTicket = new IconButton();
            btnCategories = new Button();
            btnProfile = new Button();
            headerPanel = new Panel();
            breadcrumbPanel = new Panel();
            lblBreadcrumb = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            mainPanel.SuspendLayout();
            tabPanel.SuspendLayout();
            headerPanel.SuspendLayout();
            breadcrumbPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.BackColor = Color.FromArgb(245, 245, 245);
            mainPanel.Controls.Add(ticketListPanel);
            mainPanel.Controls.Add(tabPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Margin = new Padding(3, 4, 3, 4);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(46, 40, 46, 40);
            mainPanel.Size = new Size(1536, 931);
            mainPanel.TabIndex = 0;
            // 
            // ticketListPanel
            // 
            ticketListPanel.AutoScroll = true;
            ticketListPanel.BackColor = Color.Transparent;
            ticketListPanel.Dock = DockStyle.Fill;
            ticketListPanel.FlowDirection = FlowDirection.TopDown;
            ticketListPanel.Location = new Point(46, 240);
            ticketListPanel.Margin = new Padding(3, 4, 3, 4);
            ticketListPanel.Name = "ticketListPanel";
            ticketListPanel.Padding = new Padding(0, 13, 0, 0);
            ticketListPanel.Size = new Size(1444, 651);
            ticketListPanel.TabIndex = 2;
            ticketListPanel.WrapContents = false;
            // 
            // tabPanel
            // 
            tabPanel.BackColor = Color.White;
            tabPanel.Controls.Add(btnSupport);
            tabPanel.Controls.Add(btnCreateTicket);
            tabPanel.Controls.Add(btnCategories);
            tabPanel.Controls.Add(btnProfile);
            tabPanel.Dock = DockStyle.Top;
            tabPanel.Location = new Point(46, 173);
            tabPanel.Margin = new Padding(3, 4, 3, 4);
            tabPanel.Name = "tabPanel";
            tabPanel.Size = new Size(1444, 67);
            tabPanel.TabIndex = 1;
            // 
            // btnSupport
            // 
            btnSupport.BackColor = Color.Transparent;
            btnSupport.FlatAppearance.BorderSize = 0;
            btnSupport.FlatStyle = FlatStyle.Flat;
            btnSupport.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnSupport.ForeColor = Color.FromArgb(101, 109, 255);
            btnSupport.Location = new Point(320, 0);
            btnSupport.Margin = new Padding(3, 4, 3, 4);
            btnSupport.Name = "btnSupport";
            btnSupport.Size = new Size(137, 67);
            btnSupport.TabIndex = 2;
            btnSupport.Text = "Support";
            btnSupport.UseVisualStyleBackColor = false;
            // 
            // btnCreateTicket
            // 
            btnCreateTicket.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnCreateTicket.BackColor = Color.FromArgb(101, 109, 255);
            btnCreateTicket.FlatAppearance.BorderSize = 0;
            btnCreateTicket.FlatStyle = FlatStyle.Flat;
            btnCreateTicket.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCreateTicket.ForeColor = Color.White;
            btnCreateTicket.IconChar = IconChar.Add;
            btnCreateTicket.IconColor = Color.White;
            btnCreateTicket.IconFont = IconFont.Auto;
            btnCreateTicket.IconSize = 20;
            btnCreateTicket.Location = new Point(1228, 3);
            btnCreateTicket.Margin = new Padding(3, 4, 3, 4);
            btnCreateTicket.Name = "btnCreateTicket";
            btnCreateTicket.Size = new Size(194, 60);
            btnCreateTicket.TabIndex = 3;
            btnCreateTicket.Text = "Create Ticket";
            btnCreateTicket.TextImageRelation = TextImageRelation.ImageBeforeText;
            btnCreateTicket.UseVisualStyleBackColor = false;
            btnCreateTicket.Click += BtnCreateTicket_Click;
            // 
            // btnCategories
            // 
            btnCategories.BackColor = Color.Transparent;
            btnCategories.FlatAppearance.BorderSize = 0;
            btnCategories.FlatStyle = FlatStyle.Flat;
            btnCategories.Font = new Font("Segoe UI", 11F);
            btnCategories.ForeColor = Color.Gray;
            btnCategories.Location = new Point(160, 0);
            btnCategories.Margin = new Padding(3, 4, 3, 4);
            btnCategories.Name = "btnCategories";
            btnCategories.Size = new Size(137, 67);
            btnCategories.TabIndex = 1;
            btnCategories.Text = "Categories";
            btnCategories.UseVisualStyleBackColor = false;
            btnCategories.Click += btnCategories_Click;
            // 
            // btnProfile
            // 
            btnProfile.BackColor = Color.Transparent;
            btnProfile.FlatAppearance.BorderSize = 0;
            btnProfile.FlatStyle = FlatStyle.Flat;
            btnProfile.Font = new Font("Segoe UI", 11F);
            btnProfile.ForeColor = Color.Gray;
            btnProfile.Location = new Point(0, 0);
            btnProfile.Margin = new Padding(3, 4, 3, 4);
            btnProfile.Name = "btnProfile";
            btnProfile.Size = new Size(137, 67);
            btnProfile.TabIndex = 0;
            btnProfile.Text = "Profile";
            btnProfile.UseVisualStyleBackColor = false;
            btnProfile.Click += btnProfile_Click;
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.Transparent;
            headerPanel.Controls.Add(breadcrumbPanel);
            headerPanel.Controls.Add(lblSubtitle);
            headerPanel.Controls.Add(lblTitle);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(46, 40);
            headerPanel.Margin = new Padding(3, 4, 3, 4);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1444, 133);
            headerPanel.TabIndex = 0;
            // 
            // breadcrumbPanel
            // 
            breadcrumbPanel.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            breadcrumbPanel.Controls.Add(lblBreadcrumb);
            breadcrumbPanel.Location = new Point(1142, 27);
            breadcrumbPanel.Margin = new Padding(3, 4, 3, 4);
            breadcrumbPanel.Name = "breadcrumbPanel";
            breadcrumbPanel.Size = new Size(229, 40);
            breadcrumbPanel.TabIndex = 2;
            // 
            // lblBreadcrumb
            // 
            lblBreadcrumb.Dock = DockStyle.Right;
            lblBreadcrumb.Font = new Font("Segoe UI", 10F);
            lblBreadcrumb.ForeColor = Color.Gray;
            lblBreadcrumb.Location = new Point(0, 0);
            lblBreadcrumb.Name = "lblBreadcrumb";
            lblBreadcrumb.Size = new Size(229, 40);
            lblBreadcrumb.TabIndex = 0;
            lblBreadcrumb.Text = "Settings  >  Support";
            lblBreadcrumb.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblSubtitle
            // 
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.Gray;
            lblSubtitle.Location = new Point(0, 73);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(298, 23);
            lblSubtitle.TabIndex = 1;
            lblSubtitle.Text = "Welcome Ekash Finance Management";
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblTitle.ForeColor = Color.Black;
            lblTitle.Location = new Point(0, 20);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(197, 46);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Edit Profile";
            // 
            // UC_TicketUser
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "UC_TicketUser";
            Size = new Size(1536, 931);
            mainPanel.ResumeLayout(false);
            tabPanel.ResumeLayout(false);
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            breadcrumbPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.FlowLayoutPanel ticketListPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblSubtitle;
        private FontAwesome.Sharp.IconButton btnCreateTicket;
        private System.Windows.Forms.Panel tabPanel;
        private System.Windows.Forms.Button btnSupport;
        private System.Windows.Forms.Button btnCategories;
        private System.Windows.Forms.Button btnProfile;
        private System.Windows.Forms.Panel breadcrumbPanel;
        private System.Windows.Forms.Label lblBreadcrumb;
    }
}