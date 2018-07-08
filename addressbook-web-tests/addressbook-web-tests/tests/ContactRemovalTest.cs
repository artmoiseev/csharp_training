using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactRemovalTest : BaseTest
    {
        [Test]
        public void RemoveContactTest()
        {
            appManager.ContactHelper.
                SelectContact(1).
                RemoveContact();
        }
    }
}