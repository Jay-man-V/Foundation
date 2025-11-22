//-----------------------------------------------------------------------
// <copyright file="IWpfApplicationObjects.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Collection of objects for running Wpf applications
    /// </summary>
    public interface IWpfApplicationObjects
    {
        /// <summary>
        /// Gets the <see cref="T:System.Windows.Application" /> Object for the current <see cref="T:System.AppDomain" />.
        /// </summary>
        IApplicationWrapper ApplicationWrapper { get; }

        /// <summary>
        /// 
        /// </summary>
        IClipBoardWrapper ClipBoardWrapper { get; }

        /// <summary>
        /// 
        /// </summary>
        IDialogService DialogService { get; }

        /// <summary>
        /// 
        /// </summary>
        IDispatcherTimerWrapper DispatcherTimerWrapper { get; }

        /// <summary>
        /// 
        /// </summary>
        IDispatcherWrapper DispatcherWrapper { get; }

        /// <summary>
        /// 
        /// </summary>
        IMouseWrapper MouseWrapper { get; }
    }
}
