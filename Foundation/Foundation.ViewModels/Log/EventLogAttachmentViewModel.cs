//-----------------------------------------------------------------------
// <copyright file="EventLogAttachmentViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Event Log maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IEventLogAttachment}" />
    [DependencyInjectionTransient]
    public class EventLogAttachmentViewModel : GenericDataGridViewModelBase<IEventLogAttachment>, IEventLogAttachmentViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EventLogAttachmentViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="eventLogAttachmentProcess">The event log process.</param>
        public EventLogAttachmentViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IEventLogAttachmentProcess eventLogAttachmentProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                eventLogAttachmentProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, eventLogAttachmentProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
