using Newtonsoft.Json;

namespace address_book_test_data_generators.DataWriter
{
    public class JsonDataWriter : IDataWriter
    {
        public void WriteToFile(DataBuilder builder)
        {
            var list = DataPoviderFactory.GetDataProvider(builder.DataType).GetRandomDataList(builder.NumberOfRecords);
            builder.Writer.Write(JsonConvert.SerializeObject(list));
        }
    }
}