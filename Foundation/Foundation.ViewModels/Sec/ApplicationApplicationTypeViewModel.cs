//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationTypeViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Sec
{
    /// <summary>
    /// The User Interface interaction logic for Application/Application Type maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApplicationApplicationType}" />
    [DependencyInjectionTransient]
    public class ApplicationApplicationTypeViewModel : GenericDataGridViewModelBase<IApplicationApplicationType>, IApplicationApplicationTypeViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationApplicationTypeViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="applicationApplicationTypeProcess">The application/application type process.</param>
        public ApplicationApplicationTypeViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IApplicationApplicationTypeProcess applicationApplicationTypeProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                applicationApplicationTypeProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, applicationApplicationTypeProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
