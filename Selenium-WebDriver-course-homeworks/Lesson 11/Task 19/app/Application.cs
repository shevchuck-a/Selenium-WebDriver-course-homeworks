using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    public class Application
    {
        private IWebDriver driver;
        private WebDriverWait wait;
        private MainPage mainPage;
        private ProductPage productPage;
        private CartPage cartPage;

        public Application()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            mainPage = new MainPage(driver);
            productPage = new ProductPage(driver);
            cartPage = new CartPage(driver);
        }

        public void Quit() { driver.Quit(); }

        public void AddProductsToCart(int i)
        {
            mainPage.Open();
            for (int j = 0; j < i; j++)
            {
                mainPage.OpenProduct();
                productPage.AddToCart();
                driver.Navigate().Back();
            }
        }

        public void DeleteFromCart(int j)
        {
            mainPage.CheckoutLink.Click();
            for (int i = 0; i < j; i++)
            {
                cartPage.DeleteProduct();
            }
        }
    }
}
