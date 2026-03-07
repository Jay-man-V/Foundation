//-----------------------------------------------------------------------
// <copyright file="IViewForm.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace Foundation.Interfaces
{
    /// <summary>
    /// Defines the behaviour of the View Form class
    /// </summary>
    public interface IViewForm
    {
        /// <summary>
        /// The Data Context
        /// </summary>
        Object? DataContext { get; set; }

        /// <summary>
        /// Closes the window
        /// </summary>
        void Close();

        /// <summary>
        /// Shows the window
        /// </summary>
        void Show();
    }
}
