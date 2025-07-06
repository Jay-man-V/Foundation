//-----------------------------------------------------------------------
// <copyright file="IMainViewModel.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System;

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the Main View Model
    /// </summary>
    public interface IMainViewModel : IViewModel
    {
        /// <summary>
        /// Holds the last raised exception
        /// </summary>
        Exception LastException { get; set; }

        /// <summary>
        /// Displays a message box to the user containing details of the <paramref name="exception"/>
        /// </summary>
        /// <param name="exception"></param>
        void DisplayUnhandledExceptionMessage(Exception exception);
    }
}