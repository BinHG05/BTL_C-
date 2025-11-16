using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    // Interface (Giao kèo) cho Wallet Repository
    public interface IWalletRepository
    {
        // Hàm lấy TẤT CẢ các ví của một User
        Task<List<Wallet>> GetWalletsByUserIdAsync(string userId);
    }
}