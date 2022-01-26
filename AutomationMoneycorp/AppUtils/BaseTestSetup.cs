using System.Configuration;
using AutomationMoneycorp.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace AutomationMoneycorp.AppUtils
{
    public class BaseTestSetup
    {
        private readonly string _chromeDriverPath = ConfigurationManager.AppSettings["ChromeDriverPath"];
        private readonly string _baseUrl = ConfigurationManager.AppSettings["BaseUrl"];
        private readonly string _browser = ConfigurationManager.AppSettings["Browser"];

        public HomePage SetUp(IWebDriver driver)
        {
            if (_browser.Equals("Chrome"))
            {
                ChromeOptions options = new ChromeOptions();
                options.AddArguments("--disable-notifications"); // to disable notification
                driver = new ChromeDriver(_chromeDriverPath, options);
            }
            else if (_browser.Equals("Firefox"))
            {
                driver = new FirefoxDriver();
            }
            driver.Navigate().GoToUrl(_baseUrl);
            return new HomePage(driver);
        }

    }
}
