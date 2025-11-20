using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseManager.App.Models.DTOs
{
    public class GoalContributionDTO
    {
        public string WalletName { get; set; }
        public decimal ContributedAmount { get; set; } // Số tiền đã nạp
    }
}
