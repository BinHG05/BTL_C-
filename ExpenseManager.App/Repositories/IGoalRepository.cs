using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    public interface IGoalRepository
    {
        Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(string userId);
        Task<Goal> GetGoalByIdAsync(int goalId);
        Task<Goal> CreateGoalAsync(Goal goal);
        Task<bool> UpdateGoalAsync(Goal goal);
        Task<bool> DeleteGoalAsync(int goalId);
        Task<decimal> GetLastMonthDepositAsync(int goalId);
        Task<IEnumerable<GoalDeposit>> GetGoalDepositHistoryAsync(int goalId);
        Task<GoalDeposit> AddDepositAsync(GoalDeposit deposit);
        Task<bool> UpdateGoalAmountAsync(int goalId, decimal newAmount);
        Task<IEnumerable<GoalContributionDTO>> GetWalletContributionsAsync(int goalId);
    }
}