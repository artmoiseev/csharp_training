using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationTest : GroupBaseTest
    {
        [Test]
        public void GroupModificationTests()
        {
            List<GroupData> groupsBefore = GroupData.GetAll();
            GroupData toBeModified = groupsBefore[0];
            var data = new GroupData(
                $"groupName{Guid.NewGuid()}",
                $"groupHeader{Guid.NewGuid()}",
                $"groupFooter{Guid.NewGuid()}");
            
            appManager.GroupHelper.EditGroup(toBeModified, data);
            appManager.NavigationHelper.ReturnToGroupsPage();

            List<GroupData> groupsAfter = GroupData.GetAll();

            Assert.AreEqual(groupsBefore.Count, appManager.GroupHelper.GetGroupCount());
            groupsBefore[0] = data;

            groupsAfter.Sort();
            groupsBefore.Sort();
            Assert.AreEqual(groupsBefore, groupsAfter);
        }
    }
}