using ExpenseManager.App.Models.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface IGoalService
    {
        Task<IEnumerable<GoalDTO>> GetUserGoalsAsync(string userId);
        Task<GoalDTO> GetGoalDetailsAsync(int goalId);
        Task<GoalDTO> CreateGoalAsync(CreateGoalDTO createGoalDto);
        Task<bool> UpdateGoalAsync(UpdateGoalDTO updateGoalDto);
        Task<bool> DeleteGoalAsync(int goalId);
        Task<bool> DepositToGoalAsync(GoalDepositDTO depositDto);
        Task<IEnumerable<GoalDepositHistoryDTO>> GetGoalHistoryAsync(int goalId);
        Task<IEnumerable<GoalWalletBalanceDTO>> GetAvailableWalletsAsync(string userId);
        Task<IEnumerable<GoalContributionDTO>> GetWalletContributionsAsync(int goalId);
    }
}