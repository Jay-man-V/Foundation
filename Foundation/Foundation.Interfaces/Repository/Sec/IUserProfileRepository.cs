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
    public interface IUserProfileRepository : IFoundationModelRepository<IUserProfile>
    {
        /// <summary>
        /// Gets the specified application identifier.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="domainName">The domainName.</param>
        /// <param name="username">The username.</param>
        /// <returns>
        /// </returns>
        IUserProfile Get(AppId applicationId, String domainName, String username);

        /// <summary>
        /// Gets the specified application identifier.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="userProfileId">The user profile identifier.</param>
        /// <returns>
        /// </returns>
        IUserProfile Get(AppId applicationId, EntityId userProfileId);

        /// <summary>
        /// Synchronizes the active directory user data from staging.
        /// </summary>
        /// <param name="loggedOnUserProfile">The logged on user profile.</param>
        void SyncActiveDirectoryUserDataFromStaging(IUserProfile loggedOnUserProfile);
    }
}
