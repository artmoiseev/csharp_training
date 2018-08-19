using System;
using addressbook_tests_white.models;
using NUnit.Framework;

namespace addressbook_tests_white.tests
{
    public class GroupRemovalTests : BaseTest
    {
        [Test]
        public void TestGroupRemoval()
        {
            const int indexOfGroupToDelete = 2;
            var oldGroups = app.GroupHelper.GetGroupsList();
            app.GroupHelper.RemoveGroup(indexOfGroupToDelete);
            var newGroups = app.GroupHelper.GetGroupsList();

            oldGroups.RemoveAt(indexOfGroupToDelete);
            
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}