//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Approval Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApplicationConfiguration}" />
    [DependencyInjectionTransient]
    public class ApplicationConfigurationViewModel : GenericDataGridViewModelBase<IApplicationConfiguration>, IApplicationConfigurationViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationConfigurationViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="applicationConfigurationProcess">The application configuration process</param>
        /// <param name="configurationScopeProcess">The configuration scope process.</param>
        /// <param name="applicationProcess">The application process.</param>
        public ApplicationConfigurationViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IApplicationConfigurationProcess applicationConfigurationProcess,
            IConfigurationScopeProcess configurationScopeProcess,
            IApplicationProcess applicationProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                applicationConfigurationProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, applicationConfigurationProcess, configurationScopeProcess, applicationProcess);

            ApplicationConfigurationProcess = applicationConfigurationProcess;
            ConfigurationScopeProcess = configurationScopeProcess;
            ApplicationProcess = applicationProcess;

            AllApplicationConfigurations = [];

            // Enable loading of a group of values
            Action1CommandEnabled = true;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the application configuration process
        /// </summary>
        /// <value>
        /// The application configuration process.
        /// </value>
        private IApplicationConfigurationProcess ApplicationConfigurationProcess { get; }

        /// <summary>
        /// Gets the configuration scope process
        /// </summary>
        /// <value>
        /// The configuration scope process.
        /// </value>
        private IConfigurationScopeProcess ConfigurationScopeProcess { get; }

        /// <summary>
        /// Gets the application process
        /// </summary>
        /// <value>
        /// The application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets or sets all application configurations.
        /// </summary>
        /// <value>
        /// All application configurations.
        /// </value>
        private List<IApplicationConfiguration> AllApplicationConfigurations { get; set; }

        /// <inheritdoc cref="Initialise()"/>
        public override void Initialise()
        {
            LoggingHelpers.TraceCallEnter();

            List<IConfigurationScope> configurationScopes = ConfigurationScopeProcess.GetAll();
            ConfigurationScopeProcess.AddFilterOptionsAdditional(configurationScopes);
            Filter1DataSource = configurationScopes;
            Filter1SelectedItem = configurationScopes[0];

            List<IApplication> applications = ApplicationProcess.GetAll();
            ApplicationProcess.AddFilterOptionsAdditional(applications);
            Filter2DataSource = applications;
            Filter2SelectedItem = applications[0];

            List<IUserProfile> userProfiles = UserProfileProcess.GetAll();
            UserProfileProcess.AddFilterOptionsAdditional(userProfiles);
            Filter3DataSource = userProfiles;
            Filter3SelectedItem = userProfiles[0];

            base.Initialise();

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="RefreshData()"/>
        protected override List<IApplicationConfiguration> RefreshData()
        {
            LoggingHelpers.TraceCallEnter();

            AllApplicationConfigurations = base.RefreshData();

            LoggingHelpers.TraceCallReturn(AllApplicationConfigurations);

            return AllApplicationConfigurations;
        }

        /// <inheritdoc cref="ApplyFilter1(Object)"/>
        protected override void ApplyFilter1(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if(selectedFilter is IConfigurationScope configurationScope &&
               Filter2SelectedItem is IApplication application &&
               Filter3SelectedItem is IUserProfile userProfile)
            {
                List<IApplicationConfiguration> filteredData = ApplicationConfigurationProcess.ApplyFilter(AllApplicationConfigurations, configurationScope, application, userProfile);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter2(Object)"/>
        protected override void ApplyFilter2(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is IConfigurationScope configurationScope &&
                selectedFilter is IApplication application &&
                Filter3SelectedItem is IUserProfile userProfile)
            {
                List<IApplicationConfiguration> filteredData = ApplicationConfigurationProcess.ApplyFilter(AllApplicationConfigurations, configurationScope, application, userProfile);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ApplyFilter3(Object)"/>
        protected override void ApplyFilter3(Object? selectedFilter)
        {
            LoggingHelpers.TraceCallEnter(selectedFilter);

            if (Filter1SelectedItem is IConfigurationScope configurationScope &&
                Filter2SelectedItem is IApplication application &&
                selectedFilter is IUserProfile userProfile)
            {
                List<IApplicationConfiguration> filteredData = ApplicationConfigurationProcess.ApplyFilter(AllApplicationConfigurations, configurationScope, application, userProfile);

                GridDataSource = filteredData;
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ExecuteAction1()"/>
        protected override void ExecuteAction1()
        {
            Debug.WriteLine("ExecuteAction1");
        }
    }
}
