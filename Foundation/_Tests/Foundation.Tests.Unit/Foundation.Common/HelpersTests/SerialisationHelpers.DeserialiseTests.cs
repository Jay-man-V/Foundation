//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.DeserialiseTests.cs" company="JDV Software Ltd">
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
    public class SerialisationHelpersDeserialiseTests : UnitTestBase
    {
        [TestCase]
        public void Test_Deserialise_Boolean_True()
        {
            const String value =  "True";
            const Boolean expected = true;

            Boolean actual = SerialisationHelpers.Deserialise<Boolean>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Boolean_False()
        {
            const String value =  "False";
            const Boolean expected =  false;

            Boolean actual = SerialisationHelpers.Deserialise<Boolean>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_TimeSpan()
        {
            const String value =  "10:05:00";
            TimeSpan expected =  new TimeSpan(10, 5, 0);

            TimeSpan actual = SerialisationHelpers.Deserialise<TimeSpan>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Date()
        {
            const String value =  "2023-09-08T00:00:00.000";
            DateTime expected =  new DateTime(2023, 09, 08);

            DateTime actual = SerialisationHelpers.Deserialise<DateTime>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_DateTime()
        {
            const String value =  "2023-09-08T21:38:45.000";
            DateTime expected =  new DateTime(2023, 09, 08, 21, 38, 45);

            DateTime actual = SerialisationHelpers.Deserialise<DateTime>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_DateTimeMilliseconds()
        {
            const String value =  "2023-09-08T21:38:45.123";
            DateTime expected =  new DateTime(2023, 09, 08, 21, 38, 45, 123);

            DateTime actual = SerialisationHelpers.Deserialise<DateTime>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Guid()
        {
            const String value =  "0b368339-e43e-4aff-9fbc-c9f0074fd068";
            Guid expected =  Guid.Parse($"{{{value}}}");

            Guid actual = SerialisationHelpers.Deserialise<Guid>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Char()
        {
            const String value =  "Z";
            Char expected =  'Z';

            Char actual = SerialisationHelpers.Deserialise<Char>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_String()
        {
            const String value =  "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            String expected = value;

            String actual = SerialisationHelpers.Deserialise<String>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Empty()
        {
            String? value = String.Empty;
            String? expected = value;

            String actual = SerialisationHelpers.Deserialise<String>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Null()
        {
            String? value = null;
            String? expected = value;

            String actual = SerialisationHelpers.Deserialise<String>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Int16()
        {
            const String value =  "32767";
            const Int16 expected =  Int16.MaxValue;

            Int16 actual = SerialisationHelpers.Deserialise<Int16>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_UInt16()
        {
            const String value =  "65535";
            const UInt16 expected =  UInt16.MaxValue;

            UInt16 actual = SerialisationHelpers.Deserialise<UInt16>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Int32()
        {
            const String value =  "2147483647";
            const Int32 expected =  Int32.MaxValue;

            Int32 actual = SerialisationHelpers.Deserialise<Int32>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_UInt32()
        {
            const String value =  "4294967295";
            const UInt32 expected =  UInt32.MaxValue;

            UInt32 actual = SerialisationHelpers.Deserialise<UInt32>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Int64()
        {
            const String value =  "9223372036854775807";
            const Int64 expected =  Int64.MaxValue;

            Int64 actual = SerialisationHelpers.Deserialise<Int64>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_UInt64()
        {
            const String value =  "18446744073709551615";
            const UInt64 expected =  UInt64.MaxValue;

            UInt64 actual = SerialisationHelpers.Deserialise<UInt64>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Decimal()
        {
            const String value =  "79228162514264337593543950335";
            const Decimal expected =  Decimal.MaxValue;

            Decimal actual = SerialisationHelpers.Deserialise<Decimal>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Double()
        {
            const String value =  "1.79769313486232";
            const Double expected =  1.79769313486232d;

            Double actual = SerialisationHelpers.Deserialise<Double>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_Byte()
        {
            const String value =  "255";
            const Byte expected =  Byte.MaxValue;

            Byte actual = SerialisationHelpers.Deserialise<Byte>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_Deserialise_SByte()
        {
            const String value =  "127";
            const SByte expected =  SByte.MaxValue;

            SByte actual = SerialisationHelpers.Deserialise<SByte>(value);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
