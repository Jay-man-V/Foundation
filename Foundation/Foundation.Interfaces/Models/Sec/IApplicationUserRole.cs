//-----------------------------------------------------------------------
// <copyright file="IApplicationUserRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application/User/Role model interface
    /// </summary>
    public interface IApplicationUserRole : IFoundationModel
    {
        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the user profile identifier.</summary>
        /// <value>The user profile identifier.</value>
        EntityId UserProfileId { get; set; }

        /// <summary>Gets or sets the role identifier.</summary>
        /// <value>The role identifier.</value>
        EntityId RoleId { get; set; }
    }
}
