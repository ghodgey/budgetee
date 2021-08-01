using BudgeteeServer.DataAccess.DAO;
using BudgeteeServer.Models;
using HotChocolate;
using HotChocolate.Data;
using System.Linq;
using System.Threading.Tasks;

namespace BudgeteeServer.GraphQL
{
    public class Query
    {
        [UseFiltering]
        [UseSorting]
        public async Task<IQueryable<BudgetSummary>> GetAllBudgetSummaries([Service] IBudgetSummaryRepository repository)
            => await repository.GetBudgetSummaries();


        public async Task<BudgetSummary> GetBudgetSummaryByMonthYearAsync([Service] IBudgetSummaryRepository repository, string monthYear)
            => await repository.GetBudgetSummaryByMonthYearAsync(monthYear);

    }
}
