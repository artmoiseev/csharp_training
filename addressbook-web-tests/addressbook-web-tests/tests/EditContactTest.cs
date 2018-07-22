using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class EditContactTest : ContactModificationBaseTest
    {
        [Test]
        public void ModifyContactTest()
        {
            List<ContactData> contactListBefore = appManager.ContactHelper.GetContactList();
            var contactData = new ContactData(
                $"username{Guid.NewGuid()}",
                $"userlastName{Guid.NewGuid()}");
            
            appManager.ContactHelper.EditContact(0,
                contactData).SubmitModification();
            contactListBefore[0] = contactData;
            
            List<ContactData> contactListAfter = appManager.ContactHelper.GetContactList();
            contactListBefore.Sort();
            contactListAfter.Sort();
            Assert.AreEqual(contactListBefore, contactListAfter);
        }
    }
}