using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using ExpenseManager.App.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExpenseManager.App.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IWalletRepository _walletRepository;
        private readonly ExpenseDbContext _context; // Cần context để SaveChanges chung

        // Lưu ý: Trong thực tế nên dùng UnitOfWork pattern, ở đây tôi dùng context trực tiếp cho đơn giản theo kiến trúc hiện tại của bạn
        public TransactionService(
            ITransactionRepository transactionRepository,
            IWalletRepository walletRepository,
            ExpenseDbContext context)
        {
            _transactionRepository = transactionRepository;
            _walletRepository = walletRepository;
            _context = context;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            // 1. Validate logic
            if (transaction.Amount <= 0)
                throw new ArgumentException("Số tiền phải lớn hơn 0.");
            if (transaction.WalletId == 0)
                throw new ArgumentException("Vui lòng chọn ví.");
            if (transaction.CategoryId == 0)
                throw new ArgumentException("Vui lòng chọn danh mục.");

            // 2. Lấy ví hiện tại để cập nhật số dư
            // Lưu ý: Không dùng AsNoTracking() ở đây vì ta cần update nó
            var wallet = await _context.Wallets.FindAsync(transaction.WalletId);
            if (wallet == null)
                throw new ArgumentException("Ví không tồn tại.");

            using (var dbTransaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {
                    // 3. Thêm giao dịch
                    transaction.CreatedAt = DateTime.Now;
                    transaction.UpdatedAt = DateTime.Now;
                    await _transactionRepository.AddTransactionAsync(transaction);

                    // 4. Cập nhật số dư ví
                    if (transaction.Type == "Expense")
                    {
                        wallet.Balance -= transaction.Amount;
                    }
                    else if (transaction.Type == "Income")
                    {
                        wallet.Balance += transaction.Amount;
                    }

                    _context.Wallets.Update(wallet);

                    // 5. Lưu tất cả thay đổi
                    await _context.SaveChangesAsync();
                    await dbTransaction.CommitAsync();
                }
                catch
                {
                    await dbTransaction.RollbackAsync();
                    throw;
                }
            }
        }
        public async Task<List<Transaction>> GetRecentTransactionsAsync(string userId, int days)
        {
            var fromDate = DateTime.Now.Date.AddDays(-days);
            
            // Note: Since ITransactionRepository might not have this specific filter, 
            // we'll access DbSet directly or assume GetAll returns IQueryable.
            // But _transactionRepository is an interface. Let's see what it has.
            // If repository pattern is strict, we should add this method there.
            // For now, let's use the context directly to ensure it works fast as user requested.
            
            return await _context.Transactions
                                 .Include(t => t.Category) // Include Category for names
                                 .Include(t => t.Wallet)   // Include Wallet names
                                 .Where(t => t.UserId == userId && t.TransactionDate >= fromDate)
                                 .OrderByDescending(t => t.TransactionDate)
                                 .ToListAsync();
        }
    }
}