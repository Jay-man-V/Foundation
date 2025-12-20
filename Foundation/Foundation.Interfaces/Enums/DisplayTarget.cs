//-----------------------------------------------------------------------
// <copyright file="DisplayTarget.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The Display Target Enumeration
    /// </summary>
    [Browsable(true),
     Category("Misc"),
     Description("Specifies the display target")]
    public enum DisplayTarget
    {
        /// <summary>
        /// The display target has not been set
        /// </summary>
        [Id(0), Display(Order = 0, Name = "Not set")]
        NotSet = 0,

        /// <summary>
        /// The item is to be shown to users
        /// </summary>
        [Id(1), Display(Order = 1, Name = "User")]
        User = 1,

        /// <summary>
        /// The item is to be shown to Administrators
        /// /// </summary>
        [Id(2), Display(Order = 2, Name = "Admin")]
        Admin = 2,

        /// <summary>
        /// The item is to be shown to both Users and Administrators
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Both")]
        Both = 3
    }
}
