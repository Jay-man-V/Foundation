//-----------------------------------------------------------------------
// <copyright file="MessageBoxButton.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Message Box Button
    /// </summary>
    public enum MessageBoxButton
    {
        /// <summary>
        /// The message box contains an OK button
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Ok")]
        Ok = 0,

        /// <summary>
        /// The message box contains OK and Cancel buttons
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Ok|Cancel")]
        OkCancel = 1,

        /// <summary>
        /// The message box contains Abort, Retry, and Ignore buttons
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Abort|Retry|Ignore")]
        AbortRetryIgnore = 2,

        /// <summary>
        /// The message box contains Yes, No, and Cancel buttons
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Yes|No|Cancel")]
        YesNoCancel = 3,

        /// <summary>
        /// The message box contains Yes and No buttons
        /// </summary>
        [Id(4), Display(Order = 4, Name = "Yes|No")]
        YesNo = 4,

        /// <summary>
        /// The message box contains Retry and Cancel buttons
        /// </summary>
        [Id(5), Display(Order = 4, Name = "Retry|Cancel")]
        RetryCancel = 5,

        /// <summary>
        /// Specifies that the message box contains Cancel, Try Again, and Continue buttons
        /// </summary>
        [Id(6), Display(Order = 4, Name = "Cancel|Try again|Continue")]
        CancelTryContinue = 6,
    }
}
