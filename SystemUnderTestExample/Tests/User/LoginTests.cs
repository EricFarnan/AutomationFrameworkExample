using NUnit.Framework;
using System;
using SystemUnderTestExample.Pages.Login;

namespace SystemUnderTestExample.Tests.User
{
    [TestFixture, Parallelizable]
    class LoginTests : Initialization
    {
        [Test, Parallelizable]
        public void Login_As_Standard_User()
        {
            try
            {
                LoginPage.LoginAsStandardUser();
                LoginPage.VerifyLoginSuccess();
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Attempt_Login_With_Incorrect_Credentials()
        {
            try
            {
                LoginPage.LoginAsStandardUser(false);
                LoginPage.VerifyInvalidLoginFailed();
            }
            catch (Exception e) { throw e; }
        }

        [Test, Parallelizable]
        public void Attempt_Login_As_Locked_User()
        {
            try
            {
                LoginPage.LoginAsLockedUser();
                LoginPage.VerifyUserIsLockedOut();
            }
            catch (Exception e) { throw e; }
        }
    }
}
