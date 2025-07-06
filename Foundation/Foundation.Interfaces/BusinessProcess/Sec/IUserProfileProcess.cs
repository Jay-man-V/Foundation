//-----------------------------------------------------------------------
// <copyright file="IUserProfileProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the User Profile process
    /// </summary>
    public interface IUserProfileProcess : ICommonBusinessProcess<IUserProfile>
    {
        /// <summary>
        /// Retrieves the logged on users profile for the application denoted by <paramref name="applicationId"/>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns><see cref="IUserProfile"/></returns>
        IUserProfile GetLoggedOnUserProfile(AppId applicationId);

        /// <summary>
        /// Retrieves the user profile specified by <paramref name="userProfileId"/> for the application denoted by <paramref name="applicationId"/>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns><see cref="IUserProfile"/></returns>
        IUserProfile GetUserProfile(AppId applicationId, EntityId userProfileId);

        /// <summary>
        /// Retrieves the user profile specified by <paramref name="username"/> for the application denoted by <paramref name="applicationId"/>
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="domainName">The domainName.</param>
        /// <param name="username">The username.</param>
        /// <returns><see cref="IUserProfile"/></returns>
        IUserProfile GetUserProfile(AppId applicationId, String domainName, String username);

        /// <summary>
        /// Synchronises the Activity Directory User Data from Staging
        /// </summary>
        void SyncActiveDirectoryUserDataFromStaging();
    }
}
