using ExpenseManager.App.Contracts;
using ExpenseManager.App.Services;
using ExpenseManager.App.Views; // (Hoặc Views.Interfaces)
using System;
using System.Threading.Tasks;
// using ExpenseManager.App.Contracts; // (Nếu bạn đã dọn dẹp)

namespace ExpenseManager.App.Presenters
{
    public class AddGoalPresenter
    {
        private readonly IAddGoalView _view;
        private readonly IGoalService _goalService;
        private bool _isSaving = false; // Đổi tên: _isBusy
        private bool _isDeleting = false;

        public AddGoalPresenter(IAddGoalView view, IGoalService goalService)
        {
            _view = view;
            _goalService = goalService;

            // Đăng ký nghe sự kiện "Save" từ View
            _view.SaveClicked += OnSaveClicked;

            // Đăng ký nghe sự kiện khi Form được tải (Load)
            _view.LoadView += OnLoadView;

            // *** ĐĂNG KÝ SỰ KIỆN MỚI (Cho chức năng Xóa) ***
            _view.DeleteClicked += OnDeleteClicked;
        }

        // Xử lý sự kiện Load (Cập nhật để hiển thị nút Xóa)
        private async void OnLoadView(object sender, EventArgs e)
        {
            int? goalId = _view.GoalIdToEdit;

            if (goalId != null)
            {
                // --- CHẾ ĐỘ EDIT ---
                try
                {
                    var viewModel = await _goalService.GetGoalViewModelByIdAsync(goalId.Value);

                    _view.GoalName = viewModel.Name;
                    _view.TargetAmount = viewModel.TargetAmount;
                    _view.CompletionDate = viewModel.DueDate;

                    _view.SetEditMode(viewModel.Name);

                    // *** RA LỆNH MỚI (Cho chức năng Xóa) ***
                    // Yêu cầu View hiển thị nút Xóa
                    _view.ShowDeleteButton();
                }
                catch (Exception ex)
                {
                    _view.ShowError($"Failed to load goal for editing: {ex.Message}");
                    _view.CloseDialog(false);
                }
            }
        }

        // Khi người dùng nhấn nút Save (Giữ nguyên)
        private async void OnSaveClicked(object sender, EventArgs e)
        {
            if (_isSaving || _isDeleting) return;

            // 1. Validation (Kiểm tra dữ liệu)
            if (string.IsNullOrWhiteSpace(_view.GoalName))
            {
                _view.ShowError("Goal Name cannot be empty.");
                return;
            }
            if (_view.TargetAmount <= 0)
            {
                _view.ShowError("Target Amount must be greater than zero.");
                return;
            }
            if (_view.GoalIdToEdit == null && _view.CompletionDate.Date < DateTime.Today)
            {
                _view.ShowError("Completion Date cannot be in the past.");
                return;
            }

            _isSaving = true;
            try
            {
                int? goalId = _view.GoalIdToEdit;

                if (goalId == null)
                {
                    // --- CHẾ ĐỘ CREATE (TẠO) ---
                    await _goalService.CreateGoalAsync(
                        _view.GoalName,
                        _view.TargetAmount,
                        _view.CompletionDate
                    );
                }
                else
                {
                    // --- CHẾ ĐỘ UPDATE (SỬA) ---
                    await _goalService.UpdateGoalAsync(
                        goalId.Value,
                        _view.GoalName,
                        _view.TargetAmount,
                        _view.CompletionDate
                    );
                }

                _view.CloseDialog(true);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Failed to save goal: {ex.Message}");
            }
            finally
            {
                _isSaving = false;
            }
        }

        // *** HÀM MỚI (Xử lý sự kiện Xóa) ***
        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            if (_isSaving || _isDeleting) return;

            try
            {
                // 1. Lấy ID và Tên (Tên chỉ để hiển thị)
                int? goalId = _view.GoalIdToEdit;
                string goalName = _view.GoalName;

                if (goalId == null)
                {
                    // Không thể xóa Goal chưa được tạo
                    return;
                }

                // 2. Yêu cầu View hiển thị hộp thoại "Bạn có chắc?"
                bool confirmed = _view.ConfirmDelete(goalName);
                if (!confirmed)
                {
                    return; // Người dùng nhấn "No"
                }

                _isDeleting = true;

                // 3. Gọi Service (File 6/13) để xóa
                await _goalService.DeleteGoalAsync(goalId.Value);

                // 4. Đóng Form (giống như Save thành công)
                _view.CloseDialog(true);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Failed to delete goal: {ex.Message}");
            }
            finally
            {
                _isDeleting = false;
            }
        }
    }
}