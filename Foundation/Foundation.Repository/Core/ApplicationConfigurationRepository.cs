//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;
using Foundation.Repository.DataProvider;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Core
{
    /// <summary>
    /// Defines the Configuration Scope Data Access class
    /// </summary>
    /// <see cref="IApplicationConfiguration" />
    [DependencyInjectionTransient]
    public class ApplicationConfigurationRepository : FoundationModelRepository<IApplicationConfiguration>, IApplicationConfigurationRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationConfigurationRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="foundationDataAccess">The foundation data access.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ApplicationConfigurationRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            IFoundationDataAccess foundationDataAccess,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                foundationDataAccess,
                new CoreDataProvider(),
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, foundationDataAccess, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityKey"/>
        protected override String EntityKey => FDC.ApplicationConfiguration.Key;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ApplicationConfiguration.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ApplicationConfiguration;

        /// <inheritdoc cref="IApplicationConfigurationRepository.SetValue(AppId, IUserProfile, ConfigurationScope, String, String)"/>
        public void SetValue(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, String key, String newValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, key, newValue);

            InternalSetValue(applicationId, userProfile.Id, configurationScope, key, newValue);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IApplicationConfigurationRepository.Get(AppId, IUserProfile, String)"/>
        public IApplicationConfiguration? Get(AppId applicationId, IUserProfile userProfile, String key)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, key);

            IApplicationConfiguration? retVal = default;

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine("(");
            sql.AppendLine("    SELECT");
            sql.AppendLine("        ac.*,");
            sql.AppendLine($"        RANK() OVER (PARTITION BY ac.[{FDC.ApplicationConfiguration.Key}] ORDER BY ac.{FDC.ApplicationConfiguration.ApplicationId} DESC, cs.{FDC.ConfigurationScope.UsageSequence} ASC) AS Rnk");
            sql.AppendLine("    FROM");
            sql.AppendLine($"        {FDC.TableNames.ApplicationConfiguration} ac");
            sql.AppendLine($"            INNER JOIN {FDC.TableNames.ConfigurationScope} cs ON");
            sql.AppendLine("            (");
            sql.AppendLine($"                cs.{FDC.ConfigurationScope.Id} = ac.{FDC.ApplicationConfiguration.ConfigurationScopeId}");
            sql.AppendLine("            )");
            sql.AppendLine("    WHERE");
            sql.AppendLine($"        ac.{FDC.ApplicationConfiguration.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND");
            sql.AppendLine($"        {DataLogicProvider.CurrentDateTimeFunction} BETWEEN ac.{FDC.ApplicationConfiguration.ValidFrom} AND ac.{FDC.ApplicationConfiguration.ValidTo} AND");
            sql.AppendLine($"        ac.[{FDC.ApplicationConfiguration.Key}] = {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key} AND");
            sql.AppendLine($"        COALESCE ( ac.{FDC.ApplicationConfiguration.ApplicationId}, 0 ) IN ( 0, /* Core System Application */ {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId} ) AND");
            sql.AppendLine($"        ac.{FDC.ApplicationConfiguration.CreatedByUserProfileId} IN ( 1, /* System User */ {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId} )");
            sql.AppendLine(") s");
            sql.AppendLine("WHERE");
            sql.AppendLine("    Rnk = 1");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql.ToString(), CommandType.Text, databaseParameters))
            {
                while (dataReader.Read())
                {
                    retVal = PopulateEntity<IApplicationConfiguration>(dataReader);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IApplicationConfigurationRepository.GetGroupValues(AppId, IUserProfile, String)"/>
        public List<IApplicationConfiguration> GetGroupValues(AppId applicationId, IUserProfile userProfile, String key)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, key);

            List<IApplicationConfiguration> retVal = [];

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine("(");
            sql.AppendLine("    SELECT");
            sql.AppendLine("        ac.*,");
            sql.AppendLine($"        RANK() OVER (PARTITION BY ac.[{FDC.ApplicationConfiguration.Key}] ORDER BY ac.{FDC.ApplicationConfiguration.ApplicationId} DESC, cs.{FDC.ConfigurationScope.UsageSequence} ASC) AS Rnk");
            sql.AppendLine("    FROM");
            sql.AppendLine($"        {FDC.TableNames.ApplicationConfiguration} ac");
            sql.AppendLine($"            INNER JOIN {FDC.TableNames.ConfigurationScope} cs ON");
            sql.AppendLine("            (");
            sql.AppendLine($"                cs.{FDC.ConfigurationScope.Id} = ac.{FDC.ApplicationConfiguration.ConfigurationScopeId}");
            sql.AppendLine("            )");
            sql.AppendLine("    WHERE");
            sql.AppendLine($"        ac.{FDC.ApplicationConfiguration.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND");
            sql.AppendLine($"        {DataLogicProvider.CurrentDateTimeFunction} BETWEEN ac.{FDC.ApplicationConfiguration.ValidFrom} AND ac.{FDC.ApplicationConfiguration.ValidTo} AND");
            sql.AppendLine($"        ac.[{FDC.ApplicationConfiguration.Key}] LIKE {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key} AND");
            sql.AppendLine($"        COALESCE ( ac.{FDC.ApplicationConfiguration.ApplicationId}, 0 ) IN ( 0, /* Core System Application */ {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId} ) AND");
            sql.AppendLine($"        ac.{FDC.ApplicationConfiguration.CreatedByUserProfileId} IN ( 1, /* System User */ {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId} )");
            sql.AppendLine(") s");
            sql.AppendLine("WHERE");
            sql.AppendLine("    Rnk = 1");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key + "%"),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql.ToString(), CommandType.Text, databaseParameters))
            {
                while (dataReader.Read())
                {
                    IApplicationConfiguration entity = PopulateEntity<IApplicationConfiguration>(dataReader);
                    retVal.Add(entity);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        private void InternalSetValue(AppId applicationId, EntityId userProfileId, ConfigurationScope configurationScope, String key, String newValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfileId, configurationScope, key, newValue);

            StringBuilder sql = new StringBuilder();

            sql.AppendLine("MERGE");
            sql.AppendLine($"    {FDC.TableNames.ApplicationConfiguration} target");
            sql.AppendLine("USING");
            sql.AppendLine("    (");
            sql.AppendLine("        SELECT");
            sql.AppendLine($"            {EntityStatus.Active.Id()} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.StatusId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedOn},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedOn},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ValidFrom},");
            sql.AppendLine($"            {DataLogicProvider.ValidToDateString} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ValidTo},");
            sql.AppendLine();
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ConfigurationScopeId} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ConfigurationScopeId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Value} AS {FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Value}");
            sql.AppendLine("    ) AS source");
            sql.AppendLine("ON");
            sql.AppendLine("    (");
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.StatusId} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.StatusId} AND");
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.ApplicationId} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId} AND");
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.ConfigurationScopeId} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ConfigurationScopeId} AND");
            sql.AppendLine($"        target.[{FDC.ApplicationConfiguration.Key}] = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}");
            sql.AppendLine("    )");
            sql.AppendLine("WHEN MATCHED THEN UPDATE SET");
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId},");
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.LastUpdatedOn} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedOn},");
            sql.AppendLine();
            sql.AppendLine($"        target.{FDC.ApplicationConfiguration.Value} = source.{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Value}");
            sql.AppendLine("WHEN NOT MATCHED THEN INSERT");
            sql.AppendLine("    (");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.StatusId},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.CreatedByUserProfileId},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.LastUpdatedByUserProfileId},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.CreatedOn},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.LastUpdatedOn},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.ValidFrom},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.ValidTo},");
            sql.AppendLine();
            sql.AppendLine($"        {FDC.ApplicationConfiguration.ApplicationId},");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.ConfigurationScopeId},");
            sql.AppendLine($"        [{FDC.ApplicationConfiguration.Key}],");
            sql.AppendLine($"        {FDC.ApplicationConfiguration.Value}");
            sql.AppendLine("    )");
            sql.AppendLine("VALUES");
            sql.AppendLine("    (");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.StatusId},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.CreatedByUserProfileId},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.CreatedOn},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.LastUpdatedOn},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.ValidFrom},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.ValidTo},");
            sql.AppendLine();
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.ApplicationId},");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.ConfigurationScopeId},");
            sql.AppendLine($"        source.[{FDC.ApplicationConfiguration.Key}],");
            sql.AppendLine($"        source.{FDC.ApplicationConfiguration.Value}");
            sql.AppendLine("    );");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfileId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId}", userProfileId),

                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ConfigurationScopeId}", configurationScope.Id()),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Value}", newValue),
            ];

            Int32 rowsAffected = FoundationDataAccess.ExecuteNonQuery(sql.ToString(), CommandType.Text, databaseParameters);

            if (rowsAffected != 0)
            {
                throw new Exception();
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
