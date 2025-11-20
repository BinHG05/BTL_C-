using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Diagnostics;
using System.Windows.Forms.DataVisualization.Charting;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Budget : UserControl, IBudgetView
    {
        private BudgetPresenter _presenter;
        private Chart _expenseChart;

        public string CurrentUserId
        {
            get => CurrentUserSession.CurrentUser?.UserId;
            set { }
        }

        public UC_Budget()
        {
            InitializeComponent();
            SetupEventHandlers();
            InitializeChart();

            // ✅ Khởi tạo presenter ngay trong constructor
            _presenter = new BudgetPresenter(this, Program.ServiceProvider);
        }

        private void SetupEventHandlers()
        {
            Debug.WriteLine("[UC_Budget] SetupEventHandlers");

            this.Load += UC_Budget_Load;

            if (btnAddNewBudget != null)
            {
                btnAddNewBudget.Click -= BtnAddNewBudget_Click;
                btnAddNewBudget.Click += BtnAddNewBudget_Click;
            }

            if (btnAddBudgetSidebar != null)
            {
                btnAddBudgetSidebar.Click -= BtnAddNewBudget_Click;
                btnAddBudgetSidebar.Click += BtnAddNewBudget_Click;
            }

            if (btnDelete != null) btnDelete.Click += BtnDelete_Click;
            if (btnEdit != null) btnEdit.Click += BtnEdit_Click;
            if (cmbChartType != null) cmbChartType.SelectedIndexChanged += CmbChartType_SelectedIndexChanged;
            if (dtpChartFrom != null) dtpChartFrom.ValueChanged += DateRange_Changed;
            if (dtpChartTo != null) dtpChartTo.ValueChanged += DateRange_Changed;
        }

        private void InitializeChart()
        {
            _expenseChart = new Chart
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            var chartArea = new ChartArea("MainArea")
            {
                BackColor = Color.White,
                AxisX =
                {
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot },
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(100, 116, 139) }
                },
                AxisY =
                {
                    MajorGrid = { LineColor = Color.LightGray, LineDashStyle = ChartDashStyle.Dot },
                    LabelStyle = { Font = new Font("Segoe UI", 9), ForeColor = Color.FromArgb(100, 116, 139), Format = "#,##0đ" }
                }
            };

            _expenseChart.ChartAreas.Add(chartArea);

            var series = new Series("Expense")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(99, 102, 241),
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8),
                LabelFormat = "#,##0đ"
            };

            _expenseChart.Series.Add(series);

            var legend = new Legend("MainLegend")
            {
                Docking = Docking.Top,
                Alignment = StringAlignment.Center,
                Font = new Font("Segoe UI", 9)
            };
            _expenseChart.Legends.Add(legend);

            if (pnlChartArea != null)
            {
                pnlChartArea.Controls.Clear();
                pnlChartArea.Controls.Add(_expenseChart);
            }
        }

        private void UC_Budget_Load(object sender, EventArgs e)
        {
            Debug.WriteLine("[UC_Budget] UC_Budget_Load");

            if (CurrentUserSession.CurrentUser == null)
            {
                Debug.WriteLine("[UC_Budget] WARNING: CurrentUser is NULL");
                MessageBox.Show("Bạn chưa đăng nhập!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // ✅ Presenter đã được khởi tạo trong constructor, không cần lấy từ DI nữa
            ViewLoaded?.Invoke(this, EventArgs.Empty);

            if (cmbChartType != null && cmbChartType.Items.Count > 0)
                cmbChartType.SelectedIndex = 0;
        }

        private async void BtnAddNewBudget_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UC_Budget] BtnAddNewBudget_Click");

            if (_presenter == null)
            {
                MessageBox.Show("Lỗi: Presenter chưa được khởi tạo!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var categories = await _presenter.GetCategoriesForNewBudgetAsync();

                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có danh mục chi tiêu nào!\n\nVui lòng tạo danh mục trước.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                using (var dialog = new BudgetCreateDialog(categories))
                {
                    if (dialog.ShowDialog() == DialogResult.OK && dialog.CreatedBudgetDto != null)
                    {
                        await _presenter.CreateBudgetAsync(dialog.CreatedBudgetDto);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[UC_Budget] BtnAddNewBudget_Click ERROR: {ex.Message}\n{ex.StackTrace}");
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UC_Budget] BtnDelete_Click");
            DeleteBudgetClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("[UC_Budget] BtnEdit_Click");
            EditBudgetClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChartType.SelectedItem != null)
            {
                ChartTypeChanged?.Invoke(this, cmbChartType.SelectedItem.ToString());
            }
        }

        private void DateRange_Changed(object sender, EventArgs e)
        {
            if (dtpChartFrom != null && dtpChartTo != null)
            {
                ChartDateRangeChanged?.Invoke(this, new BudgetViewDateRangeEventArgs
                {
                    StartDate = dtpChartFrom.Value.Date,
                    EndDate = dtpChartTo.Value.Date
                });
            }
        }

        // ============== IBudgetView Implementation ==============

        public event EventHandler ViewLoaded;
        public event EventHandler<int> BudgetSelected;
        public event EventHandler AddBudgetClicked;
        public event EventHandler EditBudgetClicked;
        public event EventHandler DeleteBudgetClicked;
        public event EventHandler<BudgetViewDateRangeEventArgs> ChartDateRangeChanged;
        public event EventHandler<string> ChartTypeChanged;

        public void DisplayBudgetList(IEnumerable<BudgetSummaryDto> budgets)
        {
            try
            {
                flpBudgetList.SuspendLayout();
                flpBudgetList.Controls.Clear();
                flpBudgetList.Controls.Add(btnAddBudgetSidebar);

                if (budgets == null || !budgets.Any())
                {
                    Debug.WriteLine("[UC_Budget] No budgets to display");
                    return;
                }

                foreach (var budget in budgets)
                {
                    Panel pnlItem = new Panel
                    {
                        Size = new Size(330, 100),
                        BackColor = Color.White,
                        Cursor = Cursors.Hand,
                        Margin = new Padding(3, 5, 3, 5),
                        Tag = budget.BudgetId
                    };

                    Label lblIcon = new Label
                    {
                        Text = _presenter?.GetIconEmoji(budget.IconId) ?? "💰",
                        Font = new Font("Segoe UI", 24),
                        Location = new Point(20, 25),
                        AutoSize = true
                    };

                    Label lblName = new Label
                    {
                        Text = budget.CategoryName,
                        Font = new Font("Segoe UI", 13, FontStyle.Bold),
                        ForeColor = Color.FromArgb(30, 41, 59),
                        Location = new Point(80, 25),
                        AutoSize = true,
                        MaximumSize = new Size(230, 0)
                    };

                    Label lblAmount = new Label
                    {
                        Text = budget.FormattedBudget,
                        Font = new Font("Segoe UI", 10),
                        ForeColor = Color.Gray,
                        Location = new Point(80, 55),
                        AutoSize = true
                    };

                    pnlItem.Controls.AddRange(new Control[] { lblIcon, lblName, lblAmount });

                    EventHandler clickEvent = (s, e) =>
                    {
                        foreach (Control ctrl in flpBudgetList.Controls)
                        {
                            if (ctrl is Panel p && ctrl != btnAddBudgetSidebar)
                            {
                                p.BackColor = Color.White;
                            }
                        }
                        pnlItem.BackColor = Color.FromArgb(240, 240, 255);

                        BudgetSelected?.Invoke(this, budget.BudgetId);
                    };

                    pnlItem.Click += clickEvent;
                    lblIcon.Click += clickEvent;
                    lblName.Click += clickEvent;
                    lblAmount.Click += clickEvent;

                    flpBudgetList.Controls.Add(pnlItem);
                }
            }
            finally
            {
                flpBudgetList.ResumeLayout();
            }
        }

        public void DisplayBudgetDetail(BudgetDetailDto detail)
        {
            if (detail == null) return;

            lblBudgetName.Text = detail.CategoryName;
            lblNganSachAmount.Text = detail.FormattedBudget;
            lblDaChiAmount.Text = detail.FormattedSpent;
            lblConLaiAmountOverview.Text = detail.FormattedRemaining;

            lblDaChiStatsValue.Text = detail.FormattedSpent;
            lblConLaiStatsValue.Text = detail.FormattedRemaining;

            int percent = (int)Math.Min(100, Math.Max(0, detail.PercentageUsed));
            pbBudgetProgress.Value = percent;
            lblProgressPercent.Text = $"{detail.PercentageUsed:F1}%";

            // Đổi màu progress bar theo % sử dụng
            if (percent >= 90)
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ
            }
            else if (percent >= 70)
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(245, 158, 11); // Cam
            }
            else
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(34, 197, 94); // Xanh lá
            }

            lblNgayBatDauValue.Text = detail.FormattedStartDate;
            lblNgayKetThucValue.Text = detail.FormattedEndDate;

            if (dtpChartFrom != null) dtpChartFrom.Value = detail.StartDate;
            if (dtpChartTo != null) dtpChartTo.Value = detail.EndDate;
        }

        public void DisplayExpenseChart(IEnumerable<ExpenseBreakdownDto> breakdown)
        {
            try
            {
                if (_expenseChart == null || _expenseChart.Series.Count == 0)
                {
                    Debug.WriteLine("[UC_Budget] Chart not initialized");
                    return;
                }

                var series = _expenseChart.Series[0];
                series.Points.Clear();

                if (breakdown == null || !breakdown.Any())
                {
                    Debug.WriteLine("[UC_Budget] No data for chart");
                    series.Points.AddXY("Không có dữ liệu", 0);
                    return;
                }

                var chartType = cmbChartType?.SelectedItem?.ToString() ?? "Theo Ngày";
                Debug.WriteLine($"[UC_Budget] DisplayExpenseChart: {breakdown.Count()} points, Type: {chartType}");

                var groupedData = GroupDataByChartType(breakdown, chartType);

                foreach (var item in groupedData.OrderBy(x => x.Key))
                {
                    var point = series.Points.AddXY(item.Key, (double)item.Value);
                    series.Points[point].ToolTip = $"{item.Key}\nChi tiêu: {item.Value:N0}đ";
                }

                _expenseChart.Invalidate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"[UC_Budget] DisplayExpenseChart ERROR: {ex.Message}");
            }
        }

        private Dictionary<string, decimal> GroupDataByChartType(IEnumerable<ExpenseBreakdownDto> data, string chartType)
        {
            switch (chartType)
            {
                case "Theo Tuần":
                    return data
                        .GroupBy(x => $"Tuần {GetWeekOfYear(x.Date)}")
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));

                case "Theo Tháng":
                    return data
                        .GroupBy(x => x.Date.ToString("MM/yyyy"))
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));

                case "Theo Ngày":
                default:
                    return data
                        .GroupBy(x => x.Date.ToString("dd/MM"))
                        .ToDictionary(g => g.Key, g => g.Sum(x => x.TotalAmount));
            }
        }

        private int GetWeekOfYear(DateTime date)
        {
            var culture = System.Globalization.CultureInfo.CurrentCulture;
            return culture.Calendar.GetWeekOfYear(date,
                System.Globalization.CalendarWeekRule.FirstDay, DayOfWeek.Monday);
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }

        public void ShowLoading(bool isLoading)
        {
            this.Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
            this.Enabled = !isLoading;
        }

        public void ClearBudgetDetail()
        {
            lblBudgetName.Text = "Chọn ngân sách";
            lblNganSachAmount.Text = "0đ";
            lblDaChiAmount.Text = "0đ";
            lblConLaiAmountOverview.Text = "0đ";
            lblNgayBatDauValue.Text = "--/--/----";
            lblNgayKetThucValue.Text = "--/--/----";
            pbBudgetProgress.Value = 0;
            lblProgressPercent.Text = "0%";
            lblDaChiStatsValue.Text = "0đ";
            lblConLaiStatsValue.Text = "0đ";

            if (_expenseChart?.Series.Count > 0)
            {
                _expenseChart.Series[0].Points.Clear();
            }
        }
    }
}
