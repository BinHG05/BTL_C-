using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services
{
    public interface ITicketADServices
    {
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();

        Task<Ticket> GetTicketDetailsAsync(int ticketId);

        Task DeleteTicketAsync(int ticketId);

        Task UpdateTicketDetailsAsync(int ticketId, string newStatus, string newAdminNote);
    }
}