//-----------------------------------------------------------------------
// <copyright file="SetValueTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

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

        [TestCase]
        public void Test_SetValue_True()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Boolean value = true;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_False()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Boolean value = true;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Char()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Char value = 'Z';

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_String()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            String value = Guid.NewGuid().ToString();

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);
        }

        [TestCase]
        public void Test_SetValue_Sbyte()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const SByte value = SByte.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Byte()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Byte value = Byte.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Int16()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int16 value = Int16.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_UInt16()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt16 value = UInt16.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Int32()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int32 value = Int32.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_UInt32()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt32 value = UInt32.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Int64()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Int64 value = Int64.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_UInt64()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const UInt64 value = UInt64.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Double()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            const Double value = Double.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, $"{value}");
        }

        [TestCase]
        public void Test_SetValue_Decimal()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            Decimal value = Decimal.MaxValue;

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, $"{value}");
        }

        [TestCase]
        public void Test_SetValue_Guid()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            Guid value = new Guid("{0b368339-e43e-4aff-9fbc-c9f0074fd068}");

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_TimeSpan()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            TimeSpan value = new TimeSpan(10, 5, 0);

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value.ToString());
        }

        [TestCase]
        public void Test_SetValue_Date()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, expected);
        }

        [TestCase]
        public void Test_SetValue_DateTime()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, expected);
        }

        [TestCase]
        public void Test_SetValue_DateTimeMilliseconds()
        {
            AppId applicationId = new AppId(0);
            const ConfigurationScope configurationScope = ConfigurationScope.System;
            const String key = "value";
            DateTime value = new DateTime(2023, 09, 08, 21, 38, 45, 123);
            String expected = value.ToString(Formats.DotNet.Iso8601DateTimeMilliseconds);

            TheService!.SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, value);

            TheRepository!.Received().SetValue(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, configurationScope, key, expected);
        }
    }
}
