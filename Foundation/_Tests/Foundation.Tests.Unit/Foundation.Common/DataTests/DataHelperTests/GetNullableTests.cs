//-----------------------------------------------------------------------
// <copyright file="GetNullableTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.DataTests.DataHelperTests
{
    /// <summary>
    /// The Get Nullable Tests class
    /// </summary>
    [TestFixture]
    public class GetNullableTests : UnitTestBase
    {
        private DataTable CreateTestDataTable()
        {
            DataTable retVal = new DataTable();

            retVal.Columns.Add("BooleanColumn", typeof(Boolean));
            retVal.Columns.Add("DoubleColumn", typeof(Double));
            retVal.Columns.Add("DecimalColumn", typeof(Decimal));
            retVal.Columns.Add("Int32Column", typeof(Int32));
            retVal.Columns.Add("DateTimeColumn", typeof(DateTime));
            retVal.Columns.Add("TimeSpanColumn", typeof(TimeSpan));
            retVal.Columns.Add("GuidColumn", typeof(Guid));

            retVal.Rows.Add(
                true,
                123.456d,
                789.123m,
                147,
                new DateTime(2022, 5, 7, 20, 28, 0),
                new TimeSpan(20, 29, 15),
                Guid.Parse("{1ABEAE17-8121-40F6-8888-E364D4328815}")
            );
            retVal.Rows.Add();

            return retVal;
        }

        /// <summary>
        /// Tests the Boolean value.
        /// </summary>
        [TestCase]
        public void Test_BooleanValue()
        {
            const Boolean expected = true;
            DataTable sourceData = CreateTestDataTable();
            Boolean? actual = DataHelpers.GetNullableBooleanValue(sourceData.Rows[0]["BooleanColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Boolean Null value.
        /// </summary>
        [TestCase]
        public void Test_BooleanNullValue()
        {
            Boolean? expected = null;
            DataTable sourceData = CreateTestDataTable();
            Boolean? actual = DataHelpers.GetNullableBooleanValue(sourceData.Rows[1]["BooleanColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Double value.
        /// </summary>
        [TestCase]
        public void Test_DoubleValue()
        {
            const Double expected = 123.456d;
            DataTable sourceData = CreateTestDataTable();
            Double? actual = DataHelpers.GetNullableDoubleValue(sourceData.Rows[0]["DoubleColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Double Null value.
        /// </summary>
        [TestCase]
        public void Test_DoubleNullValue()
        {
            Double? expected = null;
            DataTable sourceData = CreateTestDataTable();
            Double? actual = DataHelpers.GetNullableDoubleValue(sourceData.Rows[1]["DoubleColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Decimal value.
        /// </summary>
        [TestCase]
        public void Test_DecimalValue()
        {
            Decimal? expected = 789.123m;
            DataTable sourceData = CreateTestDataTable();
            Decimal? actual = DataHelpers.GetNullableDecimalValue(sourceData.Rows[0]["DecimalColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Decimal Null value.
        /// </summary>
        [TestCase]
        public void Test_DecimalNullValue()
        {
            Decimal? expected = null;
            DataTable sourceData = CreateTestDataTable();
            Decimal? actual = DataHelpers.GetNullableDecimalValue(sourceData.Rows[1]["DecimalColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Int32 value.
        /// </summary>
        [TestCase]
        public void Test_Int32Value()
        {
            Int32? expected = 147;
            DataTable sourceData = CreateTestDataTable();
            Int32? actual = DataHelpers.GetNullableInt32Value(sourceData.Rows[0]["Int32Column"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Int32 Null value.
        /// </summary>
        [TestCase]
        public void Test_Int32NullValue()
        {
            Int32? expected = null;
            DataTable sourceData = CreateTestDataTable();
            Int32? actual = DataHelpers.GetNullableInt32Value(sourceData.Rows[1]["Int32Column"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeValue()
        {
            DateTime? expected = new DateTime(2022, 5, 7, 20, 28, 0);
            DataTable sourceData = CreateTestDataTable();
            DateTime? actual = DataHelpers.GetNullableDateTimeValue(sourceData.Rows[0]["DateTimeColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime Null value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeNullValue()
        {
            DateTime? expected = null;
            DataTable sourceData = CreateTestDataTable();
            DateTime? actual = DataHelpers.GetNullableDateTimeValue(sourceData.Rows[1]["DateTimeColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TimeSpan value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanValue()
        {
            TimeSpan? expected = new TimeSpan(20, 29, 15);
            DataTable sourceData = CreateTestDataTable();
            TimeSpan? actual = DataHelpers.GetNullableTimeSpanValue(sourceData.Rows[0]["TimeSpanColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TimeSpan Null value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanNullValue()
        {
            TimeSpan? expected = null;
            DataTable sourceData = CreateTestDataTable();
            TimeSpan? actual = DataHelpers.GetNullableTimeSpanValue(sourceData.Rows[1]["TimeSpanColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Guid value.
        /// </summary>
        [TestCase]
        public void Test_GuidValue()
        {
            Guid? expected = Guid.Parse("{1ABEAE17-8121-40F6-8888-E364D4328815}");
            DataTable sourceData = CreateTestDataTable();
            Guid? actual = DataHelpers.GetNullableGuidValue(sourceData.Rows[0]["GuidColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Guid Null value.
        /// </summary>
        [TestCase]
        public void Test_GuidNullValue()
        {
            Guid? expected = null;
            DataTable sourceData = CreateTestDataTable();
            Guid? actual = DataHelpers.GetNullableGuidValue(sourceData.Rows[1]["GuidColumn"]);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
