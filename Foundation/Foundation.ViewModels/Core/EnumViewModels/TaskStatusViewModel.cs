//-----------------------------------------------------------------------
// <copyright file="TaskStatusViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Task Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{ITaskStatus}" />
    [DependencyInjectionTransient]
    public class TaskStatusViewModel : GenericDataGridViewModelBase<ITaskStatus>, ITaskStatusViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="TaskStatusViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="taskStatusProcess">The task status process</param>
        public TaskStatusViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            ITaskStatusProcess taskStatusProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                taskStatusProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, taskStatusProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
