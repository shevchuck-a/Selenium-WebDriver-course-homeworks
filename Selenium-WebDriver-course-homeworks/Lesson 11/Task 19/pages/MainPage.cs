using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver) { PageFactory.InitElements(driver, this); }

        public MainPage Open()
        {
            driver.Url = "https://litecart.stqa.ru/en/";
            return this;
        }

        internal void OpenProduct()
        {
            driver.FindElement(By.ClassName("product")).Click();
            wait.Until(d => d.FindElement(By.CssSelector("[name = add_cart_product]")));
        }

        [FindsBy(How = How.CssSelector, Using = "#cart .link")]
        internal IWebElement CheckoutLink;
    }
}
