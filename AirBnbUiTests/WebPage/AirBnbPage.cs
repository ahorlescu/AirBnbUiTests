namespace AirBnbUiTests.WebPage
{
    using System;
    using OpenQA.Selenium;
    using SeleniumExtras.PageObjects;

    public class AirBnbPage 
    {
        #region PageConstructor
        String url = "https://www.airbnb.com/";

        private IWebDriver driver;

        public AirBnbPage(IWebDriver driver)
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

        [FindsBy(How = How.Id, Using = "search-block-tab-STAYS")]
        private IWebElement btnStays;

        [FindsBy(How = How.Id, Using = "bigsearch-query-location-suggestion-0")]
        private IWebElement firstOption;
        #endregion

        #region Actions
        public void GoToPage()
        {
            driver.Navigate().GoToUrl(url);
        }

        public void ClickAnywhereButton()
        {
            btnAnywhere.Click();
        }

        public void SelectDestination()
        {
            firstOption.Click();
        }

        public void EnterDestination(string country)
        {
            inputWhere.SendKeys(country);
        }

        public void CheckStaysIsSelected()
        {
            btnStays.GetAttribute("aria-selected").Contains("true");
        }
        #endregion
    }
}