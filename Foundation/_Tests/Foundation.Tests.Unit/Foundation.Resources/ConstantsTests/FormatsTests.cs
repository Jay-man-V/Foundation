//-----------------------------------------------------------------------
// <copyright file="FormatsTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;
using System.Globalization;
using System.Reflection;

using Foundation.Resources;
using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Resources.ConstantsTests
{
    /// <summary>
    /// Unit Tests for the Formats class
    /// </summary>
    [TestFixture]
    public class FormatsTests : UnitTestBase
    {
        private Int32 Integer1 => 0;
        private Int32 Integer2 => 12;
        private Int32 Integer3 => 123;
        private Int32 Integer6 => 123456;
        private long Integer15 => 123456789012345;

        private decimal Decimal1 => 0.0m;
        private decimal Decimal2 => 12.123456m;
        private decimal Decimal3 => 123.123456m;
        private decimal Decimal6 => 123456.123456m;
        private decimal Decimal15 => 123456789012345.123456m;

        private decimal Percentage1 => 0.05123456m;

        private DateTime DateTime1 => new DateTime(2021, 1, 10, 20, 27, 57, 798);

        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the DotNet Formats
        /// </summary>
        [TestCase]
        public void Test_dotNet_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(Formats.DotNet));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.FromDate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.ToDate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.FromDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.ToDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.CreatedDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.UpdatedDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.TimeOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.TimeWithSeconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.TimeWithMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.MonthYear)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.DateOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.DateOnlyWithDoW)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.DateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.DateTimeSeconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.DateTimeMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Iso8601Date)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Iso8601DateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Iso8601DateTimeMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Percentage2dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Percentage5dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Integer)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.IntegerPad3)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Decimal2dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.DotNet.Decimal5dp)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        /// This test exists to force developers to come to this class if there are any changes to the Excel Formats
        /// </summary>
        [TestCase]
        public void Test_Excel_AllMembers()
        {
            // This test exists to ensure all the class members are tested/checked in the next test
            PropertyInfo[] propertyInfos = GetStaticPropertyInfosForType(typeof(Formats.Excel));
            Int32 index = 0;

            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.FromDate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.ToDate)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.FromDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.ToDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.CreatedDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.UpdatedDateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.TimeOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.TimeWithSeconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.TimeWithMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.MonthYear)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.DateOnly)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.DateOnlyWithDoW)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.DateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.DateTimeSeconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.DateTimeMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Iso8601Date)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Iso8601DateTime)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Iso8601DateTimeMilliseconds)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Percentage2dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Percentage5dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Integer)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.IntegerPad3)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Decimal2dp)));
            Assert.That(propertyInfos[index++].Name, Is.EqualTo(nameof(Formats.Excel.Decimal5dp)));

            Assert.That(propertyInfos.Length, Is.EqualTo(index));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_DebugPrint()
        {
            Debug.WriteLine("N");
            Debug.WriteLine($"Integer1: {Integer1:N}");
            Debug.WriteLine($"Integer2: {Integer2:N}");
            Debug.WriteLine($"Integer3: {Integer3:N}");
            Debug.WriteLine($"Integer4: {Integer6:N}");
            Debug.WriteLine($"Decimal1: {Decimal1:N}");
            Debug.WriteLine($"Decimal2: {Decimal2:N}");
            Debug.WriteLine($"Decimal3: {Decimal3:N}");
            Debug.WriteLine($"Decimal4: {Decimal6:N}");

            Debug.WriteLine("N0");
            Debug.WriteLine($"Integer1: {Integer1:N0}");
            Debug.WriteLine($"Integer2: {Integer2:N0}");
            Debug.WriteLine($"Integer3: {Integer3:N0}");
            Debug.WriteLine($"Integer4: {Integer6:N0}");
            Debug.WriteLine($"Decimal1: {Decimal1:N0}");
            Debug.WriteLine($"Decimal2: {Decimal2:N0}");
            Debug.WriteLine($"Decimal3: {Decimal3:N0}");
            Debug.WriteLine($"Decimal4: {Decimal6:N0}");

            Debug.WriteLine("N5");
            Debug.WriteLine($"Integer1: {Integer1:N5}");
            Debug.WriteLine($"Integer2: {Integer2:N5}");
            Debug.WriteLine($"Integer3: {Integer3:N5}");
            Debug.WriteLine($"Integer4: {Integer6:N5}");
            Debug.WriteLine($"Decimal1: {Decimal1:N5}");
            Debug.WriteLine($"Decimal2: {Decimal2:N5}");
            Debug.WriteLine($"Decimal3: {Decimal3:N5}");
            Debug.WriteLine($"Decimal4: {Decimal6:N5}");

            Debug.WriteLine("P2");
            Debug.WriteLine($"Percentage1: {Percentage1:P2}");

            Debug.WriteLine("P5");
            Debug.WriteLine($"Percentage1: {Percentage1:P5}");

            Debug.WriteLine("DateTime");
            Debug.WriteLine($"DateTime1: {DateTime1:yy-MMM-dd ddd HH:mm:ss.fffff}");
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_dotNet_Times()
        {
            const String expectedTimeOnly = "20:27";
            const String expectedTimeWithSeconds = "20:27:57";
            const String expectedTimeWithMilliseconds = "20:27:57.798";

            Assert.That(DateTime1.ToString(Formats.DotNet.TimeOnly), Is.EqualTo(expectedTimeOnly));
            Assert.That(DateTime1.ToString(Formats.DotNet.TimeWithSeconds), Is.EqualTo(expectedTimeWithSeconds));
            Assert.That(DateTime1.ToString(Formats.DotNet.TimeWithMilliseconds), Is.EqualTo(expectedTimeWithMilliseconds));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_dotNet_Dates()
        {
            const String expectedFromDate = "10-Jan-2021";
            const String expectedToDate = "10-Jan-2021";
            const String expectedFromDatetime = "10-Jan-2021 20:27";
            const String expectedToDatetime = "10-Jan-2021 20:27";
            const String expectedCreatedDateTime = "10-Jan-2021 20:27";
            const String expectedUpdatedDateTime = "10-Jan-2021 20:27";

            const String expectedMonthYear = "Jan-2021";
            const String expectedDateOnly = "10-Jan-2021";
            const String expectedDateOnlyWithDoW = "Sun, 10-Jan-2021";
            const String expectedDateTime = "10-Jan-2021 20:27";
            const String expectedDateTimeSeconds = "10-Jan-2021 20:27:57";
            const String expectedDateTimeMilliseconds = "10-Jan-2021 20:27:57.798";
            const String expectedIso8601Date = "2021-01-10";
            const String expectedIso8601DateTime = "2021-01-10T20:27:57";
            const String expectedIso8601WithMilliseconds = "2021-01-10T20:27:57.798";

            Assert.That(DateTime1.ToString(Formats.DotNet.FromDate), Is.EqualTo(expectedFromDate));
            Assert.That(DateTime1.ToString(Formats.DotNet.ToDate), Is.EqualTo(expectedToDate));
            Assert.That(DateTime1.ToString(Formats.DotNet.FromDateTime), Is.EqualTo(expectedFromDatetime));
            Assert.That(DateTime1.ToString(Formats.DotNet.ToDateTime), Is.EqualTo(expectedToDatetime));
            Assert.That(DateTime1.ToString(Formats.DotNet.CreatedDateTime), Is.EqualTo(expectedCreatedDateTime));
            Assert.That(DateTime1.ToString(Formats.DotNet.UpdatedDateTime), Is.EqualTo(expectedUpdatedDateTime));

            Assert.That(DateTime1.ToString(Formats.DotNet.MonthYear), Is.EqualTo(expectedMonthYear));
            Assert.That(DateTime1.ToString(Formats.DotNet.DateOnly), Is.EqualTo(expectedDateOnly));
            Assert.That(DateTime1.ToString(Formats.DotNet.DateOnlyWithDoW), Is.EqualTo(expectedDateOnlyWithDoW));
            Assert.That(DateTime1.ToString(Formats.DotNet.DateTime), Is.EqualTo(expectedDateTime));
            Assert.That(DateTime1.ToString(Formats.DotNet.DateTimeSeconds), Is.EqualTo(expectedDateTimeSeconds));
            Assert.That(DateTime1.ToString(Formats.DotNet.DateTimeMilliseconds), Is.EqualTo(expectedDateTimeMilliseconds));
            Assert.That(DateTime1.ToString(Formats.DotNet.Iso8601Date), Is.EqualTo(expectedIso8601Date));
            Assert.That(DateTime1.ToString(Formats.DotNet.Iso8601DateTime), Is.EqualTo(expectedIso8601DateTime));
            Assert.That(DateTime1.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds), Is.EqualTo(expectedIso8601WithMilliseconds));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_dotNet_English()
        {
            CultureInfo newCulture = new CultureInfo("EN-GB");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage2dp), Is.EqualTo("5.12%"));
            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage5dp), Is.EqualTo("5.12346%"));

            Assert.That(Integer1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Integer2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Integer3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.Integer), Is.EqualTo("123,456"));
            Assert.That(Integer15.ToString(Formats.DotNet.Integer), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Integer), Is.EqualTo("123,456"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Integer), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Integer1.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("000"));
            Assert.That(Integer2.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("012"));
            Assert.That(Integer3.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456"));
            Assert.That(Integer15.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456789012345"));

            // This combination will not work at run time
            //Assert.That(Decimal1.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("000"));
            //Assert.That(Decimal2.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("012"));
            //Assert.That(Decimal3.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123"));
            //Assert.That(Decimal6.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123,456"));
            //Assert.That(Decimal15.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12.00"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.00"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,456.00"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,456,789,012,345.00"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12.12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.12"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,456.12"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,456,789,012,345.12"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12.00000"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.00000"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,456.00000"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,456,789,012,345.00000"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12.12346"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.12346"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,456.12346"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,456,789,012,345.12346"));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Excel_Times()
        {
            const String expectedTimeOnly = "20:27";
            const String expectedTimeWithSeconds = "20:27:57";
            const String expectedTimeWithMilliseconds = "20:27:57.000";

            Assert.That(DateTime1.ToString(Formats.Excel.TimeOnly), Is.EqualTo(expectedTimeOnly));
            Assert.That(DateTime1.ToString(Formats.Excel.TimeWithSeconds), Is.EqualTo(expectedTimeWithSeconds));
            Assert.That(DateTime1.ToString(Formats.Excel.TimeWithMilliseconds), Is.EqualTo(expectedTimeWithMilliseconds));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Excel_Dates()
        {
            const String expectedFromDate = "10-Jan-2021";
            const String expectedToDate = "10-Jan-2021";
            const String expectedFromDatetime = "10-Jan-2021 20:27";
            const String expectedToDatetime = "10-Jan-2021 20:27";
            const String expectedCreatedDateTime = "10-Jan-2021 20:27";
            const String expectedUpdatedDateTime = "10-Jan-2021 20:27";

            const String expectedMonthYear = "Jan-2021";
            const String expectedDateOnly = "10-Jan-2021";
            const String expectedDateOnlyWithDoW = "Sun, 10-Jan-2021";
            const String expectedDateTime = "10-Jan-2021 20:27";
            const String expectedDateTimeSeconds = "10-Jan-2021 20:27:57";
            const String expectedDateTimeMilliseconds = "10-Jan-2021 20:27:57.000";
            const String expectedIso8601Date = "2021-01-10";
            const String expectedIso8601DateTime = "2021-01-10T20:27:57";
            const String expectedIso8601WithMilliseconds = "2021-01-10T20:27:57.000";

            Assert.That(DateTime1.ToString(Formats.Excel.FromDate), Is.EqualTo(expectedFromDate));
            Assert.That(DateTime1.ToString(Formats.Excel.ToDate), Is.EqualTo(expectedToDate));
            Assert.That(DateTime1.ToString(Formats.Excel.FromDateTime), Is.EqualTo(expectedFromDatetime));
            Assert.That(DateTime1.ToString(Formats.Excel.ToDateTime), Is.EqualTo(expectedToDatetime));
            Assert.That(DateTime1.ToString(Formats.Excel.CreatedDateTime), Is.EqualTo(expectedCreatedDateTime));
            Assert.That(DateTime1.ToString(Formats.Excel.UpdatedDateTime), Is.EqualTo(expectedUpdatedDateTime));

            Assert.That(DateTime1.ToString(Formats.Excel.MonthYear), Is.EqualTo(expectedMonthYear));
            Assert.That(DateTime1.ToString(Formats.Excel.DateOnly), Is.EqualTo(expectedDateOnly));
            Assert.That(DateTime1.ToString(Formats.Excel.DateOnlyWithDoW), Is.EqualTo(expectedDateOnlyWithDoW));
            Assert.That(DateTime1.ToString(Formats.Excel.DateTime), Is.EqualTo(expectedDateTime));
            Assert.That(DateTime1.ToString(Formats.Excel.DateTimeSeconds), Is.EqualTo(expectedDateTimeSeconds));
            Assert.That(DateTime1.ToString(Formats.Excel.DateTimeMilliseconds), Is.EqualTo(expectedDateTimeMilliseconds));
            Assert.That(DateTime1.ToString(Formats.Excel.Iso8601Date), Is.EqualTo(expectedIso8601Date));
            Assert.That(DateTime1.ToString(Formats.Excel.Iso8601DateTime), Is.EqualTo(expectedIso8601DateTime));

            // Testing this year will not give the same output as it will in Excel - the two use different mechanisms for the Milliseconds conversion
            Assert.That(DateTime1.ToString(Formats.Excel.Iso8601DateTimeMilliseconds), Is.EqualTo(expectedIso8601WithMilliseconds));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Excel_English()
        {
            CultureInfo newCulture = new CultureInfo("EN-GB");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            Assert.That(Percentage1.ToString(Formats.Excel.Percentage2dp), Is.EqualTo("5.12%"));
            Assert.That(Percentage1.ToString(Formats.Excel.Percentage5dp), Is.EqualTo("5.12346%"));

            Assert.That(Integer1.ToString(Formats.Excel.Integer), Is.EqualTo("0"));
            Assert.That(Integer2.ToString(Formats.Excel.Integer), Is.EqualTo("12"));
            Assert.That(Integer3.ToString(Formats.Excel.Integer), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.Excel.Integer), Is.EqualTo("123,456"));
            Assert.That(Integer15.ToString(Formats.Excel.Integer), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Decimal1.ToString(Formats.Excel.Integer), Is.EqualTo("0"));
            Assert.That(Decimal2.ToString(Formats.Excel.Integer), Is.EqualTo("12"));
            Assert.That(Decimal3.ToString(Formats.Excel.Integer), Is.EqualTo("123"));
            Assert.That(Decimal6.ToString(Formats.Excel.Integer), Is.EqualTo("123,456"));
            Assert.That(Decimal15.ToString(Formats.Excel.Integer), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Integer1.ToString(Formats.Excel.IntegerPad3), Is.EqualTo("000"));
            Assert.That(Integer2.ToString(Formats.Excel.IntegerPad3), Is.EqualTo("012"));
            Assert.That(Integer3.ToString(Formats.Excel.IntegerPad3), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.Excel.IntegerPad3), Is.EqualTo("123,456"));
            Assert.That(Integer15.ToString(Formats.Excel.IntegerPad3), Is.EqualTo("123,456,789,012,345"));

            Assert.That(Integer1.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Integer2.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("12.00"));
            Assert.That(Integer3.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123.00"));
            Assert.That(Integer6.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123,456.00"));
            Assert.That(Integer15.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123,456,789,012,345.00"));

            Assert.That(Decimal1.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Decimal2.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("12.12"));
            Assert.That(Decimal3.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123.12"));
            Assert.That(Decimal6.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123,456.12"));
            Assert.That(Decimal15.ToString(Formats.Excel.Decimal2dp), Is.EqualTo("123,456,789,012,345.12"));

            Assert.That(Integer1.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Integer2.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("12.00000"));
            Assert.That(Integer3.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123.00000"));
            Assert.That(Integer6.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123,456.00000"));
            Assert.That(Integer15.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123,456,789,012,345.00000"));

            Assert.That(Decimal1.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Decimal2.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("12.12346"));
            Assert.That(Decimal3.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123.12346"));
            Assert.That(Decimal6.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123,456.12346"));
            Assert.That(Decimal15.ToString(Formats.Excel.Decimal5dp), Is.EqualTo("123,456,789,012,345.12346"));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Spanish()
        {
            CultureInfo newCulture = new CultureInfo("ES-ES");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage2dp), Is.EqualTo("5,12 %"));
            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage5dp), Is.EqualTo("5,12346 %"));

            Assert.That(Integer1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Integer2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Integer3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.Integer), Is.EqualTo("123.456"));
            Assert.That(Integer15.ToString(Formats.DotNet.Integer), Is.EqualTo("123.456.789.012.345"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Integer), Is.EqualTo("123.456"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Integer), Is.EqualTo("123.456.789.012.345"));

            Assert.That(Integer1.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("000"));
            Assert.That(Integer2.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("012"));
            Assert.That(Integer3.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456"));
            Assert.That(Integer15.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456789012345"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0,00"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12,00"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,00"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.456,00"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.456.789.012.345,00"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0,00"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12,12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123,12"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.456,12"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.456.789.012.345,12"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0,00000"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12,00000"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,00000"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.456,00000"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.456.789.012.345,00000"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0,00000"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12,12346"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123,12346"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.456,12346"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.456.789.012.345,12346"));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase]
        public void Test_Gujarati()
        {
            CultureInfo newCulture = new CultureInfo("GU");
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;

            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage2dp), Is.EqualTo("5.12%"));
            Assert.That(Percentage1.ToString(Formats.DotNet.Percentage5dp), Is.EqualTo("5.12346%"));

            Assert.That(Integer1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Integer2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Integer3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.Integer), Is.EqualTo("1,23,456"));
            Assert.That(Integer15.ToString(Formats.DotNet.Integer), Is.EqualTo("12,34,56,78,90,12,345"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Integer), Is.EqualTo("0"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Integer), Is.EqualTo("12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Integer), Is.EqualTo("123"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Integer), Is.EqualTo("1,23,456"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Integer), Is.EqualTo("12,34,56,78,90,12,345"));

            Assert.That(Integer1.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("000"));
            Assert.That(Integer2.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("012"));
            Assert.That(Integer3.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123"));
            Assert.That(Integer6.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456"));
            Assert.That(Integer15.ToString(Formats.DotNet.IntegerPad3), Is.EqualTo("123456789012345"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12.00"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.00"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("1,23,456.00"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12,34,56,78,90,12,345.00"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("0.00"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12.12"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("123.12"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("1,23,456.12"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal2dp), Is.EqualTo("12,34,56,78,90,12,345.12"));

            Assert.That(Integer1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Integer2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12.00000"));
            Assert.That(Integer3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.00000"));
            Assert.That(Integer6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("1,23,456.00000"));
            Assert.That(Integer15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12,34,56,78,90,12,345.00000"));

            Assert.That(Decimal1.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("0.00000"));
            Assert.That(Decimal2.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12.12346"));
            Assert.That(Decimal3.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("123.12346"));
            Assert.That(Decimal6.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("1,23,456.12346"));
            Assert.That(Decimal15.ToString(Formats.DotNet.Decimal5dp), Is.EqualTo("12,34,56,78,90,12,345.12346"));
        }
    }
}
