using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories
{
    internal interface ITicketUserRepository
    {
        Task<IEnumerable<Ticket>> GetByUserIdAsync(string userId);
        Task AddAsync(Ticket ticket);
        Task<int> SaveChangesAsync();
    }
}