//-----------------------------------------------------------------------
// <copyright file="FileTransferArchiveAction.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// File Transfer Archive Action
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the file transfer archive action")]
    public enum FileTransferArchiveAction
    {
        /// <summary>
        /// Value not set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// 
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Copy")]
        Copy = 1,

        /// <summary>
        /// 
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Move")]
        Move = 2,
    }
}
