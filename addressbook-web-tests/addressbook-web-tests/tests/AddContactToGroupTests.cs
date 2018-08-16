using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class AddContactToGroupTests : AuthBaseTest
    {
        [Test]
        public void TestAddContactToGroup()
        {
            var groupData = GroupData.GetAll()[0];
            var oldList = groupData.GetContacts();
            var contact = ContactData.GetAll().Except(oldList).First();

            appManager.ContactHelper.AddContactToGroup(contact, groupData);
            
            var newList = groupData.GetContacts();
            oldList.Add(contact);

            newList.Sort();
            oldList.Sort();
            Assert.AreEqual(oldList, newList);
        }
    }
}