//-----------------------------------------------------------------------
// <copyright file="IDispatcherTimerWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Threading;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Dispatcher Timer Wrapper
    /// </summary>
    public interface IDispatcherTimerWrapper
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="T:DispatcherTimer" /> class which uses the specified time interval, priority, event handler, and <see cref="T:Dispatcher" />.
        /// </summary>
        /// <param name="interval">The period of time between ticks.</param>
        /// <param name="priority">The priority at which to invoke the timer.</param>
        /// <param name="callback">The event handler to call when the <see cref="E:DispatcherTimer.Tick" /> event occurs.</param>
        /// <exception cref="T:ArgumentNullException">
        /// <paramref name="callback" /> is <see langword="null" />.</exception>
        /// <exception cref="T:ArgumentOutOfRangeException">
        /// <paramref name="interval" /> is less than 0 or greater than <see cref="F:Int32.MaxValue" />.
        /// </exception>
        IDispatcherTimerWrapper NewTimer(TimeSpan interval, DispatcherPriority priority, EventHandler callback);

        /// <summary>
        /// Starts the <see cref="T:System.Windows.Threading.DispatcherTimer" />.
        /// </summary>
        void Start();
    }
}
