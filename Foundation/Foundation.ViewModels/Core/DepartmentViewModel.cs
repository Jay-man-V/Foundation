//-----------------------------------------------------------------------
// <copyright file="DepartmentViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core
{
    /// <summary>
    /// The User Interface interaction logic for Department maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IDepartment}" />
    [DependencyInjectionTransient]
    public class DepartmentViewModel : GenericDataGridViewModelBase<IDepartment>, IDepartmentViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="DepartmentViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="departmentProcess">The department process.</param>
        public DepartmentViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IDepartmentProcess departmentProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                departmentProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, departmentProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
