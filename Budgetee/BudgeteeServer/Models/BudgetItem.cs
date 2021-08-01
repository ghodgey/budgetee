using BudgeteeServer.Models.Enums;

namespace BudgeteeServer.Models
{
    public class BudgetItem
    {
        public Name Name { get; set; }
        public BudgetType BudgetType { get; set; }
        public float Price { get; set; }
        public string Description { get; set; }
    }
}
