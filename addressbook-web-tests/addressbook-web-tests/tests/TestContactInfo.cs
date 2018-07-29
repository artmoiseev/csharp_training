using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestContactInfo : AuthBaseTest
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData contactDataFomHomePage = appManager.ContactHelper.GetContactInfoFromHomePage(0);
            ContactData contactDataFomEditForm = appManager.ContactHelper.GetContactsFromEditForm(0);
            Assert.AreEqual(contactDataFomEditForm, contactDataFomHomePage);
            Assert.AreEqual(contactDataFomEditForm.Address, contactDataFomHomePage.Address);
            Assert.AreEqual(contactDataFomEditForm.AllPhones, contactDataFomHomePage.AllPhones);
        }
    }
}