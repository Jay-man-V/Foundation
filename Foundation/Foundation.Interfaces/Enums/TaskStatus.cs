//-----------------------------------------------------------------------
// <copyright file="TaskStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Task Status enum
    /// </summary>
    [Flags]
    public enum TaskStatus
    {
        /// <summary>
        /// NotSet
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// Success
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Success")]
        Success = 1,

        /// <summary>
        /// Warning
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Warning")]
        Warning = 2,

        /// <summary>
        /// Error
        /// </summary>
        [Id(4), Display(Order = 3, Name = "Error")]
        Error = 4,
    }
}
