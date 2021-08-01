using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using BudgeteeServer.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BudgeteeServer.DataAccess.DAO
{
    public class BudgetSummaryRepository : IBudgetSummaryRepository
    {
        private readonly IDynamoDBContext _dynamoDbContext;

        public BudgetSummaryRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<IQueryable<BudgetSummary>> GetBudgetSummaries()
        {
            var scanConds = new List<ScanCondition>
            {
                new ScanCondition(nameof(BudgetSummary.MonthYear), ScanOperator.GreaterThan, 0)
            };
            var result = (await _dynamoDbContext.ScanAsync<BudgetSummary>(scanConds).GetRemainingAsync()).AsQueryable();
            return result;
        }

        public async Task<BudgetSummary> GetBudgetSummaryByMonthYearAsync(string monthYear) => (await _dynamoDbContext.QueryAsync<BudgetSummary>(monthYear).GetRemainingAsync()).FirstOrDefault();

        public async Task SaveBudgetSummaryAsync(BudgetSummary budgetSummary) => await _dynamoDbContext.SaveAsync(budgetSummary);
    }
}
