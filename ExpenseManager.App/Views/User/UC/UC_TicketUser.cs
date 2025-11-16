using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User.Forms;
using FontAwesome.Sharp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.UC
{
    public partial class UC_TicketUser : UserControl, ITicketUserView
    {
        private TicketUserPresenter _presenter;
        private Button currentTabButton;
        private ExpenseDbContext _context;

        // ITicketUserView implementation
        public string UserId => CurrentUserSession.CurrentUser?.UserId;
        public event EventHandler LoadTickets;
        public event EventHandler CreateNewTicketRequested;

        public UC_TicketUser()
        {
            InitializeComponent();
            InitializePresenter();
            SetActiveTab(btnSupport);
            AddTabUnderline();

            // Trigger load tickets
            this.Load += (s, e) => LoadTickets?.Invoke(this, EventArgs.Empty);
        }

        private void InitializePresenter()
        {
            // Initialize dependencies (you may use DI container instead)
            _context = new ExpenseDbContext();
            var repository = new TicketUserRepository(_context);
            var service = new TicketUserServices(repository);
            _presenter = new TicketUserPresenter(this, service);
        }

        public void DisplayTickets(IEnumerable<Ticket> tickets)
        {
            ticketListPanel.Controls.Clear();

            if (tickets == null || !tickets.Any())
            {
                var noDataLabel = new Label
                {
                    Text = "Chưa có ticket nào",
                    Font = new Font("Segoe UI", 12F, FontStyle.Regular),
                    ForeColor = System.Drawing.Color.Gray,
                    AutoSize = true,
                    Padding = new Padding(20)
                };
                ticketListPanel.Controls.Add(noDataLabel);
                return;
            }

            foreach (var ticket in tickets)
            {
                Panel ticketItem = CreateTicketItem(ticket);
                ticketListPanel.Controls.Add(ticketItem);
            }
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetLoading(bool isLoading)
        {
            btnCreateTicket.Enabled = !isLoading;
            ticketListPanel.Enabled = !isLoading;

            if (isLoading)
            {
                Cursor = Cursors.WaitCursor;
            }
            else
            {
                Cursor = Cursors.Default;
            }
        }

        private void AddTabUnderline()
        {
            Panel underline = new Panel
            {
                Height = 3,
                BackColor = System.Drawing.Color.FromArgb(101, 109, 255),
                Dock = DockStyle.Bottom
            };
            btnSupport.Controls.Add(underline);
        }

        private void SetActiveTab(Button activeButton)
        {
            btnProfile.ForeColor = System.Drawing.Color.Gray;
            btnProfile.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnCategories.ForeColor = System.Drawing.Color.Gray;
            btnCategories.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btnSupport.ForeColor = System.Drawing.Color.Gray;
            btnSupport.Font = new Font("Segoe UI", 11F, FontStyle.Regular);

            activeButton.ForeColor = System.Drawing.Color.FromArgb(101, 109, 255);
            activeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            currentTabButton = activeButton;
        }

        private Panel CreateTicketItem(Ticket ticket)
        {
            Panel itemPanel = new Panel
            {
                Width = ticketListPanel.Width - 40,
                Height = 110,
                BackColor = System.Drawing.Color.White,
                Margin = new Padding(0, 0, 0, 15),
                Padding = new Padding(20, 15, 20, 15)
            };

            // Type Label (styled as badge)
            Label lblType = new Label
            {
                Text = ticket.QuestionType,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = System.Drawing.Color.FromArgb(101, 109, 255),
                Location = new Point(20, 15),
                AutoSize = true
            };

            // Status Label
            Label lblStatus = new Label
            {
                Text = ticket.Status,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = ticket.Status == "Open" ? System.Drawing.Color.Orange : System.Drawing.Color.Green,
                Location = new Point(120, 15),
                AutoSize = true
            };

            // Description Label
            Label lblDescription = new Label
            {
                Text = ticket.Description.Length > 80
                    ? ticket.Description.Substring(0, 80) + "..."
                    : ticket.Description,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                ForeColor = System.Drawing.Color.Black,
                Location = new Point(20, 45),
                MaximumSize = new Size(itemPanel.Width - 40, 40),
                AutoSize = true
            };

            // Date Label
            Label lblDate = new Label
            {
                Text = $"Posted on {ticket.CreatedAt:dd MMMM yyyy}",
                Font = new Font("Segoe UI", 9F, FontStyle.Regular),
                ForeColor = System.Drawing.Color.Gray,
                Location = new Point(20, 80),
                AutoSize = true
            };

            // View Button
            Button btnView = new Button
            {
                Text = "View",
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Size = new Size(100, 40),
                Location = new Point(itemPanel.Width - 130, 35),
                BackColor = System.Drawing.Color.Transparent,
                ForeColor = System.Drawing.Color.FromArgb(101, 109, 255),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Tag = ticket // Store ticket object in Tag
            };
            btnView.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(101, 109, 255);
            btnView.FlatAppearance.BorderSize = 2;
            btnView.Click += BtnView_Click;

            // Hover effect for View button
            btnView.MouseEnter += (s, e) =>
            {
                btnView.BackColor = System.Drawing.Color.FromArgb(101, 109, 255);
                btnView.ForeColor = System.Drawing.Color.White;
            };
            btnView.MouseLeave += (s, e) =>
            {
                btnView.BackColor = System.Drawing.Color.Transparent;
                btnView.ForeColor = System.Drawing.Color.FromArgb(101, 109, 255);
            };

            itemPanel.Controls.Add(lblType);
            itemPanel.Controls.Add(lblStatus);
            itemPanel.Controls.Add(lblDescription);
            itemPanel.Controls.Add(lblDate);
            itemPanel.Controls.Add(btnView);

            // Add hover effect
            itemPanel.MouseEnter += (s, e) => itemPanel.BackColor = System.Drawing.Color.FromArgb(250, 250, 250);
            itemPanel.MouseLeave += (s, e) => itemPanel.BackColor = System.Drawing.Color.White;

            return itemPanel;
        }
        private async void BtnView_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn?.Tag is Ticket ticket)
            {
                try
                {
                    // Load full ticket with User data
                    var fullTicket = await _context.Tickets
                        .Include(t => t.User)
                        .FirstOrDefaultAsync(t => t.TicketId == ticket.TicketId);

                    if (fullTicket != null)
                    {
                        TicketDetailsForm detailsForm = new TicketDetailsForm(fullTicket);
                        detailsForm.ShowDialog(this.FindForm());
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin ticket!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải thông tin ticket: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void LoadContent(UserControl uc)
        {
            this.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            this.Controls.Add(uc);
        }

        private void BtnCreateTicket_Click(object sender, EventArgs e)
        {
            var createTicketView = new UC_CreateTicketUser();
            LoadContent(createTicketView);
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            LoadContent(new UC_Settings());
        }
    }
}