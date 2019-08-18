using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task_9
{
    [TestFixture]
    class AlpabeticList
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        string[] countries;

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

            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector(".row"));
            //System.IO.File.WriteAllLines(@"c:\Users\Admin\Documents\GitHub\FindElements.txt", rows);
            int countCountries = rows.Count;

            for (int i = 1; i <= countCountries; i++)
            {
                string country = driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td/a")).GetAttribute("text");
                //countries[i] = country;
            }
            System.IO.File.WriteAllLines(@"c:\Users\Admin\Documents\GitHub\WriteLines.txt", countries);
            //foreach (IWebElement row in rows)
            //{
            //    string country = row.FindElement(By.XPath("//td[5]/a")).GetAttribute("text");

            //    for (int i = 0; i < countCountries; i++)
            //    {

            //        //countries[i] = country;
            //        System.IO.File.WriteAllText(@"c:\Users\Admin\Documents\GitHub\WriteText.txt", country);
            //    }
            //}

            //string[] sortedCountries = Array.Sort(countries);
            //if (sortedCountries != countries)
            //{
            //    Console.WriteLine("Countries are not sorted");   
            //}
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
