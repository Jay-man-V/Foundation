//-----------------------------------------------------------------------
// <copyright file="ScheduleIntervalViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for ScheduleInterval maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IScheduleInterval}" />
    [DependencyInjectionTransient]
    public class ScheduleIntervalViewModel : GenericDataGridViewModelBase<IScheduleInterval>, IScheduleIntervalViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ScheduleIntervalViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="scheduleIntervalProcess">The schedule interval process</param>
        public ScheduleIntervalViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IScheduleIntervalProcess scheduleIntervalProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                scheduleIntervalProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, scheduleIntervalProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
