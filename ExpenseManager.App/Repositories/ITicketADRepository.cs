using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories
{
    public interface ITicketADRepository
    {
        /// Lấy tất cả tickets kèm theo thông tin User
        Task<IEnumerable<Ticket>> GetAllTicketsWithUserAsync();

        /// Lấy một ticket theo ID kèm theo thông tin User
        Task<Ticket> GetTicketByIdAsync(int ticketId);

        /// Cập nhật ticket
        Task UpdateTicketAsync(Ticket ticket);

        /// Xóa ticket theo ID
        Task DeleteTicketAsync(int ticketId);
    }
}