using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;


namespace ExpenseManager.App.Repositories
{
    // Interface cho Repository xử lý Bảng GoalDeposits
    public interface IGoalDepositRepository
    {
        // Thêm một khoản nạp tiền (Deposit) mới
        Task AddAsync(GoalDeposit deposit);
    }
}