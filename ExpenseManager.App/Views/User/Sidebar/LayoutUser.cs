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
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
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

        private Color sidebarColor = Color.FromArgb(15, 23, 42);
        private Color activeColor = Color.FromArgb(99, 102, 241);
        private Color hoverColor = Color.FromArgb(30, 41, 59);
        private Color defaultBg = Color.Transparent;

        private Color defaultTextColor = Color.FromArgb(226, 232, 240);
        private Color activeTextColor = Color.White;

        private string _currentUserId;

        private ContextMenuStrip profileMenu;
        private ToolStripMenuItem itemSettings;
        private ToolStripMenuItem itemLogout;

        private bool _isLoading = false;
        private DateTime _lastClickTime = DateTime.MinValue;
        private const int CLICK_DELAY_MS = 300;

        private Panel loadingOverlay;
        private Timer spinnerTimer;
        private int spinnerAngle = 0;

        public LayoutUser()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeUserSession();
            InitializeProfileMenu();
            CreateLoadingOverlay(); 

            this.FormClosing += LayoutUser_FormClosing;
        }

        private void LayoutUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                spinnerTimer?.Stop();
                spinnerTimer?.Dispose();
                loadingOverlay?.Dispose();
            }
            catch (Exception ex)
            {
            }
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
            CreateChatbotButton();
        }

        private void CreateLoadingOverlay()
        {
            loadingOverlay = new Panel
            {
                BackColor = Color.FromArgb(200, 255, 255, 255), 
                Dock = DockStyle.Fill,
                Visible = false
            };

            loadingOverlay.Paint += LoadingOverlay_Paint;

            contentPanel.Controls.Add(loadingOverlay);
            loadingOverlay.BringToFront();

            spinnerTimer = new Timer
            {
                Interval = 50 
            };
            spinnerTimer.Tick += SpinnerTimer_Tick;
        }

        private void LoadingOverlay_Paint(object sender, PaintEventArgs e)
        {
            if (!loadingOverlay.Visible) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int centerX = loadingOverlay.Width / 2;
            int centerY = loadingOverlay.Height / 2;
            int radius = 40; 
            int thickness = 6; 

            using (Pen bgPen = new Pen(Color.FromArgb(100, 200, 200, 200), thickness))
            {
                g.DrawEllipse(bgPen,
                    centerX - radius,
                    centerY - radius,
                    radius * 2,
                    radius * 2);
            }

            using (Pen arcPen = new Pen(Color.FromArgb(99, 102, 241), thickness))
            {
                arcPen.StartCap = LineCap.Round;
                arcPen.EndCap = LineCap.Round;

                g.DrawArc(arcPen,
                    centerX - radius,
                    centerY - radius,
                    radius * 2,
                    radius * 2,
                    spinnerAngle,
                    270);
            }

            string loadingText = "Đang tải...";
            using (Font font = new Font("Segoe UI", 12, FontStyle.Regular))
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(100, 100, 100)))
            {
                SizeF textSize = g.MeasureString(loadingText, font);
                g.DrawString(loadingText, font, brush,
                    centerX - textSize.Width / 2,
                    centerY + radius + 20);
            }
        }

        private void SpinnerTimer_Tick(object sender, EventArgs e)
        {
            spinnerAngle += 10; 
            if (spinnerAngle >= 360)
                spinnerAngle = 0;

            loadingOverlay.Invalidate();
        }

        private void ShowLoading()
        {
            loadingOverlay.Visible = true;
            loadingOverlay.BringToFront();
            spinnerTimer.Start();

            DisableNavigationButtons();
        }

        private void HideLoading()
        {
            spinnerTimer.Stop();
            loadingOverlay.Visible = false;

            EnableNavigationButtons();
        }

        private void DisableNavigationButtons()
        {
            btnDashboard.Enabled = false;
            btnWallet.Enabled = false;
            btnBudget.Enabled = false;
            btnGoals.Enabled = false;
            btnAnalytics.Enabled = false;
            btnSettings.Enabled = false;
        }

        private void EnableNavigationButtons()
        {
            btnDashboard.Enabled = true;
            btnWallet.Enabled = true;
            btnBudget.Enabled = true;
            btnGoals.Enabled = true;
            btnAnalytics.Enabled = true;
            btnSettings.Enabled = true;
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

        private void SetupButtonHoverEffects()
        {
            var buttons = new[] { btnDashboard, btnWallet, btnBudget, btnGoals, btnAnalytics, btnSettings };

            foreach (var btn in buttons)
            {
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
                        btn.ForeColor = Color.White;
                        btn.IconColor = Color.White;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentButton)
                    {
                        btn.BackColor = defaultBg;
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

        private void ActivateButton(IconButton btn)
        {
            if (btn == currentButton) return;

            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = defaultTextColor;
                currentButton.IconColor = defaultTextColor;
            }

            currentButton = btn;
            btn.BackColor = activeColor;
            btn.ForeColor = activeTextColor;
            btn.IconColor = activeTextColor;
        }

        private bool CanNavigate()
        {
            if (_isLoading)
            {
                return false;
            }

            TimeSpan timeSinceLastClick = DateTime.Now - _lastClickTime;
            if (timeSinceLastClick.TotalMilliseconds < CLICK_DELAY_MS)
            {
                return false;
            }

            _lastClickTime = DateTime.Now;
            return true;
        }

        private async void LoadContent(UserControl uc)
        {
            if (uc == null)
            {
                MessageBox.Show("Không thể tạo nội dung!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                _isLoading = true;
                ShowLoading(); 

                contentPanel.SuspendLayout();

                var oldControls = contentPanel.Controls.OfType<UserControl>().ToList();
                contentPanel.Controls.Remove(loadingOverlay); 
                contentPanel.Controls.Clear();

                await Task.Delay(10);

                foreach (Control ctrl in oldControls)
                {
                    try
                    {
                        if (ctrl != null && !ctrl.IsDisposed)
                        {
                            ctrl.Dispose();
                        }
                    }
                    catch (Exception disposeEx)
                    {
                    }
                }

                if (uc.IsDisposed)
                {
                    MessageBox.Show("Nội dung đã bị hủy!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                uc.Dock = DockStyle.Fill;
                contentPanel.Controls.Add(uc);
                contentPanel.Controls.Add(loadingOverlay); 
                uc.BringToFront();

                await Task.Delay(300);

                contentPanel.ResumeLayout(true);

            }
            catch (ObjectDisposedException odEx)
            {
                MessageBox.Show($"Đối tượng đã bị hủy:\n{odEx.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải nội dung:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isLoading = false;
                HideLoading(); 
            }
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnDashboard);

                var dashboard = new UC_Dashboard();

                if (!string.IsNullOrEmpty(_currentUserId))
                {
                    dashboard.SetUserId(_currentUserId);
                }
                else
                {
                    MessageBox.Show("Lỗi: Không tìm thấy ID người dùng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadContent(dashboard);
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
                MessageBox.Show($"Lỗi khi tải Dashboard:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnWallet_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnWallet);
                LoadContent(new UC_Wallet());
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
                MessageBox.Show($"Lỗi khi tải Ví:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnBudget_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnBudget);

                if (CurrentUserSession.CurrentUser == null)
                {
                    _isLoading = false;
                    HideLoading();
                    return;
                }

                UC_Budget uc = null;

                try
                {
                    uc = new UC_Budget();
                }
                catch (Exception createEx)
                {
                    throw;
                }

                if (uc == null)
                {
                    _isLoading = false;
                    HideLoading();
                    return;
                }

                if (uc.IsDisposed)
                {
                    _isLoading = false;
                    HideLoading();
                    return;
                }

                LoadContent(uc);
            }
            catch (ObjectDisposedException odEx)
            {
                _isLoading = false;
                HideLoading();
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
            }
        }

        private void BtnGoals_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnGoals);

                var goalService = Program.ServiceProvider.GetRequiredService<IGoalService>();
                var goalsPresenter = new GoalsPresenter(goalService);

                if (!string.IsNullOrEmpty(_currentUserId))
                {
                    goalsPresenter.SetUserId(_currentUserId);
                }
                else
                {
                    _isLoading = false;
                    HideLoading();
                    return;
                }

                LoadContent(new UC_Goals(goalsPresenter));
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
            }
        }

        private void BtnAnalytics_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnAnalytics);
                LoadContent(new UC_Analytics());
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
            }
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            if (!CanNavigate()) return;

            try
            {
                ActivateButton(btnSettings);
                LoadContent(new UC_Settings());
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
            }
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
            if (!CanNavigate()) return;

            try
            {
                LoadContent(new UC_Search());
            }
            catch (Exception ex)
            {
                _isLoading = false;
                HideLoading();
                MessageBox.Show($"Lỗi khi tải Search:\n{ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        private void btnToggleTheme_Click(object sender, EventArgs e)
        {

        }
    }
}