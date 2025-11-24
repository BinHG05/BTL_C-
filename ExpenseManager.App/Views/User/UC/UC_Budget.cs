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
using System.Windows.Forms.DataVisualization.Charting;
using ExpenseManager.App.CustomControls;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Budget : UserControl, IBudgetView
    {
        private BudgetPresenter _presenter;
        private Chart _expenseChart;
        private Button _btnAddCache;
        private HashSet<int> _warnedBudgetIds = new HashSet<int>();

        public string CurrentUserId
        {
            get => CurrentUserSession.CurrentUser?.UserId;
            set { }
        }

        public UC_Budget()
        {
            InitializeComponent();
            _btnAddCache = btnAddBudgetSidebar;

            // ✅ Tắt text trên progress bar
            if (pbBudgetProgress != null)
            {
                pbBudgetProgress.ShowText = false;
            }

            SetupEventHandlers();
            InitializeChart();
            _presenter = new BudgetPresenter(this, Program.ServiceProvider);
        }

        private void SetupEventHandlers()
        {
            this.Load += UC_Budget_Load;
            if (_btnAddCache != null)
            {
                _btnAddCache.Click -= BtnAddNewBudget_Click;
                _btnAddCache.Click += BtnAddNewBudget_Click;
            }
            if (btnDelete != null) btnDelete.Click += BtnDelete_Click;
            if (btnEdit != null) btnEdit.Click += BtnEdit_Click;
            if (cmbChartType != null) cmbChartType.SelectedIndexChanged += CmbChartType_SelectedIndexChanged;
            if (dtpChartFrom != null) dtpChartFrom.ValueChanged += DateRange_Changed;
            if (dtpChartTo != null) dtpChartTo.ValueChanged += DateRange_Changed;
        }

        private void InitializeChart()
        {
            _expenseChart = new Chart { Dock = DockStyle.Fill, BackColor = Color.White };
            var chartArea = new ChartArea("MainArea") { BackColor = Color.White };

            // Grid lines
            chartArea.AxisX.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartArea.AxisY.MajorGrid.LineColor = Color.FromArgb(240, 240, 240);
            chartArea.AxisX.LineColor = Color.LightGray;
            chartArea.AxisY.LineColor = Color.LightGray;

            // ✅ Cấu hình trục X cho DateTime
            chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
            chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;

            _expenseChart.ChartAreas.Add(chartArea);

            var series = new Series("Expense")
            {
                ChartType = SeriesChartType.Column,
                Color = Color.FromArgb(99, 102, 241),
                IsValueShownAsLabel = true,
                Font = new Font("Segoe UI", 8f),
                XValueType = ChartValueType.DateTime // ✅ QUAN TRỌNG
            };

            series["PointWidth"] = "0.5";
            series["MaxPixelPointWidth"] = "60";

            _expenseChart.Series.Add(series);

            if (pnlChartArea != null)
            {
                pnlChartArea.Controls.Clear();
                pnlChartArea.Controls.Add(_expenseChart);
            }
        }

        private void UC_Budget_Load(object sender, EventArgs e)
        {
            if (CurrentUserSession.CurrentUser == null) return;
            ViewLoaded?.Invoke(this, EventArgs.Empty);
        }

        public void DisplayBudgetList(IEnumerable<BudgetSummaryDto> budgets)
        {
            try
            {
                flpBudgetList.SuspendLayout();
                flpBudgetList.Controls.Clear();

                if (budgets != null && budgets.Any())
                {
                    bool isFirstItem = true;

                    foreach (var budget in budgets)
                    {
                        Panel pnlItem = new Panel
                        {
                            Width = 325,
                            Height = 90,
                            Cursor = Cursors.Hand,
                            Margin = new Padding(3, 5, 3, 5),
                            Tag = budget
                        };

                        Color iconColor = Color.Black;
                        if (!string.IsNullOrEmpty(budget.HexCode))
                        {
                            try { iconColor = ColorTranslator.FromHtml(budget.HexCode); } catch { }
                        }

                        Label lblIcon = new Label
                        {
                            Text = GetEmoji(budget.IconClass, budget.CategoryName),
                            Font = new Font("Segoe UI", 18),
                            AutoSize = true,
                            BackColor = Color.Transparent,
                            Location = new Point(15, 28),
                            ForeColor = iconColor
                        };
                        lblIcon.Tag = iconColor;

                        Label lblName = new Label
                        {
                            Text = budget.CategoryName,
                            Font = new Font("Segoe UI", 12, FontStyle.Bold),
                            AutoSize = true,
                            BackColor = Color.Transparent,
                            Location = new Point(75, 18)
                        };

                        Label lblAmount = new Label
                        {
                            Text = budget.FormattedBudget,
                            Font = new Font("Segoe UI", 10, FontStyle.Regular),
                            AutoSize = true,
                            BackColor = Color.Transparent,
                            Location = new Point(75, 48)
                        };

                        pnlItem.Controls.Add(lblIcon);
                        pnlItem.Controls.Add(lblName);
                        pnlItem.Controls.Add(lblAmount);

                        void SetActiveState(bool isActive)
                        {
                            if (isActive)
                            {
                                pnlItem.BackColor = Color.FromArgb(59, 130, 246);
                                lblName.ForeColor = Color.White;
                                lblAmount.ForeColor = Color.White;
                                lblIcon.ForeColor = Color.White;
                            }
                            else
                            {
                                pnlItem.BackColor = Color.White;
                                lblName.ForeColor = Color.FromArgb(30, 41, 59);
                                lblAmount.ForeColor = Color.FromArgb(100, 116, 139);
                                if (lblIcon.Tag is Color c) lblIcon.ForeColor = c;
                            }
                        }

                        EventHandler clickEvent = (s, ev) =>
                        {
                            foreach (Control ctrl in flpBudgetList.Controls)
                            {
                                if (ctrl is Panel p && ctrl.Tag is BudgetSummaryDto)
                                {
                                    p.BackColor = Color.White;
                                    foreach (Control child in p.Controls)
                                    {
                                        if (child is Label lbl)
                                        {
                                            if (lbl.Location.X < 60) { if (lbl.Tag is Color c) lbl.ForeColor = c; }
                                            else if (lbl.Location.Y < 40) lbl.ForeColor = Color.FromArgb(30, 41, 59);
                                            else lbl.ForeColor = Color.FromArgb(100, 116, 139);
                                        }
                                    }
                                }
                            }
                            SetActiveState(true);
                            BudgetSelected?.Invoke(this, budget.BudgetId);
                        };

                        pnlItem.Click += clickEvent;
                        lblIcon.Click += clickEvent;
                        lblName.Click += clickEvent;
                        lblAmount.Click += clickEvent;

                        flpBudgetList.Controls.Add(pnlItem);

                        if (isFirstItem)
                        {
                            SetActiveState(true);
                            isFirstItem = false;
                        }
                        else { SetActiveState(false); }
                    }
                }

                if (_btnAddCache != null) flpBudgetList.Controls.Add(_btnAddCache);
            }
            finally { flpBudgetList.ResumeLayout(); }
        }

        private string GetEmoji(string iconClass, string name)
        {
            string text = ((iconClass ?? "") + " " + (name ?? "")).ToLower();
            if (text.Contains("paw") || text.Contains("dog")) return "🐾";
            if (text.Contains("coffee") || text.Contains("cà phê")) return "☕";
            if (text.Contains("shirt") || text.Contains("quần")) return "👕";
            if (text.Contains("shield") || text.Contains("bảo hiểm")) return "🛡️";
            if (text.Contains("ticket") || text.Contains("trúng số")) return "🎟️";
            if (text.Contains("money") || text.Contains("lương")) return "💵";
            if (text.Contains("food") || text.Contains("ăn")) return "🍔";
            if (text.Contains("fuel") || text.Contains("xe")) return "⛽";
            return "💰";
        }

        private async void BtnAddNewBudget_Click(object sender, EventArgs e)
        {
            if (_presenter == null) return;
            try
            {
                var categories = await _presenter.GetCategoriesForNewBudgetAsync();
                var existingIds = _presenter.GetExistingBudgetCategoryIds();
                var available = categories.Where(c => !existingIds.Contains(c.CategoryId)).ToList();

                if (available.Count == 0) { MessageBox.Show("Tất cả danh mục đã có ngân sách!"); return; }

                using (var dialog = new BudgetCreateDialog(available))
                {
                    if (dialog.ShowDialog() == DialogResult.OK && dialog.CreatedBudgetDto != null)
                    {
                        await _presenter.CreateBudgetAsync(dialog.CreatedBudgetDto);
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show("Lỗi: " + ex.Message); }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            var r = MessageBox.Show("Bạn có chắc chắn muốn xóa ngân sách này?", "Xác nhận", MessageBoxButtons.YesNo);
            if (r == DialogResult.Yes) DeleteBudgetClicked?.Invoke(this, EventArgs.Empty);
        }

        private void BtnEdit_Click(object sender, EventArgs e) => EditBudgetClicked?.Invoke(this, EventArgs.Empty);

        private void CmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChartType.SelectedItem != null)
            {
                string chartType = cmbChartType.SelectedItem.ToString();
                switch (chartType)
                {
                    case "Theo Ngày":
                        dtpChartFrom.Format = DateTimePickerFormat.Short;
                        dtpChartTo.Format = DateTimePickerFormat.Short;
                        dtpChartFrom.ShowUpDown = false;
                        dtpChartTo.ShowUpDown = false;
                        break;
                    case "Theo Tuần":
                        dtpChartFrom.Format = DateTimePickerFormat.Short;
                        dtpChartTo.Format = DateTimePickerFormat.Short;
                        dtpChartFrom.ShowUpDown = false;
                        dtpChartTo.ShowUpDown = false;
                        break;
                    case "Theo Tháng":
                        dtpChartFrom.Format = DateTimePickerFormat.Custom;
                        dtpChartFrom.CustomFormat = "MM/yyyy";
                        dtpChartTo.Format = DateTimePickerFormat.Custom;
                        dtpChartTo.CustomFormat = "MM/yyyy";
                        dtpChartFrom.ShowUpDown = true;
                        dtpChartTo.ShowUpDown = true;
                        break;
                }
                ChartTypeChanged?.Invoke(this, chartType);
            }
        }

        private void DateRange_Changed(object sender, EventArgs e)
        {
            if (dtpChartFrom != null && dtpChartTo != null)
                ChartDateRangeChanged?.Invoke(this, new BudgetViewDateRangeEventArgs
                {
                    StartDate = dtpChartFrom.Value.Date,
                    EndDate = dtpChartTo.Value.Date
                });
        }

        public event EventHandler ViewLoaded;
        public event EventHandler<int> BudgetSelected;
        public event EventHandler AddBudgetClicked;
        public event EventHandler EditBudgetClicked;
        public event EventHandler DeleteBudgetClicked;
        public event EventHandler<BudgetViewDateRangeEventArgs> ChartDateRangeChanged;
        public event EventHandler<string> ChartTypeChanged;

        public void DisplayBudgetDetail(BudgetDetailDto detail)
        {
            if (detail == null) return;

            lblBudgetName.Text = detail.CategoryName;
            lblNganSachAmount.Text = detail.FormattedBudget;
            lblDaChiAmount.Text = detail.FormattedSpent;
            lblConLaiAmountOverview.Text = detail.FormattedRemaining;
            lblDaChiStatsValue.Text = detail.FormattedSpent;
            lblConLaiStatsValue.Text = detail.FormattedRemaining;
            lblNgayBatDauValue.Text = detail.FormattedStartDate;
            lblNgayKetThucValue.Text = detail.FormattedEndDate;
            lblProgressPercent.Text = $"{detail.PercentageUsed:F1}%";
            pbBudgetProgress.Percentage = (double)detail.PercentageUsed;

            if (detail.IsOverBudget && !_warnedBudgetIds.Contains(detail.BudgetId))
            {
                _warnedBudgetIds.Add(detail.BudgetId);
                MessageBox.Show(
                    $"Cảnh báo: Bạn đã chi tiêu vượt quá ngân sách cho danh mục '{detail.CategoryName}'!\n\nSố tiền vượt: {Math.Abs(detail.RemainingAmount):N0}đ",
                    "Cảnh báo quá hạn mức",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning
                );
            }
        }

        public void DisplayExpenseChart(IEnumerable<ExpenseBreakdownDto> breakdown)
        {
            if (_expenseChart == null || _expenseChart.Series.Count == 0) return;

            var series = _expenseChart.Series[0];
            series.Points.Clear();

            if (breakdown == null || !breakdown.Any())
            {
                _expenseChart.Invalidate();
                return;
            }

            // ✅ Reset cấu hình trục X
            _expenseChart.ChartAreas[0].AxisX.LabelStyle.Format = "";
            _expenseChart.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Auto;

            // ✅ Set XValueType cho DateTime
            series.XValueType = ChartValueType.DateTime;

            foreach (var item in breakdown)
            {
                // ✅ Truyền DateTime object, không phải string
                int pointIndex = series.Points.AddXY(item.Date, (double)item.TotalAmount);
                series.Points[pointIndex].Label = item.TotalAmount.ToString("N0");
                series.Points[pointIndex].ToolTip = $"{item.Date:dd/MM/yyyy}\n{item.TotalAmount:N0}đ";
            }

            var chartArea = _expenseChart.ChartAreas[0];

            if (breakdown.Count() > 10)
            {
                chartArea.AxisX.LabelStyle.Format = "dd/MM";
                chartArea.AxisX.LabelStyle.Angle = -45;
                chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;
                chartArea.AxisX.Interval = 1;
            }
            else if (breakdown.Count() > 1)
            {
                chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
                chartArea.AxisX.LabelStyle.Angle = 0;
                chartArea.AxisX.IntervalType = DateTimeIntervalType.Days;

                var dates = breakdown.Select(b => b.Date).OrderBy(d => d).ToList();
                var dayRange = (dates.Last() - dates.First()).Days;

                if (dayRange > 30)
                    chartArea.AxisX.Interval = 7;
                else if (dayRange > 7)
                    chartArea.AxisX.Interval = 3;
                else
                    chartArea.AxisX.Interval = 1;
            }
            else
            {
                chartArea.AxisX.LabelStyle.Format = "dd/MM/yyyy";
                chartArea.AxisX.LabelStyle.Angle = 0;
            }

            _expenseChart.Invalidate();
        }

        public void ShowMessage(string message, string title, MessageBoxIcon icon)
            => MessageBox.Show(message, title, MessageBoxButtons.OK, icon);

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
            lblDaChiStatsValue.Text = "0đ";
            lblConLaiStatsValue.Text = "0đ";
            lblNgayBatDauValue.Text = "--";
            lblNgayKetThucValue.Text = "--";
            lblProgressPercent.Text = "0.0%";
            pbBudgetProgress.Percentage = 0;

            // ✅ Clear cached data
            _warnedBudgetIds.Clear();

            // ✅ Clear chart
            if (_expenseChart?.Series.Count > 0)
            {
                _expenseChart.Series[0].Points.Clear();
                _expenseChart.Invalidate();
            }

            // ✅ Clear budget list (giữ lại button Add)
            if (flpBudgetList != null)
            {
                flpBudgetList.Controls.Clear();
                if (_btnAddCache != null)
                    flpBudgetList.Controls.Add(_btnAddCache);
            }
        }

        public void SetChartDateRange(DateTime startDate, DateTime endDate)
        {
            if (dtpChartFrom != null && dtpChartTo != null)
            {
                // Tạm thời unsubscribe để tránh trigger event
                dtpChartFrom.ValueChanged -= DateRange_Changed;
                dtpChartTo.ValueChanged -= DateRange_Changed;

                dtpChartFrom.Value = startDate;
                dtpChartTo.Value = endDate;

                // Subscribe lại
                dtpChartFrom.ValueChanged += DateRange_Changed;
                dtpChartTo.ValueChanged += DateRange_Changed;
            }
        }

        // ✅ DISPOSE METHOD
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Dispose presenter
                if (_presenter != null)
                {
                    _presenter.Dispose();
                    _presenter = null;
                }

                // Unsubscribe events
                this.Load -= UC_Budget_Load;

                if (_btnAddCache != null)
                    _btnAddCache.Click -= BtnAddNewBudget_Click;

                if (btnDelete != null)
                    btnDelete.Click -= BtnDelete_Click;

                if (btnEdit != null)
                    btnEdit.Click -= BtnEdit_Click;

                if (cmbChartType != null)
                    cmbChartType.SelectedIndexChanged -= CmbChartType_SelectedIndexChanged;

                if (dtpChartFrom != null)
                    dtpChartFrom.ValueChanged -= DateRange_Changed;

                if (dtpChartTo != null)
                    dtpChartTo.ValueChanged -= DateRange_Changed;

                // Dispose chart
                if (_expenseChart != null)
                {
                    _expenseChart.Dispose();
                    _expenseChart = null;
                }

                // Clear cache
                _warnedBudgetIds?.Clear();
            }

            base.Dispose(disposing);
        }
    }
}