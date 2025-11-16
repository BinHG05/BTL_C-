using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using Microsoft.EntityFrameworkCore; // Cần cho AsNoTracking, ToListAsync
using System.Collections.Generic;
using System.Linq; // Cần cho Where
using System.Threading.Tasks;
// using ExpenseManager.App.Contracts.Repositories; // (Nếu bạn đã dọn dẹp)

namespace ExpenseManager.App.Repositories
{
    // Triển khai Interface (File 1/10)
    public class WalletRepository : IWalletRepository
    {
        private readonly ExpenseDbContext _context;

        // Tiêm (Inject) DbContext
        public WalletRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        // Triển khai hàm
        public async Task<List<Wallet>> GetWalletsByUserIdAsync(string userId)
        {
            return await _context.Wallets
                .Where(w => w.UserId == userId)
                .AsNoTracking() // Dùng AsNoTracking để tăng tốc độ ĐỌC
                .ToListAsync();
        }
    }
}