namespace AirBnbUiTests.WebPage
{
    using System;
    using FrameworkBase.Selenium;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;

    public class AirBnbPage : BaseTablePage
    {
        #region PageConstructor
        String url = "https://www.airbnb.com/";

        private IWebDriver driver;

        public AirBnbPage(Browser browser, ContainerProvider provider, IWebDriver driver)
        : base(browser, provider)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Elements
        [FindsBy(How = How.CssSelector, Using = "button.f19g2zq0")]
        private IWebElement btnAnywhere;

        [FindsBy(How = How.Id, Using = "bigsearch-query-location-input")]
        private IWebElement inputWhere;

        [FindsBy(How = How.Id, Using = "bigsearch-query-location-listbox")]
        private IWebElement ddlWhere;
        #endregion

        #region Actions
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void SelectDestination(string country)
        {
            DropDown.SelectItemFromFieldByValue(ddlWhere, country);
        }

        public void 
        #endregion
    }
}
