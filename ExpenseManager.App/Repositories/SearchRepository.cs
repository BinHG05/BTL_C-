using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ExpenseDbContext _context;

        public SearchRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Transaction>> GetTransactionsByUserIdAsync(string userId)
        {
            return await _context.Transactions
                .Include(t => t.Category)      
                .Include(t => t.Wallet)   
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }

        public async Task<List<Category>> GetCategoriesByUserIdAsync(string userId)
        {
            return await _context.Categories
                .Where(c => c.UserId == userId)
                .OrderBy(c => c.CategoryName)
                .ToListAsync();
        }
    }
}