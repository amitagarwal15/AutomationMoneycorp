using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationMoneycorp.AppUtils;
using OpenQA.Selenium;

namespace AutomationMoneycorp.PageObjects
{
    public class SearchResultPage : BasePage
    {
        #region WebElements
        private IWebElement searchResultCaption => Driver.FindElement(By.XPath("//h2[contains(text(),'Search moneycorp')]"));

        #endregion

        #region Constructors
        public SearchResultPage(IWebDriver driver) : base(driver)
        {
            driver.WaitForCondition(d => searchResultCaption.Displayed);
        }
        #endregion

        #region Methods

        public bool VerifyArticleLinksStartsWith(string linkPrefix)
        {
            bool matched = true;

            var allLinks = Driver.FindElements(By.XPath("//div[@class='results-wrapper']//a"));
            foreach (var link in allLinks)
            {
                if (!link.GetAttribute("href").StartsWith(linkPrefix))
                {
                    matched = false;
                }
                else {
                }
            }
            return matched;
        }

        #endregion
    }
}
