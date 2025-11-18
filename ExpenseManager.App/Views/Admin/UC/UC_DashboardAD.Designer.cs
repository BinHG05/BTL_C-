using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.Admin.UC
{
    partial class UC_DashboardAD
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
            chartPanel = new Panel();
            chartContainer = new Panel();
            filterPanel = new Panel();
            cmbFilter = new ComboBox();
            lblChartTitle = new Label();
            kpiPanel = new Panel();
            cardTickets = new Panel();
            lblTicketsResolved = new Label();
            lblTicketsOpen = new Label();
            lblTicketsChange = new Label();
            lblTicketsLabel = new Label();
            lblTicketsValue = new Label();
            iconTickets = new Panel();
            cardTrans = new Panel();
            lblTransChange = new Label();
            lblTransLabel = new Label();
            lblTransValue = new Label();
            iconTrans = new Panel();
            cardUsers = new Panel();
            lblUsersChange = new Label();
            lblUsersLabel = new Label();
            lblUsersValue = new Label();
            iconUsers = new Panel();
            headerPanel = new Panel();
            lblWelcome = new Label();
            lblDashboard = new Label();
            mainPanel.SuspendLayout();
            chartPanel.SuspendLayout();
            filterPanel.SuspendLayout();
            kpiPanel.SuspendLayout();
            cardTickets.SuspendLayout();
            cardTrans.SuspendLayout();
            cardUsers.SuspendLayout();
            headerPanel.SuspendLayout();
            SuspendLayout();
            // 
            // mainPanel
            // 
            mainPanel.AutoScroll = true;
            mainPanel.BackColor = Color.FromArgb(248, 249, 250);
            mainPanel.Controls.Add(chartPanel);
            mainPanel.Controls.Add(kpiPanel);
            mainPanel.Controls.Add(headerPanel);
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Location = new Point(0, 0);
            mainPanel.Name = "mainPanel";
            mainPanel.Padding = new Padding(40, 30, 40, 30);
            mainPanel.Size = new Size(1200, 800);
            mainPanel.TabIndex = 0;
            // 
            // chartPanel
            // 
            chartPanel.BackColor = Color.White;
            chartPanel.Controls.Add(chartContainer);
            chartPanel.Controls.Add(filterPanel);
            chartPanel.Dock = DockStyle.Top;
            chartPanel.Location = new Point(40, 272);
            chartPanel.Name = "chartPanel";
            chartPanel.Padding = new Padding(25);
            chartPanel.Size = new Size(1099, 717);
            chartPanel.TabIndex = 2;
            // 
            // chartContainer
            // 
            chartContainer.BackColor = Color.White;
            chartContainer.Dock = DockStyle.Fill;
            chartContainer.Location = new Point(25, 80);
            chartContainer.Name = "chartContainer";
            chartContainer.Size = new Size(1049, 612);
            chartContainer.TabIndex = 1;
            chartContainer.Paint += ChartContainer_Paint;
            // 
            // filterPanel
            // 
            filterPanel.Controls.Add(cmbFilter);
            filterPanel.Controls.Add(lblChartTitle);
            filterPanel.Dock = DockStyle.Top;
            filterPanel.Location = new Point(25, 25);
            filterPanel.Name = "filterPanel";
            filterPanel.Size = new Size(1049, 55);
            filterPanel.TabIndex = 0;
            // 
            // cmbFilter
            // 
            cmbFilter.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            cmbFilter.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbFilter.FlatStyle = FlatStyle.Flat;
            cmbFilter.Font = new Font("Segoe UI", 10F);
            cmbFilter.FormattingEnabled = true;
            cmbFilter.Items.AddRange(new object[] { "Theo ngày", "Theo tháng", "Theo năm" });
            cmbFilter.Location = new Point(899, 12);
            cmbFilter.Name = "cmbFilter";
            cmbFilter.Size = new Size(150, 31);
            cmbFilter.TabIndex = 1;
            // 
            // lblChartTitle
            // 
            lblChartTitle.AutoSize = true;
            lblChartTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblChartTitle.ForeColor = Color.FromArgb(52, 73, 94);
            lblChartTitle.Location = new Point(3, 12);
            lblChartTitle.Name = "lblChartTitle";
            lblChartTitle.Size = new Size(305, 32);
            lblChartTitle.TabIndex = 0;
            lblChartTitle.Text = "Biểu đồ tăng trưởng User";
            // 
            // kpiPanel
            // 
            kpiPanel.Controls.Add(cardTickets);
            kpiPanel.Controls.Add(cardTrans);
            kpiPanel.Controls.Add(cardUsers);
            kpiPanel.Dock = DockStyle.Top;
            kpiPanel.Location = new Point(40, 100);
            kpiPanel.Name = "kpiPanel";
            kpiPanel.Padding = new Padding(0, 20, 0, 20);
            kpiPanel.Size = new Size(1099, 172);
            kpiPanel.TabIndex = 1;
            // 
            // cardTickets
            // 
            cardTickets.BackColor = Color.White;
            cardTickets.Controls.Add(lblTicketsResolved);
            cardTickets.Controls.Add(lblTicketsOpen);
            cardTickets.Controls.Add(lblTicketsChange);
            cardTickets.Controls.Add(lblTicketsLabel);
            cardTickets.Controls.Add(lblTicketsValue);
            cardTickets.Controls.Add(iconTickets);
            cardTickets.Location = new Point(760, 20);
            cardTickets.Name = "cardTickets";
            cardTickets.Padding = new Padding(20);
            cardTickets.Size = new Size(360, 146);
            cardTickets.TabIndex = 2;
            // 
            // lblTicketsResolved
            // 
            lblTicketsResolved.AutoSize = true;
            lblTicketsResolved.Font = new Font("Segoe UI", 8.5F);
            lblTicketsResolved.ForeColor = Color.FromArgb(46, 204, 113);
            lblTicketsResolved.Location = new Point(221, 112);
            lblTicketsResolved.Name = "lblTicketsResolved";
            lblTicketsResolved.Size = new Size(77, 20);
            lblTicketsResolved.TabIndex = 5;
            lblTicketsResolved.Text = "9 resolved";
            // 
            // lblTicketsOpen
            // 
            lblTicketsOpen.AutoSize = true;
            lblTicketsOpen.Font = new Font("Segoe UI", 8.5F);
            lblTicketsOpen.ForeColor = Color.FromArgb(230, 126, 34);
            lblTicketsOpen.Location = new Point(20, 112);
            lblTicketsOpen.Name = "lblTicketsOpen";
            lblTicketsOpen.Size = new Size(55, 20);
            lblTicketsOpen.TabIndex = 4;
            lblTicketsOpen.Text = "2 open";
            // 
            // lblTicketsChange
            // 
            lblTicketsChange.AutoSize = true;
            lblTicketsChange.Font = new Font("Segoe UI", 8.5F);
            lblTicketsChange.ForeColor = Color.FromArgb(231, 76, 60);
            lblTicketsChange.Location = new Point(111, 112);
            lblTicketsChange.Name = "lblTicketsChange";
            lblTicketsChange.Size = new Size(76, 20);
            lblTicketsChange.TabIndex = 3;
            lblTicketsChange.Text = "1 pending";
            // 
            // lblTicketsLabel
            // 
            lblTicketsLabel.AutoSize = true;
            lblTicketsLabel.Font = new Font("Segoe UI", 9F);
            lblTicketsLabel.ForeColor = Color.FromArgb(149, 165, 166);
            lblTicketsLabel.Location = new Point(20, 83);
            lblTicketsLabel.Name = "lblTicketsLabel";
            lblTicketsLabel.Size = new Size(54, 20);
            lblTicketsLabel.TabIndex = 2;
            lblTicketsLabel.Text = "Tickets";
            // 
            // lblTicketsValue
            // 
            lblTicketsValue.AutoSize = true;
            lblTicketsValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTicketsValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblTicketsValue.Location = new Point(149, 30);
            lblTicketsValue.Name = "lblTicketsValue";
            lblTicketsValue.Size = new Size(81, 62);
            lblTicketsValue.TabIndex = 1;
            lblTicketsValue.Text = "12";
            // 
            // iconTickets
            // 
            iconTickets.BackColor = Color.FromArgb(52, 152, 219);
            iconTickets.Location = new Point(20, 30);
            iconTickets.Name = "iconTickets";
            iconTickets.Size = new Size(50, 50);
            iconTickets.TabIndex = 0;
            iconTickets.Paint += IconTickets_Paint;
            // 
            // cardTrans
            // 
            cardTrans.BackColor = Color.White;
            cardTrans.Controls.Add(lblTransChange);
            cardTrans.Controls.Add(lblTransLabel);
            cardTrans.Controls.Add(lblTransValue);
            cardTrans.Controls.Add(iconTrans);
            cardTrans.Location = new Point(360, 20);
            cardTrans.Name = "cardTrans";
            cardTrans.Padding = new Padding(20);
            cardTrans.Size = new Size(380, 146);
            cardTrans.TabIndex = 1;
            // 
            // lblTransChange
            // 
            lblTransChange.AutoSize = true;
            lblTransChange.Font = new Font("Segoe UI", 8.5F);
            lblTransChange.ForeColor = Color.FromArgb(46, 204, 113);
            lblTransChange.Location = new Point(27, 112);
            lblTransChange.Name = "lblTransChange";
            lblTransChange.Size = new Size(223, 20);
            lblTransChange.TabIndex = 3;
            lblTransChange.Text = "+15 new transactions this month";
            // 
            // lblTransLabel
            // 
            lblTransLabel.AutoSize = true;
            lblTransLabel.Font = new Font("Segoe UI", 9F);
            lblTransLabel.ForeColor = Color.FromArgb(149, 165, 166);
            lblTransLabel.Location = new Point(27, 83);
            lblTransLabel.Name = "lblTransLabel";
            lblTransLabel.Size = new Size(43, 20);
            lblTransLabel.TabIndex = 2;
            lblTransLabel.Text = "Trans";
            // 
            // lblTransValue
            // 
            lblTransValue.AutoSize = true;
            lblTransValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTransValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblTransValue.Location = new Point(169, 25);
            lblTransValue.Name = "lblTransValue";
            lblTransValue.Size = new Size(81, 62);
            lblTransValue.TabIndex = 1;
            lblTransValue.Text = "15";
            // 
            // iconTrans
            // 
            iconTrans.BackColor = Color.FromArgb(231, 76, 60);
            iconTrans.Location = new Point(20, 30);
            iconTrans.Name = "iconTrans";
            iconTrans.Size = new Size(50, 50);
            iconTrans.TabIndex = 0;
            iconTrans.Paint += IconTrans_Paint;
            // 
            // cardUsers
            // 
            cardUsers.BackColor = Color.White;
            cardUsers.Controls.Add(lblUsersChange);
            cardUsers.Controls.Add(lblUsersLabel);
            cardUsers.Controls.Add(lblUsersValue);
            cardUsers.Controls.Add(iconUsers);
            cardUsers.Location = new Point(0, 20);
            cardUsers.Name = "cardUsers";
            cardUsers.Padding = new Padding(20);
            cardUsers.Size = new Size(340, 146);
            cardUsers.TabIndex = 0;
            // 
            // lblUsersChange
            // 
            lblUsersChange.AutoSize = true;
            lblUsersChange.Font = new Font("Segoe UI", 8.5F);
            lblUsersChange.ForeColor = Color.FromArgb(46, 204, 113);
            lblUsersChange.Location = new Point(25, 112);
            lblUsersChange.Name = "lblUsersChange";
            lblUsersChange.Size = new Size(169, 20);
            lblUsersChange.TabIndex = 3;
            lblUsersChange.Text = "+7 new users this month";
            // 
            // lblUsersLabel
            // 
            lblUsersLabel.AutoSize = true;
            lblUsersLabel.Font = new Font("Segoe UI", 9F);
            lblUsersLabel.ForeColor = Color.FromArgb(149, 165, 166);
            lblUsersLabel.Location = new Point(23, 83);
            lblUsersLabel.Name = "lblUsersLabel";
            lblUsersLabel.Size = new Size(44, 20);
            lblUsersLabel.TabIndex = 2;
            lblUsersLabel.Text = "Users";
            // 
            // lblUsersValue
            // 
            lblUsersValue.AutoSize = true;
            lblUsersValue.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblUsersValue.ForeColor = Color.FromArgb(52, 73, 94);
            lblUsersValue.Location = new Point(157, 25);
            lblUsersValue.Name = "lblUsersValue";
            lblUsersValue.Size = new Size(54, 62);
            lblUsersValue.TabIndex = 1;
            lblUsersValue.Text = "7";
            // 
            // iconUsers
            // 
            iconUsers.BackColor = Color.FromArgb(155, 89, 182);
            iconUsers.Location = new Point(20, 30);
            iconUsers.Name = "iconUsers";
            iconUsers.Size = new Size(50, 50);
            iconUsers.TabIndex = 0;
            iconUsers.Paint += IconUsers_Paint;
            // 
            // headerPanel
            // 
            headerPanel.Controls.Add(lblWelcome);
            headerPanel.Controls.Add(lblDashboard);
            headerPanel.Dock = DockStyle.Top;
            headerPanel.Location = new Point(40, 30);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1099, 70);
            headerPanel.TabIndex = 0;
            // 
            // lblWelcome
            // 
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 10F);
            lblWelcome.ForeColor = Color.FromArgb(149, 165, 166);
            lblWelcome.Location = new Point(3, 42);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(273, 23);
            lblWelcome.TabIndex = 1;
            lblWelcome.Text = "Welcome back, Âu Dương Tấn AD!";
            // 
            // lblDashboard
            // 
            lblDashboard.AutoSize = true;
            lblDashboard.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblDashboard.ForeColor = Color.FromArgb(44, 62, 80);
            lblDashboard.Location = new Point(0, 0);
            lblDashboard.Name = "lblDashboard";
            lblDashboard.Size = new Size(211, 50);
            lblDashboard.TabIndex = 0;
            lblDashboard.Text = "Dashboard";
            // 
            // UC_DashboardAD
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(mainPanel);
            Name = "UC_DashboardAD";
            Size = new Size(1200, 800);
            mainPanel.ResumeLayout(false);
            chartPanel.ResumeLayout(false);
            filterPanel.ResumeLayout(false);
            filterPanel.PerformLayout();
            kpiPanel.ResumeLayout(false);
            cardTickets.ResumeLayout(false);
            cardTickets.PerformLayout();
            cardTrans.ResumeLayout(false);
            cardTrans.PerformLayout();
            cardUsers.ResumeLayout(false);
            cardUsers.PerformLayout();
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Panel headerPanel;
        private System.Windows.Forms.Label lblDashboard;
        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Label lblDateTime;
        private System.Windows.Forms.Panel kpiPanel;
        private System.Windows.Forms.Panel cardUsers;
        private System.Windows.Forms.Panel iconUsers;
        private System.Windows.Forms.Label lblUsersValue;
        private System.Windows.Forms.Label lblUsersLabel;
        private System.Windows.Forms.Label lblUsersChange;
        private System.Windows.Forms.Panel cardTrans;
        private System.Windows.Forms.Label lblTransChange;
        private System.Windows.Forms.Label lblTransLabel;
        private System.Windows.Forms.Label lblTransValue;
        private System.Windows.Forms.Panel iconTrans;
        private System.Windows.Forms.Panel cardTickets;
        private System.Windows.Forms.Label lblTicketsChange;
        private System.Windows.Forms.Label lblTicketsLabel;
        private System.Windows.Forms.Label lblTicketsValue;
        private System.Windows.Forms.Panel iconTickets;
        private System.Windows.Forms.Panel chartPanel;
        private System.Windows.Forms.Panel filterPanel;
        private System.Windows.Forms.Label lblChartTitle;
        private System.Windows.Forms.ComboBox cmbFilter;
        private System.Windows.Forms.Panel chartContainer;
        private System.Windows.Forms.Label lblTicketsOpen;
        private System.Windows.Forms.Label lblTicketsResolved;
    }
}