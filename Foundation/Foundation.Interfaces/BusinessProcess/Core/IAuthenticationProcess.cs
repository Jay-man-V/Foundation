//-----------------------------------------------------------------------
// <copyright file="IAuthenticationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines behaviours for the Authentication Process
    /// </summary>
    public interface IAuthenticationProcess
    {
        /// <summary>
        /// Authenticates the Logged On User against the Application defined by <paramref name="applicationId"/>
        /// <para>
        /// The external authorisation context must be set in the appropriate application property settings
        /// </para>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <returns></returns>
        AuthenticationToken AuthenticateUser(AppId applicationId);

        /// <summary>
        /// Authenticates a user against an external Authentication Provider, such as Azure Active Directory.
        /// Checks the <paramref name="userProfile"/> against the Application defined by <paramref name="applicationId"/>
        /// <para>
        /// The external authentication context must be set in the appropriate application property settings
        /// </para>
        /// </summary>
        /// <param name="applicationId"></param>
        /// <param name="userProfile"></param>
        /// <returns></returns>
        AuthenticationToken AuthenticateUser(AppId applicationId, IUserProfile userProfile);

        /// <summary>
        /// Checks to determine if the supplied <paramref name="authenticationToken"/> is valid
        /// <para>
        /// The external authentication context must be set in the appropriate application property settings
        /// </para>
        /// </summary>
        /// <param name="authenticationToken"></param>
        void ValidateAuthenticationToken(ref AuthenticationToken authenticationToken);

        /// <summary>
        /// Expires the supplied <paramref name="authenticationToken"/>. Effectively logging off the user from the system
        /// <para>
        /// The external authentication context must be set in the appropriate application property settings
        /// </para>
        /// </summary>
        /// <param name="authenticationToken"></param>
        void ExpireAuthenticationToken(ref AuthenticationToken authenticationToken);
    }
}
