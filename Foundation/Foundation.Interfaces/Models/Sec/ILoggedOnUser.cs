//-----------------------------------------------------------------------
// <copyright file="ILoggedOnUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Logged On User model interface
    /// </summary>
    public interface ILoggedOnUser : IFoundationModel
    {
        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the user profile identifier.</summary>
        /// <value>The user profile identifier.</value>
        EntityId UserProfileId { get; set; }

        /// <summary>Gets or sets the logged on.</summary>
        /// <value>The logged on.</value>
        DateTime LoggedOn { get; set; }

        /// <summary>Gets or sets the last active.</summary>
        /// <value>The last active.</value>
        DateTime LastActive { get; set; }

        /// <summary>Gets or sets the command.</summary>
        /// <value>The command.</value>
        String Command { get; set; }

        /// <summary>
        /// Gets the display name.
        /// </summary>
        /// <value>
        /// The display name.
        /// </value>
        String DisplayName { get; }

        /// <summary>
        /// Gets the username.
        /// </summary>
        /// <value>
        /// The username.
        /// </value>
        String Username { get; }

        /// <summary>Gets the role identifier.</summary>
        /// <value>The role identifier.</value>
        EntityId RoleId { get; }

        /// <summary>Gets a value indicating whether this instance is system support.</summary>
        /// <value>
        ///   <c>true</c> if this instance is system support; otherwise, <c>false</c>.</value>
        Boolean IsSystemSupport { get; }
    }
}
