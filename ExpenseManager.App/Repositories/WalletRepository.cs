using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Views.User.UC;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class WalletRepository : IWalletRepository
    {
        private readonly ExpenseDbContext _context;

        public WalletRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<List<Wallet>> GetWalletsByUserIdAsync(string userId)
        {
            return await _context.Wallets
                .Where(w => w.UserId == userId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<Wallet> GetWalletByIdAsync(int walletId)
        {
            return await _context.Wallets
                .AsNoTracking()
                .FirstOrDefaultAsync(w => w.WalletId == walletId);
        }

        public async Task AddWalletAsync(Wallet wallet)
        {   
            await _context.Wallets.AddAsync(wallet);
        }

        public async Task UpdateWallet(Wallet wallet)
        {
            // Lấy wallet đang được EF tracking
            var existing = await _context.Wallets
                .FirstOrDefaultAsync(w => w.WalletId == wallet.WalletId);

            if (existing == null)
                return;

            // Cập nhật giá trị
            existing.WalletName = wallet.WalletName;
            existing.Balance = wallet.Balance;
            existing.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();
        }


        public async Task DeleteWallet(Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
            await _context.SaveChangesAsync();
        }

        public async Task<decimal> GetMonthlyExpensesAsync(int walletId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.WalletId == walletId &&
                            t.Type == "Expense" &&
                            t.TransactionDate.Month == month &&
                            t.TransactionDate.Year == year)
                .AsNoTracking()
                .SumAsync(t => t.Amount);
        }

        public async Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize)
        {
            var query = _context.Transactions
                .Include(t => t.Category)

                .ThenInclude(c => c.Icon)
                .Include(t => t.Category)
                .ThenInclude(c => c.Color)
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

        public async Task<List<CategoryExpense>> GetMonthlyExpenseByCategoryAsync(int walletId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.WalletId == walletId &&
                            t.Type == "Expense" &&
                            t.TransactionDate.Month == month &&
                            t.TransactionDate.Year == year)
                .Include(t => t.Category)
                .ThenInclude(c => c.Color)
                .AsNoTracking()
                .GroupBy(t => new { t.Category.CategoryName, t.Category.Color.HexCode })
                .Select(g => new CategoryExpense
                {
                    CategoryName = g.Key.CategoryName,
                    Amount = g.Sum(t => t.Amount),
                    ColorHex = g.Key.HexCode
                })
                .OrderByDescending(x => x.Amount)
                .ToListAsync();
        }

        public async Task<bool> HasTransactionsAsync(int walletId)
        {
            return await _context.Transactions.AnyAsync(t => t.WalletId == walletId);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}