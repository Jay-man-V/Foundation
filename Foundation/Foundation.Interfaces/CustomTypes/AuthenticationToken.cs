//-----------------------------------------------------------------------
// <copyright file="AuthenticationToken.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Diagnostics;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Authentication model interface
    /// </summary>
    [DebuggerDisplay("{Token} - {Acquired.ToString(\"dd-MMM-yyyy HH:mm:ss\")} - {LastRefreshed.ToString(\"dd-MMM-yyyy HH:mm:ss\")}")]
    public readonly struct AuthenticationToken
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="authenticationToken"></param>
        /// <param name="lastRefreshed"></param>
        internal AuthenticationToken(AuthenticationToken authenticationToken, DateTime lastRefreshed) :
            this
            (
                authenticationToken.Id,
                authenticationToken.ApplicationId,
                authenticationToken.UserProfileId,
                authenticationToken.Acquired,
                authenticationToken.Token,
                lastRefreshed
            )
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="applicationId"></param>
        /// <param name="userProfileId"></param>
        /// <param name="acquired"></param>
        /// <param name="token"></param>
        /// <param name="lastRefreshed"></param>
        internal AuthenticationToken(EntityId id, AppId applicationId, EntityId userProfileId, DateTime acquired, String token, DateTime lastRefreshed)
        {
            Id = id;
            ApplicationId = applicationId;
            UserProfileId = userProfileId;
            Acquired = acquired;
            Token = token;
            LastRefreshed = lastRefreshed;
        }

        /// <summary>
        /// Gets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public EntityId Id { get; }

        /// <summary>
        /// Gets the application identifier.
        /// </summary>
        /// <value>
        /// The application identifier.
        /// </value>
        public AppId ApplicationId { get; }

        /// <summary>
        /// Gets user profile identifier.
        /// </summary>
        /// <value>
        /// The user profile identifier.
        /// </value>
        public EntityId UserProfileId { get; }

        /// <summary>
        /// The Date/Time the token was acquired
        /// </summary>
        /// <value>
        /// The acquired Date/Time.
        /// </value>
        public DateTime Acquired { get; }

        /// <summary>
        /// The token
        /// </summary>
        public String Token { get; }

        /// <summary>
        /// The Date/Time the token was last refreshed
        /// </summary>
        /// <value>
        /// The last refreshed Date/Time.
        /// </value>
        public DateTime LastRefreshed { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override String ToString()
        {
            String retVal = $"Token Id:'{Id}'. " +
                            $"Application Id:'{ApplicationId}'. " +
                            $"User Profile Id:'{UserProfileId}'. " +
                            $"Acquired:'{Acquired:yyyy-mmm-dd HH:mm:ss.fff}'. " +
                            $"Last Refreshed:'{LastRefreshed:yyyy-mmm-dd HH:mm:ss.fff}'. " +
                            $"Token:'{Token}'.";

            return retVal;
        }
    }
}
