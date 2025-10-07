//-----------------------------------------------------------------------
// <copyright file="RoleViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Sec
{
    /// <summary>
    /// The User Interface interaction logic for Role maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModel{IRole}" />
    [DependencyInjectionTransient]
    public class RoleViewModel : GenericDataGridViewModel<IRole>, IRoleViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RoleViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="roleProcess">The role process.</param>
        public RoleViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IRoleProcess roleProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                roleProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, roleProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
