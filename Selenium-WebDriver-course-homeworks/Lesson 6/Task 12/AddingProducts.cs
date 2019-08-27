using System;
using System.Reflection;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace Selenium_WebDriver_course_homeworks.Lesson_6.Task_12
{
    [TestFixture]
    class AddingProducts
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
        public void AddingProductsInAdmin()
        {
            driver.Url = "http://localhost/litecart/admin/login.php";
            driver.FindElement(By.Name("username")).SendKeys("admin");
            driver.FindElement(By.Name("password")).SendKeys("admin");
            driver.FindElement(By.Name("login")).Click();
            driver.Url = "http://localhost/litecart/admin/?app=catalog&doc=catalog";

            driver.FindElement(By.CssSelector("a.button:nth-child(2)")).Click();

            Random random = new Random();
            string num = Convert.ToString(random.Next(1, 100_000));
            string productName = "Test Product" + num;
            driver.FindElement(By.CssSelector("[name=\"name[en]\"]")).SendKeys(productName);
            driver.FindElement(By.CssSelector("[name=code]")).SendKeys(num);
            driver.FindElement(By.CssSelector("[name=\"product_groups[]\"]")).Click();
            string path2 = AppContext.BaseDirectory.Replace("\\bin\\Debug", "");
            driver.FindElement(By.CssSelector("[name=\"new_images[]\"]")).SendKeys(String.Concat(path2, "duck.jpg"));
            driver.FindElement(By.CssSelector("[href=\"#tab-information\"]")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement tabInformation = wait.Until(ExpectedConditions.ElementExists(By.Id("tab-information")));
            driver.FindElement(By.CssSelector("[name=manufacturer_id]")).Click();
            driver.FindElement(By.CssSelector("[name=manufacturer_id] option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("[name=keywords]")).SendKeys("rubber duck");
            driver.FindElement(By.CssSelector("[name=\"short_description[en]\"]")).SendKeys("Rubber duck artist");
            driver.FindElement(By.ClassName("trumbowyg-editor")).SendKeys("Rubber duck artist of high quality materials");
            driver.FindElement(By.CssSelector("[name=\"head_title[en]\"]")).SendKeys("Duck Artist");
            driver.FindElement(By.CssSelector("[name=\"meta_description[en]\"]")).SendKeys("Duck Artist");
            driver.FindElement(By.CssSelector("[href=\"#tab-prices\"]")).Click();

            IWebElement tabPrices = wait.Until(ExpectedConditions.ElementExists(By.Id("tab-prices")));
            driver.FindElement(By.CssSelector("[name=purchase_price]")).SendKeys("19");
            driver.FindElement(By.CssSelector("[name=purchase_price_currency_code]")).Click();
            driver.FindElement(By.CssSelector("[name=purchase_price_currency_code] option:nth-child(2)")).Click();
            driver.FindElement(By.CssSelector("[name=\"prices[USD]\"]")).SendKeys("19");
            driver.FindElement(By.CssSelector("[name=\"prices[EUR]\"]")).SendKeys("15");
            driver.FindElement(By.CssSelector("[name=save]")).Click();

            IList<IWebElement> productsTitle = driver.FindElements(By.CssSelector(".row.semi-transparent td:nth-child(3) a"));
            var productsTitleText = new List<string>();
            foreach (IWebElement productTitle in productsTitle)
            {
                string title = productTitle.Text;
                productsTitleText.Add(title);
            }
            Assert.Contains(productName, productsTitleText);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
