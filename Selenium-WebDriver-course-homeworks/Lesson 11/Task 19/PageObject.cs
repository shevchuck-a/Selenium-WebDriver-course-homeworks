using NUnit.Framework;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    [TestFixture]
    class PageObject : TestBase
    {
        [Test]
        public void BuyDucks()
        {
            app.AddProductsToCart(3);
            app.DeleteFromCart(3);
        }
    }
}
