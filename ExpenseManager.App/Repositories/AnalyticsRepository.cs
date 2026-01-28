using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class AnalyticsRepository : IAnalyticsRepository
    {
        private readonly ExpenseDbContext _context;

        public AnalyticsRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<(List<Transaction> Transactions, int TotalCount)> GetExpenseTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                    .ThenInclude(c => c.Icon)
                .Include(t => t.Category)
                    .ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId && t.Type == "Expense");

            // Lọc theo ví
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Đếm tổng số bản ghi
            var totalCount = await query.CountAsync();

            // Phân trang và sắp xếp theo ngày giảm dần
            var transactions = await query
                .OrderByDescending(t => t.TransactionDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (transactions, totalCount);
        }

        public async Task<(List<Transaction> Transactions, int TotalCount)> GetIncomeTransactionsAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate,
            int page,
            int pageSize)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                    .ThenInclude(c => c.Icon)
                .Include(t => t.Category)
                    .ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId && t.Type == "Income");

            // Lọc theo ví 
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Đếm tổng số bản ghi
            var totalCount = await query.CountAsync();

            // Phân trang và sắp xếp theo ngày giảm dần
            var transactions = await query
                .OrderByDescending(t => t.TransactionDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return (transactions, totalCount);
        }

        public async Task<List<CategorySummary>> GetExpenseSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                    .ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId && t.Type == "Expense");

            // Lọc theo ví (nếu có)
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Group by Category và tính tổng
            var summary = await query
                .GroupBy(t => new
                {
                    t.CategoryId,
                    t.Category.CategoryName,
                    ColorHex = t.Category.Color != null ? t.Category.Color.HexCode : "#808080"
                })
                .Select(g => new CategorySummary
                {
                    CategoryId = g.Key.CategoryId,
                    CategoryName = g.Key.CategoryName,
                    ColorHex = g.Key.ColorHex,
                    TotalAmount = g.Sum(t => t.Amount)
                })
                .OrderByDescending(s => s.TotalAmount)
                .ToListAsync();

            return summary;
        }

        public async Task<List<CategorySummary>> GetIncomeSummaryByCategoryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Transactions
                .Include(t => t.Category)
                    .ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId && t.Type == "Income");

            // Lọc theo ví (nếu có)
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Group by Category và tính tổng
            var summary = await query
                .GroupBy(t => new
                {
                    t.CategoryId,
                    t.Category.CategoryName,
                    ColorHex = t.Category.Color != null ? t.Category.Color.HexCode : "#4caf50"
                })
                .Select(g => new CategorySummary
                {
                    CategoryId = g.Key.CategoryId,
                    CategoryName = g.Key.CategoryName,
                    ColorHex = g.Key.ColorHex,
                    TotalAmount = g.Sum(t => t.Amount)
                })
                .OrderByDescending(s => s.TotalAmount)
                .ToListAsync();

            return summary;
        }

        public async Task<List<DailySummary>> GetExpenseDailySummaryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Transactions
                .Where(t => t.UserId == userId && t.Type == "Expense");

            // Lọc theo ví (nếu có)
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Group by Date và tính tổng
            var summary = await query
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new DailySummary
                {
                    Date = g.Key,
                    Amount = g.Sum(t => t.Amount)
                })
                .OrderBy(s => s.Date)
                .ToListAsync();

            return summary;
        }

        public async Task<List<DailySummary>> GetIncomeDailySummaryAsync(
            string userId,
            int? walletId,
            DateTime? startDate,
            DateTime? endDate)
        {
            var query = _context.Transactions
                .Where(t => t.UserId == userId && t.Type == "Income");

            // Lọc theo ví (nếu có)
            if (walletId.HasValue)
            {
                query = query.Where(t => t.WalletId == walletId.Value);
            }

            // Lọc theo khoảng thời gian
            if (startDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate >= startDate.Value);
            }
            if (endDate.HasValue)
            {
                query = query.Where(t => t.TransactionDate <= endDate.Value);
            }

            // Group by Date và tính tổng
            var summary = await query
                .GroupBy(t => t.TransactionDate.Date)
                .Select(g => new DailySummary
                {
                    Date = g.Key,
                    Amount = g.Sum(t => t.Amount)
                })
                .OrderBy(s => s.Date)
                .ToListAsync();

            return summary;
        }
    }
}