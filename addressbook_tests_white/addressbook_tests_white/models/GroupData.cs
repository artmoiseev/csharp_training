using System;
using System.Diagnostics;
using static System.String;

namespace addressbook_tests_white.models
{
    public class GroupData : IComparable<GroupData>, IEquatable<GroupData>
    {
        public string GroupName { get; set; }

        public int CompareTo(GroupData other)
        {
            if (ReferenceEquals(null, other)) return 1;
            return GroupName.CompareTo(other.GroupName);
        }

        public bool Equals(GroupData other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return GroupName == other.GroupName;
        }

        public override string ToString()
        {
            return GroupName;
        }
    }
}