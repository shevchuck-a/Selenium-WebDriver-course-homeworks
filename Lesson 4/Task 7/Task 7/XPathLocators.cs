using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task_7
{
    [TestFixture]
    class XPathLocators
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        Dictionary<string, string> Handlers = new Dictionary<string, string>();

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
        }

        [Test]
        public void SideMenuTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Cookies.AddCookie(new Cookie("LCSESSID", "7a6rrp1vf48kp4852hk9inh92h"));
            driver.Url = "http://localhost/litecart/admin/";
            Handlers.Add("HomeWindow", driver.CurrentWindowHandle);

            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']//a"));

            foreach (IWebElement link in links)
            {
                link.SendKeys(Keys.Control + Keys.Enter);
                driver.SwitchTo().Window(driver.WindowHandles.Last());
                Handlers.Add("SubMenuindow" + link, driver.CurrentWindowHandle);

                ReadOnlyCollection<IWebElement> sublinks = 
                    driver.FindElements(By.XPath("//ul[@class='docs']/li[not(contains(@class,'selected'))]/a"));
                foreach (IWebElement sublink in sublinks)
                {
                    sublink.SendKeys(Keys.Control + Keys.Enter);
                    driver.SwitchTo().Window(driver.WindowHandles.Last());

                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1")));

                    driver.Close();
                    driver.SwitchTo().Window(Handlers["SubMenuindow" + link]);
                }

                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1")));

                driver.Close();
                driver.SwitchTo().Window(Handlers["HomeWindow"]);
            }   //(driver.FindElement(By.CssSelector("h1")), "Logotype"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
