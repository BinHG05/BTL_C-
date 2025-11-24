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

        /// <summary>
        /// Lấy tất cả tickets kèm theo thông tin User
        /// </summary>
        public async Task<IEnumerable<Ticket>> GetAllTicketsWithUserAsync()
        {
            return await _context.Tickets
                .Include(t => t.User)  // Include navigation property User
                .OrderByDescending(t => t.CreatedAt)  // Sắp xếp theo ngày tạo mới nhất
                .ToListAsync();
        }

        /// <summary>
        /// Lấy một ticket theo ID kèm theo thông tin User
        /// </summary>
        public async Task<Ticket> GetTicketByIdAsync(int ticketId)
        {
            return await _context.Tickets
                .Include(t => t.User)  // Include navigation property User
                .FirstOrDefaultAsync(t => t.TicketId == ticketId);
        }

        /// <summary>
        /// Cập nhật ticket trong database
        /// </summary>
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

        /// <summary>
        /// Xóa ticket theo ID
        /// </summary>
        public async Task DeleteTicketAsync(int ticketId)
        {
            // Tìm ticket cần xóa
            var ticket = await _context.Tickets.FindAsync(ticketId);

            if (ticket == null)
            {
                throw new Exception($"Không tìm thấy ticket với ID: {ticketId}");
            }

            // Xóa ticket khỏi DbContext
            _context.Tickets.Remove(ticket);

            // Lưu thay đổi vào database
            await _context.SaveChangesAsync();
        }
    }
}