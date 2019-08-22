using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_6.Task_11
{
    [TestFixture]
    class UserRegistration
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            driver = new ChromeDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void Registration()
        {
            driver.Url = "http://localhost/litecart/en/";
            driver.FindElement(By.CssSelector("#box-account-login tr:nth-child(5) a")).Click();

            driver.FindElement(By.CssSelector("[name=firstname]")).SendKeys("TestName");
            driver.FindElement(By.CssSelector("[name=lastname]")).SendKeys("TestLastName");
            driver.FindElement(By.CssSelector("[name=address1]")).SendKeys("Test Address");
            driver.FindElement(By.CssSelector("[name=postcode]")).SendKeys("12345");
            driver.FindElement(By.CssSelector("[name=city]")).SendKeys("Test City");
            driver.FindElement(By.CssSelector(".select2-selection")).Click();
            driver.FindElement(By.CssSelector(".select2-results li:nth-child(225)")).Click();
            //driver.FindElement(By.CssSelector("[name=zone_code] [value=AK]")).Click();
            Random random = new Random();
            int num = random.Next(1, 100_000);
            string email = "test" + num + "@example.com";
            driver.FindElement(By.CssSelector("[name=email]")).SendKeys(email);
            driver.FindElement(By.CssSelector("[name=phone]")).SendKeys("+1234-235-5678");
            driver.FindElement(By.CssSelector("[name=password]")).SendKeys("123456");
            driver.FindElement(By.CssSelector("[name=confirmed_password]")).SendKeys("123456");
            driver.FindElement(By.CssSelector("[name=create_account]")).Click();

            driver.FindElement(By.CssSelector("[name=zone_code] [value=AK]")).Click();
            driver.FindElement(By.CssSelector("[name=password]")).SendKeys("123456");
            driver.FindElement(By.CssSelector("[name=confirmed_password]")).SendKeys("123456");
            driver.FindElement(By.CssSelector("[name=create_account]")).Click();

            driver.FindElement(By.CssSelector("#box-account li:nth-child(4) a")).Click();

            driver.FindElement(By.CssSelector("[name=email]")).SendKeys(email);
            driver.FindElement(By.CssSelector("[name=password]")).SendKeys("123456");
            driver.FindElement(By.CssSelector("[name=login]")).Click();
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
