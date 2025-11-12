using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Icon
{
    public int IconId { get; set; }

    public string IconName { get; set; } = null!;

    public string IconClass { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
