using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; // Cần dòng này

namespace ExpenseManager.App.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ExpenseDbContext _context;

        public TransactionRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
        }

        public async Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize)
        {
            var query = _context.Transactions
                // 👇👇👇 BẮT BUỘC PHẢI CÓ 2 DÒNG NÀY ĐỂ LẤY ICON VÀ MÀU 👇👇👇
                .Include(t => t.Category).ThenInclude(c => c.Icon)  // Lấy Icon
                .Include(t => t.Category).ThenInclude(c => c.Color) // Lấy Màu (Thiếu dòng này là mất màu)
                                                                    // 👆👆👆 --------------------------------------------- 👆👆👆

                .Where(t => t.WalletId == walletId)
                .OrderByDescending(t => t.TransactionDate)
                .ThenByDescending(t => t.CreatedAt)
                .AsNoTracking();

            var totalRecords = await query.CountAsync();

            var transactions = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return new PaginatedResult<Transaction>
            {
                Items = transactions,
                TotalRecords = totalRecords
            };
        }

        public async Task<IEnumerable<Transaction>> GetByCategoryAndDateRangeAsync(
           string userId, int categoryId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId
                    && t.CategoryId == categoryId
                    && t.TransactionDate >= startDate
                    && t.TransactionDate <= endDate)
                .Include(t => t.Category)
                .Include(t => t.Wallet)
                .OrderByDescending(t => t.TransactionDate)
                .ToListAsync();
        }
    }
}