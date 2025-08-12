//-----------------------------------------------------------------------
// <copyright file="GetTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models;
using Foundation.Resources;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application.ApplicationConfigurationServiceTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationServiceTests
    /// </summary>
    [TestFixture]
    public class GetTests : UnitTestBase
    {
        private IApplicationConfigurationService? TheService { get; set; }
        private IApplicationConfigurationRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheRepository = Substitute.For<IApplicationConfigurationRepository>();

            TheService = new ApplicationConfigurationService(TheRepository);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            base.TestCleanup();
        }

        [Test]
        public void Test_GetNullValue_Exception()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const IApplicationConfiguration? expectedValueFromDatabase = null;

            String errorMessage = $"Configuration value with Key '{key}' for application id '{applicationId.TheAppId}' not found. Null value retrieved from database.";
            NullValueException? actualException = null;

            try
            {
                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);
                TheService!.Get<String>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);
            }
            catch (NullValueException e)
            {
                actualException = e;
            }

            Assert.That(actualException, Is.Not.EqualTo(null));

            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [Test]
        public void Test_Get_StandardKeys()
        {
            String[] standardKeys =
            {
                ApplicationConfigurationKeys.UserDataPath,
                ApplicationConfigurationKeys.SystemDataPath,
                ApplicationConfigurationKeys.EmailFromAddress,
                ApplicationConfigurationKeys.EmailSmtpHostAddress,
                ApplicationConfigurationKeys.EmailSmtpHostPort,
                ApplicationConfigurationKeys.EmailSmtpHostPort,
                ApplicationConfigurationKeys.EmailSmtpHostEnableSsl,

                ApplicationConfigurationKeys.EmailSmtpHostUsername,
                ApplicationConfigurationKeys.EmailSmtpHostPassword,
                ApplicationConfigurationKeys.ServiceHolidaysNationalUkUrl,
                ApplicationConfigurationKeys.ServiceGeneratorPasswordRandomUrl,
                ApplicationConfigurationKeys.ServiceGeneratorPasswordMemorableUrl,
                ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleLength,
                ApplicationConfigurationKeys.ServiceGeneratorPasswordRuleCount,
            };

            AppId applicationId = new AppId(0);

            foreach (String key in standardKeys)
            {
                IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration{ Value = Guid.NewGuid().ToString() };

                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

                String actualValue = TheService!.Get<String>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

                Assert.That(actualValue, Is.EqualTo(expectedValueFromDatabase.Value));
            }
        }

        [Test]
        public void Test_Get_Boolean_True()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "true" };
            const Boolean expectedValue = true;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get<Boolean>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Boolean_False()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "false" };
            const Boolean expectedValue = false;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get<Boolean>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_TimeSpan()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "10:05:00" };
            TimeSpan expectedValue = new TimeSpan(10, 5, 0);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            TimeSpan actualValue = TheService!.Get<TimeSpan>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Date()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "2023-09-08" };
            DateTime expectedValue = new DateTime(2023, 09, 08);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_DateTime()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "2023-09-08 21:38:45" };
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_DateTimeMilliseconds()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "2023-09-08 21:38:45.123" };
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45, 123);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Guid()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = new Guid("{0B368339-E43E-4AFF-9FBC-C9F0074FD068}") };
            Guid expectedValue = new Guid("{0B368339-E43E-4AFF-9FBC-C9F0074FD068}");

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Guid actualValue = TheService!.Get<Guid>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Char()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = 'Z' };
            Char expectedValue = Convert.ToChar(expectedValueFromDatabase.Value);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Char actualValue = TheService!.Get<Char>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_String()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}" };
            String expectedValue = $"{expectedValueFromDatabase.Value}";

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            String actualValue = TheService!.Get<String>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Int16()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "32767" };
            const Int16 expectedValue = Int16.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int16 actualValue = TheService!.Get<Int16>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_UInt16()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "65535" };
            const UInt16 expectedValue = UInt16.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt16 actualValue = TheService!.Get<UInt16>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Int32()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "2147483647" };
            const Int32 expectedValue = Int32.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int32 actualValue = TheService!.Get<Int32>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_UInt32()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "4294967295" };
            const UInt32 expectedValue = UInt32.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt32 actualValue = TheService!.Get<UInt32>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Int64()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "9223372036854775807" };
            const Int64 expectedValue = Int64.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int64 actualValue = TheService!.Get<Int64>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_UInt64()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "18446744073709551615" };
            const UInt64 expectedValue = UInt64.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt64 actualValue = TheService!.Get<UInt64>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Decimal()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "79228162514264337593543950335" };
            const Decimal expectedValue = Decimal.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Decimal actualValue = TheService!.Get<Decimal>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Double()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "1.79769313486232" };
            const Double expectedValue = 1.79769313486232d;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Double actualValue = TheService!.Get<Double>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_Byte()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "255" };
            const Byte expectedValue = Byte.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Byte actualValue = TheService!.Get<Byte>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [Test]
        public void Test_Get_SByte()
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = "127" };
            const SByte expectedValue = SByte.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            SByte actualValue = TheService!.Get<SByte>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
