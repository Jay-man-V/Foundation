//-----------------------------------------------------------------------
// <copyright file="ConfigurationScopeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Approval Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IConfigurationScope}" />
    [DependencyInjectionTransient]
    public class ConfigurationScopeViewModel : GenericDataGridViewModelBase<IConfigurationScope>, IConfigurationScopeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ConfigurationScopeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="configurationScopeProcess">The configuration scope process</param>
        public ConfigurationScopeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IConfigurationScopeProcess configurationScopeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                configurationScopeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, configurationScopeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
