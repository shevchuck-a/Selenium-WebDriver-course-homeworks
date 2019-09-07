using NUnit.Framework;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    class TestBase
    {
        public Appliation app;

        [SetUp]
        public void start()
        {
            app = new Appliation();
        }

        [TearDown]
        public void stop()
        {
            app.Quit();
            app = null;
        }
    }
}
