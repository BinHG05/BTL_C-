using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Transaction
{
    public int TransactionId { get; set; }

    public string UserId { get; set; } = null!;

    public int WalletId { get; set; }

    public int CategoryId { get; set; }

    public string Type { get; set; } = null!;

    public decimal Amount { get; set; }

    public DateTime TransactionDate { get; set; }

    public string Description { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;

    public virtual Wallet Wallet { get; set; } = null!;
}
