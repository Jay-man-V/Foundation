//-----------------------------------------------------------------------
// <copyright file="CsvLoadTypedClassWithQuotesTests.cs" company="JDV Software Ltd">
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
    public class CsvLoadTypedClassWithQuotesTests : UnitTestBase
    {
        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_HeaderRow()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                Assert.That(csvReader.Size, Is.EqualTo(123));

                List<MyCsvRecord> rows = csvReader.Read().ToList();
                Assert.That(rows.Count, Is.EqualTo(6));

                MyCsvRecord? header = csvReader.HeaderRow;
                Assert.That(header!.Fields.Count, Is.EqualTo(6));
                Assert.That(header.ToString(), Is.EqualTo("True = 1 [H1, H1]|[H2, H2]|[H3, H3]|[H4, H4]|[H5, H5]|[H6, H6]"));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadRows()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                List<MyCsvRecord> rows = csvReader.Read().ToList();

                MyCsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 7 rows including the Header, so 6 rows of data
                Assert.That(rows.Count, Is.EqualTo(6));

                // Data row 1 has a carriage return
                MyCsvRecord row1 = rows[0];
                String row1Expected = $@"a,""a,{Environment.NewLine}-1/2"""",size"",a,a,a,a";
                Assert.That(row1.RawData, Is.EqualTo(row1Expected));

                // Data row 2 has double-quote
                MyCsvRecord row2 = rows[1];
                String row2Expected = @"b,""b"",b,b,b,b";
                Assert.That(row2.RawData, Is.EqualTo(row2Expected));

                // Data row 3 has double-quote
                MyCsvRecord row3 = rows[2];
                String row3Expected = @"c,""c"",c,c,c,c";
                Assert.That(row3.RawData, Is.EqualTo(row3Expected));

                // Data row 4 has double-quote
                MyCsvRecord row4 = rows[3];
                String row4Expected = @"d,""d"",d,d,d,d";
                Assert.That(row4.RawData, Is.EqualTo(row4Expected));

                // Data row 5 has double-quote
                MyCsvRecord row5 = rows[4];
                String row5Expected = @"e,""e"",e,e,e,e";
                Assert.That(row5.RawData, Is.EqualTo(row5Expected));

                // Data row 6 has double-quote
                MyCsvRecord row6 = rows[5];
                String row6Expected = @"f,""f"",f,f,f,f";
                Assert.That(row6.RawData, Is.EqualTo(row6Expected));

                Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadAll()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(sourceFile))
            {
                List<MyCsvRecord> rows = csvReader.ReadAll();

                MyCsvRecord? header = csvReader.HeaderRow;
                String headerRawData = header!.RawData;
                Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                // File has 7 rows including the Header, so 6 rows of data
                Assert.That(rows.Count, Is.EqualTo(6));

                // Data row 1 has a carriage return
                MyCsvRecord row1 = rows[0];
                String row1Expected = $@"a,""a,{Environment.NewLine}-1/2"""",size"",a,a,a,a";
                Assert.That(row1.RawData, Is.EqualTo(row1Expected));

                // Data row 2 has double-quote
                MyCsvRecord row2 = rows[1];
                String row2Expected = @"b,""b"",b,b,b,b";
                Assert.That(row2.RawData, Is.EqualTo(row2Expected));

                // Data row 3 has double-quote
                MyCsvRecord row3 = rows[2];
                String row3Expected = @"c,""c"",c,c,c,c";
                Assert.That(row3.RawData, Is.EqualTo(row3Expected));

                // Data row 4 has double-quote
                MyCsvRecord row4 = rows[3];
                String row4Expected = @"d,""d"",d,d,d,d";
                Assert.That(row4.RawData, Is.EqualTo(row4Expected));

                // Data row 5 has double-quote
                MyCsvRecord row5 = rows[4];
                String row5Expected = @"e,""e"",e,e,e,e";
                Assert.That(row5.RawData, Is.EqualTo(row5Expected));

                // Data row 6 has double-quote
                MyCsvRecord row6 = rows[5];
                String row6Expected = @"f,""f"",f,f,f,f";
                Assert.That(row6.RawData, Is.EqualTo(row6Expected));

                Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [TestCase]
        [DeploymentItem(@".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv", @".Support\SampleDocuments\CsvFiles\")]
        public void Test_LoadCsv_ReadAll_ViaStream()
        {
            const String sourceFile = @".Support\SampleDocuments\CsvFiles\CSVFile with Quotes.csv";
            Boolean fileExists = File.Exists(sourceFile);
            Assert.That(fileExists, Is.EqualTo(true));

            using (StreamReader streamReader = File.OpenText(sourceFile))
            {
                using (CsvReader<MyCsvRecord> csvReader = new CsvReader<MyCsvRecord>(streamReader))
                {
                    List<MyCsvRecord> rows = csvReader.ReadAll();

                    MyCsvRecord? header = csvReader.HeaderRow;
                    String headerRawData = header!.RawData;
                    Assert.That(headerRawData, Is.EqualTo("H1,H2,H3,H4,H5,H6"));

                    // File has 7 rows including the Header, so 6 rows of data
                    Assert.That(rows.Count, Is.EqualTo(6));

                    // Data row 1 has a carriage return
                    MyCsvRecord row1 = rows[0];
                    String row1Expected = $@"a,""a,{Environment.NewLine}-1/2"""",size"",a,a,a,a";
                    Assert.That(row1.RawData, Is.EqualTo(row1Expected));

                    // Data row 2 has double-quote
                    MyCsvRecord row2 = rows[1];
                    String row2Expected = @"b,""b"",b,b,b,b";
                    Assert.That(row2.RawData, Is.EqualTo(row2Expected));

                    // Data row 3 has double-quote
                    MyCsvRecord row3 = rows[2];
                    String row3Expected = @"c,""c"",c,c,c,c";
                    Assert.That(row3.RawData, Is.EqualTo(row3Expected));

                    // Data row 4 has double-quote
                    MyCsvRecord row4 = rows[3];
                    String row4Expected = @"d,""d"",d,d,d,d";
                    Assert.That(row4.RawData, Is.EqualTo(row4Expected));

                    // Data row 5 has double-quote
                    MyCsvRecord row5 = rows[4];
                    String row5Expected = @"e,""e"",e,e,e,e";
                    Assert.That(row5.RawData, Is.EqualTo(row5Expected));

                    // Data row 6 has double-quote
                    MyCsvRecord row6 = rows[5];
                    String row6Expected = @"f,""f"",f,f,f,f";
                    Assert.That(row6.RawData, Is.EqualTo(row6Expected));

                    Assert.That(csvReader.EndOfFile, Is.EqualTo(true));
                }
            }
        }
    }
}
