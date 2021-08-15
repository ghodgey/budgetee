import React from "react";
import ReactDOM from "react-dom";
import "./index.css";
import reportWebVitals from "./reportWebVitals";
import { BudgetSummary } from "./pages/budgetSummary";
import { createClient, Provider } from "urql";
import { SimpleLayout } from "./layout";

const client = createClient({
  url: "https://localhost:5001/graphql",
});

ReactDOM.render(
  <React.StrictMode>
    <Provider value={client}>
      <SimpleLayout>
        <BudgetSummary />
      </SimpleLayout>
    </Provider>
  </React.StrictMode>,
  document.getElementById("root")
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
