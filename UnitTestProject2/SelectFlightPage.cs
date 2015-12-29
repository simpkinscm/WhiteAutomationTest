using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace WhiteFrameworkSandbox{
    class SelectFlightPage{
        static Window window = GlobalVar.application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);
        ListView results = window.Get<ListView>("flightsDataGrid");
        Button selectFlightBtn = window.Get<Button>("selectFlightBtn");

        public void SelectFlight(int rowNum){
            results.Rows[rowNum].Cells[0].Click();
            selectFlightBtn.Click();
        }
        public void SelectFlight(String flightID) {
            ListViewRow row = results.Rows.Find(r => r.Cells[4].Text.Equals(flightID));
            row.Click();
            selectFlightBtn.Click();
        }
    }
}
