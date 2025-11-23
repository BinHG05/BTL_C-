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

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Dashboard : UserControl, IDashboardView
    {
        private DashboardPresenter _presenter;
        private string _currentUserId;
        private readonly CultureInfo _cultureVI = new CultureInfo("vi-VN");

        // Biến cho biểu đồ
        private List<BalanceTrendPoint> _currentBalanceTrends;
        private ToolTip _chartTooltip;
        private List<ChartHitSpot> _chartHitSpots = new List<ChartHitSpot>();
        private ChartHitSpot _lastHoveredSpot = null;

        private class ChartHitSpot
        {
            public PointF ScreenLocation { get; set; }
            public decimal Amount { get; set; }
            public string Label { get; set; }
        }

        public UC_Dashboard()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(238, 242, 247);
            InitializeCustomComponents();

            // --- Tự động kết nối Service ---
            if (!this.DesignMode)
            {
                try
                {
                    var dashboardService = Program.GetService<IDashboardService>();
                    _presenter = new DashboardPresenter(this, dashboardService);
                }
                catch (Exception ex) { Console.WriteLine("Lỗi init Dashboard: " + ex.Message); }
            }
        }

        public void SetUserId(string userId)
        {
            _currentUserId = userId;
            if (_presenter != null) _ = _presenter.LoadDashboardDataAsync();
        }

        public string GetCurrentUserId() => _currentUserId;

        private void UC_Dashboard_Load(object sender, EventArgs e) { }

        private void InitializeCustomComponents()
        {
            ApplyRoundedCorners(pnlTotalBalance, 12);
            ApplyRoundedCorners(pnlPeriodChange, 12);
            ApplyRoundedCorners(pnlPeriodExpenses, 12);
            ApplyRoundedCorners(pnlPeriodIncome, 12);
            ApplyRoundedCorners(pnlBalanceTrends, 12);
            ApplyRoundedCorners(pnlExpensesBreakdown, 12);

            // --- CẤU HÌNH LAYOUT ---
            lblBalanceTrendsAmount.Visible = false;
            lblBalanceTrendsChange.Visible = false;

            // 1. Layout Biểu đồ
            pnlBalanceTrends.Height = 280;
            pnlBalanceChart.Location = new Point(10, 60);
            pnlBalanceChart.Size = new Size(pnlBalanceTrends.Width - 20, pnlBalanceTrends.Height - 70);
            pnlBalanceChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // 2. Layout Danh sách chi tiêu (SỬA ĐỂ FULL WIDTH)
            // Đặt kích thước ban đầu rộng ra để lấp đầy panel cha
            pnlExpensesList.Location = new Point(25, 70);
            pnlExpensesList.Width = pnlExpensesBreakdown.Width - 50; // Trừ lề 2 bên (25*2)
            pnlExpensesList.Height = pnlExpensesBreakdown.Height - 90;
            // Neo 4 góc để khi phóng to màn hình nó tự giãn ra
            pnlExpensesList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            // Tooltip
            _chartTooltip = new ToolTip();
            _chartTooltip.AutoPopDelay = 5000;
            _chartTooltip.InitialDelay = 100;
            _chartTooltip.ReshowDelay = 100;

            this.pnlBalanceChart.MouseMove += new MouseEventHandler(this.pnlBalanceChart_MouseMove);
            this.Load += UC_Dashboard_Load;
        }

        public void DisplayDashboardStats(DashboardStats stats)
        {
            if (this.InvokeRequired) { this.Invoke(new Action(() => DisplayDashboardStats(stats))); return; }

            lblTotalBalanceAmount.Text = FormatCurrency(stats.TotalBalance);
            UpdateComparisonLabel(lblTotalBalanceChange, stats.Comparison.BalanceChangePercent, stats.Comparison.IsFirstMonth);

            lblPeriodIncomeAmount.Text = FormatCurrency(stats.MonthlyIncome);
            UpdateComparisonLabel(lblPeriodIncomePercent, stats.Comparison.IncomeChangePercent, stats.Comparison.IsFirstMonth);

            lblPeriodExpensesAmount.Text = FormatCurrency(stats.MonthlyExpense);
            UpdateComparisonLabel(lblPeriodExpensesPercent, stats.Comparison.ExpenseChangePercent, stats.Comparison.IsFirstMonth, true);

            if (stats.CurrentBudget != null)
            {
                lblPeriodChangeTitle.Text = $"Ngân sách: {stats.CurrentBudget.BudgetName}";
                lblPeriodChangeAmount.Text = $"{FormatCurrency(stats.CurrentBudget.SpentAmount)} / {FormatCurrency(stats.CurrentBudget.BudgetAmount)}";
                lblPeriodChangeAmount.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
                lblPeriodChangePercent.Text = $"Đã dùng {stats.CurrentBudget.UsagePercent}%";

                if (stats.CurrentBudget.UsagePercent >= 100) lblPeriodChangePercent.ForeColor = Color.FromArgb(220, 38, 38);
                else if (stats.CurrentBudget.UsagePercent > 80) lblPeriodChangePercent.ForeColor = Color.FromArgb(245, 158, 11);
                else lblPeriodChangePercent.ForeColor = Color.FromArgb(107, 114, 128);
            }

            if (stats.BalanceTrends != null && stats.BalanceTrends.Any())
            {
                DrawBalanceChart(stats.BalanceTrends);
            }

            LoadExpensesData(stats.ExpenseBreakdown);
            lblSubtitle.Text = stats.Comparison.IsFirstMonth ? "Chào mừng bạn đến với Ekash!" : "Dữ liệu được cập nhật mới nhất";
        }

        // --- Helper Methods ---
        private string FormatCurrency(decimal amount) => string.Format(_cultureVI, "{0:N0}đ", amount);

        private string FormatShortCurrency(decimal amount)
        {
            string prefix = amount < 0 ? "-" : "";
            amount = Math.Abs(amount);
            if (amount >= 1000000000) return prefix + (amount / 1000000000).ToString("0.#") + "B";
            if (amount >= 1000000) return prefix + (amount / 1000000).ToString("0.#") + "Tr";
            if (amount >= 1000) return prefix + (amount / 1000).ToString("0.#") + "K";
            return prefix + amount.ToString("N0");
        }

        public void ShowLoading() { this.Cursor = Cursors.WaitCursor; }
        public void HideLoading() { this.Cursor = Cursors.Default; }
        public void DisplayError(string message) { MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        private void UpdateComparisonLabel(Label label, decimal percent, bool isFirstMonth, bool isExpense = false)
        {
            if (isFirstMonth) { label.Text = "Chào mừng bạn bắt đầu!"; label.ForeColor = Color.Gray; return; }
            string arrow = percent > 0 ? "↗" : (percent < 0 ? "↘" : "-");
            label.Text = $"{arrow} {Math.Abs(percent)}% so với tháng trước";
            if (isExpense) label.ForeColor = percent > 0 ? Color.Red : Color.Green;
            else label.ForeColor = percent >= 0 ? Color.Green : Color.Red;
        }

        // --- Chart Logic ---
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
                        string label = FormatShortCurrency(value);
                        SizeF size = g.MeasureString(label, fontAxis);
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
                PointF point = new PointF(x, y);
                pts.Add(point);
                _chartHitSpots.Add(new ChartHitSpot { ScreenLocation = point, Amount = trends[i].NetAmount, Label = trends[i].Label });
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

        private void pnlBalanceChart_MouseMove(object sender, MouseEventArgs e)
        {
            ChartHitSpot hitSpot = null;
            foreach (var spot in _chartHitSpots)
            {
                if (Math.Sqrt(Math.Pow(e.X - spot.ScreenLocation.X, 2) + Math.Pow(e.Y - spot.ScreenLocation.Y, 2)) <= 15)
                {
                    hitSpot = spot;
                    break;
                }
            }

            if (hitSpot != null && hitSpot != _lastHoveredSpot)
            {
                _chartTooltip.Show($"{hitSpot.Label}\n{FormatCurrency(hitSpot.Amount)}", pnlBalanceChart, (int)hitSpot.ScreenLocation.X, (int)hitSpot.ScreenLocation.Y - 40);
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

        // =================================================================================
        // --- LOGIC DANH SÁCH CHI TIÊU (FULL WIDTH, SÁT LỀ PHẢI) ---
        // =================================================================================
        private void LoadExpensesData(List<ExpenseCategoryBreakdown> expenses)
        {
            pnlExpensesList.Controls.Clear();
            if (expenses == null || !expenses.Any()) return;

            // Thanh màu: Chiều rộng = Chiều rộng panel - 25
            // Vì Panel đã được Anchor Left+Right nên nó sẽ tự rộng ra
            var bar = new Panel { Height = 10, Width = pnlExpensesList.Width - 25, Location = new Point(0, 0) };

            // Quan trọng: Neo thanh màu để nó cũng tự giãn khi form giãn
            bar.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            bar.Paint += (s, e) => {
                float x = 0;
                foreach (var exp in expenses)
                {
                    float w = (float)(exp.Percentage / 100.0) * bar.Width;
                    Color c = GetColorSafe(exp.ColorHex);
                    using (var b = new SolidBrush(c)) e.Graphics.FillRectangle(b, x, 0, w, 10);
                    x += w;
                }
            };
            pnlExpensesList.Controls.Add(bar);

            int y = 40;
            foreach (var exp in expenses)
            {
                var item = CreateExpenseItem(exp);
                item.Location = new Point(0, y);
                // Item cũng phải rộng bằng panel
                item.Width = pnlExpensesList.Width - 25;
                // Neo item để khi resize nó tự giãn text sang phải
                item.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

                pnlExpensesList.Controls.Add(item);
                y += 70;
            }
        }

        private Panel CreateExpenseItem(ExpenseCategoryBreakdown exp)
        {
            var p = new Panel { Height = 60 };
            var c = GetColorSafe(exp.ColorHex);

            // Ô màu (Cố định bên trái)
            p.Controls.Add(new Panel { Size = new Size(14, 14), Location = new Point(5, 23), BackColor = c });

            // Tên Category (Cố định bên trái)
            p.Controls.Add(new Label
            {
                Text = exp.CategoryName,
                Location = new Point(30, 18),
                AutoSize = true,
                Font = new Font("Segoe UI", 11F)
            });

            // --- LOGIC ĐẨY SỐ TIỀN & % SANG PHẢI ---

            // Tính toán vị trí dựa trên chiều rộng hiện tại của dòng (Item Width)
            int rightEdge = p.Width;

            // Phần trăm: Nằm sát lề phải (cách 60px)
            Label lblPercent = new Label
            {
                Text = $"{exp.Percentage}%",
                AutoSize = true,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 11F),
                Anchor = AnchorStyles.Top | AnchorStyles.Right // Tự động bám phải khi resize
            };
            // Đặt vị trí ban đầu
            lblPercent.Location = new Point(rightEdge - 60, 18);
            p.Controls.Add(lblPercent);

            // Số tiền: Nằm bên trái của Phần trăm (cách lề phải khoảng 200px)
            Label lblAmount = new Label
            {
                Text = FormatCurrency(exp.Amount),
                AutoSize = true,
                Font = new Font("Segoe UI", 12F, FontStyle.Bold),
                Anchor = AnchorStyles.Top | AnchorStyles.Right // Tự động bám phải
            };
            // Đặt vị trí ban đầu
            lblAmount.Location = new Point(rightEdge - 220, 17);
            p.Controls.Add(lblAmount);

            return p;
        }

        private Color GetColorSafe(string hex) { try { return ColorTranslator.FromHtml(hex); } catch { return Color.Gray; } }

        private void ApplyRoundedCorners(Panel p, int r)
        {
            p.Paint += (s, e) => {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (var path = new GraphicsPath())
                {
                    var rect = new Rectangle(0, 0, p.Width - 1, p.Height - 1);
                    int d = r * 2;
                    path.AddArc(rect.X, rect.Y, d, d, 180, 90);
                    path.AddArc(rect.Right - d, rect.Y, d, d, 270, 90);
                    path.AddArc(rect.Right - d, rect.Bottom - d, d, d, 0, 90);
                    path.AddArc(rect.X, rect.Bottom - d, d, d, 90, 90);
                    path.CloseFigure();
                    p.Region = new Region(path);
                    using (var pen = new Pen(Color.FromArgb(229, 231, 235))) e.Graphics.DrawPath(pen, path);
                }
            };
        }
    }
}