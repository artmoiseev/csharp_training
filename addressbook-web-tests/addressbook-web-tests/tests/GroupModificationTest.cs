using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupModificationTest : BaseTest
    {
        [Test]
        public void GroupModificationTests()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.
                SelectGroup(1).
                EditGroup().
                FillGroupForm(
                    new GroupData(
                        $"groupName{Guid.NewGuid()}",
                        $"groupHeader{ Guid.NewGuid()}",
                        $"groupFooter{Guid.NewGuid()}")).
                SubmitModification();

            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}
