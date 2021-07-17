using Amazon.DynamoDBv2.DataModel;
using BudgeteeServer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgeteeServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgeteeController : ControllerBase
    {
        [HttpGet("{id:int}")]
        public async Task<IActionResult> Index([FromRoute] int id, [FromServices] IDynamoDBContext dynamoDbContext)
        {
            return Ok(await dynamoDbContext.QueryAsync<BudgetSummary>(id).GetRemainingAsync());
        }
    }
}
