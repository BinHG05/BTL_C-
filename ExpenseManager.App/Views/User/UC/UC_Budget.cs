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

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Budget : UserControl, IBudgetView
    {
        private BudgetPresenter _presenter;
        private Chart _expenseChart;
        private Button _btnAddCache;

        // THÊM: Lưu ID budget đã cảnh báo
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
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dot;
            _expenseChart.ChartAreas.Add(chartArea);
            _expenseChart.Series.Add(new Series("Expense") { ChartType = SeriesChartType.Column, Color = Color.FromArgb(99, 102, 241), IsValueShownAsLabel = true });
            if (pnlChartArea != null) { pnlChartArea.Controls.Clear(); pnlChartArea.Controls.Add(_expenseChart); }
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

                // Thay đổi format DateTimePicker theo loại chart
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

            // SỬA: ProgressBar tối đa 100%, màu đỏ khi vượt
            int percent = (int)Math.Min(100, Math.Max(0, detail.PercentageUsed));
            pbBudgetProgress.Value = percent;
            lblProgressPercent.Text = $"{detail.PercentageUsed:F1}%";

            if (detail.IsOverBudget)
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ
            }
            else if (percent >= 90)
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(239, 68, 68); // Đỏ
            }
            else if (percent >= 70)
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(245, 158, 11); // Cam
            }
            else
            {
                pbBudgetProgress.ForeColor = Color.FromArgb(34, 197, 94); // Xanh
            }

            // SỬA: Chỉ cảnh báo 1 lần khi chưa cảnh báo budget này
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
            if (breakdown == null) return;
            foreach (var item in breakdown)
                series.Points.AddXY(item.FormattedDate, (double)item.TotalAmount);
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
        }
    }
}