using System;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
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

            if (Firstname.Equals(other.Firstname))
            {
                return String.Compare(LastName, other.Firstname, StringComparison.Ordinal);
            }
            return String.Compare(other.Firstname, Firstname, StringComparison.Ordinal);
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Firstname.Equals(other.Firstname) && LastName.Equals(other.LastName);
        }

        public override string ToString()
        {
            return $"first name={Firstname} last name={LastName}";
        }
    }
}