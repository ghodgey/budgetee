using BudgeteeServer.Models;
using HotChocolate.Types;

namespace BudgeteeServer.GraphQL.Types
{
    public class BudgetSummaryType : ObjectType<BudgetSummary>
    {
        protected override void Configure(IObjectTypeDescriptor<BudgetSummary> descriptor)
        {
            descriptor.Description("Used to group all the items of budget for a given month");
            descriptor.Field(x => x.Month).Description("Month of the budget");
            descriptor.Field(x => x.Year).Description("Year of the budget");
            descriptor.Field(x => x.MonthYear).Description("Unique key to base monthly budget on");
            descriptor.Field(x => x.BudgetItems)
                      .Description("This is the list of to do item available for this list");
        }
    }
}
