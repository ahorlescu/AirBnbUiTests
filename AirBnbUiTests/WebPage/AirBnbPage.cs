namespace AirBnbUiTests.WebPage
{
    using System;
    using OpenQA.Selenium;
    using OpenQA.Selenium.Support.UI;
    using SeleniumExtras.PageObjects;

    public class AirBnbPage
    {
        #region PageConstructor
        String test_url = "https://www.airbnb.com/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public AirBnbPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }
        #endregion

        #region Elements
        [FindsBy(How = How.CssSelector, Using = "button.f19g2zq0 ")]
        private IWebElement btnAnywere;
        #endregion
    }
}
