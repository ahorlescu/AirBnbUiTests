using NUnit.Framework;
using TechTalk.SpecFlow;
using System.Xml;
using FrameworkBase;
using AirBnbUiTests.WebPage;
using OpenQA.Selenium;
using FrameworkBase.Selenium;
using OpenQA.Selenium.Chrome;

namespace AirBnbUiTests.Steps
{
    [TestFixture]
    public class AirBnbSteps
    {
        IWebDriver driver;
        AirBnbPage page;
        Browser browser;
        ContainerProvider provider;

        [SetUp]
        public void Init()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();

            page = new AirBnbPage(browser, provider, driver);
        }

        [Test]
        public void ValidateMessageIsDisplayedWhenUserEntersTextAndClickShowMessage()
        {
            

        }
    }
}
