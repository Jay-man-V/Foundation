//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.ViewModels.Core.EnumViewModels
{
    /// <summary>
    /// The User Interface interaction logic for Approval Status maintenance
    /// </summary>
    /// <seealso cref="GenericDataGridViewModelBase{IApprovalStatus}" />
    [DependencyInjectionTransient]
    public class ApprovalStatusViewModel : GenericDataGridViewModelBase<IApprovalStatus>, IApprovalStatusViewModel
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApprovalStatusViewModel"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service.</param>
        /// <param name="wpfApplicationObjects">The wpf application objects collection.</param>
        /// <param name="fileApi">The file service.</param>
        /// <param name="approvalStatusProcess">The approval status process</param>
        public ApprovalStatusViewModel
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IWpfApplicationObjects wpfApplicationObjects,
            IFileApi fileApi,
            IApprovalStatusProcess approvalStatusProcess
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                wpfApplicationObjects,
                fileApi,
                approvalStatusProcess
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, wpfApplicationObjects, fileApi, approvalStatusProcess);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
