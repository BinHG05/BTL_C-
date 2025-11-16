using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories;

namespace ExpenseManager.App.Services
{
    internal class TicketUserServices : ITicketUserServices
    {
        private readonly ITicketUserRepository _repository;

        public TicketUserServices(ITicketUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ticket>> GetUserTicketsAsync(string userId)
        {
            return await _repository.GetByUserIdAsync(userId);
        }

        public async Task<(bool success, string errorMessage)> CreateTicketAsync(string description, string questionType, string userId)
        {
            // Validation
            if (string.IsNullOrWhiteSpace(description))
            {
                return (false, "Vui lòng nhập mô tả!");
            }

            if (string.IsNullOrWhiteSpace(questionType) || questionType == "-- Choose Type --")
            {
                return (false, "Vui lòng chọn loại ticket!");
            }

            if (string.IsNullOrWhiteSpace(userId))
            {
                return (false, "User ID không hợp lệ!");
            }

            try
            {
                // Create new ticket
                var newTicket = new Ticket
                {
                    UserId = userId,
                    Description = description,
                    QuestionType = questionType,
                    Status = "Open",
                    CreatedAt = DateTime.Now,
                    AdminNote = "",
                    RespondType = "Email"
                };

                await _repository.AddAsync(newTicket);
                await _repository.SaveChangesAsync();

                return (true, string.Empty);
            }
            catch (Exception ex)
            {
                return (false, $"Có lỗi xảy ra: {ex.Message}");
            }
        }
    }
}