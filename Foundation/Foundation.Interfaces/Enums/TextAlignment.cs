//-----------------------------------------------------------------------
// <copyright file="TextAlignment.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.ComponentModel.DataAnnotations;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Text Alignment enum
    /// </summary>
    public enum TextAlignment
    {
        /// <summary>
        /// NotSet
        /// </summary>
        [Id(0), Display(Order = 0, Name = "NotSet")]
        NotSet = 0,

        /// <summary>
        /// Left
        /// </summary>
        [Id(1), Display(Order = 1, Name = "Left")]
        Left = 1,

        /// <summary>
        /// Centre
        /// </summary>
        [Id(2), Display(Order = 2, Name = "Centre")]
        Centre = 2,

        /// <summary>
        /// Right
        /// </summary>
        [Id(3), Display(Order = 3, Name = "Right")]
        Right = 3
    }
}
