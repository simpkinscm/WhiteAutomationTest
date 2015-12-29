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
        [SetUp]
        public void Setup(){
            GlobalVar.timeouts.FindWindowTimeout = 5000;
        }

        [TearDown]
        public void CloseApp(){
            GlobalVar.application.Close();
        }

        [Test]
        public void SearchandBookFlight() {
            //Login
            LoginPage loginPage = new LoginPage();
            Assert.True(loginPage.Login("John", "HP"));
            //search
            SearchPage searchPage = new SearchPage();
            Assert.True(searchPage.SearchFlight("Portland", "Sydney", 14, "Business", 2));
            //results
            SelectFlightPage selectFlightPage = new SelectFlightPage();
            selectFlightPage.SelectFlight(0);
            //book
            BookFlightPage bookFlightPage = new BookFlightPage();
            Assert.True(bookFlightPage.bookFlight("Mike Hunt"));
        }
    }
}