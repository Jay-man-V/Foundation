//-----------------------------------------------------------------------
// <copyright file="OfficeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Approval Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IOffice}" />
    [DependencyInjectionTransient]
    public class OfficeViewModel : GenericDataGridViewModelBase<IOffice>, IOfficeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="OfficeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="officeProcess">The approval status process</param>
        public OfficeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IOfficeProcess officeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                officeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, officeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
