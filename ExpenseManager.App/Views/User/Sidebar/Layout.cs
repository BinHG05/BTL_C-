using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using FontAwesome.Sharp;
using System.IO;
using ExpenseManager.App.Views.User.UC;

namespace ExpenseManager.App.Views
{
    public partial class Layout : Form
    {
        private IconButton btnDashboard, btnWallets, btnBudgets, btnGoals, btnAnalytics, btnSettings;
        private IconButton currentButton;

        private Color themeColor = ColorTranslator.FromHtml("#2F2CD8");
        private Color highlightColor = ColorTranslator.FromHtml("#4F4CFF");
        private Color hoverColor = Color.FromArgb(245, 245, 255);
        private Color defaultBg = Color.White;

        private Timer sidebarTimer;
        private bool sidebarExpanded = true;
        private int sidebarFullWidth = 250;
        private int sidebarCollapsedWidth = 100;

        public Layout()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            SetupUI();
        }

        private void SetupUI()
        {

            // ====== THANH HEADER (TÌM KIẾM + NÚT THÊM) ======
            Panel headerPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 80,
                BackColor = Color.White
            };
            this.headerPanel.Controls.Add(headerPanel);

            // Ô tìm kiếm
            Panel searchBox = new Panel
            {
                BackColor = Color.FromArgb(245, 245, 255),
                Width = 280,   // ← chỉnh kích thước dễ ở đây
                Height = 40
            };
            searchBox.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, searchBox.Width, searchBox.Height, 15, 15));

            TextBox txtSearch = new TextBox
            {
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 11),
                ForeColor = Color.Black,
                PlaceholderText = "Search...",
                BackColor = searchBox.BackColor,
                Location = new Point(10, 10),
                Width = searchBox.Width - 45
            };
            searchBox.Controls.Add(txtSearch);

            // Nút tìm kiếm trong cùng panel
            IconButton btnSearchInside = new IconButton
            {
                IconChar = IconChar.MagnifyingGlass,
                IconColor = themeColor,
                IconSize = 18,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                Width = 30,
                Height = 30,
                Location = new Point(searchBox.Width - 35, 5)
            };
            btnSearchInside.FlatAppearance.BorderSize = 0;
            searchBox.Controls.Add(btnSearchInside);
            txtSearch.Region = Region.FromHrgn(
                CreateRoundRectRgn(0, 0, txtSearch.Width, txtSearch.Height, 15, 15)
            );

            // Nút tìm kiếm
            IconButton btnSearch = new IconButton
            {
                IconChar = IconChar.MagnifyingGlass,
                IconColor = Color.White,
                IconSize = 18,
                BackColor = ColorTranslator.FromHtml("#2F2CD8"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Height = 40,
                Width = 40,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(0)
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnSearch.Width, btnSearch.Height, 15, 15));


            // Nút thêm giao dịch
            IconButton btnAddTransaction = new IconButton
            {
                Text = "Add Transaction",
                IconChar = IconChar.Plus,
                IconColor = Color.White,
                IconSize = 18,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.White,
                BackColor = themeColor,
                FlatStyle = FlatStyle.Flat,
                Height = 40,
                Width = 180
            };
            btnAddTransaction.FlatAppearance.BorderSize = 0;
            btnAddTransaction.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddTransaction.Width, btnAddTransaction.Height, 15, 15));


            Panel rightPanel = new Panel
            {
                Dock = DockStyle.Right,
                Width = 150,
                BackColor = Color.White,
                Padding = new Padding(0, 10, 20, 10)
            };
            headerPanel.Controls.Add(rightPanel);


            IconButton btnProfileTop = new IconButton
            {
                IconChar = IconChar.UserCircle,
                IconColor = themeColor,
                IconSize = 26,
                Dock = DockStyle.Right,
                Width = 45,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = themeColor,
            };
            btnProfileTop.FlatAppearance.BorderSize = 0;


            IconButton btnToggleTheme = new IconButton
            {
                IconChar = IconChar.Moon,
                IconColor = themeColor,
                IconSize = 26,
                Dock = DockStyle.Right,
                Width = 45,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = themeColor,
            };
            btnToggleTheme.FlatAppearance.BorderSize = 0;

            rightPanel.Controls.Add(btnToggleTheme);
            rightPanel.Controls.Add(btnProfileTop);



            //Panel căn giữa

            Panel centerPanel = new Panel
            {
                Height = 50,
                Width = searchBox.Width + btnAddTransaction.Width + 40
            };
            headerPanel.Controls.Add(centerPanel);

            searchBox.Location = new Point(0, 5);
            btnAddTransaction.Location = new Point(searchBox.Right + 20, 5);
            centerPanel.Controls.AddRange(new Control[] { searchBox, btnAddTransaction });

            headerPanel.Resize += (s, e) =>
            {
                centerPanel.Left = (headerPanel.Width - centerPanel.Width) / 2;
                centerPanel.Top = (headerPanel.Height - centerPanel.Height) / 2;
            };

            btnAddTransaction.FlatAppearance.BorderSize = 0;
            btnAddTransaction.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, btnAddTransaction.Width, btnAddTransaction.Height, 15, 15));


            headerPanel.Controls.Add(centerPanel);



            // Cập nhật khi resize để luôn căn giữa
            headerPanel.Resize += (s, e) =>
            {
                centerPanel.Left = (headerPanel.Width - centerPanel.Width) / 2;
            };





            //🔹 Gắn sự kiện ví dụ
            //btnSearch.Click += (s, e) => MessageBox.Show("Searching: " + txtSearch.Text);
            //btnAddTransaction.Click += (s, e) => MessageBox.Show("Add new transaction clicked!");



            sidebarPanel.BackColor = Color.White;
            sidebarPanel.Width = sidebarFullWidth;


            Panel logoPanel = new Panel
            {
                Height = 80,
                Dock = DockStyle.Top,
                BackColor = Color.White
            };

            PictureBox logoPic = new PictureBox
            {
                Image = Image.FromFile(Path.Combine(Application.StartupPath, "image", "logo.png")),
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Fill,
                BackColor = Color.Transparent
            };


            // === Buttons ===
            btnSettings = CreateSidebarButton("Settings", IconChar.Gear);
            btnAnalytics = CreateSidebarButton("Analytics", IconChar.ChartLine);
            btnGoals = CreateSidebarButton("Goals", IconChar.Bullseye);
            btnBudgets = CreateSidebarButton("Budgets", IconChar.Coins);
            btnWallets = CreateSidebarButton("Wallets", IconChar.Wallet);
            btnDashboard = CreateSidebarButton("Dashboard", IconChar.ChartPie);

            sidebarPanel.Controls.AddRange(new Control[]
            {
                btnSettings, btnAnalytics, btnGoals, btnBudgets, btnWallets, btnDashboard
            });

            logoPanel.Controls.Add(logoPic);
            sidebarPanel.Controls.Add(logoPanel);

            // === Main Panel (có sẵn) ===
            this.headerPanel.BackColor = Color.FromArgb(245, 245, 245);

            // === Timer & Hover logic ===
            sidebarTimer = new Timer { Interval = 200 };
            sidebarTimer.Tick += SidebarTimer_Tick;
            sidebarTimer.Start();

            sidebarPanel.MouseEnter += SidebarPanel_MouseEnter;
            sidebarPanel.MouseLeave += SidebarPanel_MouseLeave;

            //thêm sự kiện settings click
            btnSettings.Click += BtnSettings_Click;
        }

        private IconButton CreateSidebarButton(string text, IconChar icon)
        {
            var btn = new IconButton
            {
                Text = text,
                Tag = text,
                IconChar = icon,
                IconColor = themeColor,
                IconSize = 28,
                Dock = DockStyle.Top,
                Height = 120,
                FlatStyle = FlatStyle.Flat,
                ForeColor = Color.Black,
                Font = new Font("Segoe UI", 12, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleLeft,
                TextImageRelation = TextImageRelation.ImageBeforeText,
                Padding = new Padding(20, 0, 0, 0),
                BackColor = defaultBg
            };
            btn.FlatAppearance.BorderSize = 0;

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
            btn.Click += (s, e) => ActivateButton(btn);

            return btn;
        }

        private void ActivateButton(IconButton btn)
        {
            if (btn == currentButton)
                return;

            // Reset nút trước
            if (currentButton != null)
            {
                currentButton.BackColor = defaultBg;
                currentButton.ForeColor = Color.Black;
                currentButton.IconColor = themeColor;
                currentButton.Font = new Font("Segoe UI", 12, FontStyle.Regular);
            }

            // Gán nút hiện tại
            currentButton = btn;

            // Đổi màu nút được chọn
            btn.BackColor = highlightColor;
            btn.ForeColor = Color.White;
            btn.IconColor = Color.White;
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
        }

        private void SidebarPanel_MouseEnter(object sender, EventArgs e)
        {
            ExpandSidebar(true);
        }

        private void SidebarPanel_MouseLeave(object sender, EventArgs e)
        {
            // không thu nhỏ ngay, để Timer lo
        }



        private void SidebarTimer_Tick(object sender, EventArgs e)
        {

            Point cursorPos = PointToClient(Cursor.Position);


            if (cursorPos.X <= 20 && !sidebarExpanded)
            {
                ExpandSidebar(true);
            }

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
                foreach (var c in sidebarPanel.Controls.OfType<IconButton>())
                {
                    c.TextAlign = ContentAlignment.MiddleLeft;
                    c.TextImageRelation = TextImageRelation.ImageBeforeText;
                    c.Padding = new Padding(20, 0, 0, 0);
                    c.Text = c.Tag?.ToString() ?? c.Text;
                }
                sidebarExpanded = true;
            }
            else if (!expand && sidebarExpanded)
            {
                sidebarPanel.Width = sidebarCollapsedWidth;
                foreach (var c in sidebarPanel.Controls.OfType<IconButton>())
                {
                    c.Text = "";
                    c.Padding = new Padding(0);
                    c.TextImageRelation = TextImageRelation.Overlay;
                }
                sidebarExpanded = false;
            }
        }

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(
            int nLeftRect, int nTopRect, int nRightRect, int nBottomRect,
            int nWidthEllipse, int nHeightEllipse
        );
        private void BtnSettings_Click(object sender, EventArgs e)
        {
            ActivateButton(btnSettings);
            LoadContent(new UC_Settings());
        }
        private void LoadContent(UserControl uc)
        {
            contentPanel.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            contentPanel.Controls.Add(uc);
        }

        private void Layout_Load(object sender, EventArgs e)
        {

        }
    }
}
