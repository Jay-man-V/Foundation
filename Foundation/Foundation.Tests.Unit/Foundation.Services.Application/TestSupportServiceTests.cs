//-----------------------------------------------------------------------
// <copyright file="TestSupportServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;
using Foundation.Services.Application;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// TestSupportServiceTests
    /// </summary>
    [TestFixture]
    public class TestSupportServiceTests : UnitTestBase
    {
        private ITestSupportService? TheService { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheService = new TestSupportService();
        }

        [TestCase]
        public void Test_GetCurrentDateTime()
        {
            DateTime actual = TheService!.GetCurrentDateTime();

            Assert.That(actual <= DateTime.Now);
        }

        [TestCase]
        public void Test_SimulateLongTask()
        {
            TheService!.SimulateLongTask();
        }
    }
}
