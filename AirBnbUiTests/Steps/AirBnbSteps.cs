using NUnit.Framework;
using AirBnbUiTests.WebPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using System;

namespace AirBnbUiTests.Steps
{
    [TestFixture]
    public class AirBnbSteps
    {
        IWebDriver driver;
        AirBnbPage page;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();

            page = new AirBnbPage(driver);
        }

        [Test]
        public void ValidateDestination()
        {
            #region Navigate to page
            page.GoToPage();
            Thread.Sleep(5000);
            #endregion
            #region Flow A and B
            page.ClickAnywhereButton();
            page.CheckStaysIsSelected();
            page.EnterDestination("Spain");
            Thread.Sleep(5000);
            page.SelectDestination();
            page.SelectCheckInDate();
            page.SelectCheckOutDate();
            var expectedCheckInDate = DateTime.UtcNow.Day.ToString();
            var expectedCheckOutDate = DateTime.UtcNow.AddDays(4).Day.ToString();
            var actualcheckInDate = page.GetCheckInValue();
            var actualcheckOutDate = page.GetCheckOutValue();
            StringAssert.Contains(expectedCheckInDate, actualcheckInDate, "The interval is not selected");
            StringAssert.Contains(expectedCheckOutDate, actualcheckOutDate, "The interval is not selected");
            #endregion
            #region Flow C, D and E
            page.ClickFlexibleButton();
            page.ClickWeekendButton();
            var whenTabValue = page.GetWhenTabValue();
            StringAssert.AreEqualIgnoringCase("Any Weekend", whenTabValue, "Period is not Any Weekend");
            page.ClickChooseDatesButton();
            var checkInDate = page.GetCheckInValue();
            var checkOutDate = page.GetCheckOutValue();
            StringAssert.Contains(expectedCheckInDate, checkInDate, "The interval is persisted");
            StringAssert.Contains(expectedCheckOutDate, checkOutDate, "The interval is persisted");
            #endregion
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
