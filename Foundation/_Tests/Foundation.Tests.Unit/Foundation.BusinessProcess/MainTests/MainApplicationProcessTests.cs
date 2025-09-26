//-----------------------------------------------------------------------
// <copyright file="MainApplicationProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess.Main;
using NSubstitute;

using Foundation.BusinessProcess.Sec;
using Foundation.Interfaces;
using Foundation.Tests.Unit.Support;
using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.MainTests
{
    /// <summary>
    /// Summary description for MainApplicationProcessTests
    /// </summary>
    [TestFixture]
    public class MainApplicationProcessTests : UnitTestBase
    {
        private IMainApplicationProcess? TheProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheProcess = CreateBusinessProcess();
        }

        protected IMainApplicationProcess CreateBusinessProcess()
        {
            IMainApplicationProcess process = CreateBusinessProcess(DateTimeService);

            return process;
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
