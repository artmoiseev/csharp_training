using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactModificationBaseTest : ContactBaseTest
    {
        [SetUp]
        public void SetUpContact()
        {
            appManager.ContactHelper.CreateContactIfContactListEmpty();
        }
    }
}