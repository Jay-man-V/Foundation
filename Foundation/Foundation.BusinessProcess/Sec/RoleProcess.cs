//-----------------------------------------------------------------------
// <copyright file="RoleProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Role Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class RoleProcess : CommonBusinessProcess<IRole, IRoleRepository>, IRoleProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="RoleProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        public RoleProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IRoleRepository repository,
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
        public override String ScreenTitle => "Roles";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Roles:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.Role.Name;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Role.Name, "Name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Role.Description, "Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.Role.SystemSupportOnly, "System Support Only", typeof(Boolean));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
