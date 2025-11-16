using ExpenseManager.App.Services;
using ExpenseManager.App.Session;
using System.Threading.Tasks;
using System;
using ExpenseManager.App.Contracts;
using ExpenseManager.App.Contracts.ViewModels; // <-- SỬ DỤNG NAMESPACE MỚI

namespace ExpenseManager.App.Presenters
{
    public class GoalPresenter
    {
        private readonly IGoalsView _view;
        private readonly IGoalService _goalService;

        public GoalPresenter(IGoalsView view, IGoalService goalService)
        {
            _view = view;
            _goalService = goalService;

            // Đăng ký nghe sự kiện từ View
            _view.LoadData += OnLoadData;

            // Ví dụ: Đăng ký sự kiện khi người dùng click vào nút Thêm mục tiêu
            // _view.AddGoalClicked += OnAddGoalClicked; 
        }

        // private void OnAddGoalClicked(object sender, EventArgs e)
        // {
        //     _view.NavigateToAddGoal();
        // }

        private async void OnLoadData(object sender, EventArgs e)
        {
            try
            {
                string userId = CurrentUserSession.CurrentUser?.UserId;
                if (string.IsNullOrEmpty(userId))
                {
                    _view.ShowError("User session not found. Please log in again.");
                    return;
                }

                // Logic chính (Business Logic) nằm ở đây
                GoalsPageViewModel pageData = await _goalService.GetGoalsPageDataAsync(userId);

                // Ra lệnh cho View hiển thị
                _view.DisplayPageData(pageData);
            }
            catch (Exception ex)
            {
                _view.ShowError($"Failed to load goals: {ex.Message}");
            }
        }
    }
}