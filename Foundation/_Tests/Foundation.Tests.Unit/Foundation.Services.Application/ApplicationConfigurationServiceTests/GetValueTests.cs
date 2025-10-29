//-----------------------------------------------------------------------
// <copyright file="GetTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Core;
using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.Resources;
using Foundation.Services.Application;
using Foundation.Tests.Unit.BaseClasses;

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
        private IEncryptionService EncryptionService { get; set; }
        private IUserProfile UserProfile { get; set; }

        private AppId ApplicationId => new AppId(0);

        public override void TestInitialise()
        {
            base.TestInitialise();

            UserProfile = Substitute.For<IUserProfile>();

            ICore core = Substitute.For<ICore>();
            core.ApplicationId.Returns(ApplicationId);
            core.CurrentLoggedOnUser.Returns(new CurrentUser(UserProfile));

            TheRepository = Substitute.For<IApplicationConfigurationRepository>();
            EncryptionService = Substitute.For<IEncryptionService>();

            TheService = new ApplicationConfigurationService(core, TheRepository, EncryptionService);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            TheService = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_GetValue_NoValue_Exception()
        {
            const String key = "value";
            const IApplicationConfiguration? expectedValueFromDatabase = null;

            String errorMessage = $"Configuration value with Key '{key}' for application id '{ApplicationId.TheAppId}' not found. Null value retrieved from database.";
            NullValueException actualException = Assert.Throws<NullValueException>(() =>
            {
                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);
                TheService!.Get<String>(ApplicationId, UserProfile, key);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetValue_Null_Exception()
        {
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration();

            String errorMessage = $"Configuration value with Key '{key}' for application id '{ApplicationId.TheAppId}' is null. Null value retrieved from database.";
            NullValueException actualException = Assert.Throws<NullValueException>(() =>
            {
                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);
                TheService!.Get<String>(ApplicationId, UserProfile, key);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_GetValue_Empty_Exception()
        {
            const String key = "value";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration {Value = String.Empty};

            String errorMessage = $"Configuration value with Key '{key}' for application id '{ApplicationId.TheAppId}' could not be read as a string.";
            NullValueException actualException = Assert.Throws<NullValueException>(() =>
            {
                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);
                TheService!.Get<String>(ApplicationId, UserProfile, key);
            });

            Assert.That(actualException, Is.Not.EqualTo(null));
            Assert.That(actualException.Message, Is.EqualTo(errorMessage));
        }

        [TestCase]
        public void Test_Get_StandardKeys()
        {
            String[] standardKeys =
            [
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
            ];

            foreach (String key in standardKeys)
            {
                IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = Guid.NewGuid().ToString() };

                TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

                String actualValue = TheService!.Get<String>(ApplicationId, UserProfile, key);

                Assert.That(actualValue, Is.EqualTo(expectedValueFromDatabase.Value));
            }
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase(true, @".\UserData\")]
        [TestCase(true, @".\UserData")]
        [TestCase(false, @".\UserData\")]
        [TestCase(false, @".\UserData")]
        public void Test_UserDataPath(Boolean encrypted, String value)
        {
            String key = ApplicationConfigurationKeys.UserDataPath;
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const String expectedValue = @".\UserData\";

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(ApplicationId, UserProfile, key).Returns(expectedValueFromDatabase);

            String actualValue = TheService!.UserDataPath;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        /// <summary>
        ///
        /// </summary>
        [TestCase(true, @"\SystemData\")]
        [TestCase(true, @"\SystemData")]
        [TestCase(false, @"\SystemData\")]
        [TestCase(false, @"\SystemData")]
        public void Test_SystemDataPath(Boolean encrypted, String value)
        {
            String key = ApplicationConfigurationKeys.SystemDataPath;
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const String expectedValue = @"\SystemData\";

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            String actualValue = TheService!.SystemDataPath;

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Boolean_True(Boolean encrypted)
        {
            const String key = "value";
            const String value = "true";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Boolean expectedValue = true;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get<Boolean>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Boolean_False(Boolean encrypted)
        {
            const String key = "value";
            const String value = "false";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Boolean expectedValue = false;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get<Boolean>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_TimeSpan(Boolean encrypted)
        {
            const String key = "value";
            const String value = "10:05:00";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            TimeSpan expectedValue = new TimeSpan(10, 5, 0);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            TimeSpan actualValue = TheService!.Get<TimeSpan>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Date(Boolean encrypted)
        {
            const String key = "value";
            const String value = "2023-09-08";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            DateTime expectedValue = new DateTime(2023, 09, 08);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_DateTime(Boolean encrypted)
        {
            const String key = "value";
            const String value = "2023-09-08 21:38:45";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_DateTimeMilliseconds(Boolean encrypted)
        {
            const String key = "value";
            const String value = "2023-09-08 21:38:45.123";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45, 123);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get<DateTime>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Guid(Boolean encrypted)
        {
            const String key = "value";
            const String value = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            Guid expectedValue = Guid.Parse(value);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Guid actualValue = TheService!.Get<Guid>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Char(Boolean encrypted)
        {
            const String key = "value";
            const Char value = 'Z';
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted};
            Char expectedValue = Convert.ToChar(expectedValueFromDatabase.Value);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(expectedValue.ToString());
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Char actualValue = TheService!.Get<Char>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_String(Boolean encrypted)
        {
            const String key = "value";
            const String value = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            String expectedValue = $"{expectedValueFromDatabase.Value}";

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            String actualValue = TheService!.Get<String>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int16(Boolean encrypted)
        {
            const String key = "value";
            const String value = "32767";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int16 expectedValue = Int16.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int16 actualValue = TheService!.Get<Int16>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt16(Boolean encrypted)
        {
            const String key = "value";
            const String value = "65535";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt16 expectedValue = UInt16.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt16 actualValue = TheService!.Get<UInt16>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int32(Boolean encrypted)
        {
            const String key = "value";
            const String value = "2147483647";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int32 expectedValue = Int32.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int32 actualValue = TheService!.Get<Int32>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt32(Boolean encrypted)
        {
            const String key = "value";
            const String value = "4294967295";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt32 expectedValue = UInt32.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt32 actualValue = TheService!.Get<UInt32>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int64(Boolean encrypted)
        {
            const String key = "value";
            const String value = "9223372036854775807";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int64 expectedValue = Int64.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int64 actualValue = TheService!.Get<Int64>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt64(Boolean encrypted)
        {
            const String key = "value";
            const String value = "18446744073709551615";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt64 expectedValue = UInt64.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt64 actualValue = TheService!.Get<UInt64>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Decimal(Boolean encrypted)
        {
            const String key = "value";
            const String value = "79228162514264337593543950335";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Decimal expectedValue = Decimal.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Decimal actualValue = TheService!.Get<Decimal>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Double(Boolean encrypted)
        {
            const String key = "value";
            const String value = "1.79769313486232";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Double expectedValue = 1.79769313486232d;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Double actualValue = TheService!.Get<Double>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Byte(Boolean encrypted)
        {
            const String key = "value";
            const String value = "255";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Byte expectedValue = Byte.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Byte actualValue = TheService!.Get<Byte>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_SByte(Boolean encrypted)
        {
            const String key = "value";
            const String value = "127";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const SByte expectedValue = SByte.MaxValue;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            SByte actualValue = TheService!.Get<SByte>(ApplicationId, UserProfile, key);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
