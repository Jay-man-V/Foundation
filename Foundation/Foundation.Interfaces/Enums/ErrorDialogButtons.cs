//-----------------------------------------------------------------------
// <copyright file="ErrorDialogButtons.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Error Dialog Buttons
    /// </summary>
    [Flags]
    [Browsable(true),
     Category("Status"),
     Description("Specifies the error dialog buttons")]
    public enum ErrorDialogButtons
    {
        /// <summary>
        /// All
        /// </summary>
        [Id(1), Display(Order = 1, Name ="All")]
        All = 1,

        /// <summary>
        /// Continue
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Continue")]
        Continue = 2,

        /// <summary>
        /// Exit Application
        /// </summary>
        [Id(4), Display(Order = 3, Name = "Exit application")]
        ExitApplication = 4,
    }
}
