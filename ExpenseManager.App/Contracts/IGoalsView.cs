using ExpenseManager.App.Contracts.ViewModels;
using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Contracts
{
    // Đây là hợp đồng giao tiếp giữa UC_Goals (View) và GoalPresenter (Presenter)
    public interface IGoalsView
    {
        // EVENT: Báo hiệu cho Presenter rằng View đã sẵn sàng để tải dữ liệu.
        event EventHandler LoadData;

        // METHOD: Presenter gọi để yêu cầu View hiển thị dữ liệu tổng thể.
        void DisplayPageData(GoalsPageViewModel viewModel);

        // METHOD: Presenter gọi để thông báo cho View hiển thị trạng thái rỗng.
        void ShowEmptyState();

        // METHOD: Presenter gọi để thông báo lỗi cho người dùng.
        void ShowError(string message);

    }
}