using System;
using System.Linq;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task_7
{
    [TestFixture]
    class SideMenuTestInOneWindow
    {
        private IWebDriver driver;
        private WebDriverWait wait;

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

            int count = driver.FindElements(By.XPath("//li[@id='app-']/a")).Count();

            for (int i = 1; i <= count; i++)
            {
                driver.FindElement(By.XPath("//li[@id='app-'][" + i + "]/a")).Click();
                int count2 = driver.FindElements(By.XPath("//ul[@class='docs']//a")).Count();
                if (count2 > 0)
                {
                    for (int j = 2; j <= count2; j++)
                    {
                        driver.FindElement(By.XPath("//ul[@class='docs']/li[" + j + "]/a")).Click();
                        wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1")));
                    }
                }
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(By.CssSelector("h1")));
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
