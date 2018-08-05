using System;

namespace address_book_test_data_generators.DataWriter
{
    public static class DataWriterFactory
    {
        public static IDataWriter GetDataWriter(string dataType)
        {
            switch (dataType)
            {
                case "json": return new JsonDataWriter();
                case "xml": return new XmlDataWriter();
                default: throw new Exception("Unknown data format!");
            }
        }
    }
}