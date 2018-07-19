using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactRemovalTest : ContactModificationBaseTest
    {
        [Test]
        public void RemoveContactTest()
        {
            appManager.ContactHelper.
                RemoveContact(1);
        }
    }
}