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
        private IEncryptionService EncryptionService { get; set; }
        private IUserProfile? UserProfile { get; set; }

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

        private IApplicationConfiguration CreateReturnItem<TValue>(String key, TValue value)
        {
            IApplicationConfiguration retVal = new ApplicationConfiguration();

            retVal.Key = key;
            retVal.Value = value;

            return retVal;
        }

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Boolean_True(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", true),
                CreateReturnItem("Key.2", true),
                CreateReturnItem("Key.3", true),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Boolean_False(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", false),
                CreateReturnItem("Key.2", false),
                CreateReturnItem("Key.3", false),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_TimeSpan(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", new TimeSpan(01, 02, 03)),
                CreateReturnItem("Key.2", new TimeSpan(01, 02, 03, 04)),
                CreateReturnItem("Key.3", new TimeSpan(01, 02, 03, 04, 05)),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Date(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", new DateTime(2025, 12, 27)),
                CreateReturnItem("Key.2", new DateTime(2025, 12, 28)),
                CreateReturnItem("Key.3", new DateTime(2025, 12, 29)),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_DateTime(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", new DateTime(2025, 12, 27, 01, 02, 03)),
                CreateReturnItem("Key.2", new DateTime(2025, 12, 28, 04, 05, 06)),
                CreateReturnItem("Key.3", new DateTime(2025, 12, 29, 07, 08, 09)),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_DateTimeMilliseconds(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", new DateTime(2025, 12, 27, 01, 02, 03, 123)),
                CreateReturnItem("Key.2", new DateTime(2025, 12, 28, 04, 05, 06, 456)),
                CreateReturnItem("Key.3", new DateTime(2025, 12, 29, 07, 08, 09, 789)),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Guid(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Guid.NewGuid()),
                CreateReturnItem("Key.2", Guid.NewGuid()),
                CreateReturnItem("Key.3", Guid.NewGuid()),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Char(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", 'a'),
                CreateReturnItem("Key.2", 'b'),
                CreateReturnItem("Key.3", 'c'),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_String(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Guid.NewGuid().ToString()),
                CreateReturnItem("Key.2", Guid.NewGuid().ToString()),
                CreateReturnItem("Key.3", Guid.NewGuid().ToString()),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Int16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Int16.MaxValue - 123),
                CreateReturnItem("Key.2", Int16.MaxValue - 456),
                CreateReturnItem("Key.3", Int16.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_UInt16(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", UInt16.MaxValue - 123),
                CreateReturnItem("Key.2", UInt16.MaxValue - 456),
                CreateReturnItem("Key.3", UInt16.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Int32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Int32.MaxValue - 123),
                CreateReturnItem("Key.2", Int32.MaxValue - 456),
                CreateReturnItem("Key.3", Int32.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_UInt32(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", UInt32.MaxValue - 123),
                CreateReturnItem("Key.2", UInt32.MaxValue - 456),
                CreateReturnItem("Key.3", UInt32.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Int64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Int64.MaxValue - 123),
                CreateReturnItem("Key.2", Int64.MaxValue - 456),
                CreateReturnItem("Key.3", Int64.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_UInt64(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", UInt64.MaxValue - 123),
                CreateReturnItem("Key.2", UInt64.MaxValue - 456),
                CreateReturnItem("Key.3", UInt64.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Decimal(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Decimal.MaxValue - 123),
                CreateReturnItem("Key.2", Decimal.MaxValue - 456),
                CreateReturnItem("Key.3", Decimal.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Double(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Double.MaxValue - 123),
                CreateReturnItem("Key.2", Double.MaxValue - 456),
                CreateReturnItem("Key.3", Double.MaxValue - 789),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_Byte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", Byte.MaxValue - 12),
                CreateReturnItem("Key.2", Byte.MaxValue - 45),
                CreateReturnItem("Key.3", Byte.MaxValue - 78),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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

        [TestCase(true)]
        [TestCase(false)]
        public void Test_GetValue_SByte(Boolean encrypted)
        {
            AppId applicationId = new AppId(0);
            const String key = "Key";

            List<IApplicationConfiguration> expectedValues =
            [
                CreateReturnItem("Key.1", SByte.MaxValue - 23),
                CreateReturnItem("Key.2", SByte.MaxValue - 56),
                CreateReturnItem("Key.3", SByte.MaxValue - 89),
            ];

            if (encrypted)
            {
                expectedValues.ForEach(ac => EncryptionService.DecryptData(key, ac.Value!.ToString()!).Returns(ac.Value.ToString()));
            }

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
    }
}
