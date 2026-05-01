//-----------------------------------------------------------------------
// <copyright file="GetValueTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

using FEnums = Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.Common.DataTests.DataHelperTests
{
    /// <summary>
    /// The Get Value Tests class
    /// </summary>
    [TestFixture]
    public class GetValueTests : UnitTestBase
    {
        private readonly Guid _guid1 = Guid.NewGuid();

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
            retVal.Columns.Add("StringColumn", typeof(String));
            retVal.Columns.Add("ByteArrayColumn", typeof(Byte[]));
            retVal.Columns.Add("Image1Column", typeof(Image));
            retVal.Columns.Add("Image2Column", typeof(Byte[]));
            retVal.Columns.Add("GuidColumn", typeof(Guid));
            retVal.Columns.Add("EntityStatusColumn", typeof(EntityStatus));
            retVal.Columns.Add("TaskStatusColumn", typeof(FEnums.TaskStatus));
            retVal.Columns.Add("ScheduleIntervalColumn", typeof(ScheduleInterval));
            retVal.Columns.Add("LogSeverityColumn", typeof(LogSeverity));
            retVal.Columns.Add("MessageTypeColumn", typeof(MessageType));
            retVal.Columns.Add("EntityIdColumn", typeof(EntityId));
            retVal.Columns.Add("AppIdColumn", typeof(AppId));
            retVal.Columns.Add("LogIdColumn", typeof(LogId));
            retVal.Columns.Add("EmailAddressColumn", typeof(EmailAddress));
            retVal.Columns.Add("PostCodeColumn", typeof(PostCode));
            retVal.Columns.Add("TelephoneNumberColumn", typeof(TelephoneNumber));
            retVal.Columns.Add("DateTimeMillisecondColumn", typeof(DateTime));

            retVal.Rows.Add
            (
                true,
                Double.MaxValue,
                Decimal.MaxValue,
                UInt64.MaxValue,
                Int64.MaxValue,
                UInt32.MaxValue,
                Int32.MaxValue,
                UInt16.MaxValue,
                Int16.MaxValue,
                DateTime.MaxValue,
                TimeSpan.MaxValue,
                "String Value",
                new Byte[] {1,2,3,4,5,6,7,8,9,10},
                MakeBitmap(1,1),
                MakeBitmap(1,1).ToByteArray(),
                _guid1,
                EntityStatus.Active,
                FEnums.TaskStatus.Warning,
                ScheduleInterval.Days,
                LogSeverity.Audit,
                MessageType.Success,
                new EntityId(12345),
                new AppId(67890),
                new LogId(172839),
                new EmailAddress("Somewhere@mail.com"),
                new PostCode("HP1 1aa"),
                new TelephoneNumber("0123 4567 9876"),
                new DateTime(2022, 5, 7, 20, 28, 0, 123)
            );

            retVal.Rows.Add();

            return retVal;
        }

        private Image MakeBitmap(Int32 width, Int32 height)
        {
            Image retVal;
            Bitmap bmp = new Bitmap(width, height);
            MemoryStream ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);

            retVal = Image.FromStream(ms);

            return retVal;
        }

        private void Test_GetValue<T>(Func<Object, T, T> getValue, String columnName, T expected, T expectedDefaultValue)
        {
            DataTable sourceData = CreateTestDataTable();

            T actualValue = getValue(sourceData.Rows[0][columnName], expectedDefaultValue);
            AssertValues(actualValue, expected);

            T actualNull = getValue(sourceData.Rows[1][columnName], expectedDefaultValue);
            AssertValues(actualNull, expectedDefaultValue);
        }

        private void AssertValues<T>(T actual, T expected)
        {
            if (expected is Image expectedImage &&
                actual is Image actualImage)
            {
                Assert.That(actualImage.CompareAsByteArray(expectedImage));
            }
            else if (expected is EmailAddress expectedEmailAddress &&
                     actual is EmailAddress actualEmailAddress)
            {
                Assert.That(actualEmailAddress.ToString(), Is.EqualTo(expectedEmailAddress.ToString()));
            }
            else if (expected is PostCode expectedPostCode &&
                     actual is PostCode actualPostCode)
            {
                Assert.That(actualPostCode.ToString(), Is.EqualTo(expectedPostCode.ToString()));
            }
            else if (expected is TelephoneNumber expectedTelephoneNumber &&
                     actual is TelephoneNumber actualTelephoneNumber)
            {
                Assert.That(actualTelephoneNumber.ToString(), Is.EqualTo(expectedTelephoneNumber.ToString()));
            }
            else
            {
                Assert.That(actual, Is.EqualTo(expected));
            }
        }

        /// <summary>
        /// Tests the Boolean value.
        /// </summary>
        [TestCase]
        public void Test_BooleanValue()
        {
            const Boolean expected = true;
            const Boolean valueIfNull = false;
            Test_GetValue(DataHelpers.GetValue, "BooleanColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Double value.
        /// </summary>
        [TestCase]
        public void Test_DoubleValue()
        {
            Double expected = Double.MaxValue;
            Double valueIfNull = 157.753d;
            Test_GetValue(DataHelpers.GetValue, "DoubleColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Decimal value.
        /// </summary>
        [TestCase]
        public void Test_DecimalValue()
        {
            Decimal expected = Decimal.MaxValue;
            Decimal valueIfNull = 789.123m;
            Test_GetValue(DataHelpers.GetValue, "DecimalColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the UInt64 value.
        /// </summary>
        [TestCase]
        public void Test_UInt64Value()
        {
            UInt64 expected = UInt64.MaxValue;
            UInt64 valueIfNull = 147L;
            Test_GetValue(DataHelpers.GetValue, "UInt64Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Int64 value.
        /// </summary>
        [TestCase]
        public void Test_Int64Value()
        {
            Int64 expected = Int64.MaxValue;
            Int64 valueIfNull = 147L;
            Test_GetValue(DataHelpers.GetValue, "Int64Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the UInt32 value.
        /// </summary>
        [TestCase]
        public void Test_UInt32Value()
        {
            UInt32 expected = UInt32.MaxValue;
            UInt32 valueIfNull = 147;
            Test_GetValue(DataHelpers.GetValue, "UInt32Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Int32 value.
        /// </summary>
        [TestCase]
        public void Test_Int32Value()
        {
            Int32 expected = Int32.MaxValue;
            Int32 valueIfNull = 147;
            Test_GetValue(DataHelpers.GetValue, "Int32Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the UInt32 value.
        /// </summary>
        [TestCase]
        public void Test_UInt16Value()
        {
            UInt16 expected = UInt16.MaxValue;
            UInt16 valueIfNull = 147;
            Test_GetValue(DataHelpers.GetValue, "UInt16Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Int32 value.
        /// </summary>
        [TestCase]
        public void Test_Int16Value()
        {
            Int16 expected = Int16.MaxValue;
            Int16 valueIfNull = 147;
            Test_GetValue(DataHelpers.GetValue, "Int16Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeValue()
        {
            DateTime expected = DateTime.MaxValue;
            DateTime valueIfNull = new DateTime(2022, 5, 7, 20, 28, 0, 0);
            Test_GetValue(DataHelpers.GetValue, "DateTimeColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeMillisecondValue()
        {
            DateTime expected = new DateTime(2022, 5, 7, 20, 28, 0, 123);
            DateTime valueIfNull = new DateTime(2026, 3, 12, 08, 00, 0, 123);
            Test_GetValue(DataHelpers.GetValue, "DateTimeMillisecondColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the TimeSpan value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanValue()
        {
            TimeSpan expected = TimeSpan.MaxValue;
            TimeSpan valueIfNull = new TimeSpan(20, 29, 15);
            Test_GetValue(DataHelpers.GetValue, "TimeSpanColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the String value.
        /// </summary>
        [TestCase]
        public void Test_StringValue()
        {
            String expected = "String Value";
            String valueIfNull = $"{Guid.NewGuid()}String Value{Guid.NewGuid()}";
            Test_GetValue(DataHelpers.GetValue, "StringColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Byte[] value.
        /// </summary>
        [TestCase]
        public void Test_ByteArrayValue()
        {
            Byte[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            Byte[] valueIfNull = [100, 200, 101, 201, 102, 202, 103, 203, 104, 204];
            Test_GetValue(DataHelpers.GetValue, "ByteArrayColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Image value.
        /// </summary>
        [TestCase]
        public void Test_Image1Value()
        {
            Image expected = MakeBitmap(1, 1);
            Image valueIfNull = MakeBitmap(10, 10);
            Test_GetValue(DataHelpers.GetValue, "Image1Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Image value.
        /// </summary>
        [TestCase]
        public void Test_Image2Value()
        {
            Image expected = MakeBitmap(1, 1);
            Image valueIfNull = MakeBitmap(10, 10);
            Test_GetValue(DataHelpers.GetValue, "Image2Column", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the Guid value.
        /// </summary>
        [TestCase]
        public void Test_GuidValue()
        {
            Guid expected = _guid1;
            Guid valueIfNull = Guid.NewGuid();
            Test_GetValue(DataHelpers.GetValue, "GuidColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the EntityStatus value.
        /// </summary>
        [TestCase]
        public void Test_EntityStatusValue()
        {
            EntityStatus expected = EntityStatus.Active;
            EntityStatus valueIfNull = EntityStatus.Incomplete;
            Test_GetValue(DataHelpers.GetValue, "EntityStatusColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the TaskStatus value.
        /// </summary>
        [TestCase]
        public void Test_TaskStatusValue()
        {
            FEnums.TaskStatus expected = FEnums.TaskStatus.Warning;
            FEnums.TaskStatus valueIfNull = FEnums.TaskStatus.NotSet;
            Test_GetValue(DataHelpers.GetValue, "TaskStatusColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the ScheduleInterval value.
        /// </summary>
        [TestCase]
        public void Test_ScheduleIntervalValue()
        {
            ScheduleInterval expected = ScheduleInterval.Days;
            ScheduleInterval valueIfNull = ScheduleInterval.NotSet;
            Test_GetValue(DataHelpers.GetValue, "ScheduleIntervalColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the LogSeverity value.
        /// </summary>
        [TestCase]
        public void Test_LogSeverityValue()
        {
            LogSeverity expected = LogSeverity.Audit;
            LogSeverity valueIfNull = LogSeverity.NotSet;
            Test_GetValue(DataHelpers.GetValue, "LogSeverityColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the MessageType value.
        /// </summary>
        [TestCase]
        public void Test_MessageTypeValue()
        {
            MessageType expected = MessageType.Success;
            MessageType valueIfNull = MessageType.NotSet;
            Test_GetValue(DataHelpers.GetValue, "MessageTypeColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the EntityId value.
        /// </summary>
        [TestCase]
        public void Test_EntityIdValue()
        {
            EntityId expected = new EntityId(12345);
            EntityId valueIfNull = new EntityId(465789);
            Test_GetValue(DataHelpers.GetValue, "EntityIdColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the AppId value.
        /// </summary>
        [TestCase]
        public void Test_ApplicationIdValue()
        {
            AppId expected = new AppId(67890);
            AppId valueIfNull = new AppId(456789);
            Test_GetValue(DataHelpers.GetValue, "AppIdColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the AppId value.
        /// </summary>
        [TestCase]
        public void Test_LogIdValue()
        {
            LogId expected = new LogId(172839);
            LogId valueIfNull = new LogId(456789);
            Test_GetValue(DataHelpers.GetValue, "LogIdColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the EmailAddress value.
        /// </summary>
        [TestCase]
        public void Test_EmailAddressValue()
        {
            EmailAddress expected = new EmailAddress("Somewhere@mail.com");
            EmailAddress valueIfNull = new EmailAddress();
            Test_GetValue(DataHelpers.GetValue, "EmailAddressColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the PostCode value.
        /// </summary>
        [TestCase]
        public void Test_PostCodeValue()
        {
            PostCode expected = new PostCode("HP1 1aa");
            PostCode valueIfNull = new PostCode();
            Test_GetValue(DataHelpers.GetValue, "PostCodeColumn", expected, valueIfNull);
        }

        /// <summary>
        /// Tests the TelephoneNumber value.
        /// </summary>
        [TestCase]
        public void Test_TelephoneNumberValue()
        {
            TelephoneNumber expected = new TelephoneNumber("0123 4567 9876");
            TelephoneNumber valueIfNull = new TelephoneNumber();
            Test_GetValue(DataHelpers.GetValue, "TelephoneNumberColumn", expected, valueIfNull);
        }
    }
}
