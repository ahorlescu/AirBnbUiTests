namespace AirBnbUiTests.WebPage
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using FrameworkBase.Selenium;
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

        [FindsBy(How = How.CssSelector, Using = "div > div.chdozwg > div:nth-child(1)")]
        private IWebElement checkFirstDate;

        [FindsBy(How = How.CssSelector, Using = "div > div.chdozwg > div:nth-child(3)")]
        private IWebElement checkSecondDate;

        [FindsBy(How = How.CssSelector, Using = "div.v1ykbue4")]
        private IWebElement whenTab;

        [FindsBy(How = How.Id, Using = "bigsearch-query-location-input")]
        private IWebElement inputWhere;

        [FindsBy(How = How.Id, Using = "search-block-tab-STAYS")]
        private IWebElement btnStays;

        [FindsBy(How = How.Id, Using = "bigsearch-query-location-suggestion-0")]
        private IWebElement firstOption;

        [FindsBy(How = How.Id, Using = "tab--tabs--1")]
        private IWebElement btnFlexible;

        [FindsBy(How = How.Id, Using = "tab--tabs--0")]
        private IWebElement btnChooseDates;

        [FindsBy(How = How.Id, Using = "flexible_trip_lengths-weekend_trip")]
        private IWebElement btnWeekend;
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

        public void ClickFlexibleButton()
        {
            btnFlexible.Click();
        }

        public void ClickChooseDatesButton()
        {
            btnChooseDates.Click();
        }

        public void ClickWeekendButton()
        {
            btnWeekend.Click();
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

        public string GetCheckInValue()
        {
            return checkFirstDate.Text;
        }

        public string GetCheckOutValue()
        {
            return checkSecondDate.Text;
        }

        public string GetWhenTabValue()
        {
            return whenTab.Text;
        }

        public void SelectCheckInDate()
        {
            List<IWebElement> tableContent = new List<IWebElement>(driver.FindElements(By.XPath("//table[@class='_cvkwaj']//td")));

            foreach (IWebElement ele in tableContent)
            {
                string date = ele.Text;

                if (date.Equals(DateTime.UtcNow.Day.ToString()))
                {
                    ele.Click();
                    break;
                }
            }
        }

        public void SelectCheckOutDate()
        {
            List<IWebElement> tableContent = new List<IWebElement>(driver.FindElements(By.XPath("//table[@class='_cvkwaj']//td")));

            foreach (IWebElement ele in tableContent)
            {
                string date = ele.Text;

                if (date.Equals(DateTime.UtcNow.AddDays(4).Day.ToString()))
                {
                    ele.Click();
                    break;
                }
            }
        }
        #endregion
    }
}