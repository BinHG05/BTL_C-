using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User.UC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Presenters
{
    public class GoalsPresenter
    {
        private  IGoalsView _view;
        private readonly IGoalService _goalService;
        private string _currentUserId;
        private int? _selectedGoalId;

        public GoalsPresenter(IGoalService goalService)
        {
  
            _goalService = goalService;
        }
        public void SetView(IGoalsView view)
        {
            _view = view;
        }
        public void SetUserId(string userId)
        {
            _currentUserId = userId;
        }

        public async Task LoadUserGoalsAsync()
        {
            try
            {
                var goals = await _goalService.GetUserGoalsAsync(_currentUserId);
                _view.DisplayGoalsList(goals);
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải danh sách mục tiêu: {ex.Message}", false);
            }
        }

        public async Task LoadGoalDetailsAsync(int goalId)
        {
            try
            {
                _selectedGoalId = goalId;

                // 1. Load thông tin cơ bản
                var goal = await _goalService.GetGoalDetailsAsync(goalId);

                if (goal != null)
                {
                    _view.DisplayGoalDetails(goal);

                    // 2. Load lịch sử nạp tiền
                    var history = await _goalService.GetGoalHistoryAsync(goalId);
                    _view.DisplayHistory(history);

                    // Gọi hàm Service vừa viết để lấy dữ liệu
                    var contributions = await _goalService.GetWalletContributionsAsync(goalId);

                    // Gọi hàm View để hiển thị lên giao diện
                    _view.DisplayWalletContributions(contributions);
                }
                else
                {
                    _view.ShowMessage("Không tìm thấy mục tiêu", false);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi tải chi tiết mục tiêu: {ex.Message}", false);
            }
        }


        public async Task CreateGoalAsync(string goalName, decimal targetAmount, DateTime? completionDate)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(goalName))
                {
                    _view.ShowMessage("Vui lòng nhập tên mục tiêu", false);
                    return;
                }

                if (targetAmount <= 0)
                {
                    _view.ShowMessage("Số tiền mục tiêu phải lớn hơn 0", false);
                    return;
                }

                var createDto = new CreateGoalDTO
                {
                    UserId = _currentUserId,
                    GoalName = goalName,
                    TargetAmount = targetAmount,
                    CompletionDate = completionDate 
                };

                var createdGoal = await _goalService.CreateGoalAsync(createDto);
                _view.ShowMessage("Tạo mục tiêu thành công!", true);
                await LoadUserGoalsAsync();
            }
            catch (Exception ex)
            {
                var innerMessage = ex.InnerException != null ? ex.InnerException.Message : ex.Message;

                _view.ShowMessage($"Lỗi chi tiết: {innerMessage}", false);

                System.Diagnostics.Debug.WriteLine($"FULL ERROR: {ex}");
            }
        }

        public async Task UpdateGoalAsync(int goalId, string goalName, decimal targetAmount, DateTime? completionDate, string status)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(goalName))
                {
                    _view.ShowMessage("Vui lòng nhập tên mục tiêu", false);
                    return;
                }

                if (targetAmount <= 0)
                {
                    _view.ShowMessage("Số tiền mục tiêu phải lớn hơn 0", false);
                    return;
                }

                var updateDto = new UpdateGoalDTO
                {
                    GoalId = goalId,
                    GoalName = goalName,
                    TargetAmount = targetAmount,
                    CompletionDate = completionDate, 
                    Status = status
                };

                var success = await _goalService.UpdateGoalAsync(updateDto);
                if (success)
                {
                    _view.ShowMessage("Cập nhật mục tiêu thành công!", true);
                    await LoadUserGoalsAsync();

                    if (_selectedGoalId == goalId)
                    {
                        await LoadGoalDetailsAsync(goalId);
                    }
                }
                else
                {
                    _view.ShowMessage("Không thể cập nhật mục tiêu", false);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi cập nhật mục tiêu: {ex.Message}", false);
            }
        }

        public async Task DeleteGoalAsync(int goalId)
        {
            try
            {
                var success = await _goalService.DeleteGoalAsync(goalId);
                if (success)
                {
                    _view.ShowMessage("Xóa mục tiêu thành công!", true);
                    _view.ClearGoalDetails();
                    _selectedGoalId = null;
                    await LoadUserGoalsAsync();
                }
                else
                {
                    _view.ShowMessage("Không thể xóa mục tiêu", false);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi xóa mục tiêu: {ex.Message}", false);
            }
        }

        public async Task DepositToGoalAsync(int goalId, int walletId, decimal amount, string note)
        {
            try
            {
                if (amount <= 0)
                {
                    _view.ShowMessage("Số tiền phải lớn hơn 0", false);
                    return;
                }

                var depositDto = new GoalDepositDTO
                {
                    GoalId = goalId,
                    UserId = _currentUserId,
                    WalletId = walletId,
                    Amount = amount,
                    Note = note ?? string.Empty
                };

                var success = await _goalService.DepositToGoalAsync(depositDto);
                if (success)
                {
                    _view.ShowMessage("Nạp tiền thành công!", true);

                    // 1. Load lại chi tiết Mục tiêu (Để cập nhật thanh tiến độ và Lịch sử)
                    await LoadGoalDetailsAsync(goalId);

                    // 2. Load lại danh sách Ví (Để cập nhật số dư mới sau khi trừ tiền)
                    var wallets = await _goalService.GetAvailableWalletsAsync(_currentUserId);
                    _view.DisplayWalletBalances(wallets);

                    // 3. Load lại danh sách Goals bên trái (Để cập nhật số tiền trên thẻ Card)
                    await LoadUserGoalsAsync();
                }
                else
                {
                    _view.ShowMessage("Nạp tiền thất bại.", false);
                }
            }
            catch (Exception ex)
            {
                _view.ShowMessage($"Lỗi nạp tiền: {ex.Message}", false);
            }
        }

        public async Task<IEnumerable<GoalWalletBalanceDTO>> GetAvailableWalletsAsync()
        {
            try
            {
                return await _goalService.GetAvailableWalletsAsync(_currentUserId);
            }
            catch (Exception)
            {
                return new List<GoalWalletBalanceDTO>();
            }
        }

        public int? GetSelectedGoalId()
        {
            return _selectedGoalId;
        }
    }
}