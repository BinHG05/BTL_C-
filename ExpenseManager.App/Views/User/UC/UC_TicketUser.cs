using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_TicketUser : UserControl
    {
        public event EventHandler ChangeToCreateTicketRequested;

        private List<TicketData> mockTickets;
        private Button currentTabButton;

        public UC_TicketUser()
        {
            InitializeComponent();
            InitializeMockData();
            LoadTickets();
            SetActiveTab(btnSupport);

            // Add underline for active tab
            AddTabUnderline();
        }

        private void AddTabUnderline()
        {
            // Add blue underline to Support tab
            Panel underline = new Panel
            {
                Height = 3,
                BackColor = Color.FromArgb(101, 109, 255),
                Dock = DockStyle.Bottom
            };
            btnSupport.Controls.Add(underline);
        }

        private void SetActiveTab(Button activeButton)
        {
            // Reset all tabs
            btnProfile.ForeColor = Color.Gray;
            btnProfile.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnCategories.ForeColor = Color.Gray;
            btnCategories.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnSupport.ForeColor = Color.Gray;
            btnSupport.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            // Set active tab
            activeButton.ForeColor = Color.FromArgb(101, 109, 255);
            activeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            currentTabButton = activeButton;
        }

        private void InitializeMockData()
        {
            mockTickets = new List<TicketData>
            {
                new TicketData
                {
                    Type = "General",
                    Subject = "nhìn chung là khá ổn rồi đấy...",
                    Date = "Posted on 15 November 2025"
                },
                new TicketData
                {
                    Type = "Others",
                    Subject = "sao không thêm mấy cái category đi, thêm tay my...",
                    Date = "Posted on 15 November 2025"
                },
                new TicketData
                {
                    Type = "General",
                    Subject = "giao diện khá đẹp nhưng cần thêm tính năng search",
                    Date = "Posted on 14 November 2025"
                },
                new TicketData
                {
                    Type = "Bug Report",
                    Subject = "lỗi khi export dữ liệu ra Excel",
                    Date = "Posted on 13 November 2025"
                },
                new TicketData
                {
                    Type = "Feature Request",
                    Subject = "muốn có dark mode cho ứng dụng",
                    Date = "Posted on 12 November 2025"
                }
            };
        }

        private void LoadTickets()
        {
            ticketListPanel.Controls.Clear();

            foreach (var ticket in mockTickets)
            {
                Panel ticketItem = CreateTicketItem(ticket);
                ticketListPanel.Controls.Add(ticketItem);
            }
        }

        private Panel CreateTicketItem(TicketData ticket)
        {
            Panel itemPanel = new Panel
            {
                Width = ticketListPanel.Width - 40,
                Height = 90,
                BackColor = Color.White,
                Margin = new Padding(0, 0, 0, 15),
                Padding = new Padding(20, 15, 20, 15)
            };

            // Type Label (styled as badge)
            Label lblType = new Label
            {
                Text = ticket.Type,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(101, 109, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            // Subject Label
            Label lblSubject = new Label
            {
                Text = ticket.Subject,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = Color.Black,
                Location = new Point(20, 40),
                AutoSize = true,
                MaximumSize = new Size(itemPanel.Width - 40, 0)
            };

            // Date Label
            Label lblDate = new Label
            {
                Text = ticket.Date,
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = Color.Gray,
                Location = new Point(20, 63),
                AutoSize = true
            };

            itemPanel.Controls.Add(lblType);
            itemPanel.Controls.Add(lblSubject);
            itemPanel.Controls.Add(lblDate);

            // Add hover effect
            itemPanel.MouseEnter += (s, e) => itemPanel.BackColor = Color.FromArgb(250, 250, 250);
            itemPanel.MouseLeave += (s, e) => itemPanel.BackColor = Color.White;

            return itemPanel;
        }
        private void LoadContent(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }
        private void BtnCreateTicket_Click(object sender, EventArgs e)
        {
            // Raise event để thông báo cho Form/UC cha
            LoadContent(new UC_CreateTicketUser());
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadContent(new UC_Settings());
        }
    }

    // Class để lưu thông tin ticket
    public class TicketData
    {
        public string Type { get; set; }
        public string Subject { get; set; }
        public string Date { get; set; }
    }
}