//-----------------------------------------------------------------------
// <copyright file="IApplicationRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Application Role model interface
    /// </summary>
    public interface IApplicationRole : IEnumModel
    {
        /// <summary>Gets the role.</summary>
        /// <value>The role.</value>
        ApplicationRole Role { get; }

        /// <summary>Gets or sets the application identifier.</summary>
        /// <value>The application identifier.</value>
        AppId ApplicationId { get; set; }

        /// <summary>Gets or sets the role identifier.</summary>
        /// <value>The role identifier.</value>
        EntityId RoleId { get; set; }
    }
}
