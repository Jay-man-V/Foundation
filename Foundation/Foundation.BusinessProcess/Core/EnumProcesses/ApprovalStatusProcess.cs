//-----------------------------------------------------------------------
// <copyright file="ApprovalStatusProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Core.EnumProcesses
{
    /// <summary>
    /// The Approval Status Business Process 
    /// </summary>
    [DependencyInjectionTransient]
    public class ApprovalStatusProcess : CommonBusinessProcess<IApprovalStatus, IApprovalStatusRepository>, IApprovalStatusProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApprovalStatusProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        public ApprovalStatusProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IApprovalStatusRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                userProfileRepository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Approval Statuses";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Approval Statuses:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.ApprovalStatus.Name;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApprovalStatus.Name, "Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApprovalStatus.Description, "Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
