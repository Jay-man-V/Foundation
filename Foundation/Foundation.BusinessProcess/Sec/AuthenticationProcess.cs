//-----------------------------------------------------------------------
// <copyright file="AuthenticationProcess.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Common;
using Foundation.Interfaces;

namespace Foundation.BusinessProcess
{
    /// <ineritdoc cref="AuthenticationProcess" />
    [DependencyInjectionTransient]
    public class AuthenticationProcess : IAuthenticationProcess
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationProcess"/> class.
        /// </summary>
        /// <param name="core">The Foundation Core service</param>
        /// <param name="repository">The data access</param>
        public AuthenticationProcess
        (
            ICore core,
            IAuthenticationRepository repository
        )
        {
            LoggingHelpers.TraceCallEnter(core, repository);

            Core = core;
            Repository = repository;

            LoggingHelpers.TraceCallReturn();
        }

        /// <summary>
        /// Gets the Foundation Core Service
        /// </summary>
        private ICore Core { get; }

        /// <summary>
        /// Gets the data access
        /// </summary>
        private IAuthenticationRepository Repository { get; }

        /// <inheritdoc cref="IAuthenticationProcess.AuthenticateUser(AppId)"/>
        public AuthenticationToken AuthenticateUser(AppId applicationId)
        {
            LoggingHelpers.TraceCallEnter(applicationId);

            IUserProfile userProfile = Core.CurrentLoggedOnUser.UserProfile;
            AuthenticationToken retVal = AuthenticateUser(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IAuthenticationProcess.AuthenticateUser(AppId, IUserProfile)"/>
        public AuthenticationToken AuthenticateUser(AppId applicationId, IUserProfile userProfile)
        {
            LoggingHelpers.TraceCallEnter(applicationId, userProfile);

            AuthenticationToken retVal = Repository.AuthenticateUser(applicationId, userProfile);

            LoggingHelpers.TraceCallReturn(retVal);

            return retVal;
        }

        /// <inheritdoc cref="IAuthenticationProcess.ValidateAuthenticationToken(ref AuthenticationToken)"/>
        public void ValidateAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            Repository.ValidateAuthenticationToken(ref authenticationToken);

            LoggingHelpers.TraceCallReturn();
        }

        /// <inheritdoc cref="IAuthenticationProcess.ExpireAuthenticationToken(ref AuthenticationToken)"/>
        public void ExpireAuthenticationToken(ref AuthenticationToken authenticationToken)
        {
            LoggingHelpers.TraceCallEnter(authenticationToken);

            Repository.ExpireAuthenticationToken(ref authenticationToken);

            LoggingHelpers.TraceCallReturn();
        }
    }
}
