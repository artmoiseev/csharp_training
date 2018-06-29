using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    class GroupData
    {
        private string groupName;
        private string groupHeader;
        private string groupFooter;

        public GroupData(string groupName, string groupHeader, string groupFooter)
        {
            this.GroupName = groupName;
            this.GroupHeader = groupHeader;
            this.GroupFooter = groupFooter;
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
    }
}
