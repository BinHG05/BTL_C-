using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public interface IGoalRepository
    {
        // Hàm đã có (để đọc)
        Task<List<Goal>> GetGoalsWithDepositsAsync(string userId);

        // Hàm đã có (để đọc 1 goal)
        Task<Goal> GetGoalByIdAsync(int goalId);

        // Hàm đã có (để tạo)
        Task AddGoalAsync(Goal goal);

        // Hàm đã có (để sửa)
        Task UpdateGoalAsync(Goal goal);

        // --- HÀM MỚI (Cho chức năng Xóa) ---
        // Xóa một Goal bằng ID
        // (Chúng ta truyền ID, Repository sẽ tự xử lý việc
        // xóa các GoalDeposits liên quan)
        Task DeleteGoalAsync(int goalId);
    }
}