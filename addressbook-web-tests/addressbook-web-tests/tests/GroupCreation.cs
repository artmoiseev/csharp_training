using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : AuthBaseTest
    {
        [Test, TestCaseSource(nameof(RandomGroupDataProvider))]
        public void GroupCreationTest(GroupData data)
        {
            appManager.NavigationHelper.GoToGroupsPage();

            List<GroupData> groupsBefore = appManager.GroupHelper.GetGroupsList();

            appManager.GroupHelper.CreateNewGroup(data);

            appManager.NavigationHelper.ReturnToGroupsPage();

            List<GroupData> groupsAfter = appManager.GroupHelper.GetGroupsList();
            Assert.AreEqual(groupsBefore.Count + 1, appManager.GroupHelper.GetGroupCount());
            groupsBefore.Add(data);
            groupsAfter.Sort();
            groupsBefore.Sort();

            Assert.AreEqual(groupsBefore, groupsAfter);
        }

        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 5; i++)
            {
                groups.Add(
                    new GroupData(GenerateRandomString(30), GenerateRandomString(100), GenerateRandomString(100)));
            }

            return groups;
        }
    }
}