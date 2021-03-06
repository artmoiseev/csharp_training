﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressBookTests
{
    class ContactCreationTests : ContactBaseTest
    {
        [Test, TestCaseSource(nameof(RandomContactData))]
        public void ContactCreationTest(ContactData contactData)
        {
            List<ContactData> contactListBefore = ContactData.GetAll();
            appManager.ContactHelper.CreateNewContact(contactData);
            Assert.AreEqual(contactListBefore.Count + 1, appManager.ContactHelper.GetContactCount());

            contactListBefore.Add(contactData);
            
            List<ContactData> contactListAfter = ContactData.GetAll();
            contactListBefore.Sort();
            contactListAfter.Sort();
            Assert.AreEqual(contactListAfter, contactListBefore);
        }

        public static IEnumerable<BaseDataModel> ContactDataFromXml()
        {
            return (List<BaseDataModel>) new XmlSerializer(typeof(List<BaseDataModel>)).Deserialize(
                new StreamReader(@"ContactData.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJson()
        {
            return JsonConvert.DeserializeObject< List<ContactData>>(File.ReadAllText(@"ContactData.json"));
        }

        public static IEnumerable<ContactData> RandomContactData()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 10; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(100)));
            }
            return contacts;
        }
    }
}