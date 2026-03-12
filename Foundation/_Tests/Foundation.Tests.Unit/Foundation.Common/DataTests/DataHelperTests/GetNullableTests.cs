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
            retVal.Columns.Add("UInt64Column", typeof(UInt64));
            retVal.Columns.Add("Int64Column", typeof(Int64));
            retVal.Columns.Add("UInt32Column", typeof(UInt32));
            retVal.Columns.Add("Int32Column", typeof(Int32));
            retVal.Columns.Add("UInt16Column", typeof(UInt16));
            retVal.Columns.Add("Int16Column", typeof(Int16));
            retVal.Columns.Add("DateTimeColumn", typeof(DateTime));
            retVal.Columns.Add("TimeSpanColumn", typeof(TimeSpan));
            retVal.Columns.Add("GuidColumn", typeof(Guid));

            retVal.Rows.Add(
                true,
                123.456d,
                789.123m,
                UInt64.MaxValue,
                Int64.MaxValue,
                UInt32.MaxValue,
                Int32.MaxValue,
                UInt16.MaxValue,
                Int16.MaxValue,
                new DateTime(2022, 5, 7, 20, 28, 0),
                new TimeSpan(20, 29, 15),
                Guid.Parse("{1ABEAE17-8121-40F6-8888-E364D4328815}")
            );
            retVal.Rows.Add();

            return retVal;
        }

        private void Test_GetNullableValue<T>(Func<Object, T?> getNullableValue, String columnName, T? expected) where T : struct
        {
            DataTable sourceData = CreateTestDataTable();

            T? actualValue = getNullableValue(sourceData.Rows[0][columnName]);
            Assert.That(actualValue, Is.EqualTo(expected));

            T? expectedNull = null;
            T? actual = getNullableValue(sourceData.Rows[1][columnName]);
            Assert.That(actual, Is.EqualTo(expectedNull));
        }

        /// <summary>
        /// Tests the Boolean value.
        /// </summary>
        [TestCase]
        public void Test_BooleanValue()
        {
            const Boolean expected = true;
            Test_GetNullableValue(DataHelpers.GetNullableBooleanValue, "BooleanColumn", expected);
        }

        /// <summary>
        /// Tests the Double value.
        /// </summary>
        [TestCase]
        public void Test_DoubleValue()
        {
            const Double expected = 123.456d;
            Test_GetNullableValue(DataHelpers.GetNullableDoubleValue, "DoubleColumn", expected);
        }

        /// <summary>
        /// Tests the Decimal value.
        /// </summary>
        [TestCase]
        public void Test_DecimalValue()
        {
            Decimal? expected = 789.123m;
            Test_GetNullableValue(DataHelpers.GetNullableDecimalValue, "DecimalColumn", expected);
        }

        /// <summary>
        /// Tests the UInt64 value.
        /// </summary>
        [TestCase]
        public void Test_UInt64Value()
        {
            UInt64? expected = UInt64.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableUInt64Value, "UInt64Column", expected);
        }

        /// <summary>
        /// Tests the Int64 value.
        /// </summary>
        [TestCase]
        public void Test_Int64Value()
        {
            Int64? expected = Int64.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableInt64Value, "Int64Column", expected);
        }

        /// <summary>
        /// Tests the UInt32 value.
        /// </summary>
        [TestCase]
        public void Test_UInt32Value()
        {
            UInt32? expected = UInt32.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableUInt32Value, "UInt32Column", expected);
        }

        /// <summary>
        /// Tests the Int32 value.
        /// </summary>
        [TestCase]
        public void Test_Int32Value()
        {
            Int32? expected = Int32.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableInt32Value, "Int32Column", expected);
        }

        /// <summary>
        /// Tests the UInt16 value.
        /// </summary>
        [TestCase]
        public void Test_UInt16Value()
        {
            UInt16? expected = UInt16.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableUInt16Value, "UInt16Column", expected);
        }

        /// <summary>
        /// Tests the Int16 value.
        /// </summary>
        [TestCase]
        public void Test_Int16Value()
        {
            Int16? expected = Int16.MaxValue;
            Test_GetNullableValue(DataHelpers.GetNullableInt16Value, "Int16Column", expected);
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeValue()
        {
            DateTime? expected = new DateTime(2022, 5, 7, 20, 28, 0);
            Test_GetNullableValue(DataHelpers.GetNullableDateTimeValue, "DateTimeColumn", expected);
        }

        /// <summary>
        /// Tests the TimeSpan value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanValue()
        {
            TimeSpan? expected = new TimeSpan(20, 29, 15);
            Test_GetNullableValue(DataHelpers.GetNullableTimeSpanValue, "TimeSpanColumn", expected);
        }

        /// <summary>
        /// Tests the Guid value.
        /// </summary>
        [TestCase]
        public void Test_GuidValue()
        {
            Guid? expected = Guid.Parse("{1ABEAE17-8121-40F6-8888-E364D4328815}");
            Test_GetNullableValue(DataHelpers.GetNullableGuidValue, "GuidColumn", expected);
        }
    }
}
