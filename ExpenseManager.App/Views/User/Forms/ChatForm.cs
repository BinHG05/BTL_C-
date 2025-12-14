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
        private Label lblTyping;

        // Drag Form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        public ChatForm(IAIChatService aiChatService)
        {
            InitializeComponent();
            _aiChatService = aiChatService;

            // Add Mascot to Header
            try
            {
                string mascotPath = System.IO.Path.Combine(Application.StartupPath, "image", "mascot.png");
                if (System.IO.File.Exists(mascotPath))
                {
                    var pbHeaderMascot = new PictureBox();
                    pbHeaderMascot.Size = new Size(35, 35);
                    pbHeaderMascot.SizeMode = PictureBoxSizeMode.Zoom;
                    pbHeaderMascot.Image = Image.FromFile(mascotPath);
                    pbHeaderMascot.Location = new Point(10, 8); // Adjust position
                    pbHeaderMascot.BackColor = Color.Transparent;
                    
                    // Shift title
                    lblTitle.Location = new Point(50, 15);
                    
                    pnlHeader.Controls.Add(pbHeaderMascot);
                    // Ensure title is brought to front if needed, or added after
                }
            }
            catch { }
            
            // Init Typing Indicator
            lblTyping = new Label();
            lblTyping.Text = "AI đang soạn tin...";
            lblTyping.Font = new Font("Segoe UI", 9, FontStyle.Italic);
            lblTyping.ForeColor = Color.Gray;
            lblTyping.AutoSize = true;
            lblTyping.BackColor = Color.White; // Match message panel bg
            lblTyping.Location = new Point(15, this.ClientSize.Height - 75); // Just above input
            lblTyping.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            lblTyping.Visible = false;
            this.Controls.Add(lblTyping);
            lblTyping.BringToFront();

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

            lblTyping.Visible = true; // Show typing
            lblTyping.BringToFront();
            
            try
            {
                string response = await _aiChatService.SendMessageAsync(message);
                AddMessageToUI(new ChatMessage(response, false));
            }
            catch (Exception ex)
            {
                AddMessageToUI(new ChatMessage($"Lỗi: {ex.Message}", false));
            }
            finally
            {
                lblTyping.Visible = false; // Hide typing
            }
        }

        private void AddMessageToUI(ChatMessage msg)
        {
            // Container for the row (Full Width)
            var pnlRow = new Panel();
            pnlRow.Width = pnlMessages.ClientSize.Width - 25; // Minus scrollbar
            pnlRow.AutoSize = true;
            pnlRow.Padding = new Padding(0, 10, 0, 10); // Spacing between messages

            // Avatar for AI
            PictureBox pbAvatar = null;
            if (!msg.IsUser)
            {
                pbAvatar = new PictureBox();
                pbAvatar.Size = new Size(40, 40);
                pbAvatar.SizeMode = PictureBoxSizeMode.Zoom;
                try
                {
                    // Load mascot from file
                    string mascotPath = System.IO.Path.Combine(Application.StartupPath, "image", "mascot.png");
                    if (System.IO.File.Exists(mascotPath))
                        pbAvatar.Image = Image.FromFile(mascotPath);
                }
                catch { } // Ignore if fail
                pbAvatar.Location = new Point(5, 0); // Top-left of row
            }

            // Bubble Panel (Custom Painting)
            var pnlBubble = new Panel();
            // Calculate size based on text
            // We use a dummy label to measure text size
            var lblMeasure = new Label();
            lblMeasure.Font = new Font("Segoe UI", 11); // Larger font
            lblMeasure.Text = msg.Content;
            lblMeasure.MaximumSize = new Size(pnlRow.Width - 100, 0); // Max width constrained
            lblMeasure.AutoSize = true;
            var textSize = lblMeasure.GetPreferredSize(new Size(pnlRow.Width - 100, 0));
            
            pnlBubble.Size = new Size(textSize.Width + 40, textSize.Height + 30); // Add padding
            pnlBubble.Font = new Font("Segoe UI", 11);
            
            // Content Label inside Bubble
            var lblContent = new Label();
            lblContent.Text = msg.Content;
            lblContent.Font = new Font("Segoe UI", 11);
            lblContent.ForeColor = msg.IsUser ? Color.White : Color.Black;
            lblContent.BackColor = Color.Transparent; // Important for custom background
            lblContent.Dock = DockStyle.Fill;
            lblContent.Padding = new Padding(15);
            lblContent.TextAlign = ContentAlignment.MiddleLeft; // Vertically center text if single line? No, default TopLeft is better for multi-line.
            
            pnlBubble.Controls.Add(lblContent);

            // Positioning
            if (msg.IsUser)
            {
                // Align Right
                pnlBubble.Location = new Point(pnlRow.Width - pnlBubble.Width - 10, 0);
                pnlBubble.Paint += (s, e) => 
                {
                    var g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    // Pink/Purple Gradient for User (MoMo style)
                    using (var brush = new System.Drawing.Drawing2D.LinearGradientBrush(pnlBubble.ClientRectangle, 
                        Color.FromArgb(216, 45, 139), Color.FromArgb(171, 39, 134), 45f)) // MoMo Pink
                    {
                        var rect = pnlBubble.ClientRectangle;
                        rect.Width--; rect.Height--;
                        FillRoundedRectangle(g, brush, rect, 20);
                    }
                };
            }
            else
            {
                // Align Left (next to Avatar)
                pnlBubble.Location = new Point(55, 0); // 5 (margin) + 40 (avatar) + 10 (spacing)
                pnlBubble.Paint += (s, e) =>
                {
                    var g = e.Graphics;
                    g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    using (var brush = new SolidBrush(Color.White))
                    {
                        var rect = pnlBubble.ClientRectangle;
                        rect.Width--; rect.Height--;
                        FillRoundedRectangle(g, brush, rect, 20);
                        // Optional Border
                        using (var pen = new Pen(Color.FromArgb(230,230,230), 1))
                            DrawRoundedRectangle(g, pen, rect, 20);
                    }
                };
                
                if (pbAvatar != null) pnlRow.Controls.Add(pbAvatar);
            }

            pnlRow.Controls.Add(pnlBubble);
            pnlMessages.Controls.Add(pnlRow);
            pnlMessages.ScrollControlIntoView(pnlRow);
        }

        private void FillRoundedRectangle(Graphics g, Brush brush, Rectangle bounds, int cornerRadius)
        {
            if (g == null) return;
            using (var path = GetRoundedRect(bounds, cornerRadius))
            {
                g.FillPath(brush, path);
            }
        }

        private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle bounds, int cornerRadius)
        {
            if (g == null) return;
            using (var path = GetRoundedRect(bounds, cornerRadius))
            {
                g.DrawPath(pen, path);
            }
        }

        private System.Drawing.Drawing2D.GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // Top left arc  
            path.AddArc(arc, 180, 90);

            // Top right arc  
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc  
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc 
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
