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
            appManager.NavigationHelper.OpenHomePage();
            appManager.LoginHelper.Login(new AccountData("admin", "secret"));
        }

        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
    }
}