using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    public class Appliation
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private MainPage mainPage;
        private ProductPage productPage;

        public Appliation()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            mainPage = new MainPage(driver);
            productPage = new ProductPage(driver);
        }

        public void Quit() { driver.Quit(); }

        public void AddProductsToCart(int i)
        {
            mainPage.Open();
            mainPage.OpenProduct();

            //if (IsElementPresent(By.CssSelector("[name=\"options[Size]\"]")))
            //{
            //    driver.FindElement(By.CssSelector("[name=\"options[Size]\"]")).Click();
            //    driver.FindElement(By.CssSelector("[name=\"options[Size]\"] option:nth-child(2)")).Click();
            //}
            //driver.FindElement(By.CssSelector("[name = add_cart_product]")).Click();
            productPage.AddToCart();
            //wait.Until(ExpectedConditions.Equals(was + 1, thus));


            IWebElement cart = driver.FindElement(By.CssSelector("#cart .content .quantity"));
            string count = Convert.ToString(i);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElement(cart, count));

            driver.Navigate().Back();
        }

        public void DeleteFromCart(int j)
        {
            driver.FindElement(By.CssSelector("#cart .link")).Click();

            for (int i = 0; i < j; i++)
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
    }
}
