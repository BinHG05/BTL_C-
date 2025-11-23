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
            this.Close();
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

            // Show loading or typing indicator?
            // For now, just wait.

            try
            {
                string response = await _aiChatService.SendMessageAsync(message);
                AddMessageToUI(new ChatMessage(response, false));
            }
            catch (Exception ex)
            {
                AddMessageToUI(new ChatMessage($"Lỗi: {ex.Message}", false));
            }
        }

        private void AddMessageToUI(ChatMessage msg)
        {
            var pnlMsg = new Panel();
            pnlMsg.AutoSize = true;
            pnlMsg.Padding = new Padding(10);
            pnlMsg.Margin = new Padding(0, 5, 0, 5);
            pnlMsg.MaximumSize = new Size(pnlMessages.Width - 30, 0);

            var lblMsg = new Label();
            lblMsg.Text = msg.Content;
            lblMsg.AutoSize = true;
            lblMsg.MaximumSize = new Size(pnlMessages.Width - 50, 0);
            lblMsg.Font = new Font("Segoe UI", 10);

            pnlMsg.Controls.Add(lblMsg);

            if (msg.IsUser)
            {
                pnlMsg.BackColor = Color.FromArgb(220, 248, 255); // Light Blue
                lblMsg.ForeColor = Color.Black;
                // Align Right (Hack: FlowLayoutPanel is TopDown, so we set Margin left to push it right?)
                // Actually FlowLayoutPanel doesn't support easy right align for individual items in TopDown.
                // We can set the Panel Width to full and dock the label right? No.
                // We'll just use color to distinguish for now.
                // Or we can use a TableLayoutPanel inside or just set the FlowDirection to TopDown and handle alignment by padding?
                // Let's keep it simple: User = Blue, AI = Gray.
            }
            else
            {
                pnlMsg.BackColor = Color.FromArgb(240, 240, 240); // Light Gray
                lblMsg.ForeColor = Color.Black;
            }

            pnlMessages.Controls.Add(pnlMsg);
            pnlMessages.ScrollControlIntoView(pnlMsg);
        }
    }
}
