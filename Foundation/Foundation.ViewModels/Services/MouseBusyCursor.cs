//-----------------------------------------------------------------------
// <copyright file="MouseCursor.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Input;
using System.Windows.Threading;

using Foundation.Interfaces;

namespace Foundation.ViewModels.Services
{
    /// <summary>
    ///  Contains helper methods for UI, so far just one for showing a wait cursor
    /// </summary>
    [DependencyInjectionTransient]
    internal class MouseBusyCursor : IMouseCursor
    {
        /// <summary>
        /// Initialises a new instance of the <see cref="MouseBusyCursor" /> class.
        /// </summary>
        public MouseBusyCursor
        (
            IWpfApplicationObjects wpfApplicationObjects
        )
        {
            ApplicationWrapper = wpfApplicationObjects.ApplicationWrapper;
            DispatcherTimerWrapper = wpfApplicationObjects.DispatcherTimerWrapper;
            MouseWrapper = wpfApplicationObjects.MouseWrapper;

            SetBusyState(true);
        }

        private IApplicationWrapper? ApplicationWrapper { get; }
        private IDispatcherTimerWrapper DispatcherTimerWrapper { get; }
        private IMouseWrapper MouseWrapper { get; }

        /// <summary>
        /// A value indicating whether the UI is currently busy
        /// </summary>
        internal Boolean IsBusy { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public void Dispose()
        {
            SetBusyState(false);
        }

        /// <summary>
        /// Sets the busy state to busy or not busy.
        /// </summary>
        /// <param name="busy">if set to <c>true</c> the application is now busy.</param>
        private void SetBusyState(Boolean busy)
        {
            if (busy != IsBusy)
            {
                IsBusy = busy;

                if (ApplicationWrapper != null)
                {
                    MouseWrapper.OverrideCursor = null;
                }

                if (IsBusy)
                {
                    MouseWrapper.OverrideCursor = busy ? Cursors.Wait : null;

                    TimeSpan interval = TimeSpan.FromSeconds(0);
                    DispatcherPriority dispatcherPriority = DispatcherPriority.Send;
                    IDispatcherTimerWrapper timer = DispatcherTimerWrapper.NewTimer(interval, dispatcherPriority, OnDispatcherTimer_Tick);
                    timer.Start();
                }
            }
        }

        /// <summary>
        /// Handles the Tick event of the dispatcherTimer control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void OnDispatcherTimer_Tick(Object? sender, EventArgs e)
        {
            if (sender is DispatcherTimer dispatcherTimer)
            {
                SetBusyState(IsBusy);
                dispatcherTimer.Stop();
            }
        }
    }
}
