//-----------------------------------------------------------------------
// <copyright file="IMessageBoxSettings.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Message Box Settings definition
    /// </summary>
    public interface IMessageBoxSettings
    {
        /// <summary>
        /// Buttons to be displayed
        /// </summary>
        MessageBoxButton Button { get; set; }

        /// <summary>
        /// Caption to be used
        /// </summary>
        String Caption { get; set; }

        /// <summary>
        /// Icon to be shown
        /// </summary>
        MessageBoxImage Icon { get; set; }

        /// <summary>
        /// Message box text
        /// </summary>
        String Text { get; set; }
    }
}
