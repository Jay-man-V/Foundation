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
    public interface IConfigurationScope : IEnumModel
    {
        /// <summary>Gets or sets the usage sequence.</summary>
        /// <value>The usage sequence.</value>
        Int32 UsageSequence { get; set; }
    }
}
