using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Repositories
{
    public class BudgetRepository : IBudgetRepository
    {
        private readonly ExpenseDbContext _context;

        public BudgetRepository(ExpenseDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Budget>> GetAllAsync()
        {
            try
            {
                var result = await _context.Budgets
                    .AsNoTracking()
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Icon)
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Color)
                    .Include(b => b.User)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Budget?> GetByIdAsync(int id)
        {
            try
            {
                var result = await _context.Budgets
                    .AsNoTracking()
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Icon)
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Color)
                    .Include(b => b.User)
                    .FirstOrDefaultAsync(b => b.BudgetId == id);

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Budget>> GetByUserAsync(string userId)
        {
            try
            {
                var result = await _context.Budgets
                    .AsNoTracking()
                    .Where(b => b.UserId == userId)
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Icon)
                    .Include(b => b.Category)
                        .ThenInclude(c => c.Color)
                    .OrderBy(b => b.Category.CategoryName)
                    .ToListAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Budget> AddAsync(Budget model)
        {
            try
            {
                await _context.Budgets.AddAsync(model);
                await _context.SaveChangesAsync();

                // Detach để tránh tracking issues
                _context.Entry(model).State = EntityState.Detached;

                return model;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Budget model)
        {
            try
            {
                var existing = await _context.Budgets.FindAsync(model.BudgetId);

                if (existing == null)
                {
                    return false;
                }

                existing.CategoryId = model.CategoryId;
                existing.BudgetAmount = model.BudgetAmount;
                existing.StartDate = model.StartDate;
                existing.EndDate = model.EndDate;
                existing.IsRecurring = model.IsRecurring;

                _context.Budgets.Update(existing);
                await _context.SaveChangesAsync();

                _context.Entry(existing).State = EntityState.Detached;

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var existing = await _context.Budgets.FindAsync(id);

                if (existing == null)
                {
                    return false;
                }

                _context.Budgets.Remove(existing);
                await _context.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}