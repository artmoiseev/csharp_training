using NUnit.Framework;

namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected AppManager appManager;

        [SetUp]
        public void SetupAppManager()
        {
            appManager = AppManager.GetInstaneAppManager();
        }
    }
}