//-----------------------------------------------------------------------
// <copyright file="MessageType.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines Messages Types
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the message type")]
    public enum MessageType
    {
        /// <summary>
        /// The not set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// The information
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Information")]
        Information = 1,

        /// <summary>
        /// The success
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Success")]
        Success = 2,

        /// <summary>
        /// The warning
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Warning")]
        Warning = 3,

        /// <summary>
        /// The serious warning
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Serious warning")]
        SeriousWarning = 4,

        /// <summary>
        /// The error
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Error")]
        Error = 5,

        /// <summary>
        /// The fatal error
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Fatal error")]
        FatalError = 6
    }
}
