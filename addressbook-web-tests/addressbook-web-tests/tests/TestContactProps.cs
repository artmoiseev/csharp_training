using System.Diagnostics;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class TestContactProps : AuthBaseTest
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData contactDataFomEditForm = appManager.ContactHelper.GetContactsFromEditForm(0);
            ContactData contactDataFomDetailsForm = appManager.ContactHelper.GetContactsFromDetailsForm(0);
            Assert.AreEqual(contactDataFomEditForm.AllData, contactDataFomDetailsForm.AllData);
        }
    }
}