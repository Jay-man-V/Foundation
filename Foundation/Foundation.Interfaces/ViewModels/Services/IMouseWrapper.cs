//-----------------------------------------------------------------------
// <copyright file="IMouseWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Input;

namespace Foundation.Interfaces
{
    /// <summary>
    /// The interface Mouse Wrapper
    /// </summary>
    public interface IMouseWrapper : IDisposable
    {
        ///// <summary>
        ///// Gets or sets the cursor for the entire application.
        ///// </summary>
        ///// <returns>The override cursor or <see langword="null" /> if the <see cref="P:System.Windows.Input.Mouse.OverrideCursor" /> is not set.</returns>
        Cursor? OverrideCursor { get; set; }

        /// <summary>
        /// Creates new instance of the <see cref="IMouseWrapper"/>
        /// </summary>
        /// <returns></returns>
        IMouseWrapper New();
    }
}
