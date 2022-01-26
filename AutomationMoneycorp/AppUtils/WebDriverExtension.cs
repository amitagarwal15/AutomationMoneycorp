using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationMoneycorp.AppUtils
{
    public static class WebDriverExtension
    {
        /// <summary>
        /// Waits until element is displayed.
        /// It calls GetExplicitWait to get the maximum waiting time.
        /// </summary>
        /// <param name="driver">This <see cref="T:OpenQA.Selenium.IWebDriver" />.</param>
        /// <param name="by"></param>
        /// <returns>IWebElement</returns>
        public static IWebElement WaitUntilElementIsDisplayed(this IWebDriver driver, By by)
        {
            WebDriverWait explicitWait = driver.GetExplicitWait();
            try
            {
                explicitWait.Until<bool>((Func<IWebDriver, bool>)(drv => drv.DoesElementExist(by) && drv.FindElement(by).Displayed));
                return driver.FindElement(by);
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebDriverTimeoutException(string.Format("Timed out after {0} seconds waiting for element '{1}' to be displayed.", (object)explicitWait.Timeout.TotalSeconds, (object)by), (Exception)ex);
            }
        }

        /// <summary>
        /// Gets the maximum explicit timeout 120 seconds.
        /// </summary>
        /// <param name="driver">This <see cref="T:OpenQA.Selenium.IWebDriver" />.</param>
        /// <returns><see cref="T:OpenQA.Selenium.Support.UI.WebDriverWait" /></returns>
        public static WebDriverWait GetExplicitWait(this IWebDriver driver)
        {
            WebDriverWait explicitWait = new WebDriverWait(driver, TimeSpan.FromSeconds(120));
            explicitWait.IgnoreExceptionTypes(new Type[1]
            {
                typeof (StaleElementReferenceException)
            });
            return explicitWait;
        }

        /// <summary>Returns whether an element exists or not.</summary>
        /// <param name="driver">This <see cref="T:OpenQA.Selenium.IWebDriver" />.</param>
        /// <param name="by"></param>
        /// <returns>true is element exists; otherwise, return false.</returns>
        public static bool DoesElementExist(this IWebDriver driver, By by)
        {
            bool flag;
            try
            {
                flag = (uint)driver.FindElements(by).Count > 0U;
            }
            catch (NullReferenceException ex)
            {
                flag = (uint)driver.FindElements(by).Count > 0U;
            }
            return flag;
        }

        /// <summary>Waits for a given condition to evaluate to true.</summary>
        /// <param name="driver">This <see cref="T:OpenQA.Selenium.IWebDriver" />.</param>
        /// <param name="condition"></param>
        /// <param name="description"></param>
        /// <exception cref="T:OpenQA.Selenium.WebDriverTimeoutException"></exception>
        public static void WaitForCondition(
            this IWebDriver driver,
            Func<IWebDriver, bool> condition,
            string description = null)
        {
            WebDriverWait explicitWait = driver.GetExplicitWait();
            try
            {
                explicitWait.Until<bool>(condition);
            }
            catch (WebDriverTimeoutException ex)
            {
                throw new WebDriverTimeoutException(string.Format("Timed out after {0} seconds waiting for condition '{1}'", (object)explicitWait.Timeout.TotalSeconds, (object)(description ?? condition.ToString())), (Exception)ex);
            }
        }
    }
}
