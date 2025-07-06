//-----------------------------------------------------------------------
// <copyright file="LogSeverity.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// LogSeverity enum
    /// </summary>
    public enum LogSeverity
    {
        /// <summary>
        /// NotSet
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// Trace
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Trace")]
        Trace = 1,

        /// <summary>
        /// Information
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Information")]
        Information = 2,

        /// <summary>
        /// Success
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Success")]
        Success = 3,

        /// <summary>
        /// Audit
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Audit")]
        Audit = 4,

        /// <summary>
        /// Warning
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Warning")]
        Warning = 5,

        /// <summary>
        /// Error
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Error")]
        Error = 6,
    }
}
