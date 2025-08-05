//-----------------------------------------------------------------------
// <copyright file="EventLogApplicationViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Event Log Application maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IEventLogApplication}" />
    [DependencyInjectionTransient]
    public class EventLogApplicationViewModel : GenericDataGridViewModelBase<IEventLogApplication>, IEventLogApplicationViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogApplicationViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="eventLogApplicationProcess">The event log application process.</param>
        public EventLogApplicationViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IEventLogApplicationProcess eventLogApplicationProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                eventLogApplicationProcess
                
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, eventLogApplicationProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
