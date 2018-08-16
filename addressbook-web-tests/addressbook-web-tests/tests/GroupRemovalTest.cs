using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class GroupRemovalTest : GroupModificationBaseTest
    {
        [Test]
        public void RemoveGroupTest()
        {
            List<GroupData> groupsBefore = GroupData.GetAll();
            GroupData toBeRemoved = groupsBefore[0];
            appManager.GroupHelper.RemoveGroup(toBeRemoved);

            List<GroupData> groupsAfter = GroupData.GetAll();
            Assert.AreEqual(groupsBefore.Count - 1, appManager.GroupHelper.GetGroupCount());
            groupsBefore.RemoveAt(0);
            Assert.AreEqual(groupsBefore, groupsAfter);
        }
    }
}