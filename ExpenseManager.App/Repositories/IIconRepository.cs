using System.Collections.Generic;
using System.Threading.Tasks;

// Thêm alias này để phân biệt
using DbIcon = ExpenseManager.App.Models.Entities.Icon;

namespace ExpenseManager.App.Repositories.Interfaces
{
    // Interface Icon
    public interface IIconRepository
    {
        Task<List<DbIcon>> GetAllIconsAsync();
    }
}