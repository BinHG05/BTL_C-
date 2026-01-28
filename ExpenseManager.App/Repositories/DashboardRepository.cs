using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Repositories
{
    public interface IDashboardRepository
    {
        Task<decimal> GetTotalBalanceAsync(string userId);
        Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year);
        Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year);

        Task<Budget> GetFirstActiveBudgetAsync(string userId); 
        Task<List<Budget>> GetActiveBudgetsAsync(string userId); 

        Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year);
        Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate);

        Task<List<Transaction>> GetRecentTransactionsAsync(string userId, int count);
        Task<List<Goal>> GetGoalsAsync(string userId);
    }

    public class DashboardRepository : IDashboardRepository
    {
        private readonly ExpenseDbContext _context;

        public DashboardRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<decimal> GetTotalBalanceAsync(string userId)
        {
            return await _context.Wallets.Where(w => w.UserId == userId).SumAsync(w => w.Balance);
        }

        public async Task<decimal> GetMonthlyIncomeAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId && t.Type == "Income" && t.TransactionDate.Month == month && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);
        }

        public async Task<decimal> GetMonthlyExpenseAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId && t.Type == "Expense" && t.TransactionDate.Month == month && t.TransactionDate.Year == year)
                .SumAsync(t => t.Amount);
        }

        public async Task<Budget> GetFirstActiveBudgetAsync(string userId)
        {
            var now = DateTime.Now;
            return await _context.Budgets
                .Include(b => b.Category)
                .Where(b => b.UserId == userId && b.StartDate <= now && b.EndDate >= now)
                .OrderByDescending(b => b.CreatedAt)
                .FirstOrDefaultAsync();
        }

        //Lấy danh sách ngân sách đang chạy 
        public async Task<List<Budget>> GetActiveBudgetsAsync(string userId)
        {
            var now = DateTime.Now;
            return await _context.Budgets
                .Include(b => b.Category).ThenInclude(c => c.Color)
                .Include(b => b.Category).ThenInclude(c => c.Icon) 
                .Where(b => b.UserId == userId && b.StartDate <= now && b.EndDate >= now)
                .Take(4)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetMonthlyTransactionsAsync(string userId, int month, int year)
        {
            return await _context.Transactions
                .Include(t => t.Category).ThenInclude(c => c.Color)
                .Where(t => t.UserId == userId && t.TransactionDate.Month == month && t.TransactionDate.Year == year)
                .ToListAsync();
        }

        public async Task<List<Transaction>> GetTransactionsByDateRangeAsync(string userId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Where(t => t.UserId == userId && t.TransactionDate >= startDate && t.TransactionDate <= endDate)
                .ToListAsync();
        }

        //Lấy 5 giao dịch gần nhất
        public async Task<List<Transaction>> GetRecentTransactionsAsync(string userId, int count)
        {
            return await _context.Transactions
                .Include(t => t.Category).ThenInclude(c => c.Color)
                .Include(t => t.Category).ThenInclude(c => c.Icon) 
                .Where(t => t.UserId == userId)
                .OrderByDescending(t => t.TransactionDate)
                .ThenByDescending(t => t.CreatedAt)
                .Take(count)
                .ToListAsync();
        }

        //Lấy danh sách mục tiêu
        public async Task<List<Goal>> GetGoalsAsync(string userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId && g.Status != "Completed") 
                .OrderByDescending(g => g.CreatedAt)
                .Take(3) 
                .ToListAsync();
        }
    }
}