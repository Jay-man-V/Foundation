//-----------------------------------------------------------------------
// <copyright file="ApplicationApplicationTypeProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec
{
    /// <summary>
    /// The Application/Application Type Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class ApplicationApplicationTypeProcess : CommonBusinessProcess<IApplicationApplicationType, IApplicationApplicationTypeRepository>, IApplicationApplicationTypeProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationApplicationTypeProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        /// <param name="userProfileRepository">The user profile data access.</param>
        /// <param name="applicationProcess">The application process.</param>
        /// <param name="applicationTypeProcess">The application type process.</param>
        public ApplicationApplicationTypeProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IApplicationApplicationTypeRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IApplicationProcess applicationProcess,
            IApplicationTypeProcess applicationTypeProcess
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
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, userProfileRepository, applicationProcess, applicationTypeProcess);

            ApplicationProcess = applicationProcess;
            ApplicationTypeProcess = applicationTypeProcess;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the application process.
        /// </summary>
        /// <value>
        /// The application process.
        /// </value>
        private IApplicationProcess ApplicationProcess { get; }

        /// <summary>
        /// Gets the application type process.
        /// </summary>
        /// <value>
        /// The application type process.
        /// </value>
        private IApplicationTypeProcess ApplicationTypeProcess { get; }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "Application/Application Types";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of Application/Application Types:";

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationApplicationType.ApplicationId, "Application", typeof(String))
            {
                DataSource = ApplicationProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationProcess.ComboBoxValueMember,
                DisplayMember = ApplicationProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.ApplicationApplicationType.ApplicationTypeId, "Type", typeof(String))
            {
                DataSource = ApplicationTypeProcess.GetAll(excludeDeleted: false),
                ValueMember = ApplicationTypeProcess.ComboBoxValueMember,
                DisplayMember = ApplicationTypeProcess.ComboBoxDisplayMember,
            };
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
