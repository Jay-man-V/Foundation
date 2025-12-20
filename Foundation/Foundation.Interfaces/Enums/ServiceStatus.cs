//-----------------------------------------------------------------------
// <copyright file="ServiceStatus.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Service Status enum
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the service status")]
    public enum ServiceStatus
    {
        /// <summary>
        /// NotSet
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// Stopping
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Stopped")]
        Stopped = 1,

        /// <summary>
        /// Starting
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Starting")]
        StartPending = 2,

        /// <summary>
        /// Stopping
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Stopping")]
        StopPending = 3,

        /// <summary>
        /// Running
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Running")]
        Running = 4,

        /// <summary>
        /// Continuing
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Continuing")]
        ContinuePending = 5,

        /// <summary>
        /// Pause ending
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Pause ending")]
        PauseEnding = 6,

        /// <summary>
        /// Paused
        /// </summary>
        [Id(7), Display(Order = 7, Name = "Paused")]
        Paused = 7,
    }
}
