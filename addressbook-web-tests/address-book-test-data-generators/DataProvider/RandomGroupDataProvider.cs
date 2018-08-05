using System.Collections.Generic;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public class RandomGroupDataProvider : IRandomDataProvider
    {
        List<BaseDataModel> IRandomDataProvider.GetRandomDataList(int count)
        {
            List<BaseDataModel> groupData = new List<BaseDataModel>();
            for (var i = 0; i < count; i++)
            {
                groupData.Add(new GroupData
                {
                    GroupName = BaseTest.GenerateRandomString(10),
                    GroupFooter = BaseTest.GenerateRandomString(100),
                    GroupHeader = BaseTest.GenerateRandomString(100)
                });
            }
            return groupData;
        }
    }
}