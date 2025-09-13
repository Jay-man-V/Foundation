//-----------------------------------------------------------------------
// <copyright file="ScheduledJobViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Scheduled Job maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IScheduledJob}" />
    [DependencyInjectionTransient]
    public class ScheduledJobViewModel : GenericDataGridViewModelBase<IScheduledJob>, IScheduledJobViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduledJobViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="scheduledJobProcess">The scheduled task process.</param>
        public ScheduledJobViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IScheduledJobProcess scheduledJobProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                scheduledJobProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, scheduledJobProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
