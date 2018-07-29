using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : AuthBaseTest
    {
        [Test, TestCaseSource(nameof(RandomContactDataProvider))]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> contactListBefore = appManager.ContactHelper.GetContactList();
            
            appManager.ContactHelper.CreateNewContact(contactData);
            Assert.AreEqual(contactListBefore.Count + 1, appManager.ContactHelper.GetContactCount());
            
            contactListBefore.Add(contactData);
            List<ContactData> contactListAfter = appManager.ContactHelper.GetContactList();

            contactListBefore.Sort();
            contactListAfter.Sort();
            Assert.AreEqual(contactListAfter, contactListBefore);
        }
        
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(100)));
            }

            return contacts;
        }
    }
}