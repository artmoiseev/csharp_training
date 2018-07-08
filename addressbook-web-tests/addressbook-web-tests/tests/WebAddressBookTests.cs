using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : BaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.NavigationHelper.OpenHomePage();
            appManager.LoginHelper.Login(new AccountData("admin", "secret"));

            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.
                InitGroupCreation().
                FillGroupForm(new GroupData("df", "dg", "fddg")).
                SubmitCreation();

            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}