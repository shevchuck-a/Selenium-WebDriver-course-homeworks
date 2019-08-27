using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_8.Task_14
{
    [TestFixture]
    class NavigationBetweenWindows
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
        public void NewWindowNavigation()
        {
            driver.Url = "http://localhost/litecart/admin/";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";
            //Handlers.Add("HomeWindow", driver.CurrentWindowHandle);
            string mainWindow = driver.CurrentWindowHandle;
            ICollection<string> oldWindows = driver.WindowHandles;
            driver.FindElement(By.XPath("//tr[@class='row']/td[5]/a")).Click();
            IList<IWebElement> externalLinks = driver.FindElements(By.CssSelector("form [target=_blank]"));
            foreach (var externalLink in externalLinks)
            {
                externalLink.Click();
                //var nonintersect = array2.Except(array1);
                ICollection<string> newWindows = driver.WindowHandles;
                var newWindowId = newWindows.Except(oldWindows).ToList();
                //string newWindowId = newWindow[0];
                string newWindow = wait.Until();
                driver.FindElement(By.XPath("//tr[@class='row']/td[5]/a")).Click();
            }
        }
    }
}
