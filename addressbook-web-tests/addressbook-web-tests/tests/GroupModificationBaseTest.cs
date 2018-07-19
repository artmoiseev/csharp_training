using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationBaseTest : AuthBaseTest
    {
        [SetUp]
        public void SetUpGroup()
        {
            appManager.NavigationHelper.GoToGroupsPage();
            appManager.GroupHelper.CreateGroupIfGroupListEmpty();
        }
    }
}