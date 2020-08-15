using AutomationFrameworkExample.Helpers;
using System;
using SystemUnderTestExample.PageObjectModels.Login;
using SystemUnderTestExample.POM.Global;

namespace SystemUnderTestExample.Pages.Global
{
    public class GlobalPage : BasePage
    {
        private static GlobalPOM Repo = new GlobalPOM();
        private static LoginPOM LoginRepo = new LoginPOM();

        public static void Logout()
        {
            ClickWait(Repo.MenuBtn);
            ClickWait(Repo.MenuLogout);
        }

        public static void VerifyLogout()
        {
            Logout();

            // Confirm a login element present
            if (!IsElementPresent(LoginRepo.LoginBtn))
                throw new Exception("The login button was not present after logging out.");
        }

        public static void LogoutAndVerifySessionRemoved()
        {
            Logout();

            // Navigate to a page that should only be accessible while logged in
            GoToURL("https://www.saucedemo.com/inventory.html");

            // Confirm the page redirected the user to login
            if (!IsElementPresent(LoginRepo.LoginBtn))
                throw new Exception("The user's session was saved after logging out, " +
                    "navigating to an internal webpage did not redirect the user to login.");
        }
    }
}
