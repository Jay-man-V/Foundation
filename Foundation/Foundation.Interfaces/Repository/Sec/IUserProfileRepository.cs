//-----------------------------------------------------------------------
// <copyright file="IUserProfileRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The User Profile Data Access interface
    /// </summary>
    public interface IUserProfileRepository : IFoundationModelDataAccess<IUserProfile>
    {
        /// <summary>
        /// Retrieves the UserProfile for the specified application and security identifier.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="securityIdentifier">The security identifier.</param>
        /// <returns>
        /// </returns>
        IUserProfile? Get(AppId applicationId, String securityIdentifier);

        /// <summary>
        /// Retrieves the UserProfile for the specified application, domain name, and username.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="domainName">The domainName.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// </returns>
        IUserProfile? Get(AppId applicationId, String domainName, String username);

        /// <summary>
        /// Retrieves the UserProfile for the specified application and user profile identifier.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns>
        /// </returns>
        IUserProfile? Get(AppId applicationId, EntityId userProfileId);

        /// <summary>
        /// Synchronizes the active directory user data from staging.
        /// </summary>
        /// <param name="loggedOnUserProfile">The logged on user profile.</param>
        void SyncActiveDirectoryUserDataFromStaging(IUserProfile loggedOnUserProfile);
    }
}
