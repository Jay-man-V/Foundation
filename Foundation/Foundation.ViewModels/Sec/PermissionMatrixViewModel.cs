//-----------------------------------------------------------------------
// <copyright file="PermissionMatrixViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Sec
{
    /// <summary>
    /// The User Interface interaction logic for Permission Matrix maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IPermissionMatrix}" />
    [DependencyInjectionTransient]
    public class PermissionMatrixViewModel : GenericDataGridViewModelBase<IPermissionMatrix>, IPermissionMatrixViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RoleViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="permissionMatrixProcess">The permission matrix process.</param>
        public PermissionMatrixViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IPermissionMatrixProcess permissionMatrixProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                permissionMatrixProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, permissionMatrixProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
