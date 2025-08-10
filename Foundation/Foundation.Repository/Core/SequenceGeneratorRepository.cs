//-----------------------------------------------------------------------
// <copyright file="SequenceGenerator.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

using System.Data;
using Foundation.DataAccess.Database;
using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Active Directory User Profile Data Access class
    /// </summary>
    /// <see cref="ISequenceGenerator" />
    [DependencyInjectionTransient]
    public class SequenceGeneratorRepository : FoundationModelRepository<ISequenceGenerator>, ISequenceGeneratorRepository 
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="SequenceGeneratorRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider">The Core Database Provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public SequenceGeneratorRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ICoreDatabaseProvider databaseProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                databaseProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, databaseProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.SequenceGenerator.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.SequenceGenerator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanCreate(TModel)"/>
        protected override void VerifyCanCreate(ISequenceGenerator entity)
        {
            // Everyone can Create a Sequence Generator Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanEdit(TModel)"/>
        protected override void VerifyCanEdit(ISequenceGenerator entity)
        {
            // Everyone can Edit an Sequence Generator Entry
            // Does nothing
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.VerifyCanDelete(TModel)"/>
        protected override void VerifyCanDelete(ISequenceGenerator entity)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(EntityId)"/>
        public override void Delete(EntityId entityId)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(TModel)"/>
        public override ISequenceGenerator Delete(ISequenceGenerator entity)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.Delete(List{TModel})"/>
        public override List<ISequenceGenerator> Delete(List<ISequenceGenerator> entities)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.DeleteEntity(IDbConnection, EntityId)"/>
        protected override int DeleteEntity(IDbConnection conn, EntityId entityId)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.DeleteEntity(IDbConnection, TModel)"/>
        protected override int DeleteEntity(IDbConnection conn, ISequenceGenerator entity)
        {
            // Sequence Generator Entries cannot be deleted
            throw new NotImplementedException("Sequence Generator Entries cannot be deleted");
        }
        /// <inheritdoc cref="ISequenceGeneratorRepository.GetNextSequence(AppId, IUserProfile, ConfigurationScope, String)"/>
        public Int32 GetNextSequence(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String sequenceName)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, sequenceName);

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter(FDC.StoredProcedures.GetNextSequence.ApplicationId, applicationId),
                FoundationDataAccess.CreateParameter(FDC.StoredProcedures.GetNextSequence.UserProfileId, userProfile.Id),
                FoundationDataAccess.CreateParameter(FDC.StoredProcedures.GetNextSequence.SequenceName, sequenceName)
            ];

            Object? result = FoundationDataAccess.ExecuteScalar(FDC.StoredProcedures.GetNextSequence.ProcedureName, CommandType.StoredProcedure, databaseParameters);

            Int32.TryParse(result?.ToString() ?? "-1", out Int32 retVal);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
