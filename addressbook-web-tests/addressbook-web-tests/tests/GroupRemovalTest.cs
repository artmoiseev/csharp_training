using NUnit.Framework;

namespace WebAddressBookTests
{
    class GroupRemovalTest : GroupModificationBaseTest
    {
        [Test]
        public void RemoveGroupTest()
        {
            appManager.GroupHelper.RemoveGroup(1);
        }
    }
}