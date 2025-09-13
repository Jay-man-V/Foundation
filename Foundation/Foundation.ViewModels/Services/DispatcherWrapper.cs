//-----------------------------------------------------------------------
// <copyright file="DispatcherWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows;
using System.Windows.Threading;

using Foundation.Interfaces;

namespace Foundation.ViewModels.Services
{
    /// <summary>
    /// </summary>
    [DependencyInjectionSingleton]
    internal class DispatcherWrapper : IDispatcherWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public DispatcherWrapper()
        {
            Dispatcher = Application.Current.Dispatcher;
        }

        /// <summary>
        /// Gets the <see cref="T:System.Windows.Threading.Dispatcher" /> this <see cref="T:System.Windows.Threading.DispatcherObject" /> is associated with.
        /// </summary>
        /// <returns>The dispatcher.</returns>
        private Dispatcher Dispatcher { get; }
    }
}