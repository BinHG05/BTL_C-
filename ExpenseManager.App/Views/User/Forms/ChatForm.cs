using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Services;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User.Forms
{
    public partial class ChatForm : Form
    {
        private readonly IAIChatService _aiChatService;

        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public ChatForm(IAIChatService aiChatService)
        {
            InitializeComponent();
            _aiChatService = aiChatService;

            // Load history if any
            foreach (var msg in _aiChatService.GetHistory())
            {
                AddMessageToUI(msg);
            }

            // Initial greeting if empty
            if (_aiChatService.GetHistory().Count == 0)
            {
                AddMessageToUI(new ChatMessage("Xin chào! Tôi là trợ lý tài chính của bạn. Tôi có thể giúp gì cho bạn hôm nay?", false));
            }
        }

        private void pnlHeader_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Hide(); // Hide instead of Close to keep state if LayoutUser manages it, or Close if we re-create.
            // Since LayoutUser re-creates if Disposed, Close() is fine, but Hide() allows reuse if we kept the instance.
            // LayoutUser logic checks: if (_chatForm == null || _chatForm.IsDisposed)
            // So if we Close(), it disposes. If we Hide(), it doesn't.
            // Let's just Hide() to be faster on re-open?
            // But if we Hide(), LayoutUser needs to know it's not disposed.
            // LayoutUser: if (_chatForm == null || _chatForm.IsDisposed).
            // So Hide() is perfect.
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            _aiChatService.ClearHistory();
            pnlMessages.Controls.Clear();
            AddMessageToUI(new ChatMessage("Xin chào! Tôi là trợ lý tài chính của bạn. Tôi có thể giúp gì cho bạn hôm nay?", false));
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Prevent newline
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            string message = txtMessage.Text.Trim();
            if (string.IsNullOrEmpty(message)) return;

            txtMessage.Text = "";
            AddMessageToUI(new ChatMessage(message, true));

            // Show loading placeholder?
            var loadingMsg = new ChatMessage("...", false);
            // AddMessageToUI(loadingMsg); // Optional

            try
            {
                string response = await _aiChatService.SendMessageAsync(message);
                // Remove loading if added
                AddMessageToUI(new ChatMessage(response, false));
            }
            catch (Exception ex)
            {
                AddMessageToUI(new ChatMessage($"Lỗi: {ex.Message}", false));
            }
        }

        private void AddMessageToUI(ChatMessage msg)
        {
            // Container for the row (Full Width)
            var pnlRow = new Panel();
            pnlRow.Width = pnlMessages.ClientSize.Width - 25; // Minus scrollbar
            pnlRow.Padding = new Padding(0, 5, 0, 5);
            pnlRow.AutoSize = true;

            // Bubble (Label)
            var lblMsg = new Label();
            lblMsg.Text = msg.Content;
            lblMsg.Font = new Font("Segoe UI", 10);
            lblMsg.AutoSize = true;
            lblMsg.MaximumSize = new Size(pnlRow.Width - 60, 0); // Leave space for margins
            lblMsg.Padding = new Padding(10, 8, 10, 8); // Inner padding

            // Styling based on User vs Bot
            if (msg.IsUser)
            {
                lblMsg.BackColor = Color.FromArgb(0, 132, 255); // Messenger Blue
                lblMsg.ForeColor = Color.White;
                // Align Right
                // We need to add logic to position it to the right after it autosizes
                // We'll calculate location after adding to control? No, do it now.
                // Note: AutoSize happens when added or text set.
            }
            else
            {
                lblMsg.BackColor = Color.White; // Cleaner White
                lblMsg.ForeColor = Color.Black;
                // Add a border maybe? Or shadow?
                // For now just background.
                // Align Left
            }

            pnlRow.Controls.Add(lblMsg);
            pnlMessages.Controls.Add(pnlRow);

            // Force layout update to calculate sizes
            lblMsg.PerformLayout();
            pnlRow.PerformLayout();

            // Set Position
            if (msg.IsUser)
            {
                lblMsg.Location = new Point(pnlRow.Width - lblMsg.Width, 0);
            }
            else
            {
                lblMsg.Location = new Point(0, 0);
            }

            // Scroll to bottom
            pnlMessages.ScrollControlIntoView(pnlRow);
        }
    }
}
