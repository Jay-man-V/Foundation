//-----------------------------------------------------------------------
// <copyright file="EnumModelProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess
{
    /// <summary>
    /// The Approval Status Business Process 
    /// </summary>
    public abstract class EnumModelProcess<TModel, TRepository> : CommonBusinessProcess<TModel, TRepository>, ICommonBusinessProcess<TModel>
        where TModel : IFoundationModel
        where TRepository : IFoundationModelDataAccess<TModel>
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="EnumModelProcess{TModel, TProcess}" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="loggingService">The logging service</param>
        /// <param name="repository">The data access</param>
        /// <param name="statusRepository">The status data access</param>
        /// <param name="userProfileRepository">The user profile data access</param>
        /// <param name="reportGenerator">The report generator service</param>
        protected EnumModelProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            ILoggingService loggingService,
            TRepository repository,
            IStatusRepository statusRepository,
            IUserProfileRepository userProfileRepository,
            IReportGenerator reportGenerator
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                loggingService,
                repository,
                statusRepository,
                userProfileRepository,
                reportGenerator
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, loggingService, repository, statusRepository, userProfileRepository, reportGenerator);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.EnumModel.Code;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EnumModel.Code, "Code", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EnumModel.ShortDescription, "Short Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.EnumModel.LongDescription, "Long Description", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
