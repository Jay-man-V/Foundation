//-----------------------------------------------------------------------
// <copyright file="IAuthorisationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines behaviours for the Authorisation Process
    /// </summary>
    public interface IAuthorisationProcess
    {
        /// <summary>
        /// Determines if a user is authorised to execute a particular function
        /// <para>
        /// The external authorisation context must be set in the appropriate application property settings
        /// </para>
        /// </summary>
        /// <param name="authenticationToken"></param>
        /// <param name="functionKey"></param>
        /// <returns></returns>
        void IsUserAuthorised(ref AuthenticationToken authenticationToken, String functionKey);
    }
}
