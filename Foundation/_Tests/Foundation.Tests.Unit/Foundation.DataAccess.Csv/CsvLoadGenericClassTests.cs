//-----------------------------------------------------------------------
// <copyright file="CsvLoadGenericClassTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.DataAccess.Csv;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.DataAccess.Csv
{
    /// <summary>
    /// The Csv load tests class
    /// </summary>
    [TestFixture]
    public class CsvLoadGenericClassTests : UnitTestBase
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

            using (CsvReader<CsvRecord> csvReader = new CsvReader<CsvRecord>(sourceFile))
            {
                Assert.That(csvReader.Size, Is.EqualTo(695));

                List<CsvRecord> rows = csvReader.Read().ToList();
                Assert.That(rows.Count, Is.EqualTo(52));

                CsvRecord? header = csvReader.HeaderRow;
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

            using (CsvReader<CsvRecord> csvReader = new CsvReader<CsvRecord>(sourceFile))
            {
                List<CsvRecord> rows = csvReader.Read().ToList();
                CsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 53 rows including the Header, so 52 rows of data
                Assert.That(rows.Count, Is.EqualTo(52));

                Int32 rowCounter = 0;
                Int32 offset = 97;
                foreach (CsvRecord csvRecord in rows)
                {
                    for (Int32 fieldCounter = 1; fieldCounter <= 6; fieldCounter++)
                    {
                        String actual = csvRecord.Fields[$"H{fieldCounter}"];
                        String expected = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual, Is.EqualTo(expected));
                    }

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

            using (CsvReader<CsvRecord> csvReader = new CsvReader<CsvRecord>(sourceFile))
            {
                List<CsvRecord> rows = csvReader.ReadAll();
                CsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 53 rows including the Header, so 52 rows of data
                Assert.That(rows.Count, Is.EqualTo(52));

                Int32 rowCounter = 0;
                Int32 offset = 97;
                foreach (CsvRecord csvRecord in rows)
                {
                    for (Int32 fieldCounter = 1; fieldCounter <= 6; fieldCounter++)
                    {
                        String actual = csvRecord.Fields[$"H{fieldCounter}"];
                        String expected = Convert.ToString(Convert.ToChar(rowCounter + offset));
                        Assert.That(actual, Is.EqualTo(expected));
                    }

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

            using (StreamReader streamReader = File.OpenText(sourceFile))
            {
                using (CsvReader<CsvRecord> csvReader = new CsvReader<CsvRecord>(streamReader))
                {
                    List<CsvRecord> rows = csvReader.ReadAll();
                    CsvRecord? header = csvReader.HeaderRow;
                    String headerRawData = header!.RawData;
                    Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                    // File has 53 rows including the Header, so 52 rows of data
                    Assert.That(rows.Count, Is.EqualTo(52));

                    Int32 rowCounter = 0;
                    Int32 offset = 97;
                    foreach (CsvRecord csvRecord in rows)
                    {
                        for (Int32 fieldCounter = 1; fieldCounter <= 6; fieldCounter++)
                        {
                            String actual = csvRecord.Fields[$"H{fieldCounter}"];
                            String expected = Convert.ToString(Convert.ToChar(rowCounter + offset));
                            Assert.That(actual, Is.EqualTo(expected));
                        }

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
