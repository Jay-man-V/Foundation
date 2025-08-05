//-----------------------------------------------------------------------
// <copyright file="MouseWrapper.cs" company="JDV Software Ltd">
//     Copyright (c) JDV Software Ltd. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

using System.Windows.Input;

using Foundation.Interfaces;

namespace Foundation.ViewModels
{
    /// <summary>
    /// </summary>
    [DependencyInjectionSingleton]
    internal class MouseWrapper : IMouseWrapper
    {
        public MouseWrapper()
        {
            OverrideCursor = Cursors.Wait;
        }

        public MouseWrapper(Cursor newCursor)
        {
            OverrideCursor = newCursor;
        }

        /// <inheritdoc cref="IMouseWrapper.OverrideCursor"/>
        public Cursor OverrideCursor
        {
            get => Mouse.OverrideCursor;
            set => Mouse.OverrideCursor = value;
        }

        /// <inheritdoc cref="IMouseWrapper.New()"/>
        public IMouseWrapper New()
        {
            IMouseWrapper retVal = new MouseWrapper(Cursors.Wait);

            return retVal;
        }

        public void Dispose()
        {
            OverrideCursor = null;
        }
    }
}