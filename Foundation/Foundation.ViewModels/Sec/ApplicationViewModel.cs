//-----------------------------------------------------------------------
// <copyright file="ApplicationViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Sec
{
    /// <summary>
    /// The User Interface interaction logic for Application maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModel{IApplication}" />
    [DependencyInjectionTransient]
    public class ApplicationViewModel : GenericDataGridViewModel<IApplication>, IApplicationViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="applicationProcess">The application process.</param>
        public ApplicationViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IApplicationProcess applicationProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                applicationProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, applicationProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
