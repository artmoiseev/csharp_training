using System;
using System.Text.RegularExpressions;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            Firstname = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
        }

        public string Firstname { get; set; }

        public string Address { get; set; }

        public string AllPhones
        {
            get
            {
                if (allphones != null)
                {
                    return allphones;
                }

                return (CleanUpPhone(HomePhone) + CleanUpPhone(MobilePhone) + CleanUpPhone(WorkPhone)).Trim();
            }
            set => allphones = value;
        }

        private string CleanUpPhone(string phone)
        {
            if (phone == null)
            {
                return "";
            }

            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        private string allphones;
        private string allData;

        public string LastName { get; set; }

        public string HomePhone { get; set; }

        public string MobilePhone { get; set; }

        public string WorkPhone { get; set; }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }

                return CleanUpConcatenatedData($"{Firstname} {LastName}\r\n{Address}\r\n\r\n{AllPhones}");
            }
            set { allData = CleanUpConcatenatedData(value); }
        }

        private string CleanUpConcatenatedData(string data)
        {
            return Regex.Replace(data, "[ |H:|M:|W:]", "");
        }

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