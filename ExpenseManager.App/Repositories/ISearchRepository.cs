using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories
{
    public interface ISearchRepository
    {
        Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId);
        Task<List<Category>> GetCategoriesByUserIdAsync(string userId);
    }
}