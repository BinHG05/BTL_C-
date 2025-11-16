using ExpenseManager.App.Contracts.ViewModels;
using System;
using System.Threading.Tasks;

// Namespace của bạn
namespace ExpenseManager.App.Services
{
    public interface IGoalService
    {
        // Hàm đã có (để tải UC_Goals)
        Task<GoalsPageViewModel> GetGoalsPageDataAsync(string userId);

        // Hàm đã có (để tạo Goal mới)
        Task CreateGoalAsync(string name, decimal targetAmount, DateTime targetDate);

        // Hàm đã có (để lấy 1 Goal cho chế độ Edit)
        Task<GoalViewModel> GetGoalViewModelByIdAsync(int goalId);

        // Hàm đã có (để sửa 1 Goal)
        Task UpdateGoalAsync(int goalId, string name, decimal targetAmount, DateTime targetDate);

        // --- HÀM MỚI (Cho chức năng Xóa) ---
        // Xóa một Goal (và các Deposits liên quan)
        Task DeleteGoalAsync(int goalId);
    }
}