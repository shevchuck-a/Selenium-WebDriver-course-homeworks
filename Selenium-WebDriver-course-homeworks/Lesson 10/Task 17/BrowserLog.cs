using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_10.Task_17
{
    [TestFixture]
    class BrowserLog
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        //Dictionary<string, string> Handlers = new Dictionary<string, string>();

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Test]
        public void BrowserLogOutput()
        {
            driver.Url = "http://localhost/litecart/admin/";
            Console.WriteLine(driver.Manage().Logs.AvailableLogTypes);
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = " http://localhost/litecart/admin/?app=catalog&doc=catalog&category_id=1";
            IList<IWebElement> products = driver.FindElements(By.XPath("//td/a[contains(.,'Duck')]"));
            int countProducts = products.Count;

            for (int i = 0; i < countProducts; i++)
            {
                products = driver.FindElements(By.XPath("//td/a[contains(.,'Duck')]"));
                products[i].Click();
                //Console.WriteLine(driver.Manage().Logs.AvailableLogTypes);
                //foreach (LogEntry l in driver.Manage().Logs.GetLog("browser"))
                //{
                //    //Assert.IsNull(l);
                //    Console.WriteLine(l);
                //}
                driver.Navigate().Back();
            }
        }
        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
