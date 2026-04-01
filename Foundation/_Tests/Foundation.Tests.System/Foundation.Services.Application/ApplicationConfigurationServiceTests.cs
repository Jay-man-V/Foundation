//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// System Tests for ApplicationConfigurationService
    /// </summary>
    [TestFixture]
    public class ApplicationConfigurationServiceTests : SystemTestBase
    {
        private IApplicationConfigurationService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<IApplicationConfigurationService>();
        }

        [TestCase]
        public void Test_UserDataPath()
        {
            String expected = @"D:\Projects\UserData\";

            String actual = TheService!.UserDataPath;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_SystemDataPath()
        {
            String expected = @"D:\Projects\SystemData\";

            String actual = TheService!.SystemDataPath;

            Assert.That(actual, Is.EqualTo(expected));
        }

        private void Test_SetAndGetValue<T>(String key, T expected, T newValue, T defaultValue, T expectedDefaultValue)
        {
            T actualWithDefault = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, defaultValue);
            Assert.That(actualWithDefault, Is.EqualTo(expectedDefaultValue));

            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ConfigurationScope.User, isEncrypted: false, key, newValue);
            T actual2 = TheService!.Get<T>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);
            Assert.That(actual2, Is.EqualTo(expected));

            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ConfigurationScope.User, isEncrypted: true, key, newValue);
            T actual3 = TheService!.Get<T>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);
            Assert.That(actual3, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_SetAndGetValue_True()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Boolean defaultValue = true;
            Boolean expectedDefaultValue = defaultValue;

            Boolean newValue = true;
            Boolean expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_False()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Boolean defaultValue = false;
            Boolean expectedDefaultValue = defaultValue;

            Boolean newValue = false;
            Boolean expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Guid()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Guid defaultValue = Guid.NewGuid();
            Guid expectedDefaultValue = defaultValue;

            Guid newValue = Guid.NewGuid();
            Guid expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Int16()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Int16 defaultValue = Int16.MaxValue;
            Int16 expectedDefaultValue = defaultValue;

            Int16 newValue = Int16.MinValue;
            Int16 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_UInt16()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            UInt16 defaultValue = UInt16.MaxValue;
            UInt16 expectedDefaultValue = defaultValue;

            UInt16 newValue = 33768;
            UInt16 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Int32()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Int32 defaultValue = Int32.MaxValue;
            Int32 expectedDefaultValue = defaultValue;

            Int32 newValue = Int32.MinValue;
            Int32 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_UInt32()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            UInt32 defaultValue = UInt32.MaxValue;
            UInt32 expectedDefaultValue = defaultValue;

            UInt32 newValue = 2_247_483_647;
            UInt32 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Int64()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Int64 defaultValue = Int64.MaxValue;
            Int64 expectedDefaultValue = defaultValue;

            Int64 newValue = Int64.MinValue;
            Int64 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_UInt64()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            UInt64 defaultValue = UInt64.MaxValue;
            UInt64 expectedDefaultValue = defaultValue;

            UInt64 newValue = 3_247_483_647;
            UInt64 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Int128()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Int128 defaultValue = Int128.MaxValue;
            Int128 expectedDefaultValue = defaultValue;

            Int128 newValue = Int128.MinValue;
            Int128 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_UInt128()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            UInt128 defaultValue = UInt128.MaxValue;
            UInt128 expectedDefaultValue = defaultValue;

            UInt128 newValue = 6_247_483_647;
            UInt128 expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Decimal()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Decimal defaultValue = Decimal.MaxValue;
            Decimal expectedDefaultValue = defaultValue;

            Decimal newValue = Decimal.MinValue;
            Decimal expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Double()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Double defaultValue = Double.MaxValue;
            Double expectedDefaultValue = defaultValue;

            Double newValue = 6_247_483_647.012456789;
            Double expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Char()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            Char defaultValue = 'D';
            Char expectedDefaultValue = defaultValue;

            Char newValue = 'A';
            Char expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_String()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            String defaultValue = Guid.NewGuid().ToString();
            String expectedDefaultValue = defaultValue;

            String newValue = Guid.NewGuid().ToString();
            String expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_TimeSpan()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            TimeSpan defaultValue = new TimeSpan(5, 5, 5, 5);
            TimeSpan expectedDefaultValue = defaultValue;

            TimeSpan newValue = new TimeSpan(10, 10, 10, 10);
            TimeSpan expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_Date()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            DateTime defaultValue = new DateTime(2026, 03, 30);
            DateTime expectedDefaultValue = defaultValue;

            DateTime newValue = new DateTime(2020, 1, 1);
            DateTime expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_DateTime()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            DateTime defaultValue = new DateTime(2026, 03, 30, 20, 57, 05);
            DateTime expectedDefaultValue = defaultValue;

            DateTime newValue = new DateTime(2020, 1, 1, 09, 30, 30);
            DateTime expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_DateTime_Milliseconds()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            DateTime defaultValue = new DateTime(2026, 03, 30, 20, 57, 05, 123);
            DateTime expectedDefaultValue = defaultValue;

            DateTime newValue = new DateTime(2020, 1, 1, 09, 30, 30, 321);
            DateTime expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_LogId()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            LogId defaultValue = new LogId(123);
            LogId expectedDefaultValue = defaultValue;

            LogId newValue = new LogId(789);
            LogId expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_LogSeverity()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            LogSeverity defaultValue = LogSeverity.NotSet;
            LogSeverity expectedDefaultValue = defaultValue;

            LogSeverity newValue = LogSeverity.Audit;
            LogSeverity expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_AppId()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            AppId defaultValue = new AppId(123);
            AppId expectedDefaultValue = defaultValue;

            AppId newValue = new AppId(789);
            AppId expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_EntityId()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            EntityId defaultValue = new EntityId(123);
            EntityId expectedDefaultValue = defaultValue;

            EntityId newValue = new EntityId(789);
            EntityId expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_EmailAddress()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            EmailAddress defaultValue = new EmailAddress("testing@jdvsoftware.co.uk");
            EmailAddress expectedDefaultValue = defaultValue;

            EmailAddress newValue = new EmailAddress("info@jdvsoftware.com");
            EmailAddress expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_SetAndGetValue_TimeWindow()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";

            TimeWindow defaultValue = new TimeWindow(new TimeSpan(09, 00, 00), new TimeSpan(17, 30, 00));
            TimeWindow expectedDefaultValue = defaultValue;

            TimeWindow newValue = new TimeWindow(new TimeSpan(12, 00, 00), new TimeSpan(13, 00, 00));
            TimeWindow expected = newValue;

            Test_SetAndGetValue(key, expected, newValue, defaultValue, expectedDefaultValue);
        }

        [TestCase]
        public void Test_GetValue_Validate_Hierarchy()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";
            Boolean isEncrypted = false;

            String expectedValue = Guid.NewGuid().ToString();
            String expectedDefaultValue = Guid.NewGuid().ToString();
            String expectedUserValue1 = Guid.NewGuid().ToString();

            // First test, default value is returned when no value is set at any level
            String actualValue1 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, key, expectedDefaultValue);
            Assert.That(actualValue1, Is.EqualTo(expectedDefaultValue));

            String actualValue2 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, expectedDefaultValue);
            Assert.That(actualValue2, Is.EqualTo(expectedDefaultValue));



            // Second test, System level default value
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key, expectedValue);

            // Get value at system level - should return system level value
            String actualValue3 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, key, expectedDefaultValue);
            Assert.That(actualValue3, Is.EqualTo(expectedValue));

            // Get value at user level - should return system level value as no user level value is set
            String actualValue4 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, expectedDefaultValue);
            Assert.That(actualValue4, Is.EqualTo(expectedValue));

            // User level default value 1 - should override system level default value
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ConfigurationScope.User, isEncrypted, key, expectedUserValue1);
            String actualValue5 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, expectedDefaultValue);
            Assert.That(actualValue5, Is.EqualTo(expectedUserValue1));



            // User level default value 2 - should return system level value as no user 2 value is set
            IUserProfile user2 = CoreInstance.IoC.Get<IUserProfile>();
            user2.Id = new EntityId(123);
            String actualValue6 = TheService!.Get(CoreInstance.ApplicationId, user2, key, expectedDefaultValue);
            Assert.That(actualValue6, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_GroupValues()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";
            Boolean isEncrypted = false;

            String expectedValue1 = Guid.NewGuid().ToString();
            String expectedValue2 = Guid.NewGuid().ToString();
            String expectedValue3 = Guid.NewGuid().ToString();
            String expectedValue4 = Guid.NewGuid().ToString();
            String expectedValue5 = Guid.NewGuid().ToString();

            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key + ".01", expectedValue1);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key + ".02", expectedValue2);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key + ".03", expectedValue3);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key + ".04", expectedValue4);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, isEncrypted, key + ".05", expectedValue5);

            List<IApplicationConfiguration> values = TheService!.GetGroupValues(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, key);
            Assert.That(values.Count, Is.EqualTo(5));
            Assert.That(values[0].Value!.ToString(), Is.EqualTo(expectedValue1));
            Assert.That(values[1].Value!.ToString(), Is.EqualTo(expectedValue2));
            Assert.That(values[2].Value!.ToString(), Is.EqualTo(expectedValue3));
            Assert.That(values[3].Value!.ToString(), Is.EqualTo(expectedValue4));
            Assert.That(values[4].Value!.ToString(), Is.EqualTo(expectedValue5));
        }
    }
}
