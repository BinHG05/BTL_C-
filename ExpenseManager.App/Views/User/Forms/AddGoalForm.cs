using ExpenseManager.App.Contracts;
using ExpenseManager.App.Models.EF; // Cần cho Program.AppDbContext
using ExpenseManager.App.Presenters; // Cần cho AddGoalPresenter
using ExpenseManager.App.Repositories; // Cần cho GoalRepository
using ExpenseManager.App.Services; // Cần cho GoalService
using System;
using System.Windows.Forms;
// Thêm namespace Interface (nếu bạn đã dọn dẹp)
// using ExpenseManager.App.Contracts; 

namespace ExpenseManager.App.Views
{
    // Triển khai IAddGoalView MỚI (File 9/13)
    public partial class AddGoalForm : Form, IAddGoalView
    {
        private readonly AddGoalPresenter _presenter;
        private readonly int? _goalIdToEdit;

        public AddGoalForm(int? goalIdToEdit = null)
        {
            InitializeComponent();

            _goalIdToEdit = goalIdToEdit;

            if (!this.DesignMode)
            {
                var dbContext = Program.AppDbContext;
                var goalRepo = new GoalRepository(dbContext);
                var goalService = new GoalService(goalRepo);
                _presenter = new AddGoalPresenter(this, goalService);
            }

            // --- Gắn sự kiện cho các nút ---
            btnSave.Click += (s, e) => SaveClicked?.Invoke(this, EventArgs.Empty);
            btnCancel.Click += (s, e) => CloseDialog(false);

            // *** GẮN SỰ KIỆN MỚI (Cho chức năng Xóa) ***
            btnDelete.Click += (s, e) => DeleteClicked?.Invoke(this, EventArgs.Empty);

            // Gắn sự kiện Load của Form
            this.Load += AddGoalForm_Load;
        }

        // Xử lý sự kiện Load
        private void AddGoalForm_Load(object sender, EventArgs e)
        {
            // Báo cho Presenter: "Tôi đã tải xong, hãy kiểm tra chế độ Edit!"
            LoadView?.Invoke(this, EventArgs.Empty);
        }


        // --- Triển khai Interface IAddGoalView ---

        // Properties (Lấy/Gán dữ liệu)
        public string GoalName
        {
            get => txtGoalName.Text;
            set => txtGoalName.Text = value;
        }

        public decimal TargetAmount
        {
            get => numTargetAmount.Value;
            set => numTargetAmount.Value = value;
        }

        public DateTime CompletionDate
        {
            get => dtpCompletionDate.Value;
            set => dtpCompletionDate.Value = value;
        }

        public int? GoalIdToEdit => _goalIdToEdit;

        // Events (Báo cho Presenter)
        public event EventHandler SaveClicked;
        public event EventHandler LoadView;
        public event EventHandler DeleteClicked; // Event mới

        // Actions (Presenter ra lệnh)
        public void ShowError(string message)
        {
            this.Invoke((MethodInvoker)delegate {
                MessageBox.Show(this, message, "Lỗi Nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            });
        }

        public void CloseDialog(bool success)
        {
            this.Invoke((MethodInvoker)delegate {
                this.DialogResult = success ? DialogResult.OK : DialogResult.Cancel;
                this.Close();
            });
        }

        // (Action này được gọi bởi Presenter (File 10/13) khi ở chế độ Edit)
        public void SetEditMode(string goalName)
        {
            this.Text = $"Chỉnh sửa Mục tiêu: {goalName}";
            this.lblTitle.Text = "Chỉnh sửa Mục tiêu";
            this.btnSave.Text = "Lưu thay đổi";
        }

        // *** ACTION MỚI (Triển khai Interface File 9/13) ***
        public void ShowDeleteButton()
        {
            // (Được gọi bởi Presenter (File 10/13) khi ở chế độ Edit)
            btnDelete.Visible = true;
        }

        // *** ACTION MỚI (Triển khai Interface File 9/13) ***
        public bool ConfirmDelete(string goalName)
        {
            // (Được gọi bởi Presenter (File 10/13) khi nhấn nút Xóa)
            var result = MessageBox.Show(
                this,
                $"Bạn có chắc chắn muốn xóa mục tiêu '{goalName}' không?\n\nHành động này không thể hoàn tác và sẽ xóa tất cả các khoản nạp tiền liên quan.",
                "Xác nhận Xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            return (result == DialogResult.Yes);
        }
    }
}