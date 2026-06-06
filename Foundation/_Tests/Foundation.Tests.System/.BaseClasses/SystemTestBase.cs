//-----------------------------------------------------------------------
// <copyright file="SystemTestBase.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Resources;
using Foundation.Tests.Unit.BaseClasses;

namespace Foundation.Tests.System.BaseClasses
{
    /// <summary>
    /// The System Test Base class
    /// </summary>
    [TestFixture]
    public abstract class SystemTestBase : UnitTestBase
    {
        protected override String TestingApplicationName => "SystemTesting";

        protected IApplicationConfigurationProcess? ApplicationConfigurationProcess { get; set; }

        public override void TestInitialise()
        {
            base.TestInitialise();

            CoreInstance = Core.Core.Initialise();
            DateTimeService = CoreInstance.IoC.Get<IDateTimeService>();
            RunTimeEnvironmentSettings = CoreInstance.IoC.Get<IRunTimeEnvironmentSettings>();
            LoggingService = CoreInstance.IoC.Get<ILoggingService>();

            RootLogId = LoggingService.CreateLogEntry(BatchName, ProcessName, TaskName);

            ApplicationConfigurationProcess = CoreInstance.IoC.Get<IApplicationConfigurationProcess>();

            SetupApplicationConfigurations();
        }

        public override void TestCleanup()
        {
            LoggingService.CreateLogEntry(RootLogId, BatchName, ProcessName, TaskName, LogSeverity.Information, "Finished testing");

            ApplicationConfigurationProcess = null;

            base.TestCleanup();
        }

        protected void SetupApplicationConfigurations()
        {
            List<IApplicationConfiguration> applicationConfigurations = GetTestApplicationConfigurations();

            ApplicationConfigurationProcess!.Save(applicationConfigurations);
        }

        protected IApplicationConfiguration GetExistingOrCreateNewApplicationConfiguration(String key, String value)
        {
            IApplicationConfiguration? existing = ApplicationConfigurationProcess!.Get(key);
            if (existing != null)
            {
                return existing;
            }

            IApplicationConfiguration newConfig = CoreInstance.IoC.Get<IApplicationConfiguration>();

            newConfig.ApplicationId = TestingApplicationId;
            newConfig.ConfigurationScopeId = new EntityId(ConfigurationScope.System.Id());
            newConfig.ValidFrom = DateTimeService.SystemUtcDateTimeNow;
            newConfig.ValidTo = ApplicationDefaultValues.DefaultValidToDateTime;
            newConfig.CreatedByUserProfileId = new EntityId(1);
            newConfig.LastUpdatedByUserProfileId = new EntityId(1);

            newConfig.Key = key;
            newConfig.Value = value;

            ApplicationConfigurationProcess.Save(newConfig);
            return newConfig;
        }

        protected virtual List<IApplicationConfiguration> GetTestApplicationConfigurations()
        {
            List<IApplicationConfiguration> retVal = [];

            return retVal;
        }
    }
}
