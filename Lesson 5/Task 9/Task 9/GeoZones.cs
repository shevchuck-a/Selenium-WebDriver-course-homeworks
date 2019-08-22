using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;

namespace Task_9
{
    class GeoZones
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void CountriesSortingTest()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=geo_zones&doc=geo_zones";

            IList<IWebElement> countries = driver.FindElements(By.XPath("//tr[@class='row']/td[3]/a"));
            int countCountries = countries.Count;

            for (int i = 1; i <= countCountries; i++)
            {
                driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td[3]/a")).Click();
                IList<IWebElement> zones = driver.FindElements
                    (By.CssSelector("[name $= \"[zone_code]\"]  [selected]"));
                var unsortedZones = new List<string>();
                foreach (IWebElement zone in zones)
                {
                    string zoneName = zone.GetAttribute("text");
                    unsortedZones.Add(zoneName);
                }
                var sortedZones = new List<string>();
                sortedZones.AddRange(unsortedZones.OrderBy(o => o));
                Assert.IsTrue(unsortedZones.SequenceEqual(sortedZones));
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
