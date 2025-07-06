//-----------------------------------------------------------------------
// <copyright file="IUserProfile.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The User Profile model interface
    /// </summary>
    public interface IUserProfile : IFoundationModel
    {
        /// <summary>Gets the roles.</summary>
        /// <value>The roles.</value>
        IList<IRole> Roles { get; }

        /// <summary>Gets or sets the external key identifier.</summary>
        /// <value>The external key identifier.</value>
        String ExternalKeyId { get; set; }

        /// <summary>Gets or sets the Domain Name.</summary>
        /// <value>The Domain Name.</value>
        String DomainName { get; set; }

        /// <summary>Gets or sets the username.</summary>
        /// <value>The username.</value>
        String Username { get; set; }

        /// <summary>Gets or sets the display name.</summary>
        /// <value>The display name.</value>
        String DisplayName { get; set; }

        /// <summary>Gets or sets a value indicating whether this instance is system support.</summary>
        /// <value>
        ///   <c>true</c> if this instance is system support; otherwise, <c>false</c>.</value>
        Boolean IsSystemSupport { get; set; }

        /// <summary>Gets or sets the contact detail identifier.</summary>
        /// <value>The contact detail identifier.</value>
        EntityId ContactDetailId { get; set; }
    }
}
