using BudgeteeServer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace BudgeteeServer.DataAccess.DAO
{
    public interface IBudgetSummaryRepository
    {
        Task<BudgetSummary> GetBudgetSummaryByMonthYearAsync(string monthYear);
        Task SaveBudgetSummaryAsync(BudgetSummary budgetSummary);
        Task<IQueryable<BudgetSummary>> GetBudgetSummaries();
    }
}
