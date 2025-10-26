//-----------------------------------------------------------------------
// <copyright file="GetGroupTests.cs" company="JDV Software Ltd">
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
    public class GetGroupTests : UnitTestBase
    {
        private IApplicationConfigurationService? TheService { get; set; }
        private IApplicationConfigurationRepository? TheRepository { get; set; }
        private IUserProfile? UserProfile { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheRepository = Substitute.For<IApplicationConfigurationRepository>();
            IEncryptionService encryptionService = Substitute.For<IEncryptionService>();

            TheService = new ApplicationConfigurationService(TheRepository, encryptionService);

            UserProfile = Substitute.For<IUserProfile>();
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            TheService = null;

            base.TestCleanup();
        }

        private IApplicationConfiguration CreateReturnItem<TValue>(String key, TValue value)
        {
            IApplicationConfiguration retVal = new ApplicationConfiguration();

            retVal.Key = key;
            retVal.Value = value;

            return retVal;
        }

        [TestCase]
        public void Test_GetValue_Boolean_True()
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", true),
                CreateReturnItem("Key.2", true),
                CreateReturnItem("Key.3", true),
            ];

            TheRepository!.GetGroupValues(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValues);

            List<IApplicationConfiguration> actualValues = TheService!.GetGroupValues(applicationId, UserProfile!, key);

            Assert.That(actualValues.Count, Is.EqualTo(3));

            Assert.That(actualValues[0].Key, Is.EqualTo(expectedValues[0].Key));
            Assert.That(actualValues[1].Key, Is.EqualTo(expectedValues[1].Key));
            Assert.That(actualValues[2].Key, Is.EqualTo(expectedValues[2].Key));

            Assert.That(actualValues[0].Value, Is.EqualTo(expectedValues[0].Value));
            Assert.That(actualValues[1].Value, Is.EqualTo(expectedValues[1].Value));
            Assert.That(actualValues[2].Value, Is.EqualTo(expectedValues[2].Value));
        }

        //[TestCase]
        //public void Test_GetValue_Boolean_False()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "false";
        //    const Boolean expectedValue = false;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Boolean actualValue = process.GetValue<Boolean>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_TimeSpan()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "10:05:00";
        //    TimeSpan expectedValue = new TimeSpan(10, 5, 0);
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    TimeSpan actualValue = process.GetValue<TimeSpan>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Date()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "2023-09-08";
        //    DateTime expectedValue = new DateTime(2023, 09, 08);
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    DateTime actualValue = process.GetValue<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_DateTime()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "2023-09-08 21:38:45";
        //    DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45);
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    DateTime actualValue = process.GetValue<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_DateTimeMilliseconds()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "2023-09-08 21:38:45.123";
        //    DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45, 123);
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    DateTime actualValue = process.GetValue<DateTime>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Guid()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    Guid expectedValueFromDatabase = new Guid("{0B368339-E43E-4AFF-9FBC-C9F0074FD068}");
        //    Guid expectedValue = expectedValueFromDatabase;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Guid actualValue = process.GetValue<Guid>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Char()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const Char expectedValueFromDatabase = 'Z';
        //    Char expectedValue = expectedValueFromDatabase;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Char actualValue = process.GetValue<Char>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_String()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "{0B368339-E43E-4AFF-9FBC-C9F0074FD068}";
        //    String expectedValue = expectedValueFromDatabase;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    String actualValue = process.GetValue<String>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Int16()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "32767";
        //    const Int16 expectedValue = Int16.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Int16 actualValue = process.GetValue<Int16>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_UInt16()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "65535";
        //    const UInt16 expectedValue = UInt16.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    UInt16 actualValue = process.GetValue<UInt16>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Int32()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "2147483647";
        //    const Int32 expectedValue = Int32.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Int32 actualValue = process.GetValue<Int32>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_UInt32()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "4294967295";
        //    const UInt32 expectedValue = UInt32.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    UInt32 actualValue = process.GetValue<UInt32>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Int64()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "9223372036854775807";
        //    const Int64 expectedValue = Int64.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Int64 actualValue = process.GetValue<Int64>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_UInt64()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "18446744073709551615";
        //    const UInt64 expectedValue = UInt64.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    UInt64 actualValue = process.GetValue<UInt64>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Decimal()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "79228162514264337593543950335";
        //    const Decimal expectedValue = Decimal.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Decimal actualValue = process.GetValue<Decimal>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Double()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "1.79769313486232";
        //    const Double expectedValue = 1.79769313486232d;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Double actualValue = process.GetValue<Double>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_Byte()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "255";
        //    const Byte expectedValue = Byte.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    Byte actualValue = process.GetValue<Byte>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}

        //[TestCase]
        //public void Test_GetValue_SByte()
        //{
        //    AppId applicationId = new AppId(0);
        //    const String key = "value";
        //    const String expectedValueFromDatabase = "127";
        //    const SByte expectedValue = SByte.MaxValue;
        //    EntityRepository.GetValue(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(expectedValueFromDatabase);

        //    IApplicationConfigurationProcess<String> process = CreateBusinessProcess();

        //    SByte actualValue = process.GetValue<SByte>(applicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, key);

        //    Assert.That(actualValue, Is.EqualTo(expectedValue));
        //}
    }
}
