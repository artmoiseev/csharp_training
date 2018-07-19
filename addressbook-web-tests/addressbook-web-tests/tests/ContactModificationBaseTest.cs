using NUnit.Framework;

namespace WebAddressBookTests
{
    public class ContactModificationBaseTest : AuthBaseTest
    {
        [SetUp]
        public void SetUpContact()
        {
            appManager.ContactHelper.CreateContactIfContactListEmpty();
        }
    }
}