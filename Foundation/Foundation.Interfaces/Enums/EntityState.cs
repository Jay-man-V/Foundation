//-----------------------------------------------------------------------
// <copyright file="EntityState.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Entity State Enumeration
    /// </summary>
    [Browsable(true),
     Category("Status"),
     Description("Specifies the entity state")]
    public enum EntityState
    {
        /// <summary>
        /// The entity is dirty
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Dirty")]
        Dirty = 0,

        /// <summary>
        /// The entity has been saved
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Saved")]
        Saved = 1
    }
}
