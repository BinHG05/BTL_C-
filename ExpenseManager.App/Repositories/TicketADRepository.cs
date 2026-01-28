using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Repositories
{
    public class TicketADRepository : ITicketADRepository
    {
        private readonly ExpenseDbContext _context;

        public TicketADRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        /// Lấy tất cả tickets kèm theo thông tin User
        public async Task<IEnumerable<Ticket>> GetAllTicketsWithUserAsync()
        {
            return await _context.Tickets
                .Include(t => t.User)  
                .OrderByDescending(t => t.CreatedAt)  
                .ToListAsync();
        }

        /// Lấy một ticket theo ID kèm theo thông tin User
        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets
                .Include(t => t.User) 
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        /// Cập nhật ticket trong database
        public async Task UpdateTicketAsync(Ticket ticket)
        {
            if (ticket == null)
            {
                throw new ArgumentNullException(nameof(ticket), "yêu cầu không được null");
            }

            // Đánh dấu entity là đã được sửa đổi
            _context.Entry(ticket).State = EntityState.Modified;

            // Lưu thay đổi vào database
            await _context.SaveChangesAsync();
        }

        /// Xóa ticket theo ID
        public async Task DeleteTicketAsync(int ticketId)
        {
            // Tìm ticket cần xóa
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket == null)
            {
                throw new Exception($"Không tìm thấy ticket với ID: {ticketId}");
            }

            _context.Tickets.Remove(ticket);

            await _context.SaveChangesAsync();
        }
    }
}