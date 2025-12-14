using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.Admin.UC;
using ExpenseManager.App.Views.User;
using ExpenseManager.App.Views.User.Forms;
using ExpenseManager.App.Views.User.UC;
using FontAwesome.Sharp;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.Sidebar
{
    public partial class LayoutUser : Form
    {
        private IconButton currentButton;

        private IconButton btnChatbot;
        private ChatForm _chatForm;

        // =========================================================
        // ✅ CẬP NHẬT MÀU SẮC (Đã sửa lại màu chữ mặc định)
        // =========================================================
        private Color sidebarColor = Color.FromArgb(15, 23, 42);     // Màu nền sidebar (Dark Navy)
        private Color activeColor = Color.FromArgb(99, 102, 241);      // Màu tím/indigo khi Active
        private Color hoverColor = Color.FromArgb(30, 41, 59);         // Màu khi di chuột (Sáng hơn nền một chút)
        private Color defaultBg = Color.Transparent;

        // 🔥 ĐÂY LÀ DÒNG QUAN TRỌNG ĐÃ SỬA:
        // Đổi từ màu xám đậm (71, 85, 105) sang màu trắng bạc (226, 232, 240) để nổi bật trên nền tối
        private Color defaultTextColor = Color.FromArgb(226, 232, 240);

        private Color activeTextColor = Color.White;

        private string _currentUserId;

        private ContextMenuStrip profileMenu;
        private ToolStripMenuItem itemSettings;
        private ToolStripMenuItem itemLogout;

        public LayoutUser()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeUserSession();
            InitializeProfileMenu();
        }

        private void InitializeUserSession()
        {
            if (CurrentUserSession.CurrentUser != null)
            {
                _currentUserId = CurrentUserSession.CurrentUser.UserId;
            }
            else
            {
                MessageBox.Show("Phiên đăng nhập đã hết hạn hoặc không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void InitializeCustomComponents()
        {
            try
            {
                string logoPath = Path.Combine(Application.StartupPath, "image", "logo.png");
                if (File.Exists(logoPath))
                {
                    logoPic.Image = Image.FromFile(logoPath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot load logo: " + ex.Message);
            }

            ApplyRoundedCorners();
            SetupButtonHoverEffects();
            CenterPanelInHeader();
            headerPanel.Resize += (s, e) => CenterPanelInHeader();
            RoundProfileButton();

            this.btnAddTransaction.Click += new System.EventHandler(this.BtnAddTransaction_Click);
            //Tạo button Chatbot
            CreateChatbotButton();
        }

        private void InitializeProfileMenu()
        {
            profileMenu = new ContextMenuStrip();
            profileMenu.Font = new Font("Segoe UI", 10F);
            profileMenu.RenderMode = ToolStripRenderMode.Professional;
            profileMenu.Renderer = new CustomMenuRenderer();

            string userName = CurrentUserSession.CurrentUser?.FullName ?? "User";
            string userEmail = CurrentUserSession.CurrentUser?.Email ?? "Email";

            var headerItem = new ToolStripMenuItem();
            headerItem.Text = $"{userName}\n{userEmail}";
            headerItem.Enabled = false;
            headerItem.ForeColor = Color.Gray;
            headerItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            itemSettings = new ToolStripMenuItem("Cài đặt", GetIconBitmap(IconChar.Gear, 16, Color.Black));
            itemSettings.Click += BtnSettings_Click;

            itemLogout = new ToolStripMenuItem("Đăng xuất", GetIconBitmap(IconChar.SignOutAlt, 16, Color.Red));
            itemLogout.ForeColor = Color.Red;
            itemLogout.Click += LogoutMenuItem_Click;

            profileMenu.Items.Add(headerItem);
            profileMenu.Items.Add(new ToolStripSeparator());
            profileMenu.Items.Add(itemSettings);
            profileMenu.Items.Add(new ToolStripSeparator());
            profileMenu.Items.Add(itemLogout);
        }

        private Bitmap GetIconBitmap(IconChar icon, int size, Color color)
        {
            using (var iconPic = new IconPictureBox())
            {
                iconPic.IconChar = icon;
                iconPic.IconSize = size;
                iconPic.IconColor = color;
                iconPic.BackColor = Color.Transparent;
                iconPic.Size = new Size(size, size);
                iconPic.SizeMode = PictureBoxSizeMode.CenterImage;

                var bmp = new Bitmap(size, size);
                iconPic.DrawToBitmap(bmp, new Rectangle(0, 0, size, size));
                return bmp;
            }
        }

        private void CreateChatbotButton()
        {
            btnChatbot = new IconButton();
            btnChatbot.IconChar = IconChar.Robot;
            btnChatbot.IconColor = Color.White;
            btnChatbot.IconFont = IconFont.Auto;
            btnChatbot.IconSize = 30;
            btnChatbot.BackColor = Color.FromArgb(41, 128, 185);
            btnChatbot.FlatStyle = FlatStyle.Flat;
            btnChatbot.FlatAppearance.BorderSize = 0;
            btnChatbot.Size = new Size(50, 50);
            btnChatbot.Location = new Point(this.ClientSize.Width - 70, this.ClientSize.Height - 70);
            btnChatbot.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            // Make it circular
            btnChatbot.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, 50, 50, 50, 50));

            btnChatbot.Click += BtnChatbot_Click;
            this.Controls.Add(btnChatbot);
            btnChatbot.BringToFront();
        }
        private void BtnChatbot_Click(object sender, EventArgs e)
        {
            try
            {
                if (_chatForm == null || _chatForm.IsDisposed)
                {
                    _chatForm = Program.ServiceProvider.GetRequiredService<ChatForm>();
                    _chatForm.Show();
                }
                else
                {
                    if (_chatForm.WindowState == FormWindowState.Minimized)
                    {
                        _chatForm.WindowState = FormWindowState.Normal;
                    }
                    _chatForm.Show(); // ✅ Đảm bảo hiện lại nếu form bị Hide()
                    _chatForm.BringToFront();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở Chatbot: " + ex.Message);
            }
        }

        private void BtnProfileTop_Click(object sender, EventArgs e)
        {
            if (profileMenu.Items.Count > 0)
            {
                string userName = CurrentUserSession.CurrentUser?.FullName ?? "User";
                string userEmail = CurrentUserSession.CurrentUser?.Email ?? "Email";
                profileMenu.Items[0].Text = $"{userName}\n{userEmail}";
            }
            Point menuLocation = btnProfileTop.PointToScreen(new Point(-150, btnProfileTop.Height + 5));
            profileMenu.Show(menuLocation);
        }

        private void BtnAddTransaction_Click(object sender, EventArgs e)
        {
            try
            {
                var addForm = Program.ServiceProvider.GetRequiredService<AddTransactionForm>();
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    if (currentButton == btnDashboard) BtnDashboard_Click(null, null);
                    else if (currentButton == btnWallet) BtnWallet_Click(null, null);
                    else if (currentButton == btnBudget) BtnBudget_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Không thể mở form thêm giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyRoundedCorners()
        {
            btnAddTransaction.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddTransaction.Width, btnAddTransaction.Height, 10, 10));
            searchBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, searchBox.Width, searchBox.Height, 10, 10));
            btnSearchInside.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSearchInside.Width, btnSearchInside.Height, 8, 8));
        }

        private void RoundProfileButton()
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, btnProfileTop.Width, btnProfileTop.Height);
            btnProfileTop.Region = new Region(path);
        }

        // ✅ CẬP NHẬT: Hover effects sử dụng màu chữ sáng
        private void SetupButtonHoverEffects()
        {
            var buttons = new[] { btnDashboard, btnWallet, btnBudget, btnGoals, btnAnalytics, btnSettings };

            foreach (var btn in buttons)
            {
                // Đảm bảo ban đầu nút có màu đúng
                if (btn != currentButton)
                {
                    btn.ForeColor = defaultTextColor;
                    btn.IconColor = defaultTextColor;
                }

                btn.MouseEnter += (s, e) =>
                {
                    if (btn != currentButton)
                    {
                        btn.BackColor = hoverColor;
                        // Khi hover có thể giữ màu trắng hoặc đổi sang màu tím nhạt tùy bạn, 
                        // ở đây tôi giữ màu trắng cho dễ nhìn
                        btn.ForeColor = Color.White;
                        btn.IconColor = Color.White;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentButton)
                    {
                        btn.BackColor = defaultBg;
                        // Khi rời chuột, trả về màu mặc định (Bây giờ là màu sáng)
                        btn.ForeColor = defaultTextColor;
                        btn.IconColor = defaultTextColor;
                    }
                };
            }
        }

        private void CenterPanelInHeader()
        {
            centerPanel.Left = (headerPanel.Width - centerPanel.Width) / 2;
            centerPanel.Top = (headerPanel.Height - centerPanel.Height) / 2;
        }

        // ✅ CẬP NHẬT: Active button logic
        private void ActivateButton(IconButton btn)
        {
            if (btn == currentButton) return;

            if (currentButton != null)
            {
                // Trả nút cũ về màu mặc định (Màu sáng)
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = defaultTextColor;
                currentButton.IconColor = defaultTextColor;
            }

            currentButton = btn;
            // Nút đang chọn (Active)
            btn.BackColor = activeColor;
            btn.ForeColor = activeTextColor;
            btn.IconColor = activeTextColor;
        }

        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
        }

        // ============== BUTTON CLICK EVENTS ==============

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            // 1. Đổi màu nút trên Sidebar
            ActivateButton(btnDashboard);

            // 2. Tạo mới Dashboard
            var dashboard = new UC_Dashboard();

            // 3. [QUAN TRỌNG] Truyền UserID vào để Dashboard biết lấy dữ liệu của ai
            // Biến _currentUserId đã được bạn lấy từ Session ở đầu Form LayoutUser rồi
            if (!string.IsNullOrEmpty(_currentUserId))
            {
                dashboard.SetUserId(_currentUserId);
            }
            else
            {
                // Phòng trường hợp lỗi Session (hiếm khi xảy ra nếu đã login)
                MessageBox.Show("Lỗi: Không tìm thấy ID người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // 4. Hiển thị Dashboard lên màn hình chính
            LoadContent(dashboard);
        }

        private void BtnWallet_Click(object sender, EventArgs e)
        {
            ActivateButton(btnWallet);
            LoadContent(new UC_Wallet());
        }

        private void BtnBudget_Click(object sender, EventArgs e)
        {
            ActivateButton(btnBudget);

            try
            {
                // ✅ Dispose control cũ trước
                if (contentPanel.Controls.Count > 0)
                {
                    var oldControl = contentPanel.Controls[0];
                    contentPanel.Controls.Clear();

                    if (oldControl != null && !oldControl.IsDisposed)
                    {
                        oldControl.Dispose();
                    }
                }

                // ✅ TẠO MỚI trực tiếp, KHÔNG dùng GetService
                var uc = new UC_Budget();

                // ✅ Check nếu disposed
                if (uc.IsDisposed)
                {
                    MessageBox.Show("Cannot create Budget control", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadContent(uc);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải trang Ngân sách: " + ex.Message + "\n" + ex.StackTrace,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnGoals_Click(object sender, EventArgs e)
        {
            ActivateButton(btnGoals);

            try
            {
                var goalService = Program.ServiceProvider.GetRequiredService<IGoalService>();
                var goalsPresenter = new GoalsPresenter(goalService);

                if (!string.IsNullOrEmpty(_currentUserId))
                {
                    goalsPresenter.SetUserId(_currentUserId);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng.");
                    return;
                }

                LoadContent(new UC_Goals(goalsPresenter));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải trang Mục tiêu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            ActivateButton(btnAnalytics);
            LoadContent(new UC_Analytics());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSettings);
            LoadContent(new UC_Settings());
        }

        private void LayoutAdmin_Load(object sender, EventArgs e)
        {
            BtnDashboard_Click(btnDashboard, EventArgs.Empty);
        }

        private void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentUserSession.ClearUser();
                var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Close();
            }
        }

        private void btnSearchInside_Click_1(object sender, EventArgs e)
        {
            LoadContent(new UC_Search());
        }

        // ============== MENU RENDERER CLASSES ==============

        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }

            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected)
                {
                    base.OnRenderMenuItemBackground(e);
                }
                else
                {
                    Rectangle rc = new Rectangle(Point.Empty, e.Item.Size);
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(240, 240, 245)), rc);
                }
            }

            protected override void OnRenderSeparator(ToolStripSeparatorRenderEventArgs e)
            {
                Rectangle rc = new Rectangle(10, 3, e.Item.Width - 20, 1);
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(220, 220, 220)), rc);
            }
        }

        public class CustomColorTable : ProfessionalColorTable
        {
            public override Color MenuItemSelected => Color.FromArgb(240, 240, 245);
            public override Color MenuItemSelectedGradientBegin => Color.FromArgb(240, 240, 245);
            public override Color MenuItemSelectedGradientEnd => Color.FromArgb(240, 240, 245);
            public override Color MenuItemBorder => Color.Transparent;
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
    }
}