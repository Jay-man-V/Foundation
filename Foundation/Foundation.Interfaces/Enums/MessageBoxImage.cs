//-----------------------------------------------------------------------
// <copyright file="MessageBoxImage.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Message Box Image
    /// </summary>
    [Browsable(true),
     Category("Process"),
     Description("Specifies the message box image")]
    public enum MessageBoxImage
    {
        /// <summary>
        /// No icon is displayed.
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        None = 0,

        /// <summary>
        /// The message box contains a symbol consisting of a white X in a circle with a red background.
        /// </summary>
        [Id(16), Display(Order = 1, Name = "Hand")]
        Hand = 16,

        /// <summary>
        /// The message box contains a symbol consisting of a question mark in a circle.
        /// </summary>
        [Id(32), Display(Order = 2, Name = "Question")]
        Question = 32,

        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// </summary>
        [Id(48), Display(Order = 3, Name = "Question")]
        Exclamation = 48,

        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// </summary>
        [Id(64), Display(Order = 4, Name = "Asterisk")]
        Asterisk = 64,

        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// </summary>
        [Id(16), Display(Order = 5, Name = "Stop")]
        Stop = 16,

        /// <summary>
        /// The message box contains a symbol consisting of white X in a circle with a red background.
        /// </summary>
        [Id(16), Display(Order = 6, Name = "Error")]
        Error = 16,

        /// <summary>
        /// The message box contains a symbol consisting of an exclamation point in a triangle with a yellow background.
        /// </summary>
        [Id(48), Display(Order = 7, Name = "Warning")]
        Warning = 48,

        /// <summary>
        /// The message box contains a symbol consisting of a lowercase letter i in a circle.
        /// </summary>
        [Id(64), Display(Order = 8, Name = "Information")]
        Information = 64
    }
}
