//-----------------------------------------------------------------------
// <copyright file="MainApplicationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Main;
using Foundation.Interfaces;

using Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.MainTests
{
    /// <summary>
    /// Summary description for MainApplicationProcessTests
    /// </summary>
    [TestFixture]
    public class MainApplicationProcessTests : BusinessProcessUnitTestsBase
    {
        private IMainApplicationProcess? TheProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheProcess = CreateBusinessProcess(DateTimeService);
        }

        protected IMainApplicationProcess CreateBusinessProcess(IDateTimeService dateTimeService)
        {
            IMainApplicationProcess process = new MainApplicationProcess(CoreInstance);

            return process;
        }

        [TestCase]
        public void Test_Properties()
        {
        }
    }
}
