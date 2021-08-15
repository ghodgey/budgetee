import { useQuery } from "urql";
import { getBudgetSummaryByMonthYear } from "../../queries/getBudgetSummaryByMonthYear";
import { IBudgetSummary } from "../../models/interfaces";
import {
  KeyboardDatePicker,
  MuiPickersUtilsProvider,
} from "@material-ui/pickers";
import { useState } from "react";
import DateFnsUtils from "@date-io/moment";
import { MaterialUiPickersDate } from "@material-ui/pickers/typings/date";
import moment from "moment";
import { dateFormatMmDdYyyy } from "../../constants/dateTimeConstants";

export function BudgetSummary() {
  const [result] = useQuery({
    query: getBudgetSummaryByMonthYear("December2021"),
  });

  const { data, fetching, error } = result;

  const [selectedDate, setSelectedDate] = useState(
    moment(new Date()).format(dateFormatMmDdYyyy)
  );

  const handleDateChange = (date: MaterialUiPickersDate, value: any) => {
    setSelectedDate(value);
  };

  if (fetching) return <p>Loading...</p>;
  if (error) return <p>Oh no... {error.message}</p>;
  if (data) {
    const { month, year } = data?.budgetSummaryByMonthYear as IBudgetSummary;

    return (
      <div>
        <MuiPickersUtilsProvider utils={DateFnsUtils}>
          <KeyboardDatePicker
            margin="normal"
            id="date-picker-dialog"
            label="Select the budget date"
            format={dateFormatMmDdYyyy}
            value={selectedDate}
            onChange={handleDateChange}
            KeyboardButtonProps={{
              "aria-label": "change date",
            }}
          />
          <p>{month}</p>
          <p>{year}</p>
          <p>The date selected is: {selectedDate}</p>
        </MuiPickersUtilsProvider>
      </div>
    );
  }

  return null;
}
