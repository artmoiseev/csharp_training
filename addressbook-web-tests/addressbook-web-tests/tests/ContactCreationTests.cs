using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : BaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.NavigationHelper.GoToAddNewContactMenu();
            
            appManager.ContactHelper.
                FillContactData(new ContactData($"username{Guid.NewGuid()}", $"userlastName{Guid.NewGuid()}")).
                SubmitCreation();
        }
    }
}