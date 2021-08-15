using Amazon.DynamoDBv2.DataModel;
using System.Collections.Generic;

namespace BudgeteeServer.Models
{
    /// <summary>
    /// This class is used to capture the entire summary of the budget
    /// </summary>

    public class BudgetSummary
    {
        /// <summary>
        /// This is the index for the BudgetSummary
        /// </summary>
        [DynamoDBHashKey]
        public string MonthYear { get; set; }

        /// <summary>
        /// Range key used to sort queries and when the budget summary was initially created
        /// </summary>
        [DynamoDBRangeKey]
        public string DateCreated { get; set; }

        /// <summary>
        /// Month of the budget summary
        /// </summary>
        [DynamoDBProperty]
        public string Month { get; set; }

        /// <summary>
        /// Year of the budget summary
        /// </summary>
        [DynamoDBProperty]
        public string Year { get; set; }

        /// <summary>
        /// All budget items for the given month and year
        /// </summary>
        /// <remarks>
        /// These items are for budgeting purposes 
        /// </remarks>
        [DynamoDBProperty]
        public List<BudgetItem> BudgetItems { get; set; }
    }
}
