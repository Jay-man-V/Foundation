//-----------------------------------------------------------------------
// <copyright file="IdGeneratorTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using NSubstitute;

using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    public class IdGeneratorTests : UnitTestBase
    {
        private AppId ApplicationId => new AppId(1);
        private IIdGeneratorService? TheService { get; set; }
        private IIdGeneratorRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheRepository = Substitute.For<IIdGeneratorRepository>();

            TheService = new IdGeneratorService(TheRepository);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            base.TestCleanup();
        }

        [TestCase]
        public void Test_GetNextId()
        {
            const Int32 expected = 123;
            TheRepository!.GetNextId(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), Arg.Any<String>()).Returns(expected);

            Int32 actual = TheService!.GetNextId(ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, IdNames.GenericId);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [TestCase]
        public void Test_GetNewGuid()
        {
            Guid actual = TheService!.NewUniqueIdentifier();

            Assert.That(actual, Is.Not.EqualTo(Guid.NewGuid()));
            Assert.That(actual, Is.Not.EqualTo(Guid.Empty));
        }
    }
}