//-----------------------------------------------------------------------
// <copyright file="IPermissionProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Permission Matrix Process
    /// </summary>
    public interface IPermissionMatrixProcess : ICommonBusinessProcess<IPermissionMatrix>
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
