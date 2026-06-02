//-----------------------------------------------------------------------
// <copyright file="LoggedOnUserRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository.Sec
{
    /// <summary>
    /// Defines the LoggedOnUser Repository class
    /// </summary>
    /// <see cref="ILoggedOnUser" />
    [DependencyInjectionTransient]
    public class LoggedOnUserRepository : FoundationModelRepository<ILoggedOnUser>, ILoggedOnUserRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="LoggedOnUserRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="securityDataProvider">The security data provider.</param>
        /// <param name="dateTimeService">The date/time service.</param>
        public LoggedOnUserRepository
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

        /// <inheritdoc cref="FoundationModelRepository{TModel}.HasValidityPeriodColumns"/>
        public override Boolean HasValidityPeriodColumns => false;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.EntityName"/>
        protected override String EntityName => FDC.LoggedOnUser.EntityName;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.TableName"/>
        protected override String TableName => FDC.TableNames.LoggedOnUser;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumCreateRole"/>
        protected override ApplicationRole RequiredMinimumCreateRole => ApplicationRole.None;

        /// <inheritdoc cref="FoundationModelRepository{TModel}.RequiredMinimumEditRole"/>
        protected override ApplicationRole RequiredMinimumEditRole => ApplicationRole.None;

        /// <inheritdoc cref="ILoggedOnUserRepository.UpdateCommand(AppId, ILoggedOnUser, String)"/>
        public void UpdateCommand(AppId applicationId, ILoggedOnUser loggedOnUser, String command)
        {
            LoggingHelpers.TraceCallEnter(applicationId, loggedOnUser, command);

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine($"    {FDC.TableNames.LoggedOnUser}");
            sql.AppendLine("SET");
            sql.AppendLine($"   {FDC.LoggedOnUser.Command} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.Command}");
            sql.AppendLine("WHERE");
            sql.AppendLine($"   {FDC.LoggedOnUser.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId} AND");
            sql.AppendLine($"   {FDC.LoggedOnUser.UserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.Command}", command, DataHelpers.DefaultString),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}", FDC.LoggedOnUser.UserProfileId),
            ];

            FoundationDataAccess.ExecuteNonQuery(sql.ToString(), CommandType.Text, databaseParameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserRepository.LogUserOn(AppId, IUserProfile)"/>
        public void LogUserOn(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedByUserProfileId}", userProfile.Id),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedByUserProfileId}", userProfile.Id),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}", userProfile.Id),
            ];

            FoundationDataAccess.ExecuteNonQuery(sql, CommandType.Text, databaseParameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserRepository.UpdateLoggedOnUser(AppId, IUserProfile)"/>
        public void UpdateLoggedOnUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}", userProfile.Id)
            ];

            FoundationDataAccess.ExecuteNonQuery(sql, CommandType.Text, databaseParameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserRepository.GetLoggedOnUsers(AppId)"/>
        public List<ILoggedOnUser> GetLoggedOnUsers(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            List<ILoggedOnUser> retVal = [];

            String sql = GetSqlFromFile();

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql, CommandType.Text, databaseParameters))
            {
                while (dataReader.Read())
                {
                    ILoggedOnUser loggedOnUser = base.PopulateEntity<ILoggedOnUser>(dataReader);

                    retVal.Add(loggedOnUser);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
