using ExpenseManager.App.Models.DTOs;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private readonly ExpenseDbContext _context;

        public GoalRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Goal>> GetGoalsByUserIdAsync(string userId)
        {
            return await _context.Goals
                .Where(g => g.UserId == userId)
                .Include(g => g.GoalDeposits)
                .Include(g => g.Wallet)
                // 👇 ĐÃ SỬA: OrderBy (Tăng dần) -> Cũ trên, Mới dưới
                .OrderBy(g => g.CreatedAt)
                .ToListAsync();
        }

        public async Task<Goal> GetGoalByIdAsync(int goalId)
        {
            return await _context.Goals
                .Include(g => g.GoalDeposits)
                    .ThenInclude(gd => gd.Wallet)
                .Include(g => g.Wallet)
                .FirstOrDefaultAsync(g => g.GoalId == goalId);
        }

        public async Task<Goal> CreateGoalAsync(Goal goal)
        {
            goal.CreatedAt = DateTime.Now;
            goal.UpdatedAt = DateTime.Now;
            goal.CurrentAmount = 0;
            goal.Status = "Active";

            _context.Goals.Add(goal);
            await _context.SaveChangesAsync();
            return goal;
        }

        public async Task<bool> UpdateGoalAsync(Goal goal)
        {
            var existing = await _context.Goals
                .FirstOrDefaultAsync(g => g.GoalId == goal.GoalId);

            if (existing == null) return false;

            existing.GoalName = goal.GoalName;
            existing.TargetAmount = goal.TargetAmount;
            existing.WalletId = goal.WalletId;
            existing.CurrentAmount = goal.CurrentAmount;
            existing.Status = goal.Status;
            existing.UpdatedAt = DateTime.Now;
            existing.CompletionDate = goal.CompletionDate;

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> DeleteGoalAsync(int goalId)
        {
            var goal = await _context.Goals.FindAsync(goalId);
            if (goal == null) return false;

            var relatedDeposits = _context.GoalDeposits.Where(x => x.GoalId == goalId);
            _context.GoalDeposits.RemoveRange(relatedDeposits);

            _context.Goals.Remove(goal);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<decimal> GetLastMonthDepositAsync(int goalId)
        {
            var lastMonth = DateTime.Now.AddMonths(-1);
            var startOfLastMonth = new DateTime(lastMonth.Year, lastMonth.Month, 1);
            var endOfLastMonth = startOfLastMonth.AddMonths(1).AddDays(-1);

            return await _context.GoalDeposits
                .Where(gd => gd.GoalId == goalId
                    && gd.DepositDate >= startOfLastMonth
                    && gd.DepositDate <= endOfLastMonth)
                .SumAsync(d => d.Amount);
        }

        public async Task<IEnumerable<GoalDeposit>> GetGoalDepositHistoryAsync(int goalId)
        {
            return await _context.GoalDeposits
                .Where(gd => gd.GoalId == goalId)
                .Include(gd => gd.Wallet)
                .OrderByDescending(gd => gd.DepositDate)
                .ToListAsync();
        }

        public async Task<GoalDeposit> AddDepositAsync(GoalDeposit deposit)
        {
            deposit.DepositDate = DateTime.Now;
            _context.GoalDeposits.Add(deposit);
            await _context.SaveChangesAsync();
            return deposit;
        }

        public async Task<bool> UpdateGoalAmountAsync(int goalId, decimal newAmount)
        {
            var goal = await _context.Goals.FindAsync(goalId);
            if (goal == null) return false;

            goal.CurrentAmount = newAmount;
            goal.UpdatedAt = DateTime.Now;

            if (goal.CurrentAmount >= goal.TargetAmount && goal.Status != "Completed")
            {
                goal.Status = "Completed";
                goal.CompletionDate = DateTime.Now;
            }
            else if (goal.CurrentAmount < goal.TargetAmount && goal.Status == "Completed")
            {
                goal.Status = "Active";
                goal.CompletionDate = null;
            }

            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<IEnumerable<GoalContributionDTO>> GetWalletContributionsAsync(int goalId)
        {
            return await _context.GoalDeposits
            .Where(d => d.GoalId == goalId)
            .Include(d => d.Wallet)
            .GroupBy(d => d.Wallet.WalletName)
            .Select(g => new GoalContributionDTO
            {
                WalletName = g.Key,
                ContributedAmount = g.Sum(d => d.Amount)
            })
            .ToListAsync();
        }
    }
}