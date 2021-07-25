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
        private readonly string MONTH_YEAR_INDEX = "MonthYear";

        public BudgetSummaryRepository(IDynamoDBContext dynamoDbContext)
        {
            _dynamoDbContext = dynamoDbContext;
        }

        public async Task<IQueryable<BudgetSummary>> GetBudgetSummaries()
        {
            var scanConds = new List<ScanCondition>
            {
                new ScanCondition(nameof(BudgetSummary.Id), ScanOperator.GreaterThan, 0)
            };
            var result = (await _dynamoDbContext.ScanAsync<BudgetSummary>(scanConds).GetRemainingAsync()).AsQueryable();

            return result;
        }


        public async Task<BudgetSummary> GetBudgetSummaryByMonthYearAsync(string monthYear)
        {
            var query = new QueryOperationConfig
            {
                IndexName = "MonthYear-index",
                Filter = new QueryFilter(MONTH_YEAR_INDEX, QueryOperator.Equal, monthYear),
                Limit = 1
            };

            var result = await _dynamoDbContext
            .FromQueryAsync<BudgetSummary>(query).GetRemainingAsync();

            return result.Count > 0 ? result[0] : null;
        }

        public async Task SaveBudgetSummaryAsync(BudgetSummary budgetSummary) => await _dynamoDbContext.SaveAsync(budgetSummary);

    }
}
