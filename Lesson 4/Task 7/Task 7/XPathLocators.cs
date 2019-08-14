using System;
using System.Collections.ObjectModel;
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

        [SetUp]
        public void start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void SideMenuTest()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.Manage().Cookies.DeleteAllCookies();
            driver.Manage().Cookies.AddCookie(new Cookie("LCSESSID", "7a6rrp1vf48kp4852hk9inh92h"));
            driver.Url = "http://localhost/litecart/admin/";

            //driver.FindElements(By.XPath("//ul[@id='box-apps-menu']//a"));

            ReadOnlyCollection<IWebElement> links = driver.FindElements(By.XPath("//ul[@id='box-apps-menu']//a"));

            foreach (IWebElement link in links)
            {
                link.SendKeys(Keys.Control + Keys.Enter);
                //driver.SwitchTo().Window(driver.WindowHandles);
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1")));
                driver.Navigate().Back();
            }

            //driver.FindElement(By.XPath("//span[text()='Appearence']/..")).Click();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement
            //    (driver.FindElement(By.CssSelector("h1")), "Template"));

            //driver.FindElement(By.XPath("//span[text()='Logotype']/..")).Click();
            //wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElement
            //    (driver.FindElement(By.CssSelector("h1")), "Logotype"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
