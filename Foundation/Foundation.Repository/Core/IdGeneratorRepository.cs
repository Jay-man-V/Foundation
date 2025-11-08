//-----------------------------------------------------------------------
// <copyright file="IdGeneratorRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Id Generator Repository class
    /// </summary>
    /// <see cref="IIdGeneratorRepository" />
    [DependencyInjectionTransient]
    public class IdGeneratorRepository : FoundationModelRepository<IIdGenerator>, IIdGeneratorRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="IdGeneratorRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="coreDataProvider">The core data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public IdGeneratorRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDataProvider coreDataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                coreDataProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, coreDataProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.IdGenerator.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.IdGenerator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.SystemSupervisor;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.SystemSupervisor;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanCreate(TModel)"/>
        protected override void VerifyCanCreate(IIdGenerator entity)
        {
            // Everyone can Create an Id Generator Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanEdit(TModel)"/>
        protected override void VerifyCanEdit(IIdGenerator entity)
        {
            // Everyone can Edit an Id Generator Entry
            // Does nothing
        }

        /// <inheritdoc cref="IIdGeneratorRepository.GetNextId(AppId, IUserProfile, String)"/>
        public Int32 GetNextId(AppId applicationId, IUserProfile userProfile, String idName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, idName);

            String sql = StoredProcedures.GetNextId.ProcedureName;

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter(StoredProcedures.GetNextId.ApplicationId, applicationId),
                FoundationDataAccess.CreateParameter(StoredProcedures.GetNextId.UserProfileId, userProfile.Id),
                FoundationDataAccess.CreateParameter(StoredProcedures.GetNextId.IdName, idName)
            ];

            Object? result = FoundationDataAccess.ExecuteScalar(sql, CommandType.StoredProcedure, databaseParameters);

            Int32.TryParse(result?.ToString() ?? "-1", out Int32 retVal);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
