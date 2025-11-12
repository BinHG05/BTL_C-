using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Color
{
    public int ColorId { get; set; }

    public string ColorName { get; set; } = null!;

    public string HexCode { get; set; } = null!;

    public virtual ICollection<Category> Categories { get; set; } = new List<Category>();
}
