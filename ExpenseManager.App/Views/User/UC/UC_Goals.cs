using ExpenseManager.App.Contracts;
using ExpenseManager.App.Contracts.ViewModels;
using ExpenseManager.App.Models.EF; // Cần cho Program.AppDbContext
using ExpenseManager.App.Presenters;
using ExpenseManager.App.Repositories;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views.User.Forms;
using System;
using System.Collections.Generic;
using System.Globalization; // Cần cho định dạng tiền tệ
using System.Linq;
using System.Windows.Forms;

namespace ExpenseManager.App.Views.Admin.UC
{
    // Kế thừa IGoalsView
    public partial class UC_Goals : UserControl, IGoalsView
    {
        private GoalPresenter _presenter;

        // Biến này sẽ lưu danh sách Goals (và ID)
        private List<GoalViewModel> _currentGoalsList = new List<GoalViewModel>();

        // (Sử dụng Tiếng Việt)
        private readonly CultureInfo _culture = CultureInfo.GetCultureInfo("vi-VN");

        // Triển khai Event
        public event EventHandler LoadData;

        public UC_Goals()
        {
            InitializeComponent();

            // --- GẮN SỰ KIỆN CHO TẤT CẢ CÁC NÚT ---

            // 1. Gắn sự kiện cho nút "+ Add new goal"
            btnAddNewGoal.Click += btnAddNewGoal_Click;

            // 2. Gắn sự kiện cho các nút "Edit" (✎)
            btnGoal1Edit.Click += (s, e) => OnEditGoalClicked(0);
            btnGoal2Edit.Click += (s, e) => OnEditGoalClicked(1);
            btnGoal3Edit.Click += (s, e) => OnEditGoalClicked(2);
            btnGoal4Edit.Click += (s, e) => OnEditGoalClicked(3);

            // 3. *** HÀM MỚI: Gắn sự kiện Click cho Nạp tiền (Deposit) ***
            // (Chúng ta dùng hàm helper 'WirePanelClick' để gắn 
            // sự kiện cho cả Panel và các con của nó)
            WirePanelClick(pnlGoal1, 0);
            WirePanelClick(pnlGoal2, 1);
            WirePanelClick(pnlGoal3, 2);
            WirePanelClick(pnlGoal4, 3);

            // --- Khởi tạo MVP ---
            if (!this.DesignMode)
            {
                var dbContext = Program.AppDbContext;

                // Khởi tạo các Repository cần thiết
                var goalRepo = new GoalRepository(dbContext);
                var depositRepo = new GoalDepositRepository(dbContext);
                var walletRepo = new WalletRepository(dbContext);

                // Khởi tạo các Service cần thiết
                var goalService = new GoalService(goalRepo);
                var depositService = new GoalDepositService(goalRepo, depositRepo);
                var walletService = new WalletService(walletRepo);

                // Presenter của UC_Goals chỉ cần GoalService
                _presenter = new GoalPresenter(this, goalService);

                // (Các Presenter khác sẽ được Form Pop-up tự khởi tạo)
            }
        }

        // Kích hoạt sự kiện LoadData khi UC được tải
        private void UC_Goals_Load(object sender, EventArgs e)
        {
            if (!this.DesignMode)
            {
                // Báo cho Presenter: "Tôi đã sẵn sàng, hãy tải dữ liệu!"
                LoadData?.Invoke(this, EventArgs.Empty);
            }
        }

        // --- HÀM HELPER: Gắn sự kiện Click cho Panel và các con ---
        private void WirePanelClick(Control panel, int index)
        {
            panel.Cursor = Cursors.Hand; // Thêm con trỏ tay
            panel.Click += (s, e) => OnDepositClicked(index);

            foreach (Control child in panel.Controls)
            {
                // TRỪ nút "Edit" (vì nó có sự kiện riêng)
                if (child != btnGoal1Edit && child != btnGoal2Edit && child != btnGoal3Edit && child != btnGoal4Edit)
                {
                    child.Cursor = Cursors.Hand;
                    child.Click += (s, e) => OnDepositClicked(index);

                    if (child is FlowLayoutPanel flowPanel)
                    {
                        foreach (Control flowChild in flowPanel.Controls)
                        {
                            flowChild.Cursor = Cursors.Hand;
                            flowChild.Click += (s, e) => OnDepositClicked(index);
                        }
                    }
                }
            }
        }


        // --- XỬ LÝ CÁC SỰ KIỆN CLICK ---

        // 1. Khi click "+ Add new goal"
        private void btnAddNewGoal_Click(object sender, EventArgs e)
        {
            // Mở Form ở chế độ "Add" (truyền null)
            using (var addGoalForm = new AddGoalForm(null))
            {
                var result = addGoalForm.ShowDialog(this.ParentForm);
                if (result == DialogResult.OK)
                {
                    LoadData?.Invoke(this, EventArgs.Empty); // Tải lại
                }
            }
        }

        // 2. Khi click "Edit" (✎)
        private void OnEditGoalClicked(int index)
        {
            if (_currentGoalsList == null || index >= _currentGoalsList.Count)
            {
                return;
            }
            int goalIdToEdit = _currentGoalsList[index].GoalId;

            // Mở Form ở chế độ "Edit" (truyền ID)
            using (var editGoalForm = new AddGoalForm(goalIdToEdit))
            {
                var result = editGoalForm.ShowDialog(this.ParentForm);
                if (result == DialogResult.OK)
                {
                    LoadData?.Invoke(this, EventArgs.Empty); // Tải lại
                }
            }
        }

        // 3. Khi click vào Card (Nạp tiền)
        private void OnDepositClicked(int index)
        {
            if (_currentGoalsList == null || index >= _currentGoalsList.Count)
            {
                return;
            }

            // Lấy ID của Goal (cha)
            int goalId = _currentGoalsList[index].GoalId;

            // Mở Form Pop-up Nạp tiền (File 10/10)
            using (var depositForm = new AddDepositForm(goalId))
            {
                var result = depositForm.ShowDialog(this.ParentForm);

                // Tải lại (Refresh) nếu nạp tiền thành công
                if (result == DialogResult.OK)
                {
                    LoadData?.Invoke(this, EventArgs.Empty);
                }
            }
        }


        // ---- Triển khai các hàm của IGoalsView ----

        public void DisplayPageData(GoalsPageViewModel viewModel)
        {
            this.Invoke((MethodInvoker)delegate
            {
                if (viewModel == null || viewModel.GoalsList == null || !viewModel.GoalsList.Any())
                {
                    ShowEmptyState();
                    DisplaySummary(viewModel?.Summary ?? new GoalSummaryModel());
                    return;
                }

                DisplayGoals(viewModel.GoalsList);
                DisplaySummary(viewModel.Summary);
            });
        }

        private void DisplayGoals(List<GoalViewModel> goals)
        {
            // Lưu lại danh sách (để lấy ID khi Click)
            _currentGoalsList = goals ?? new List<GoalViewModel>();

            // Ẩn tất cả các panel goal
            pnlGoal1.Visible = false;
            pnlGoal2.Visible = false;
            pnlGoal3.Visible = false;
            pnlGoal4.Visible = false;

            if (goals == null) return;

            lblItemsCount.Text = $"{goals.Count} mục"; // Đã dịch

            // Điền dữ liệu cho Goal 1 (nếu có)
            if (goals.Count > 0)
            {
                var goal1 = goals[0];
                lblGoal1Title.Text = goal1.Name;
                lblGoal1DueDate.Text = $"Ngày đáo hạn — {goal1.DueDate.ToShortDateString()}";
                lblGoal1Amount.Text = goal1.CurrentAmount.ToString("C0", _culture); // C0 = 0 số lẻ (VND)
                lblGoal1Target.Text = $"/ {goal1.TargetAmount.ToString("C0", _culture)}";
                prgGoal1.Value = goal1.ProgressPercent > 100 ? 100 : goal1.ProgressPercent;
                lblGoal1Progress.Text = $"{goal1.ProgressPercent}%";
                lblGoal1Left.Text = goal1.DaysLeft > 0 ? $"{goal1.DaysLeft} ngày còn lại" : "Quá hạn"; // Đã dịch
                pnlGoal1.Visible = true;
            }

            // Điền dữ liệu cho Goal 2 (nếu có)
            if (goals.Count > 1)
            {
                var goal2 = goals[1];
                lblGoal2Title.Text = goal2.Name;
                lblGoal2DueDate.Text = $"Ngày đáo hạn — {goal2.DueDate.ToShortDateString()}";
                lblGoal2Amount.Text = goal2.CurrentAmount.ToString("C0", _culture);
                lblGoal2Target.Text = $"/ {goal2.TargetAmount.ToString("C0", _culture)}";
                prgGoal2.Value = goal2.ProgressPercent > 100 ? 100 : goal2.ProgressPercent;
                lblGoal2Progress.Text = $"{goal2.ProgressPercent}%";
                lblGoal2Left.Text = goal2.DaysLeft > 0 ? $"{goal2.DaysLeft} ngày còn lại" : "Quá hạn"; // Đã dịch
                pnlGoal2.Visible = true;
            }

            // (Tương tự cho Goal 3 và 4)
            if (goals.Count > 2)
            {
                var goal3 = goals[2];
                lblGoal3Title.Text = goal3.Name;
                lblGoal3DueDate.Text = $"Ngày đáo hạn — {goal3.DueDate.ToShortDateString()}";
                lblGoal3Amount.Text = goal3.CurrentAmount.ToString("C0", _culture);
                lblGoal3Target.Text = $"/ {goal3.TargetAmount.ToString("C0", _culture)}";
                prgGoal3.Value = goal3.ProgressPercent > 100 ? 100 : goal3.ProgressPercent;
                lblGoal3Progress.Text = $"{goal3.ProgressPercent}%";
                lblGoal3Left.Text = goal3.DaysLeft > 0 ? $"{goal3.DaysLeft} ngày còn lại" : "Quá hạn"; // Đã dịch
                pnlGoal3.Visible = true;
            }

            if (goals.Count > 3)
            {
                var goal4 = goals[3];
                lblGoal4Title.Text = goal4.Name;
                lblGoal4DueDate.Text = $"Ngày đáo hạn — {goal4.DueDate.ToShortDateString()}";
                lblGoal4Amount.Text = goal4.CurrentAmount.ToString("C0", _culture);
                lblGoal4Target.Text = $"/ {goal4.TargetAmount.ToString("C0", _culture)}";
                prgGoal4.Value = goal4.ProgressPercent > 100 ? 100 : goal4.ProgressPercent;
                lblGoal4Progress.Text = $"{goal4.ProgressPercent}%";
                lblGoal4Left.Text = goal4.DaysLeft > 0 ? $"{goal4.DaysLeft} ngày còn lại" : "Quá hạn"; // Đã dịch
                pnlGoal4.Visible = true;
            }
        }

        private void DisplaySummary(GoalSummaryModel summary)
        {
            if (summary == null) return;

            lblTotalGoalsCount.Text = summary.Total.ToString();
            lblNotStartedCount.Text = summary.NotStarted.ToString();
            lblInProgressCount.Text = summary.InProgress.ToString();
            lblFinishedCount.Text = summary.Finished.ToString();
            lblCanceledCount.Text = summary.Canceled.ToString();
        }

        public void ShowEmptyState()
        {
            this.Invoke((MethodInvoker)delegate
            {
                _currentGoalsList.Clear();
                pnlGoal1.Visible = false;
                pnlGoal2.Visible = false;
                pnlGoal3.Visible = false;
                pnlGoal4.Visible = false;
                lblItemsCount.Text = "0 mục"; // Đã dịch

                // (TODO: Hiển thị Panel "Rỗng" của bạn ở đây)
                // pnlEmptyState.Visible = true; 
            });
        }

        public void ShowError(string message)
        {
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(message, "Lỗi Tải Mục tiêu", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });
        }
    }
}