//-----------------------------------------------------------------------
// <copyright file="GetDefaultValueTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.Services.Application.ApplicationConfigurationServiceTests
{
    /// <summary>
    /// Summary description for ApplicationConfigurationServiceTests
    /// </summary>
    [TestFixture]
    public class GetDefaultValueTests : UnitTestBase
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

        [TestCase]
        public void Test_Get_True()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Boolean expectedValue = true;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_False()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Boolean expectedValue = true;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Char()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Char expectedValue = 'Z';

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_String()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            String expectedValue = Guid.NewGuid().ToString();

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_SByte()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const SByte expectedValue = SByte.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Byte()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Byte expectedValue = Byte.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Int16()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Int16 expectedValue = Int16.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_UInt16()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const UInt16 expectedValue = UInt16.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Int32()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Int32 expectedValue = Int32.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_UInt32()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const UInt32 expectedValue = UInt32.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Int64()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Int64 expectedValue = Int64.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_UInt64()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const UInt64 expectedValue = UInt64.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Object actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_TimeSpan()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            TimeSpan expectedValue = new TimeSpan(10, 5, 0);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            TimeSpan actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Date()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            DateTime expectedValue = new DateTime(2023, 09, 08);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            DateTime actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_DateTime()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45);

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            DateTime actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_DateTimeMilliseconds()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            DateTime expectedValue = new DateTime(2023, 09, 08, 21, 38, 45, 123);
            
            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            DateTime actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Guid()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            Guid expectedValue = new Guid("{0B368339-E43E-4AFF-9FBC-C9F0074FD068}");

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Guid actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Decimal()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Decimal expectedValue = Decimal.MaxValue;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Decimal actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }

        [TestCase]
        public void Test_Get_Double()
        {
            AppId applicationId = new AppId(0);
            const String key = "key";
            const Double expectedValue = 1.79769313486232d;

            TheRepository!.Get(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), key).Returns(default(IApplicationConfiguration));

            Double actualValue = TheService!.Get(applicationId, UserProfile!, key, expectedValue);

            Assert.That(actualValue, Is.EqualTo(expectedValue));
        }
    }
}
