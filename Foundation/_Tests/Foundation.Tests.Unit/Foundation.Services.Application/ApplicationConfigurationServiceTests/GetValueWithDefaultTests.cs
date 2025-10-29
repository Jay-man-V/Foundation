//-----------------------------------------------------------------------
// <copyright file="GetWithDefaultTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Models.Core;
using Foundation.Services.Application;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application.ApplicationConfigurationServiceTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationServiceTests
    /// </summary>
    [TestFixture]
    public class GetWithDefaultTests : UnitTestBase
    {
        private IApplicationConfigurationService? TheService { get; set; }
        private IApplicationConfigurationRepository? TheRepository { get; set; }
        private IEncryptionService EncryptionService { get; set; }
        private IUserProfile UserProfile { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            ICore core = Substitute.For<ICore>();
            TheRepository = Substitute.For<IApplicationConfigurationRepository>();
            EncryptionService = Substitute.For<IEncryptionService>();

            TheService = new ApplicationConfigurationService(core, TheRepository, EncryptionService);

            UserProfile = Substitute.For<IUserProfile>();
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            TheService = null;

            base.TestCleanup();
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Boolean_True(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "true";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Boolean expectedValue = true;
            const Boolean defaultValue = false;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Boolean_False(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "false";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Boolean expectedValue = false;
            const Boolean defaultValue = true;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Boolean actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_TimeSpan(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "10:05:00";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            TimeSpan expectedValue = new TimeSpan(10, 5, 0);
            TimeSpan defaultValue = new TimeSpan(12, 30, 0);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            TimeSpan actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Date(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "2023-09-08";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            DateTime expectedValue = new DateTime(2023, 09, 08);
            DateTime defaultValue = new DateTime(2020, 01, 01);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_DateTime(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "2023-09-08 21:38:45";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45);
            DateTime defaultValue = new DateTime(2020, 01, 01, 12, 30, 30);

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            DateTime actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Guid(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted};
            Guid expectedValue = Guid.Parse(value);
            Guid defaultValue = Guid.Empty;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Guid actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Char(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const Char value = 'Z';
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted};
            Char expectedValue = Convert.ToChar(expectedValueFromDatabase.Value);
            const Char defaultValue = 'N';

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value.ToString());
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Char actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_String(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            String expectedValue = $"{expectedValueFromDatabase.Value}";
            const String defaultValue = "No value";

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            String actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "32767";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int16 expectedValue = Int16.MaxValue;
            const Int16 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int16 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "65535";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt16 expectedValue = UInt16.MaxValue;
            const UInt16 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt16 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "2147483647";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int32 expectedValue = Int32.MaxValue;
            const Int32 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int32 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "4294967295";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt32 expectedValue = UInt32.MaxValue;
            const UInt32 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt32 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Int64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "9223372036854775807";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Int64 expectedValue = Int64.MaxValue;
            const Int64 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Int64 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_UInt64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "18446744073709551615";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const UInt64 expectedValue = UInt64.MaxValue;
            const UInt64 defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            UInt64 actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Decimal(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "79228162514264337593543950335";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Decimal expectedValue = Decimal.MaxValue;
            const Decimal defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Decimal actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Double(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "1.79769313486232";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Double expectedValue = 1.79769313486232d;
            const Double defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Double actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_Byte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "255";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const Byte expectedValue = Byte.MaxValue;
            const Byte defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            Byte actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_Get_SByte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "value";
            const String value = "127";
            IApplicationConfiguration expectedValueFromDatabase = new ApplicationConfiguration { Value = value, IsEncrypted = encrypted };
            const SByte expectedValue = SByte.MaxValue;
            const SByte defaultValue = 0;

            if (encrypted)
            {
                EncryptionService.DecryptData(key, expectedValueFromDatabase.Value!.ToString()!).Returns(value);
            }

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

            SByte actualValue = TheService!.Get(applicationId, UserProfile, key, defaultValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
