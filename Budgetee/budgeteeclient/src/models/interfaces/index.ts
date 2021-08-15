import { BudgetType, Name } from "../enums";

interface IBudgetItems {
  name: Name;
  budgetType: BudgetType;
  price: number;
  description: string;
}

export interface IBudgetSummary {
  monthYear: string;
  dateCreated: string;
  month: string;
  year: string;
  budgetItems: IBudgetItems[];
}
