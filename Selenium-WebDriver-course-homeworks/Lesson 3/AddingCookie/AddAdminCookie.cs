using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_3.AddingCookie
{
    [TestFixture]
    class AddAdminCookie
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
            driver.Url = "http://localhost/litecart/";
            driver.Manage().Cookies.AddCookie(new Cookie("LCSESSID", "7a6rrp1vf48kp4852hk9inh92h"));
            driver.Url = "http://localhost/litecart/admin/login.php";

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TitleIs("My Store"));
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
