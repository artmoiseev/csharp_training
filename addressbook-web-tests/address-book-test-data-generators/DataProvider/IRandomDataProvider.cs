using System.Collections.Generic;
using NUnit.Framework;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public interface IRandomDataProvider
    {
        List<BaseDataModel> GetRandomDataList(int count);
    }
}