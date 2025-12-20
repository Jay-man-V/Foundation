//-----------------------------------------------------------------------
// <copyright file="DialogResult.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Dialog Result
    /// </summary>
    [Browsable(true),
     Category("Misc"),
     Description("Specifies the dialog result")]
    public enum DialogResult
    {
        /// <summary>
        /// The message box returns no result
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// The result value of the message box is OK.
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Ok")]
        Ok = 1,

        /// <summary>
        /// The result value of the message box is Cancel.
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Cancel")]
        Cancel = 2,

        /// <summary>
        /// The result value of the message box is Abort.
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Abort")]
        Abort = 3,

        /// <summary>
        /// The result value of the message box is Retry.
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Retry")]
        Retry = 4,

        /// <summary>
        /// The result value of the message box is Ignore.
        /// </summary>
        [Id(5), Display(Order = 5, Name = "Ignore")]
        Ignore = 5,

        /// <summary>
        /// The result value of the message box is Yes.
        /// </summary>
        [Id(6), Display(Order = 6, Name = "Yes")]
        Yes = 6,

        /// <summary>
        /// The result value of the message box is No.
        /// </summary>
        [Id(7), Display(Order = 7, Name = "No")]
        No = 7,

        /// <summary>
        /// The result value of the message box is TryAgain.
        /// </summary>
        [Id(10), Display(Order = 10, Name = "Try again")]
        TryAgain = 10,

        /// <summary>
        /// The result value of the message box is Continue.
        /// </summary>
        [Id(11), Display(Order = 11, Name = "Continue")]
        Continue = 11,
    }
}
