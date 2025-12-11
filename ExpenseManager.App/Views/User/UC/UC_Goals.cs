using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Views.Admin.Forms;
using ExpenseManager.App.Views.User.UC;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.User
{
    public partial class UC_Goals : UserControl, IGoalsView
    {
        private readonly GoalsPresenter _presenter;

        // --- CẤU HÌNH MÀU SẮC ---
        private Color activeBgColor = Color.FromArgb(59, 130, 246);
        private Color activeTextColor = Color.White;
        private Color activeSubColor = Color.FromArgb(225, 230, 255);

        private Color inactiveBgColor = Color.White;
        private Color titleColor = Color.FromArgb(30, 41, 59);
        private Color subTitleColor = Color.FromArgb(100, 116, 139);

        private Panel _activeGoalPanel = null;
        private decimal _currentGoalTotalAmount = 0;

        public UC_Goals(GoalsPresenter presenter)
        {
            InitializeComponent();
            this.BackColor = Color.FromArgb(238, 242, 247);

            _presenter = presenter;
            _presenter.SetView(this);

            SetupGridView();
            InitializeEvents();
            ClearGoalDetails();

            this.Load += async (s, e) => await _presenter.LoadUserGoalsAsync();
        }

        private void SetupGridView()
        {
            dgvHistory.ScrollBars = ScrollBars.None;
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.GridColor = Color.FromArgb(241, 245, 249);

            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvHistory.ColumnHeadersHeight = 50;

            dgvHistory.DefaultCellStyle.BackColor = Color.White;
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(30, 41, 59);
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvHistory.DefaultCellStyle.Padding = new Padding(10, 0, 0, 0);
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.FromArgb(30, 41, 59);

            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.Height = 60;
            dgvHistory.AllowUserToResizeRows = false;

            dgvHistory.CellFormatting += dgvHistory_CellFormatting;
        }

        private void dgvHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvHistory.Columns[e.ColumnIndex].Name == "Amount" && e.Value != null)
            {
                if (decimal.TryParse(e.Value.ToString(), out decimal amount))
                {
                    e.Value = "+" + amount.ToString("N0") + " đ";
                    e.FormattingApplied = true;
                }
            }
        }

        private void InitializeEvents()
        {
            btnNaptien.Click += BtnNaptien_Click;
            btnXoa.Click += BtnXoa_Click;
        }

        private Button CreateAddButton()
        {
            Button btn = new Button();
            btn.Size = new Size(330, 55);
            btn.Margin = new Padding(0, 10, 0, 20);
            btn.Text = "⊕  Thêm mục tiêu mới";
            btn.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            btn.ForeColor = Color.FromArgb(30, 41, 59);
            btn.BackColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.BorderSize = 1;
            btn.Cursor = Cursors.Hand;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Click += BtnAddGoal_Click;
            return btn;
        }

        public void DisplayGoalsList(IEnumerable<GoalDTO> goals)
        {
            flpGoals.Controls.Clear();

            if (goals != null && goals.Any())
            {
                pnlEmptyState.Visible = false;
                ToggleMainContent(true);

                var currentSelectedId = _presenter.GetSelectedGoalId();

                foreach (var goal in goals)
                {
                    var card = CreateGoalCard(goal);
                    flpGoals.Controls.Add(card);

                    if (currentSelectedId.HasValue && goal.GoalId == currentSelectedId.Value)
                    {
                        SetActiveCardStyle(card, true);
                        _activeGoalPanel = card;
                    }
                    else if (!currentSelectedId.HasValue && goal == goals.First())
                    {
                        SetActiveCardStyle(card, true);
                        _activeGoalPanel = card;
                        _presenter.LoadGoalDetailsAsync(goal.GoalId);
                    }
                }
            }
            else
            {
                ShowEmptyState();
            }

            var btnAdd = CreateAddButton();
            flpGoals.Controls.Add(btnAdd);
        }

        private Panel CreateGoalCard(GoalDTO goal)
        {
            Panel pnl = new Panel();
            pnl.Size = new Size(330, 90);
            pnl.Margin = new Padding(0, 0, 0, 10);
            pnl.Cursor = Cursors.Hand;
            pnl.Tag = goal.GoalId;
            pnl.BackColor = inactiveBgColor;

            Label lblIcon = new Label();
            lblIcon.Text = "🎯";
            lblIcon.Font = new Font("Segoe UI", 20);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(15, 25);
            lblIcon.BackColor = Color.Transparent;

            Label lblName = new Label();
            lblName.Text = goal.GoalName;
            lblName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblName.ForeColor = titleColor;
            lblName.Location = new Point(100, 20);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;

            Label lblAmount = new Label();
            lblAmount.Text = $"{goal.CurrentAmount:N0}đ / {goal.TargetAmount:N0}đ";
            lblAmount.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            lblAmount.ForeColor = subTitleColor;
            lblAmount.Location = new Point(100, 45);
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.Transparent;

            // --- LOGIC TRẠNG THÁI ---
            bool isFinished = goal.CurrentAmount >= goal.TargetAmount;
            bool isDeadlinePassed = goal.CompletionDate.HasValue && DateTime.Today > goal.CompletionDate.Value.Date;
            
            // Determine Status
            // 1. Completed Late
            bool isCompletedLate = isFinished && goal.CompletionDate.HasValue && goal.LastDepositDate.HasValue 
                                   && goal.LastDepositDate.Value.Date > goal.CompletionDate.Value.Date;

            // 2. Overdue (Not finished and deadline passed)
            bool isOverdue = !isFinished && isDeadlinePassed;

            // 3. Completed (On time)
            bool isCompleted = isFinished && !isCompletedLate;

            // --- ÁP DỤNG STYLE ---
            if (isCompletedLate)
            {
                pnl.BackColor = Color.FromArgb(255, 247, 237); // Orange tint
                pnl.Paint += (s, e) => {
                    ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.FromArgb(249, 115, 22), ButtonBorderStyle.Solid);
                };
                lblIcon.Text = "⚠️"; // Warning icon
                lblName.ForeColor = Color.FromArgb(194, 65, 12); // Dark Orange
            }
            else if (isOverdue)
            {
                pnl.BackColor = Color.FromArgb(254, 242, 242); // Red tint
                pnl.Paint += (s, e) => {
                    ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.FromArgb(239, 68, 68), ButtonBorderStyle.Solid);
                };
                lblIcon.Text = "⏰"; // Alarm icon
                lblName.ForeColor = Color.FromArgb(185, 28, 28); // Dark Red
            }
            else if (isCompleted)
            {
                pnl.BackColor = Color.FromArgb(240, 253, 244); // Green tint
                pnl.Paint += (s, e) => {
                    ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.FromArgb(34, 197, 94), ButtonBorderStyle.Solid);
                };
                lblIcon.Text = "✅"; // Check icon
                lblName.ForeColor = Color.FromArgb(21, 128, 61); // Dark Green
            }
            else
            {
                pnl.BackColor = inactiveBgColor; // Default
            }

            // Add Status Label (Optional, but helpful)
            Label lblStatus = new Label();
            lblStatus.Font = new Font("Segoe UI", 8, FontStyle.Italic);
            lblStatus.Location = new Point(100, 70);
            lblStatus.AutoSize = true;
            
            if (isCompletedLate) { lblStatus.Text = "Hoàn thành trễ"; lblStatus.ForeColor = Color.FromArgb(194, 65, 12); }
            else if (isOverdue) { lblStatus.Text = "Quá hạn"; lblStatus.ForeColor = Color.FromArgb(185, 28, 28); }
            else if (isCompleted) { lblStatus.Text = "Đã hoàn thành"; lblStatus.ForeColor = Color.FromArgb(21, 128, 61); }
            else { lblStatus.Text = "Đang thực hiện"; lblStatus.ForeColor = subTitleColor; }

            EventHandler clickEvent = (s, e) =>
            {
                if (_activeGoalPanel != pnl)
                {
                    if (_activeGoalPanel != null) SetActiveCardStyle(_activeGoalPanel, false);
                    SetActiveCardStyle(pnl, true);
                    _activeGoalPanel = pnl;
                    _presenter.LoadGoalDetailsAsync(goal.GoalId);
                }
            };

            pnl.Click += clickEvent;
            lblIcon.Click += clickEvent;
            lblName.Click += clickEvent;
            lblAmount.Click += clickEvent;
            lblStatus.Click += clickEvent;

            pnl.Controls.Add(lblIcon);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblAmount);
            pnl.Controls.Add(lblStatus);

            return pnl;
        }

        private void SetActiveCardStyle(Panel pnl, bool isActive)
        {
            if (pnl == null) return;

            Label lblIcon = pnl.Controls[0] as Label;
            Label lblName = pnl.Controls[1] as Label;
            Label lblAmount = pnl.Controls[2] as Label;

            if (isActive)
            {
                pnl.BackColor = activeBgColor;
                if (lblName != null) lblName.ForeColor = activeTextColor;
                if (lblAmount != null) lblAmount.ForeColor = activeSubColor;
            }
            else
            {
                pnl.BackColor = inactiveBgColor;
                if (lblName != null) lblName.ForeColor = titleColor;
                if (lblAmount != null) lblAmount.ForeColor = subTitleColor;
            }
        }

        public void DisplayGoalDetails(GoalDTO goal)
        {
            if (goal == null) return;

            _currentGoalTotalAmount = goal.CurrentAmount;

            lblGoalTitle.Text = goal.GoalName;
            lblSavedAmount.Text = $"{goal.CurrentAmount:N0} đ";
            lblTargetAmount.Text = $"{goal.TargetAmount:N0} đ";

            // LOGIC PROGRESS BAR CUSTOM
            if (goal.TargetAmount > 0)
            {
                decimal rawPercent = (goal.CurrentAmount / goal.TargetAmount);
                if (rawPercent > 1) rawPercent = 1;
                if (rawPercent < 0) rawPercent = 0;

                int width = (int)(rawPercent * pnlPbBackground.Width);
                pnlPbValue.Width = width;
            }
            else
            {
                pnlPbValue.Width = (goal.CurrentAmount > 0) ? pnlPbBackground.Width : 0;
            }

            btnNaptien.Enabled = true;
        }

        public void DisplayWalletContributions(IEnumerable<GoalContributionDTO> contributions)
        {
            flpWalletList.SuspendLayout();
            flpWalletList.Controls.Clear();

            if (contributions != null && contributions.Any())
            {
                foreach (var item in contributions.OrderByDescending(x => x.ContributedAmount))
                {
                    var panel = CreateContributionItem(item);
                    flpWalletList.Controls.Add(panel);
                }
            }
            else
            {
                Label lblEmpty = new Label();
                lblEmpty.Text = "Chưa có khoản đóng góp nào.";
                lblEmpty.AutoSize = true;
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblEmpty.Margin = new Padding(20);
                flpWalletList.Controls.Add(lblEmpty);
            }
            flpWalletList.ResumeLayout();
            flpWalletList.PerformLayout();
        }

        private Panel CreateContributionItem(GoalContributionDTO contribution)
        {
            int itemWidth = pnlAvailable.Width - 60;
            int itemHeight = 70;

            Panel pnlItem = new Panel();
            pnlItem.Size = new Size(itemWidth, itemHeight);
            pnlItem.Margin = new Padding(0, 0, 0, 15);
            pnlItem.BackColor = Color.Transparent;

            // 1. Icon
            Label lblIcon = new Label();
            lblIcon.Text = "💰";
            if (contribution.WalletName.ToLower().Contains("momo")) lblIcon.Text = "📱";
            else if (contribution.WalletName.ToLower().Contains("bank")) lblIcon.Text = "🏦";
            else if (contribution.WalletName.ToLower().Contains("tiền mặt")) lblIcon.Text = "💵";
            else if (contribution.WalletName.ToLower().Contains("bidv")) lblIcon.Text = "🏦";

            lblIcon.Font = new Font("Segoe UI", 18);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(0, 10);

            // 2. Tên ví
            Label lblName = new Label();
            lblName.Text = contribution.WalletName;
            lblName.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblName.ForeColor = titleColor;
            lblName.AutoSize = true;
            lblName.Location = new Point(70, 15);

            // 3. Số tiền
            Label lblAmount = new Label();
            lblAmount.Text = $"{contribution.ContributedAmount:N0} đ";
            lblAmount.Font = new Font("Segoe UI", 11, FontStyle.Bold);
            lblAmount.ForeColor = titleColor;
            lblAmount.AutoSize = false;
            lblAmount.TextAlign = ContentAlignment.MiddleRight;
            lblAmount.Size = new Size(200, 30);
            lblAmount.Location = new Point(itemWidth - 210, 15);

            // 4. Thanh Background
            Panel pnlBarBg = new Panel();
            pnlBarBg.Size = new Size(itemWidth - 70, 6);
            pnlBarBg.Location = new Point(70, 50);
            pnlBarBg.BackColor = Color.FromArgb(226, 232, 240);

            // 5. Thanh Value
            int percent = 0;
            if (_currentGoalTotalAmount > 0)
                percent = (int)((contribution.ContributedAmount / _currentGoalTotalAmount) * 100);
            if (percent > 100) percent = 100;

            Panel pnlBarVal = new Panel();
            pnlBarVal.Height = 6;
            pnlBarVal.BackColor = Color.FromArgb(16, 185, 129);
            pnlBarVal.Location = new Point(0, 0);
            pnlBarVal.Width = (int)((float)percent / 100 * pnlBarBg.Width);

            pnlBarBg.Controls.Add(pnlBarVal);
            pnlItem.Controls.Add(lblIcon);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblAmount);
            pnlItem.Controls.Add(pnlBarBg);

            return pnlItem;
        }

        public void DisplayHistory(IEnumerable<GoalDepositHistoryDTO> history)
        {
            dgvHistory.DataSource = null;
            dgvHistory.Rows.Clear();

            if (history == null || !history.Any())
            {
                lblNoHistory.Visible = true;
                dgvHistory.Visible = false;
                return;
            }

            lblNoHistory.Visible = false;
            dgvHistory.Visible = true;

            var data = history.OrderByDescending(h => h.DepositDate).Take(10).ToList();
            dgvHistory.DataSource = data;
            ConfigureGridColumns();
        }

        private void ConfigureGridColumns()
        {
            if (dgvHistory.Columns["DepositId"] != null) dgvHistory.Columns["DepositId"].Visible = false;
            if (dgvHistory.Columns["GoalId"] != null) dgvHistory.Columns["GoalId"].Visible = false;
            if (dgvHistory.Columns["WalletId"] != null) dgvHistory.Columns["WalletId"].Visible = false;

            if (dgvHistory.Columns["DepositDate"] != null)
            {
                dgvHistory.Columns["DepositDate"].HeaderText = "Ngày giao dịch";
                dgvHistory.Columns["DepositDate"].DefaultCellStyle.Format = "dd/MM/yyyy";
                dgvHistory.Columns["DepositDate"].FillWeight = 20;
            }

            if (dgvHistory.Columns["WalletName"] != null)
            {
                dgvHistory.Columns["WalletName"].HeaderText = "Nguồn tiền";
                dgvHistory.Columns["WalletName"].FillWeight = 30;
            }

            if (dgvHistory.Columns["Note"] != null)
            {
                dgvHistory.Columns["Note"].HeaderText = "Nội dung";
                dgvHistory.Columns["Note"].FillWeight = 30;
            }

            if (dgvHistory.Columns["Amount"] != null)
            {
                dgvHistory.Columns["Amount"].HeaderText = "Số tiền";
                dgvHistory.Columns["Amount"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHistory.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                dgvHistory.Columns["Amount"].DefaultCellStyle.ForeColor = Color.FromArgb(16, 185, 129);
                dgvHistory.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
                dgvHistory.Columns["Amount"].FillWeight = 20;
            }
        }

        public void ClearGoalDetails()
        {
            lblGoalTitle.Text = "Chọn mục tiêu";
            lblSavedAmount.Text = "0 đ";
            lblTargetAmount.Text = "0 đ";
            pnlPbValue.Width = 0; // Reset thanh xanh
            flpWalletList.Controls.Clear();
            dgvHistory.DataSource = null;
            lblNoHistory.Visible = true;
        }

        private void ToggleMainContent(bool visible)
        {
            pnlGoalHeader.Visible = visible;
            pnlSaved.Visible = visible;
            pnlTarget.Visible = visible;
            pnlAvailable.Visible = visible;
            pnlHistory.Visible = visible;
        }

        private void ShowEmptyState()
        {
            pnlEmptyState.Visible = true;
            ToggleMainContent(false);
        }

        public void ShowMessage(string message, bool isSuccess)
        {
            MessageBoxIcon icon = isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, icon);
        }

        public void DisplayWalletBalances(IEnumerable<GoalWalletBalanceDTO> wallets) { }

        private void BtnAddGoal_Click(object sender, EventArgs e)
        {
            using (var form = new GoalForm(_presenter, "CurrentUserID"))
            {
                form.ShowDialog();
            }
        }

        private void BtnNaptien_Click(object sender, EventArgs e)
        {
            var goalId = _presenter.GetSelectedGoalId();
            if (!goalId.HasValue) return;

            using (var form = new GoalTransactionForm(_presenter, "CurrentUserID", goalId.Value))
            {
                form.ShowDialog();
            }
        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var goalId = _presenter.GetSelectedGoalId();
            if (goalId.HasValue)
            {
                DialogResult result = MessageBox.Show(
                    "Bạn có chắc chắn muốn xóa mục tiêu này? Mọi lịch sử giao dịch liên quan sẽ bị xóa.",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    _presenter.DeleteGoalAsync(goalId.Value);
                }
            }
        }

        private void flpGoals_Paint(object sender, PaintEventArgs e) { }
        private void pnlTarget_Paint(object sender, PaintEventArgs e) { }
        private void pnlEmptyState_Paint(object sender, PaintEventArgs e) { }
    }
}