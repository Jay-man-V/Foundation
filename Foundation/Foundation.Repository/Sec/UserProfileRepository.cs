//-----------------------------------------------------------------------
// <copyright file="UserProfileRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Sec
{
    /// <summary>
    /// Defines the User Profile Repository class
    /// </summary>
    /// <see cref="IUserProfile" />
    [DependencyInjectionTransient]
    public class UserProfileRepository : FoundationModelRepository<IUserProfile>, IUserProfileRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="UserProfileRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="securityDataProvider">The security data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public UserProfileRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDataProvider securityDataProvider,
            IDateTimeService dateTimeService
        ) :
            base
            (
                core,
                runTimeEnvironmentSettings,
                systemConfigurationService,
                securityDataProvider,
                dateTimeService
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, securityDataProvider, dateTimeService);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.UserProfile.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.UserProfile;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityKey"/>
        protected override String EntityKey => FDC.UserProfile.Username;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.SystemDataAdministrator;

        /// <inheritdoc cref="IUserProfileRepository.Get(AppId, String)"/>
        public IUserProfile? Get(AppId applicationId, String securityIdentifier)
        {
            LoggingHelpers.TraceCallEnter(applicationId, securityIdentifier);

            IUserProfile? retVal = null;

            String sql = GetSqlFromFile("GetBySecurityIdentifier");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.ExternalKeyId}", securityIdentifier),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId}", applicationId)
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql, CommandType.Text, databaseParameters);

            retVal = PopulateUserProfileEntity(dataTable);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileRepository.Get(AppId, String, String)"/>
        public IUserProfile? Get(AppId applicationId, String domainName, String username)
        {
            LoggingHelpers.TraceCallEnter(applicationId, domainName, username);

            IUserProfile? retVal = null;

            String sql = GetSqlFromFile("GetByDomainUsername");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.DomainName}", domainName),
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Username}", username),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId}", applicationId)
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql, CommandType.Text, databaseParameters);

            retVal = PopulateUserProfileEntity(dataTable);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileRepository.Get(AppId, EntityId)"/>
        public IUserProfile? Get(AppId applicationId, EntityId userProfileId)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfileId);

            IUserProfile? retVal = null;

            String sql = GetSqlFromFile("GetByUserProfileId");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Id}", userProfileId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId}", applicationId),
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql, CommandType.Text, databaseParameters);

            retVal = PopulateUserProfileEntity(dataTable);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileRepository.SyncActiveDirectoryUserDataFromStaging(IUserProfile)"/>
        public void SyncActiveDirectoryUserDataFromStaging(IUserProfile loggedOnUserProfile)
        {
            LoggingHelpers.TraceCallEnter(loggedOnUserProfile);

            using (IDbConnection conn = FoundationDataAccess.GetConnection())
            {
                using (IDbTransaction transaction = conn.BeginTransaction())
                {
                    using (IDbCommand command = conn.CreateCommand())
                    {
                        command.Transaction = transaction;

                        String sql = StoredProcedures.LoadFromActiveDirectoryUsersFromStaging.ProcedureName;
                        command.CommandText = sql;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(FoundationDataAccess.CreateParameter(StoredProcedures.LoadFromActiveDirectoryUsersFromStaging.LoggedOnUserProfileId, loggedOnUserProfile.Id));

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }

        private IUserProfile? PopulateUserProfileEntity(DataTable dataTable)
        {
            LoggingHelpers.TraceCallEnter(dataTable);

            IUserProfile? retVal = Core.IoC.Get<IUserProfile>();

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = base.PopulateEntity<IUserProfile>(dr);
                foreach (DataRow rolesDataRow in dataTable.Rows)
                {
                    IRoleRepository roleRepository = Core.IoC.Get<IRoleRepository>();
                    EntityId roleId = DataHelpers.GetValue(rolesDataRow[FDC.ApplicationUserRole.RoleId], new EntityId());
                    IRole? role = roleRepository.Get(roleId);
                    if (role != null)
                    {
                        retVal.Roles.Add(role);
                    }
                }
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
}
}
