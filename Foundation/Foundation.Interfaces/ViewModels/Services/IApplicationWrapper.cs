//-----------------------------------------------------------------------
// <copyright file="IApplicationWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Application Wrapper
    /// </summary>
    public interface IApplicationWrapper
    {
        /// <summary>
        /// Gets or sets the main window of the application.
        /// </summary>
        /// <returns>A <see cref="T:System.Windows.Window" /> that is designated as the main application window.</returns>
        /// <exception cref="T:System.InvalidOperationException">
        /// <see cref="P:System.Windows.Application.MainWindow" /> is set from an application that's hosted in a browser, such as an XAML browser applications (XBAPs).</exception>
        IWindowWrapper MainWindow { get; }
    }
}
