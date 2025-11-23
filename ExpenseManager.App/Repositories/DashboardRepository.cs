using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.App.Models.EF;      // Namespace chứa DbContext của bạn
using ExpenseManager.App.Models.Entities; // Namespace chứa Entity (Wallet, Transaction...)

namespace ExpenseManager.App.Repositories
{
    public interface IDashboardRepository
    {
        Task<decimal> GetTotalBalanceAsync(string userId);
        Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year);
        Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year);
        Task<Budget> GetActiveBudgetAsync(string userId, int month, int year);
        Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year);
        Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate);
    }

    public class DashboardRepository : IDashboardRepository
    {
        private readonly ExpenseDbContext _context;

        public DashboardRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        // 1. Lấy tổng số dư của TẤT CẢ các ví
        public async Task<decimal> GetTotalBalanceAsync(string userId)
        {
            return await _context.Wallets
                .Where(w => w.UserId == userId)
                .SumAsync(w => w.Balance);
        }

        // 2. Lấy tổng thu nhập trong tháng
        public async Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId
                            && t.Type == "Income"
                            && t.TransactionDate.Month == month
                            && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);
        }

        // 3. Lấy tổng chi tiêu trong tháng
        public async Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId
                            && t.Type == "Expense"
                            && t.TransactionDate.Month == month
                            && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);
        }

        // 4. Lấy ngân sách đang hoạt động trong tháng này
        public async Task<Budget> GetActiveBudgetAsync(string userId, int month, int year)
        {
            var now = DateTime.Now;
            return await _context.Budgets
                .Include(b => b.Category) // Join để lấy tên Category
                .Where(b => b.UserId == userId
                            && b.StartDate <= now
                            && b.EndDate >= now)
                .OrderByDescending(b => b.CreatedAt) // Lấy cái mới nhất
                .FirstOrDefaultAsync();
        }

        // 5. Lấy danh sách giao dịch tháng này (để vẽ biểu đồ & list breakdown)
        public async Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Include(t => t.Category)           // Join Category
                .ThenInclude(c => c.Color)          // Join Color để lấy mã màu Hex
                .Where(t => t.UserId == userId
                            && t.TransactionDate.Month == month
                            && t.TransactionDate.Year == year)
                .OrderBy(t => t.TransactionDate)
                .ToListAsync();
        }

        // 6. Lấy giao dịch theo khoảng thời gian (dùng cho tính toán Budget)
        public async Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId
                            && t.TransactionDate >= startDate
                            && t.TransactionDate <= endDate)
                .ToListAsync();
        }
    }
}