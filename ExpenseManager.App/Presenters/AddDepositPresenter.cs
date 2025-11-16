using ExpenseManager.App.Contracts; // (Hoặc Views/Interfaces)
using ExpenseManager.App.Services;
using System;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    // Presenter MỚI cho Form Nạp tiền (Đã cập nhật)
    public class AddDepositPresenter
    {
        private readonly IAddDepositView _view;
        private readonly IGoalService _goalService; // Cần để LẤY TÊN Goal
        private readonly IWalletService _walletService; // Cần để LẤY DANH SÁCH VÍ
        private readonly IGoalDepositService _depositService; // Cần để NẠP TIỀN
        private bool _isBusy = false;

        // Tiêm (Inject) cả 3 Service
        public AddDepositPresenter(
            IAddDepositView view,
            IGoalService goalService,
            IWalletService walletService,
            IGoalDepositService depositService)
        {
            _view = view;
            _goalService = goalService;
            _walletService = walletService;
            _depositService = depositService;

            // Đăng ký nghe sự kiện
            _view.LoadView += OnLoadView;
            _view.SaveDepositClicked += OnSaveDepositClicked;
        }

        // Khi Form Pop-up được tải (Load)
        private async void OnLoadView(object sender, EventArgs e)
        {
            try
            {
                // 1. Lấy ID của Goal (cha) từ View
                int goalId = _view.GoalId;

                // 2. *** ĐÃ SỬA LỖI ĐA LUỒNG ***
                // Chạy tuần tự (sequentially), KHÔNG chạy song song

                // (Chạy và đợi)
                var goalViewModel = await _goalService.GetGoalViewModelByIdAsync(goalId);

                // (Chạy và đợi)
                var wallets = await _walletService.GetWalletsForCurrentUserAsync();

                // (Xóa code Task.WhenAll cũ)

                // 3. Kiểm tra (Validation)
                if (goalViewModel == null)
                {
                    _view.ShowError("Không thể tải thông tin mục tiêu.");
                    _view.CloseDialog(false);
                    return;
                }

                if (wallets == null || wallets.Count == 0)
                {
                    _view.ShowError("Không tìm thấy ví nào. Vui lòng tạo một ví trước khi nạp tiền.");
                    _view.CloseDialog(false); // Đóng form vì không thể nạp tiền
                    return;
                }

                // 4. Ra lệnh cho View hiển thị tên Goal
                _view.SetGoalDetails(
                    goalViewModel.Name,
                    goalViewModel.CurrentAmount,
                    goalViewModel.TargetAmount
                );

                // 5. Ra lệnh cho View hiển thị danh sách Ví (Wallets)
                _view.SetWallets(wallets);
            }
            catch (Exception ex)
            {
                _view.ShowError(ex.Message);
            }
        }

        // Khi người dùng nhấn nút "Lưu" (Nạp tiền)
        private async void OnSaveDepositClicked(object sender, EventArgs e)
        {
            if (_isBusy) return;

            // 1. Lấy dữ liệu
            decimal amount = _view.Amount;
            int goalId = _view.GoalId;
            int walletId = _view.SelectedWalletId; // Lấy ID Ví đã chọn

            // 2. Validation (Kiểm tra)
            if (walletId <= 0)
            {
                _view.ShowError("Vui lòng chọn một ví để nạp tiền."); // Đã dịch
                return;
            }
            if (amount <= 0)
            {
                _view.ShowError("Số tiền nạp phải lớn hơn 0."); // Đã dịch
                return;
            }

            _isBusy = true;
            try
            {
                // 3. Gọi DepositService (File 6/10)
                await _depositService.AddDepositAsync(goalId, walletId, amount);

                // 4. Báo thành công và đóng Form
                _view.CloseDialog(true);
            }
            catch (Exception ex)
            {
                // Báo lỗi (ví dụ: "Mục tiêu đã hoàn thành", hoặc lỗi CSDL)
                _view.ShowError(ex.Message);
            }
            finally
            {
                _isBusy = false;
            }
        }
    }
}