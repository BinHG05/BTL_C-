using ExpenseManager.App.Models.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    // Interface (Giao kèo) cho Wallet Service
    public interface IWalletService
    {
        // Hàm lấy danh sách Ví (Wallets) của người dùng
        // đang đăng nhập (để hiển thị trong ComboBox)
        Task<List<Wallet>> GetWalletsForCurrentUserAsync();
    }
}