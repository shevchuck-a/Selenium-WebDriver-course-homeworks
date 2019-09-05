using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using RemoteBrowserMobProxy;

namespace Selenium_WebDriver_course_homeworks.Lesson_9.Task_17
{
    [TestFixture]
    class Proxy
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void start()
        {
            Proxy proxy = new Proxy();
            //proxy.Kind = ProxyKind.Manual;
            //proxy.HttpProxy = "localhost:8888";
            //ChromeOptions options = new ChromeOptions();
            //options.Proxy = proxy;
            proxy.
            //IWebDriver driver = new ChromeDriver(options);
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
