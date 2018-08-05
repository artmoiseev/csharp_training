using System.Collections.Generic;
using System.Xml.Serialization;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public class XmlDataWriter : IDataWriter
    {
        public void WriteToFile(DataBuilder builder)
        {
            var list = DataPoviderFactory.GetDataProvider(builder.DataType).GetRandomDataList(builder.NumberOfRecords);
            new XmlSerializer(typeof(List<BaseDataModel>)).Serialize(builder.Writer, list);
        }
    }
}