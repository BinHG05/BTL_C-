using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Goal
{
    public int GoalId { get; set; }

    public string UserId { get; set; } = null!;

    public string GoalName { get; set; } = null!;

    public decimal TargetAmount { get; set; }

    public decimal CurrentAmount { get; set; }

    public string Status { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public int? WalletId { get; set; }

    public DateTime? CompletionDate { get; set; }

    public virtual ICollection<GoalDeposit> GoalDeposits { get; set; } = new List<GoalDeposit>();

    public virtual User User { get; set; } = null!;

    public virtual Wallet? Wallet { get; set; }
}
