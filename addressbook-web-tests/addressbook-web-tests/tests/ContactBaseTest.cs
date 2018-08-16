using NUnit.Framework;

namespace WebAddressBookTests
{
    public class  ContactBaseTest : AuthBaseTest
    {
        public bool IsCompareUiWithDb = true;

        [TearDown]
        public void CompareGroupsFromUiWithDB()
        {
            if (!IsCompareUiWithDb) return;
            var fromUi = appManager.ContactHelper.GetContactList();
            var fromDb = ContactData.GetAll();
            fromUi.Sort();
            fromDb.Sort();
            Assert.AreEqual(fromUi, fromDb);
        }
    }
}