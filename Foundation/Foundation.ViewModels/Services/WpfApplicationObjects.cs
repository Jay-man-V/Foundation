//-----------------------------------------------------------------------
// <copyright file="WpfApplicationObjects.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// </summary>
    [DependencyInjectionSingleton]
    internal class WpfApplicationObjects : IWpfApplicationObjects
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="applicationWrapper"></param>
        /// <param name="clipBoardWrapper"></param>
        /// <param name="dialogService"></param>
        /// <param name="dispatcherTimerWrapper"></param>
        /// <param name="dispatcherWrapper"></param>
        /// <param name="mouseWrapper"></param>
        public WpfApplicationObjects
        (
            IApplicationWrapper applicationWrapper,
            IClipBoardWrapper clipBoardWrapper,
            IDialogService dialogService,
            IDispatcherTimerWrapper dispatcherTimerWrapper,
            IDispatcherWrapper dispatcherWrapper,
            IMouseWrapper mouseWrapper
        )
        {
            ApplicationWrapper = applicationWrapper;
            ClipBoardWrapper = clipBoardWrapper;
            DialogService = dialogService;
            DispatcherTimerWrapper = dispatcherTimerWrapper;
            DispatcherWrapper = dispatcherWrapper;
            MouseWrapper = mouseWrapper;
        }


        /// <inheritdoc cref="IWpfApplicationObjects.ApplicationWrapper"/>
        public IApplicationWrapper ApplicationWrapper { get; }

        /// <inheritdoc cref="IWpfApplicationObjects.ClipBoardWrapper"/>
        public IClipBoardWrapper ClipBoardWrapper { get; }

        /// <inheritdoc cref="IWpfApplicationObjects.DialogService"/>
        public IDialogService DialogService { get; }

        /// <inheritdoc cref="IWpfApplicationObjects.DispatcherTimerWrapper"/>
        public IDispatcherTimerWrapper DispatcherTimerWrapper { get; }

        /// <inheritdoc cref="IWpfApplicationObjects.DispatcherWrapper"/>
        public IDispatcherWrapper DispatcherWrapper { get; }

        /// <inheritdoc cref="IWpfApplicationObjects.MouseWrapper"/>
        public IMouseWrapper MouseWrapper { get; }
    }
}