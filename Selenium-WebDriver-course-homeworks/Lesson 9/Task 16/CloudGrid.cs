using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;

namespace Selenium_WebDriver_course_homeworks.Lesson_9.Task_16
{
    [TestFixture]
    public class BrowserStackNUnitTest
    {
        [Test]
        public void Browserstack()
        {
            IWebDriver driver;
            ChromeOptions options = new ChromeOptions();
            options.AddAdditionalCapability("browser", "Chrome");
            options.AddAdditionalCapability("browser_version", "62.0");
            options.AddAdditionalCapability("os", "Windows");
            options.AddAdditionalCapability("os_version", "10");
            options.AddAdditionalCapability("resolution", "1024x768");
            options.AddAdditionalCapability("browserstack.user", "-");
            options.AddAdditionalCapability("browserstack.key", "-");
            options.AddAdditionalCapability("name", "Bstack-[C_sharp] Sample Test");

            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), options);
            driver.Navigate().GoToUrl("http://www.google.com");
            Console.WriteLine(driver.Title);

            IWebElement query = driver.FindElement(By.Name("q"));
            query.SendKeys("Browserstack");
            query.Submit();
            Console.WriteLine(driver.Title);

            driver.Quit();
        }
    }
}
