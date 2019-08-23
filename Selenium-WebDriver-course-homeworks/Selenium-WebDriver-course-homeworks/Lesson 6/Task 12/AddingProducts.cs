using System;
using System.Reflection;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

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

            driver.FindElement(By.CssSelector("[name=\"name[en]\"]")).SendKeys("Test Product");
            Random random = new Random();
            string num = Convert.ToString(random.Next(1, 100_000));
            driver.FindElement(By.CssSelector("[name=code]")).SendKeys(num);
            driver.FindElement(By.CssSelector("[name=\"product_groups[]\"]")).Click();

            // trying to get relative path to file
            string path = AppDomain.CurrentDomain.BaseDirectory;
            string path2 = System.AppContext.BaseDirectory;
            string path3 = Directory.GetCurrentDirectory();
            string path4 = Environment.CurrentDirectory;

            var buildDir = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string path5 = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "..\\..\\Lesson 6\\Task 11\\duck.jpg");
            //string path6 = Path.GetFullPath(Path.Combine(Application.StartupPath, "..\\.."));
            var filePath = buildDir + @"\duck.jpg";

            //string path = System.IO.Directory.GetCurrentDirectory();
            string assemblyFolder = Path.GetDirectoryName(new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath);
            DirectoryInfo directoryInfo = Directory.GetParent(path);
            DirectoryInfo directoryInfo2 = Directory.GetParent(path2);
            DirectoryInfo directoryInfo3 = Directory.GetParent(path3);
            DirectoryInfo directoryInfo4 = Directory.GetParent(path4);
            //DirectoryInfo directoryInfo2 = Directory.GetParent(directoryInfo);


            driver.FindElement(By.CssSelector("[name=\"new_images[]\"]")).SendKeys(path + "\\duck.jpg");
            driver.FindElement(By.CssSelector("[name=save]")).Click();

            driver.FindElement(By.CssSelector("name=enable")).Click();
        }
    }
}
