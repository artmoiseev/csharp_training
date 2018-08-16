using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class GroupBaseTest : AuthBaseTest
    {
        public bool IsCompareUiWithDb = true;

        [TearDown]
        public void CompareGroupsFromUiWithDB()
        {
            if (!IsCompareUiWithDb) return;
            var fromUi = appManager.GroupHelper.GetGroupsList();
            var fromDb = GroupData.GetAll();
            fromUi.Sort();
            fromDb.Sort();
            Assert.AreEqual(fromUi, fromDb);
        }
    }
}