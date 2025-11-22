//-----------------------------------------------------------------------
// <copyright file="GetValueTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Drawing;
using System.Drawing.Imaging;

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
        private readonly Guid _guid2 = Guid.NewGuid();

        private DataTable CreateTestDataTable()
        {
            DataTable retVal = new DataTable();

            retVal.Columns.Add("BooleanColumn", typeof(Boolean));
            retVal.Columns.Add("DoubleColumn", typeof(Double));
            retVal.Columns.Add("DecimalColumn", typeof(Decimal));
            retVal.Columns.Add("Int32Column", typeof(Int32));
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
            retVal.Columns.Add("DateTimeMillisecondColumn", typeof(DateTime));

            retVal.Rows.Add
            (
                true,
                123.456d,
                789.123m,
                147,
                new DateTime(2022, 5, 7, 20, 28, 0),
                new TimeSpan(20, 29, 15),
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
                new EmailAddress(),
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

        /// <summary>
        /// Tests the Boolean value.
        /// </summary>
        [TestCase]
        public void Test_BooleanValue()
        {
            const Boolean expected = true;
            DataTable sourceData = CreateTestDataTable();
            Boolean actual = DataHelpers.GetValue(sourceData.Rows[0]["BooleanColumn"], false);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Boolean Null value.
        /// </summary>
        [TestCase]
        public void Test_BooleanNullValue()
        {
            const Boolean expected = false;
            DataTable sourceData = CreateTestDataTable();
            Boolean actual = DataHelpers.GetValue(sourceData.Rows[1]["BooleanColumn"], false);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Double value.
        /// </summary>
        [TestCase]
        public void Test_DoubleValue()
        {
            Double expected = 123.456d;
            DataTable sourceData = CreateTestDataTable();
            Double actual = DataHelpers.GetValue(sourceData.Rows[0]["DoubleColumn"], 159.753d);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Double Null value.
        /// </summary>
        [TestCase]
        public void Test_DoubleNullValue()
        {
            Double expected = 159.753d;
            DataTable sourceData = CreateTestDataTable();
            Double actual = DataHelpers.GetValue(sourceData.Rows[1]["DoubleColumn"], 159.753d);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Decimal value.
        /// </summary>
        [TestCase]
        public void Test_DecimalValue()
        {
            Decimal expected = 789.123m;
            DataTable sourceData = CreateTestDataTable();
            Decimal actual = DataHelpers.GetValue(sourceData.Rows[0]["DecimalColumn"], 357.159m);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Decimal Null value.
        /// </summary>
        [TestCase]
        public void Test_DecimalNullValue()
        {
            Decimal expected = 357.159m;
            DataTable sourceData = CreateTestDataTable();
            Decimal actual = DataHelpers.GetValue(sourceData.Rows[1]["DecimalColumn"], 357.159m);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Int32 value.
        /// </summary>
        [TestCase]
        public void Test_Int32Value()
        {
            Int32 expected = 147;
            DataTable sourceData = CreateTestDataTable();
            Int32 actual = DataHelpers.GetValue(sourceData.Rows[0]["Int32Column"], 456);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Int32 Null value.
        /// </summary>
        [TestCase]
        public void Test_Int32NullValue()
        {
            Int32 expected = 456;
            DataTable sourceData = CreateTestDataTable();
            Int32 actual = DataHelpers.GetValue(sourceData.Rows[1]["Int32Column"], 456);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeValue()
        {
            DateTime expected = new DateTime(2022, 5, 7, 20, 28, 0, 0);
            DataTable sourceData = CreateTestDataTable();
            DateTime actual = DataHelpers.GetValue(sourceData.Rows[0]["DateTimeColumn"], new DateTime(2021, 2, 3, 4, 5, 6));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeMillisecondValue()
        {
            DateTime expected = new DateTime(2022, 5, 7, 20, 28, 0, 123);
            DataTable sourceData = CreateTestDataTable();
            DateTime actual = DataHelpers.GetValue(sourceData.Rows[0]["DateTimeMillisecondColumn"], new DateTime(2021, 2, 3, 4, 5, 6));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime Null value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeNullValue()
        {
            DateTime expected = new DateTime(2021, 2, 3, 4, 5, 6, 0);
            DataTable sourceData = CreateTestDataTable();
            DateTime actual = DataHelpers.GetValue(sourceData.Rows[1]["DateTimeColumn"], new DateTime(2021, 2, 3, 4, 5, 6));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the DateTime Null value.
        /// </summary>
        [TestCase]
        public void Test_DateTimeMillisecondNullValue()
        {
            DateTime expected = new DateTime(2021, 2, 3, 4, 5, 6, 123);
            DataTable sourceData = CreateTestDataTable();
            DateTime actual = DataHelpers.GetValue(sourceData.Rows[1]["DateTimeMillisecondColumn"], new DateTime(2021, 2, 3, 4, 5, 6, 123));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TimeSpan value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanValue()
        {
            TimeSpan expected = new TimeSpan(20, 29, 15);
            DataTable sourceData = CreateTestDataTable();
            TimeSpan actual = DataHelpers.GetValue(sourceData.Rows[0]["TimeSpanColumn"], new TimeSpan(1, 2, 3));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TimeSpan Null value.
        /// </summary>
        [TestCase]
        public void Test_TimeSpanNullValue()
        {
            TimeSpan expected = new TimeSpan(1, 2, 3);
            DataTable sourceData = CreateTestDataTable();
            TimeSpan actual = DataHelpers.GetValue(sourceData.Rows[1]["TimeSpanColumn"], new TimeSpan(1, 2, 3));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the String value.
        /// </summary>
        [TestCase]
        public void Test_StringValue()
        {
            String expected = "String Value";
            DataTable sourceData = CreateTestDataTable();
            String actual = DataHelpers.GetValue(sourceData.Rows[0]["StringColumn"], "Default Value");

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the String Null value.
        /// </summary>
        [TestCase]
        public void Test_StringNullValue()
        {
            String expected = "Default Value";
            DataTable sourceData = CreateTestDataTable();
            String actual = DataHelpers.GetValue(sourceData.Rows[1]["StringColumn"], "Default Value");

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Byte[] value.
        /// </summary>
        [TestCase]
        public void Test_ByteArrayValue()
        {
            Byte[] expected = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10];
            DataTable sourceData = CreateTestDataTable();
            Byte[] actual = DataHelpers.GetValue(sourceData.Rows[0]["ByteArrayColumn"], [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]);

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        /// <summary>
        /// Tests the Byte[] Null value.
        /// </summary>
        [TestCase]
        public void Test_ByteArrayNullValue()
        {
            Byte[] expected = [10, 20, 30, 40, 50, 60, 70, 80, 90, 100];
            DataTable sourceData = CreateTestDataTable();
            Byte[] actual = DataHelpers.GetValue(sourceData.Rows[1]["ByteArrayColumn"], [10, 20, 30, 40, 50, 60, 70, 80, 90, 100]);

            Assert.That(actual, Is.EquivalentTo(expected));
        }

        /// <summary>
        /// Tests the Image value.
        /// </summary>
        [TestCase]
        public void Test_Image1Value()
        {
            Image expected = MakeBitmap(1, 1);
            DataTable sourceData = CreateTestDataTable();
            Image actual = DataHelpers.GetValue(sourceData.Rows[0]["Image1Column"], MakeBitmap(10, 10));

            Assert.That(expected.CompareAsByteArray(actual));
        }

        /// <summary>
        /// Tests the Image Null value.
        /// </summary>
        [TestCase]
        public void Test_Image1NullValue()
        {
            Image expected = MakeBitmap(10, 10);
            DataTable sourceData = CreateTestDataTable();
            Image actual = DataHelpers.GetValue(sourceData.Rows[1]["Image1Column"], MakeBitmap(10, 10));

            Assert.That(expected.CompareAsByteArray(actual));
        }

        /// <summary>
        /// Tests the Image value.
        /// </summary>
        [TestCase]
        public void Test_Image2Value()
        {
            Image expected = MakeBitmap(1, 1);
            DataTable sourceData = CreateTestDataTable();
            Image actual = DataHelpers.GetValue(sourceData.Rows[0]["Image2Column"], MakeBitmap(10, 10));

            Assert.That(expected.CompareAsByteArray(actual));
        }

        /// <summary>
        /// Tests the Image Null value.
        /// </summary>
        [TestCase]
        public void Test_Image2NullValue()
        {
            Image expected = MakeBitmap(10, 10);
            DataTable sourceData = CreateTestDataTable();
            Image actual = DataHelpers.GetValue(sourceData.Rows[1]["Image2Column"], MakeBitmap(10, 10));

            Assert.That(expected.CompareAsByteArray(actual));
        }

        /// <summary>
        /// Tests the Guid value.
        /// </summary>
        [TestCase]
        public void Test_GuidValue()
        {
            Guid expected = _guid1;
            DataTable sourceData = CreateTestDataTable();
            Guid actual = DataHelpers.GetValue(sourceData.Rows[0]["GuidColumn"], _guid2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the Guid Null value.
        /// </summary>
        [TestCase]
        public void Test_GuidNullValue()
        {
            Guid expected = _guid2;
            DataTable sourceData = CreateTestDataTable();
            Guid actual = DataHelpers.GetValue(sourceData.Rows[1]["GuidColumn"], _guid2);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the EntityStatus value.
        /// </summary>
        [TestCase]
        public void Test_EntityStatusValue()
        {
            EntityStatus expected = EntityStatus.Active;
            DataTable sourceData = CreateTestDataTable();
            EntityStatus actual = DataHelpers.GetValue(sourceData.Rows[0]["EntityStatusColumn"], EntityStatus.Incomplete);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the EntityStatus Null value.
        /// </summary>
        [TestCase]
        public void Test_EntityStatusNullValue()
        {
            EntityStatus expected = EntityStatus.Incomplete;
            DataTable sourceData = CreateTestDataTable();
            EntityStatus actual = DataHelpers.GetValue(sourceData.Rows[1]["EntityStatusColumn"], EntityStatus.Incomplete);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TaskStatus value.
        /// </summary>
        [TestCase]
        public void Test_TaskStatusValue()
        {
            FEnums.TaskStatus expected = FEnums.TaskStatus.Warning;
            DataTable sourceData = CreateTestDataTable();
            FEnums.TaskStatus actual = DataHelpers.GetValue(sourceData.Rows[0]["TaskStatusColumn"], FEnums.TaskStatus.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the TaskStatus Null value.
        /// </summary>
        [TestCase]
        public void Test_TaskStatusNullValue()
        {
            FEnums.TaskStatus expected = FEnums.TaskStatus.NotSet;
            DataTable sourceData = CreateTestDataTable();
            FEnums.TaskStatus actual = DataHelpers.GetValue(sourceData.Rows[1]["TaskStatusColumn"], FEnums.TaskStatus.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the ScheduleInterval value.
        /// </summary>
        [TestCase]
        public void Test_ScheduleIntervalValue()
        {
            ScheduleInterval expected = ScheduleInterval.Days;
            DataTable sourceData = CreateTestDataTable();
            ScheduleInterval actual = DataHelpers.GetValue(sourceData.Rows[0]["ScheduleIntervalColumn"], ScheduleInterval.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the ScheduleInterval Null value.
        /// </summary>
        [TestCase]
        public void Test_ScheduleIntervalNullValue()
        {
            ScheduleInterval expected = ScheduleInterval.NotSet;
            DataTable sourceData = CreateTestDataTable();
            ScheduleInterval actual = DataHelpers.GetValue(sourceData.Rows[1]["ScheduleIntervalColumn"], ScheduleInterval.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the LogSeverity value.
        /// </summary>
        [TestCase]
        public void Test_LogSeverityValue()
        {
            LogSeverity expected = LogSeverity.Audit;
            DataTable sourceData = CreateTestDataTable();
            LogSeverity actual = DataHelpers.GetValue(sourceData.Rows[0]["LogSeverityColumn"], LogSeverity.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the LogSeverity Null value.
        /// </summary>
        [TestCase]
        public void Test_LogSeverityNullValue()
        {
            LogSeverity expected = LogSeverity.NotSet;
            DataTable sourceData = CreateTestDataTable();
            LogSeverity actual = DataHelpers.GetValue(sourceData.Rows[1]["LogSeverityColumn"], LogSeverity.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the MessageType value.
        /// </summary>
        [TestCase]
        public void Test_MessageTypeValue()
        {
            MessageType expected = MessageType.Success;
            DataTable sourceData = CreateTestDataTable();
            MessageType actual = DataHelpers.GetValue(sourceData.Rows[0]["MessageTypeColumn"], MessageType.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the MessageType Null value.
        /// </summary>
        [TestCase]
        public void Test_MessageTypeNullValue()
        {
            MessageType expected = MessageType.NotSet;
            DataTable sourceData = CreateTestDataTable();
            MessageType actual = DataHelpers.GetValue(sourceData.Rows[1]["MessageTypeColumn"], MessageType.NotSet);

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the EntityId value.
        /// </summary>
        [TestCase]
        public void Test_EntityIdValue()
        {
            EntityId expected = new EntityId(12345);
            DataTable sourceData = CreateTestDataTable();
            EntityId actual = DataHelpers.GetValue(sourceData.Rows[0]["EntityIdColumn"], new EntityId(456789));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the EntityId Null value.
        /// </summary>
        [TestCase]
        public void Test_EntityIdNullValue()
        {
            EntityId expected = new EntityId(456789);
            DataTable sourceData = CreateTestDataTable();
            EntityId actual = DataHelpers.GetValue(sourceData.Rows[1]["EntityIdColumn"], new EntityId(456789));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the AppId value.
        /// </summary>
        [TestCase]
        public void Test_ApplicationIdValue()
        {
            AppId expected = new AppId(67890);
            DataTable sourceData = CreateTestDataTable();
            AppId actual = DataHelpers.GetValue(sourceData.Rows[0]["AppIdColumn"], new AppId(456789));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the AppId Null value.
        /// </summary>
        [TestCase]
        public void Test_ApplicationIdNullValue()
        {
            AppId expected = new AppId(456789);
            DataTable sourceData = CreateTestDataTable();
            AppId actual = DataHelpers.GetValue(sourceData.Rows[1]["AppIdColumn"], new AppId(456789));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the AppId value.
        /// </summary>
        [TestCase]
        public void Test_LogIdValue()
        {
            LogId expected = new LogId(172839);
            DataTable sourceData = CreateTestDataTable();
            LogId actual = DataHelpers.GetValue(sourceData.Rows[0]["LogIdColumn"], new LogId(172839));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the AppId Null value.
        /// </summary>
        [TestCase]
        public void Test_LogIdNullValue()
        {
            LogId expected = new LogId(172839);
            DataTable sourceData = CreateTestDataTable();
            LogId actual = DataHelpers.GetValue(sourceData.Rows[1]["LogIdColumn"], new LogId(172839));

            Assert.That(actual, Is.EqualTo(expected));
        }

        /// <summary>
        /// Tests the EmailAddress value.
        /// </summary>
        [TestCase]
        public void Test_EmailAddressValue()
        {
            EmailAddress expected = new EmailAddress();
            DataTable sourceData = CreateTestDataTable();
            EmailAddress actual = DataHelpers.GetValue(sourceData.Rows[0]["EmailAddressColumn"], new EmailAddress());

            Assert.That(actual.ToString(), Is.EqualTo(expected.ToString()));
        }

        /// <summary>
        /// Tests the EntityId Null value.
        /// </summary>
        [TestCase]
        public void Test_EmailAddressNullValue()
        {
            EmailAddress expected = new EmailAddress("unknown@world.com");
            DataTable sourceData = CreateTestDataTable();
            EmailAddress actual = DataHelpers.GetValue(sourceData.Rows[1]["EntityIdColumn"], new EmailAddress("unknown@world.com"));

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
