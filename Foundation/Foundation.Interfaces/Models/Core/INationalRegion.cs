//-----------------------------------------------------------------------
// <copyright file="INationalRegion.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The National Region model interface
    /// </summary>
    public interface INationalRegion : IFoundationModel
    {
        /// <summary>Gets or sets the country identifier.</summary>
        /// <value>The country identifier.</value>
        EntityId CountryId { get; set; }

        /// <summary>Gets or sets the abbreviation.</summary>
        /// <value>The abbreviation.</value>
        String Abbreviation { get; set; }

        /// <summary>Gets or sets the short name.</summary>
        /// <value>The short name.</value>
        String ShortName { get; set; }

        /// <summary>Gets or sets the full name.</summary>
        /// <value>The full name.</value>
        String FullName { get; set; }
    }
}
