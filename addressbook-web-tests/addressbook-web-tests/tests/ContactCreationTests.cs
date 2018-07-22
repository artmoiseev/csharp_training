using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : AuthBaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            ContactData contactData = new ContactData(
                $"username{Guid.NewGuid()}",
                $"userlastName{Guid.NewGuid()}");
            
            List<ContactData> contactListBefore = appManager.ContactHelper.GetContactList();
            
            appManager.ContactHelper.CreateNewContact(contactData);
            contactListBefore.Add(contactData);
            
            List<ContactData> contactListAfter = appManager.ContactHelper.GetContactList();
            
            contactListAfter.Sort();
            contactListBefore.Sort();
            Assert.AreEqual(contactListAfter, contactListBefore);
        }
    }
}