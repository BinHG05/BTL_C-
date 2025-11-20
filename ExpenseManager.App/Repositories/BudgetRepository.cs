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
            Debug.WriteLine("[BudgetRepository] GetAllAsync");
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

                Debug.WriteLine($"✅ GetAllAsync: {result.Count} budgets");
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetAllAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Budget?> GetByIdAsync(int id)
        {
            Debug.WriteLine($"[BudgetRepository] GetByIdAsync: ID={id}");
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

                Debug.WriteLine($"✅ GetByIdAsync: {(result != null ? "Found" : "Not found")}");
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetByIdAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<Budget>> GetByUserAsync(string userId)
        {
            Debug.WriteLine($"[BudgetRepository] GetByUserAsync: UserId={userId}");
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

                Debug.WriteLine($"✅ GetByUserAsync: {result.Count} budgets");
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ GetByUserAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task<Budget> AddAsync(Budget model)
        {
            Debug.WriteLine($"[BudgetRepository] AddAsync: CategoryId={model.CategoryId}");
            try
            {
                await _context.Budgets.AddAsync(model);
                await _context.SaveChangesAsync();

                // Detach để tránh tracking issues
                _context.Entry(model).State = EntityState.Detached;

                Debug.WriteLine($"✅ AddAsync: BudgetId={model.BudgetId} created");
                return model;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ AddAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Budget model)
        {
            Debug.WriteLine($"[BudgetRepository] UpdateAsync: BudgetId={model.BudgetId}");
            try
            {
                var existing = await _context.Budgets.FindAsync(model.BudgetId);

                if (existing == null)
                {
                    Debug.WriteLine($"❌ UpdateAsync: Budget {model.BudgetId} not found");
                    return false;
                }

                existing.CategoryId = model.CategoryId;
                existing.BudgetAmount = model.BudgetAmount;
                existing.StartDate = model.StartDate;
                existing.EndDate = model.EndDate;
                existing.IsRecurring = model.IsRecurring;

                _context.Budgets.Update(existing);
                await _context.SaveChangesAsync();

                // Detach
                _context.Entry(existing).State = EntityState.Detached;

                Debug.WriteLine($"✅ UpdateAsync: Budget {model.BudgetId} updated");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ UpdateAsync Error: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Debug.WriteLine($"[BudgetRepository] DeleteAsync: ID={id}");
            try
            {
                var existing = await _context.Budgets.FindAsync(id);

                if (existing == null)
                {
                    Debug.WriteLine($"❌ DeleteAsync: Budget {id} not found");
                    return false;
                }

                _context.Budgets.Remove(existing);
                await _context.SaveChangesAsync();

                Debug.WriteLine($"✅ DeleteAsync: Budget {id} deleted");
                return true;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"❌ DeleteAsync Error: {ex.Message}");
                throw;
            }
        }
    }
}