using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore; // Bắt buộc có dòng này
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        // 👇👇👇 SỬA HÀM NÀY 👇👇👇
        public async Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize)
        {
            var query = _context.Transactions
                // 1. Lấy Category và Icon
                .Include(t => t.Category)
                    .ThenInclude(c => c.Icon)

                // 2. QUAN TRỌNG: Lấy thêm Color (Nếu thiếu dòng này -> Icon sẽ màu xám)
                .Include(t => t.Category)
                    .ThenInclude(c => c.Color)
                // -------------------------------------------------------------------

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
    }
}