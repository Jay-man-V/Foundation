//-----------------------------------------------------------------------
// <copyright file="Fonts.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Drawing;

namespace Foundation.Resources
{
    /// <summary>
    /// Defines the Fonts for all parts of the application
    /// </summary>
    public class Fonts
    {
        /// <summary>
        /// Gets the default application font family.
        /// </summary>
        /// <value>
        /// The default application font family.
        /// </value>
        public static FontFamily DefaultApplicationFontFamily => new FontFamily("Segoe UI");

        /// <summary>
        /// Gets the default fixed font family.
        /// </summary>
        /// <value>
        /// The default fixed font family.
        /// </value>
        public static FontFamily DefaultFixedFontFamily => new FontFamily("Lucida Console");
    }
}
