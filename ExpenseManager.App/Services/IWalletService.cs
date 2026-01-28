using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces; 
using ExpenseManager.App.Views.User.UC; 
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface IWalletService
    {
        Task<List<Wallet>> GetWalletsByUserIdAsync(string userId);
        Task<Wallet> GetWalletByIdAsync(int walletId);
        Task CreateWalletAsync(Wallet wallet);
        Task UpdateWalletAsync(Wallet wallet);
        Task DeleteWalletAsync(int walletId);
        Task<decimal> GetMonthlyExpensesAsync(int walletId, int month, int year);
        Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize);
        Task<List<CategoryExpense>> GetMonthlyExpenseByCategoryAsync(int walletId, int month, int year);
    }
}