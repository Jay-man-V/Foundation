//-----------------------------------------------------------------------
// <copyright file="EventLogViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Log
{
    /// <summary>
    /// The User Interface interaction logic for Event Log maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IEventLog}" />
    [DependencyInjectionTransient]
    public class EventLogViewModel : GenericDataGridViewModelBase<IEventLog>, IEventLogViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="eventLogProcess">The event log process.</param>
        public EventLogViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IEventLogProcess eventLogProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                eventLogProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, eventLogProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
