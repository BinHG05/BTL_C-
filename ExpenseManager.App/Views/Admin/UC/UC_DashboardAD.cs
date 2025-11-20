using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ExpenseManager.App.Session;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_DashboardAD : UserControl, IDashboardADView
    {
        // Dữ liệu cho biểu đồ
        private List<ChartDataPoint> chartData;
        private string currentFilter = "Theo tháng";

        // Presenter
        private DashboardADPresenter _presenter;

        // Loading indicator
        private Panel loadingPanel;

        public UC_DashboardAD()
        {
            InitializeComponent();
            lblDateTime.Text = "📅 " + DateTime.Now.ToString("dddd, dd MMMM, yyyy", new CultureInfo("vi-VN"));
            SetupLoadingPanel();
            SetupCardShadows();
            DisplayWelcomeMessage();
            // Set default filter
            cmbFilter.SelectedIndex = 1; // Theo tháng
            cmbFilter.SelectedIndexChanged += CmbFilter_SelectedIndexChanged;
        }
        private void DisplayWelcomeMessage()
        {
            string userName = "Admin"; 

            // 1. Kiểm tra Session để lấy thông tin người dùng
            var currentUser = CurrentUserSession.CurrentUser;

            if (currentUser != null)
            {
                // Giả định đối tượng CurrentUser có thuộc tính FullName
                // Nếu bạn lưu tên ở thuộc tính khác 
                if (!string.IsNullOrEmpty(currentUser.FullName))
                {
                    userName = currentUser.FullName;
                }
                else if (!string.IsNullOrEmpty(currentUser.FullName))
                {
                    userName = currentUser.FullName;
                }
            }

            // 2. Gán giá trị vào Label
            // Cú pháp cũ trong Designer là: lblWelcome.Text = "Welcome back, Âu Dương Tấn AD!";
            lblWelcome.Text = $"Welcome back, {userName} !";
        }
        /// <summary>
        /// Khởi tạo Presenter với Dependency Injection
        /// Phương thức này nên được gọi từ bên ngoài sau khi tạo UC
        /// </summary>
        public void InitializePresenter(DbContext dbContext)
        {
            // Setup Dependency Injection
            var repository = new DashboardADRepository(dbContext);
            var service = new DashboardADService(repository);
            _presenter = new DashboardADPresenter(this, service);

            // Load dữ liệu ban đầu
            _ = LoadDashboardDataAsync();
        }

        /// <summary>
        /// Load toàn bộ dữ liệu Dashboard
        /// </summary>
        private async Task LoadDashboardDataAsync()
        {
            if (_presenter != null)
            {
                await _presenter.LoadDashboardAsync(currentFilter);
            }
        }

        #region IDashboardADView Implementation

        /// <summary>
        /// Hiển thị dữ liệu KPI lên các thẻ
        /// </summary>
        public void DisplayKPIStats(KPIStatsDTO stats)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayKPIStats(stats)));
                return;
            }

            // ===== USERS CARD =====
            lblUsersValue.Text = stats.TotalUsers.ToString();

            // Hiển thị số users mới và growth rate
            string usersChangeText = $"+{stats.NewUsersThisMonth} new users this month";
            if (stats.UserGrowthRate != 0)
            {
                usersChangeText += $" ({(stats.UserGrowthRate > 0 ? "+" : "")}{stats.UserGrowthRate}%)";
            }
            lblUsersChange.Text = usersChangeText;
            lblUsersChange.ForeColor = stats.UserGrowthRate >= 0
                ? Color.FromArgb(46, 204, 113)  // Xanh lá nếu tăng
                : Color.FromArgb(231, 76, 60);   // Đỏ nếu giảm

            // ===== TRANSACTIONS CARD =====
            lblTransValue.Text = stats.TotalTrans.ToString();

            string transChangeText = $"+{stats.NewTransThisMonth} new transactions this month";
            if (stats.TransGrowthRate != 0)
            {
                transChangeText += $" ({(stats.TransGrowthRate > 0 ? "+" : "")}{stats.TransGrowthRate}%)";
            }
            lblTransChange.Text = transChangeText;
            lblTransChange.ForeColor = stats.TransGrowthRate >= 0
                ? Color.FromArgb(46, 204, 113)
                : Color.FromArgb(231, 76, 60);

            // ===== TICKETS CARD =====
            lblTicketsValue.Text = stats.TotalTickets.ToString();

            // Pending (Sử dụng lblTicketsChange)
            lblTicketsChange.Text = $"{stats.PendingTickets} pending";
            lblTicketsChange.ForeColor = Color.FromArgb(231, 76, 60); // Đỏ cho Pending

            // Open
            lblTicketsOpen.Text = $"{stats.OpenTickets} open";
            lblTicketsOpen.ForeColor = Color.FromArgb(230, 126, 34); // Cam cho Open

            // Resolved
            lblTicketsResolved.Text = $"{stats.ResolvedTickets} resolved";
            lblTicketsResolved.ForeColor = Color.FromArgb(46, 204, 113); // Xanh lá cho Resolved

            // Cập nhật trạng thái hiển thị của các Label
            lblTicketsChange.Visible = stats.PendingTickets > 0;
            lblTicketsOpen.Visible = stats.OpenTickets > 0;
            lblTicketsResolved.Visible = stats.ResolvedTickets > 0;

            // Cập nhật Label chính (Tickets)
            lblTicketsLabel.Text = (stats.TotalTickets > 0) ? "Tickets" : "No active tickets";
        }

        /// <summary>
        /// Hiển thị dữ liệu biểu đồ tăng trưởng User
        /// </summary>
        public void DisplayUserGrowthChart(List<ChartDataPointDTO> data)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayUserGrowthChart(data)));
                return;
            }

            // Chuyển đổi từ DTO sang model nội bộ
            chartData = data.Select(d => new ChartDataPoint
            {
                Label = d.Label,
                Value = d.Value
            }).ToList();

            // Cập nhật tiêu đề biểu đồ
            UpdateChartTitle();

            // Vẽ lại biểu đồ
            chartContainer.Invalidate();
        }

        /// <summary>
        /// Hiển thị thông báo lỗi
        /// </summary>
        public void ShowError(string message)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowError(message)));
                return;
            }

            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Hiển thị/ẩn loading indicator
        /// </summary>
        public void ShowLoading(bool isLoading)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowLoading(isLoading)));
                return;
            }

            loadingPanel.Visible = isLoading;
            if (isLoading)
            {
                loadingPanel.BringToFront();
            }
        }

        #endregion

        #region Event Handlers

        private async void CmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFilter = cmbFilter.SelectedItem.ToString();
            UpdateChartTitle();

            // Load lại dữ liệu biểu đồ qua Presenter
            if (_presenter != null)
            {
                await _presenter.LoadUserGrowthChartAsync(currentFilter);
            }
        }

        #endregion

        #region Helper Methods

        private void UpdateChartTitle()
        {
            switch (currentFilter)
            {
                case "Theo ngày":
                    lblChartTitle.Text = "Biểu đồ tăng trưởng User theo Ngày";
                    break;
                case "Theo tháng":
                    lblChartTitle.Text = "Biểu đồ tăng trưởng User theo Tháng";
                    break;
                case "Theo năm":
                    lblChartTitle.Text = "Biểu đồ tăng trưởng User theo Năm";
                    break;
            }
        }

        private void SetupLoadingPanel()
        {
            loadingPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(200, 255, 255, 255),
                Visible = false
            };

            var loadingLabel = new Label
            {
                Text = "Đang tải dữ liệu...",
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                ForeColor = Color.FromArgb(52, 73, 94),
                AutoSize = true
            };

            loadingPanel.Controls.Add(loadingLabel);
            loadingPanel.Resize += (sender, e) =>
            {
                loadingLabel.Location = new Point(
                    (loadingPanel.Width - loadingLabel.Width) / 2,
                    (loadingPanel.Height - loadingLabel.Height) / 2
                );
            };
            loadingPanel.Resize += (sender, e) =>
            {
                loadingLabel.Location = new Point(
                    (loadingPanel.Width - loadingLabel.Width) / 2,
                    (loadingPanel.Height - loadingLabel.Height) / 2
                );
            };

            mainPanel.Controls.Add(loadingPanel);
            loadingPanel.BringToFront();
        }

        private void SetupCardShadows()
        {
            // Thêm shadow effect cho các cards
            ApplyCardStyle(cardUsers);
            ApplyCardStyle(cardTrans);
            ApplyCardStyle(cardTickets);
            ApplyCardStyle(chartPanel);
        }

        private void ApplyCardStyle(Panel card)
        {
            // Bo góc
            card.Paint += (s, e) =>
            {
                var rect = card.ClientRectangle;
                using (var path = GetRoundedRectangle(rect, 12))
                {
                    card.Region = new Region(path);
                }
            };
        }

        private GraphicsPath GetRoundedRectangle(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // Top left arc
            path.AddArc(arc, 180, 90);

            // Top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // Bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // Bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }

        #endregion

        #region Icon Paint Methods

        // Vẽ icon Users với gradient tím/xanh
        private void IconUsers_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient từ tím sang xanh
            using (var brush = new LinearGradientBrush(
                iconUsers.ClientRectangle,
                Color.FromArgb(155, 89, 182),  // Tím
                Color.FromArgb(52, 152, 219),   // Xanh
                LinearGradientMode.ForwardDiagonal))
            {
                // Bo góc
                using (var path = GetRoundedRectangle(iconUsers.ClientRectangle, 10))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Vẽ icon người dùng đơn giản
            using (var pen = new Pen(Color.White, 2f))
            {
                // Vẽ đầu (circle)
                e.Graphics.DrawEllipse(pen, 19, 10, 12, 12);

                // Vẽ thân (arc)
                e.Graphics.DrawArc(pen, 13, 22, 24, 20, 0, 180);
            }
        }

        // Vẽ icon Trans với gradient hồng/đỏ
        private void IconTrans_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient từ hồng sang đỏ
            using (var brush = new LinearGradientBrush(
                iconTrans.ClientRectangle,
                Color.FromArgb(231, 76, 60),    // Đỏ
                Color.FromArgb(255, 118, 117),  // Hồng nhạt
                LinearGradientMode.ForwardDiagonal))
            {
                using (var path = GetRoundedRectangle(iconTrans.ClientRectangle, 10))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Vẽ icon mũi tên trao đổi
            using (var pen = new Pen(Color.White, 2f))
            {
                // Mũi tên lên
                e.Graphics.DrawLine(pen, 25, 20, 17, 13);
                e.Graphics.DrawLine(pen, 25, 20, 25, 28);
                e.Graphics.DrawLine(pen, 25, 20, 33, 20);

                // Mũi tên xuống
                e.Graphics.DrawLine(pen, 25, 28, 17, 37);
                e.Graphics.DrawLine(pen, 25, 28, 33, 37);
            }
        }

        // Vẽ icon Tickets với gradient xanh lam/cyan
        private void IconTickets_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Gradient từ xanh lam sang cyan
            using (var brush = new LinearGradientBrush(
                iconTickets.ClientRectangle,
                Color.FromArgb(52, 152, 219),   // Xanh lam
                Color.FromArgb(26, 188, 156),   // Cyan
                LinearGradientMode.ForwardDiagonal))
            {
                using (var path = GetRoundedRectangle(iconTickets.ClientRectangle, 10))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            // Vẽ icon ticket
            using (var pen = new Pen(Color.White, 2f))
            {
                // Hình chữ nhật vé
                e.Graphics.DrawRectangle(pen, 15, 15, 20, 20);

                // Các đường gạch ngang
                e.Graphics.DrawLine(pen, 18, 21, 32, 21);
                e.Graphics.DrawLine(pen, 18, 25, 32, 25);
                e.Graphics.DrawLine(pen, 18, 29, 32, 29);
            }
        }

        #endregion

        #region Chart Drawing

        // Vẽ biểu đồ line chart
        private void ChartContainer_Paint(object sender, PaintEventArgs e)
        {
            if (chartData == null || chartData.Count == 0)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            // Margins
            int leftMargin = 60;
            int rightMargin = 40;
            int topMargin = 40;
            int bottomMargin = 50;

            int chartWidth = chartContainer.Width - leftMargin - rightMargin;
            int chartHeight = chartContainer.Height - topMargin - bottomMargin;

            // Tìm giá trị max
            float maxValue = chartData.Max(d => d.Value);
            float minValue = chartData.Min(d => d.Value);
            float valueRange = maxValue - minValue;

            // Tránh chia cho 0
            if (valueRange == 0) valueRange = 1;

            // Vẽ grid lines (lưới nền)
            using (var gridPen = new Pen(Color.FromArgb(224, 224, 224), 1))
            {
                // Horizontal grid lines
                for (int i = 0; i <= 5; i++)
                {
                    float y = topMargin + (chartHeight * i / 5);
                    e.Graphics.DrawLine(gridPen, leftMargin, y, leftMargin + chartWidth, y);

                    // Y-axis labels
                    float value = maxValue - (valueRange * i / 5);
                    using (var font = new Font("Segoe UI", 8))
                    using (var brush = new SolidBrush(Color.FromArgb(149, 165, 166)))
                    {
                        string label = value.ToString("0");
                        var size = e.Graphics.MeasureString(label, font);
                        e.Graphics.DrawString(label, font, brush,
                            leftMargin - size.Width - 8, y - size.Height / 2);
                    }
                }
            }

            // Tạo points cho line
            PointF[] points = new PointF[chartData.Count];
            for (int i = 0; i < chartData.Count; i++)
            {
                float x = chartData.Count > 1
                    ? leftMargin + (chartWidth * i / (chartData.Count - 1))
                    : leftMargin + chartWidth / 2;

                float normalizedValue = (chartData[i].Value - minValue) / valueRange;
                float y = topMargin + chartHeight - (normalizedValue * chartHeight);
                points[i] = new PointF(x, y);
            }

            // Vẽ area (vùng dưới line với gradient)
            if (points.Length >= 2)
            {
                GraphicsPath areaPath = new GraphicsPath();
                areaPath.AddLine(leftMargin, topMargin + chartHeight, points[0].X, points[0].Y);
                areaPath.AddLines(points);
                areaPath.AddLine(points[points.Length - 1].X, points[points.Length - 1].Y,
                    leftMargin + chartWidth, topMargin + chartHeight);
                areaPath.CloseFigure();

                using (var areaBrush = new LinearGradientBrush(
                    new Rectangle(leftMargin, topMargin, chartWidth, chartHeight),
                    Color.FromArgb(80, 52, 152, 219),   // Xanh nhạt
                    Color.FromArgb(10, 52, 152, 219),   // Rất nhạt
                    LinearGradientMode.Vertical))
                {
                    e.Graphics.FillPath(areaBrush, areaPath);
                }
            }

            // Vẽ line
            if (points.Length >= 2)
            {
                using (var linePen = new Pen(Color.FromArgb(52, 152, 219), 3))
                {
                    e.Graphics.DrawLines(linePen, points);
                }
            }

            // Vẽ points
            foreach (var point in points)
            {
                using (var pointBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
                {
                    e.Graphics.FillEllipse(pointBrush, point.X - 4, point.Y - 4, 8, 8);
                }
                using (var whiteBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(whiteBrush, point.X - 2, point.Y - 2, 4, 4);
                }
            }

            // Vẽ X-axis labels
            using (var font = new Font("Segoe UI", 8))
            using (var brush = new SolidBrush(Color.FromArgb(149, 165, 166)))
            {
                for (int i = 0; i < chartData.Count; i++)
                {
                    // Chỉ hiển thị một số labels để tránh chồng chéo
                    if (chartData.Count > 12 && i % 3 != 0 && i != chartData.Count - 1)
                        continue;

                    float x = points[i].X;
                    var size = e.Graphics.MeasureString(chartData[i].Label, font);
                    e.Graphics.DrawString(chartData[i].Label, font, brush,
                        x - size.Width / 2, topMargin + chartHeight + 10);
                }
            }

            // Vẽ legend
            using (var legendFont = new Font("Segoe UI", 9))
            using (var legendBrush = new SolidBrush(Color.FromArgb(52, 73, 94)))
            {
                int legendX = leftMargin;
                int legendY = topMargin - 25;

                // Box màu
                using (var boxBrush = new SolidBrush(Color.FromArgb(52, 152, 219)))
                {
                    e.Graphics.FillRectangle(boxBrush, legendX, legendY, 15, 15);
                }

                e.Graphics.DrawString("Số lượng Users", legendFont, legendBrush,
                    legendX + 20, legendY);
            }
        }

        #endregion

        // Class để lưu dữ liệu biểu đồ
        private class ChartDataPoint
        {
            public string Label { get; set; }
            public float Value { get; set; }
        }
    }
}