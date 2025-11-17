using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services.Interfaces;
using ExpenseManager.App.Views.User.UC;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepository _walletRepository;

        public WalletService(IWalletRepository walletRepository)
        {
            _walletRepository = walletRepository;
        }

        public Task<List<Wallet>> GetWalletsByUserIdAsync(string userId)
        {
            return _walletRepository.GetWalletsByUserIdAsync(userId);
        }

        public Task<Wallet> GetWalletByIdAsync(int walletId)
        {
            return _walletRepository.GetWalletByIdAsync(walletId);
        }

        public async Task CreateWalletAsync(Wallet wallet)
        {
            if (string.IsNullOrWhiteSpace(wallet.WalletName))
                throw new ArgumentException("Tên ví không được để trống.");

            // Logic gán Icon dựa trên Type
            wallet.Icon = GetIconForWalletType(wallet.WalletType);

            // Gán số dư ban đầu
            wallet.Balance = wallet.InitialBalance;
            wallet.CreatedAt = DateTime.Now;
            wallet.UpdatedAt = DateTime.Now;

            await _walletRepository.AddWalletAsync(wallet);
            await _walletRepository.SaveChangesAsync();
        }

        public async Task UpdateWalletAsync(Wallet wallet)
        {
            var existingWallet = await _walletRepository.GetWalletByIdAsync(wallet.WalletId);
            if (existingWallet == null)
                throw new ArgumentException("Không tìm thấy ví.");

            // Chỉ cho phép cập nhật tên
            existingWallet.WalletName = wallet.WalletName;
            existingWallet.UpdatedAt = DateTime.Now;

            _walletRepository.UpdateWallet(existingWallet);
            await _walletRepository.SaveChangesAsync();
        }

        public async Task DeleteWalletAsync(int walletId)
        {
            var wallet = await _walletRepository.GetWalletByIdAsync(walletId);
            if (wallet == null)
                throw new ArgumentException("Không tìm thấy ví.");

            // Kiểm tra ràng buộc
            if (wallet.Balance != 0)
                throw new InvalidOperationException("Không thể xóa ví vẫn còn số dư. Vui lòng chuyển tiền sang ví khác trước khi xóa.");

            if (await _walletRepository.HasTransactionsAsync(walletId))
                throw new InvalidOperationException("Không thể xóa ví đã có giao dịch. Bạn có thể ẩn ví này thay vì xóa.");

            _walletRepository.DeleteWallet(wallet);
            await _walletRepository.SaveChangesAsync();
        }

        public Task<decimal> GetMonthlyExpensesAsync(int walletId, int month, int year)
        {
            return _walletRepository.GetMonthlyExpensesAsync(walletId, month, year);
        }

        public Task<PaginatedResult<Transaction>> GetTransactionsByWalletIdAsync(int walletId, int pageNumber, int pageSize)
        {
            return _walletRepository.GetTransactionsByWalletIdAsync(walletId, pageNumber, pageSize);
        }

        public Task<List<CategoryExpense>> GetMonthlyExpenseByCategoryAsync(int walletId, int month, int year)
        {
            return _walletRepository.GetMonthlyExpenseByCategoryAsync(walletId, month, year);
        }

        // --- Hàm helper bạn đã cung cấp ---
        private string GetIconForWalletType(string walletType)
        {
            switch (walletType)
            {
                case "Bank":
                    return "fa-solid fa-building-columns";
                case "Cash":
                    return "fa-solid fa-money-bill-wave";
                case "E-Wallet":
                    return "fa-solid fa-wallet";
                case "Credit Card":
                    return "fa-regular fa-credit-card";
                case "Other":
                default:
                    return "fa-solid fa-circle-question";
            }
        }
    }
}