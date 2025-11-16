using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Contracts.ViewModels
{
    /// <summary>
    /// DTO "cha" chứa tất cả dữ liệu cho UC_Goals
    /// </summary>
    public class GoalsPageViewModel
    {
        public List<GoalViewModel> GoalsList { get; set; }
        public GoalSummaryModel Summary { get; set; }

        public GoalsPageViewModel()
        {
            GoalsList = new List<GoalViewModel>();
            Summary = new GoalSummaryModel();
        }
    }

    /// <summary>
    /// DTO chứa các thông tin tóm tắt chung về mục tiêu
    /// </summary>
    public class GoalSummaryModel
    {
        public int Total { get; set; }
        public int NotStarted { get; set; }
        public int InProgress { get; set; }
        public int Finished { get; set; }
        public int Canceled { get; set; }
    }

    /// <summary>
    /// DTO đại diện cho một mục tiêu đơn lẻ, bao gồm các thuộc tính đã tính toán
    /// </summary>
    public class GoalViewModel
    {
        public int GoalId { get; set; }
        public string Name { get; set; }
        public decimal TargetAmount { get; set; }
        public decimal CurrentAmount { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }

        // Thuộc tính đã tính toán (Presentation Logic) vẫn giữ ở đây vì
        // đây là nơi View Model được thiết kế để chứa các logic trình bày đơn giản này.
        public int ProgressPercent => (TargetAmount == 0) ? 0 : (int)((CurrentAmount / TargetAmount) * 100);
        public int DaysLeft => (DueDate - DateTime.Today).Days;
    }
}