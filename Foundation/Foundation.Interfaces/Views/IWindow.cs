//-----------------------------------------------------------------------
// <copyright file="IWindow.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Window class
    /// </summary>
    public interface IWindow
    {
        /// <summary>
        /// The Data Context
        /// </summary>
        Object? DataContext { get; set; }

        /// <summary>
        /// Closes the window
        /// </summary>
        void Close();

        /// <summary>
        /// Shows the window
        /// </summary>
        void Show();
    }
}
