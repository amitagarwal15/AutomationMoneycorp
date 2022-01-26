using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace AutomationMoneycorp.PageObjects
{
    /// <summary>
    /// <see langword="abstract" /> base class for page objects.
    /// </summary>
    public abstract class BasePage
    {
        public IWebDriver Driver { get; private set; }
        #region Constructors
        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements((ISearchContext)driver, (object)this);
        }
        #endregion

        #region Methods
        public string GetCurrentPageTitle()
        {
            return Driver.Title;
        }

        #endregion
    }
}
