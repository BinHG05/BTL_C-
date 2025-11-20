using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Services;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Session;
using ExpenseManager.App.Views.User;

namespace ExpenseManager.App.Views.Admin.UC
{
    public partial class UC_Budget : UserControl, IBudgetView
    {
        private BudgetPresenter _presenter;

        public string CurrentUserId
        {
            get
            {
                return CurrentUserSession.CurrentUser?.UserId;
            }
            set
            {
                // Không làm gì vì UserId lấy từ session
            }
        }

        // Parameterless ctor so view can be constructed independently from presenter
        public UC_Budget()
        {
            InitializeComponent();
        }

        // Attach presenter after view construction to avoid circular ctor dependency
        public void SetPresenter(BudgetPresenter presenter)
        {
            _presenter = presenter ?? throw new ArgumentNullException(nameof(presenter));
            WireUpEvents();
        }

        private void WireUpEvents()
        {
            // guard to ensure presenter is available
            if (_presenter == null) return;

            btnAddNewBudget.Click -= BtnAddNewBudget_Click;
            btnAddBudgetSidebar.Click -= BtnAddNewBudget_Click;
            btnDelete.Click -= BtnDelete_Click;
            cmbChartType.SelectedIndexChanged -= CmbChartType_SelectedIndexChanged;

            btnAddNewBudget.Click += BtnAddNewBudget_Click;
            btnAddBudgetSidebar.Click += BtnAddNewBudget_Click;
            btnDelete.Click += BtnDelete_Click;

            cmbChartType.SelectedIndexChanged += CmbChartType_SelectedIndexChanged;
        }

        private async void BtnAddNewBudget_Click(object sender, EventArgs e)
        {
            try
            {
                var categories = await _presenter.GetCategoriesForNewBudgetAsync();
                if (categories == null || categories.Count == 0)
                {
                    MessageBox.Show("Bạn chưa có danh mục chi tiêu nào.", "Thông báo");
                    return;
                }

                using (var dialog = new BudgetCreateDialog(categories))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        await _presenter.CreateBudgetAsync(dialog.CreatedBudgetDto);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DeleteBudgetClicked?.Invoke(this, EventArgs.Empty);
        }

        private void CmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbChartType.SelectedItem != null)
                ChartTypeChanged?.Invoke(this, cmbChartType.SelectedItem.ToString());
        }

        private void UC_Budget_Load(object sender, EventArgs e)
        {
            if (CurrentUserSession.CurrentUser == null)
            {
                MessageBox.Show("Bạn chưa đăng nhập. Vui lòng đăng nhập trước khi sử dụng chức năng này.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ViewLoaded?.Invoke(this, EventArgs.Empty);

            if (cmbChartType.Items.Count > 0) cmbChartType.SelectedIndex = 0;
        }

        // ================== IMPLEMENT IBudgetView ==================

        public event EventHandler ViewLoaded;
        public event EventHandler<int> BudgetSelected;
        public event EventHandler AddBudgetClicked;
        public event EventHandler EditBudgetClicked;
        public event EventHandler DeleteBudgetClicked;
        public event EventHandler<BudgetViewDateRangeEventArgs> ChartDateRangeChanged;
        public event EventHandler<string> ChartTypeChanged;

        public void DisplayBudgetList(IEnumerable<BudgetSummaryDto> budgets)
        {
            flpBudgetList.Controls.Clear();
            foreach (var budget in budgets)
            {
                Panel pnlItem = new Panel
                {
                    Size = new Size(330, 100),
                    BackColor = Color.White,
                    Cursor = Cursors.Hand,
                    Margin = new Padding(3)
                };

                Label lblIcon = new Label { Text = _presenter?.GetIconEmoji(budget.IconId) ?? "💰", Font = new Font("Segoe UI", 24), Location = new Point(20, 25), AutoSize = true };
                Label lblName = new Label { Text = budget.CategoryName, Font = new Font("Segoe UI", 13, FontStyle.Bold), ForeColor = Color.FromArgb(30, 41, 59), Location = new Point(80, 25), AutoSize = true };
                Label lblAmount = new Label { Text = budget.FormattedBudget, Font = new Font("Segoe UI", 10), ForeColor = Color.Gray, Location = new Point(80, 55), AutoSize = true };

                pnlItem.Controls.AddRange(new Control[] { lblIcon, lblName, lblAmount });

                EventHandler clickEvent = (s, e) => BudgetSelected?.Invoke(this, budget.BudgetId);
                pnlItem.Click += clickEvent;
                lblIcon.Click += clickEvent;
                lblName.Click += clickEvent;
                lblAmount.Click += clickEvent;

                flpBudgetList.Controls.Add(pnlItem);
            }
            flpBudgetList.Controls.Add(btnAddBudgetSidebar);
        }

        public void DisplayBudgetDetail(BudgetDetailDto detail)
        {
            if (detail == null) return;
            lblBudgetName.Text = detail.CategoryName;
            lblNganSachAmount.Text = detail.FormattedBudget;
            lblDaChiAmount.Text = detail.FormattedSpent;
            lblConLaiAmountOverview.Text = detail.FormattedRemaining;
            lblConLaiStatsValue.Text = detail.FormattedRemaining;

            int percent = (int)detail.PercentageUsed;
            if (percent > 100) percent = 100; else if (percent < 0) percent = 0;
            pbBudgetProgress.Value = percent;
            lblProgressPercent.Text = $"{detail.PercentageUsed}%";

            lblNgayBatDauValue.Text = detail.FormattedStartDate;
            lblNgayKetThucValue.Text = detail.FormattedEndDate;
        }

        public void DisplayExpenseChart(IEnumerable<ExpenseBreakdownDto> breakdown) { }
        public void ShowMessage(string message, string title, MessageBoxIcon icon) => MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        public void ShowLoading(bool isLoading) => Cursor = isLoading ? Cursors.WaitCursor : Cursors.Default;
        public void ClearBudgetDetail()
        {
            lblBudgetName.Text = "Chưa chọn";
            lblNganSachAmount.Text = "0đ";
            lblDaChiAmount.Text = "0đ";
        }
    }
}