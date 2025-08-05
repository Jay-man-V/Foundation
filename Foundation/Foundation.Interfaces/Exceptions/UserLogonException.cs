//-----------------------------------------------------------------------
// <copyright file="UserLogonException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// User Logon Exception - raised when there is a problem logging the user in to an application
    /// </summary>
    /// <seealso cref="UserCredentialsException" />
    public class UserLogonException : UserCredentialsException
    {
        internal const String CannotLocateUserCredentials = "Cannot locate user credentials";
        internal const String ApplicationSystemLogon = "Application/System Logon";

        /// <summary>
        /// Initialises a new instance of the <see cref="UserLogonException"/> class.
        /// </summary>
        public UserLogonException
        (
            String username
        )
            : this
            (
                username,
                CannotLocateUserCredentials
            )
        { }

        /// <summary>
        /// Initialises a new instance of the <see cref="UserLogonException"/> class.
        /// </summary>
        /// <param name="userCredentials">The user credentials.</param>
        /// <param name="message">The message.</param>
        public UserLogonException
        (
            String userCredentials,
            String message
        ) :
            base
            (
                userCredentials,
                ApplicationSystemLogon,
                message
            )
        { }
    }
}
