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

namespace Foundation.Repository.Sec
{
    /// <summary>
    /// Defines the Role Repository class
    /// </summary>
    [DependencyInjectionTransient]
    public class AuthenticationTokenRepository : FoundationDataAccess, IAuthenticationDataAccess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationTokenRepository"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service.</param>
        /// <param name="runTimeEnvironmentSettings">The run time environment settings.</param>
        /// <param name="systemConfigurationService">The system configuration service.</param>
        /// <param name="securityDataProvider">The security data provider.</param>
        public AuthenticationTokenRepository
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            ISystemConfigurationService systemConfigurationService,
            ISecurityDataProvider securityDataProvider
        ) :
            base
            (
                core,
                systemConfigurationService,
                securityDataProvider.ConnectionName
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, systemConfigurationService, securityDataProvider);

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

        /// <inheritdoc cref="IAuthenticationDataAccess.AuthenticateUser(AppId, IUserProfile)"/>
        public AuthenticationToken AuthenticateUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            AuthenticationToken retVal;

            Boolean canUserUseApplication = CanUserUseApplication(applicationId, userProfile);

            if (!canUserUseApplication)
            {
                String errorMessage = $"Cannot authenticate user for application {applicationId}";
                throw new UserLogonException(Core.ApplicationId, userProfile.Username, errorMessage);
            }

            retVal = CreateAuthenticationToken(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IAuthenticationDataAccess.ValidateAuthenticationToken(ref AuthenticationToken)"/>
        public void ValidateAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            String sql = GetSqlFromFile(FDC.TableNames.AuthenticationToken);

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}1", authenticationToken.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}2", authenticationToken.Id)
            ];

            Object? result = ExecuteScalar(sql, CommandType.Text, databaseParameters);

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

        /// <inheritdoc cref="IAuthenticationDataAccess.ExpireAuthenticationToken"/>
        public void ExpireAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            String sql = GetSqlFromFile(FDC.TableNames.AuthenticationToken);

            IDatabaseParameters databaseParameters = new DatabaseParameters
            {
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.Id}", authenticationToken.Id),
            };

            Int32 rowCount = ExecuteGetRowCount(sql, CommandType.Text, databaseParameters);

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

            String sql = GetSqlFromFile(FDC.TableNames.Application);

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{FDC.Application.EntityName}{FDC.Application.Id}", applicationId),
                CreateParameter($"{FDC.UserProfile.EntityName}{FDC.UserProfile.Id}", userProfile.Id),
            ];

            Int32 rowCount = ExecuteGetRowCount(sql, CommandType.Text, databaseParameters);

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

            String sql = GetSqlFromFile(FDC.TableNames.AuthenticationToken);

            DatabaseParameters databaseParameters =
            [
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.StatusId}", EntityStatus.Active.Id()),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.CreatedByUserProfileId}", userProfile.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.LastUpdatedByUserProfileId}", userProfile.Id),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.ApplicationId}", applicationId),
                CreateParameter($"{EntityName}{FDC.AuthenticationToken.UserProfileId}", userProfile.Id),
            ];

            using (IDataReader dataReader = ExecuteReader(sql, CommandType.Text, databaseParameters))
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
