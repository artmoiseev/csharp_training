using LinqToDB;

namespace WebAddressBookTests
{
    public class AddressBookDB : LinqToDB.Data.DataConnection
    {
        public AddressBookDB() : base("AddressBook")
        {
        }

        public ITable<GroupData> Groups => GetTable<GroupData>();

        public ITable<ContactData> Contacts => GetTable<ContactData>();

    }
}