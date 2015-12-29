using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace WhiteFrameworkSandbox{
    class SearchPage{
        static Window window = GlobalVar.application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);
        ComboBox fromCityBox = window.Get<ComboBox>("fromCity");
        ComboBox toCityBox = window.Get<ComboBox>("toCity");
        DateTimePicker flightDatePicker = window.Get<DateTimePicker>("datePicker");
        ComboBox flightClassBox = window.Get<ComboBox>("Class");
        ComboBox numOfTicketsBox = window.Get<ComboBox>("numOfTickets");
        Button findFlightsBtn = window.Get<Button>(SearchCriteria.ByText("FIND FLIGHTS"));

        public bool SearchFlight(String fromCity, String toCity, int daysTilFlight, String flightClass, int numTickets){
            fromCityBox.Items.Select(fromCity);
            toCityBox.Items.Select(toCity);
            DateTime today = DateTime.Now;
            DateTime flightDate = today.AddDays(daysTilFlight);
            flightDatePicker.SetDate(flightDate, DateFormat.MonthDayYear);
            flightClassBox.Items.Select(flightClass);
            numOfTicketsBox.Items.Select(numTickets - 1);
            findFlightsBtn.Click();
            try{
                Window errorMsg = window.MessageBox("Error");
                return false;
            }catch (Exception e){
                return true;
            }
        }
    }
}
