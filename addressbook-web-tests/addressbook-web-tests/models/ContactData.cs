namespace WebAddressBookTests
{
    public class ContactData
    {
        public ContactData(string firstName, string lastName)
        {
            this.Firstname = firstName;
            this.LastName = lastName;
        }

        public string Firstname { get; set; }

        public string LastName { get; set; }
    }
}