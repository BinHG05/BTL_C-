using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    // Interface cho Service xử lý logic Nạp tiền
    public interface IGoalDepositService
    {
        Task AddDepositAsync(int goalId, int walletId, decimal amount);
    }
}