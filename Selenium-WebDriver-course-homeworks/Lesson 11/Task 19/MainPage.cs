using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    internal class MainPage : Page
    {
        public MainPage(IWebDriver driver) : base(driver) { }

        internal MainPage Open()
        {
            driver.Url = "https://litecart.stqa.ru/en/";
            return this;
        }
    }
}
