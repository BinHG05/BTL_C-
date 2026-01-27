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

        // Data
        private List<ExpenseBreakdownItem> _expenseBreakdown = new List<ExpenseBreakdownItem>();
        private List<IncomeBreakdownItem> _incomeBreakdown = new List<IncomeBreakdownItem>();
        private List<TrendDataPoint> _expenseTrendData = new List<TrendDataPoint>();
        private List<TrendDataPoint> _incomeTrendData = new List<TrendDataPoint>();
        private PagingInfo _currentPaging;

        public UC_Analytics()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(238, 242, 247);

            if (lblHome != null) lblHome.Visible = false;
            if (lblSeparator != null) lblSeparator.Visible = false;
            if (lblPageName != null) lblPageName.Visible = false;

            this.DoubleBuffered = true;

            // Events
            this.pnlDonutChart.Paint += pnlDonutChart_Paint;
            this.pnlLineChart.Paint += pnlLineChart_Paint;
            this.btnExpenses.Click += btnExpenses_Click;
            this.btnIncome.Click += btnIncome_Click;
            this.btnLoc.Click += btnLoc_Click;
            this.btnReset.Click += btnReset_Click;
            this.Load += UC_Analytics_Load;

            // 1. Apply Styles
            ApplyEnhancedStyles();

            // 2. Căn chỉnh vị trí Header thẳng hàng với Content dưới
            AlignHeaderItems();
        }

        private void AlignHeaderItems()
        {
            // Padding nội bộ bên trong cái hộp trắng
            int startX = 20;
            int currentX = startX;

            // --- 1. TABS (Expenses / Income) ---
            btnExpenses.Location = new System.Drawing.Point(currentX, 10);
            currentX += btnExpenses.Width + 10;

            btnIncome.Location = new System.Drawing.Point(currentX, 10);

            // Cập nhật luôn cái gạch chân ngay tại đây
            if (underline != null)
            {
                if (ActiveTab == "Expense")
                    underline.Location = new System.Drawing.Point(btnExpenses.Left, btnExpenses.Bottom - 3);
                else
                    underline.Location = new System.Drawing.Point(btnIncome.Left, btnIncome.Bottom - 3);
            }

            // --- 2. FILTER ROW (Dòng bộ lọc) ---
            int filterY = 65;
            int filterX = startX; // Reset X

            // Label Chọn ví
            lblChonVi.Location = new System.Drawing.Point(filterX, filterY + 4);
            filterX += lblChonVi.Width + 10;

            // ComboBox Ví
            cmbWallets.Location = new System.Drawing.Point(filterX, filterY);
            filterX += cmbWallets.Width + 20;

            // Label Tháng
            lblThang.Location = new System.Drawing.Point(filterX, filterY + 4);
            filterX += lblThang.Width + 10;

            // DateTimePicker
            dtpMonth.Location = new System.Drawing.Point(filterX, filterY);
            filterX += dtpMonth.Width + 20;

            // Nút Lọc
            btnLoc.Location = new System.Drawing.Point(filterX, filterY - 2);
            filterX += btnLoc.Width + 10;

            // Nút Reset
            btnReset.Location = new System.Drawing.Point(filterX, filterY - 2);
        }

        private void ApplyEnhancedStyles()
        {
            try
            {
                this.BackColor = Color.FromArgb(238, 242, 247);

                if (pnlChart != null) { pnlChart.BackColor = cardBgColor; pnlChart.Padding = new Padding(20); }
                if (pnlHistory != null) { pnlHistory.BackColor = cardBgColor; pnlHistory.Padding = new Padding(20); }
                if (pnlTrend != null) { pnlTrend.BackColor = cardBgColor; pnlTrend.Padding = new Padding(20); }

                if (lblExpensesBreakdown != null)
                {
                    lblExpensesBreakdown.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblExpensesBreakdown.ForeColor = Color.FromArgb(30, 41, 59);
                    lblExpensesBreakdown.Location = new Point(10, 20);
                }

                if (lblTrendTitle != null)
                {
                    lblTrendTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
                    lblTrendTitle.ForeColor = Color.FromArgb(30, 41, 59);
                }

                if (lblTotalExpenses != null)
                {
                    lblTotalExpenses.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
                    lblTotalExpenses.Padding = new Padding(10, 6, 10, 6);
                    lblTotalExpenses.AutoSize = true;
                    lblTotalExpenses.TextAlign = ContentAlignment.MiddleCenter;
                    lblTotalExpenses.BringToFront();
                }

                if (flpLegend != null) { flpLegend.Padding = new Padding(10); flpLegend.AutoScroll = true; }

                // GridView với scrollbar
                if (dgvTransactions != null)
                {
                    dgvTransactions.Dock = DockStyle.None;
                    dgvTransactions.Location = new Point(20, 80);
                    dgvTransactions.Size = new Size(pnlHistory.Width - 40, pnlHistory.Height - 100);
                    dgvTransactions.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
                    dgvTransactions.BringToFront();

                    dgvTransactions.BorderStyle = BorderStyle.None;
                    dgvTransactions.BackgroundColor = cardBgColor;
                    dgvTransactions.GridColor = Color.FromArgb(241, 245, 249);
                    dgvTransactions.RowHeadersVisible = false;
                    dgvTransactions.AllowUserToAddRows = false;
                    dgvTransactions.AllowUserToDeleteRows = false;
                    dgvTransactions.ReadOnly = true;
                    dgvTransactions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                    dgvTransactions.ScrollBars = ScrollBars.Vertical;
                    dgvTransactions.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
                }
            }
            catch (Exception ex) { System.Diagnostics.Debug.WriteLine($"Style error: {ex.Message}"); }
        }

        private async void UC_Analytics_Load(object sender, EventArgs e)
        {
            if (_isInitialized) return;

            try
            {
                cmbWallets.DisplayMember = "WalletName";
                cmbWallets.ValueMember = "WalletID";
                dtpMonth.Value = DateTime.Now;
                dtpMonth.Format = DateTimePickerFormat.Custom;
                dtpMonth.CustomFormat = "MMMM yyyy";

                // Create Underline
                underline = new Panel
                {
                    BackColor = tabActiveColor,
                    Size = new Size(btnExpenses.Width, 3)
                };
                pnlTabsAndFilters.Controls.Add(underline);

                // Đặt vị trí underline
                underline.Location = new Point(btnExpenses.Left, btnExpenses.Bottom - 3);
                underline.BringToFront();

                var analyticsService = Program.GetService<IAnalyticsService>();
                var walletService = Program.GetService<IWalletService>();
                _presenter = new AnalyticsPresenter(this, analyticsService, walletService);

                LoadWalletList?.Invoke(this, EventArgs.Empty);
                await System.Threading.Tasks.Task.Delay(50);
                ApplyFilter?.Invoke(this, EventArgs.Empty);

                _isInitialized = true;
            }
            catch (Exception ex) { MessageBox.Show($"Lỗi khởi tạo: {ex.Message}"); }
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
                if (cmbWallets.SelectedValue == null || cmbWallets.SelectedIndex == 0) return null;
                if (int.TryParse(cmbWallets.SelectedValue.ToString(), out int walletId)) return walletId;
                return null;
            }
        }

        public string SelectedMonth
        {
            get => dtpMonth.Value.ToString("yyyy-MM");
            set
            {
                if (DateTime.TryParseExact(value, "yyyy-MM", null, System.Globalization.DateTimeStyles.None, out var date))
                    dtpMonth.Value = date;
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
            if (_expenseBreakdown.Any()) { LoadExpensesChartLegend(); pnlDonutChart.Invalidate(); }
            else ShowEmptyState();
        }

        public void DisplayExpenseHistory(List<TransactionDto> history)
        {
            if (history != null && history.Any()) LoadExpensesTransactionHistory(history);
            else ShowEmptyTransactionHistory();
        }

        public void DisplayTotalExpense(decimal total)
        {
            lblTotalExpenses.Text = $"Tổng chi: {total:N0}đ";
            lblTotalExpenses.BackColor = totalExpenseBgColor;
            lblTotalExpenses.ForeColor = totalExpenseColor;
            lblTotalExpenses.Visible = true;
        }

        public void DisplayExpenseTrend(List<TrendDataPoint> trendData)
        {
            _expenseTrendData = trendData ?? new List<TrendDataPoint>();
            lblTrendTitle.Text = "Xu hướng chi tiêu";
            pnlLineChart.Invalidate();
        }

        public void DisplayIncomeBreakdown(List<IncomeBreakdownItem> breakdown)
        {
            _incomeBreakdown = breakdown ?? new List<IncomeBreakdownItem>();
            if (_incomeBreakdown.Any()) { LoadIncomeChartLegend(); pnlDonutChart.Invalidate(); }
            else ShowEmptyState();
        }

        public void DisplayIncomeHistory(List<IncomeTransactionDto> history)
        {
            if (history != null && history.Any()) LoadIncomeTransactionHistory(history);
            else ShowEmptyTransactionHistory();
        }

        public void DisplayTotalIncome(decimal total)
        {
            lblTotalExpenses.Text = $"Tổng thu: {total:N0}đ";
            lblTotalExpenses.BackColor = totalIncomeBgColor;
            lblTotalExpenses.ForeColor = totalIncomeColor;
            lblTotalExpenses.Visible = true;
        }

        public void DisplayIncomeTrend(List<TrendDataPoint> trendData)
        {
            _incomeTrendData = trendData ?? new List<TrendDataPoint>();
            lblTrendTitle.Text = "Xu hướng thu nhập";
            pnlLineChart.Invalidate();
        }

        public void DisplayPagingInfo(PagingInfo info) { _currentPaging = info; }
        public void ShowLoading(bool isVisible) { this.Cursor = isVisible ? Cursors.WaitCursor : Cursors.Default; }
        public void ShowError(string message) { MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        public void SetWalletList(List<WalletDto> wallets)
        {
            var allWallets = new List<WalletDto> { new WalletDto { WalletID = 0, WalletName = "Tất cả ví" } };
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

            lblExpensesBreakdown.Text = "Phân tích chi tiêu";
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

            lblExpensesBreakdown.Text = "Phân tích thu nhập";
            ApplyFilter?.Invoke(this, EventArgs.Empty);
        }

        #endregion

        #region Empty State & Donut Chart

        private void ShowEmptyState()
        {
            flpLegend.Controls.Clear();
            pnlDonutChart.Invalidate();
            Panel emptyPanel = new Panel { Size = new Size(flpLegend.Width - 20, 200), Margin = new Padding(10) };

            Label iconLabel = new Label { Text = "📊", Font = new Font("Segoe UI", 32F), ForeColor = Color.FromArgb(148, 163, 184), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
            iconLabel.Location = new Point((emptyPanel.Width - 40) / 2, 30);

            Label messageLabel = new Label { Text = isIncomeView ? "Chưa có dữ liệu thu nhập" : "Chưa có dữ liệu chi tiêu", Font = new Font("Segoe UI", 13F, FontStyle.Bold), ForeColor = Color.FromArgb(100, 116, 139), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
            messageLabel.Location = new Point((emptyPanel.Width - messageLabel.Width) / 2, 100);

            Label subLabel = new Label { Text = "Hãy thêm giao dịch để xem phân tích", Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(148, 163, 184), AutoSize = true, TextAlign = ContentAlignment.MiddleCenter };
            subLabel.Location = new Point((emptyPanel.Width - subLabel.Width) / 2, 130);

            emptyPanel.Controls.AddRange(new Control[] { iconLabel, messageLabel, subLabel });
            flpLegend.Controls.Add(emptyPanel);
        }

        private void ShowEmptyTransactionHistory()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Danhmuc"); dt.Columns.Add("Ngay"); dt.Columns.Add("Mota"); dt.Columns.Add("Sotien", typeof(string));
            dgvTransactions.DataSource = dt;
            dt.Rows.Add("", "", "Không có giao dịch nào trong khoảng thời gian này", "");
            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            foreach (DataGridViewColumn col in dgvTransactions.Columns) { col.Visible = true; col.DefaultCellStyle.ForeColor = Color.Transparent; }
            dgvTransactions.Columns["Mota"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvTransactions.Columns["Mota"].DefaultCellStyle.Font = new Font("Segoe UI", 11F, FontStyle.Italic);
            dgvTransactions.Columns["Mota"].DefaultCellStyle.ForeColor = Color.FromArgb(148, 163, 184);
        }

        private void pnlDonutChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;
            float[] values; Color[] colors;

            if (isIncomeView && _incomeBreakdown.Any()) { values = _incomeBreakdown.Select(b => (float)b.Percentage).ToArray(); colors = _incomeBreakdown.Select(b => ColorTranslator.FromHtml(b.ColorHex)).ToArray(); }
            else if (!isIncomeView && _expenseBreakdown.Any()) { values = _expenseBreakdown.Select(b => (float)b.Percentage).ToArray(); colors = _expenseBreakdown.Select(b => ColorTranslator.FromHtml(b.ColorHex)).ToArray(); }
            else { DrawEmptyChart(g); return; }

            int chartSize = Math.Min(pnlDonutChart.Width, pnlDonutChart.Height) - 40;
            int x = (pnlDonutChart.Width - chartSize) / 2;
            int y = (pnlDonutChart.Height - chartSize) / 2;
            Rectangle rect = new Rectangle(x, y, chartSize, chartSize);

            float currentAngle = -90;
            for (int i = 0; i < values.Length; i++)
            {
                float sweepAngle = 360f * (values[i] / 100f);
                using (SolidBrush brush = new SolidBrush(colors[i])) { g.FillPie(brush, rect, currentAngle, sweepAngle); }
                currentAngle += sweepAngle;
            }

            RectangleF holeRect = new RectangleF(rect.Left + (rect.Width * 0.175f), rect.Top + (rect.Height * 0.175f), rect.Width * 0.65f, rect.Height * 0.65f);
            using (SolidBrush brushWhite = new SolidBrush(cardBgColor)) { g.FillEllipse(brushWhite, holeRect); }
        }

        private void DrawEmptyChart(Graphics g)
        {
            int chartSize = Math.Min(pnlDonutChart.Width, pnlDonutChart.Height) - 40;
            int x = (pnlDonutChart.Width - chartSize) / 2;
            Rectangle rect = new Rectangle(x, (pnlDonutChart.Height - chartSize) / 2, chartSize, chartSize);
            using (SolidBrush brush = new SolidBrush(Color.FromArgb(241, 245, 249))) { g.FillEllipse(brush, rect); }
            RectangleF holeRect = new RectangleF(rect.Left + (rect.Width * 0.175f), rect.Top + (rect.Height * 0.175f), rect.Width * 0.65f, rect.Height * 0.65f);
            using (SolidBrush brushWhite = new SolidBrush(cardBgColor)) { g.FillEllipse(brushWhite, holeRect); }

            string text = "Chưa có dữ liệu";
            using (Font font = new Font("Segoe UI", 12F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, textBrush, new PointF(pnlDonutChart.Width / 2 - textSize.Width / 2, pnlDonutChart.Height / 2 - textSize.Height / 2));
            }
        }

        #endregion

        #region Line Chart (Trend)

        private void pnlLineChart_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            var trendData = isIncomeView ? _incomeTrendData : _expenseTrendData;

            if (trendData == null || !trendData.Any())
            {
                DrawEmptyTrendChart(g);
                return;
            }

            // Màu cho đường line
            Color lineColor = isIncomeView ? totalIncomeColor : totalExpenseColor;
            Color fillColor = isIncomeView ? Color.FromArgb(30, 22, 163, 74) : Color.FromArgb(30, 220, 38, 38);

            // Padding
            int padding = 50;
            int chartWidth = pnlLineChart.Width - (padding * 2);
            int chartHeight = pnlLineChart.Height - (padding * 2);

            if (chartWidth <= 0 || chartHeight <= 0) return;

            // Tìm min/max
            decimal maxValue = trendData.Max(d => d.Amount);
            decimal minValue = 0;
            decimal range = maxValue - minValue;
            if (range == 0) range = 1;

            // Vẽ grid lines
            DrawGridLines(g, padding, chartWidth, chartHeight, maxValue);

            // Tính toán points
            List<PointF> points = new List<PointF>();
            int dataCount = trendData.Count;
            float xStep = dataCount > 1 ? (float)chartWidth / (dataCount - 1) : chartWidth / 2;

            for (int i = 0; i < dataCount; i++)
            {
                float x = padding + (i * xStep);
                float y = padding + chartHeight - (float)((trendData[i].Amount - minValue) / range * chartHeight);
                points.Add(new PointF(x, y));
            }

            // Vẽ fill area
            if (points.Count > 1)
            {
                GraphicsPath fillPath = new GraphicsPath();
                fillPath.AddLine(points[0].X, padding + chartHeight, points[0].X, points[0].Y);
                for (int i = 0; i < points.Count - 1; i++)
                {
                    fillPath.AddLine(points[i], points[i + 1]);
                }
                fillPath.AddLine(points[points.Count - 1].X, points[points.Count - 1].Y, points[points.Count - 1].X, padding + chartHeight);
                fillPath.CloseFigure();

                using (SolidBrush fillBrush = new SolidBrush(fillColor))
                {
                    g.FillPath(fillBrush, fillPath);
                }
            }

            // Vẽ line
            if (points.Count > 1)
            {
                using (Pen linePen = new Pen(lineColor, 3))
                {
                    g.DrawLines(linePen, points.ToArray());
                }
            }

            // Vẽ points
            foreach (var point in points)
            {
                using (SolidBrush pointBrush = new SolidBrush(lineColor))
                {
                    g.FillEllipse(pointBrush, point.X - 4, point.Y - 4, 8, 8);
                }
                using (Pen whitePen = new Pen(Color.White, 2))
                {
                    g.DrawEllipse(whitePen, point.X - 4, point.Y - 4, 8, 8);
                }
            }

            // Vẽ labels
            DrawTrendLabels(g, trendData, points, padding, chartHeight);
        }

        private void DrawGridLines(Graphics g, int padding, int chartWidth, int chartHeight, decimal maxValue)
        {
            using (Pen gridPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                gridPen.DashStyle = DashStyle.Dash;

                // Horizontal grid lines (5 lines)
                for (int i = 0; i <= 4; i++)
                {
                    float y = padding + (chartHeight * i / 4f);
                    g.DrawLine(gridPen, padding, y, padding + chartWidth, y);

                    // Y-axis labels
                    decimal value = maxValue * (4 - i) / 4;
                    string label = value >= 1000000 ? $"{value / 1000000:F1}M" : $"{value / 1000:F0}K";
                    using (Font font = new Font("Segoe UI", 9F))
                    using (Brush brush = new SolidBrush(Color.FromArgb(100, 116, 139)))
                    {
                        SizeF size = g.MeasureString(label, font);
                        g.DrawString(label, font, brush, padding - size.Width - 10, y - size.Height / 2);
                    }
                }
            }
        }

        private void DrawTrendLabels(Graphics g, List<TrendDataPoint> trendData, List<PointF> points, int padding, int chartHeight)
        {
            using (Font font = new Font("Segoe UI", 9F))
            using (Brush brush = new SolidBrush(Color.FromArgb(100, 116, 139)))
            {
                for (int i = 0; i < trendData.Count; i++)
                {
                    string label = trendData[i].Label;
                    SizeF size = g.MeasureString(label, font);
                    float x = points[i].X - size.Width / 2;
                    float y = padding + chartHeight + 10;
                    g.DrawString(label, font, brush, x, y);
                }
            }
        }

        private void DrawEmptyTrendChart(Graphics g)
        {
            string text = "Chưa có dữ liệu xu hướng";
            using (Font font = new Font("Segoe UI", 14F, FontStyle.Bold))
            using (Brush textBrush = new SolidBrush(Color.FromArgb(148, 163, 184)))
            {
                SizeF textSize = g.MeasureString(text, font);
                g.DrawString(text, font, textBrush,
                    new PointF(pnlLineChart.Width / 2 - textSize.Width / 2,
                               pnlLineChart.Height / 2 - textSize.Height / 2));
            }
        }

        #endregion

        #region Helpers: Legend & Grid Setup

        private void LoadExpensesChartLegend()
        {
            flpLegend.Controls.Clear();
            foreach (var item in _expenseBreakdown) CreateLegendItem(ColorTranslator.FromHtml(item.ColorHex), item.CategoryName, $"{item.Amount:N0}đ", $"{item.Percentage:F1}%");
        }

        private void LoadIncomeChartLegend()
        {
            flpLegend.Controls.Clear();
            foreach (var item in _incomeBreakdown) CreateLegendItem(ColorTranslator.FromHtml(item.ColorHex), item.CategoryName, $"{item.Amount:N0}đ", $"{item.Percentage:F1}%");
        }

        private void CreateLegendItem(Color color, string name, string amount, string percent)
        {
            Panel pnlItem = new Panel { Size = new Size(flpLegend.Width - 40, 50), Margin = new Padding(5), BackColor = Color.FromArgb(248, 250, 252), Padding = new Padding(10) };
            Panel colorBox = new Panel { BackColor = color, Size = new Size(20, 20), Location = new Point(10, 15) };
            Label lblName = new Label { Text = name, Font = new Font("Segoe UI", 10F, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59), Location = new Point(45, 14), AutoSize = true };
            Label lblAmount = new Label { Text = amount, Font = new Font("Segoe UI", 10F), ForeColor = Color.FromArgb(100, 116, 139), Location = new Point(pnlItem.Width - 220, 14), AutoSize = true };
            Label lblPercent = new Label { Text = percent, Font = new Font("Segoe UI", 11F, FontStyle.Bold), ForeColor = color, Location = new Point(pnlItem.Width - 80, 13), AutoSize = true };
            pnlItem.Controls.AddRange(new Control[] { colorBox, lblName, lblAmount, lblPercent });
            flpLegend.Controls.Add(pnlItem);
        }

        private void LoadExpensesTransactionHistory(List<TransactionDto> transactions)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category"); dt.Columns.Add("Date"); dt.Columns.Add("Description"); dt.Columns.Add("Amount", typeof(decimal));
            foreach (var t in transactions) dt.Rows.Add(t.Category?.CategoryName ?? "N/A", t.TransactionDate.ToString("dd/MM/yyyy"), t.Description, -t.Amount);
            SetupDataGridView(dt);
        }

        private void LoadIncomeTransactionHistory(List<IncomeTransactionDto> transactions)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Category"); dt.Columns.Add("Date"); dt.Columns.Add("Description"); dt.Columns.Add("Amount", typeof(decimal));
            foreach (var t in transactions) dt.Rows.Add(t.Category?.CategoryName ?? "N/A", t.TransactionDate.ToString("dd/MM/yyyy"), t.Description, t.Amount);
            SetupDataGridView(dt);
        }

        private void SetupDataGridView(DataTable dt)
        {
            dgvTransactions.DataSource = dt;
            dgvTransactions.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            foreach (DataGridViewColumn col in dgvTransactions.Columns) { col.Visible = true; col.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59); }

            dgvTransactions.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgvTransactions.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(248, 250, 252);
            dgvTransactions.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(71, 85, 105);
            dgvTransactions.ColumnHeadersDefaultCellStyle.Padding = new Padding(10);
            dgvTransactions.ColumnHeadersHeight = 45;
            dgvTransactions.EnableHeadersVisualStyles = false;

            dgvTransactions.DefaultCellStyle.Font = new Font("Segoe UI", 10F);
            dgvTransactions.DefaultCellStyle.Padding = new Padding(10, 5, 10, 5);
            dgvTransactions.RowTemplate.Height = 50;

            dgvTransactions.Columns["Category"].HeaderText = "Danh mục";
            dgvTransactions.Columns["Date"].HeaderText = "Ngày";
            dgvTransactions.Columns["Description"].HeaderText = "Mô tả";
            dgvTransactions.Columns["Amount"].HeaderText = "Số tiền";

            dgvTransactions.Columns["Category"].FillWeight = 20;
            dgvTransactions.Columns["Date"].FillWeight = 15;
            dgvTransactions.Columns["Description"].FillWeight = 45;
            dgvTransactions.Columns["Amount"].FillWeight = 20;

            dgvTransactions.Columns["Amount"].DefaultCellStyle.Format = "N0";
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvTransactions.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            dgvTransactions.CellFormatting -= DgvTransactions_CellFormatting;
            dgvTransactions.CellFormatting += DgvTransactions_CellFormatting;
        }

        private void DgvTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvTransactions.Columns[e.ColumnIndex].Name == "Amount" && e.Value is decimal amount)
            {
                e.CellStyle.ForeColor = amount < 0 ? totalExpenseColor : totalIncomeColor;
                if (amount >= 0) e.Value = "+" + String.Format("{0:N0}", amount);
            }
        }
        #endregion
    }
}