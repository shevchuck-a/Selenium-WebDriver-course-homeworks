using System;
using System.Collections.Generic;
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
            //options.AddAdditionalCapability("browser", "Chrome");
            //options.AddAdditionalCapability("browser_version", "62.0");
            //options.AddAdditionalCapability("os", "Windows");
            //options.AddAdditionalCapability("os_version", "10");
            //options.AddAdditionalCapability("resolution", "1024x768");
            //options.AddAdditionalCapability("browserstack.user", "-");
            //options.AddAdditionalCapability("browserstack.key", "-");
            //options.AddAdditionalCapability("name", "Bstack-[C_sharp] Sample Test");

            //driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), options);

            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("browserName", "Chrome");
            capabilities.SetCapability("browserVersion", "62.0");
            Dictionary<string, object> browserstackOptions = new Dictionary<string, object>();
            browserstackOptions.Add("os", "Windows");
            browserstackOptions.Add("osVersion", "10");
            browserstackOptions.Add("local", "false");
            browserstackOptions.Add("seleniumVersion", "3.5.2");
            browserstackOptions.Add("userName", "bsuser52951");
            browserstackOptions.Add("accessKey", "LP8AYuT9xtLvxTzw9TBU");
            capabilities.SetCapability("bstack:options", browserstackOptions);
            driver = new RemoteWebDriver(new Uri("http://hub-cloud.browserstack.com/wd/hub/"), capabilities);

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
