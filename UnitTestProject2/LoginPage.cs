using System;
using TestStack.White;
using TestStack.White.Factory;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.WindowItems;

namespace WhiteFrameworkSandbox
{
    class LoginPage{
        static Window window = GlobalVar.application.GetWindow(SearchCriteria.ByText("HP MyFlight Sample Application"), InitializeOption.NoCache);

        TextBox usernameBox = window.Get<TextBox>("agentName");
        TextBox passwordBox = window.Get<TextBox>("password");
        Button okBtn = window.Get<Button>("okButton");

        public bool Login(String username, String password){
            usernameBox.SetValue(username);
            passwordBox.SetValue(password);
            okBtn.Click();
            try{
                Window errorMsg = window.MessageBox("Login Failed");
                return false;
            }catch (Exception e){
                return true;
            }
        }
    }
}
