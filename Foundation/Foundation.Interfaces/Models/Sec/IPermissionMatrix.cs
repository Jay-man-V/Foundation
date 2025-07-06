//-----------------------------------------------------------------------
// <copyright file="IPermissionMatrix.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The PermissionMatrix model interface
    /// </summary>
    public interface IPermissionMatrix : IFoundationModel
    {
        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the role identifier.</summary>
        /// <value>The role identifier.</value>
        EntityId RoleId { get; set; }

        /// <summary>Gets or sets the user profile identifier.</summary>
        /// <value>The user profile identifier.</value>
        EntityId UserProfileId { get; set; }

        /// <summary>Gets or sets the function key.</summary>
        /// <value>The function key.</value>
        String FunctionKey { get; set; }

        /// <summary>Gets or sets the permission.</summary>
        /// <value>The permission.</value>
        String Permission { get; set; }
    }
}
