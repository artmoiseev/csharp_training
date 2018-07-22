using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class GroupRemovalTest : GroupModificationBaseTest
    {
        [Test]
        public void RemoveGroupTest()
        {
            List<GroupData> groupsBefore = appManager.GroupHelper.GetGroupsList();
            appManager.GroupHelper.RemoveGroup(0);

            List<GroupData> groupsAfter = appManager.GroupHelper.GetGroupsList();
            groupsBefore.RemoveAt(0);
            Assert.AreEqual(groupsBefore, groupsAfter);
        }
    }
}