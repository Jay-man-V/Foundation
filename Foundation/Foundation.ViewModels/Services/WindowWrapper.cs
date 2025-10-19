//-----------------------------------------------------------------------
// <copyright file="WindowWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;

using Foundation.Interfaces;

namespace Foundation.ViewModels.Services
{
    /// <summary>
    /// </summary>
    [DependencyInjectionSingleton]
    internal class WindowWrapper : IWindowWrapper
    {
        /// <inheritdoc cref="IWindowWrapper.Close()"/>
        public void Close()
        {
            Window? window = Application.Current.MainWindow;
            window?.Close();
        }
    }
}