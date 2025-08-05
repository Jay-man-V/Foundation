//-----------------------------------------------------------------------
// <copyright file="ApplicationPermissionsException.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Application Permission Exception - raised when there is an issue with required application permissions and what the user is allowed to do
    /// </summary>
    /// <seealso cref="UserCredentialsException" />
    public class ApplicationPermissionsException : UserCredentialsException
    {
        internal const String ErrorMessageRequiredPermission = "User: '{0}' does not have the required permissions. Required permission is: '{1}'";
        internal const String ErrorMessageRequiredFunction = "User: '{0}' does not have the required permissions. Assigned Roles are: '{1}'. Function Key is: '{2}'.";

        //public ApplicationPermissionsException(String processName, ApplicationRole requiredPermissions, IFoundationModel FoundationModel)
        //    : base(LoggedOnUserCredentials, processName, String.DotNetFormat(ErrorMessageTemplate1, LoggedOnUserCredentials, String.Join(", ", requiredPermissions)))
        //{
        //    RequiredPermission = requiredPermissions;
        //    FoundationModel = FoundationModel;
        //}

        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationPermissionsException"/> class.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="requiredPermissions">The required permissions.</param>
        /// <param name="foundationModel">The foundation model.</param>
        /// <param name="userProfile">The user profile.</param>
        public ApplicationPermissionsException
        (
            String processName,
            ApplicationRole[] requiredPermissions,
            IFoundationModel? foundationModel,
            IUserProfile userProfile
        )
            : base
            (
                userProfile.Username,
                processName,
                String.Format(ErrorMessageRequiredPermission, userProfile.Username, String.Join(", ", requiredPermissions))
            )
        {
            RequiredPermission = String.Join(", ", requiredPermissions);

            FoundationModel = foundationModel;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationPermissionsException"/> class.
        /// </summary>
        /// <param name="username">The logged on users username.</param>
        /// <param name="processName">Name of the process.</param>
        /// <param name="requiredPermission">The required permission.</param>
        /// <param name="foundationModel">The foundation model.</param>
        public ApplicationPermissionsException
        (
            String username,
            String processName,
            ApplicationRole requiredPermission,
            IFoundationModel? foundationModel
        )
            : base
            (
                username,
                processName,
                String.Format(ErrorMessageRequiredPermission, username, requiredPermission)
            )
        {
            RequiredPermission = requiredPermission.ToString();
            FoundationModel = foundationModel;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="ApplicationPermissionsException"/> class.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="userProfile">The user profile.</param>
        /// <param name="functionKey">The function key.</param>
        public ApplicationPermissionsException
        (
            String processName,
            IUserProfile userProfile,
            String functionKey
        )
            : base
            (
                userProfile.Username,
                processName,
                String.Format(ErrorMessageRequiredFunction, userProfile.Username, String.Join(", ", userProfile.Roles.Select(r => r.ApplicationRole)), functionKey)
            )
        {
            RequiredPermission = String.Empty;
        }
        
        /// <summary>
        /// Gets the required permission.
        /// </summary>
        /// <value>
        /// The required permission.
        /// </value>
        public String RequiredPermission { get; }

        /// <summary>
        /// Gets the foundation model.
        /// </summary>
        /// <value>
        /// The foundation model.
        /// </value>
        public IFoundationModel? FoundationModel { get; }
    }
}
