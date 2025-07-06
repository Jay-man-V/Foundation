//-----------------------------------------------------------------------
// <copyright file="IConfigurationScope.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Configuration Scope model interface
    /// </summary>
    public interface IConfigurationScope : IFoundationModel
    {
        /// <summary>Gets or sets the name.</summary>
        /// <value>The name.</value>
        String Name { get; set; }

        /// <summary>Gets or sets the description.</summary>
        /// <value>The description.</value>
        String Description { get; set; }

        /// <summary>Gets or sets the usage sequence.</summary>
        /// <value>The usage sequence.</value>
        Int32 UsageSequence { get; set; }
    }
}
