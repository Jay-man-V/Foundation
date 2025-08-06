//-----------------------------------------------------------------------
// <copyright file="UserProfileRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Common.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the User Profile Data Access class
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
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public UserProfileRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDatabaseProvider databaseProvider,
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

        /// <inheritdoc cref="IUserProfileRepository.Get(AppId, String, String)"/>
        public IUserProfile? Get(AppId applicationId, String domainName, String username)
        {
            LoggingHelpers.TraceCallEnter(applicationId, domainName, username);

            IUserProfile? retVal = null;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    up.*,");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.RoleId}");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {FDC.TableNames.UserProfile} up");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.ApplicationUserRole} aur ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             up.{FDC.UserProfile.Id} = aur.{FDC.ApplicationUserRole.UserProfileId}");
            sql.AppendLine("        )");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    up.{FDC.UserProfile.DomainName} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.UserProfile.EntityName}{FDC.UserProfile.DomainName} AND");
            sql.AppendLine($"    up.{FDC.UserProfile.Username} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.UserProfile.EntityName}{FDC.UserProfile.Username} AND");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId} AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN up.{FDC.UserProfile.ValidFrom} AND up.{FDC.UserProfile.ValidTo} AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN aur.{FDC.UserProfile.ValidFrom} AND aur.{FDC.UserProfile.ValidTo}");

            DatabaseParameters databaseParameters = new DatabaseParameters
            {
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.DomainName}", domainName),
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Username}", username),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId}", applicationId),
            };

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql.ToString(), CommandType.Text, databaseParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = base.PopulateEntity<IUserProfile>(dr);
                IRoleRepository roleRepository = Core.IoC.Get<IRoleRepository>();
                EntityId roleId = DataHelpers.GetValue(dr[FDC.ApplicationUserRole.RoleId], new EntityId());
                IRole role = roleRepository.Get(roleId);
                retVal.Roles.Add(role);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileRepository.Get(AppId, EntityId)"/>
        public IUserProfile? Get(AppId applicationId, EntityId userProfileId)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfileId);

            IUserProfile? retVal = default;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    up.*,");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.RoleId}");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {FDC.TableNames.UserProfile} up");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.ApplicationUserRole} aur ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             up.{FDC.UserProfile.Id} = aur.{FDC.ApplicationUserRole.UserProfileId}");
            sql.AppendLine("        )");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    up.{FDC.UserProfile.Id} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.UserProfile.EntityName}{FDC.UserProfile.Id} AND");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId} AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN up.{FDC.UserProfile.ValidFrom} AND up.{FDC.UserProfile.ValidTo} AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN aur.{FDC.UserProfile.ValidFrom} AND aur.{FDC.UserProfile.ValidTo}");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Id}", userProfileId),
                FoundationDataAccess.CreateParameter($"{FDC.ApplicationUserRole.EntityName}{FDC.ApplicationUserRole.ApplicationId}", applicationId),
            ];

            DataTable dataTable = FoundationDataAccess.ExecuteDataTable(sql.ToString(), CommandType.Text, databaseParameters);

            if (dataTable.Rows.Count > 0)
            {
                DataRow dr = dataTable.Rows[0];
                retVal = base.PopulateEntity<IUserProfile>(dr);
                IRoleRepository roleRepository = Core.IoC.Get<IRoleRepository>();
                EntityId roleId = DataHelpers.GetValue(dr[FDC.ApplicationUserRole.RoleId], new EntityId());
                IRole role = roleRepository.Get(roleId);
                retVal.Roles.Add(role);
            }

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

                        String sql = FDC.StoredProcedureNames.UserProfileLoadFromActiveDirectoryUsersFromStaging;
                        command.CommandText = sql;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.Add(FoundationDataAccess.CreateParameter("loggedOnUserProfileId", loggedOnUserProfile.Id));

                        command.ExecuteNonQuery();
                    }

                    transaction.Commit();
                }
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
