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
        private Color barColor = Color.FromArgb(51, 51, 255); // Màu xanh cho progress bar ví
        private Panel _activeGoalPanel = null;
        private int? _activeGoalId = null;

        // Màu sắc cho trạng thái Active/Inactive
        private Color activeBgColor = Color.FromArgb(51, 51, 255); // Xanh dương (giống Wallet Active)
        private Color activeTextColor = Color.White;

        private Color inactiveBgColor = Color.White;
        private Color inactiveTitleColor = Color.FromArgb(44, 62, 80); // Đen xám
        private Color inactiveSubColor = Color.Gray;

        private decimal _currentGoalTotalAmount = 0;
        public UC_Goals(GoalsPresenter presenter)
        {
            InitializeComponent();
            _presenter = presenter;
            _presenter.SetView(this);

            InitializeEvents();
            ClearGoalDetails();

            // Style cho GridView (Đồng bộ với Wallet)
            SetupGridView();

            // Gọi load dữ liệu
            this.Load += async (s, e) => await _presenter.LoadUserGoalsAsync();
        }

        private void SetupGridView()
        {
            // 1. Cấu hình cơ bản & TẮT THANH CUỘN
            dgvHistory.ScrollBars = ScrollBars.None; // <--- QUAN TRỌNG: Tắt hoàn toàn
            dgvHistory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistory.BackgroundColor = Color.White;
            dgvHistory.BorderStyle = BorderStyle.None;

            // Kẻ ngang đơn giản
            dgvHistory.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvHistory.GridColor = Color.FromArgb(230, 230, 230); // Màu xám nhạt theo yêu cầu

            // 2. Header (Cao 50px)
            dgvHistory.EnableHeadersVisualStyles = false;
            dgvHistory.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvHistory.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvHistory.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(100, 116, 139);
            dgvHistory.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold); // Font 11 Bold
            dgvHistory.ColumnHeadersHeight = 50;

            // 3. Row (Cao 50px)
            dgvHistory.DefaultCellStyle.BackColor = Color.White;
            dgvHistory.DefaultCellStyle.ForeColor = Color.FromArgb(50, 50, 50);
            dgvHistory.DefaultCellStyle.Font = new Font("Segoe UI", 11); // Font 11 thường
            dgvHistory.DefaultCellStyle.SelectionBackColor = Color.FromArgb(240, 245, 255);
            dgvHistory.DefaultCellStyle.SelectionForeColor = Color.Black;

            dgvHistory.RowHeadersVisible = false;
            dgvHistory.RowTemplate.Height = 50;
            dgvHistory.AllowUserToResizeRows = false;
        }

        private void InitializeEvents()
        {
            btnAddGoal.Click += BtnAddGoal_Click;
            btnNaptien.Click += BtnNaptien_Click;
            btnRuttien.Click += BtnRuttien_Click;
            btnXoa.Click += BtnXoa_Click;
        }

        // --- CÁC HÀM IGoalsView ---

        public void DisplayGoalsList(IEnumerable<GoalDTO> goals)
        {
            // 1. Xóa sạch các control cũ trong danh sách
            flpGoals.Controls.Clear();

            // 2. Kiểm tra nếu danh sách rỗng
            if (goals == null || !goals.Any())
            {
                ShowEmptyState(); // Hiển thị màn hình trống (trong đó đã có nút thêm to)
                return;
            }

            // Nếu có dữ liệu thì ẩn màn hình trống đi
            pnlEmptyState.Visible = false;

            // Lấy ID đang chọn (nếu có)
            var currentSelectedId = _presenter.GetSelectedGoalId();

            // 3. Vòng lặp tạo thẻ Goal (Card)
            foreach (var goal in goals)
            {
                // Tạo Card
                var card = CreateGoalCard(goal);
                flpGoals.Controls.Add(card);

                // Xử lý Logic Active (Tô màu xanh cho thẻ đang chọn)
                if (currentSelectedId.HasValue && goal.GoalId == currentSelectedId.Value)
                {
                    SetCardActive(card, true);
                    _activeGoalPanel = card;
                }
                // Nếu chưa chọn ai thì mặc định chọn thẻ đầu tiên
                else if (!currentSelectedId.HasValue && goal == goals.First())
                {
                    SetCardActive(card, true);
                    _activeGoalPanel = card;
                    _presenter.LoadGoalDetailsAsync(goal.GoalId);
                }
            }

            // 4. --- QUAN TRỌNG: THÊM NÚT ADD VÀO CUỐI CÙNG ---
            // Sau khi add hết goal, ta add nút thêm vào đít danh sách
            var btnAdd = CreateAddButton();
            flpGoals.Controls.Add(btnAdd);
        }

        // --- HÀM TẠO CARD GOAL
        private Panel CreateGoalCard(GoalDTO goal)
        {
            Panel pnl = new Panel();
            // TĂNG KÍCH THƯỚC: Rộng 330 (giữ nguyên để vừa sidebar), Cao 140 (To hơn)
            pnl.Size = new Size(420, 140);
            pnl.Margin = new Padding(0, 0, 0, 15);
            pnl.Cursor = Cursors.Hand;
            pnl.Tag = goal.GoalId;
            pnl.BackColor = inactiveBgColor;

            // 1. Icon: Tăng font to hơn nữa
            Label lblIcon = new Label();
            lblIcon.Text = "🎯";
            lblIcon.Font = new Font("Segoe UI", 28); // Font 28
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(15, 40); // Căn giữa theo chiều dọc mới
            lblIcon.BackColor = Color.Transparent;

            // 2. Tên Mục Tiêu: Font to và đậm
            Label lblName = new Label();
            lblName.Text = goal.GoalName;
            lblName.Font = new Font("Segoe UI", 14, FontStyle.Bold); // Font 14 Bold
            lblName.ForeColor = inactiveTitleColor;
            // Dịch sang phải (X=85) để không bị icon che mất chữ
            lblName.Location = new Point(140, 35);
            lblName.AutoSize = true;
            lblName.BackColor = Color.Transparent;

            // 3. Số tiền / Tiến độ: Font to hơn
            Label lblAmount = new Label();
            lblAmount.Text = $"{goal.CurrentAmount:N0}đ / {goal.TargetAmount:N0}đ";
            lblAmount.Font = new Font("Segoe UI", 8, FontStyle.Regular); // Font 11
            lblAmount.ForeColor = inactiveSubColor;
            lblAmount.Location = new Point(140, 70); // Dịch xuống dưới tên
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.Transparent;

            // Sự kiện Click (Giữ nguyên)
            EventHandler clickEvent = (s, e) =>
            {
                if (_activeGoalPanel != pnl)
                {
                    if (_activeGoalPanel != null) SetCardActive(_activeGoalPanel, false);
                    SetCardActive(pnl, true);
                    _activeGoalPanel = pnl;
                    _presenter.LoadGoalDetailsAsync(goal.GoalId);
                }
            };

            pnl.Click += clickEvent;
            lblIcon.Click += clickEvent;
            lblName.Click += clickEvent;
            lblAmount.Click += clickEvent;

            pnl.Controls.Add(lblIcon);
            pnl.Controls.Add(lblName);
            pnl.Controls.Add(lblAmount);

            return pnl;
        }

        // --- HÀM ĐỔI MÀU CARD (ACTIVE/INACTIVE) ---
        private void SetCardActive(Panel pnl, bool isActive)
        {
            if (pnl == null) return;

            // Tìm các label con để đổi màu chữ
            Label lblName = pnl.Controls[1] as Label;   // Index 1 là Name (theo thứ tự add ở trên)
            Label lblAmount = pnl.Controls[2] as Label; // Index 2 là Amount

            if (isActive)
            {
                pnl.BackColor = activeBgColor;
                if (lblName != null) lblName.ForeColor = activeTextColor;
                if (lblAmount != null) lblAmount.ForeColor = Color.FromArgb(230, 230, 230); // Trắng hơi xám
            }
            else
            {
                pnl.BackColor = inactiveBgColor;
                if (lblName != null) lblName.ForeColor = inactiveTitleColor;
                if (lblAmount != null) lblAmount.ForeColor = inactiveSubColor;
            }
        }

        public void DisplayGoalDetails(GoalDTO goal)
        {
            if (goal == null) return;

            // Lưu lại tổng tiền hiện có để lát nữa tính % đóng góp
            _currentGoalTotalAmount = goal.CurrentAmount;

            lblGoalTitle.Text = goal.GoalName;
            lblSavedAmount.Text = $"{goal.CurrentAmount:N0} đ";
            lblTargetAmount.Text = $"{goal.TargetAmount:N0} đ";

            // Logic Progress Bar chính (giữ nguyên)
            if (goal.TargetAmount > 0)
            {
                int percent = (int)((goal.CurrentAmount / goal.TargetAmount) * 100);
                if (percent > 100) percent = 100;
                pbSaved.Value = percent;
            }
            else
            {
                pbSaved.Value = 0;
            }

            // Logic nút bấm (giữ nguyên)
            bool isCompleted = goal.Status == "Completed" || goal.Status == "Đã hoàn thành";
            btnNaptien.Enabled = !isCompleted;
            btnRuttien.Enabled = !isCompleted && goal.CurrentAmount > 0;
        }
        private Button CreateAddButton()
        {
            Button btn = new Button();
            // Kích thước đồng bộ với Card: Rộng 330, Cao 70 (nhỏ hơn card xíu cho tinh tế)
            btn.Size = new Size(420, 70);
            btn.Margin = new Padding(0, 10, 0, 20);

            btn.Text = "⊕  Thêm mục tiêu mới";
            btn.Font = new Font("Segoe UI", 12, FontStyle.Bold); // Font 12
            btn.ForeColor = Color.FromArgb(30, 41, 59);
            btn.BackColor = Color.White;

            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btn.FlatAppearance.BorderSize = 2; // Viền dày hơn chút cho rõ
            btn.Cursor = Cursors.Hand;

            btn.Click += BtnAddGoal_Click;

            return btn;
        }
        // --- HÀM TẠO GIAO DIỆN DANH SÁCH VÍ (AVAILABLE BY WALLET) ---
        public void DisplayWalletBalances(IEnumerable<GoalWalletBalanceDTO> wallets)
        {
            flpWalletList.Controls.Clear();

            if (wallets == null) return;

            foreach (var wallet in wallets)
            {
                var itemPanel = CreateWalletItem(wallet);
                flpWalletList.Controls.Add(itemPanel);
            }
        }

        private Panel CreateWalletItem(GoalWalletBalanceDTO wallet)
        {
            // 1. Tính toán chiều rộng động (Lấy chiều rộng khung chứa trừ đi 25px cho thanh cuộn)
            int itemWidth = flpWalletList.ClientSize.Width - 25;

            // 2. Panel chứa (Container)
            Panel pnlItem = new Panel();
            pnlItem.Size = new Size(itemWidth, 80); // Dùng width động
            pnlItem.Margin = new Padding(0, 0, 0, 15);
            pnlItem.BackColor = Color.Transparent;

            // 3. Icon ví (Giữ nguyên)
            Label lblIcon = new Label();
            lblIcon.Text = "🏦";
            if (wallet.WalletName.ToLower().Contains("momo")) lblIcon.Text = "📱";
            if (wallet.WalletName.ToLower().Contains("tiền mặt")) lblIcon.Text = "💵";
            lblIcon.Font = new Font("Segoe UI", 16);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(10, 10);

            // 4. Tên ví (Giữ nguyên)
            Label lblName = new Label();
            lblName.Text = wallet.WalletName;
            lblName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.AutoSize = true;
            lblName.Location = new Point(60, 15);

            // 5. Số tiền (CĂN CHỈNH LẠI VỊ TRÍ DỰA THEO WIDTH MỚI)
            Label lblAmount = new Label();
            lblAmount.Text = $"{wallet.Balance:N0} đ";
            lblAmount.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAmount.ForeColor = Color.Black;
            lblAmount.AutoSize = false;
            lblAmount.TextAlign = ContentAlignment.MiddleRight;
            lblAmount.Size = new Size(300, 30);

            // Đẩy label số tiền sát sang bên phải
            lblAmount.Location = new Point(itemWidth - 310, 15);

            // 6. Custom Progress Bar (CĂN CHỈNH LẠI WIDTH)
            Panel pnlBarBackground = new Panel();
            pnlBarBackground.Size = new Size(itemWidth - 20, 6); // Width động theo panel cha
            pnlBarBackground.Location = new Point(10, 55);
            pnlBarBackground.BackColor = Color.FromArgb(226, 232, 240);

            Panel pnlBarValue = new Panel();
            pnlBarValue.Height = 6;
            pnlBarValue.BackColor = barColor;
            pnlBarValue.Location = new Point(0, 0);
            pnlBarValue.Width = pnlBarBackground.Width; // Full thanh

            pnlBarBackground.Controls.Add(pnlBarValue);

            // Add controls vào Panel Item
            pnlItem.Controls.Add(lblIcon);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblAmount);
            pnlItem.Controls.Add(pnlBarBackground);

            return pnlItem;
        }

        public void DisplayHistory(IEnumerable<GoalDepositHistoryDTO> history)
        {
            dgvHistory.DataSource = null;
            dgvHistory.Rows.Clear();

            // --- SET CỨNG VỊ TRÍ VÀ KÍCH THƯỚC ---
            dgvHistory.Location = new Point(38, 90);  // Padding trái 38 (đồng bộ Header), Top 90
            dgvHistory.Size = new Size(1374, 404);    // Width 1374 (Full), Height 404
            dgvHistory.ScrollBars = ScrollBars.None;  // Đảm bảo tắt cuộn lần nữa
                                                      // --------------------------------------

            if (history == null || !history.Any())
            {
                lblNoHistory.Visible = true;
                dgvHistory.Visible = false;
            }
            else
            {
                lblNoHistory.Visible = false;
                dgvHistory.Visible = true;

                dgvHistory.AutoGenerateColumns = true;
                // Chuyển sang List và chỉ lấy số lượng vừa đủ hiển thị nếu cần (ví dụ Top 7)
                // để đảm bảo không bị tràn nếu tắt scrollbar
                dgvHistory.DataSource = history.Take(7).ToList();

                try
                {
                    if (dgvHistory.Columns["DepositDate"] != null)
                    {
                        dgvHistory.Columns["DepositDate"].HeaderText = "Ngày giao dịch";
                        dgvHistory.Columns["DepositDate"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    }
                    if (dgvHistory.Columns["WalletName"] != null) dgvHistory.Columns["WalletName"].HeaderText = "Ví nguồn";
                    if (dgvHistory.Columns["Note"] != null) dgvHistory.Columns["Note"].HeaderText = "Nội dung";

                    if (dgvHistory.Columns["Amount"] != null)
                    {
                        dgvHistory.Columns["Amount"].HeaderText = "Số tiền";
                        dgvHistory.Columns["Amount"].DefaultCellStyle.Format = "+N0 đ";
                        dgvHistory.Columns["Amount"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                        dgvHistory.Columns["Amount"].DefaultCellStyle.ForeColor = Color.FromArgb(16, 185, 129);
                        dgvHistory.Columns["Amount"].DefaultCellStyle.Font = new Font("Segoe UI", 11, FontStyle.Bold);
                    }
                    if (dgvHistory.Columns["DepositId"] != null) dgvHistory.Columns["DepositId"].Visible = false;
                }
                catch { }
            }
        }

        public void ShowMessage(string message, bool isSuccess)
        {
            MessageBoxIcon icon = isSuccess ? MessageBoxIcon.Information : MessageBoxIcon.Warning;
            MessageBox.Show(message, "Thông báo", MessageBoxButtons.OK, icon);
        }

        public void ClearGoalDetails()
        {
            lblGoalTitle.Text = "Chọn mục tiêu";
            lblSavedAmount.Text = "0 đ";
            lblTargetAmount.Text = "0 đ";
            pbSaved.Value = 0;
            flpWalletList.Controls.Clear();
            dgvHistory.DataSource = null;
        }

        private void ShowEmptyState()
        {
            pnlEmptyState.Visible = true;
            // Ẩn các panel khác
            pnlGoalHeader.Visible = false;
            pnlSaved.Visible = false;
            pnlTarget.Visible = false;
            pnlAvailable.Visible = false;
            pnlHistory.Visible = false;
        }

        // --- Hàm tạo Button Goal bên trái Sidebar ---
        private Button CreateGoalButton(GoalDTO goal)
        {
            Button btn = new Button();
            btn.Text = goal.GoalName;
            btn.Size = new Size(330, 60);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.White;
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Font = new Font("Segoe UI", 10);
            btn.Cursor = Cursors.Hand;
            btn.Margin = new Padding(0, 0, 0, 10);

            // Click thì load chi tiết
            btn.Click += (s, e) => _presenter.LoadGoalDetailsAsync(goal.GoalId);

            return btn;
        }

        // --- Các sự kiện Click ---
        private void BtnAddGoal_Click(object sender, EventArgs e)
        {
            using (var form = new GoalForm(_presenter, "CurrentUserID")) // UserID lấy từ presenter/session
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    // Reload handled by presenter in form
                }
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

        // Rút tiền & Xóa (Logic tương tự)...
        private void BtnRuttien_Click(object sender, EventArgs e) { /* TODO */ }
        private void BtnXoa_Click(object sender, EventArgs e)
        {
            var goalId = _presenter.GetSelectedGoalId();
            if (goalId.HasValue && MessageBox.Show("Bạn chắc chắn xóa?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _presenter.DeleteGoalAsync(goalId.Value);
            }
        }

        // 1. Hàm hiển thị danh sách (Thêm các lệnh reset)
        public void DisplayWalletContributions(IEnumerable<GoalContributionDTO> contributions)
        {
            // Tạm dừng vẽ để tăng tốc và tránh lỗi nháy
            this.SuspendLayout();

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
                lblEmpty.Text = "Chưa có dữ liệu đóng góp.";
                lblEmpty.AutoSize = true;
                lblEmpty.ForeColor = Color.Gray;
                lblEmpty.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                lblEmpty.Margin = new Padding(10);
                flpWalletList.Controls.Add(lblEmpty);
            }

            // Bật lại vẽ
            this.ResumeLayout();
            this.PerformLayout();
        }

        // 2. Hàm tạo Item (Sửa lại Width chuẩn)
        private Panel CreateContributionItem(GoalContributionDTO contribution)
        {
            // 1. SET CỨNG KÍCH THƯỚC THEO YÊU CẦU
            int itemWidth = pnlAvailable.Width - 20;
            if (itemWidth <= 0) itemWidth = 1380;
            int itemHeight = 80;  // Gọn gàng hơn

            Panel pnlItem = new Panel();
            pnlItem.Size = new Size(itemWidth, itemHeight);
            pnlItem.Margin = new Padding(0, 0, 0, 15); // Cách dưới 15px
            pnlItem.BackColor = Color.Transparent;

            // --- Icon (Emoji đơn giản, X=0) ---
            Label lblIcon = new Label();
            lblIcon.Text = "💰";
            if (contribution.WalletName.ToLower().Contains("momo")) lblIcon.Text = "📱";
            else if (contribution.WalletName.ToLower().Contains("tiền mặt")) lblIcon.Text = "💵";
            else if (contribution.WalletName.ToLower().Contains("bank")) lblIcon.Text = "🏦";

            lblIcon.Font = new Font("Segoe UI", 20);
            lblIcon.AutoSize = true;
            lblIcon.Location = new Point(0, 10); // Sát lề trái

            // --- Tên Ví (X=50) ---
            Label lblName = new Label();
            lblName.Text = contribution.WalletName;
            lblName.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblName.ForeColor = Color.FromArgb(44, 62, 80);
            lblName.AutoSize = true;
            lblName.Location = new Point(50, 15);

            // --- Số tiền (Căn phải, X = itemWidth - 250) ---
            Label lblAmount = new Label();
            lblAmount.Text = $"{contribution.ContributedAmount:N0} đ";
            lblAmount.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            lblAmount.ForeColor = Color.Black;
            lblAmount.AutoSize = false;
            lblAmount.TextAlign = ContentAlignment.MiddleRight;
            lblAmount.Size = new Size(250, 30);
            lblAmount.Location = new Point(itemWidth - 250, 15);

            // --- Tính % ---
            int percent = 0;
            if (_currentGoalTotalAmount > 0)
                percent = (int)((contribution.ContributedAmount / _currentGoalTotalAmount) * 100);
            if (percent > 100) percent = 100;

            // --- Progress Bar Background (Xám) ---
            // Yêu cầu: Bắt đầu từ X=50, Width=1300
            Panel pnlBarBackground = new Panel();
            pnlBarBackground.Size = new Size(1300, 6); // Width = 1350 - 50
            pnlBarBackground.Location = new Point(50, 60); // Nằm dưới tên ví
            pnlBarBackground.BackColor = Color.FromArgb(230, 230, 230); // Xám nhạt

            // --- Progress Bar Value (Xanh) ---
            Panel pnlBarValue = new Panel();
            pnlBarValue.Height = 6;
            pnlBarValue.BackColor = Color.FromArgb(51, 51, 255); // Màu xanh
            pnlBarValue.Location = new Point(0, 0);

            // Tính chiều dài thanh màu
            int barWidth = (int)((float)percent / 100 * pnlBarBackground.Width);
            pnlBarValue.Width = barWidth > 0 ? barWidth : 0;

            pnlBarBackground.Controls.Add(pnlBarValue);

            // Add controls (ĐÃ BỎ LABEL %)
            pnlItem.Controls.Add(lblIcon);
            pnlItem.Controls.Add(lblName);
            pnlItem.Controls.Add(lblAmount);
            pnlItem.Controls.Add(pnlBarBackground);

            return pnlItem;
        }

        private void flpGoals_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlTarget_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pnlEmptyState_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}