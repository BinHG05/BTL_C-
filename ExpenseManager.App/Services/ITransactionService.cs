using ExpenseManager.App.Models.Entities;
using System.Threading.Tasks;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
    }
}