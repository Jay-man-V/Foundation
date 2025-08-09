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

using FDC = Foundation.Resources.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the LoggedOnUser Data Access class
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
        /// <param name="databaseProvider"></param>
        /// <param name="dateTimeService"></param>
        public LoggedOnUserRepository
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

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("MERGE INTO");
            sql.AppendLine($"    {FDC.TableNames.LoggedOnUser} AS target");
            sql.AppendLine("USING");
            sql.AppendLine("    (");
            sql.AppendLine("        SELECT");
            sql.AppendLine($"            {EntityStatus.Active.Id()} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.StatusId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedByUserProfileId} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedByUserProfileId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedByUserProfileId} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedByUserProfileId},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedOn},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedOn},");
            sql.AppendLine();
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId},");
            sql.AppendLine($"            {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LoggedOn},");
            sql.AppendLine($"            {DataLogicProvider.CurrentDateTimeFunction} AS {FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastActive}");
            sql.AppendLine("    ) AS source");
            sql.AppendLine("ON");
            sql.AppendLine("    (");
            sql.AppendLine($"        target.{FDC.LoggedOnUser.ApplicationId} = source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId} AND");
            sql.AppendLine($"        target.{FDC.LoggedOnUser.UserProfileId} = source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}");
            sql.AppendLine("    )");
            sql.AppendLine("WHEN MATCHED THEN UPDATE SET");
            sql.AppendLine($"       target.{FDC.LoggedOnUser.LastUpdatedOn} = source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedOn},");
            sql.AppendLine($"       target.{FDC.LoggedOnUser.LastActive} = source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastActive},");
            sql.AppendLine($"       target.{FDC.LoggedOnUser.LoggedOn} = source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LoggedOn}");
            sql.AppendLine("WHEN NOT MATCHED THEN INSERT");
            sql.AppendLine("   (");
            sql.AppendLine($"       {FDC.LoggedOnUser.StatusId},");
            sql.AppendLine($"       {FDC.LoggedOnUser.CreatedByUserProfileId},");
            sql.AppendLine($"       {FDC.LoggedOnUser.LastUpdatedByUserProfileId},");
            sql.AppendLine($"       {FDC.LoggedOnUser.CreatedOn},");
            sql.AppendLine($"       {FDC.LoggedOnUser.LastUpdatedOn},");
            sql.AppendLine();
            sql.AppendLine($"       {FDC.LoggedOnUser.ApplicationId},");
            sql.AppendLine($"       {FDC.LoggedOnUser.UserProfileId},");
            sql.AppendLine($"       {FDC.LoggedOnUser.LoggedOn},");
            sql.AppendLine($"       {FDC.LoggedOnUser.LastActive}");
            sql.AppendLine("   )");
            sql.AppendLine("   VALUES");
            sql.AppendLine("   (");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.StatusId},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedByUserProfileId},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedByUserProfileId},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedOn},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedOn},");
            sql.AppendLine();
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LoggedOn},");
            sql.AppendLine($"       source.{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastActive}");
            sql.AppendLine("   );");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.CreatedByUserProfileId}", userProfile.Id),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.LastUpdatedByUserProfileId}", userProfile.Id),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}", userProfile.Id),
            ];

            FoundationDataAccess.ExecuteNonQuery(sql.ToString(), CommandType.Text, databaseParameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserRepository.UpdateLoggedOnUser(AppId, IUserProfile)"/>
        public void UpdateLoggedOnUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine($"    {FDC.TableNames.LoggedOnUser}");
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.LoggedOnUser.LastUpdatedOn} = {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {FDC.LoggedOnUser.LastActive} = {DataLogicProvider.CurrentDateTimeFunction}");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.LoggedOnUser.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId} AND");
            sql.AppendLine($"    {FDC.LoggedOnUser.UserProfileId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.UserProfileId}", userProfile.Id)
            ];

            FoundationDataAccess.ExecuteNonQuery(sql.ToString(), CommandType.Text, databaseParameters);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ILoggedOnUserRepository.GetLoggedOnUsers(AppId)"/>
        public List<ILoggedOnUser> GetLoggedOnUsers(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            List<ILoggedOnUser> retVal = [];

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT ");
            sql.AppendLine("    lou.*, ");
            sql.AppendLine($"    r.{FDC.Role.Id} AS {FDC.LoggedOnUser.RoleId}, ");
            sql.AppendLine($"    r.{FDC.Role.Description} AS {FDC.LoggedOnUser.RoleDescription}, ");
            sql.AppendLine($"    r.{FDC.Role.SystemSupportOnly} AS {FDC.LoggedOnUser.IsSystemSupport}");
            sql.AppendLine("FROM ");
            sql.AppendLine($"    {FDC.TableNames.LoggedOnUser} lou ");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.Application} a ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             a.{FDC.Application.Id} = lou.{FDC.LoggedOnUser.ApplicationId} ");
            sql.AppendLine("        )");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.ApplicationUserRole} aur ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             aur.{FDC.ApplicationUserRole.ApplicationId} = lou.{FDC.LoggedOnUser.ApplicationId} AND");
            sql.AppendLine($"             aur.{FDC.ApplicationUserRole.UserProfileId} = lou.{FDC.LoggedOnUser.CreatedByUserProfileId} ");
            sql.AppendLine("        )");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.Role} r ON");
            sql.AppendLine("        (");
            sql.AppendLine($"             r.{FDC.Role.Id} = aur.{FDC.ApplicationUserRole.RoleId} ");
            sql.AppendLine("        )");
            sql.AppendLine("WHERE ");
            sql.AppendLine($"    lou.{FDC.LoggedOnUser.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    a.{FDC.Application.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    r.{FDC.Role.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN a.{FDC.Application.ValidFrom} AND a.{FDC.Application.ValidTo} AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN aur.{FDC.ApplicationUserRole.ValidFrom} AND aur.{FDC.ApplicationUserRole.ValidTo} AND ");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN r.{FDC.Role.ValidFrom} AND r.{FDC.Role.ValidTo} AND ");
            sql.AppendLine($"    lou.{FDC.LoggedOnUser.ApplicationId} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId} AND ");
            sql.AppendLine($"    {DataLogicProvider.GetMinuteComparisonSql("lou." + FDC.FoundationEntity.LastUpdatedOn, DataLogicProvider.CurrentDateTimeFunction, "<= 1")}");
            sql.AppendLine("ORDER BY");
            sql.AppendLine($"    {FDC.LoggedOnUser.RoleId} DESC, {FDC.LoggedOnUser.LoggedOn} ASC");

            DatabaseParameters databaseParameters =
            [
                FoundationDataAccess.CreateParameter($"{FDC.LoggedOnUser.EntityName}{FDC.LoggedOnUser.ApplicationId}", applicationId),
            ];

            using (IDataReader dataReader = FoundationDataAccess.ExecuteReader(sql.ToString(), CommandType.Text, databaseParameters))
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
