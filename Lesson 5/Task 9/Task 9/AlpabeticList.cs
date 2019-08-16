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
        public void ListSortingTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Cookies.AddCookie(new Cookie("LCSESSID", "7a6rrp1vf48kp4852hk9inh92h"));
            driver.Url = "http://localhost/litecart/admin/?app=countries&doc=countries";

            ReadOnlyCollection<IWebElement> rows = driver.FindElements(By.TagName("tr"));
            int countCountries = rows.Count;

            foreach (IWebElement row in rows)
            {
                string country = row.FindElement(By.XPath("//td[5]/a")).GetAttribute("text");
                for (int i = 0; i < countCountries; i++)
                {
                    countries[i] = country;
                }
            }

        }
    }
}
