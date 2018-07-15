using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationTest : AuthBaseTest
    {
        [Test]
        public void GroupModificationTests()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.EditGroup(1, new GroupData(
                $"groupName{Guid.NewGuid()}",
                $"groupHeader{Guid.NewGuid()}",
                $"groupFooter{Guid.NewGuid()}"));

            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}