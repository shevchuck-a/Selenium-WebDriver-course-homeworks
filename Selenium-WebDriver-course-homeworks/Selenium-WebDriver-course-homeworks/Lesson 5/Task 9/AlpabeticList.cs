using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections;
namespace Selenium_WebDriver_course_homeworks.Lesson_5.Task_9
{
    [TestFixture]
    class AlpabeticList
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
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            //Test of alphabetical order of Countries
            ArrayList text = new ArrayList();
            IList<IWebElement> countries = driver.FindElements(By.XPath("//tr[@class='row']/td[5]/a"));
            int countCountries = countries.Count;
            var unsortedCountries = new List<string>();

            for (int i = 1; i <= countCountries; i++)
            {
                string country = driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td/a"))
                    .GetAttribute("text");
                unsortedCountries.Add(country);
            }

            var sortedCountries = new List<string>();
            sortedCountries.AddRange(unsortedCountries.OrderBy(o => o));
            Assert.IsTrue(unsortedCountries.SequenceEqual(sortedCountries));

            //Test of alphabetical order of Countrie's zones
            for (int i = 1; i <= countCountries; i++)
            {
                string enabledZones = driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td[6]"))
                    .GetAttribute("textContent");
                var unsortedZones = new List<string>();
                if (enabledZones != "0")
                {
                    driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td[5]/a")).Click();
                    IList<IWebElement> zones = driver.FindElements(By.XPath("//table[@id='table-zones']//td[3]/input"));
                    int countZones = zones.Count;
                    for (int j = 2; j <= countZones; j++)
                    {
                        string zone = driver.FindElement
                            (By.XPath("//table[@id='table-zones']//tr[" + j + "]/td[3]/input")).GetAttribute("value");
                        unsortedZones.Add(zone);
                    }
                    var sortedZones = new List<string>();
                    sortedZones.AddRange(unsortedZones.OrderBy(o => o));
                    Assert.IsTrue(unsortedZones.SequenceEqual(sortedZones));
                    driver.Navigate().Back();
                }
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
