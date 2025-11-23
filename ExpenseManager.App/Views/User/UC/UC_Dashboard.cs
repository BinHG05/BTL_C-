using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;
using ExpenseManager.App.Models.ViewModels;
using ExpenseManager.App.Presenters;

namespace ExpenseManager.App.Views.Admin.UC
{
    /// <summary>
    /// UserControl Dashboard - Implement IDashboardView
    /// Hiển thị thống kê tổng quan về tài chính
    /// </summary>
    public partial class UC_Dashboard : UserControl, IDashboardView
    {
        private DashboardPresenter _presenter;
        private string _currentUserId;
        private List<BalanceTrendPoint> _currentBalanceTrends;

        public UC_Dashboard()
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(238, 242, 247);
            InitializeCustomComponents();
        }

        /// <summary>
        /// Thiết lập Presenter (gọi từ form cha)
        /// </summary>
        public void SetPresenter(DashboardPresenter presenter)
        {
            _presenter = presenter;
        }

        /// <summary>
        /// Thiết lập User ID (gọi từ form cha)
        /// </summary>
        public void SetUserId(string userId)
        {
            _currentUserId = userId;
        }

        /// <summary>
        /// Event khi UserControl được load
        /// </summary>
        private async void UC_Dashboard_Load(object sender, EventArgs e)
        {
            if (_presenter != null)
            {
                await _presenter.LoadDashboardDataAsync();
            }
        }

        /// <summary>
        /// Khởi tạo các component tùy chỉnh
        /// </summary>
        private void InitializeCustomComponents()
        {
            // Áp dụng góc bo tròn cho các card
            ApplyRoundedCorners(pnlTotalBalance, 12);
            ApplyRoundedCorners(pnlPeriodChange, 12);
            ApplyRoundedCorners(pnlPeriodExpenses, 12);
            ApplyRoundedCorners(pnlPeriodIncome, 12);
            ApplyRoundedCorners(pnlBalanceTrends, 12);
            ApplyRoundedCorners(pnlExpensesBreakdown, 12);

            // Đăng ký event Load
            this.Load += UC_Dashboard_Load;
        }

        #region IDashboardView Implementation

        public void ShowLoading()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => ShowLoading()));
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            // Có thể thêm loading spinner ở đây nếu muốn
        }

        public void HideLoading()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => HideLoading()));
                return;
            }

            this.Cursor = Cursors.Default;
        }

        public void DisplayDashboardStats(DashboardStats stats)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DisplayDashboardStats(stats)));
                return;
            }

            // 1. Hiển thị tổng số dư
            lblTotalBalanceAmount.Text = FormatCurrency(stats.TotalBalance);
            UpdateComparisonLabel(lblTotalBalanceChange, stats.Comparison.BalanceChangePercent,
                stats.Comparison.BalanceChangeAmount, stats.Comparison.IsFirstMonth);

            // 2. Hiển thị thu nhập tháng này
            lblPeriodIncomeAmount.Text = FormatCurrency(stats.MonthlyIncome);
            UpdateComparisonLabel(lblPeriodIncomePercent, stats.Comparison.IncomeChangePercent,
                stats.Comparison.IncomeChangeAmount, stats.Comparison.IsFirstMonth);

            // 3. Hiển thị chi tiêu tháng này
            lblPeriodExpensesAmount.Text = FormatCurrency(stats.MonthlyExpense);
            UpdateComparisonLabel(lblPeriodExpensesPercent, stats.Comparison.ExpenseChangePercent,
                stats.Comparison.ExpenseChangeAmount, stats.Comparison.IsFirstMonth, true);

            // 4. Hiển thị ngân sách
            if (stats.CurrentBudget != null)
            {
                lblPeriodChangeTitle.Text = stats.CurrentBudget.BudgetName;
                lblPeriodChangeAmount.Text = FormatCurrency(stats.CurrentBudget.BudgetAmount);
                lblPeriodChangePercent.Text = $"Đã dùng {stats.CurrentBudget.UsagePercent:F1}% " +
                    $"(Còn {FormatCurrency(stats.CurrentBudget.RemainingAmount)})";

                // Đổi màu cảnh báo nếu dùng > 80%
                lblPeriodChangePercent.ForeColor = stats.CurrentBudget.UsagePercent > 80
                    ? Color.FromArgb(239, 68, 68)
                    : Color.FromArgb(107, 114, 128);
            }

            // 5. Vẽ biểu đồ Balance Trends
            if (stats.BalanceTrends != null && stats.BalanceTrends.Any())
            {
                DrawBalanceChart(stats.BalanceTrends);

                var latestTrend = stats.BalanceTrends.Last();
                lblBalanceTrendsAmount.Text = FormatCurrency(latestTrend.NetAmount);

                // Tính % change cho balance trends
                if (stats.BalanceTrends.Count > 1)
                {
                    var firstWeek = stats.BalanceTrends.First().NetAmount;
                    var lastWeek = latestTrend.NetAmount;
                    var change = lastWeek - firstWeek;
                    var changePercent = firstWeek != 0 ? (change / firstWeek * 100) : 0;

                    var arrow = changePercent >= 0 ? "↗" : "↘";
                    lblBalanceTrendsChange.Text = $"{arrow} {Math.Abs(changePercent):F2}%";
                    lblBalanceTrendsChange.ForeColor = changePercent >= 0
                        ? Color.FromArgb(34, 197, 94)
                        : Color.FromArgb(239, 68, 68);
                }
            }

            // 6. Hiển thị phân tích chi tiêu
            LoadExpensesData(stats.ExpenseBreakdown);

            // 7. Cập nhật tiêu đề
            lblSubtitle.Text = stats.Comparison.IsFirstMonth
                ? "Chào mừng bạn đến với Ekash Finance Management!"
                : $"Dữ liệu cập nhật: {DateTime.Now:dd/MM/yyyy HH:mm}";
        }

        public void DisplayError(string message)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => DisplayError(message)));
                return;
            }

            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public string GetCurrentUserId()
        {
            return _currentUserId;
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Format số tiền sang dạng VNĐ
        /// </summary>
        private string FormatCurrency(decimal amount)
        {
            return amount.ToString("N0") + " ₫";
        }

        /// <summary>
        /// Cập nhật label so sánh với tháng trước
        /// </summary>
        private void UpdateComparisonLabel(Label label, decimal changePercent,
            decimal changeAmount, bool isFirstMonth, bool isExpense = false)
        {
            if (isFirstMonth)
            {
                label.Text = "Chào mừng bạn!";
                label.ForeColor = Color.FromArgb(107, 114, 128);
                return;
            }

            var arrow = changePercent >= 0 ? "↗" : "↘";

            // Với chi tiêu: tăng = xấu (đỏ), giảm = tốt (xanh)
            // Với thu nhập và số dư: tăng = tốt (xanh), giảm = xấu (đỏ)
            Color color;
            if (isExpense)
            {
                color = changePercent >= 0
                    ? Color.FromArgb(239, 68, 68)  // Tăng chi tiêu = đỏ
                    : Color.FromArgb(34, 197, 94);  // Giảm chi tiêu = xanh
            }
            else
            {
                color = changePercent >= 0
                    ? Color.FromArgb(34, 197, 94)   // Tăng thu/số dư = xanh
                    : Color.FromArgb(239, 68, 68);  // Giảm thu/số dư = đỏ
            }

            label.Text = $"{arrow} {Math.Abs(changePercent):F2}% so với tháng trước ({FormatCurrency(Math.Abs(changeAmount))})";
            label.ForeColor = color;
        }

        #endregion

        #region UI Drawing Methods

        /// <summary>
        /// Áp dụng góc bo tròn cho panel
        /// </summary>
        private void ApplyRoundedCorners(Panel panel, int radius)
        {
            panel.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                GraphicsPath path = GetRoundedRectangle(rect, radius);

                panel.Region = new Region(path);

                using (Pen pen = new Pen(Color.FromArgb(229, 231, 235), 1))
                {
                    g.DrawPath(pen, path);
                }
            };
        }

        /// <summary>
        /// Tạo GraphicsPath cho hình chữ nhật bo góc
        /// </summary>
        private GraphicsPath GetRoundedRectangle(Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            path.AddArc(rect.X, rect.Y, diameter, diameter, 180, 90);
            path.AddArc(rect.Right - diameter, rect.Y, diameter, diameter, 270, 90);
            path.AddArc(rect.Right - diameter, rect.Bottom - diameter, diameter, diameter, 0, 90);
            path.AddArc(rect.X, rect.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Vẽ biểu đồ Balance Trends
        /// </summary>
        private void DrawBalanceChart(List<BalanceTrendPoint> trendPoints)
        {
            pnlBalanceChart.Controls.Clear();

            // Xóa tất cả event handlers cũ
            pnlBalanceChart.Paint -= PnlBalanceChart_Paint;

            // Lưu data vào biến instance
            _currentBalanceTrends = trendPoints;

            // Đăng ký event handler mới
            pnlBalanceChart.Paint += PnlBalanceChart_Paint;
            pnlBalanceChart.Invalidate();
        }

        //private List<BalanceTrendPoint> _currentBalanceTrends;

        /// <summary>
        /// Event vẽ biểu đồ
        /// </summary>
        private void PnlBalanceChart_Paint(object sender, PaintEventArgs e)
        {
            var trends = _currentBalanceTrends;
            if (trends == null || !trends.Any()) return;

            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int width = pnlBalanceChart.Width;
            int height = pnlBalanceChart.Height;
            int margin = 20;

            // Tính toán các điểm
            List<PointF> points = new List<PointF>();
            float xStep = trends.Count > 1
                ? (float)(width - margin * 2) / (trends.Count - 1)
                : (width - margin * 2);

            var maxValue = trends.Max(t => t.NetAmount);
            var minValue = trends.Min(t => t.NetAmount);
            var range = maxValue - minValue;
            if (range == 0) range = 1;

            for (int i = 0; i < trends.Count; i++)
            {
                float x = margin + i * xStep;
                float y = height - margin - (float)((trends[i].NetAmount - minValue) / range) * (height - margin * 2);
                points.Add(new PointF(x, y));
            }

            // Vẽ gradient area
            GraphicsPath areaPath = new GraphicsPath();
            areaPath.AddLine(margin, height - margin, points[0].X, points[0].Y);

            for (int i = 0; i < points.Count - 1; i++)
            {
                areaPath.AddLine(points[i], points[i + 1]);
            }

            areaPath.AddLine(points[points.Count - 1].X, points[points.Count - 1].Y,
                            width - margin, height - margin);
            areaPath.AddLine(width - margin, height - margin, margin, height - margin);

            // Fill gradient
            using (LinearGradientBrush brush = new LinearGradientBrush(
                new Point(0, 0),
                new Point(0, height),
                Color.FromArgb(120, 99, 122, 255),
                Color.FromArgb(20, 99, 122, 255)))
            {
                g.FillPath(brush, areaPath);
            }

            // Vẽ đường line
            using (Pen pen = new Pen(Color.FromArgb(99, 102, 241), 3))
            {
                for (int i = 0; i < points.Count - 1; i++)
                {
                    g.DrawLine(pen, points[i], points[i + 1]);
                }
            }

            // Vẽ các điểm
            foreach (var point in points)
            {
                using (SolidBrush brush = new SolidBrush(Color.FromArgb(99, 102, 241)))
                {
                    g.FillEllipse(brush, point.X - 4, point.Y - 4, 8, 8);
                }
            }
        }

        /// <summary>
        /// Load dữ liệu chi tiêu theo danh mục
        /// </summary>
        private void LoadExpensesData(List<ExpenseCategoryBreakdown> expenses)
        {
            pnlExpensesList.Controls.Clear();

            if (expenses == null || !expenses.Any())
            {
                Label noData = new Label
                {
                    Text = "Chưa có dữ liệu chi tiêu trong tháng này",
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = Color.FromArgb(107, 114, 128),
                    AutoSize = true,
                    Location = new Point(20, 20)
                };
                pnlExpensesList.Controls.Add(noData);
                return;
            }

            // Tạo thanh progress bar đa màu ở đầu
            Panel progressBar = CreateProgressBar(expenses);
            progressBar.Location = new Point(0, 0);
            progressBar.Width = pnlExpensesList.Width - 5;
            progressBar.Height = 8;
            pnlExpensesList.Controls.Add(progressBar);

            // Thêm các item chi tiêu
            int yPos = 30;
            foreach (var expense in expenses)
            {
                Panel expenseItem = CreateExpenseItem(expense);
                expenseItem.Location = new Point(0, yPos);
                expenseItem.Width = pnlExpensesList.Width - 20;
                pnlExpensesList.Controls.Add(expenseItem);
                yPos += 60;
            }
        }

        /// <summary>
        /// Tạo thanh progress bar đa màu
        /// </summary>
        private Panel CreateProgressBar(List<ExpenseCategoryBreakdown> expenses)
        {
            Panel progressBar = new Panel { Height = 8 };

            progressBar.Paint += (s, e) =>
            {
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                float xPos = 0;
                float totalWidth = progressBar.Width;

                foreach (var expense in expenses)
                {
                    float segmentWidth = (float)(expense.Percentage / 100.0) * totalWidth;

                    // Xử lý trường hợp HexCode null hoặc không hợp lệ
                    Color color;
                    try
                    {
                        color = ColorTranslator.FromHtml(expense.ColorHex);
                    }
                    catch
                    {
                        color = Color.FromArgb(99, 102, 241); // Màu mặc định
                    }

                    using (SolidBrush brush = new SolidBrush(color))
                    {
                        g.FillRectangle(brush, xPos, 0, segmentWidth, progressBar.Height);
                    }

                    xPos += segmentWidth;
                }
            };

            return progressBar;
        }

        /// <summary>
        /// Tạo item hiển thị chi tiêu theo danh mục
        /// </summary>
        private Panel CreateExpenseItem(ExpenseCategoryBreakdown expense)
        {
            Panel item = new Panel
            {
                Height = 50,
                BackColor = Color.Transparent
            };

            // Xử lý màu sắc an toàn
            Color color;
            try
            {
                color = ColorTranslator.FromHtml(expense.ColorHex);
            }
            catch
            {
                color = Color.FromArgb(99, 102, 241); // Màu mặc định
            }

            // Chấm tròn màu
            Panel colorBox = new Panel
            {
                Size = new Size(12, 12),
                BackColor = color,
                Location = new Point(0, 15)
            };
            colorBox.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddEllipse(0, 0, colorBox.Width - 1, colorBox.Height - 1);
                    colorBox.Region = new Region(path);
                }
            };

            // Tên danh mục
            Label lblName = new Label
            {
                Text = expense.CategoryName,
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(31, 41, 55),
                AutoSize = true,
                Location = new Point(25, 15)
            };

            // Số tiền
            Label lblAmount = new Label
            {
                Text = FormatCurrency(expense.Amount),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 41, 55),
                AutoSize = true,
                Location = new Point(250, 15)
            };

            // Phần trăm
            Label lblPercentage = new Label
            {
                Text = $"{expense.Percentage:F1}%",
                Font = new Font("Segoe UI", 10F),
                ForeColor = Color.FromArgb(107, 114, 128),
                AutoSize = true,
                Location = new Point(380, 15)
            };

            item.Controls.Add(colorBox);
            item.Controls.Add(lblName);
            item.Controls.Add(lblAmount);
            item.Controls.Add(lblPercentage);

            return item;
        }

        #endregion
    }
}