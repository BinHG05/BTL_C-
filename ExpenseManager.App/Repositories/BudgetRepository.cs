using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;

public class BudgetRepository : IBudgetRepository
{
    private readonly ExpenseDbContext _context;

    public BudgetRepository(ExpenseDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Budget>> GetAllAsync()
    {
        Debug.WriteLine("[BudgetRepository] GetAllAsync: Bắt đầu truy vấn tất cả ngân sách.");
        try
        {
            var result = await _context.Budgets
                .Include(b => b.Category)
                .Include(b => b.User)
                .ToListAsync();
            Debug.WriteLine($"[BudgetRepository] GetAllAsync: Truy vấn thành công. Số lượng: {result.Count}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] GetAllAsync: Lỗi: {ex.Message}");
            throw;
        }
    }

    public async Task<Budget?> GetByIdAsync(int id)
    {
        Debug.WriteLine($"[BudgetRepository] GetByIdAsync: Bắt đầu truy vấn ngân sách ID: {id}");
        try
        {
            var result = await _context.Budgets
                .Include(b => b.Category)
                .Include(b => b.User)
                .FirstOrDefaultAsync(b => b.BudgetId == id);
            Debug.WriteLine($"[BudgetRepository] GetByIdAsync: Truy vấn hoàn tất. Kết quả: {(result != null ? "Có" : "Không")}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] GetByIdAsync: Lỗi: {ex.Message}");
            throw;
        }
    }

    public async Task<IEnumerable<Budget>> GetByUserAsync(string userId)
    {
        Debug.WriteLine($"[BudgetRepository] GetByUserAsync: Bắt đầu truy vấn cho UserId: {userId}");
        try
        {
            var result = await _context.Budgets
                .Where(b => b.UserId == userId)
                .Include(b => b.Category)
                .ToListAsync();

            Debug.WriteLine($"[BudgetRepository] GetByUserAsync: Truy vấn thành công. Số lượng: {result.Count}");
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] GetByUserAsync: Lỗi: {ex.Message}");
            throw;
        }
    }

    public async Task<Budget> AddAsync(Budget model)
    {
        Debug.WriteLine("[BudgetRepository] AddAsync: Bắt đầu thêm ngân sách mới.");
        try
        {
            await _context.Budgets.AddAsync(model);
            await _context.SaveChangesAsync();
            Debug.WriteLine($"[BudgetRepository] AddAsync: Ngân sách ID {model.BudgetId} đã được thêm.");
            return model;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] AddAsync: Lỗi: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> UpdateAsync(Budget model)
    {
        Debug.WriteLine($"[BudgetRepository] UpdateAsync: Bắt đầu cập nhật ngân sách ID: {model.BudgetId}");
        try
        {
            var existing = await _context.Budgets.FindAsync(model.BudgetId);

            if (existing == null)
            {
                Debug.WriteLine($"[BudgetRepository] UpdateAsync: Ngân sách ID {model.BudgetId} không tồn tại.");
                return false;
            }

            existing.CategoryId = model.CategoryId;
            existing.BudgetAmount = model.BudgetAmount;
            existing.StartDate = model.StartDate;
            existing.EndDate = model.EndDate;
            existing.IsRecurring = model.IsRecurring;

            _context.Budgets.Update(existing);
            await _context.SaveChangesAsync();
            Debug.WriteLine($"[BudgetRepository] UpdateAsync: Ngân sách ID {model.BudgetId} đã được cập nhật.");
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] UpdateAsync: Lỗi: {ex.Message}");
            throw;
        }
    }

    public async Task<bool> DeleteAsync(int id)
    {
        Debug.WriteLine($"[BudgetRepository] DeleteAsync: Bắt đầu xóa ngân sách ID: {id}");
        try
        {
            var existing = await _context.Budgets.FindAsync(id);

            if (existing == null)
            {
                Debug.WriteLine($"[BudgetRepository] DeleteAsync: Ngân sách ID {id} không tồn tại.");
                return false;
            }

            _context.Budgets.Remove(existing);
            await _context.SaveChangesAsync();
            Debug.WriteLine($"[BudgetRepository] DeleteAsync: Ngân sách ID {id} đã được xóa.");
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"[BudgetRepository] DeleteAsync: Lỗi: {ex.Message}");
            throw;
        }
    }
}