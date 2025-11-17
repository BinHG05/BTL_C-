using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Views.User.UC; // For CategoryExpense DTO
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    // DTO cho phân trang
    public class PaginatedResult<T>
    {
        public List<T> Items { get; set; }
        public int TotalRecords { get; set; }
    }

    public interface IWalletRepository
    {
        Task<List<Wallet>> GetWalletsByUserIdAsync(string userId);
        Task<Wallet> GetWalletByIdAsync(int walletId);
        Task AddWalletAsync(Wallet wallet);
        void UpdateWallet(Wallet wallet);
        void DeleteWallet(Wallet wallet);
        Task<decimal> GetMonthlyExpensesAsync(int walletId, int month, int year);
        Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize);
        Task<List<CategoryExpense>> GetMonthlyExpenseByCategoryAsync(int walletId, int month, int year);
        Task<bool> HasTransactionsAsync(int walletId);
        Task SaveChangesAsync();
    }
}