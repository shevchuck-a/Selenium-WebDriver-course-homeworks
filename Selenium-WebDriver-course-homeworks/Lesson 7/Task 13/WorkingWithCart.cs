using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_7.Task_13
{
    [TestFixture]
    class WorkingWithCart
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
        public void BuyDucks()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.ClassName("product")).Click();

            driver.FindElement(By.CssSelector("[name = add_cart_product]")).Click();
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
