using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore;
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

        public async Task<List<Goal>> GetGoalsWithDepositsAsync(string userId)
        {
            // (Hàm đã có - Giữ nguyên)
            return await _context.Goals
                .Where(g => g.UserId == userId)
                .Include(g => g.GoalDeposits)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task AddGoalAsync(Goal goal)
        {
            // (Hàm đã có - Giữ nguyên)
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();
        }

        public async Task<Goal> GetGoalByIdAsync(int goalId)
        {
            // (Hàm đã có - Giữ nguyên)
            // (Cần Include Deposits để Service tính CurrentAmount)
            return await _context.Goals
                .Include(g => g.GoalDeposits)
                .FirstOrDefaultAsync(g => g.GoalId == goalId);
        }

        public async Task UpdateGoalAsync(Goal goal)
        {
            // (Hàm đã có - Giữ nguyên)
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
        }

        // --- HÀM MỚI (Triển khai từ Interface File 1/13) ---
        public async Task DeleteGoalAsync(int goalId)
        {
            // 1. Tìm Goal (và các Deposits của nó)
            // Phải Include Deposits để EF có thể xóa chúng trước
            // (Phòng trường hợp CSDL không có "ON DELETE CASCADE")
            var goalToDelete = await _context.Goals
                .Include(g => g.GoalDeposits)
                .FirstOrDefaultAsync(g => g.GoalId == goalId);

            if (goalToDelete != null)
            {
                // 2. Xóa các Deposits (con) trước
                _context.GoalDeposits.RemoveRange(goalToDelete.GoalDeposits);

                // 3. Xóa Goal (cha)
                _context.Goals.Remove(goalToDelete);

                // 4. Lưu CSDL
                await _context.SaveChangesAsync();
            }
        }
    }
}