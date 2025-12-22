//-----------------------------------------------------------------------
// <copyright file="DatePeriodViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for DatePeriod maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModel{IDatePeriod}" />
    [DependencyInjectionTransient]
    public class DatePeriodViewModel : GenericDataGridViewModel<IDatePeriod>, IDatePeriodViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DatePeriodViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="datePeriodProcess">The schedule interval process</param>
        public DatePeriodViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IDatePeriodProcess datePeriodProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                datePeriodProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, datePeriodProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
