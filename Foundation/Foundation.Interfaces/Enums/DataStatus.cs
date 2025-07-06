//-----------------------------------------------------------------------
// <copyright file="DataStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Data Status enum
    /// </summary>
    [Flags]
    public enum DataStatus
    {
        /// <summary>
        /// NotSet
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// InProgress
        /// </summary>
        [Id(1), Display(Order = 1, Name = "In Progress")]
        InProgress = 1,

        /// <summary>
        /// Ready
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Ready")]
        Ready = 2,

        /// <summary>
        /// Aborted
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Aborted")]
        Aborted = 3,
    }
}
