using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ExpenseManager.App.Models.Entities;

namespace ExpenseManager.App.Services.Interfaces
{
    public interface ITransactionService
    {
        Task AddTransactionAsync(Transaction transaction);
    }
}