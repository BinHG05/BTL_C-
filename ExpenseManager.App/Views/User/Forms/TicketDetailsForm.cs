using System;
using System.Drawing;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.Forms
{
    public partial class TicketDetailsForm : System.Windows.Forms.Form
    {
        private Ticket _ticket;

        public TicketDetailsForm(Ticket ticket)
        {
            _ticket = ticket;
            //InitializeComponent();
            BuildLayout();
            LoadTicketDetails();
        }

        private void BuildLayout()
        {
            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Size = new Size(880, 650);
            this.BackColor = System.Drawing.Color.White;
            this.Padding = new Padding(10);

            // Main Panel
            Panel mainPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = System.Drawing.Color.White
            };

            // Close Button
            IconButton btnClose = new IconButton
            {
                IconChar = IconChar.Xmark,
                IconColor = System.Drawing.Color.Gray,
                IconSize = 24,
                Size = new Size(40, 40),
                Location = new Point(this.Width - 70, 20),
                FlatStyle = FlatStyle.Flat,
                BackColor = System.Drawing.Color.Transparent,
                Cursor = Cursors.Hand
            };
            btnClose.FlatAppearance.BorderSize = 0;
            btnClose.Click += (s, e) => this.Close();

            // Title
            Label lblTitle = new Label
            {
                Text = "Ticket Details",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(30, 30),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(30, 30, 30)
            };

            // Divider
            Panel divider1 = new Panel
            {
                Height = 1,
                BackColor = System.Drawing.Color.FromArgb(230, 230, 230),
                Location = new Point(30, 85),
                Width = this.Width - 60
            };

            // User Info Section
            Label lblUserName = new Label
            {
                Text = "User Name",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(30, 110),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            Label lblUserNameValue = new Label
            {
                Text = _ticket?.User?.FullName ?? "N/A",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(30, 138),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };

            Label lblEmail = new Label
            {
                Text = "Email",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(450, 110),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            Label lblEmailValue = new Label
            {
                Text = _ticket?.User?.Email ?? "N/A",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(450, 138),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };

            // My Question Section
            Label lblMyQuestion = new Label
            {
                Text = "My Question",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(30, 185),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            TextBox txtDescription = new TextBox
            {
                Text = _ticket?.Description ?? "",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(30, 213),
                Size = new Size(this.Width - 60, 80),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60),
                Padding = new Padding(10)
            };

            // Question Type and Status
            Label lblQuestionType = new Label
            {
                Text = "Question Type",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(30, 320),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            Label lblQuestionTypeValue = new Label
            {
                Text = _ticket?.QuestionType ?? "N/A",
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(30, 348),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60)
            };

            Label lblStatus = new Label
            {
                Text = "Status",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(450, 320),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            Label lblStatusValue = new Label
            {
                Text = _ticket?.Status ?? "N/A",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(450, 348),
                AutoSize = true,
                ForeColor = _ticket?.Status == "Open" ? System.Drawing.Color.Orange : System.Drawing.Color.Green
            };

            // Admin Note Section
            Label lblAdminNote = new Label
            {
                Text = "Admin Note",
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                Location = new Point(30, 395),
                AutoSize = true,
                ForeColor = System.Drawing.Color.FromArgb(40, 53, 147)
            };

            TextBox txtAdminNote = new TextBox
            {
                Text = string.IsNullOrEmpty(_ticket?.AdminNote) ? "" : _ticket.AdminNote,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                Location = new Point(30, 423),
                Size = new Size(this.Width - 60, 80),
                Multiline = true,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                BackColor = System.Drawing.Color.FromArgb(248, 249, 250),
                ForeColor = System.Drawing.Color.FromArgb(60, 60, 60),
                Padding = new Padding(10)
            };

            // Timestamps
            Label lblCreated = new Label
            {
                Text = $"Created: {_ticket?.CreatedAt.ToString("HH:mm:ss dd/MM/yyyy") ?? "N/A"}",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Location = new Point(30, 530),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };

            Label lblUpdated = new Label
            {
                Text = $"Updated: {_ticket?.UpdatedAt?.ToString("HH:mm:ss dd/MM/yyyy") ?? "N/A"}",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                Location = new Point(450, 530),
                AutoSize = true,
                ForeColor = System.Drawing.Color.Gray
            };

            // Close Button at bottom
            Button btnCloseBottom = new Button
            {
                Text = "Close",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(120, 45),
                Location = new Point(this.Width - 150, 565),
                BackColor = System.Drawing.Color.FromArgb(108, 117, 125),
                ForeColor = System.Drawing.Color.White,
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand
            };
            btnCloseBottom.FlatAppearance.BorderSize = 0;
            btnCloseBottom.Click += (s, e) => this.Close();

            // Add all controls
            mainPanel.Controls.Add(btnClose);
            mainPanel.Controls.Add(lblTitle);
            mainPanel.Controls.Add(divider1);
            mainPanel.Controls.Add(lblUserName);
            mainPanel.Controls.Add(lblUserNameValue);
            mainPanel.Controls.Add(lblEmail);
            mainPanel.Controls.Add(lblEmailValue);
            mainPanel.Controls.Add(lblMyQuestion);
            mainPanel.Controls.Add(txtDescription);
            mainPanel.Controls.Add(lblQuestionType);
            mainPanel.Controls.Add(lblQuestionTypeValue);
            mainPanel.Controls.Add(lblStatus);
            mainPanel.Controls.Add(lblStatusValue);
            mainPanel.Controls.Add(lblAdminNote);
            mainPanel.Controls.Add(txtAdminNote);
            mainPanel.Controls.Add(lblCreated);
            mainPanel.Controls.Add(lblUpdated);
            mainPanel.Controls.Add(btnCloseBottom);

            this.Controls.Add(mainPanel);

            // Add shadow effect
            this.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle,
                    System.Drawing.Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    System.Drawing.Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    System.Drawing.Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid,
                    System.Drawing.Color.FromArgb(200, 200, 200), 1, ButtonBorderStyle.Solid);
            };
        }

        private void LoadTicketDetails()
        {
            // Details are loaded in InitializeComponent
        }

        private void InitializeComponent()
        {

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            // Add semi-transparent overlay effect
            Form overlay = new Form
            {
                FormBorderStyle = FormBorderStyle.None,
                Opacity = 0.5,
                BackColor = System.Drawing.Color.Black,
                WindowState = FormWindowState.Maximized,
                TopMost = false,
                ShowInTaskbar = false,
                Owner = this.Owner
            };
            overlay.Show();
            this.FormClosed += (s, e2) => overlay.Close();
        }
    }
}