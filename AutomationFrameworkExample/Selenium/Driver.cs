using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

namespace AutomationFrameworkExample.Selenium
{
    public class Driver
    {
        [ThreadStatic] public static IWebDriver Instance;

        public IWebDriver InitializeWebDriver()
        {
            var workingDir = Directory.GetCurrentDirectory();
            var driverDir = workingDir.Substring(0, workingDir.IndexOf("AutomationFrameworkExample") + 26) + @"\AutomationFrameworkExample\Selenium\";
            
            Instance = new ChromeDriver(driverDir);
            Instance.Manage().Window.Maximize();
            return Instance;
        }

        public static void DriverTearDown() => Instance.Quit();
    }
}
