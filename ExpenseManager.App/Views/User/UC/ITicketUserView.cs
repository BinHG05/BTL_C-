using System;
using System.Collections.Generic;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.User.UC
{
    internal interface ITicketUserView
    {
        string UserId { get; }
        void DisplayTickets(IEnumerable<Ticket> tickets);
        void ShowError(string message);
        void SetLoading(bool isLoading);
        event EventHandler LoadTickets;
        event EventHandler CreateNewTicketRequested;
    }
}