using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
//using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_2.Exercise_1
{
    [TestFixture]
    class FirstUnitTest
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
        public void FirstTest()
        {
            driver.Url = "http://www.google.com/";
            driver.FindElement(By.Name("q")).SendKeys("webdriver");
            //driver.FindElement(By.Name("btnG")).Click();
            driver.FindElement(By.Name("q")).SendKeys(Keys.Enter);
            wait.Until(ExpectedConditions.TitleIs("webdriver - Пошук Google"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
