using BudgeteeServer.DataAccess.DAO;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BudgeteeServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BudgeteeController : ControllerBase
    {
        private readonly IBudgetSummaryRepository _budgetSummaryRepository;
        public BudgeteeController(IBudgetSummaryRepository budgetSummaryRepository)
        {
            _budgetSummaryRepository = budgetSummaryRepository;
        }
        [HttpGet("{monthYear}")]
        public async Task<IActionResult> Index([FromRoute] string monthYear)
        {
            var budgetSummary = await _budgetSummaryRepository.GetBudgetSummaryByMonthYearAsync(monthYear);

            budgetSummary.BudgetItems.Add(new Models.BudgetItem
            {
                BudgetType = 0,
                Description = "This is a test",
                Name = Models.Enums.Name.Gazza,
                Price = 23.99f
            });

            await _budgetSummaryRepository.SaveBudgetSummaryAsync(budgetSummary);

            return Ok(await _budgetSummaryRepository.GetBudgetSummaryByMonthYearAsync(monthYear));
        }
    }
}
