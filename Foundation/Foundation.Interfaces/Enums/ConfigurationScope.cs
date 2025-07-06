//-----------------------------------------------------------------------
// <copyright file="ConfigurationScope.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Configuration Scope
    /// </summary>
    public enum ConfigurationScope
    {
        /// <summary>
        /// Not Set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// System scoped config items
        /// </summary>
        [Id(1), Display(Order = 1, Name = "System")]
        System = 1,

        /// <summary>
        /// Application scoped config items
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Application")]
        Application = 2,

        /// <summary>
        /// User scoped config items
        /// </summary>
        [Id(3), Display(Order = 3, Name = "User")]
        User = 3,
    }
}
