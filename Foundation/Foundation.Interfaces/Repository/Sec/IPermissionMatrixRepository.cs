//-----------------------------------------------------------------------
// <copyright file="IPermissionMatrixRepository.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Permission Matrix Data Access interface
    /// </summary>
    public interface IPermissionMatrixRepository : IFoundationModelRepository<IPermissionMatrix>
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
        Boolean CanUserPerformFunction(ref AuthenticationToken authenticationToken, String functionKey);
    }
}
