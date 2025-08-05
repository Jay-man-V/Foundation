//-----------------------------------------------------------------------
// <copyright file="TimeZoneViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Time Zone maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{ITimeZone}" />
    [DependencyInjectionTransient]
    public class TimeZoneViewModel : GenericDataGridViewModelBase<ITimeZone>, ITimeZoneViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TimeZoneViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="timeZoneProcess">The time zone process.</param>
        public TimeZoneViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ITimeZoneProcess timeZoneProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                timeZoneProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, timeZoneProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
