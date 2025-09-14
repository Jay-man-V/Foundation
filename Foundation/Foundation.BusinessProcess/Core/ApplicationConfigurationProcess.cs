//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Core
{
    /// <summary>
    /// The Application Configuration Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class ApplicationConfigurationProcess : CommonBusinessProcess<IApplicationConfiguration, IApplicationConfigurationRepository>, IApplicationConfigurationProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationConfigurationProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The data time service.</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="configurationScopeProcess">The configuration scope process.</param>
        /// <param name="applicationProcess">The application process.</param>
        /// <param name="userProfileProcess">The user profile process.</param>
        public ApplicationConfigurationProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IApplicationConfigurationRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IConfigurationScopeProcess configurationScopeProcess,
            IApplicationProcess applicationProcess,
            IUserProfileProcess userProfileProcess
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, configurationScopeProcess, applicationProcess, userProfileProcess);

            ConfigurationScopeProcess = configurationScopeProcess;
            ApplicationProcess = applicationProcess;
            UserProfileProcess = userProfileProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the configuration scope process.
        /// </summary>
        /// <value>
        /// The configuration scope process.
        /// </value>
        private IConfigurationScopeProcess ConfigurationScopeProcess { get; }

        /// <summary>
        /// Gets the application process.
        /// </summary>
        /// <value>
        /// The application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets the user profile process.
        /// </summary>
        /// <value>
        /// The user profile process.
        /// </value>
        private IUserProfileProcess UserProfileProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Application Configurations";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Application Configurations:";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter1"/>
        public override Boolean HasOptionalDropDownParameter1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1Name"/>
        public override String Filter1Name => "Configuration Scope:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1DisplayMemberPath"/>
        public override String Filter1DisplayMemberPath => ConfigurationScopeProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter1SelectedValuePath"/>
        public override String Filter1SelectedValuePath => ConfigurationScopeProcess.ComboBoxValueMember;

        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalAction1"/>
        public override Boolean HasOptionalAction1 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Action1Name"/>
        public override String Action1Name => "Load group...";


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter2"/>
        public override Boolean HasOptionalDropDownParameter2 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2Name"/>
        public override String Filter2Name => "Application Name:";

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2DisplayMemberPath"/>
        public override String Filter2DisplayMemberPath => ApplicationProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter2SelectedValuePath"/>
        public override String Filter2SelectedValuePath => ApplicationProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.HasOptionalDropDownParameter3"/>
        public override Boolean HasOptionalDropDownParameter3 => true;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3Name"/>
        public override String Filter3Name => "User:"; 

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3DisplayMemberPath"/>
        public override String Filter3DisplayMemberPath => UserProfileProcess.ComboBoxDisplayMember;

        /// <inheritdoc cref="ICommonBusinessProcess.Filter3SelectedValuePath"/>
        public override String Filter3SelectedValuePath => UserProfileProcess.ComboBoxValueMember;


        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.ApplicationConfiguration.Key;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationConfiguration.ApplicationId, "Application", typeof(String))
            {
                TextAlignment = TextAlignment.Centre,
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationConfiguration.ConfigurationScopeId, "Scope", typeof(String))
            {
                TextAlignment = TextAlignment.Centre,
                DataSource = ConfigurationScopeProcess.GetAll(excludeDeleted: false),
                ValueMember = ConfigurationScopeProcess.ComboBoxValueMember,
                DisplayMember = ConfigurationScopeProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(300, FDC.ApplicationConfiguration.Key, "Key", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(500, FDC.ApplicationConfiguration.Value, "Value", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IApplicationConfigurationProcess.ApplyFilter(List{IApplicationConfiguration}, IConfigurationScope?, IApplication?, IUserProfile?)"/>
        public List<IApplicationConfiguration> ApplyFilter(List<IApplicationConfiguration> applicationConfigurations, IConfigurationScope? configurationScope, IApplication? application, IUserProfile? userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationConfigurations, configurationScope, application);

            List<IApplicationConfiguration> retVal = applicationConfigurations;

            if (configurationScope != null)
            {
                retVal = retVal.Where(ac => (ac.ConfigurationScopeId == configurationScope.Id) ||           // Matching Configuration Scope
                                            (configurationScope.Id == ConfigurationScopeProcess.AllId) ||   // All records
                                            (configurationScope.Id == ConfigurationScopeProcess.NoneId &&
                                             ac.ConfigurationScopeId == ConfigurationScopeProcess.NullId)   // No Configuration Scope
                ).ToList();
            }

            if (application != null)
            {
                retVal = retVal.Where(ac => (ac.ApplicationId == application.Id) ||                         // Matching Application
                                            (application.Id == ApplicationProcess.AllId) ||                 // All records
                                            (application.Id == ApplicationProcess.NoneId &&
                                             ac.ApplicationId == ApplicationProcess.NullId)                 // No Application
                ).ToList();
            }

            if (userProfile != null)
            {
                retVal = retVal.Where(ac => (ac.CreatedByUserProfileId == userProfile.Id) ||                // Matching User
                                            (userProfile.Id == UserProfileProcess.AllId) ||                 // All records
                                            (userProfile.Id == UserProfileProcess.NoneId &&
                                             ac.CreatedByUserProfileId == UserProfileProcess.NullId)        // No User
                ).ToList();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
