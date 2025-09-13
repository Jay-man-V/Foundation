//-----------------------------------------------------------------------
// <copyright file="DataStatusViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Data Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IDataStatus}" />
    [DependencyInjectionTransient]
    public class DataStatusViewModel : GenericDataGridViewModelBase<IDataStatus>, IDataStatusViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DataStatusViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="dataStatusProcess">The status process</param>
        public DataStatusViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IDataStatusProcess dataStatusProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                dataStatusProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, dataStatusProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
