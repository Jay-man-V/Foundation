//-----------------------------------------------------------------------
// <copyright file="CommonProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess;
using Foundation.Interfaces;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess.BaseClasses
{
    public abstract class CommonProcessTests<TCommonProcess> : BusinessProcessUnitTestsBase
    {
        protected TCommonProcess? TheProcess { get; set; }

        protected virtual TCommonProcess CreateBusinessProcess()
        {
            TCommonProcess retVal = CreateBusinessProcess(DateTimeService);

            return retVal;
        }

        protected abstract TCommonProcess CreateBusinessProcess(IDateTimeService dateTimeService);

        public override void TestInitialise()
        {
            base.TestInitialise();

            TheProcess = CreateBusinessProcess();
        }

        [TestCase]
        public void Test_CommonProcess_Properties()
        {
            CommonProcess? commonProcess = TheProcess! as CommonProcess;
            Assert.That(commonProcess!.Core, Is.Not.EqualTo(null));
            Assert.That(commonProcess.RunTimeEnvironmentSettings, Is.Not.EqualTo(null));
            Assert.That(commonProcess.DateTimeService, Is.Not.EqualTo(null));
            Assert.That(commonProcess.LoggingService, Is.Not.EqualTo(null));
        }
    }
}