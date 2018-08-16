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
            List<ContactData> contactListBefore = ContactData.GetAll();
            ContactData contactToModify = contactListBefore[0];
            var contactData = new ContactData(
                $"username{Guid.NewGuid()}",
                $"userlastName{Guid.NewGuid()}");

            appManager.ContactHelper.
                EditContact(contactToModify, contactData).
                SubmitModification();
            contactListBefore[0] = contactData;

            Assert.AreEqual(contactListBefore.Count, appManager.ContactHelper.GetContactCount());
            List<ContactData> contactListAfter = ContactData.GetAll();
            contactListBefore.Sort();
            contactListAfter.Sort();
            Assert.AreEqual(contactListBefore, contactListAfter);
        }
    }
}