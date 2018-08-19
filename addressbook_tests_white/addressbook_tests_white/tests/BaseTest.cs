using addressbook_tests_white;
using NUnit.Framework;

namespace addressbook_tests_white
{
    public class BaseTest
    {
        protected AppManager app;

        [SetUp]
        public void InitApplication()
        {
            app = new AppManager();
        }

        [TearDown]
        public void StopApplication()
        {
            app.Stop();
        }
    }
}