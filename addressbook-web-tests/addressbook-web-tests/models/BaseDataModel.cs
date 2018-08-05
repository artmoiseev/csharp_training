using System;
using System.Xml.Serialization;

namespace WebAddressBookTests
{
    [XmlInclude(typeof(ContactData))]
    [XmlInclude(typeof(GroupData))]
    [Serializable]
    public class BaseDataModel
    {
    }
}