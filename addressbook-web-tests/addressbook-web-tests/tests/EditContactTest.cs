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
                SelectContact(5).
                EditContact().
                FillContactData(
                    new ContactData(
                        $"username{Guid.NewGuid()}",
                        $"userlastName{Guid.NewGuid()}")).
                SubmitModification();
        }
    }
}