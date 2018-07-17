using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class EditContactTest : AuthBaseTest
    {
        [Test]
        public void ModifyContactTest()
        {
            appManager.ContactHelper.CreateContactIfContactListEmpty();
            appManager.ContactHelper.EditContact(1,
                new ContactData(
                    $"username{Guid.NewGuid()}",
                    $"userlastName{Guid.NewGuid()}")).SubmitModification();
        }
    }
}