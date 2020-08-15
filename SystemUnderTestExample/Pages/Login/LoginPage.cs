using AutomationFrameworkExample.Helpers;
using NUnit.Framework;
using SystemUnderTestExample.PageObjectModels.Login;

namespace SystemUnderTestExample.Pages.Login
{
    class LoginPage : BasePage
    {
        private static LoginPOM Repo = new LoginPOM();
        private static string _password = "secret_sauce";
        public static void GoTo() => GoToURL("https://www.saucedemo.com/");

        public static void LoginAsStandardUser(bool isValid = true)
        {
            EnterText(Repo.UserNameInput, "standard_user");

            if (isValid)
                EnterText(Repo.PasswordInput, _password);
            else
                EnterText(Repo.PasswordInput, "testInvalidPassword");

            ClickWait(Repo.LoginBtn);
        }

        public static void LoginAsLockedUser()
        {
            EnterText(Repo.UserNameInput, "locked_out_user");
            EnterText(Repo.PasswordInput, _password);
            ClickWait(Repo.LoginBtn);
        }

        public static void VerifyLoginSuccess()
        {
            if (IsElementPresent(Repo.LoginBtn))
                throw new System.Exception("The login button was still visible after the user logged in.");
        }

        public static void VerifyUserIsLockedOut()
        {
            if (!IsElementPresent(Repo.LoginBtn))
                throw new System.Exception("The login button was no loger visible after the locked user attempted to log in.");

            Assert.AreEqual(GetTextFromElement(Repo.LockedOutMessage), "Epic sadface: Sorry, this user has been locked out.");
        }

        public static void VerifyInvalidLoginFailed()
        {
            if (!IsElementPresent(Repo.LoginBtn))
                throw new System.Exception("The login button was no loger visible after the user attempted to log in with incorrect credentials.");

            Assert.AreEqual(GetTextFromElement(Repo.LockedOutMessage), "Epic sadface: Username and password do not match any user in this service");
        }
    }
}
