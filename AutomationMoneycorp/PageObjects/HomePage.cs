using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AutomationMoneycorp.AppUtils;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumExtras.PageObjects;


namespace AutomationMoneycorp.PageObjects
{
    public class HomePage : BasePage
    {
        #region WebElements

        private IWebElement moneycorpLogo => Driver.FindElement(By.CssSelector("div.moneycorp-logo"));

        private IWebElement languageMenu => Driver.FindElement(By.Id("nav-languages"));

        private IWebElement languageDropdown => Driver.FindElement(By.Id("language-dropdown-flag"));

        private IWebElement languageUsa => Driver.FindElement(By.CssSelector("span>img[alt='USA English']"));

        private IWebElement findOutMoreForeignExchangeBth => Driver.FindElement(By.XPath("//h3[contains(text(),'Foreign exchange solutions')]/following-sibling::a/span"));
        #endregion

        #region Constructors
        public HomePage(IWebDriver driver) : base(driver)
        {
            driver.WaitForCondition(d => moneycorpLogo.Displayed);
        }
        #endregion

        #region Methods

        public void ClickLanguageDropdown()
        {
            languageDropdown.Click();
        }

        public void SelectLanguageUsa()
        {
            Actions actions = new Actions(Driver);
            actions.ClickAndHold(languageMenu).MoveByOffset(200, -150);
            actions.Click(languageUsa);
            actions.Perform();
        }

        public ForeignExchangeSolutionPage ClickFindOutMore()
        {

            ((IJavaScriptExecutor)Driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", findOutMoreForeignExchangeBth);
            findOutMoreForeignExchangeBth.Click();
            return new ForeignExchangeSolutionPage(Driver);
        }

        #endregion
    }
}
