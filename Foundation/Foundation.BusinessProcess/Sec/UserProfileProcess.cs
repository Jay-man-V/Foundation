//-----------------------------------------------------------------------
// <copyright file="UserProfileProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;
using Foundation.Interfaces.Helpers;
using Foundation.Models.Specialised;

using FDC = Foundation.Resources.Constants.DataColumns;

namespace Foundation.BusinessProcess.Sec
{
    /// <summary>
    /// The User Profile Business Process
    /// </summary>
    [DependencyInjectionTransient]
    public class UserProfileProcess : CommonBusinessProcess<IUserProfile, IUserProfileRepository>, IUserProfileProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="UserProfileProcess" /> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="runTimeEnvironmentSettings">The runtime environment settings.</param>
        /// <param name="dateTimeService">The date time service</param>
        /// <param name="repository">The data access.</param>
        /// <param name="statusRepository">The status data access.</param>
        public UserProfileProcess
        (
            ICore core,
            IRunTimeEnvironmentSettings runTimeEnvironmentSettings,
            IDateTimeService dateTimeService,
            IUserProfileRepository repository,
            IStatusRepository statusRepository
        )
            : base
            (
                core,
                runTimeEnvironmentSettings,
                dateTimeService,
                repository,
                statusRepository,
                repository
            )
        {
            LoggingHelpers.TraceCallEnter(core, runTimeEnvironmentSettings, dateTimeService, repository, statusRepository, repository);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="ICommonBusinessProcess.ScreenTitle"/>
        public override String ScreenTitle => "User Profiles";

        /// <inheritdoc cref="ICommonBusinessProcess.StatusBarText"/>
        public override String StatusBarText => "Number of User Profiles:";

        /// <inheritdoc cref="ICommonBusinessProcess.ComboBoxDisplayMember" />
        public override String ComboBoxDisplayMember => FDC.UserProfile.DisplayName;

        /// <inheritdoc cref="ICommonBusinessProcess.GetColumnDefinitions()" />
        public override List<IGridColumnDefinition> GetColumnDefinitions()
        {
            LoggingHelpers.TraceCallEnter();

            List<IGridColumnDefinition> retVal = GetStandardEntityColumnDefinitions();
            IGridColumnDefinition gridColumnDefinition;

            gridColumnDefinition = new GridColumnDefinition(150, FDC.UserProfile.DomainName, "Domain name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(150, FDC.UserProfile.Username, "User name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(200, FDC.UserProfile.DisplayName, "Display name", typeof(String));
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(60, FDC.UserProfile.IsSystemSupport, $"Is{Environment.NewLine}System{Environment.NewLine}Support", typeof(Boolean))
            {
                TrueValue = "Y",
                FalseValue = String.Empty,
            };
            retVal.Add(gridColumnDefinition);

            gridColumnDefinition = new GridColumnDefinition(120, FDC.UserProfile.ExternalKeyId, "External Key Id", typeof(String));
            retVal.Add(gridColumnDefinition);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileProcess.GetLoggedOnUserProfile(AppId)"/>
        public IUserProfile GetLoggedOnUserProfile(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            String logonDomain = RunTimeEnvironmentSettings.UserDomainName;
            String username = RunTimeEnvironmentSettings.UserName;

            IUserProfile? retVal = EntityRepository.Get(applicationId, logonDomain, username);

            if (retVal == null)
            {
                String message = $"Unable to locate the User Profile with details: Application Id: '{applicationId}'. Logon Domain: '{logonDomain}'. User name: '{username}'.";
                throw new InvalidOperationException(message);
            }

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileProcess.GetUserProfile(AppId, EntityId)"/>
        public IUserProfile? GetUserProfile(AppId applicationId, EntityId userProfileId)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfileId);

            IUserProfile? retVal = EntityRepository.Get(applicationId, userProfileId);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileProcess.GetUserProfile(AppId, String, String)"/>
        public IUserProfile? GetUserProfile(AppId applicationId, String domainName, String username)
        {
            LoggingHelpers.TraceCallEnter(applicationId, domainName, username);

            IUserProfile? retVal = EntityRepository.Get(applicationId, domainName, username);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IUserProfileProcess.SyncActiveDirectoryUserDataFromStaging()"/>
        public void SyncActiveDirectoryUserDataFromStaging()
        {
            LoggingHelpers.TraceCallEnter();

            EntityRepository.SyncActiveDirectoryUserDataFromStaging(Core.CurrentLoggedOnUser.UserProfile);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
