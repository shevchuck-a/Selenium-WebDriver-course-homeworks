using NUnit.Framework;

namespace Selenium_WebDriver_course_homeworks.Lesson_11.Task_19
{
    class TestBase
    {
        public Application app;

        [SetUp]
        public void start()
        {
            app = new Application();
        }

        [TearDown]
        public void stop()
        {
            app.Quit();
            app = null;
        }
    }
}
