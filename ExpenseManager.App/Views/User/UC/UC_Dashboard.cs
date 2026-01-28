using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using FontAwesome.Sharp; 

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Dashboard : UserControl, IDashboardView
    {
        private DashboardPresenter _presenter;
        private string _currentUserId;
        private readonly CultureInfo _cultureVI = new CultureInfo("vi-VN");

        private List<BalanceTrendPoint> _currentBalanceTrends;
        private ToolTip _chartTooltip;
        private List<ChartHitSpot> _chartHitSpots = new List<ChartHitSpot>();
        private ChartHitSpot _lastHoveredSpot = null;

        private List<BarHitSpot> _barHitSpots = new List<BarHitSpot>();
        private BarHitSpot _lastHoveredBar = null;

        private TableLayoutPanel _mainGrid;
        private Panel _pnlBudgets, _pnlChart, _pnlRecent, _pnlGoals;

        private class ChartHitSpot { public PointF ScreenLocation { get; set; } public decimal Amount { get; set; } public string Label { get; set; } }
        private class BarHitSpot { public RectangleF Rect { get; set; } public decimal Amount { get; set; } public string TypeLabel { get; set; } public string DateLabel { get; set; } }

        public UC_Dashboard()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(238, 242, 247);
            this.pnlStatCards.SendToBack();
            this.pnlHeader.SendToBack();
            //this.pnlHeader.Padding = new Padding(30, 50, 30, 30);

            this.Load += (s, e) => {
                int totalWidth = this.Width - 60; 
                int gap = 15;
                int cardWidth = (totalWidth - (gap * 3)) / 4; 

                // Set width và margin cho từng card
                pnlTotalBalance.Width = cardWidth;
                pnlTotalBalance.Margin = new Padding(0, 10, gap, 10);

                pnlPeriodIncome.Width = cardWidth;
                pnlPeriodIncome.Margin = new Padding(0, 10, gap, 10);

                pnlPeriodExpenses.Width = cardWidth;
                pnlPeriodExpenses.Margin = new Padding(0, 10, gap, 10);

                pnlPeriodChange.Width = cardWidth;
                pnlPeriodChange.Margin = new Padding(0, 10, 0, 10);

                // Đảm bảo pnlStatCards đủ rộng
                pnlStatCards.Width = this.Width - 60;
            };

            // Sự kiện Resize - Tự động điều chỉnh
            this.Resize += (s, e) => {
                int totalWidth = this.Width - 60;
                int gap = 15;
                int cardWidth = (totalWidth - (gap * 3)) / 4;

                pnlTotalBalance.Width = cardWidth;
                pnlPeriodIncome.Width = cardWidth;
                pnlPeriodExpenses.Width = cardWidth;
                pnlPeriodChange.Width = cardWidth;

                pnlStatCards.Width = this.Width - 60;
            };

            // Tăng chiều cao để chứa đủ nội dung và bật cuộn
            this.Size = new Size(1400, 1600);
            this.AutoScroll = true;

            InitializeCustomComponents();

            // Tự động kết nối Service 
            if (!this.DesignMode)
            {
                try
                {
                    var dashboardService = Program.GetService<IDashboardService>();
                    _presenter = new DashboardPresenter(this, dashboardService);
                }
                catch (Exception ex) { Console.WriteLine("Init Error: " + ex.Message); }
            }
        }
        public void SetUserId(string userId)
        {
            _currentUserId = userId;
            if (_presenter != null) _ = _presenter.LoadDashboardDataAsync();
        }
        public string GetCurrentUserId() => _currentUserId;

        private void UC_Dashboard_Load(object sender, EventArgs e)
        {
            ApplyRoundedCorners(pnlTotalBalance, 12);
            ApplyRoundedCorners(pnlPeriodChange, 12);
            ApplyRoundedCorners(pnlPeriodExpenses, 12);
            ApplyRoundedCorners(pnlPeriodIncome, 12);
            ApplyRoundedCorners(pnlBalanceTrends, 12);
            ApplyRoundedCorners(pnlExpensesBreakdown, 12);
        }

        private void InitializeCustomComponents()
        {   
            lblBalanceTrendsAmount.Visible = false;
            lblBalanceTrendsChange.Visible = false;

          
            pnlMainContent.Dock = DockStyle.None;
            pnlMainContent.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            pnlMainContent.Location = new Point(0, 290);
            pnlMainContent.Size = new Size(this.Width, 400);

            // Chỉnh chiều cao khung chứa biểu đồ (Gọn gàng: 350px)
            pnlBalanceTrends.Height = 350;

            pnlBalanceChart.Location = new Point(10, 60);
            pnlBalanceChart.Size = new Size(pnlBalanceTrends.Width - 20, pnlBalanceTrends.Height - 70);
            pnlBalanceChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Chỉnh List chi tiêu Full Width
            pnlExpensesList.Location = new Point(25, 70);
            pnlExpensesList.Width = pnlExpensesBreakdown.Width - 50;
            pnlExpensesList.Height = pnlExpensesBreakdown.Height - 90;
            pnlExpensesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            InitializeBottomLayout();

            // Tooltip
            _chartTooltip = new ToolTip();
            _chartTooltip.AutoPopDelay = 5000;
            _chartTooltip.InitialDelay = 100;
            _chartTooltip.ReshowDelay = 100;

            // Đăng ký sự kiện vẽ biểu đồ
            this.pnlBalanceChart.MouseMove += PnlBalanceChart_MouseMove;

            this.Load += UC_Dashboard_Load;
        }

        private void InitializeBottomLayout()
        {
            _mainGrid = new TableLayoutPanel();
            _mainGrid.ColumnCount = 2;
            _mainGrid.RowCount = 2;
            _mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _mainGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            _mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F)); // Tăng chiều cao mỗi hàng lên 350
            _mainGrid.RowStyles.Add(new RowStyle(SizeType.Absolute, 350F));

            _mainGrid.Location = new Point(20, 710);
            _mainGrid.Size = new Size(this.Width - 40, 720);
            _mainGrid.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.Controls.Add(_mainGrid);

            _pnlBudgets = CreateCard("Ngân Sách Hàng Tháng");
            _pnlChart = CreateCard("Thu Nhập vs Chi Tiêu");
            _pnlRecent = CreateCard("Giao Dịch Gần Đây");
            _pnlGoals = CreateCard("Mục Tiêu Tiết Kiệm");

            // Label "7 ngày"
            Label lblPeriod = new Label { Text = "7 ngày", Location = new Point(_pnlChart.Width - 90, 18), Size = new Size(70, 26), Anchor = AnchorStyles.Top | AnchorStyles.Right, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9), BackColor = Color.White };
            lblPeriod.Paint += (s, e) => { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (GraphicsPath p = GetRoundedPath(lblPeriod.ClientRectangle, 4)) using (Pen pen = new Pen(Color.FromArgb(209, 213, 219))) e.Graphics.DrawPath(pen, p); };
            _pnlChart.Controls.Add(lblPeriod);

            _mainGrid.Controls.Add(_pnlBudgets, 0, 0);
            _mainGrid.Controls.Add(_pnlChart, 1, 0);
            _mainGrid.Controls.Add(_pnlRecent, 0, 1);
            _mainGrid.Controls.Add(_pnlGoals, 1, 1);
        }

        private Panel CreateCard(string title)
        {
            Panel card = new Panel { Dock = DockStyle.Fill, BackColor = Color.White, Margin = new Padding(10) };
            card.Paint += (s, e) => { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (GraphicsPath p = GetRoundedPath(card.ClientRectangle, 12)) using (Pen pen = new Pen(Color.FromArgb(229, 231, 235))) e.Graphics.DrawPath(pen, p); };
            card.Controls.Add(new Label { Text = title, Font = new Font("Segoe UI", 12F, FontStyle.Bold), ForeColor = Color.FromArgb(17, 24, 39), Location = new Point(20, 20), AutoSize = true });
            return card;
        }

        public void DisplayDashboardStats(DashboardStats stats)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => DisplayDashboardStats(stats))); return; }

            lblTotalBalanceAmount.Text = FormatCurrency(stats.TotalBalance);
            UpdateComparisonLabel(lblTotalBalanceChange, stats.Comparison.BalanceChangePercent, stats.Comparison.IsFirstMonth);
            lblPeriodIncomeAmount.Text = FormatCurrency(stats.MonthlyIncome);
            lblPeriodExpensesAmount.Text = FormatCurrency(stats.MonthlyExpense);
            UpdateComparisonLabel(lblPeriodIncomePercent, stats.Comparison.IncomeChangePercent, stats.Comparison.IsFirstMonth);
            UpdateComparisonLabel(lblPeriodExpensesPercent, stats.Comparison.ExpenseChangePercent, stats.Comparison.IsFirstMonth, true);

            if (stats.CurrentBudget != null)
            {
                lblPeriodChangeTitle.Text = $"Ngân sách: {stats.CurrentBudget.BudgetName}";
                lblPeriodChangeAmount.Text = $"{FormatCurrency(stats.CurrentBudget.SpentAmount)} / {FormatCurrency(stats.CurrentBudget.BudgetAmount)}";
                lblPeriodChangeAmount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                lblPeriodChangePercent.Text = $"Đã dùng {stats.CurrentBudget.UsagePercent}%";
            }

            if (stats.BalanceTrends != null && stats.BalanceTrends.Any())
            {
                DrawBalanceChart(stats.BalanceTrends);
            }

            LoadExpensesData(stats.ExpenseBreakdown);
            RenderBudgetList(stats.Budgets);
            RenderBarChart(stats.DailyAnalysis);
            RenderRecentList(stats.RecentTransactions);
            RenderGoalsList(stats.Goals);

            lblSubtitle.Text = stats.Comparison.IsFirstMonth ? "Chào mừng bạn đến với Ekash!" : "Dữ liệu được cập nhật mới nhất";
        }
        private void DrawBalanceChart(List<BalanceTrendPoint> trendPoints)
        {
            pnlBalanceChart.Controls.Clear();
            pnlBalanceChart.Paint -= PnlBalanceChart_Paint;
            _currentBalanceTrends = trendPoints;
            _chartHitSpots.Clear();
            pnlBalanceChart.Paint += PnlBalanceChart_Paint;
            pnlBalanceChart.Invalidate();
        }

        private void PnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            var trends = _currentBalanceTrends;
            if (trends == null || !trends.Any()) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Color tealDark = Color.FromArgb(20, 184, 166);
            Color tealLight = Color.FromArgb(100, 45, 212, 191);
            Color tealTransparent = Color.FromArgb(10, 45, 212, 191);
            Color zeroLineColor = Color.FromArgb(156, 163, 175);
            Color gridColor = Color.FromArgb(240, 240, 240);
            Color axisTextColor = Color.Gray;

            int w = pnlBalanceChart.Width;
            int h = pnlBalanceChart.Height;
            int marginLeft = 60, marginRight = 20, marginTop = 20, marginBottom = 30;
            int chartH = h - marginTop - marginBottom;
            int chartW = w - marginLeft - marginRight;

            var maxVal = trends.Max(t => t.NetAmount);
            var minVal = trends.Min(t => t.NetAmount);
            var range = maxVal - minVal;
            if (range == 0) range = 100000;

            var chartMax = maxVal + (range * 0.1m);
            var chartMin = minVal - (range * 0.1m);
            if (chartMax < 0) chartMax = 0;
            if (chartMin > 0) chartMin = 0;
            var chartRange = chartMax - chartMin;

            using (var penGrid = new Pen(gridColor, 1))
            using (var penZero = new Pen(zeroLineColor, 1) { DashStyle = DashStyle.Dash })
            using (var fontAxis = new Font("Segoe UI", 8, FontStyle.Regular))
            using (var brushAxis = new SolidBrush(axisTextColor))
            {
                int steps = 5;
                for (int i = 0; i <= steps; i++)
                {
                    decimal value = chartMin + (chartRange * i / steps);
                    float y = marginTop + chartH - (float)((value - chartMin) / chartRange) * chartH;
                    bool isZeroLine = Math.Abs(value) < (chartRange / 100);

                    if (isZeroLine)
                    {
                        g.DrawLine(penZero, marginLeft, y, w - marginRight, y);
                        g.DrawString("0", fontAxis, Brushes.Black, marginLeft - 15, y - 6);
                    }
                    else
                    {
                        g.DrawLine(penGrid, marginLeft, y, w - marginRight, y);
                        string label = FormatShort(value);
                        SizeF size = g.MeasureString(label, fontAxis); // Đã có biến size
                        g.DrawString(label, fontAxis, brushAxis, marginLeft - size.Width - 5, y - size.Height / 2);
                    }
                }
                g.DrawLine(penGrid, marginLeft, marginTop, marginLeft, h - marginBottom);
            }

            List<PointF> pts = new List<PointF>();
            _chartHitSpots.Clear();
            float stepX = (float)chartW / (trends.Count - 1);

            for (int i = 0; i < trends.Count; i++)
            {
                float x = marginLeft + i * stepX;
                float y = marginTop + chartH - (float)((trends[i].NetAmount - chartMin) / chartRange) * chartH;
                pts.Add(new PointF(x, y));
                _chartHitSpots.Add(new ChartHitSpot { ScreenLocation = new PointF(x, y), Amount = trends[i].NetAmount, Label = trends[i].Label });
            }

            if (pts.Count > 1)
            {
                GraphicsPath path = new GraphicsPath();
                float bottomY = marginTop + chartH;
                path.AddLine(marginLeft, bottomY, pts[0].X, pts[0].Y);
                path.AddCurve(pts.ToArray(), 0.1f);
                path.AddLine(pts.Last().X, pts.Last().Y, w - marginRight, bottomY);
                path.CloseFigure();

                using (var brush = new LinearGradientBrush(new Rectangle(0, marginTop, w, chartH), tealLight, tealTransparent, LinearGradientMode.Vertical))
                    g.FillPath(brush, path);

                using (var pen = new Pen(tealDark, 2))
                    g.DrawCurve(pen, pts.ToArray(), 0.1f);
            }

            using (var fontDate = new Font("Segoe UI", 8, FontStyle.Regular))
            using (var brushDate = new SolidBrush(axisTextColor))
            using (var whiteBrush = new SolidBrush(Color.White))
            using (var circleBrush = new SolidBrush(tealDark))
            using (var negativeBrush = new SolidBrush(Color.FromArgb(239, 68, 68)))
            {
                for (int i = 0; i < pts.Count; i++)
                {
                    var p = pts[i];
                    var currentBrush = trends[i].NetAmount >= 0 ? circleBrush : negativeBrush;
                    g.FillEllipse(whiteBrush, p.X - 5, p.Y - 5, 10, 10);
                    g.FillEllipse(currentBrush, p.X - 3, p.Y - 3, 6, 6);
                    string dateLabel = trends[i].Label;
                    SizeF textSize = g.MeasureString(dateLabel, fontDate);
                    g.DrawString(dateLabel, fontDate, brushDate, p.X - (textSize.Width / 2), h - 20);
                }
            }
        }

        // Tìm hàm PnlBalanceChart_MouseMove và thay thế bằng đoạn này:
        private void PnlBalanceChart_MouseMove(object sender, MouseEventArgs e)
        {
            // Tìm điểm đang hover
            ChartHitSpot hitSpot = _chartHitSpots.FirstOrDefault(s =>
                Math.Sqrt(Math.Pow(e.X - s.ScreenLocation.X, 2) + Math.Pow(e.Y - s.ScreenLocation.Y, 2)) <= 15);

            if (hitSpot != null && hitSpot != _lastHoveredSpot)
            {
                // Hiển thị Tooltip
                _chartTooltip.Show(
                    $"{hitSpot.Label}\n{FormatCurrency(hitSpot.Amount)}",
                    pnlBalanceChart,
                    (int)hitSpot.ScreenLocation.X,      
                    (int)hitSpot.ScreenLocation.Y - 40  
                );

                pnlBalanceChart.Cursor = Cursors.Hand;
                _lastHoveredSpot = hitSpot;
            }
            else if (hitSpot == null && _lastHoveredSpot != null)
            {
                _chartTooltip.Hide(pnlBalanceChart);
                pnlBalanceChart.Cursor = Cursors.Default;
                _lastHoveredSpot = null;
            }
        }

        private void RenderBarChart(List<DailyAnalysisDto> data)
        {
            _pnlChart.Controls.Clear();
            _pnlChart.Controls.Add(new Label { Text = "Thu Nhập vs Chi Tiêu", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            Label lblPeriod = new Label { Text = "7 ngày", Location = new Point(_pnlChart.Width - 90, 18), Size = new Size(70, 26), Anchor = AnchorStyles.Top | AnchorStyles.Right, TextAlign = ContentAlignment.MiddleCenter, Font = new Font("Segoe UI", 9), BackColor = Color.White };
            lblPeriod.Paint += (s, e) => { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (GraphicsPath p = GetRoundedPath(lblPeriod.ClientRectangle, 4)) using (Pen pen = new Pen(Color.FromArgb(209, 213, 219))) e.Graphics.DrawPath(pen, p); };
            _pnlChart.Controls.Add(lblPeriod);

            if (data == null || !data.Any()) return;

            PictureBox pic = new PictureBox { Location = new Point(20, 60), Size = new Size(_pnlChart.Width - 40, 240), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom, BackColor = Color.White };
            _pnlChart.Controls.Add(pic);

            pic.MouseMove += PnlBarChart_MouseMove;

            pic.Paint += (s, e) => {
                var g = e.Graphics; g.SmoothingMode = SmoothingMode.AntiAlias; _barHitSpots.Clear();
                decimal maxVal = Math.Max(data.Max(d => d.Income), data.Max(d => d.Expense)); if (maxVal == 0) maxVal = 1;
                int ml = 100, mb = 30, w = pic.Width, h = pic.Height, chartW = w - ml, chartH = h - mb - 20;

                using (var pGrid = new Pen(Color.FromArgb(240, 240, 240))) using (var f = new Font("Segoe UI", 8)) using (var b = new SolidBrush(Color.Gray))
                {
                    for (int i = 0; i <= 5; i++)
                    {
                        decimal v = maxVal * i / 5; float y = 20 + chartH - (float)(v / maxVal) * chartH;
                        g.DrawLine(pGrid, ml, y, w, y);
                        string lbl = FormatShort(v); SizeF sz = g.MeasureString(lbl, f);
                        g.DrawString(lbl, f, b, ml - sz.Width - 10, y - sz.Height / 2);
                    }
                    g.DrawLine(pGrid, ml, 20, ml, h - mb);
                }

                int count = data.Count; float colW = (float)(chartW - 20) / count / 3; if (colW > 30) colW = 30;
                using (Brush bInc = new SolidBrush(Color.FromArgb(99, 102, 241))) using (Brush bExp = new SolidBrush(Color.FromArgb(199, 210, 254))) using (Font f = new Font("Segoe UI", 8))
                {
                    float sx = ml + 10;
                    for (int i = 0; i < count; i++)
                    {
                        float x = sx + (i * (colW * 2 + colW));
                        float hInc = (float)(data[i].Income / maxVal) * chartH, hExp = (float)(data[i].Expense / maxVal) * chartH;
                        RectangleF rI = new RectangleF(x, 20 + chartH - hInc, colW, hInc), rE = new RectangleF(x + colW, 20 + chartH - hExp, colW, hExp);
                        g.FillRectangle(bInc, rI); g.FillRectangle(bExp, rE);
                        _barHitSpots.Add(new BarHitSpot { Rect = rI, Amount = data[i].Income, TypeLabel = "Thu", DateLabel = data[i].Label });
                        _barHitSpots.Add(new BarHitSpot { Rect = rE, Amount = data[i].Expense, TypeLabel = "Chi", DateLabel = data[i].Label });
                        g.DrawString(data[i].Label, f, Brushes.Gray, x, h - mb + 5);
                    }
                }
            };
        }

        private void PnlBarChart_MouseMove(object sender, MouseEventArgs e)
        {
            BarHitSpot spot = _barHitSpots.FirstOrDefault(s => s.Rect.Contains(e.Location));
            if (spot != null && spot != _lastHoveredBar)
            {
                _chartTooltip.Show($"{spot.DateLabel}\n{spot.TypeLabel}: {FormatCurrency(spot.Amount)}", (Control)sender, (int)(spot.Rect.X + spot.Rect.Width / 2), (int)spot.Rect.Y);
                _lastHoveredBar = spot;
            }
            else if (spot == null && _lastHoveredBar != null) { _chartTooltip.Hide((Control)sender); _lastHoveredBar = null; }
        }

        private void RenderRecentList(List<RecentTransactionDto> txs)
        {
            _pnlRecent.Controls.Clear();
            _pnlRecent.Controls.Add(new Label { Text = "Giao Dịch Gần Đây", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            int y = 60;
            var fontHead = new Font("Segoe UI", 9, FontStyle.Bold);
            _pnlRecent.Controls.Add(new Label { Text = "Danh mục", Location = new Point(20, y), Font = fontHead, ForeColor = Color.Gray, AutoSize = true });
            _pnlRecent.Controls.Add(new Label { Text = "Ngày", Location = new Point(180, y), Font = fontHead, ForeColor = Color.Gray, AutoSize = true });
            _pnlRecent.Controls.Add(new Label { Text = "Nội dung", Location = new Point(300, y), Font = fontHead, ForeColor = Color.Gray, AutoSize = true });
            _pnlRecent.Controls.Add(new Label { Text = "Số tiền", Location = new Point(_pnlRecent.Width - 100, y), Font = fontHead, ForeColor = Color.Gray, AutoSize = true, Anchor = AnchorStyles.Top | AnchorStyles.Right, TextAlign = ContentAlignment.TopRight });

            _pnlRecent.Controls.Add(new Panel { Height = 1, BackColor = Color.FromArgb(243, 244, 246), Width = _pnlRecent.Width - 40, Location = new Point(20, y + 25), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right });

            if (txs == null || txs.Count == 0) return;

            y += 40;
            var fontText = new Font("Segoe UI", 10);

            foreach (var tx in txs)
            {
                Color catColor = GetColorSafe(tx.ColorHex);
                Panel pnlIcon = new Panel { Size = new Size(32, 32), Location = new Point(20, y - 5) };
                pnlIcon.Paint += (s, e) => { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (SolidBrush b = new SolidBrush(Color.FromArgb(30, catColor))) e.Graphics.FillEllipse(b, 0, 0, 31, 31); };

                IconPictureBox iconPic = new IconPictureBox { IconChar = ParseIcon(tx.CategoryIcon), IconColor = catColor, IconSize = 18, Size = new Size(18, 18), Location = new Point(7, 7), BackColor = Color.Transparent };
                pnlIcon.Controls.Add(iconPic);

                Label lblName = new Label { Text = tx.CategoryName, Location = new Point(65, y), AutoSize = true, Font = fontText, ForeColor = Color.FromArgb(55, 65, 81) };
                Label lblDate = new Label { Text = tx.Date.ToString("dd/MM/yyyy"), Location = new Point(180, y), AutoSize = true, ForeColor = Color.Gray, Font = fontText };
                Label lblNote = new Label { Text = tx.Note, Location = new Point(300, y), AutoSize = false, Width = 200, Height = 20, ForeColor = Color.FromArgb(55, 65, 81), Font = fontText, AutoEllipsis = true };

                bool isExp = tx.Type == "Expense";
                Label lblAmt = new Label
                {
                    Text = (isExp ? "-" : "+") + FormatCurrency(tx.Amount),
                    Location = new Point(_pnlRecent.Width - 150, y),
                    AutoSize = false,
                    Width = 130,
                    TextAlign = ContentAlignment.MiddleRight,
                    ForeColor = isExp ? Color.Red : Color.Green,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    Anchor = AnchorStyles.Top | AnchorStyles.Right
                };

                _pnlRecent.Controls.AddRange(new Control[] { pnlIcon, lblName, lblDate, lblNote, lblAmt });
                y += 45;
            }
        }
        private void LoadExpensesData(List<ExpenseCategoryBreakdown> expenses)
        {
            pnlExpensesList.Controls.Clear(); if (expenses == null) return;
            Panel bar = new Panel { Height = 10, Width = pnlExpensesList.Width - 25, Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
            bar.Paint += (s, ev) => { float x = 0; foreach (var ex in expenses) { float w = (float)(ex.Percentage / 100.0) * bar.Width; using (SolidBrush b = new SolidBrush(GetColorSafe(ex.ColorHex))) ev.Graphics.FillRectangle(b, x, 0, w, 10); x += w; } };
            pnlExpensesList.Controls.Add(bar); int y = 40; foreach (var ex in expenses) { var p = CreateExpenseItem(ex); p.Location = new Point(0, y); p.Width = pnlExpensesList.Width - 25; p.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right; pnlExpensesList.Controls.Add(p); y += 70; }
        }
        private Panel CreateExpenseItem(ExpenseCategoryBreakdown exp)
        {
            var p = new Panel { Height = 60 }; p.Controls.Add(new Panel { Size = new Size(14, 14), Location = new Point(5, 23), BackColor = GetColorSafe(exp.ColorHex) });
            p.Controls.Add(new Label { Text = exp.CategoryName, Location = new Point(30, 18), AutoSize = true, Font = new Font("Segoe UI", 11) });
            p.Controls.Add(new Label { Text = FormatCurrency(exp.Amount), Location = new Point(p.Width - 220, 17), AutoSize = true, Font = new Font("Segoe UI", 12, FontStyle.Bold), Anchor = AnchorStyles.Top | AnchorStyles.Right });
            p.Controls.Add(new Label { Text = exp.Percentage + "%", Location = new Point(p.Width - 60, 18), AutoSize = true, ForeColor = Color.Gray, Anchor = AnchorStyles.Top | AnchorStyles.Right }); return p;
        }

        private void RenderBudgetList(List<BudgetDto> budgets)
        {
            _pnlBudgets.Controls.Clear();
            _pnlBudgets.Controls.Add(new Label { Text = "Ngân Sách Hàng Tháng", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            if (budgets == null) return;
            int y = 60;

            foreach (var b in budgets)
            {
                Color catColor = GetColorSafe(b.ColorHex);

                // 1. Icon FontAwesome 
                IconPictureBox iconPic = new IconPictureBox
                {
                    IconChar = ParseIcon(b.CategoryIcon), 
                    IconColor = catColor,
                    IconSize = 20,
                    Size = new Size(20, 20),
                    Location = new Point(20, y + 2), 
                    BackColor = Color.Transparent,
                    SizeMode = PictureBoxSizeMode.CenterImage
                };
                _pnlBudgets.Controls.Add(iconPic);

                // 2. Tên Ngân sách 
                _pnlBudgets.Controls.Add(new Label
                {
                    Text = b.Name,
                    Location = new Point(50, y), 
                    AutoSize = true,
                    Font = new Font("Segoe UI", 10, FontStyle.Bold),
                    ForeColor = Color.FromArgb(55, 65, 81)
                });

                // 3. Số tiền 
                Label lblAmt = new Label
                {
                    Text = $"{FormatShort(b.Spent)}/{FormatShort(b.Limit)}",
                    Location = new Point(_pnlBudgets.Width - 140, y),
                    AutoSize = false,
                    Width = 120,
                    TextAlign = ContentAlignment.MiddleRight,
                    Anchor = AnchorStyles.Top | AnchorStyles.Right,
                    ForeColor = Color.Gray,
                    Font = new Font("Segoe UI", 9)
                };
                _pnlBudgets.Controls.Add(lblAmt);

                // 4. Thanh Progress
                Panel pnlBar = new Panel { Size = new Size(_pnlBudgets.Width - 40, 6), Location = new Point(20, y + 25), BackColor = Color.FromArgb(243, 244, 246), Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right };
                Panel pnlFill = new Panel { Height = 6, BackColor = catColor, Location = new Point(0, 0) };
                float pct = (float)Math.Min(b.Percent, 100);
                pnlFill.Width = (int)((pnlBar.Width * pct) / 100);

                pnlBar.Resize += (s, e) => { pnlFill.Width = (int)((pnlBar.Width * pct) / 100); };

                pnlBar.Controls.Add(pnlFill);
                _pnlBudgets.Controls.Add(pnlBar);

                y += 55;
            }
        }
        private void RenderGoalsList(List<GoalDto> goals)
        {
            _pnlGoals.Controls.Clear();
            _pnlGoals.Controls.Add(new Label { Text = "Mục Tiêu Tiết Kiệm", Font = new Font("Segoe UI", 12, FontStyle.Bold), Location = new Point(20, 20), AutoSize = true });

            if (goals == null || !goals.Any()) return;

            int itemWidth = 140;
            int totalWidth = goals.Count * itemWidth;
            int startX = (_pnlGoals.Width - totalWidth) / 2;
            if (startX < 10) startX = 10;

            int x = startX;
            foreach (var g in goals)
            {
                Panel pItem = new Panel { Size = new Size(120, 180), Location = new Point(x, 60) };
                _pnlGoals.Controls.Add(pItem);

                PictureBox picCircle = new PictureBox { Size = new Size(100, 100), Location = new Point(10, 0) };
                pItem.Controls.Add(picCircle);

                Label lblName = new Label { Text = g.Name, AutoSize = false, Width = 120, Height = 40, TextAlign = ContentAlignment.TopCenter, Location = new Point(0, 110), Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(55, 65, 81) };
                pItem.Controls.Add(lblName);

                picCircle.Paint += (s, e) => {
                    e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                    int size = 90;
                    Rectangle rect = new Rectangle(5, 5, size, size);

                    // 1. Vòng nền xám
                    using (Pen p1 = new Pen(Color.FromArgb(243, 244, 246), 8))
                        e.Graphics.DrawEllipse(p1, rect);

                    // 2. Vòng tiến độ xanh
                    if (g.Percent > 0)
                    {
                        using (Pen p2 = new Pen(Color.FromArgb(37, 99, 235), 8) { StartCap = LineCap.Round, EndCap = LineCap.Round })
                        {
                            // Tính góc quét
                            float angle = (float)(g.Percent * 360) / 100;

                            if (angle < 5) angle = 5;

                            e.Graphics.DrawArc(p2, rect, -90, angle);
                        }
                    }

                    // 3. Text % ở giữa
                    string txt = (g.Percent % 1 == 0)
                        ? $"{g.Percent}%"
                        : $"{g.Percent:0.##}%"; 

                    using (Font f = new Font("Segoe UI", 13, FontStyle.Bold))
                    {
                        SizeF ts = e.Graphics.MeasureString(txt, f);
                        e.Graphics.DrawString(txt, f, Brushes.Black, 5 + (size - ts.Width) / 2, 5 + (size - ts.Height) / 2);
                    }
                };
                x += itemWidth;
            }
        }

        public void ShowLoading() { Cursor = Cursors.WaitCursor; }
        public void HideLoading() { Cursor = Cursors.Default; }
        public void DisplayError(string message) { MessageBox.Show(message); }
        private string FormatCurrency(decimal amount) => string.Format(_cultureVI, "{0:N0}đ", amount);
        private string FormatShort(decimal amount) { string p = amount < 0 ? "-" : ""; amount = Math.Abs(amount); if (amount >= 1000000000) return p + (amount / 1000000000).ToString("0.#") + "B"; if (amount >= 1000000) return p + (amount / 1000000).ToString("0.#") + "Tr"; if (amount >= 1000) return p + (amount / 1000).ToString("0.#") + "K"; return p + amount.ToString("N0"); }
        private Color GetColorSafe(string hex) { try { return ColorTranslator.FromHtml(hex); } catch { return Color.Gray; } }
        private void UpdateComparisonLabel(Label l, decimal p, bool f, bool e = false) { if (f) { l.Text = "Bắt đầu"; return; } l.Text = $"{(p > 0 ? "↗" : "↘")} {Math.Abs(p)}%"; l.ForeColor = (e ? (p > 0) : (p < 0)) ? Color.Red : Color.Green; }
        private GraphicsPath GetRoundedPath(Rectangle r, int d) { GraphicsPath p = new GraphicsPath(); int dia = d * 2; p.AddArc(r.X, r.Y, dia, dia, 180, 90); p.AddArc(r.Right - dia, r.Y, dia, dia, 270, 90); p.AddArc(r.Right - dia, r.Bottom - dia, dia, dia, 0, 90); p.AddArc(r.X, r.Bottom - dia, dia, dia, 90, 90); p.CloseFigure(); return p; }
        private void ApplyRoundedCorners(Panel p, int r) { p.Paint += (s, e) => { e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; using (var path = GetRoundedPath(new Rectangle(0, 0, p.Width - 1, p.Height - 1), r)) using (var pen = new Pen(Color.FromArgb(229, 231, 235))) e.Graphics.DrawPath(pen, path); }; }

        private IconChar ParseIcon(string name)
        {
            if (string.IsNullOrEmpty(name)) return IconChar.QuestionCircle;
            if (Enum.TryParse(name, true, out IconChar icon)) return icon;

            string cleanName = name.Split(' ').Last().Replace("fa-", "").Replace("-", "").Replace(" ", "");
            if (Enum.TryParse(cleanName, true, out IconChar cleanIcon)) return cleanIcon;

            switch (cleanName.ToLower())
            {
                case "utensils": return IconChar.Utensils;
                case "bussimple": return IconChar.Bus;
                case "gaspump": return IconChar.GasPump;
                case "fileinvoicedollar": return IconChar.FileInvoiceDollar;
                case "houseuser": return IconChar.HouseUser;
                case "shirt": return IconChar.Tshirt;
                case "cartshopping": return IconChar.ShoppingCart;
                case "screwdriverwrench": return IconChar.Tools;
                case "heartpulse": return IconChar.Heartbeat;
                case "graduationcap": return IconChar.GraduationCap;
                case "film": return IconChar.Film;
                case "dumbbell": return IconChar.Dumbbell;
                case "wandmagicsparkles": return IconChar.Magic;
                case "mughot": return IconChar.MugHot;
                case "planedeparture": return IconChar.PlaneDeparture;
                case "palette": return IconChar.Palette;
                case "gift": return IconChar.Gift;
                case "childreaching": return IconChar.Child;
                case "paw": return IconChar.Paw;
                case "moneybillwave": return IconChar.MoneyBillWave;
                default: return IconChar.Circle;
            }
        }
    }
}