using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationMoneycorp.AppUtils;
using OpenQA.Selenium;

namespace AutomationMoneycorp.PageObjects
{
    public class ForeignExchangeSolutionPage : BasePage
    {

        #region WebElements

        private IWebElement foreignExchangeSolutionCaption => Driver.FindElement(By.XPath("//h1[contains(text(),'Foreign exchange solutions for your business')]"));

        private IWebElement searchIcon => Driver.FindElement(By.CssSelector("button.navigation-search.icon"));
        private IWebElement searchField => Driver.FindElement(By.Id("nav_search"));


        #endregion

        #region Constructors
        public ForeignExchangeSolutionPage(IWebDriver driver) : base(driver)
        {
            driver.WaitForCondition(d => foreignExchangeSolutionCaption.Displayed);
        }
        #endregion

        #region Methods

        public void ClickSearchIcon()
        {
            searchIcon.Click();
        }

        public void EnterSearchText(string searchText)
        {
            searchField.Click();
            searchField.SendKeys(searchText);
        }

        public SearchResultPage SearchText(string searchText)
        {
            ClickSearchIcon();
            EnterSearchText(searchText);
            searchField.SendKeys(Keys.Enter);
            return new SearchResultPage(Driver);
        }

        #endregion
    }
}
