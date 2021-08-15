export const getBudgetSummaryByMonthYear = (monthYear: string) => `
query{
  budgetSummaryByMonthYear(monthYear: "${monthYear}"){
    month
    year
    budgetItems{
      name
    }
  }
}
`;
