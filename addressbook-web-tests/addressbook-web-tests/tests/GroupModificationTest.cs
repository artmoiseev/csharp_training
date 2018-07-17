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
            appManager.GroupHelper.CreateGroupIfGroupListEmpty();
            
            var data = new GroupData(
                $"groupName{Guid.NewGuid()}",
                $"groupHeader{Guid.NewGuid()}",
                $"groupFooter{Guid.NewGuid()}");
            
            appManager.GroupHelper.EditGroup(1, data);
            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}