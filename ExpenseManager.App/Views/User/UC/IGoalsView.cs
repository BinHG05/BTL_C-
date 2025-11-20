using ExpenseManager.App.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.App.Views.User.UC
{
    public interface IGoalsView
    {
        void DisplayGoalsList(IEnumerable<GoalDTO> goals);
        void DisplayGoalDetails(GoalDTO goal);
        void DisplayWalletBalances(IEnumerable<GoalWalletBalanceDTO> wallets);
        void DisplayHistory(IEnumerable<GoalDepositHistoryDTO> history);
        void ShowMessage(string message, bool isSuccess);
        void DisplayWalletContributions(IEnumerable<GoalContributionDTO> contributions);
        void ClearGoalDetails();

    }
}
