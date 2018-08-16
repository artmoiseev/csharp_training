using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressBookTests
{
    [TestFixture]
    public class WebAddressBookTests : GroupBaseTest
    {
        [Test, TestCaseSource(nameof(RandomGroupData))]
        public void GroupCreationTest(GroupData data)
        {
            appManager.NavigationHelper.GoToGroupsPage();

            List<GroupData> groupsBefore = GroupData.GetAll();

            appManager.GroupHelper.CreateNewGroup(data);

            appManager.NavigationHelper.ReturnToGroupsPage();

            List<GroupData> groupsAfter = GroupData.GetAll();
            Assert.AreEqual(groupsBefore.Count + 1, appManager.GroupHelper.GetGroupCount());
            groupsBefore.Add(data);
            groupsAfter.Sort();
            groupsBefore.Sort();

            Assert.AreEqual(groupsBefore, groupsAfter);
        }

        public static IEnumerable<GroupData> RandomGroupData()
        {
            List<GroupData> groups = new List<GroupData>();
            for (int i = 0; i < 4; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30), GenerateRandomString(100), GenerateRandomString(100)));
            }

            return groups;
        }

        public static IEnumerable<BaseDataModel> GroupDataFromXml()
        {
            List<BaseDataModel> datas =
                (List<BaseDataModel>) new XmlSerializer(typeof(List<BaseDataModel>)).Deserialize(
                    new StreamReader(@"GroupData.xml"));
            return datas;
        }

        public static IEnumerable<GroupData> GroupDataFromJson()
        {
            return JsonConvert.DeserializeObject<List<GroupData>>(File.ReadAllText(@"GroupData.json"));
        }
    }
}