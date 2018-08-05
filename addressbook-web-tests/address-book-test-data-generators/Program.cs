using System;
using System.IO;
using address_book_test_data_generators.DataWriter;

namespace address_book_test_data_generators
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var dataType = args[0];
            var numberOfRecords = Convert.ToInt32(args[1]);
            var fileName = args[2];
            var fileFormat = args[3];
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fileName);
                DataWriterFactory.
                    GetDataWriter(fileFormat).
                    WriteToFile(new DataBuilder
                    {
                        Writer = streamWriter,
                        DataType = dataType,
                        FileName = fileName,
                        NumberOfRecords = numberOfRecords
                    });
            }
            catch (Exception e)
            {
                Console.Out.Write($"Exception occured during the process, stack trace: \n{e}");
            }
            finally
            {
                streamWriter?.Close();
            }
        }
    }
}