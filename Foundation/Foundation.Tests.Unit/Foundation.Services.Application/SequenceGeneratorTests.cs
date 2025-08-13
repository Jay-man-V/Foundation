//-----------------------------------------------------------------------
// <copyright file="SequenceGeneratorTests.cs" company="JDV Software Ltd">
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
    public class SequenceGeneratorTests : UnitTestBase
    {
        private AppId ApplicationId => new AppId(1);
        private ISequenceGeneratorService? TheService { get; set; }
        private ISequenceGeneratorRepository? TheRepository { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheRepository = Substitute.For<ISequenceGeneratorRepository>();

            TheService = new SequenceGeneratorService(TheRepository);
        }

        public override void TestCleanup()
        {
            TheRepository!.Dispose();
            TheRepository = null;

            base.TestCleanup();
        }

        [Test]
        public void Test_GetNextSequence()
        {
            const Int32 expected = 123;
            TheRepository!.GetNextSequence(Arg.Any<AppId>(), Arg.Any<IUserProfile>(), Arg.Any<String>()).Returns(expected);

            Int32 actual = TheService!.GetNextSequence(ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, SequenceNames.GenericSequence);

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Test_GetNewGuid()
        {
            Guid actual = TheService!.NewGuid();

            Assert.That(actual, Is.Not.EqualTo(Guid.NewGuid()));
            Assert.That(actual, Is.Not.EqualTo(Guid.Empty));
        }
    }
}