using System;

namespace WebAddressBookTests
{
    public class ContactData : IComparable<ContactData>, IEquatable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            this.Firstname = firstName;
            this.LastName = lastName;
        }

        public string Firstname { get; set; }

        public string LastName { get; set; }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(null, other)) return 1;
            return String.Compare(ToString(), other.ToString(), StringComparison.Ordinal);
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ToString() == other.ToString();
        }

        public override string ToString()
        {
            return $"first name={Firstname} last name={LastName}";
        }
    }
}