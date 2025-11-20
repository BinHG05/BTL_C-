using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services
{
    public interface ISearchServices
    {
        Task<List<Transaction>> SearchTransactionsAsync(
            string userId,
            string keyword,
            string type,
            int? categoryId,
            DateTime fromDate,
            DateTime toDate);

        Task<List<Category>> GetUserCategoriesAsync(string userId);
    }
}