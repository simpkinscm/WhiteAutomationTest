using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.ListBoxItems;
using TestStack.White.UIItems.WindowItems;

namespace WhiteFrameworkSandbox{
    class BookFlightPage{
        static Window window = GlobalVar.application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);
        TextBox passengerNameBox = window.Get<TextBox>("passengerName");
        ProgressBar progBar = window.Get<ProgressBar>("progBar");
        Button orderBtn = window.Get<Button>("orderBtn");

        public bool bookFlight(String passengerName){
            passengerNameBox.SetValue(passengerName);
            orderBtn.Click();
            do{
                System.Threading.Thread.Sleep(500);
            } while (0 < progBar.Value && progBar.Value < 100);
            try {
                bool bFound = window.Get<Label>("orderCompleted").Visible;
                return true;
            }catch(Exception e) {
                return false;
            }

        }
    }
}
