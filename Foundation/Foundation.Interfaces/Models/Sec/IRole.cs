//-----------------------------------------------------------------------
// <copyright file="IRole.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Role model interface
    /// </summary>
    public interface IRole : IFoundationModel
    {
        /// <summary>Gets the application role.</summary>
        /// <value>The application role.</value>
        ApplicationRole ApplicationRole { get; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }

        /// <summary>Gets a value indicating whether [system support only].</summary>
        /// <value>
        ///   <c>true</c> if [system support only]; otherwise, <c>false</c>.</value>
        Boolean SystemSupportOnly { get; }
    }
}
