﻿using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : BaseTest
    {
        [Test]
        public void GroupCreationTest()
        {
            appManager.NavigationHelper.GoToGroupsPage();

            appManager.GroupHelper.
                InitGroupCreation().
                FillGroupForm(
                    new GroupData(
                        $"groupName{Guid.NewGuid()}", 
                        $"groupHeader{ Guid.NewGuid()}", 
                        $"groupFooter{Guid.NewGuid()}")).
                SubmitCreation();

            appManager.NavigationHelper.ReturnToGroupsPage();
        }
    }
}