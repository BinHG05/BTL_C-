using ExpenseManager.App.Views.Admin.UC;
using ExpenseManager.App.Views.User.UC;
using FontAwesome.Sharp;
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
    public partial class LayoutAdmin : Form
    {
        private IconButton currentButton;
        private Color themeColor = ColorTranslator.FromHtml("#2F2CD8");
        private Color highlightColor = ColorTranslator.FromHtml("#4F4CFF");
        private Color hoverColor = Color.FromArgb(245, 245, 255);
        private Color defaultBg = Color.White;

        private Timer sidebarTimer;
        private bool sidebarExpanded = true;
        private int sidebarFullWidth = 250;
        private int sidebarCollapsedWidth = 100;

        public LayoutAdmin()
        {
            InitializeComponent();
            InitializeCustomComponents();
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

            // Apply rounded corners to search box and buttons
            ApplyRoundedCorners();

            // Setup sidebar buttons hover effects
            SetupButtonHoverEffects();

            // Setup sidebar expand/collapse timer
            SetupSidebarTimer();

            // Center the center panel
            CenterPanelInHeader();
            headerPanel.Resize += (s, e) => CenterPanelInHeader();
        }

        private void ApplyRoundedCorners()
        {
            // Round search box
            searchBox.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, searchBox.Width, searchBox.Height, 15, 15)
            );

            // Round add transaction button
            btnAddTransaction.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnAddTransaction.Width, btnAddTransaction.Height, 15, 15)
            );

            // Round text search
            txtSearch.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, txtSearch.Width, txtSearch.Height, 15, 15)
            );
        }

        private void SetupButtonHoverEffects()
        {
            var buttons = new[] { btnDashboard, btnWallet, btnBudget, btnGoals, btnAnalytics, btnSettings };

            foreach (var btn in buttons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != currentButton)
                        btn.BackColor = hoverColor;
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentButton)
                        btn.BackColor = defaultBg;
                };
            }
        }

        private void SetupSidebarTimer()
        {
            sidebarTimer = new Timer { Interval = 200 };
            sidebarTimer.Tick += SidebarTimer_Tick;
            sidebarTimer.Start();

            sidebarPanel.MouseEnter += (s, e) => ExpandSidebar(true);
            sidebarPanel.MouseLeave += (s, e) => { }; // Timer will handle collapse
        }

        private void CenterPanelInHeader()
        {
            centerPanel.Left = (headerPanel.Width - centerPanel.Width) / 2;
            centerPanel.Top = (headerPanel.Height - centerPanel.Height) / 2;
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            Point cursorPos = PointToClient(Cursor.Position);

            // Expand when cursor near left edge
            if (cursorPos.X <= 20 && !sidebarExpanded)
            {
                ExpandSidebar(true);
            }
            // Collapse when cursor away from sidebar
            else if (cursorPos.X > sidebarPanel.Width + 50 && sidebarExpanded)
            {
                ExpandSidebar(false);
            }
        }

        private void ExpandSidebar(bool expand)
        {
            if (expand && !sidebarExpanded)
            {
                sidebarPanel.Width = sidebarFullWidth;
                foreach (var btn in sidebarPanel.Controls.OfType<IconButton>())
                {
                    btn.TextAlign = ContentAlignment.MiddleLeft;
                    btn.TextImageRelation = TextImageRelation.ImageBeforeText;
                    btn.Padding = new Padding(20, 0, 0, 0);
                    btn.Text = btn.Tag?.ToString() ?? btn.Text;
                }
                sidebarExpanded = true;
            }
            else if (!expand && sidebarExpanded)
            {
                sidebarPanel.Width = sidebarCollapsedWidth;
                foreach (var btn in sidebarPanel.Controls.OfType<IconButton>())
                {
                    btn.Text = "";
                    btn.Padding = new Padding(0);
                    btn.TextImageRelation = TextImageRelation.Overlay;
                }
                sidebarExpanded = false;
            }
        }

        private void ActivateButton(IconButton btn)
        {
            if (btn == currentButton)
                return;

            // Reset previous button
            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = Color.Black;
                currentButton.IconColor = themeColor;
                currentButton.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            }

            // Set current button
            currentButton = btn;

            // Highlight selected button
            btn.BackColor = highlightColor;
            btn.ForeColor = Color.White;
            btn.IconColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
        }

        // Button Click Events
        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            ActivateButton(btnDashboard);
            LoadContent(new UC_Dashboard());
        }

        private void BtnWallet_Click(object sender, EventArgs e)
        {
            ActivateButton(btnWallet);
            LoadContent(new UC_Wallet());
        }

        private void BtnBudget_Click(object sender, EventArgs e)
        {
            ActivateButton(btnBudget);
            LoadContent(new UC_Budget());
        }

        private void BtnGoals_Click(object sender, EventArgs e)
        {
            ActivateButton(btnGoals);
            LoadContent(new UC_Goals());
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
            // Load Dashboard by default
            BtnDashboard_Click(btnDashboard, EventArgs.Empty);
        }

        // Win32 API for rounded corners
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
    }
}