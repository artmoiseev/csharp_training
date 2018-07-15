using System;
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

            appManager.GroupHelper.
                CreateNewGroup(new GroupData(
                    $"groupName{Guid.NewGuid()}", 
                    $"groupHeader{ Guid.NewGuid()}", 
                    $"groupFooter{Guid.NewGuid()}"));

            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}