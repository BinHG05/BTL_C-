using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DbColor = ExpenseManager.App.Models.Entities.Color;

namespace ExpenseManager.App.Repositories.Interfaces
{
    // Interface Color
    public interface IColorRepository
    {
        Task<List<DbColor>> GetAllColorsAsync();
    }
}