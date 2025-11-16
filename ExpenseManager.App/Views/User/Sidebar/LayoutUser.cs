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
    public partial class LayoutUser : Form
    {
        private IconButton currentButton;
        private Color sidebarColor = Color.FromArgb(31, 31, 224);
        private Color activeColor = Color.FromArgb(51, 51, 255);
        private Color hoverColor = Color.FromArgb(61, 61, 244);
        private Color defaultBg = Color.Transparent;

        public LayoutUser()
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

            // Apply rounded corners to buttons
            ApplyRoundedCorners();

            // Setup sidebar buttons hover effects
            SetupButtonHoverEffects();

            // Center the center panel
            CenterPanelInHeader();
            headerPanel.Resize += (s, e) => CenterPanelInHeader();

            // Round profile button
            RoundProfileButton();
        }

        private void ApplyRoundedCorners()
        {
            // Round add transaction button
            btnAddTransaction.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnAddTransaction.Width, btnAddTransaction.Height, 10, 10)
            );

            // Round search box
            searchBox.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, searchBox.Width, searchBox.Height, 10, 10)
            );

            // Round search button inside
            btnSearchInside.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, btnSearchInside.Width, btnSearchInside.Height, 8, 8)
            );
        }

        private void RoundProfileButton()
        {
            // Make profile button circular
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddEllipse(0, 0, btnProfileTop.Width, btnProfileTop.Height);
            btnProfileTop.Region = new Region(path);
        }

        private void SetupButtonHoverEffects()
        {
            var buttons = new[] { btnDashboard, btnWallet, btnBudget, btnGoals, btnAnalytics, btnSettings };

            foreach (var btn in buttons)
            {
                btn.MouseEnter += (s, e) =>
                {
                    if (btn != currentButton)
                    {
                        btn.BackColor = hoverColor;
                    }
                };

                btn.MouseLeave += (s, e) =>
                {
                    if (btn != currentButton)
                    {
                        btn.BackColor = defaultBg;
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
            if (btn == currentButton)
                return;

            // Reset previous button
            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = Color.White;
                currentButton.IconColor = Color.White;
            }

            // Set current button
            currentButton = btn;

            // Highlight selected button with active color
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