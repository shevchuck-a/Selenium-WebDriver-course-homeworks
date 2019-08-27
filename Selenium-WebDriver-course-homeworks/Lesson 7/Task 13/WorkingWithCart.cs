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
            driver.Url = "https://litecart.stqa.ru/en/";
            for (int i = 1; i < 4; i++)
            {
                driver.FindElement(By.ClassName("product")).Click();

                
                if (IsElementPresent(By.CssSelector("[name=\"options[Size]\"]")))
                {
                    driver.FindElement(By.CssSelector("[name=\"options[Size]\"]")).Click();
                    driver.FindElement(By.CssSelector("[name=\"options[Size]\"] option:nth-child(2)")).Click();
                }
                driver.FindElement(By.CssSelector("[name = add_cart_product]")).Click();
                IWebElement cart = driver.FindElement(By.CssSelector("#cart .content .quantity"));
                string count = Convert.ToString(i);
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(ExpectedConditions.TextToBePresentInElement(cart, count));

                driver.Navigate().Back();
                Console.WriteLine(i);
            }
            driver.FindElement(By.CssSelector("#cart .link")).Click();

            if (IsElementPresent(By.CssSelector("[name=remove_cart_item]")))
            {
                IWebElement table = driver.FindElement(By.Id("box-checkout-summary"));
                driver.FindElement(By.CssSelector("[name=remove_cart_item]")).Click();
                wait.Until(ExpectedConditions.StalenessOf(table));
            }

        }

        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
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
