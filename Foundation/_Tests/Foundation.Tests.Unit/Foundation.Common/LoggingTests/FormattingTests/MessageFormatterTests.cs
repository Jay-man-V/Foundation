//-----------------------------------------------------------------------
// <copyright file="MessageFormatterTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Resources;

using Foundation.Tests.Unit.BaseClasses;
using Foundation.Tests.Unit.Mocks;

namespace Foundation.Tests.Unit.Foundation.Common.LoggingTests.FormattingTests
{
    /// <summary>
    /// The Message Formatter Tests
    /// </summary>
    [TestFixture]
    public class MessageFormatterTests : UnitTestBase
    {
        [TestCase]
        public void TestNestedException_NullObject()
        {
            const Object? anyObject = null;
            String expectedValue = "<null>";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_DbNullObject()
        {
            Object anyObject = DBNull.Value;
            String expectedValue = "<null>";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_ValidObject()
        {
            Object anyObject = new MockFoundationModel();
            String expectedValue = typeof(MockFoundationModel).ToString();

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_ListOfValidObjects()
        {
            DateTime workingDateTime = new DateTime(2022, 11, 28, 17, 12, 13, 123);
            String dateTimeString = workingDateTime.ToString(Formats.DotNet.DateTimeMilliseconds);
            String objectName = Guid.NewGuid().ToString();
            String typeName = typeof(MockFoundationModel).ToString();
            Object?[] anyObject =
            {
                workingDateTime,
                new RandomObject(objectName),
                new MockFoundationModel(),
                new MockFoundationModel(),
                null
            };
            String expectedValue = $"[{anyObject.Length}]->({dateTimeString}, '1' - '{objectName}', {typeName}, {typeName}, <null>)";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_DateTime()
        {
            DateTime anyObject = new DateTime(2019, 3, 22, 23, 55, 44);
            String expectedValue = "22-Mar-2019 23:55:44.000";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_StringEmpty()
        {
            String anyObject = String.Empty;
            String expectedValue = String.Empty;

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_String()
        {
            String anyObject = "Hello World!";
            String expectedValue = "Hello World!";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Boolean()
        {
            const Boolean anyObject = true;
            String expectedValue = "True";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Byte()
        {
            Byte anyObject = Byte.MaxValue;
            String expectedValue = "255";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Char()
        {
            Char anyObject = Char.MinValue;
            String expectedValue = "\0";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Decimal()
        {
            Decimal anyObject = Decimal.MinValue;
            String expectedValue = "-79228162514264337593543950335";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Single()
        {
            Single anyObject = Single.MinValue;
            String expectedValue = "-3.4028235E+38";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_SByte()
        {
            SByte anyObject = SByte.MinValue;
            String expectedValue = "-128";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Int16()
        {
            Int16 anyObject = Int16.MinValue;
            String expectedValue = "-32768";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Int32()
        {
            Int32 anyObject = Int32.MinValue;
            String expectedValue = "-2147483648";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_Int64()
        {
            Int64 anyObject = Int64.MinValue;
            String expectedValue = "-9223372036854775808";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_UInt16()
        {
            UInt16 anyObject = UInt16.MaxValue;
            String expectedValue = "65535";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_UInt32()
        {
            UInt32 anyObject = UInt32.MaxValue;
            String expectedValue = "4294967295";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void TestNestedException_UInt64()
        {
            UInt64 anyObject = UInt64.MaxValue;
            String expectedValue = "18446744073709551615";

            String actualValue = MessageFormatter.RenderObjectValue(anyObject);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
