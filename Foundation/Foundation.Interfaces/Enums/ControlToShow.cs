//-----------------------------------------------------------------------
// <copyright file="ControlToShowValue.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Control to show
    /// </summary>
    [Browsable(true),
     Category("Misc"),
     Description("Specifies the type of control to show")]
    public enum ControlToShow
    {
        /// <summary>
        /// List Control
        /// </summary>
        [Id(0), Display(Order = 1, Name = "List control"), Category(""), Description("This is a List Control")]
        ListControl = 0,

        /// <summary>
        /// Bar Control
        /// </summary>
        [Id(1), Display(Order = 2, Name = "Bar control"), Category(""), Description("This is a Bar Control")]
        BarControl = 1,
    }
}
