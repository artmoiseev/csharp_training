using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationBaseTest : GroupBaseTest
    {
        [SetUp]
        public void SetUpGroup()
        {
            appManager.NavigationHelper.GoToGroupsPage();
            appManager.GroupHelper.CreateGroupIfGroupListEmpty();
        }
    }
}