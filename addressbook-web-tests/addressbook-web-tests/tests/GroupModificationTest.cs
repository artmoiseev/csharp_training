using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationTest : GroupModificationBaseTest
    {
        [Test]
        public void GroupModificationTests()
        {
            List<GroupData> groupsBefore = appManager.GroupHelper.GetGroupsList();
            var data = new GroupData(
                $"groupName{Guid.NewGuid()}",
                $"groupHeader{Guid.NewGuid()}",
                $"groupFooter{Guid.NewGuid()}");
            
            appManager.GroupHelper.EditGroup(0, data);
            appManager.NavigationHelper.ReturnToGroupsPage();
            
            List<GroupData> groupsAfter = appManager.GroupHelper.GetGroupsList();
            groupsBefore[0] = data;

            groupsAfter.Sort();
            groupsBefore.Sort();
            Assert.AreEqual(groupsBefore, groupsAfter);
        }
    }
}