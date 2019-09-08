using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    internal class ProductPage :Page
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        private int CheckCartCount()
        {
            IWebElement cart = driver.FindElement(By.CssSelector("#cart .content .quantity"));
            int count = Convert.ToInt32(cart.GetAttribute("textContent"));
            return count;
        }

        internal void AddToCart()
        {
            int was = CheckCartCount();
            if (IsElementPresent(By.CssSelector("[name=\"options[Size]\"]")))
            {
                driver.FindElement(By.CssSelector("[name=\"options[Size]\"]")).Click();
                driver.FindElement(By.CssSelector("[name=\"options[Size]\"] option:nth-child(2)")).Click();
            }
            driver.FindElement(By.CssSelector("[name = add_cart_product]")).Click();
            int thus = CheckCartCount();
            //wait.Until(d => d.)
            //wait.Until(ExpectedConditions.Equals(was + 1, thus));
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
