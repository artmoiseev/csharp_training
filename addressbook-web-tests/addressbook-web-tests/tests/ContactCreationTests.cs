using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            Assert.AreEqual(contactListBefore.Count + 1, appManager.ContactHelper.GetContactCount());
            
            contactListBefore.Add(contactData);
            List<ContactData> contactListAfter = appManager.ContactHelper.GetContactList();

            contactListBefore.Sort();
            contactListAfter.Sort();
            Assert.AreEqual(contactListAfter, contactListBefore);
        }
    }
}