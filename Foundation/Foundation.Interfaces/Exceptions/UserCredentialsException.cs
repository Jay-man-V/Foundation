//-----------------------------------------------------------------------
// <copyright file="UserCredentialsException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// User Credentials Exception - raised when there is a problem with or relating to User Credentials
    /// </summary>
    /// <seealso cref="ApplicationException" />
    public class UserCredentialsException : ApplicationException
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="UserCredentialsException"/> class.
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="userCredentials">The user credentials.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="message">The message.</param>
        public UserCredentialsException
        (
            AppId applicationId,
            String userCredentials,
            String processName,
            String message
        ) :
            base
            (
                message
            )
        {
            ApplicationId = applicationId;
            UserCredentials = userCredentials;
            ProcessName = processName;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="UserCredentialsException"/> class.
        /// </summary>
        /// <param name="applicationId">The application id</param>
        /// <param name="userCredentials">The user credentials.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public UserCredentialsException
        (
            AppId applicationId,
            String userCredentials,
            String processName,
            String message,
            Exception innerException
        ) :
            base
            (
                message,
                innerException
            )
        {
            ApplicationId = applicationId;
            UserCredentials = userCredentials;
            ProcessName = processName;
        }

        /// <summary>
        /// Gets the application id.
        /// </summary>
        /// <value>
        /// The application id.
        /// </value>
        public AppId ApplicationId { get; }

        /// <summary>
        /// Gets the user credentials.
        /// </summary>
        /// <value>
        /// The user credentials.
        /// </value>
        public String UserCredentials { get; }

        /// <summary>
        /// Gets the name of the process.
        /// </summary>
        /// <value>
        /// The name of the process.
        /// </value>
        public String ProcessName { get; }
    }
}
