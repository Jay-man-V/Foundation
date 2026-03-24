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

        [TestCase]
        public void Test_SetAndGetValue_Boolean_True()
        {
            String key = $"{Guid.NewGuid()}-{LocationUtils.GetFunctionName()}";
            Boolean isEncrypted = false;

            Boolean defaultValue = true;
            Boolean expectedDefaultValue = true;

            Boolean newValue = true;
            Boolean expected = true;

            Boolean actualWithDefault = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, defaultValue);
            Assert.That(actualWithDefault, Is.EqualTo(expectedDefaultValue));

            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ConfigurationScope.User, key, isEncrypted, newValue);

            Boolean actual2 = TheService!.Get<Boolean>(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

            Assert.That(actual2, Is.EqualTo(expected));
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
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key, isEncrypted, expectedValue);

            // Get value at system level - should return system level value
            String actualValue3 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, key, expectedDefaultValue);
            Assert.That(actualValue3, Is.EqualTo(expectedValue));

            // Get value at user level - should return system level value as no user level value is set
            String actualValue4 = TheService!.Get(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key, expectedDefaultValue);
            Assert.That(actualValue4, Is.EqualTo(expectedValue));

            // User level default value 1 - should override system level default value
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, ConfigurationScope.User, key, isEncrypted, expectedUserValue1);
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

            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key + ".01", isEncrypted, expectedValue1);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key + ".02", isEncrypted, expectedValue2);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key + ".03", isEncrypted, expectedValue3);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key + ".04", isEncrypted, expectedValue4);
            TheService!.SetValue(CoreInstance.ApplicationId, CoreInstance.SystemUserProfile, ConfigurationScope.System, key + ".05", isEncrypted, expectedValue5);

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
