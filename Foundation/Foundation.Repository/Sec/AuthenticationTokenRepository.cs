//-----------------------------------------------------------------------
// <copyright file="AuthenticationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Data;
using System.Text;

using Foundation.Common;
using Foundation.DataAccess.Database;
using Foundation.Interfaces;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.Repository
{
    /// <summary>
    /// Defines the Role Data Access class
    /// </summary>
    [DependencyInjectionTransient]
    public class AuthenticationTokenRepository : FoundationDataAccess, IAuthenticationRepository
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationTokenRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="databaseProvider"></param>
        public AuthenticationTokenRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDatabaseProvider databaseProvider
        ) :
            base
            (
                core,
                systemConfigurationService,
                databaseProvider
            )
        {
            LoggingHelpers.TraceCallEnter(core, systemConfigurationService, runTimeEnvironmentSettings, databaseProvider);

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the name of the entity.
        /// </summary>
        /// <value>The name of the entity.</value>
        protected String EntityName => FDC.AuthenticationToken.EntityName;

        /// <summary>
        /// Gets the name of the table.
        /// </summary>
        /// <value>The name of the table.</value>
        protected String TableName => FDC.TableNames.AuthenticationToken;

        /// <inheritdoc cref="IAuthenticationRepository.AuthenticateUser(AppId, IUserProfile)"/>
        public AuthenticationToken AuthenticateUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            AuthenticationToken retVal;

            Boolean canUserUseApplication = CanUserUseApplication(applicationId, userProfile);

            if (!canUserUseApplication)
            {
                String errorMessage = $"Cannot authenticate user for application {applicationId}";
                throw new UserLogonException(userProfile.Username, errorMessage);
            }

            retVal = CreateAuthenticationToken(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IAuthenticationRepository.ValidateAuthenticationToken(ref AuthenticationToken)"/>
        public void ValidateAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine($"    {TableName}");
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastUpdatedOn} = {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastRefreshed} = {DataLogicProvider.CurrentDateTimeFunction}");
            sql.AppendLine("WHERE ");
            sql.AppendLine($"    {FDC.AuthenticationToken.StatusId} = {EntityStatus.Active.Id()} AND");
            sql.AppendLine($"    {FDC.AuthenticationToken.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.Id}1");
            sql.AppendLine();
            sql.AppendLine("SELECT");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastRefreshed}");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.AuthenticationToken.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.Id}2");

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}1", authenticationToken.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}2", authenticationToken.Id)
            ];

            Object? result = ExecuteScalar(sql.ToString(), CommandType.Text, databaseParameters);

            if (result != null &&
                DateTime.TryParse(result.ToString(), out DateTime dt))
            {
                authenticationToken = new AuthenticationToken(authenticationToken, dt);
            }
            else
            {
                String errorMessage = "Unable to refresh Authentication Token";
                throw new AuthenticationTokenException(authenticationToken.UserProfileId, errorMessage);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IAuthenticationRepository.ExpireAuthenticationToken"/>
        public void ExpireAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("UPDATE");
            sql.AppendLine($"    {TableName}");
            sql.AppendLine("SET");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastUpdatedOn} = {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {FDC.AuthenticationToken.StatusId} = {EntityStatus.Inactive.Id()}");
            sql.AppendLine("WHERE ");
            sql.AppendLine($"    {FDC.AuthenticationToken.Id} = {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.Id}");

            IDatabaseParameters databaseParameters = new DatabaseParameters
            {
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}", authenticationToken.Id),
            };

            Int32 rowCount = ExecuteGetRowCount(sql.ToString(), CommandType.Text, databaseParameters);

            if (rowCount == 1)
            {
                // Authentication is now useless, clear the reference to it
                authenticationToken = default;
            }
            else
            {
                String errorMessage = "Unable to expire Authentication Token";
                throw new AuthenticationTokenException(authenticationToken.UserProfileId, errorMessage);
            }

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        private Boolean CanUserUseApplication(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            Boolean retVal;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine($"    {FDC.TableNames.Application} a");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.ApplicationUserRole} aur ON");
            sql.AppendLine("         (");
            sql.AppendLine($"              aur.{FDC.ApplicationUserRole.ApplicationId} = a.{FDC.Application.Id}");
            sql.AppendLine("         )");
            sql.AppendLine($"        INNER JOIN {FDC.TableNames.UserProfile} up ON");
            sql.AppendLine("         (");
            sql.AppendLine($"              up.{FDC.UserProfile.Id} = aur.{FDC.ApplicationUserRole.UserProfileId}");
            sql.AppendLine("         )");
            sql.AppendLine("WHERE");
            sql.AppendLine($"    a.{FDC.Application.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN a.{FDC.Application.ValidFrom} AND a.{FDC.Application.ValidTo} AND");
            sql.AppendLine($"    aur.{FDC.ApplicationUserRole.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN aur.{FDC.ApplicationUserRole.ValidFrom} AND aur.{FDC.ApplicationUserRole.ValidTo} AND");
            sql.AppendLine($"    up.{FDC.UserProfile.StatusId} IN ( {EntityStatus.Active.Id()}, {EntityStatus.Approved.Id()} ) AND");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction} BETWEEN up.{FDC.UserProfile.ValidFrom} AND up.{FDC.UserProfile.ValidTo} AND");
            sql.AppendLine($"    a.{FDC.Application.Id} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.Application.EntityName}{FDC.Application.Id} AND");
            sql.AppendLine($"    up.{FDC.UserProfile.Id} = {DataLogicProvider.DatabaseParameterPrefix}{FDC.UserProfile.EntityName}{FDC.UserProfile.Id}");

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{FDC.Application.EntityName}{FDC.Application.Id}", applicationId),
                CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Id}", userProfile.Id),
            ];

            Int32 rowCount = ExecuteGetRowCount(sql.ToString(), CommandType.Text, databaseParameters);

            retVal = (rowCount > 0);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <summary>
        /// Creates and <see cref="AuthenticationToken"/> for the user
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        private AuthenticationToken CreateAuthenticationToken(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            AuthenticationToken retVal;

            StringBuilder sql = new StringBuilder();
            sql.AppendLine("INSERT INTO");
            sql.AppendLine(TableName);
            sql.AppendLine("(");
            sql.AppendLine($"    {FDC.AuthenticationToken.StatusId},");
            sql.AppendLine($"    {FDC.AuthenticationToken.CreatedByUserProfileId},");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {FDC.AuthenticationToken.CreatedOn},");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastUpdatedOn},");
            sql.AppendLine($"    {FDC.AuthenticationToken.ApplicationId},");
            sql.AppendLine($"    {FDC.AuthenticationToken.UserProfileId},");
            sql.AppendLine($"    {FDC.AuthenticationToken.Token},");
            sql.AppendLine($"    {FDC.AuthenticationToken.Acquired},");
            sql.AppendLine($"    {FDC.AuthenticationToken.LastRefreshed}");
            sql.AppendLine(")");
            sql.AppendLine("VALUES");
            sql.AppendLine("(");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.StatusId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.CreatedByUserProfileId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.LastUpdatedByUserProfileId},");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.ApplicationId},");
            sql.AppendLine($"    {DataLogicProvider.DatabaseParameterPrefix}{EntityName}{FDC.AuthenticationToken.UserProfileId},");
            sql.AppendLine($"    {DataLogicProvider.UniqueIdFunction},");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction},");
            sql.AppendLine($"    {DataLogicProvider.CurrentDateTimeFunction}");
            sql.AppendLine(");");
            sql.AppendLine();
            sql.AppendLine("SELECT");
            sql.AppendLine("    *");
            sql.AppendLine("FROM");
            sql.AppendLine(TableName);
            sql.AppendLine("WHERE");
            sql.AppendLine($"    {FDC.AuthenticationToken.Id} = {DataLogicProvider.IdentityOfLastInsertFunction}");

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.StatusId}", EntityStatus.Active.Id()),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.CreatedByUserProfileId}", userProfile.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.LastUpdatedByUserProfileId}", userProfile.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.ApplicationId}", applicationId),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.UserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = ExecuteReader(sql.ToString(), CommandType.Text, databaseParameters))
            {
                if (dataReader.Read())
                {
                    EntityId id = DataHelpers.GetValue(dataReader[FDC.AuthenticationToken.Id], DataHelpers.DefaultEntityId);
                    DateTime acquired = DataHelpers.GetValue(dataReader[FDC.AuthenticationToken.Acquired], DataHelpers.DefaultDateTime);
                    String token = DataHelpers.GetValue(dataReader[FDC.AuthenticationToken.Token], DataHelpers.DefaultString);
                    DateTime lastRefreshed = DataHelpers.GetValue(dataReader[FDC.AuthenticationToken.LastRefreshed], DataHelpers.DefaultDateTime);

                    retVal = new AuthenticationToken(id, applicationId, userProfile.Id, acquired, token, lastRefreshed);
                }
                else
                {
                    throw new UnableToReadNewIdentityException(EntityName, TableName);
                }

                dataReader.Close();
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }
    }
}
