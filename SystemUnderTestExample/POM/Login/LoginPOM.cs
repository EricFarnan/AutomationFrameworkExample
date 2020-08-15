using OpenQA.Selenium;

namespace SystemUnderTestExample.PageObjectModels.Login
{
    public class LoginPOM
    {
        public By UserNameInput => By.CssSelector("#user-name");
        public By PasswordInput => By.CssSelector("#password");
        public By LoginBtn => By.CssSelector("#login-button");
        public By LockedOutMessage => By.CssSelector("h3[data-test=\"error\"]");
    }
}
