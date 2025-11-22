//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.SerialiseTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Common.HelpersTests
{
    /// <summary>
    /// The Serialisation Helpers Tests class
    /// </summary>
    [TestFixture]
    public class SerialisationHelpersSerialiseTests : UnitTestBase
    {
        [TestCase]
        public void Test_Serialise_Object_Null()
        {
            String expected = String.Empty;
            const Object? value = null;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Boolean_True()
        {
            const String expected = "True";
            const Boolean value = true;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Boolean_False()
        {
            const String expected = "False";
            const Boolean value = false;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_TimeSpan()
        {
            const String expected = "10:05:00";
            TimeSpan value = new TimeSpan(10, 5, 0);

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Date()
        {
            const String expected = "2023-09-08T00:00:00.000";
            DateTime value = new DateTime(2023, 09, 08);

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_DateTime()
        {
            const String expected = "2023-09-08T21:38:45.000";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45);

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_DateTimeMilliseconds()
        {
            const String expected = "2023-09-08T21:38:45.123";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45, 123);

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Guid()
        {
            const String expected = "0b368339-e43e-4aff-9fbc-c9f0074fd068";
            Guid value = Guid.Parse($"{{{expected}}}");

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Char()
        {
            const String expected = "Z";
            Char value = 'Z';

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_String()
        {
            const String expected = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            String value = expected;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Int16()
        {
            const String expected = "32767";
            const Int16 value = Int16.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_UInt16()
        {
            const String expected = "65535";
            const UInt16 value = UInt16.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Int32()
        {
            const String expected = "2147483647";
            const Int32 value = Int32.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_UInt32()
        {
            const String expected = "4294967295";
            const UInt32 value = UInt32.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Int64()
        {
            const String expected = "9223372036854775807";
            const Int64 value = Int64.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_UInt64()
        {
            const String expected = "18446744073709551615";
            const UInt64 value = UInt64.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Decimal()
        {
            const String expected = "79228162514264337593543950335";
            const Decimal value = Decimal.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Double()
        {
            const String expected = "1.79769313486232";
            const Double value = 1.79769313486232d;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_Byte()
        {
            const String expected = "255";
            const Byte value = Byte.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Serialise_SByte()
        {
            const String expected = "127";
            const SByte value = SByte.MaxValue;

            String actual = SerialisationHelpers.Serialise(value);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
