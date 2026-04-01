//-----------------------------------------------------------------------
// <copyright file="SerialisationHelpers.SerialiseTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

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
            Object? value = null;

            String serialised = SerialisationHelpers.Serialise(value);
            Object deserialised = SerialisationHelpers.Deserialise<Object>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Boolean_True()
        {
            String expected = "True";
            Boolean value = true;

            String serialised = SerialisationHelpers.Serialise(value);
            Boolean deserialised = SerialisationHelpers.Deserialise<Boolean>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Boolean_False()
        {
            String expected = "False";
            Boolean value = false;

            String serialised = SerialisationHelpers.Serialise(value);
            Boolean deserialised = SerialisationHelpers.Deserialise<Boolean>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_TimeSpan()
        {
            String expected = "10:05:00";
            TimeSpan value = new TimeSpan(10, 5, 0);

            String serialised = SerialisationHelpers.Serialise(value);
            TimeSpan deserialised = SerialisationHelpers.Deserialise<TimeSpan>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Date()
        {
            String expected = "2023-09-08T00:00:00.000";
            DateTime value = new DateTime(2023, 09, 08);

            String serialised = SerialisationHelpers.Serialise(value);
            DateTime deserialised = SerialisationHelpers.Deserialise<DateTime>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_DateTime()
        {
            String expected = "2023-09-08T21:38:45.000";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45);

            String serialised = SerialisationHelpers.Serialise(value);
            DateTime deserialised = SerialisationHelpers.Deserialise<DateTime>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_DateTimeMilliseconds()
        {
            String expected = "2023-09-08T21:38:45.123";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45, 123);

            String serialised = SerialisationHelpers.Serialise(value);
            DateTime deserialised = SerialisationHelpers.Deserialise<DateTime>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Guid()
        {
            String expected = "0b368339-e43e-4aff-9fbc-c9f0074fd068";
            Guid value = Guid.Parse($"{{{expected}}}");

            String serialised = SerialisationHelpers.Serialise(value);
            Guid deserialised = SerialisationHelpers.Deserialise<Guid>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Char()
        {
            String expected = "Z";
            Char value = 'Z';

            String serialised = SerialisationHelpers.Serialise(value);
            Char deserialised = SerialisationHelpers.Deserialise<Char>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_String()
        {
            String expected = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            String value = expected;

            String serialised = SerialisationHelpers.Serialise(value);
            String deserialised = SerialisationHelpers.Deserialise<String>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_String_Empty()
        {
            String expected = String.Empty;
            Object? value = null;

            String serialised = SerialisationHelpers.Serialise(value);
            Object deserialised = SerialisationHelpers.Deserialise<Object>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Int16()
        {
            String expected = "32767";
            Int16 value = Int16.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            Int16 deserialised = SerialisationHelpers.Deserialise<Int16>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_UInt16()
        {
            String expected = "65535";
            UInt16 value = UInt16.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            UInt16 deserialised = SerialisationHelpers.Deserialise<UInt16>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Int32()
        {
            String expected = "2147483647";
            Int32 value = Int32.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            Int32 deserialised = SerialisationHelpers.Deserialise<Int32>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_UInt32()
        {
            String expected = "4294967295";
            UInt32 value = UInt32.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            UInt32 deserialised = SerialisationHelpers.Deserialise<UInt32>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Int64()
        {
            String expected = "9223372036854775807";
            Int64 value = Int64.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            Int64 deserialised = SerialisationHelpers.Deserialise<Int64>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_UInt64()
        {
            String expected = "18446744073709551615";
            UInt64 value = UInt64.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            UInt64 deserialised = SerialisationHelpers.Deserialise<UInt64>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Decimal()
        {
            String expected = "79228162514264337593543950335";
            Decimal value = Decimal.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            Decimal deserialised = SerialisationHelpers.Deserialise<Decimal>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Double()
        {
            String expected = "1.79769313486232";
            Double value = 1.79769313486232d;

            String serialised = SerialisationHelpers.Serialise(value);
            Double deserialised = SerialisationHelpers.Deserialise<Double>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Byte()
        {
            String expected = "255";
            Byte value = Byte.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            Byte deserialised = SerialisationHelpers.Deserialise<Byte>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_SByte()
        {
            String expected = "127";
            SByte value = SByte.MaxValue;

            String serialised = SerialisationHelpers.Serialise(value);
            SByte deserialised = SerialisationHelpers.Deserialise<SByte>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_Appid()
        {
            String expected = """
                              {
                                "TheAppId": 127
                              }
                              """;
            AppId value = new AppId(127);

            String serialised = SerialisationHelpers.Serialise(value);
            AppId deserialised = SerialisationHelpers.Deserialise<AppId>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_EmailAddress()
        {
            String expected = """
                              {
                                "TheEmailAddress": "info@JDVSoftware.com"
                              }
                              """;
            EmailAddress value = new EmailAddress("info@JDVSoftware.com");

            String serialised = SerialisationHelpers.Serialise(value);
            EmailAddress deserialised = SerialisationHelpers.Deserialise<EmailAddress>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
            Assert.That(deserialised.TheEmailAddress, Is.EqualTo(value.TheEmailAddress));
            Assert.That(deserialised.DomainName(), Is.EqualTo(value.DomainName()));
            Assert.That(deserialised.LocalPart(), Is.EqualTo(value.LocalPart()));
        }

        [TestCase]
        public void Test_Serialise_EntityId()
        {
            String expected = """
                              {
                                "TheEntityId": 127
                              }
                              """;
            EntityId value = new EntityId(127);

            String serialised = SerialisationHelpers.Serialise(value);
            EntityId deserialised = SerialisationHelpers.Deserialise<EntityId>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_LogId()
        {
            String expected = """
                              {
                                "TheLogId": 127
                              }
                              """;
            LogId value = new LogId(127);

            String serialised = SerialisationHelpers.Serialise(value);
            LogId deserialised = SerialisationHelpers.Deserialise<LogId>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_PostCode()
        {
            String expected = """
                              {
                                "Value": "hp11aa"
                              }
                              """;
            PostCode value = new PostCode("hp11aa");

            String serialised = SerialisationHelpers.Serialise(value);
            PostCode deserialised = SerialisationHelpers.Deserialise<PostCode>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_TelephoneNumber()
        {
            String expected = """
                               {
                                 "TheTelephoneNumber": "0123 1234 5678"
                               }
                               """;
            TelephoneNumber value = new TelephoneNumber("0123 1234 5678");

            String serialised = SerialisationHelpers.Serialise(value);
            TelephoneNumber deserialised = SerialisationHelpers.Deserialise<TelephoneNumber>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }

        [TestCase]
        public void Test_Serialise_TimeWindow()
        {
            String expected = """
                               {
                                 "StartTime": "09:00:00",
                                 "EndTime": "17:30:00"
                               }
                               """;
            TimeWindow value = new TimeWindow(new TimeSpan(09, 00, 00), new TimeSpan(17, 30, 00));

            String serialised = SerialisationHelpers.Serialise(value);
            TimeWindow deserialised = SerialisationHelpers.Deserialise<TimeWindow>(serialised);

            Assert.That(serialised, Is.EqualTo(expected));
            Assert.That(deserialised, Is.EqualTo(value));
        }
    }
}
