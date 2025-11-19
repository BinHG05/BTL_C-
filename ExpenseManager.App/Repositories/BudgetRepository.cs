using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class BudgetRepository:IBudgetRepository
{
    private readonly ExpenseDbContext _context;

    public BudgetRepository(ExpenseDbContext context)
    {
        _context = context;
    }

    // ====================== GET ALL =========================
    public async Task<IEnumerable<Budget>> GetAllAsync()
    {
        return await _context.Budgets
            .Include(b => b.Category)
            .Include(b => b.User)
            .ToListAsync();
    }

    // ================== GET BY ID =============================
    public async Task<Budget?> GetByIdAsync(int id)
    {
        return await _context.Budgets
            .Include(b => b.Category)
            .Include(b => b.User)
            .FirstOrDefaultAsync(b => b.BudgetId == id);
    }

    // ================ GET BY USER ID ==========================
    public async Task<IEnumerable<Budget>> GetByUserAsync(string userId)
    {
        return await _context.Budgets
            .Where(b => b.UserId == userId)
            .Include(b => b.Category)
            .ToListAsync();
    }

    // ====================== ADD ===============================
    public async Task<Budget> AddAsync(Budget model)
    {
        await _context.Budgets.AddAsync(model);
        await _context.SaveChangesAsync();
        return model;
    }

    // ====================== UPDATE ============================
    public async Task<bool> UpdateAsync(Budget model)
    {
        var existing = await _context.Budgets.FindAsync(model.BudgetId);

        if (existing == null)
            return false;

        existing.CategoryId = model.CategoryId;
        existing.BudgetAmount = model.BudgetAmount;
        existing.StartDate = model.StartDate;
        existing.EndDate = model.EndDate;
        existing.IsRecurring = model.IsRecurring;

        _context.Budgets.Update(existing);
        await _context.SaveChangesAsync();
        return true;
    }

    // ====================== DELETE ============================
    public async Task<bool> DeleteAsync(int id)
    {
        var existing = await _context.Budgets.FindAsync(id);

        if (existing == null)
            return false;

        _context.Budgets.Remove(existing);
        await _context.SaveChangesAsync();
        return true;
    }
}
