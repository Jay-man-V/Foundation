//-----------------------------------------------------------------------
// <copyright file="SetValueTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application.ApplicationConfigurationServiceTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationServiceTests
    /// </summary>
    [TestFixture]
    public class SetValueTests : UnitTestBase
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
        public void Test_SetValue_True(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Boolean value = true;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_False(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Boolean value = true;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Char(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Char value = 'Z';

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_String(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            String value = Guid.NewGuid().ToString();

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value).Returns(value);
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Sbyte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const SByte value = SByte.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Byte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Byte value = Byte.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Int16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int16 value = Int16.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_UInt16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt16 value = UInt16.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Int32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int32 value = Int32.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_UInt32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt32 value = UInt32.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Int64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int64 value = Int64.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_UInt64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt64 value = UInt64.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Double(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Double value = Double.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, $"{value}");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Decimal(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            Decimal value = Decimal.MaxValue;

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, $"{value}");
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Guid(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            Guid value = new Guid("{0b368339-e43e-4aff-9fbc-c9f0074fd068}");

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_TimeSpan(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            TimeSpan value = new TimeSpan(10, 5, 0);

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString()).Returns(value.ToString());
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_Date(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds)).Returns(value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds));
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_DateTime(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds)).Returns(value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds));
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, expected);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_SetValue_DateTimeMilliseconds(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45, 123);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            if (encrypted)
            {
                EncryptionService.EncryptData(key, value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds)).Returns(value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds));
            }

            TheService!.SetValue(applicationId, UserProfile, configurationScope, key, encrypted, value);

            TheRepository!.Received().SetValue(applicationId, UserProfile, configurationScope, key, expected);
        }
    }
}
