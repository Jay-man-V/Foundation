//-----------------------------------------------------------------------
// <copyright file="CsvLoadTypedClassTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Csv;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;
using Foundation.Tests.Unit.Foundation.DataAccess.Csv.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Csv
{
    /// <summary>
    /// The Csv load tests class
    /// </summary>
    [TestFixture]
    public class CsvLoadTypedClassTests : UnitTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_HeaderRow()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                Assert.That(csvReader.Size, Is.EqualTo(695));

                List<MyCsvRecord> rows = csvReader.Read().ToList();
                Assert.That(rows.Count, Is.EqualTo(52));

                MyCsvRecord? header = csvReader.HeaderRow;
                Assert.That(header!.Fields.Count, Is.EqualTo(6));
                Assert.That(header.ToString(), Is.EqualTo("True = 1 [H1, H1]|[H2, H2]|[H3, H3]|[H4, H4]|[H5, H5]|[H6, H6]"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadRows()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                List<MyCsvRecord> rows = csvReader.Read().ToList();
                MyCsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 53 rows including the Header, so 52 rows of data
                Assert.That(rows.Count, Is.EqualTo(52));

                Int32 rowCounter = 0;
                Int32 offset = 97;
                foreach (MyCsvRecord csvRecord in rows)
                {
                    String recordRawData = csvRecord.RawData;

                    String[] array =
                    [
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                    ];

                    String expectedRow = String.Join(",", array);
                    Assert.That(recordRawData, Is.EqualTo(expectedRow));

                    String actual1 = csvRecord.Field1;
                    String expected1 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual1, Is.EqualTo(expected1));

                    String actual2 = csvRecord.Field2;
                    String expected2 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual2, Is.EqualTo(expected2));

                    String actual3 = csvRecord.Field3;
                    String expected3 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual3, Is.EqualTo(expected3));

                    String actual4 = csvRecord.Field4;
                    String expected4 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual4, Is.EqualTo(expected4));

                    String actual5 = csvRecord.Field5;
                    String expected5 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual5, Is.EqualTo(expected5));

                    String actual6 = csvRecord.Field6;
                    String expected6 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual6, Is.EqualTo(expected6));

                    rowCounter++;

                    if (rowCounter == 26)
                    {
                        rowCounter = 0;
                        offset = 65;
                    }
                }

                Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadAll()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                List<MyCsvRecord> rows = csvReader.ReadAll();
                MyCsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 53 rows including the Header, so 52 rows of data
                Assert.That(rows.Count, Is.EqualTo(52));

                Int32 rowCounter = 0;
                Int32 offset = 97;
                foreach (MyCsvRecord csvRecord in rows)
                {
                    String recordRawData = csvRecord.RawData;

                    String[] array =
                    [
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        Convert.ToString(Convert.ToChar(rowCounter + offset)),
                    ];

                    String expectedRow = String.Join(",", array);
                    Assert.That(recordRawData, Is.EqualTo(expectedRow));

                    String actual1 = csvRecord.Field1;
                    String expected1 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual1, Is.EqualTo(expected1));

                    String actual2 = csvRecord.Field2;
                    String expected2 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual2, Is.EqualTo(expected2));

                    String actual3 = csvRecord.Field3;
                    String expected3 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual3, Is.EqualTo(expected3));

                    String actual4 = csvRecord.Field4;
                    String expected4 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual4, Is.EqualTo(expected4));

                    String actual5 = csvRecord.Field5;
                    String expected5 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual5, Is.EqualTo(expected5));

                    String actual6 = csvRecord.Field6;
                    String expected6 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                    Assert.That(actual6, Is.EqualTo(expected6));

                    rowCounter++;

                    if (rowCounter == 26)
                    {
                        rowCounter = 0;
                        offset = 65;
                    }
                }

                Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadAll_ViaStream()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (StreamReader streamReader = new StreamReader(sourceFile))
            {
                using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(streamReader))
                {
                    List<MyCsvRecord> rows = csvReader.ReadAll();
                    MyCsvRecord? header = csvReader.HeaderRow;
                    String headerRawData = header!.RawData;
                    Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                    // File has 53 rows including the Header, so 52 rows of data
                    Assert.That(rows.Count, Is.EqualTo(52));

                    Int32 rowCounter = 0;
                    Int32 offset = 97;
                    foreach (MyCsvRecord csvRecord in rows)
                    {
                        String recordRawData = csvRecord.RawData;

                        String[] array =
                        [
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                            Convert.ToString(Convert.ToChar(rowCounter + offset)),
                        ];

                        String expectedRow = String.Join(",", array);
                        Assert.That(recordRawData, Is.EqualTo(expectedRow));

                        String actual1 = csvRecord.Field1;
                        String expected1 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual1, Is.EqualTo(expected1));

                        String actual2 = csvRecord.Field2;
                        String expected2 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual2, Is.EqualTo(expected2));

                        String actual3 = csvRecord.Field3;
                        String expected3 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual3, Is.EqualTo(expected3));

                        String actual4 = csvRecord.Field4;
                        String expected4 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual4, Is.EqualTo(expected4));

                        String actual5 = csvRecord.Field5;
                        String expected5 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual5, Is.EqualTo(expected5));

                        String actual6 = csvRecord.Field6;
                        String expected6 = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual6, Is.EqualTo(expected6));

                        rowCounter++;

                        if (rowCounter == 26)
                        {
                            rowCounter = 0;
                            offset = 65;
                        }
                    }

                    Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
                }
            }
        }
    }
}
