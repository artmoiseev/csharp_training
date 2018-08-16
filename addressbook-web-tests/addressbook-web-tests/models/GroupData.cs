using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Xml.Serialization;
using LinqToDB.Mapping;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [XmlInclude(typeof(BaseDataModel))]
    [Table(Name = "group_list")]
    public class GroupData  : BaseDataModel, IEquatable<GroupData>, IComparable<GroupData> 
    {
        private string groupName;
        private string groupHeader;
        private string groupFooter;

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            GroupName = groupName;
            GroupHeader = groupHeader;
            GroupFooter = groupFooter;
        }

        public GroupData()
        {
        }

        public GroupData(string groupName)
        {
            this.groupName = groupName;
        }

        [Column(Name = "group_name")]
        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        [Column(Name = "group_header")]
        public string GroupHeader
        {
            get { return groupHeader; }
            set { groupHeader = value; }
        }

        [Column(Name = "group_footer")]
        public string GroupFooter
        {
            get { return groupFooter; }
            set { groupFooter = value; }
        }
        
        [Column(Name = "group_id"), PrimaryKey, Identity]
        public string Id { get; set; }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GroupName == other.GroupName;
        }

        public override int GetHashCode()
        {
            return GroupName.GetHashCode();
        }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(null, other)) return 1;
            return GroupName.CompareTo(other.GroupName);
        }

        public override string ToString()
        {
            return "name=" + GroupName;
        }

        public static List<GroupData> GetAll()
        {
            using (var addressBookDb = new AddressBookDB())
            {
                return (from g in addressBookDb.Groups select g).ToList();
            }
        }

        public List<ContactData> GetContacts()
        {
            using (var addressBookDb = new AddressBookDB())
            {
                return (from contact in addressBookDb.Contacts
                    from gcr in addressBookDb.GCR.Where(p => p.GroupId == Id 
                                                             && p.ContactId == contact.Id 
                                                             && contact.Deprecated=="0000-00-00 00:00:00")
                    select contact).Distinct().ToList();
            }
        }
    }
}