//-----------------------------------------------------------------------
// <copyright file="AuthenticationTokenException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Authentication Token Exception - raised when there is a problem getting or refreshing an Authentication Token
    /// </summary>
    public class AuthenticationTokenException : Exception
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="AuthenticationTokenException"/> class.
        /// </summary>
        /// <param name="userProfileId">The user profile id.</param>
        /// <param name="message">The message.</param>
        public AuthenticationTokenException
        (
            EntityId userProfileId,
            String message
        ) :
            base
            (
                message
            )
        {
            UserProfileId = userProfileId;
        }

        /// <summary>
        /// Gets the user profile id
        /// </summary>
        public EntityId UserProfileId { get; }
    }
}
