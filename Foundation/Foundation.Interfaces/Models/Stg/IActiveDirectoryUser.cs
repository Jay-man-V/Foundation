//-----------------------------------------------------------------------
// <copyright file="IActiveDirectoryUser.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Active Directory User model interface
    /// </summary>
    public interface IActiveDirectoryUser : IFoundationModel
    {
        /// <summary>Gets or sets the object security identifier.</summary>
        /// <value>The object security identifier.</value>
        String ObjectSId { get; set; }

        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        /// <value>The full name.</value>
        String FullName { get; set; }
    }
}
