using NUnit.Framework;
using System.Diagnostics;
using TestStack.White.Factory;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.UIItems.ListBoxItems;
using System.IO;
using System;

namespace WhiteFrameworkSandbox
{
    [TestFixture]
    public class MyTests{
        Window window;

        [SetUp]
        public void LaunchandLogin(){
            //Launch App
            string applicationDirectory = TestContext.CurrentContext.TestDirectory;
            string exePath = Path.GetFullPath(applicationDirectory + "..\\..\\..\\..\\Flight Application\\Flights Application\\FlightsGUI.exe");
            var exeProcess = new ProcessStartInfo(exePath);
            Application application = Application.AttachOrLaunch(exeProcess);

            //Assign Login Window
            window = application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);

            //Login
            window.Get<TextBox>("agentName").SetValue("John");
            window.Get<TextBox>("password").SetValue("HP");
            window.Get<Button>("okButton").Click();

            //Assign App Window
            window = application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);
        }

        [TearDown]
        public void CloseApp(){
            //Close App
            window.Close();
        }

        [Test]
        public void SearchandBookFlight() {
            //search
            window.Get<ComboBox>("fromCity").Items.Select("Denver");
            window.Get<ComboBox>("toCity").Items.Select("Portland");
            window.Get<DateTimePicker>("datePicker").SetDate(new System.DateTime(2016, 1, 26), DateFormat.MonthDayYear);
            window.Get<ComboBox>("Class").Items.Select("Business");
            window.Get<Button>(SearchCriteria.ByText("FIND FLIGHTS")).Click();
            //results
            ListView results = window.Get<ListView>("flightsDataGrid");
            results.Rows[0].Cells[0].Click();
            window.Get<Button>("selectFlightBtn").Click();
            //book
            window.Get<TextBox>("passengerName").SetValue("Mike Hunt");
            window.Get<Button>("orderBtn").Click();
            //Verify
            ProgressBar progBar = window.Get<ProgressBar>("progBar");
            do
            {
                System.Threading.Thread.Sleep(500);
            } while (0 < progBar.Value && progBar.Value < 100);
            Assert.True(window.Get<Label>("orderCompleted").Visible);
        }
    }
}