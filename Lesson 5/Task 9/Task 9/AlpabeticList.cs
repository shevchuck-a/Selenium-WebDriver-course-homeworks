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
                int countZones = Convert.ToInt32(enabledZones);
                var unsortedZones = new List<string>();
                if (countZones != 0)
                {
                    driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td[5]/a")).Click();
                    //IList<IWebElement> zones = driver.FindElements(By.XPath("//table[@id='table-zones']//td[3]/input"));
                    //int countZones = zones.Count;
                    for (int j = 2; j <= ++countZones; j++)
                    {
                        string zone = driver.FindElement
                            (By.XPath("//table[@id='table-zones']//tr[" + i + "]/td[3]/input")).GetAttribute("value");
                        unsortedZones.Add(zone);
                    }
                    var sortedZones = new List<string>();
                    sortedZones.AddRange(unsortedZones.OrderBy(o => o));
                    Assert.IsTrue(unsortedZones.SequenceEqual(sortedZones));

                }
            }


            //ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.CssSelector(".row"));
            ////System.IO.File.WriteAllLines(@"c:\Users\Admin\Documents\GitHub\FindElements.txt", rows);
            //int countCountries = rows.Count;

            //for (int i = 1; i <= countCountries; i++)
            //{
            //    string country = driver.FindElement(By.XPath("//tr[@class='row'][" + i + "]/td/a")).GetAttribute("text");
            //    //countries[i] = country;
            //}
            //System.IO.File.WriteAllLines(@"c:\Users\Admin\Documents\GitHub\WriteLines.txt", countries);


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
