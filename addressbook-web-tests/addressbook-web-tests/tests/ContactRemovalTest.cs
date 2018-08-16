using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactRemovalTest : ContactModificationBaseTest
    {
        [Test]
        public void RemoveContactTest()
        {
            var contactListBefore = ContactData.GetAll();

            var contactToRemove = contactListBefore[0];
            appManager.ContactHelper.RemoveContact(contactToRemove);

            var contactListAfter = ContactData.GetAll();
            Assert.AreEqual(contactListBefore.Count - 1, appManager.ContactHelper.GetContactCount());
            contactListBefore.Remove(contactToRemove);
            
            contactListBefore.Sort(); 
            contactListAfter.Sort();
            Assert.AreEqual(contactListBefore, contactListAfter);
        }
    }
}