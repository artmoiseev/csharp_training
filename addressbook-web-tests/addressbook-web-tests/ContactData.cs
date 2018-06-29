using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData
    {
        private string firstname;
        private string lastName;

        public ContactData(string firstName, string lastName)
        {
            this.Firstname = firstName;
            this.LastName = lastName;
        }

        public string Firstname
        {
            get { return firstname; }
            set { firstname = value; }
        }

        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
    }
}
