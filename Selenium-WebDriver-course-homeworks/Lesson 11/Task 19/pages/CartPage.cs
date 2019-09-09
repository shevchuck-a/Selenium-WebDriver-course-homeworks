using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    internal class CartPage : Page
    {
        public CartPage(IWebDriver driver) : base(driver) { }
        internal void DeleteProduct()
        {
            if (IsElementPresent(By.CssSelector("[name=remove_cart_item]")))
            {
                IWebElement table = driver.FindElement(By.Id("box-checkout-summary"));
                driver.FindElement(By.CssSelector("[name=remove_cart_item]")).Click();
                wait.Until(ExpectedConditions.StalenessOf(table));
            }
        }
    }
}
