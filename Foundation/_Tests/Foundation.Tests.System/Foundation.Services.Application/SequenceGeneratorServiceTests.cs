//-----------------------------------------------------------------------
// <copyright file="SequenceGeneratorServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using Foundation.Tests.System.BaseClasses;

namespace Foundation.Tests.System.Foundation.Services.Application
{
    /// <summary>
    /// System Tests for Sequence Generator Service
    /// </summary>
    [TestFixture]
    public class SequenceGeneratorServiceTests : SystemTestBase
    {
        private ISequenceGeneratorService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = CoreInstance.IoC.Get<ISequenceGeneratorService>();
        }

        [Test]
        public void Test_GetNextId()
        {
            String sequenceName = LocationUtils.GetFullyQualifiedFunctionName();

            Int64 actual1 = TheService!.GetNextId(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, sequenceName);
            Int64 actual2 = TheService!.GetNextId(CoreInstance.ApplicationId, CoreInstance.CurrentLoggedOnUser.UserProfile, sequenceName);

            Assert.That(actual1, Is.GreaterThan(0));
            Assert.That(actual2, Is.GreaterThan(0));
            Assert.That(actual2, Is.Not.EqualTo(actual1));
        }

        [Test]
        public void Test_NewUniqueIdentifier()
        {
            String actual1 = TheService!.NewUniqueIdentifier();
            String actual2 = TheService!.NewUniqueIdentifier();

            Assert.That(actual1, Is.Not.EqualTo(String.Empty));
            Assert.That(actual2, Is.Not.EqualTo(String.Empty));
            Assert.That(actual2, Is.Not.EqualTo(actual1));
        }
    }
}
