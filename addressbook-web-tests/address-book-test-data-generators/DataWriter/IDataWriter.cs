using System.IO;
using WebAddressBookTests;

namespace address_book_test_data_generators.DataWriter
{
    public interface IDataWriter
    {
        void WriteToFile(DataBuilder dataBuilder);
    }
}