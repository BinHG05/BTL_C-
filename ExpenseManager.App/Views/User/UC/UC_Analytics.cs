using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Collections.Generic;
using System.Linq;
using ExpenseManager.App.Views.User.UC;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Models.DTOs;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Analytics : UserControl, IAnalyticsView
    {
        private AnalyticsPresenter _presenter;
        private Panel underline;
        private bool isIncomeView = false;
        private bool _isInitialized = false;

        // Màu sắc
        private Color tabActiveColor = Color.FromArgb(59, 130, 246);
        private Color tabInactiveColor = Color.FromArgb(100, 116, 139);
        private Color totalExpenseColor = Color.FromArgb(220, 38, 38);
        private Color totalExpenseBgColor = Color.FromArgb(254, 226, 226);
        private Color totalIncomeColor = Color.FromArgb(22, 163, 74);
        private Color totalIncomeBgColor = Color.FromArgb(220, 252, 231);
        private Color cardBgColor = Color.White;
        private Color borderColor = Color.FromArgb(226, 232, 240);

        // Data
        private List<ExpenseBreakdownItem> _expenseBreakdown = new List<ExpenseBreakdownItem>();
        private List<IncomeBreakdownItem> _incomeBreakdown = new List<IncomeBreakdownItem>();
        private PagingInfo _currentPaging;

        public UC_Analytics()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

            // Kết nối sự kiện
            this.pnlDonutChart.Paint += pnlDonutChart_Paint;
            this.btnExpenses.Click += btnExpenses_Click;
            this.btnIncome.Click += btnIncome_Click;
            this.btnLoc.Click += btnLoc_Click;
            this.btnReset.Click += btnReset_Click;
            this.Load += UC_Analytics_Load;

            // ✅ APPLY ENHANCED STYLES
            ApplyEnhancedStyles();
        }

        private void ApplyEnhancedStyles()
        {
            try
            {
                // Main container background
                this.BackColor = Color.FromArgb(248, 250, 252);

                // ✅ Style cho pnlChart (Left card - Pie Chart)
                if (pnlChart != null)
                {
                    pnlChart.BackColor = cardBgColor;
                    pnlChart.Padding = new Padding(20);
                }

                // ✅ Style cho pnlHistory (Right card - Transaction History)
                if (pnlHistory != null)
                {
                    pnlHistory.BackColor = cardBgColor;
                    pnlHistory.Padding = new Padding(20);
                }

                // ✅ Style cho lblExpensesBreakdown title
                if (lblExpensesBreakdown != null)
                {
                    lblExpensesBreakdown.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblExpensesBreakdown.ForeColor = Color.FromArgb(30, 41, 59);
                }

                // ✅ FIX: Ẩn lblPageName vì nó đè lên breadcrumb
                if (lblPageName != null)
                {
                    lblPageName.Visible = false;
                }

                // ✅ FIX: Style cho lblTotalExpenses - Đơn giản hóa
                if (lblTotalExpenses != null)
                {
                    lblTotalExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    lblTotalExpenses.Padding = new Padding(10, 6, 10, 6);
                    lblTotalExpenses.AutoSize = true;
                    lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
                }

                // ✅ Style cho flpLegend
                if (flpLegend != null)
                {
                    flpLegend.Padding = new Padding(10);
                    flpLegend.AutoScroll = true;
                }

                // ✅ Style cho DataGridView
                if (dgvTransactions != null)
                {
                    dgvTransactions.BorderStyle = BorderStyle.None;
                    dgvTransactions.BackgroundColor = cardBgColor;
                    dgvTransactions.GridColor = Color.FromArgb(241, 245, 249);
                    dgvTransactions.RowHeadersVisible = false;
                    dgvTransactions.AllowUserToAddRows = false;
                    dgvTransactions.AllowUserToDeleteRows = false;
                    dgvTransactions.ReadOnly = true;
                    dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                }
            }
            catch (Exception ex)
            {
                // Ignore styling errors
                System.Diagnostics.Debug.WriteLine($"Style error: {ex.Message}");
            }
        }

        private async void UC_Analytics_Load(object sender, EventArgs e)
        {
            if (_isInitialized) return;

            try
            {
                // Setup UI
                cmbWallets.DisplayMember = "WalletName";
                cmbWallets.ValueMember = "WalletID";
                dtpMonth.Value = DateTime.Now;
                dtpMonth.Format = DateTimePickerFormat.Custom;
                dtpMonth.CustomFormat = "MMMM yyyy";

                // Tạo underline
                underline = new Panel
                {
                    BackColor = tabActiveColor,
                    Size = new Size(btnExpenses.Width, 3)
                };
                pnlTabsAndFilters.Controls.Add(underline);
                underline.Location = new Point(btnExpenses.Left, btnExpenses.Bottom - 3);
                underline.BringToFront();

                // Khởi tạo Presenter
                var analyticsService = Program.GetService<IAnalyticsService>();
                var walletService = Program.GetService<IWalletService>();
                _presenter = new AnalyticsPresenter(this, analyticsService, walletService);

                LoadWalletList?.Invoke(this, EventArgs.Empty);
                await System.Threading.Tasks.Task.Delay(50);
                ApplyFilter?.Invoke(this, EventArgs.Empty);

                _isInitialized = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo Analytics: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            if (!_isInitialized) return;
            ApplyFilter?.Invoke(this, EventArgs.Empty);
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            if (!_isInitialized) return;
            ResetFilter?.Invoke(this, EventArgs.Empty);
        }

        #region IAnalyticsView Implementation

        public string UserId => ExpenseManager.App.Session.CurrentUserSession.CurrentUser?.UserId;

        public int? SelectedWalletId
        {
            get
            {
                if (cmbWallets.SelectedValue == null || cmbWallets.SelectedIndex == 0)
                    return null;

                if (int.TryParse(cmbWallets.SelectedValue.ToString(), out int walletId))
                    return walletId;

                return null;
            }
        }

        public string SelectedMonth
        {
            get => dtpMonth.Value.ToString("yyyy-MM");
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM", null,
                    System.Globalization.DateTimeStyles.None, out var date))
                {
                    dtpMonth.Value = date;
                }
            }
        }

        public string ActiveTab { get; set; } = "Expense";

        public event EventHandler LoadWalletList;
        public event EventHandler ApplyFilter;
        public event EventHandler ResetFilter;
        public event EventHandler<int> PageChanged;

        public void DisplayExpenseBreakdown(List<ExpenseBreakdownItem> breakdown)
        {
            _expenseBreakdown = breakdown ?? new List<ExpenseBreakdownItem>();

            if (_expenseBreakdown.Any())
            {
                LoadExpensesChartLegend();
                pnlDonutChart.Invalidate();
            }
            else
            {
                ShowEmptyState();
            }
        }

        public void DisplayExpenseHistory(List<TransactionDto> history)
        {
            if (history != null && history.Any())
            {
                LoadExpensesTransactionHistory(history);
            }
            else
            {
                ShowEmptyTransactionHistory();
            }
        }

        public void DisplayTotalExpense(decimal total)
        {
            // ✅ Hiển thị rõ ràng số tiền tổng chi
            lblTotalExpenses.Text = $"Tổng chi: {total:N0}đ";
            lblTotalExpenses.BackColor = totalExpenseBgColor;
            lblTotalExpenses.ForeColor = totalExpenseColor;
            lblTotalExpenses.Visible = true; // Đảm bảo hiển thị
        }

        public void DisplayIncomeBreakdown(List<IncomeBreakdownItem> breakdown)
        {
            _incomeBreakdown = breakdown ?? new List<IncomeBreakdownItem>();

            if (_incomeBreakdown.Any())
            {
                LoadIncomeChartLegend();
                pnlDonutChart.Invalidate();
            }
            else
            {
                ShowEmptyState();
            }
        }

        public void DisplayIncomeHistory(List<IncomeTransactionDto> history)
        {
            if (history != null && history.Any())
            {
                LoadIncomeTransactionHistory(history);
            }
            else
            {
                ShowEmptyTransactionHistory();
            }
        }

        public void DisplayTotalIncome(decimal total)
        {
            // ✅ Hiển thị rõ ràng số tiền tổng thu
            lblTotalExpenses.Text = $"Tổng thu: {total:N0}đ";
            lblTotalExpenses.BackColor = totalIncomeBgColor;
            lblTotalExpenses.ForeColor = totalIncomeColor;
            lblTotalExpenses.Visible = true; // Đảm bảo hiển thị
        }

        public void DisplayPagingInfo(PagingInfo info)
        {
            _currentPaging = info;
        }

        public void ShowLoading(bool isVisible)
        {
            this.Cursor = isVisible ? Cursors.WaitCursor : Cursors.Default;
        }

        public void ShowError(string message)
        {
            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetWalletList(List<WalletDto> wallets)
        {
            var allWallets = new List<WalletDto>
            {
                new WalletDto { WalletID = 0, WalletName = "Tất cả ví" }
            };
            allWallets.AddRange(wallets);

            cmbWallets.DataSource = allWallets;
            cmbWallets.SelectedIndex = 0;
        }

        #endregion

        #region Tab Switching

        private void btnExpenses_Click(object sender, EventArgs e)
        {
            if (!_isInitialized) return;

            ActiveTab = "Expense";
            isIncomeView = false;

            btnExpenses.ForeColor = tabActiveColor;
            btnIncome.ForeColor = tabInactiveColor;
            underline.Location = new Point(btnExpenses.Left, btnExpenses.Bottom - 3);

            lblExpensesBreakdown.Text = "Expenses Breakdown";
            // ✅ Không cần set lblPageName vì đã ẩn

            ApplyFilter?.Invoke(this, EventArgs.Empty);
        }

        private void btnIncome_Click(object sender, EventArgs e)
        {
            if (!_isInitialized) return;

            ActiveTab = "Income";
            isIncomeView = true;

            btnIncome.ForeColor = tabActiveColor;
            btnExpenses.ForeColor = tabInactiveColor;
            underline.Location = new Point(btnIncome.Left, btnIncome.Bottom - 3);

            lblExpensesBreakdown.Text = "Income Breakdown";
            // ✅ Không cần set lblPageName vì đã ẩn

            ApplyFilter?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Empty State

        private void ShowEmptyState()
        {
            flpLegend.Controls.Clear();
            pnlDonutChart.Invalidate(); // Clear chart

            // Create empty state panel
            Panel emptyPanel = new Panel
            {
                Size = new Size(flpLegend.Width - 20, 200),
                Margin = new Padding(10)
            };

            // ✅ Icon nhỏ gọn hơn
            Label iconLabel = new Label
            {
                Text = "📊",
                Font = new Font("Segoe UI", 32F), // Giảm từ 48 xuống 32
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            iconLabel.Location = new Point((emptyPanel.Width - 40) / 2, 30); // Điều chỉnh vị trí

            Label messageLabel = new Label
            {
                Text = isIncomeView ? "Chưa có dữ liệu thu nhập" : "Chưa có dữ liệu chi tiêu",
                Font = new Font("Segoe UI", 13F, FontStyle.Bold), // Giảm từ 14 xuống 13
                ForeColor = Color.FromArgb(100, 116, 139),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            messageLabel.Location = new Point((emptyPanel.Width - messageLabel.Width) / 2, 100);

            Label subLabel = new Label
            {
                Text = "Hãy thêm giao dịch để xem phân tích",
                Font = new Font("Segoe UI", 10F), // Giảm từ 11 xuống 10
                ForeColor = Color.FromArgb(148, 163, 184),
                AutoSize = true,
                TextAlign = ContentAlignment.MiddleCenter
            };
            subLabel.Location = new Point((emptyPanel.Width - subLabel.Width) / 2, 130);

            emptyPanel.Controls.Add(iconLabel);
            emptyPanel.Controls.Add(messageLabel);
            emptyPanel.Controls.Add(subLabel);

            flpLegend.Controls.Add(emptyPanel);
        }

        private void ShowEmptyTransactionHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Date");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount", typeof(string));

            // ✅ FIX: Đảm bảo tất cả columns đều hiển thị đúng
            dgvTransactions.DataSource = dt;

            // Add empty message row
            dt.Rows.Add("", "", "Không có giao dịch nào trong khoảng thời gian này", "");

            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ Đảm bảo tất cả columns visible
            dgvTransactions.Columns["Category"].Visible = true;
            dgvTransactions.Columns["Date"].Visible = true;
            dgvTransactions.Columns["Description"].Visible = true;
            dgvTransactions.Columns["Amount"].Visible = true;

            // Style for empty message - center only Description
            dgvTransactions.Columns["Description"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.Columns["Description"].DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            dgvTransactions.Columns["Description"].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);

            // Hide content in other columns for empty state
            dgvTransactions.Columns["Category"].DefaultCellStyle.ForeColor = Color.Transparent;
            dgvTransactions.Columns["Date"].DefaultCellStyle.ForeColor = Color.Transparent;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.ForeColor = Color.Transparent;
        }

        #endregion

        #region Pie Chart Drawing

        private void pnlDonutChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            float[] values;
            Color[] colors;

            if (isIncomeView && _incomeBreakdown.Any())
            {
                values = _incomeBreakdown.Select(b => (float)b.Percentage).ToArray();
                colors = _incomeBreakdown.Select(b => ColorTranslator.FromHtml(b.ColorHex)).ToArray();
            }
            else if (!isIncomeView && _expenseBreakdown.Any())
            {
                values = _expenseBreakdown.Select(b => (float)b.Percentage).ToArray();
                colors = _expenseBreakdown.Select(b => ColorTranslator.FromHtml(b.ColorHex)).ToArray();
            }
            else
            {
                // Draw empty state in chart area
                DrawEmptyChart(g);
                return;
            }

            // ✅ Improved chart sizing - center and add padding
            int chartSize = Math.Min(pnlDonutChart.Width, pnlDonutChart.Height) - 40;
            int x = (pnlDonutChart.Width - chartSize) / 2;
            int y = (pnlDonutChart.Height - chartSize) / 2;
            Rectangle rect = new Rectangle(x, y, chartSize, chartSize);
            float holeRadiusRatio = 0.65f;

            // Draw pie slices
            float currentAngle = -90;
            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = 360f * (values[i] / 100f);
                using (SolidBrush brush = new SolidBrush(colors[i]))
                {
                    g.FillPie(brush, rect, currentAngle, sweepAngle);
                }
                currentAngle += sweepAngle;
            }

            // Draw center hole
            RectangleF holeRect = new RectangleF(
                rect.Left + (rect.Width * (1 - holeRadiusRatio) / 2),
                rect.Top + (rect.Height * (1 - holeRadiusRatio) / 2),
                rect.Width * holeRadiusRatio,
                rect.Height * holeRadiusRatio
            );
            using (SolidBrush brushWhite = new SolidBrush(cardBgColor))
            {
                g.FillEllipse(brushWhite, holeRect);
            }
        }

        private void DrawEmptyChart(Graphics g)
        {
            int chartSize = Math.Min(pnlDonutChart.Width, pnlDonutChart.Height) - 40;
            int x = (pnlDonutChart.Width - chartSize) / 2;
            int y = (pnlDonutChart.Height - chartSize) / 2;
            Rectangle rect = new Rectangle(x, y, chartSize, chartSize);

            // Draw gray circle
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(241, 245, 249)))
            {
                g.FillEllipse(brush, rect);
            }

            // Draw center hole
            float holeRadiusRatio = 0.65f;
            RectangleF holeRect = new RectangleF(
                rect.Left + (rect.Width * (1 - holeRadiusRatio) / 2),
                rect.Top + (rect.Height * (1 - holeRadiusRatio) / 2),
                rect.Width * holeRadiusRatio,
                rect.Height * holeRadiusRatio
            );
            using (SolidBrush brushWhite = new SolidBrush(cardBgColor))
            {
                g.FillEllipse(brushWhite, holeRect);
            }

            // Draw "No Data" text
            string text = "Chưa có dữ liệu";
            using (Font font = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                SizeF textSize = g.MeasureString(text, font);
                PointF textPos = new PointF(
                    pnlDonutChart.Width / 2 - textSize.Width / 2,
                    pnlDonutChart.Height / 2 - textSize.Height / 2
                );
                g.DrawString(text, font, textBrush, textPos);
            }
        }

        #endregion

        #region Legend

        private void LoadExpensesChartLegend()
        {
            flpLegend.Controls.Clear();
            foreach (var item in _expenseBreakdown)
            {
                CreateLegendItem(
                    ColorTranslator.FromHtml(item.ColorHex),
                    item.CategoryName,
                    $"{item.Amount:N0}đ",
                    $"{item.Percentage:F1}%"
                );
            }
        }

        private void LoadIncomeChartLegend()
        {
            flpLegend.Controls.Clear();
            foreach (var item in _incomeBreakdown)
            {
                CreateLegendItem(
                    ColorTranslator.FromHtml(item.ColorHex),
                    item.CategoryName,
                    $"{item.Amount:N0}đ",
                    $"{item.Percentage:F1}%"
                );
            }
        }

        private void CreateLegendItem(Color color, string name, string amount, string percent)
        {
            Panel pnlItem = new Panel
            {
                Size = new Size(flpLegend.Width - 40, 50),
                Margin = new Padding(5),
                BackColor = Color.FromArgb(248, 250, 252),
                Padding = new Padding(10)
            };

            // Color box with border
            Panel colorBox = new Panel
            {
                BackColor = color,
                Size = new Size(20, 20),
                Location = new Point(10, 15)
            };

            Label lblName = new Label
            {
                Text = name,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 41, 59),
                Location = new Point(45, 14),
                AutoSize = true
            };

            Label lblAmount = new Label
            {
                Text = amount,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(100, 116, 139),
                Location = new Point(pnlItem.Width - 220, 14),
                AutoSize = true
            };

            Label lblPercent = new Label
            {
                Text = percent,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                ForeColor = color,
                Location = new Point(pnlItem.Width - 80, 13),
                AutoSize = true
            };

            pnlItem.Controls.Add(colorBox);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblAmount);
            pnlItem.Controls.Add(lblPercent);
            flpLegend.Controls.Add(pnlItem);
        }

        #endregion

        #region Transaction History

        private void LoadExpensesTransactionHistory(List<TransactionDto> transactions)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Date");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount", typeof(decimal));

            foreach (var t in transactions)
            {
                dt.Rows.Add(
                    t.Category?.CategoryName ?? "N/A",
                    t.TransactionDate.ToString("dd/MM/yyyy"),
                    t.Description,
                    -t.Amount
                );
            }

            SetupDataGridView(dt);
        }

        private void LoadIncomeTransactionHistory(List<IncomeTransactionDto> transactions)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category");
            dt.Columns.Add("Date");
            dt.Columns.Add("Description");
            dt.Columns.Add("Amount", typeof(decimal));

            foreach (var t in transactions)
            {
                dt.Rows.Add(
                    t.Category?.CategoryName ?? "N/A",
                    t.TransactionDate.ToString("dd/MM/yyyy"),
                    t.Description,
                    t.Amount
                );
            }

            SetupDataGridView(dt);
        }

        private void SetupDataGridView(DataTable dt)
        {
            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // ✅ RESET tất cả columns về trạng thái bình thường
            foreach (DataGridViewColumn col in dgvTransactions.Columns)
            {
                col.Visible = true;
                col.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            }

            // Header style
            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvTransactions.ColumnHeadersHeight = 45;
            dgvTransactions.EnableHeadersVisualStyles = false;

            // Cell style
            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvTransactions.DefaultCellStyle.SelectionBackColor = Color.FromArgb(238, 242, 247);
            dgvTransactions.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);
            dgvTransactions.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvTransactions.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft; // Reset alignment
            dgvTransactions.RowTemplate.Height = 50;

            // Column specific styles
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvTransactions.Columns["Category"].FillWeight = 40;
            dgvTransactions.Columns["Date"].FillWeight = 40;
            dgvTransactions.Columns["Description"].FillWeight = 40;
            dgvTransactions.Columns["Amount"].FillWeight = 40;

            dgvTransactions.CellFormatting -= DgvTransactions_CellFormatting;
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "Amount")
            {
                if (e.Value != null && e.Value is decimal amount)
                {
                    if (amount < 0)
                    {
                        e.CellStyle.ForeColor = totalExpenseColor;
                    }
                    else
                    {
                        e.CellStyle.ForeColor = totalIncomeColor;
                        e.Value = "+" + String.Format("{0:N0}", amount);
                    }
                }
            }
        }

        #endregion
    }
}