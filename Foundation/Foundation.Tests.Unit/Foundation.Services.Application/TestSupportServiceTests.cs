//-----------------------------------------------------------------------
// <copyright file="TestSupportServiceTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.Services.Application
{
    /// <summary>
    /// TestSupportServiceTests
    /// </summary>
    [TestFixture]
    public class TestSupportServiceTests : UnitTestBase
    {
        [TestCase]
        public void Test_GetCurrentDateTime()
        {
            ITestSupportService service = CoreInstance.IoC.Get<ITestSupportService>();

            DateTime aValue = service.GetCurrentDateTime();

            Assert.That(aValue <= DateTime.Now);
        }

        [TestCase]
        public void Test_SimulateLongTask()
        {
            ITestSupportService service = CoreInstance.IoC.Get<ITestSupportService>();

            service.SimulateLongTask();
        }
    }
}
