using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services
{
    internal interface ITicketUserServices
    {
        Task<IEnumerable<Ticket>> GetUserTicketsAsync(string userId);
        Task<(bool success, string errorMessage)> CreateTicketAsync(string description, string questionType, string userId);
    }
}