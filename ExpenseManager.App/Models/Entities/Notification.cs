using System;
using System.Collections.Generic;

namespace ExpenseManager.App.Models.Entities;

public partial class Notification
{
    public int NotificationId { get; set; }

    public string UserId { get; set; } = null!;

    public string Message { get; set; } = null!;

    public string Url { get; set; } = null!;

    public bool IsRead { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual User User { get; set; } = null!;
}
