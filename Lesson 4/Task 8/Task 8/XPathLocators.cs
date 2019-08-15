using System;
using System.Collections.ObjectModel;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
namespace Task_7
{
    [TestFixture]
    class XPathLocators
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
        public void ProductStickers()
        {
            driver.Url = "http://localhost/litecart/en/";
            ReadOnlyCollection<IWebElement> products = driver.FindElements(By.ClassName("product"));

            foreach (IWebElement product in products)
            {
                var sticker = driver.FindElements(By.ClassName("sticker"));
                if(sticker.Count != 1)
                {
                    Console.WriteLine("Count of stickers != 1");
                }
            }

        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
