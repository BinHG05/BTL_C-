using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    public class TicketADServices : ITicketADServices
    {
        private readonly ITicketADRepository _repository;

        public TicketADServices(ITicketADRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Lấy tất cả tickets từ Repository
        /// </summary>
        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _repository.GetAllTicketsWithUserAsync();
        }

        /// <summary>
        /// Lấy chi tiết một ticket theo ID
        /// </summary>
        public async Task<Ticket> GetTicketDetailsAsync(int ticketId)
        {
            return await _repository.GetTicketByIdAsync(ticketId);
        }

        /// <summary>
        /// Xóa ticket theo ID
        /// </summary>
        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteTicketAsync(ticketId);
        }

        /// <summary>
        /// Cập nhật thông tin ticket với logic nghiệp vụ
        /// </summary>
        public async Task UpdateTicketDetailsAsync(int ticketId, string newStatus, string newAdminNote)
        {
            // Lấy ticket hiện tại từ Repository
            var ticket = await _repository.GetTicketByIdAsync(ticketId);

            if (ticket == null)
            {
                throw new Exception($"Không tìm thấy yêu cầu với ID: {ticketId}");
            }

            // Cập nhật các trường cơ bản
            ticket.Status = newStatus;
            ticket.AdminNote = newAdminNote;
            ticket.UpdatedAt = DateTime.Now;

            // Logic nghiệp vụ quan trọng:
            // Nếu Status = "Resolved", set ResolvedAt = DateTime.Now
            // Ngược lại, set ResolvedAt = null
            if (newStatus == "Resolved")
            {
                ticket.ResolvedAt = DateTime.Now;
            }
            else
            {
                ticket.ResolvedAt = null;
            }

            // Lưu vào database thông qua Repository
            await _repository.UpdateTicketAsync(ticket);
        }
    }
}