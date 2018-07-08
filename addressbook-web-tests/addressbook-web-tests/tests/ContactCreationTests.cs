using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : BaseTest
    {
        [Test]
        public void ContactCreationTest()
        {
            appManager.NavigationHelper.OpenHomePage();
            appManager.LoginHelper.Login(new AccountData("admin", "secret"));
            appManager.NavigationHelper.GoToAddNewContactMenu();
            appManager.ContactHelper.
                FillContactData(new ContactData("df", "dg")).
                SubmitCreation();
        }
    }
}