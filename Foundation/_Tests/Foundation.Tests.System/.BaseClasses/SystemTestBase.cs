//-----------------------------------------------------------------------
// <copyright file="SystemTestBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.System.BaseClasses
{
    /// <summary>
    /// The System Test Base class
    /// </summary>
    [TestFixture]
    public abstract class SystemTestBase : UnitTestBase
    {
        public override void TestInitialise()
        {
            base.TestInitialise();

            CoreInstance = Core.Core.Initialise();
            DateTimeService = CoreInstance.IoC.Get<IDateTimeService>();
            RunTimeEnvironmentSettings = CoreInstance.IoC.Get<IRunTimeEnvironmentSettings>();
            LoggingService = CoreInstance.IoC.Get<ILoggingService>();
        }

        public override void TestCleanup()
        {
            base.TestCleanup();
        }
    }
}
