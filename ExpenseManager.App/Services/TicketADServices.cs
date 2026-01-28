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

        public async Task<IEnumerable<Ticket>> GetAllTicketsAsync()
        {
            return await _repository.GetAllTicketsWithUserAsync();
        }

        public async Task<Ticket> GetTicketDetailsAsync(int ticketId)
        {
            return await _repository.GetTicketByIdAsync(ticketId);
        }

        public async Task DeleteTicketAsync(int ticketId)
        {
            await _repository.DeleteTicketAsync(ticketId);
        }

        public async Task UpdateTicketDetailsAsync(int ticketId, string newStatus, string newAdminNote)
        {
            var ticket = await _repository.GetTicketByIdAsync(ticketId);

            if (ticket == null)
            {
                throw new Exception($"Không tìm thấy yêu cầu với ID: {ticketId}");
            }

            ticket.Status = newStatus;
            ticket.AdminNote = newAdminNote;
            ticket.UpdatedAt = DateTime.Now;

            if (newStatus == "Resolved")
            {
                ticket.ResolvedAt = DateTime.Now;
            }
            else
            {
                ticket.ResolvedAt = null;
            }

            await _repository.UpdateTicketAsync(ticket);
        }
    }
}