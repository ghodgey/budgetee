using BudgeteeServer.DataAccess.DAO;
using BudgeteeServer.Models;
using HotChocolate;
using System.Threading.Tasks;

namespace BudgeteeServer.GraphQL
{
    public class Mutation
    {
        public async Task<AddBudgetSummaryPayload> AddBudgetSummaryAsync(AddBudgetSummaryInput input, [Service] IBudgetSummaryRepository repository)
        {
            var budgetSummary = new BudgetSummary
            {
                MonthYear = input.BudgetSummary.MonthYear,
                DateCreated = input.BudgetSummary.DateCreated,
                Month = input.BudgetSummary.Month,
                Year = input.BudgetSummary.Year,
                BudgetItems = input.BudgetSummary.BudgetItems
            };

            await repository.SaveBudgetSummaryAsync(budgetSummary);

            return new AddBudgetSummaryPayload(budgetSummary);
        }
    }
}
