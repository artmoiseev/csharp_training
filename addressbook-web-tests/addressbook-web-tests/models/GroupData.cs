using System;
using System.Xml.Serialization;

namespace WebAddressBookTests
{
    [XmlInclude(typeof(BaseDataModel))]
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

        public string GroupName
        {
            get { return groupName; }
            set { groupName = value; }
        }

        public string GroupHeader
        {
            get { return groupHeader; }
            set { groupHeader = value; }
        }

        public string GroupFooter
        {
            get { return groupFooter; }
            set { groupFooter = value; }
        }

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
    }
}