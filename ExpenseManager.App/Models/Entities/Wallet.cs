using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Wallet
{
    public int WalletId { get; set; }

    public string UserId { get; set; } = null!;

    public string WalletName { get; set; } = null!;

    public string WalletType { get; set; } = null!;

    public string Icon { get; set; } = null!;

    public decimal InitialBalance { get; set; }

    public decimal Balance { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<GoalDeposit> GoalDeposits { get; set; } = new List<GoalDeposit>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
