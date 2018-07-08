using NUnit.Framework;

namespace WebAddressBookTests
{
    class GroupRemovalTest : BaseTest
    {
        [Test]
        public void RemoveGroupTest()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.
                SelectGroup(1).
                RemoveGroup();
        }
    }
}