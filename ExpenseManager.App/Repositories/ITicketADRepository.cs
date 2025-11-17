using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories
{
    public interface ITicketADRepository
    {
        /// <summary>
        /// Lấy tất cả tickets kèm theo thông tin User
        /// </summary>
        Task<IEnumerable<Ticket>> GetAllTicketsWithUserAsync();

        /// <summary>
        /// Lấy một ticket theo ID kèm theo thông tin User
        /// </summary>
        Task<Ticket> GetTicketByIdAsync(int ticketId);

        /// <summary>
        /// Cập nhật ticket
        /// </summary>
        Task UpdateTicketAsync(Ticket ticket);

        /// <summary>
        /// Xóa ticket theo ID
        /// </summary>
        Task DeleteTicketAsync(int ticketId);
    }
}