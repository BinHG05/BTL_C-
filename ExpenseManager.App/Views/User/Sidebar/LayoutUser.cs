using ExpenseManager.App.Presenters;
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
        private Color sidebarColor = Color.FromArgb(31, 31, 224);
        private Color activeColor = Color.FromArgb(51, 51, 255);
        private Color hoverColor = Color.FromArgb(61, 61, 244);
        private Color defaultBg = Color.Transparent;
        private string _currentUserId;

        // Biến cho Menu Profile
        private ContextMenuStrip profileMenu;
        private ToolStripMenuItem itemSettings;
        private ToolStripMenuItem itemLogout;

        public LayoutUser()
        {
            InitializeComponent();
            InitializeCustomComponents();
            InitializeUserSession();
            InitializeProfileMenu(); // Khởi tạo menu
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
            // Load logo
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

            // Apply rounded corners
            ApplyRoundedCorners();
            // Setup hover effects
            SetupButtonHoverEffects();
            // Center panel
            CenterPanelInHeader();
            headerPanel.Resize += (s, e) => CenterPanelInHeader();
            // Round profile button
            RoundProfileButton();

            this.btnAddTransaction.Click += new System.EventHandler(this.BtnAddTransaction_Click);
        }

        // ========================================================================
        // KHỞI TẠO MENU PROFILE (ĐÃ SỬA LỖI ICON)
        // ========================================================================
        private void InitializeProfileMenu()
        {
            profileMenu = new ContextMenuStrip();
            profileMenu.Font = new Font("Segoe UI", 10F);
            profileMenu.RenderMode = ToolStripRenderMode.Professional;
            profileMenu.Renderer = new CustomMenuRenderer();

            // 1. Header Item (Tên + Email)
            string userName = CurrentUserSession.CurrentUser?.FullName ?? "User";
            string userEmail = CurrentUserSession.CurrentUser?.Email ?? "Email";

            var headerItem = new ToolStripMenuItem();
            headerItem.Text = $"{userName}\n{userEmail}";
            headerItem.Enabled = false;
            headerItem.ForeColor = Color.Gray;
            headerItem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            // 2. Item Settings - SỬA LỖI TẠI ĐÂY (Dùng GetIconBitmap)
            itemSettings = new ToolStripMenuItem("Settings", GetIconBitmap(IconChar.Gear, 16, Color.Black));
            itemSettings.Click += BtnSettings_Click;

            // 3. Item Logout - SỬA LỖI TẠI ĐÂY (Dùng GetIconBitmap)
            itemLogout = new ToolStripMenuItem("Logout", GetIconBitmap(IconChar.SignOutAlt, 16, Color.Red));
            itemLogout.ForeColor = Color.Red;
            itemLogout.Click += LogoutMenuItem_Click;

            // Thêm vào menu
            profileMenu.Items.Add(headerItem);
            profileMenu.Items.Add(new ToolStripSeparator());
            profileMenu.Items.Add(itemSettings);
            profileMenu.Items.Add(new ToolStripSeparator());
            profileMenu.Items.Add(itemLogout);
        }

        // ========================================================================
        // HÀM HỖ TRỢ TẠO ICON BITMAP (FIX LỖI CS1929)
        // ========================================================================
        private Bitmap GetIconBitmap(IconChar icon, int size, Color color)
        {
            // Tạo IconPictureBox ảo để vẽ ra Bitmap
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
                btn.MouseEnter += (s, e) => { if (btn != currentButton) btn.BackColor = hoverColor; };
                btn.MouseLeave += (s, e) => { if (btn != currentButton) btn.BackColor = defaultBg; };
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
                currentButton.ForeColor = Color.White;
                currentButton.IconColor = Color.White;
            }

            currentButton = btn;
            btn.BackColor = activeColor;
            btn.ForeColor = Color.White;
            btn.IconColor = Color.White;
        }

        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
        }

        // Button Click Events
        private void BtnDashboard_Click(object sender, EventArgs e) { ActivateButton(btnDashboard); LoadContent(new UC_Dashboard()); }
        private void BtnWallet_Click(object sender, EventArgs e) { ActivateButton(btnWallet); LoadContent(new UC_Wallet()); }
        private void BtnBudget_Click(object sender, EventArgs e) { ActivateButton(btnBudget); LoadContent(new UC_Budget()); }
        private void BtnGoals_Click(object sender, EventArgs e)
        {
            var goalService = Program.ServiceProvider.GetRequiredService<IGoalService>();
            var goalsPresenter = new GoalsPresenter(goalService);
            if (!string.IsNullOrEmpty(_currentUserId)) goalsPresenter.SetUserId(_currentUserId);
            else { MessageBox.Show("Lỗi: Không tìm thấy thông tin người dùng."); return; }
            ActivateButton(btnGoals);
            LoadContent(new UC_Goals(goalsPresenter));
        }
        private void BtnAnalytics_Click(object sender, EventArgs e) { ActivateButton(btnAnalytics); LoadContent(new UC_Analytics()); }
        private void BtnSettings_Click(object sender, EventArgs e) { ActivateButton(btnSettings); LoadContent(new UC_Settings()); }

        private void LayoutAdmin_Load(object sender, EventArgs e) { BtnDashboard_Click(btnDashboard, EventArgs.Empty); }

        private void LogoutMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận đăng xuất", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                CurrentUserSession.ClearUser();
                var loginForm = Program.ServiceProvider.GetRequiredService<LoginForm>();
                loginForm.Show();
                this.Close();
            }
        }

        // Menu Renderer Classes
        public class CustomMenuRenderer : ToolStripProfessionalRenderer
        {
            public CustomMenuRenderer() : base(new CustomColorTable()) { }
            protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
            {
                if (!e.Item.Selected) base.OnRenderMenuItemBackground(e);
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

        private void btnSearchInside_Click_1(object sender, EventArgs e) { LoadContent(new UC_Search()); }
    }
}