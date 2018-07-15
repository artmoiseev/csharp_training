using NUnit.Framework;

namespace WebAddressBookTests
{
    class GroupRemovalTest : AuthBaseTest
    {
        [Test]
        public void RemoveGroupTest()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.RemoveGroup(1);
        }
    }
}