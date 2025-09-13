//-----------------------------------------------------------------------
// <copyright file="DispatcherTimerWrapper.cs" company="JDV Software Ltd">
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
    internal class DispatcherTimerWrapper : IDispatcherTimerWrapper
    {
        /// <summary>
        /// 
        /// </summary>
        public DispatcherTimerWrapper()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        private DispatcherTimerWrapper(TimeSpan interval, DispatcherPriority priority, EventHandler callback, Dispatcher dispatcher)
        {
            DispatcherTimer = new DispatcherTimer(interval, priority, callback, dispatcher);
        }

        private DispatcherTimer? DispatcherTimer  {  get; }

        /// <inheritdoc cref="IDispatcherTimerWrapper.NewTimer(TimeSpan, DispatcherPriority, EventHandler)"/>
        public IDispatcherTimerWrapper NewTimer(TimeSpan interval, DispatcherPriority priority, EventHandler callback)
        {
            Dispatcher currentDispatcher = Application.Current.Dispatcher;

            IDispatcherTimerWrapper retVal = new DispatcherTimerWrapper(interval, priority, callback, currentDispatcher);

            return retVal;
        }

        /// <inheritdoc cref="IDispatcherTimerWrapper.Start()"/>
        public void Start()
        {
            if (DispatcherTimer != null)
            {
                DispatcherTimer.Start();
            }
        }
    }
}
