//-----------------------------------------------------------------------
// <copyright file="CommonProcessTests.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.BusinessProcess;

using Foundation.Tests.Unit.Support;

namespace Foundation.Tests.Unit.Foundation.BusinessProcess
{
    public abstract class CommonProcessTests<TCommonProcess> : UnitTestBase
    {
        protected TCommonProcess? TheProcess { get; set; }

        protected abstract TCommonProcess CreateBusinessProcess();

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
            Assert.That(commonProcess!.RunTimeEnvironmentSettings, Is.Not.EqualTo(null));
            Assert.That(commonProcess!.DateTimeService, Is.Not.EqualTo(null));
            Assert.That(commonProcess!.LoggingService, Is.Not.EqualTo(null));
        }
    }
}