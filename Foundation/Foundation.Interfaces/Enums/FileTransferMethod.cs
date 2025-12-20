//-----------------------------------------------------------------------
// <copyright file="FileTransferMethod.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// File Transfer Method
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the file transfer archive action")]
    public enum FileTransferMethod
    {
        /// <summary>
        /// Value not set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// 
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Email")]
        Email = 1,

        /// <summary>
        /// 
        /// </summary>
        [Id(2), Display(Order = 2, Name = "File System")]
        FileSystem = 2,

        /// <summary>
        /// 
        /// </summary>
        [Id(3), Display(Order = 3, Name = "File Transfer Protocol (FTP)")]
        Ftp = 3,

        /// <summary>
        /// 
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Hyper Text Transfer Protocol (HTTP)")]
        Http = 4,

        /// <summary>
        /// 
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Representational State Transfer (REST)")]
        Rest = 5,

        /// <summary>
        /// 
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Message Queuing (MQ)")]
        Mq = 6,
    }
}
