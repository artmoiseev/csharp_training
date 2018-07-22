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
            List<ContactData> contactListBefore = appManager.ContactHelper.GetContactList();
            
            appManager.ContactHelper.RemoveContact(0);
            
            List<ContactData> contactListAfter = appManager.ContactHelper.GetContactList();
            contactListBefore.RemoveAt(0);
            Assert.AreEqual(contactListBefore, contactListAfter);
        }
    }
}