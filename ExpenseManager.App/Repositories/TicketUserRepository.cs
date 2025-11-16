
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    internal class TicketUserRepository : ITicketUserRepository
    {
        private readonly ExpenseDbContext _context;

        public TicketUserRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Ticket>> GetByUserIdAsync(string userId)
        {
            return await _context.Tickets
                .Include(t => t.User) 
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();
        }

        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}