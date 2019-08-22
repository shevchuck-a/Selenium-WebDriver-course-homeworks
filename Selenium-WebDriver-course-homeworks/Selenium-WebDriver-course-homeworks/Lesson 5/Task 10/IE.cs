using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;

namespace Selenium_WebDriver_course_homeworks.Lesson_5.Task_10
{
    [TestFixture]
    class IE
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [SetUp]
        public void Start()
        {
            driver = new InternetExplorerDriver();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [Test]
        public void ProductTest()
        {
            driver.Url = "http://localhost/litecart/en/";

            //values for comparing with values from product page
            string title = driver.FindElement(By.CssSelector("#box-campaigns .name")).GetAttribute("textContent");
            string price = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetAttribute("textContent");
            string priceStyle = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).TagName;
            string regularPrice = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetAttribute("textContent");
            string regularPriceStyle = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).TagName;

            //check that Price color is red (G and B from RGB are equal 0)
            string priceColourData = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("color");
            String[] hexPriceColour = priceColourData.Replace("rgba(", "").Replace(")", "").Split(',');
            int hexPriceColour2 = Convert.ToInt32(hexPriceColour[1]);
            int hexPriceColour3 = Convert.ToInt32(hexPriceColour[2]);
            Assert.AreEqual(0, hexPriceColour2);
            Assert.AreEqual(0, hexPriceColour3);

            //check that Regular Price is gray (RGB values are equal)
            string regularPriceColourData = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("color");
            String[] hexRegularPriceColour = regularPriceColourData.Replace("rgba(", "").Replace(")", "").Split(',');
            int hexRegularPriceColour1 = Convert.ToInt32(hexRegularPriceColour[0]);
            int hexRegularPriceColour2 = Convert.ToInt32(hexRegularPriceColour[1]);
            int hexRegularPriceColour3 = Convert.ToInt32(hexRegularPriceColour[2]);
            Assert.AreEqual(hexRegularPriceColour1, hexRegularPriceColour2);
            Assert.AreEqual(hexRegularPriceColour1, hexRegularPriceColour3);

            //check that font size of Regular Prise is less than 1
            string regularPriseData = driver.FindElement(By.CssSelector("#box-campaigns .regular-price")).GetCssValue("font-size");
            Convert.ToDouble(regularPriseData.Replace("px", ""));
            string priseData = driver.FindElement(By.CssSelector("#box-campaigns .campaign-price")).GetCssValue("font-size");
            Convert.ToDouble(priseData.Replace("px", ""));
            Assert.Greater(priseData, regularPriseData);

            //
            driver.FindElement(By.CssSelector("#box-campaigns .link")).Click();

            string productTitle = driver.FindElement(By.CssSelector("h1")).GetAttribute("textContent");
            Assert.AreEqual(title, productTitle);

            string productPrice = driver.FindElement(By.CssSelector(".campaign-price")).GetAttribute("textContent");
            Assert.AreEqual(price, productPrice);

            string productPriceStyle = driver.FindElement(By.CssSelector(".campaign-price")).TagName;
            Assert.AreEqual(priceStyle, productPriceStyle);

            string productRegularPrice = driver.FindElement(By.CssSelector(".regular-price")).GetAttribute("textContent");
            Assert.AreEqual(regularPrice, productRegularPrice);

            string productRegularPriceStyle = driver.FindElement(By.CssSelector(".regular-price")).TagName;
            Assert.AreEqual(regularPriceStyle, productRegularPriceStyle);

            //check that Price color on Product page is red (G and B from RGB are equal 0)
            string productPriceColourData = driver.FindElement(By.CssSelector(".campaign-price")).GetCssValue("color");
            String[] hexProductPriceColour = productPriceColourData.Replace("rgba(", "").Replace(")", "").Split(',');
            int hexProductPriceColour2 = Convert.ToInt32(hexProductPriceColour[1]);
            int hexProductPriceColour3 = Convert.ToInt32(hexProductPriceColour[2]);
            Assert.AreEqual(0, hexProductPriceColour2);
            Assert.AreEqual(0, hexProductPriceColour3);

            //check that Regular Price on Product page is gray (RGB values are equal)
            string productRegularPriceColourData = driver.FindElement(By.CssSelector(".regular-price")).GetCssValue("color");
            String[] hexProductRegularPriceColour = productRegularPriceColourData.Replace("rgba(", "").Replace(")", "").Split(',');
            int hexProductRegularPriceColour1 = Convert.ToInt32(hexProductRegularPriceColour[0]);
            int hexProductRegularPriceColour2 = Convert.ToInt32(hexProductRegularPriceColour[1]);
            int hexProductRegularPriceColour3 = Convert.ToInt32(hexProductRegularPriceColour[2]);
            Assert.AreEqual(hexProductRegularPriceColour1, hexProductRegularPriceColour2);
            Assert.AreEqual(hexProductRegularPriceColour1, hexProductRegularPriceColour3);

            //check that font size of Regular Prise on Product page is less than 1
            string productRegularPriseData = driver.FindElement(By.CssSelector(".regular-price")).GetCssValue("font-size");
            Convert.ToDouble(productRegularPriseData.Replace("px", ""));
            string productPriseData = driver.FindElement(By.CssSelector(".campaign-price")).GetCssValue("font-size");
            Convert.ToDouble(productPriseData.Replace("px", ""));
            Assert.Greater(productPriseData, productRegularPriseData);
        }

        [TearDown]
        public void stop()
        {
            driver.Quit();
            driver = null;
        }
    }
}
