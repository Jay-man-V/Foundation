//-----------------------------------------------------------------------
// <copyright file="FileTransferArchiveAction.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// File Transfer Archive Action
    /// </summary>
    public enum FileTransferArchiveAction
    {
        /// <summary>
        /// Value not set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "NotSet")]
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
