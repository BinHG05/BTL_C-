using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories.Interfaces
{
    public interface ITransactionRepository
    {
        Task AddTransactionAsync(Transaction transaction);
        // Các method khác nếu cần (Get, Update, Delete...)
    }
}