using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
        // Các method khác nếu cần (Get, Update, Delete...)

        Task<IEnumerable<Transaction>> GetByCategoryAndDateRangeAsync(
          string userId, int categoryId, DateTime startDate, DateTime endDate);
    }
}