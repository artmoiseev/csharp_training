using System.Collections.Generic;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public class RandomContactDataProvider : IRandomDataProvider
    {
        public List<BaseDataModel> GetRandomDataList(int count)
        {
            List<BaseDataModel> contactDatas = new List<BaseDataModel>();
            for (var i = 0; i < count; i++)
            {
                contactDatas.Add(new ContactData
                {
                    Firstname = BaseTest.GenerateRandomString(10),
                    LastName = BaseTest.GenerateRandomString(100)
                });
            }
            return contactDatas;
        }
    }
}