using System.Configuration;
using AutomationMoneycorp.AppUtils;
using AutomationMoneycorp.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationMoneycorp.TestScripts
{
    public class MoneycorpTestFixture : BaseTestSetup
    {
        private IWebDriver Driver = null;
        private HomePage homePage;
        private readonly string _baseUrlUsa = ConfigurationManager.AppSettings["BaseUrlUsa"];
        private readonly string _pageTitleLandingPage = ConfigurationManager.AppSettings["PageTitleLandingPage"];
        private readonly string _pageTitleLocalePage = ConfigurationManager.AppSettings["PageTitleLocalePage"];
        private readonly string _pageTitleForeignExchangeSolutionPage = ConfigurationManager.AppSettings["PageTitleForeignExchangeSolutionPage"];
        private readonly string _pageTitleSearchResultPage = ConfigurationManager.AppSettings["PageTitleSearchResultPage"];
        private readonly string _textToSearch = ConfigurationManager.AppSettings["TextToSearch"];
        
        [Test]
        public void VerifyAllLinksInSearchResult()
        {
            homePage = SetUp(Driver);
            // Verify page title for landing page
            Assert.AreEqual(_pageTitleLandingPage, homePage.GetCurrentPageTitle());
            // Click language dropdown
            homePage.ClickLanguageDropdown();
            // Select USA English from language dropdown
            homePage.SelectLanguageUsa();
            // Verify page title after selecting language
            Assert.AreEqual(_pageTitleLocalePage, homePage.GetCurrentPageTitle());
            // Click find out more under foreign exchange solution
            var foreignExchangeSolutionPage = homePage.ClickFindOutMore();
            // Verify page title after clicking find out more
            Assert.AreEqual(_pageTitleForeignExchangeSolutionPage, foreignExchangeSolutionPage.GetCurrentPageTitle());
            // Search for the text
            var searchResultPage = foreignExchangeSolutionPage.SearchText(_textToSearch);
            // Verify page title after performing search
            Assert.AreEqual(_pageTitleSearchResultPage, searchResultPage.GetCurrentPageTitle());
            // Verify each article in searched result list having link starts with https://www.moneycorp.com/en-us/
            Assert.IsTrue(searchResultPage.VerifyArticleLinksStartsWith(_baseUrlUsa));
        }

        [TearDown]
        public void Teardown()
        {
            homePage.Driver.Quit();
        }
    }
}
