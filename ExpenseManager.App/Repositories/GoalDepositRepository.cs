using ExpenseManager.App.Models.EF; // Cần cho DbContext
using ExpenseManager.App.Models.Entities; // Cần cho GoalDeposit
using System.Threading.Tasks;

namespace ExpenseManager.App.Repositories
{

    public class GoalDepositRepository : IGoalDepositRepository
    {
        private readonly ExpenseDbContext _context;

        // Tiêm (Inject) DbContext
        public GoalDepositRepository(ExpenseDbContext context)
        {
            _context = context;
        }

        // Triển khai hàm AddAsync
        public async Task AddAsync(GoalDeposit deposit)
        {
            await _context.GoalDeposits.AddAsync(deposit);
            await _context.SaveChangesAsync();
        }
    }
}