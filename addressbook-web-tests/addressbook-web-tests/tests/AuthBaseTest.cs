using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AuthBaseTest : BaseTest
    {
        [SetUp]
        public void SetupLogin()
        {
            appManager.LoginHelper.Login(
                new AccountData("admin", "secret"));
        }
    }
}