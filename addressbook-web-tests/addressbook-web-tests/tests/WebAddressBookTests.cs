using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : AuthBaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            List<GroupData> groupsBefore = appManager.GroupHelper.GetGroupsList();

            GroupData data = new GroupData(
                $"groupName{Guid.NewGuid()}",
                $"groupHeader{Guid.NewGuid()}",
                $"groupFooter{Guid.NewGuid()}");

            appManager.GroupHelper.CreateNewGroup(data);

            appManager.NavigationHelper.ReturnToGroupsPage();

            List<GroupData> groupsAfter = appManager.GroupHelper.GetGroupsList();
            Assert.AreEqual(groupsBefore.Count + 1, appManager.GroupHelper.GetGroupCount());
            groupsBefore.Add(data);
            groupsAfter.Sort();
            groupsBefore.Sort();

            Assert.AreEqual(groupsBefore, groupsAfter);
        }
    }
}