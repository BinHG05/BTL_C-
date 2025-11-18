using ExpenseManager.App.Models.EF;
using ExpenseManager.App.Models.Entities;
using ExpenseManager.App.Repositories.Interfaces;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ExpenseDbContext _context;

        public TransactionRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        public async Task AddTransactionAsync(Transaction transaction)
        {
            await _context.Transactions.AddAsync(transaction);
            // Lưu ý: Chúng ta chưa gọi SaveChanges ở đây để xử lý Transaction (Database Transaction) bên Service
        }
    }
}