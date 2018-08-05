using System;
using System.Collections;
using System.Collections.Generic;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public static class DataPoviderFactory
    {
        public static IRandomDataProvider GetDataProvider(string dataType)
        {
            switch (dataType)
            {
                case "contact": return new RandomContactDataProvider();
                case "group": return new RandomGroupDataProvider();
                default: throw new Exception("Unknown data type!");
            }
        }
    }
}