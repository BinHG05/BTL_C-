using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Category
{
    public int CategoryId { get; set; }

    public string UserId { get; set; } = null!;

    public string CategoryName { get; set; } = null!;

    public string Type { get; set; } = null!;

    public DateTime CreatedAt { get; set; }

    public int ColorId { get; set; }

    public int IconId { get; set; }

    public virtual ICollection<Budget> Budgets { get; set; } = new List<Budget>();

    public virtual Color Color { get; set; } = null!;

    public virtual Icon Icon { get; set; } = null!;

    public virtual ICollection<Transaction> Transactions { get; set; } = new List<Transaction>();

    public virtual User User { get; set; } = null!;
}
