using AutomationFrameworkExample.Selenium;
using NUnit.Framework;
using SystemUnderTestExample.Pages.Login;

namespace SystemUnderTestExample.Tests
{
    // NUnit test initializer
    public class Initialization
    {
        [SetUp]
        public void Init()
        {
            var drive = new Driver();
            drive.InitializeWebDriver();
            LoginPage.GoTo();
        }

        [TearDown]
        public void Cleanup() => Driver.DriverTearDown();
    }
}
