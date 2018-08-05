using System.IO;

namespace address_book_test_data_generators
{
    public class DataBuilder
    {
        public StreamWriter Writer { get; set; }
        public string DataType { get; set; }
        public string FileName { get; set; }
        public int NumberOfRecords { get; set; }
    }
}