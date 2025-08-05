//-----------------------------------------------------------------------
// <copyright file="OfficeWeekCalendarViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Office Week Calendar maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IOfficeWeekCalendar}" />
    [DependencyInjectionTransient]
    public class OfficeWeekCalendarViewModel : GenericDataGridViewModelBase<IOfficeWeekCalendar>, IOfficeWeekCalendarViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="OfficeWeekCalendarViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="officeWeekCalendarProcess">The office week calendar process</param>
        public OfficeWeekCalendarViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IOfficeWeekCalendarProcess officeWeekCalendarProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                officeWeekCalendarProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, officeWeekCalendarProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
