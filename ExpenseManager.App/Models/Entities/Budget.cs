using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Budget
{
    public int BudgetId { get; set; }

    public string UserId { get; set; } = null!;

    public int CategoryId { get; set; }

    public decimal BudgetAmount { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool IsRecurring { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
