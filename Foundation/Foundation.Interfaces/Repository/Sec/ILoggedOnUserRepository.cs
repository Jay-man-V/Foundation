//-----------------------------------------------------------------------
// <copyright file="ILoggedOnUserRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Logged On User Data Access interface
    /// </summary>
    public interface ILoggedOnUserRepository : IFoundationModelRepository<ILoggedOnUser>
    {
        /// <summary>
        /// Updates the command.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="loggedOnUser">The logged on user.</param>
        /// <param name="command">The command.</param>
        void UpdateCommand(AppId applicationId, ILoggedOnUser loggedOnUser, String command);

        /// <summary>
        /// Logs the user on.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="userProfile">The user profile.</param>
        void LogUserOn(AppId applicationId, IUserProfile userProfile);

        /// <summary>
        /// Updates the logged on user.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <param name="userProfile">The user profile.</param>
        void UpdateLoggedOnUser(AppId applicationId, IUserProfile userProfile);

        /// <summary>
        /// Gets the logged on users.
        /// </summary>
        /// <param name="applicationId">The application identifier.</param>
        /// <returns>
        ///   <br />
        /// </returns>
        List<ILoggedOnUser> GetLoggedOnUsers(AppId applicationId);
    }
}
