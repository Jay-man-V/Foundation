//-----------------------------------------------------------------------
// <copyright file="AuthorisationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <ineritdoc cref="IAuthorisationProcess" />
    [DependencyInjectionTransient]
    public class AuthorisationProcess : IAuthorisationProcess
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AuthorisationProcess"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="permissionMatrixProcess">The permission matrix process.</param>
        /// <param name="authenticationProcess">The authentication process.</param>
        public AuthorisationProcess
        (
            ICore core,
            IPermissionMatrixProcess permissionMatrixProcess,
            IAuthenticationProcess authenticationProcess
        )
        {
            LoggingHelpers.TraceCallEnter(core, permissionMatrixProcess, authenticationProcess);

            Core = core;
            PermissionMatrixProcess = permissionMatrixProcess;
            AuthenticationProcess = authenticationProcess;

            LoggingHelpers.TraceCallReturn();
        }

        private ICore Core { get; }
        private IPermissionMatrixProcess PermissionMatrixProcess { get; }

        /// <summary>
        /// Gets the Authentication Process
        /// </summary>
        private IAuthenticationProcess AuthenticationProcess { get; }

        /// <inheritdoc cref="IAuthorisationProcess.IsUserAuthorised(ref AuthenticationToken, String)"/>
        public void IsUserAuthorised(ref AuthenticationToken authenticationToken, String functionKey)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken, functionKey);

            AuthenticationProcess.ValidateAuthenticationToken(ref authenticationToken);

            Boolean result = PermissionMatrixProcess.CanUserPerformFunction(ref authenticationToken, functionKey);

            if (!result)
            {
                String processName = $"{GetType()}::{LocationUtils.GetFunctionName()}";
                throw new ApplicationPermissionsException(Core.ApplicationId, processName, Core.CurrentLoggedOnUser.UserProfile, functionKey);
            }

            LoggingHelpers.TraceCallReturn();
        }
    }
}
