using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class EditContactTest : BaseTest
    {
        [Test]
        public void ModifyContactTest()
        {
            appManager.ContactHelper.
                EditContact(1).
                FillContactData(
                    new ContactData(
                        $"username{Guid.NewGuid()}",
                        $"userlastName{Guid.NewGuid()}")).
                SubmitModification();
        }
    }
}