using NUnit.Framework;
using AirBnbUiTests.WebPage;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

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
            page.GoToPage();
            Thread.Sleep(5000);
            page.ClickAnywhereButton();
            page.CheckStaysIsSelected();
            page.EnterDestination("Spain");
            page.SelectDestination();
        }

        [TearDown]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
