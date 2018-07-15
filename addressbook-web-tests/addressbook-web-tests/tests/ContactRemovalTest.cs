using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactRemovalTest : AuthBaseTest
    {
        [Test]
        public void RemoveContactTest()
        {
            appManager.ContactHelper.
                RemoveContact(1);
        }
    }
}