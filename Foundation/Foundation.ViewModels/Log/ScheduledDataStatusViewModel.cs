//-----------------------------------------------------------------------
// <copyright file="ScheduledDataStatusViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Log
{
    /// <summary>
    /// The User Interface interaction logic for ScheduledDataStatus maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModel{IScheduledDataStatus}" />
    [DependencyInjectionTransient]
    public class ScheduledDataStatusViewModel : GenericDataGridViewModel<IScheduledDataStatus>, IScheduledDataStatusViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduledDataStatusViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="scheduledDataStatusProcess">The scheduled task process.</param>
        public ScheduledDataStatusViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IScheduledDataStatusProcess scheduledDataStatusProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                scheduledDataStatusProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, scheduledDataStatusProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
