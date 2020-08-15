using NUnit.Framework;
using System;
using SystemUnderTestExample.Pages.Global;
using SystemUnderTestExample.Pages.Login;

namespace SystemUnderTestExample.Tests.User
{
    [TestFixture, Parallelizable]
    class LogoutTests : Initialization
    {
        [Test, Parallelizable]
        public void Logout()
        {
            try
            {
                LoginPage.LoginAsStandardUser();
                GlobalPage.VerifyLogout();
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Confirm_Session_Removed_After_Logout()
        {
            try
            {
                LoginPage.LoginAsStandardUser();
                GlobalPage.LogoutAndVerifySessionRemoved();
            }
            catch (Exception e) { throw e; }
        }
    }
}
