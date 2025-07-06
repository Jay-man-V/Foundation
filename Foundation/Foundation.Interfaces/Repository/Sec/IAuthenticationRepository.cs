//-----------------------------------------------------------------------
// <copyright file="IAuthenticationRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Authentication Data Access interface
    /// </summary>
    public interface IAuthenticationRepository
    {
        /// <summary>
        /// Checks the database for the existence of the user profile for the application
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
