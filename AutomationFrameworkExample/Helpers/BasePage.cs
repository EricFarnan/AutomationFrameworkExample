using AutomationFrameworkExample.Selenium;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace AutomationFrameworkExample.Helpers
{
    // Framework host for common driver commands
    public class BasePage
    {
        #region Waits
        public static void WaitForVisible(By place)
        {
            try
            {
                var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(45));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(place));
            }
            catch
            {
                throw new Exception($"Timed out after 45 seconds waiting for element to be visible: {place}");
            }
        }

        public static void WaitForPageLoad()
        {
            // Grab the current page source, wait 500 ms and grab it again
            // If the page sources are equal then the page is done loading
            var attempts = 0;

            var originalPageSource = Driver.Instance.PageSource;
            SleepFor(1000);

            while (originalPageSource != Driver.Instance.PageSource && attempts != 30)
            {
                SleepFor(1000);
                originalPageSource = Driver.Instance.PageSource;
                attempts++;
            }
        }

        public static void SleepFor(int milliseconds) => System.Threading.Thread.Sleep(milliseconds);
        #endregion

        #region Clicks
        public static void Click(By place) => GetElement(place).Click();

        public static void ClickWait(By place)
        {
            WaitForVisible(place);
            Click(place);
            WaitForPageLoad();
        }

        public static void ClickWaitElement(IWebElement element)
        {
            element.Click();
            WaitForPageLoad();
        }

        public static void ClickWaitIndexed(By place, int index)
        {
            var elements = GetElements(place);
            elements[index].Click();
            WaitForPageLoad();
        }
        #endregion

        #region Data Entry
        public static void EnterText(By place, string text, bool clearText = false)
        {
            WaitForVisible(place);

            if (clearText)
                GetElement(place).Clear();

            GetElement(place).SendKeys(text);
        }

        public static void SelectDropDown(By place, string text)
        {
            var form = new SelectElement(GetElement(place));
            form.SelectByText(text);
        }
        #endregion

        #region Data Retrieval
        public static string GetTextFromElement(By place)
        {
            WaitForVisible(place);
            return GetElement(place).Text;
        }

        public static List<string> GetTextFromElements(By place)
        {
            WaitForVisible(place);
            var elements = GetElements(place);

            List<string> elementsText = new List<string>();

            foreach (IWebElement element in elements)
                elementsText.Add(element.Text);

            return elementsText;
        }

        public static string GetValueFromElement(By place) => GetElement(place).GetAttribute("value");
        #endregion

        #region Data Validation
        public static bool IsElementPresent(By place)
        {
            try
            {
                GetElement(place);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        public static bool ValidateText(By place, string text)
        {
            var elementText = GetTextFromElement(place);
            return elementText.ToUpper().Contains(text.ToUpper());
        }
        #endregion

        #region Element Retrieval
        public static IWebElement GetElement(By place) => Driver.Instance.FindElement(place);
        public static System.Collections.ObjectModel.ReadOnlyCollection<IWebElement> GetElements(By place) => Driver.Instance.FindElements(place);

        #endregion

        #region URLs/Page
        public static void GoToURL(string url) => Driver.Instance.Navigate().GoToUrl(url);

        public static void Refresh() => Driver.Instance.Navigate().Refresh();
        #endregion
    }
}
