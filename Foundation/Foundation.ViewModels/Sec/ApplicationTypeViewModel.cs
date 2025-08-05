//-----------------------------------------------------------------------
// <copyright file="ApplicationTypeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Application Type maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApplicationType}" />
    [DependencyInjectionTransient]
    public class ApplicationTypeViewModel : GenericDataGridViewModelBase<IApplicationType>, IApplicationTypeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationTypeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="applicationTypeProcess">The application type process</param>
        public ApplicationTypeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IApplicationTypeProcess applicationTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                applicationTypeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, applicationTypeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
