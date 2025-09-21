//-----------------------------------------------------------------------
// <copyright file="FileFiltersTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Resources;
using Foundation.Tests.Unit.Support;

using System.Reflection;

namespace Foundation.Tests.Unit.Foundation.Resources.FileManagementTests
{
    /// <summary>
    /// Unit Tests for the File Filters class
    /// </summary>
    [TestFixture]
    public class FileFiltersTests : UnitTestBase
    {
        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the <see cref="FileFilters"/>
        /// </summary>
        [TestCase]
        public void Test_CountMembers()
        {
            IEnumerable<MethodInfo> testMethods = GetListOfTestMethods();
            Int32 testMethodCount = testMethods.Count() - 1;

            // This test exists to ensure all the Properties are tested/checked in the next test
            Type theType = typeof(FileFilters);
            PropertyInfo[] propertyInfos = theType.GetProperties();

            Assert.That(propertyInfos.Length, Is.EqualTo(testMethodCount));

            Int32 index = 0;
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileFilters.AllFiles)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileFilters.TextFiles)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileFilters.CsvFiles)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileFilters.ExcelFiles)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(FileFilters.WordFiles)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// Tests the All Files
        /// </summary>
        [TestCase]
        public void Test_AllFiles()
        {
            String expected = String.Empty;
            expected += "All Files (*.*)|*.*";

            String actual = FileFilters.AllFiles;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Text Files
        /// </summary>
        [TestCase]
        public void Test_TextFiles()
        {
            String expected = String.Empty;
            expected += "All Files (*.*)|*.*";
            expected += "|Text Files (*.txt)|*.txt";

            String actual = FileFilters.TextFiles;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Csv Files
        /// </summary>
        [TestCase]
        public void Test_CsvFiles()
        {
            String expected = String.Empty;
            expected += "All Files (*.*)|*.*";
            expected += "|Comma Separated Values Files (Csv) (*.csv)|*.csv";

            String actual = FileFilters.CsvFiles;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Excel Files
        /// </summary>
        [TestCase]
        public void Test_ExcelFiles()
        {
            String expected = String.Empty;
            expected += "All Files (*.*)|*.*";
            expected += "|Excel Files (*.xls)|*.xls" +
                        "|Excel Files (*.xlsx)|*.xlsx" +
                        "|Excel Files (*.xlsm)|*.xlsm";

            String actual = FileFilters.ExcelFiles;

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Word Files
        /// </summary>
        [TestCase]
        public void Test_WordFiles()
        {
            String expected = String.Empty;
            expected += "All Files (*.*)|*.*";
            expected += "|Word Files (*.doc)|*.doc" +
                        "|Word Files (*.docx)|*.docx" +
                        "|Word Files (*.docm)|*.docm";

            String actual = FileFilters.WordFiles;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
