//-----------------------------------------------------------------------
// <copyright file="SecretProviderRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Repository.Sec;

namespace Foundation.Repository.Sec
{
    /// <summary>
    /// Defines the Secret Provider Repository class
    /// </summary>
    /// <see cref="ISecretProviderRepository" />
    [DependencyInjectionTransient]
    public class SecretProviderRepository : ISecretProviderRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RoleRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        /// <param name="secretDataProvider">The secret data provider.</param>
        public SecretProviderRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IDateTimeService dateTimeService,
            ISecretDataProvider secretDataProvider
        )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, dateTimeService, secretDataProvider);

            Core = core;
            RunTimeEnvironmentSettings = runTimeEnvironmentSettings;
            SystemConfigurationService = systemConfigurationService;
            DateTimeService = dateTimeService;
            SecretDataProvider = secretDataProvider;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IRunTimeEnvironmentSettings RunTimeEnvironmentSettings { get; }
        private ISystemConfigurationService SystemConfigurationService { get; }
        private IDateTimeService DateTimeService { get; }
        private ISecretDataProvider SecretDataProvider { get; }

        /// <inheritdoc cref="ISecretProviderRepository.GetSecret(String, String)"/>
        public String GetSecret(String applicationCode, String secretName)
        {
            LoggingHelpers.TraceCallEnter(applicationCode, secretName);

            String retVal = "<Not implemented>";

            LoggingHelpers.TraceCallReturn($"{nameof(retVal)} not logged");

            return retVal;
        }
    }
}
