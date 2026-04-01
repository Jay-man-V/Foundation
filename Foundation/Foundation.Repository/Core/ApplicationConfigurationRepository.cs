//-----------------------------------------------------------------------
// <copyright file="ApplicationConfigurationRepository.cs" company="JDV Software Ltd">
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
    /// Defines the Configuration Scope Repository class
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
        /// <param name="coreDataProvider">The core data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public ApplicationConfigurationRepository
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

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityKey"/>
        protected override String EntityKey => FDC.ApplicationConfiguration.Key;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.ApplicationConfiguration.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.ApplicationConfiguration;

        /// <inheritdoc cref="IApplicationConfigurationRepository.SetValue(AppId, IUserProfile, ConfigurationScope, Boolean, String, String)"/>
        public void SetValue(AppId applicationId, IUserProfile userProfile, ConfigurationScope configurationScope, Boolean isEncrypted, String key, String newValue)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, configurationScope, key, newValue);

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfile.Id),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.LastUpdatedByUserProfileId}", userProfile.Id),

                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ConfigurationScopeId}", configurationScope.Id()),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.IsEncrypted}", isEncrypted),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Value}", newValue),
            ];

            Int32 rowsAffected = FoundationDataAccess.ExecuteNonQuery(sql, CommandType.Text, databaseParameters);

            if (rowsAffected != 1)
            {
                throw new Exception();
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IApplicationConfigurationRepository.Get(AppId, IUserProfile, String)"/>
        public IApplicationConfiguration? Get(AppId applicationId, IUserProfile userProfile, String key)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile, key);

            IApplicationConfiguration? retVal = default;

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql, CommandType.Text, databaseParameters))
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

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.Key}", key + "%"),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationConfiguration.EntityName}{FDC.ApplicationConfiguration.CreatedByUserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql, CommandType.Text, databaseParameters))
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
    }
}
