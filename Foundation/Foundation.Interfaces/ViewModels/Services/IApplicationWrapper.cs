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

        /// <summary>
        ///     Shutdown is called to programmatically shut down an application.
        ///
        ///     Once shutdown() is called, the application gets called with the
        ///     OnShutdown method to raise the Shutdown event.
        ///     The exitCode parameter passed in at Shutdown will be returned as a
        ///     return parameter on the run() method, so it can be passed back to the OS.
        /// </summary>
        /// <remarks>
        ///     Callers must have UIPermission(UIPermissionWindow.AllWindows) to call this API.
        /// </remarks>
        /// <param name="exitCode">returned to the Application.Run() method. Typically, this will be returned to the OS</param>
        void Shutdown(Int32 exitCode);
    }
}
