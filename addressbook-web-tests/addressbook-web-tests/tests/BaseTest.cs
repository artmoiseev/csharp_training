using NUnit.Framework;

namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected AppManager appManager;

        [SetUp]
        public void SetupTest()
        {
            appManager = new AppManager();
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
    }
}