using System;
using System.Collections.Generic;
using addressbook_tests_white.models;
using NUnit.Framework;
using TestStack.White;
using System.Diagnostics;
using Debug = System.Diagnostics.Debug;


namespace addressbook_tests_white.tests
{
    public class GroupCreationTests : BaseTest
    {
        [Test]
        public void TestGroupCreation()
        {
            var oldGroups = app.GroupHelper.GetGroupsList();
            var newGroup = new GroupData
            {
                GroupName = $"{Guid.NewGuid()}"
            };
            app.GroupHelper.Add(newGroup);
            var newGroups = app.GroupHelper.GetGroupsList();
            oldGroups.Add(newGroup);
            
            oldGroups.Sort();
            newGroups.Sort();
            
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}