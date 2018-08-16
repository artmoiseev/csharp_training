using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [Table(Name = "addressbook")] 
    public class ContactData : BaseDataModel, IEquatable<ContactData>, IComparable<ContactData>
    {
        public ContactData(string firstName, string lastName)
        {
            Firstname = firstName;
            LastName = lastName;
        }

        public ContactData()
        {
        }
        
        [Column(Name = "firstname")]
        public string Firstname { get; set; }

        [Column(Name = "address")]
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

        private string allEmails;

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "home")]
        public string HomePhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "id"), PrimaryKey, Identity]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }

                return $"{Email1}\r\n{Email2}\r\n{Email3}";
            }
            set => allEmails = value;
        }

        public string AllData
        {
            get
            {
                if (allData != null)
                {
                    return allData;
                }

                return $"{Firstname} {LastName}\r\n{Address}\r\n\r\nH: " +
                       $"{HomePhone}\r\nM: {MobilePhone}\r\nW: {WorkPhone}\r\n\r\n{Email1}\r\n{Email2}\r\n{Email3}";
            }
            set => allData = value;
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

        public static List<ContactData> GetAll()
        {
            using (var addressBookDb = new AddressBookDB())
            {
                List<ContactData> rawList = (from contact in addressBookDb.Contacts select contact).ToList();
                List<ContactData> listToReturn = new List<ContactData>(); 
                foreach (var data in rawList)
                {
                    if (data.Deprecated.Equals("01.01.0001 0:00:00"))
                    {
                        listToReturn.Add(data);
                    }
                }
                return listToReturn;
            }
        }
    }
}