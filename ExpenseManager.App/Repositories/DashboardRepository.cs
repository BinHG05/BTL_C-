using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Repositories
{
    /// <summary>
    /// Interface định nghĩa các phương thức truy vấn dữ liệu cho Dashboard
    /// </summary>
    public interface IDashboardRepository
    {
        Task<decimal> GetTotalBalanceAsync(string userId);
        Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year);
        Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year);
        Task<Budget> GetFirstActiveBudgetAsync(string userId);
        Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year);
        Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate);
        Task<List<Category>> GetExpenseCategoriesAsync(string userId);
    }

    /// <summary>
    /// Implementation của Repository - xử lý tất cả truy vấn database
    /// </summary>
    public class DashboardRepository : IDashboardRepository
    {
        private readonly ExpenseDbContext _context;

        public DashboardRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Lấy tổng số dư của tất cả các ví của user
        /// </summary>
        public async Task<decimal> GetTotalBalanceAsync(string userId)
        {
            var totalBalance = await _context.Wallets
                .Where(w => w.UserId == userId)
                .SumAsync(w => w.Balance);

            return totalBalance;
        }

        /// <summary>
        /// Lấy tổng thu nhập trong tháng
        /// </summary>
        public async Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year)
        {
            var income = await _context.Transactions
                .Where(t => t.UserId == userId
                    && t.Type == "Income"
                    && t.TransactionDate.Month == month
                    && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);

            return income;
        }

        /// <summary>
        /// Lấy tổng chi tiêu trong tháng
        /// </summary>
        public async Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year)
        {
            var expense = await _context.Transactions
                .Where(t => t.UserId == userId
                    && t.Type == "Expense"
                    && t.TransactionDate.Month == month
                    && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);

            return expense;
        }

        /// <summary>
        /// Lấy budget đang hoạt động đầu tiên của user
        /// </summary>
        public async Task<Budget> GetFirstActiveBudgetAsync(string userId)
        {
            var now = DateTime.Now;

            var budget = await _context.Budgets
                .Include(b => b.Category)
                .Where(b => b.UserId == userId
                    && b.StartDate <= now
                    && b.EndDate >= now)
                .OrderByDescending(b => b.CreatedAt)
                .FirstOrDefaultAsync();

            return budget;
        }

        /// <summary>
        /// Lấy tất cả giao dịch trong tháng
        /// </summary>
        public async Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year)
        {
            var transactions = await _context.Transactions
                .Include(t => t.Category)
                .ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId
                    && t.TransactionDate.Month == month
                    && t.TransactionDate.Year == year)
                .OrderBy(t => t.TransactionDate)
                .ToListAsync();

            return transactions;
        }

        /// <summary>
        /// Lấy giao dịch theo khoảng thời gian
        /// </summary>
        public async Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate)
        {
            var transactions = await _context.Transactions
                .Where(t => t.UserId == userId
                    && t.TransactionDate >= startDate
                    && t.TransactionDate <= endDate)
                .OrderBy(t => t.TransactionDate)
                .ToListAsync();

            return transactions;
        }

        /// <summary>
        /// Lấy danh sách các category chi tiêu
        /// </summary>
        public async Task<List<Category>> GetExpenseCategoriesAsync(string userId)
        {
            var categories = await _context.Categories
                .Include(c => c.Color)
                .Where(c => c.UserId == userId && c.Type == "Expense")
                .ToListAsync();

            return categories;
        }
    }
}