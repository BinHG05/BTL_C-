using System;
using System.Windows.Forms;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Views.Admin.UC
{
    public interface ITicketADView
    {
        event EventHandler LoadTickets;
        event EventHandler ViewTicket;
        event EventHandler DeleteTicket;

        void SetTicketListBinding(BindingSource ticketList);

        string GetSelectedTicketId();

        (DialogResult DialogResult, string Status, string AdminNote) ShowTicketDetailsDialog(Ticket ticket, ExpenseManager.App.Models.Entities.User user);

        DialogResult ShowMessage(string message, string title, MessageBoxButtons buttons, MessageBoxIcon icon);
    }
}