using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services
{
    public interface ITicketADServices
    {
        /// <summary>
        /// Lấy tất cả tickets (bao gồm thông tin User)
        /// </summary>
        Task<IEnumerable<Ticket>> GetAllTicketsAsync();

        /// <summary>
        /// Lấy chi tiết một ticket theo ID (bao gồm thông tin User)
        /// </summary>
        Task<Ticket> GetTicketDetailsAsync(int ticketId);

        /// <summary>
        /// Xóa ticket theo ID
        /// </summary>
        Task DeleteTicketAsync(int ticketId);

        /// <summary>
        /// Cập nhật thông tin ticket (Status, AdminNote, UpdatedAt, ResolvedAt)
        /// </summary>
        Task UpdateTicketDetailsAsync(int ticketId, string newStatus, string newAdminNote);
    }
}