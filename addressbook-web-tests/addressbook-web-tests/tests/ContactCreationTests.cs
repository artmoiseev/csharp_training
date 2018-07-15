using System;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : AuthBaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.ContactHelper
                .CreateNewContact();
        }
    }
}